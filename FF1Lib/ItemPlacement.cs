﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using RomUtilities;

namespace FF1Lib
{
	public static class ItemPlacement
	{
		public static List<IRewardSource> PlaceSaneItems(MT19337 rng,
														ITreasureShuffleFlags flags,
														IncentiveData incentivesData,
														List<Item> allTreasures,
														ItemShopSlot caravanItemLocation,
														Dictionary<MapLocation, List<MapChange>> mapLocationRequirements)
		{
			long sanityCounter = 0;
			List<IRewardSource> placedItems;
			
			var incentiveLocationPool = incentivesData.IncentiveLocations.ToList();
			var incentivePool = incentivesData.IncentiveItems.ToList();
			var forcedItems = incentivesData.ForcedItemPlacements.ToList();
			var bridgeLocations = incentivesData.BridgeLocations.ToList();
			var shipLocations = incentivesData.ShipLocations.ToList();
			var itemLocationPool = incentivesData.AllValidItemLocations.ToList();
			
			var unincentivizedQuestItems =
				ItemLists.AllQuestItems
					.Where(x => !incentivePool.Contains(x) &&
								x != Item.Ship && x != Item.Bridge && x != Item.Bottle &&
								!forcedItems.Any(y => y.Item == x)).ToList();

			var treasurePool = allTreasures.ToList();
			treasurePool.Remove(Item.Bridge);
			treasurePool.Remove(Item.Ship);

			foreach (var incentive in incentivePool)
			{
				treasurePool.Remove(incentive);
			}
			foreach (var placement in forcedItems)
			{
				treasurePool.Remove(placement.Item);
			}
			foreach (var questItem in unincentivizedQuestItems)
			{
				treasurePool.Remove(questItem);
			}
			while (treasurePool.Remove(Item.Shard))
			{
				unincentivizedQuestItems.Add(Item.Shard);
			}
			do
			{
				sanityCounter++;
				if (sanityCounter > 10000) throw new InvalidOperationException("Invalid flag set");
				// 1. (Re)Initialize lists inside of loop
				placedItems = forcedItems.ToList();
				var incentives = incentivePool.ToList();
				incentives.Shuffle(rng);

				if (flags.NPCItems)
				{
					// 2. Place caravan item first because among incentive locations it has the smallest set of possible items
					if (!placedItems.Any(x => x.Address == ItemLocations.CaravanItemShop1.Address))
					{
						var itemPick = Item.Bottle;
						var validShopIncentives = incentives
							.Where(x => x > Item.None && x <= Item.Soft)
							.ToList();
						if (validShopIncentives.Any())
						{
							itemPick = validShopIncentives.PickRandom(rng);
							incentives.Remove(itemPick);
						}
						else if (placedItems.Any(x => x.Item == Item.Bottle))
						{
							itemPick = ItemLists.AllConsumables.ToList().PickRandom(rng);
						}
						else
						{
							treasurePool.Remove(Item.Bottle);
						}

						placedItems.Add(new ItemShopSlot(caravanItemLocation, itemPick));
					}

					// 3. Place Bridge and Ship next since the valid location lists are so small
					IRewardSource bridgePlacement = bridgeLocations.PickRandom(rng);
					placedItems.Add(NewItemPlacement(bridgePlacement, Item.Bridge));

					var shipPlacement =
							shipLocations
								.Where(x => x.Address != bridgePlacement.Address)
								.ToList().PickRandom(rng);
					placedItems.Add(NewItemPlacement(shipPlacement, Item.Ship));
				}

				// 4. Then place all incentive locations that don't have special logic
				foreach (var incentiveLocation in incentiveLocationPool.Where(x => !placedItems.Any(y => y.Address == x.Address)))
				{
					if (!incentives.Any()) break;
					placedItems.Add(NewItemPlacement(incentiveLocation, incentives.SpliceRandom(rng)));
				}

				// 5. Then place remanining incentive items and unincentivized quest items in any other chest before ToFR
				var leftoverItems = incentives.Concat(unincentivizedQuestItems).ToList();
				leftoverItems.Shuffle(rng);
				var leftoverItemLocations =
					itemLocationPool
						 .Where(x => !ItemLocations.ToFR.Any(y => y.Address == x.Address) &&
								!x.IsUnused && !placedItems.Any(y => y.Address == x.Address))
						 .ToList();
				foreach (var leftoverItem in leftoverItems)
				{
					placedItems.Add(NewItemPlacement(leftoverItemLocations.SpliceRandom(rng), leftoverItem));
				}

				// 6. Check sanity and loop if needed
			} while (!CheckSanity(placedItems, flags, mapLocationRequirements));

			// 7. Place all remaining unincentivized treasures or incentivized non-quest items that weren't placed
			var i = 0;
			itemLocationPool =
				itemLocationPool
					 .Where(x => !x.IsUnused && !placedItems.Any(y => y.Address == x.Address))
					.ToList();
			foreach (var placedItem in placedItems)
			{
				incentivePool.Remove(placedItem.Item);
			}
			foreach (var unplacedIncentive in incentivePool)
			{
				treasurePool.Add(unplacedIncentive);
			}
			treasurePool.Shuffle(rng);
			foreach (var remainingTreasure in itemLocationPool)
			{
				placedItems.Add(NewItemPlacement(remainingTreasure, treasurePool[i]));
				i++;
			}

			//Debug.WriteLine($"Sanity Check Fails: {sanityCounter}");
			return placedItems;
		}

		public static IRewardSource NewItemPlacement(IRewardSource copyFromSource, Item newItem)
		{
			if (copyFromSource is MapObject)
			{
				return new MapObject(copyFromSource as MapObject, newItem);
			}
			else
			{
				return new TreasureChest(copyFromSource, newItem);
			}
		}

		public static bool CheckSanity(List<IRewardSource> treasurePlacements,
										ITreasureShuffleFlags flags,
										Dictionary<MapLocation, List<MapChange>> mapLocationRequirements)
		{
			const int maxIterations = 20;
			var currentIteration = 0;
			var currentAccess = AccessRequirement.None;
			var currentMapChanges = MapChange.None;
			var allMapLocations = Enum.GetValues(typeof(MapLocation))
									  .Cast<MapLocation>().ToList();
			Func<IEnumerable<MapLocation>> currentMapLocations =
				() => allMapLocations
					.Where(x => mapLocationRequirements[x]
						   .Any(y => currentMapChanges.HasFlag(y)));
			Func<IEnumerable<IRewardSource>> currentItemLocations =
				() => treasurePlacements
						   .Where(x => {
							   var locations = currentMapLocations().ToList();
							   return locations.Contains(x.MapLocation) &&
										currentAccess.HasFlag(x.AccessRequirement) &&
											   (!(x is MapObject) || locations.Contains(((MapObject)x).SecondLocation));
						   });

			var winTheGameAccess = ItemLocations.ChaosReward.AccessRequirement;
			var winTheGameLocation = ItemLocations.ChaosReward.MapLocation;
			var accessibleLocationCount = currentItemLocations().Count();
			var requiredAccess = winTheGameAccess;
			if (!flags.EarlyOrdeals)
				requiredAccess |= AccessRequirement.Crown;
			var requiredMapChanges = MapChange.None;
			if (flags.MapTitansTrove)
				requiredMapChanges |= MapChange.TitanFed;

			while (!currentAccess.HasFlag(requiredAccess) ||
				   !currentMapChanges.HasFlag(requiredMapChanges) ||
				   !currentMapLocations().Contains(winTheGameLocation))
			{
				if (currentIteration > maxIterations)
				{
					throw new InvalidOperationException($"Sanity Check hit max iterations: {currentIteration}");
				}
				currentIteration++;
				var currentItems = currentItemLocations().Select(x => x.Item).ToList();

				if (!currentAccess.HasFlag(AccessRequirement.Key) &&
					currentItems.Contains(Item.Key))
					currentAccess |= AccessRequirement.Key;
				if (!currentMapChanges.HasFlag(MapChange.Bridge) &&
					currentItems.Contains(Item.Bridge) &&
					currentMapLocations().Contains(MapLocation.BridgeLocation))
					currentMapChanges |= MapChange.Bridge;
				if (!currentAccess.HasFlag(AccessRequirement.Crown) &&
					currentItems.Contains(Item.Crown))
					currentAccess |= AccessRequirement.Crown;
				if (!currentAccess.HasFlag(AccessRequirement.Crystal) &&
					currentItems.Contains(Item.Crystal))
					currentAccess |= AccessRequirement.Crystal;
				if (!currentAccess.HasFlag(AccessRequirement.Herb) &&
					currentItems.Contains(Item.Herb))
					currentAccess |= AccessRequirement.Herb;
				if (!currentMapChanges.HasFlag(MapChange.Canoe) &&
					currentItems.Contains(Item.Canoe))
					currentMapChanges |= MapChange.Canoe;
				if (!currentMapChanges.HasFlag(MapChange.Ship) &&
					currentItems.Contains(Item.Ship) &&
					currentMapLocations().Contains(MapLocation.ShipLocation))
					currentMapChanges |= MapChange.Ship;
				if (!currentAccess.HasFlag(AccessRequirement.Tnt) &&
					currentItems.Contains(Item.Tnt))
					currentAccess |= AccessRequirement.Tnt;
				if (!currentAccess.HasFlag(AccessRequirement.Adamant) &&
					currentItems.Contains(Item.Adamant))
					currentAccess |= AccessRequirement.Adamant;
				if (!currentMapChanges.HasFlag(MapChange.Canal) &&
					currentItems.Contains(Item.Canal) &&
					currentMapChanges.HasFlag(MapChange.Ship))
					currentMapChanges |= MapChange.Canal;
				if (!currentMapChanges.HasFlag(MapChange.TitanFed) &&
					currentItems.Contains(Item.Ruby) &&
					currentMapLocations().Contains(MapLocation.TitansTunnelEast))
					currentMapChanges |= MapChange.TitanFed;
				if (!currentAccess.HasFlag(AccessRequirement.Rod) &&
					currentItems.Contains(Item.Rod))
					currentAccess |= AccessRequirement.Rod;
				if (!currentAccess.HasFlag(AccessRequirement.Slab) &&
					currentItems.Contains(Item.Slab))
					currentAccess |= AccessRequirement.Slab;
				if (!currentMapChanges.HasFlag(MapChange.Airship) &&
					(currentItems.Contains(Item.Floater)) && // || currentItems.Contains(Item.Airship)) &&
					currentMapLocations().Contains(MapLocation.AirshipLocation))
					currentMapChanges |= MapChange.Airship;

				if (!currentAccess.HasFlag(AccessRequirement.Bottle) &&
					currentItems.Contains(Item.Bottle))
					currentAccess |= AccessRequirement.Bottle;
				if (!currentAccess.HasFlag(AccessRequirement.Oxyale) &&
					currentItems.Contains(Item.Oxyale))
					currentAccess |= AccessRequirement.Oxyale;
				if (!currentMapChanges.HasFlag(MapChange.Chime) &&
					currentItems.Contains(Item.Chime) &&
					currentMapChanges.HasFlag(MapChange.Airship))
					currentMapChanges |= MapChange.Chime;
				if (!currentAccess.HasFlag(AccessRequirement.Cube) &&
					currentItems.Contains(Item.Cube))
					currentAccess |= AccessRequirement.Cube;
				if (!currentAccess.HasFlag(AccessRequirement.BlackOrb) &&
					ItemLists.AllOrbs.All(y => currentItems.Contains(y)))
					currentAccess |= AccessRequirement.BlackOrb;
				if (!currentAccess.HasFlag(AccessRequirement.Lute) &&
					currentItems.Contains(Item.Lute))
					currentAccess |= AccessRequirement.Lute;

				var newCount = currentItemLocations().Count();
				if (newCount <= accessibleLocationCount)
				{
					return false;
				}
				accessibleLocationCount = newCount;
			}

			return true;
		}
	}
}
