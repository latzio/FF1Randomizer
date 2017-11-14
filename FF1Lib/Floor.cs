using RomUtilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FF1Lib
{
	public enum MapIndex : byte
	{
		ConeriaTown = 0,
		Provoka = 1,
		Elfland = 2,
		Melmond = 3,
		CrescentLake = 4,
		Gaia = 5,
		Onrac = 6,
		Lefein = 7,
		ConeriaCastle1F = 8,
		EflandCastle = 9,
		NorthwestCastle = 10,
		CastleOrdeals1F = 11,
		TemploOfFiends = 12,
		EarthCaveB1 = 13,
		GurguVolcanoB1 = 14,
		IceCaveB1 = 15,
		Cardia = 16,
		BahamutCaveB1 = 17,
		Waterfall = 18,
		DwarfCave = 19,
		MatoyasCave = 20,
		SardasCave = 21,
		MarshCaveB1 = 22,
		MirageTower1F = 23,
		ConeriaCastle2F = 24,
		CastleOrdeals2F = 25,
		CastleOrdeals3F = 26,
		MarshCaveB2 = 27,
		MarshCaveB3 = 28,
		EarthCaveB2 = 29,
		EarthCaveB3 = 30,
		EarthCaveB4 = 31,
		EarthCaveB5 = 32,
		GurguVolcanoB2 = 33,
		GurguVolcanoB3 = 34,
		GurguVolcanoB4 = 35,
		GurguVolcanoB5 = 36,
		IceCaveB2 = 37,
		IceCaveB3 = 38,
		BahamutsRoomB2 = 39,
		MirageTower2F = 40,
		MirageTower3F = 41,
		SeaShrineB5 = 42,
		SeaShrineB4 = 43,
		SeaShrineB3 = 44,
		SeaShrineB2 = 45,
		SeaShrineB1 = 46,
		SkyPalace1F = 47,
		SkyPalace2F = 48,
		SkyPalace3F = 49,
		SkyPalace4F = 50,
		SkyPalace5F = 51,
		TempleOfFiends1F = 52,
		TempleOfFiends2F = 53,
		TempleOfFiends3F = 54,
		TempleOfFiendsEarth = 55,
		TempleOfFiendsFire = 56,
		TempleOfFiendsWater = 57,
		TempleOfFiendsAir = 58,
		TempleOfFiendsChaos = 59,
		TitansTunnel = 60,
	}

	public enum Tileset : byte
	{
		Town = 0,
		Castle = 1,
		EarthFire = 2,
		IceCardiaWaterfall = 3,
		MirageMarsh = 4,
		SeaShrine = 5,
		SkyPalace = 6,
		ToF = 7,
	}

	public enum Teleporter : byte
	{
		CorneriaCastle1 = 0,
		TimeWarp = 1,
		MarshCave1 = 2,
		MarshCave2 = 3,
		MarshCave3 = 4,
		EarthCave1 = 5,
		EarthCave2 = 6,
		EarthCave3 = 7,
		EarthCave4 = 8,
		Gurgu1 = 9,
		Gurgu2 = 10,
		Gurgu3 = 11,
		Gurgu4 = 12,
		Gurgu5 = 13,
		Gurgu6 = 14,
		IceCave1 = 15,
		IceCave2 = 16,
		IceCave3 = 17,
		IceCave4 = 18,
		IceCave5 = 19,
		IceCave6 = 20,
		IceCave7 = 21,
		CastleOrdeals1 = 22,
		CastleOrdeals2 = 23,
		CastleOrdeals3 = 24,
		BahamutsRoom = 25,
		CastleOrdeals4 = 26,
		CastleOrdeals5 = 27,
		CastleOrdeals6 = 28,
		CastleOrdeals7 = 29,
		CastleOrdeals8 = 30,
		CastleOrdeals9 = 31,
		SeaShrine1 = 32,
		SeaShrine2 = 33,
		SeaShrine3 = 34,
		SeaShrine4 = 35,
		SeaShrine5 = 36,
		SeaShrine6 = 37,
		SeaShrine7 = 38,
		SeaShrine8 = 39,
		SeaShrine9 = 40,
		MirageTower1 = 41,
		MirageTower2 = 42,
		SkyPalace1 = 43,
		SkyPalace2 = 44,
		SkyPalace3 = 45,
		SkyPalace4 = 46,
		SkyPalace5 = 47,
		TempleOfFiends1 = 48,
		TempleOfFiends2 = 49,
		TempleOfFiends3 = 50,
		TempleOfFiends4 = 51,
		TempleOfFiends5 = 52,
		TempleOfFiends6 = 53,
		TempleOfFiends7 = 54,
		TempleOfFiends8 = 55,
		TempleOfFiends9 = 56,
		TempleOfFiends10 = 57,
		CastleOrdeals10 = 58,
		CastleOrdeals11 = 59,
		CastleOrdeals12 = 60,
		CastleOrdeals13 = 61,
		ConeriaCastle = 62,
		RescuePrincess = 63,
	}

	public enum OverworldExit : byte
	{ 
		ExitTitanE = 0,
		ExitTitanW = 1,
		ExitIceCave = 2,
		ExitCastleOrrdeals = 3,
		ExitCastleConeria = 4,
		ExitEarthCave = 5,
		ExitGurguVolcano = 6,
		ExitSeaShrine = 7,
		ExitSkyCastle = 8,
		ExitUnused1 = 9,
		ExitUnused2 = 10,
		ExitUnused3 = 11,
		ExitUnused4 = 12,
		ExitUnused5 = 13,
		ExitUnused6 = 14,
		ExitUnused7 = 15,
	}

	public class FloorDestination
	{
		public MapLocation Location { get; set; }
		public MapIndex Index { get; set; }
		public Tileset Tileset { get; set; }

		public byte CoordinateX { get; set; }
		public byte CoordinateY { get; set; }

		public FloorDestination(MapLocation location, MapIndex index, Tileset tileset, byte x, byte y)
		{
			Location = location;
			Index = index;
			Tileset = tileset;
			CoordinateX = x;
			CoordinateY = y;			
		}
	}

	public abstract class TeleporterBase
	{
		public Floor Destination;

		public abstract void Write(NesRom rom);
	}

	public class FloorTeleporter : TeleporterBase
	{
		private int TeleporterMapIndexOffset = 0x2D80;
		private int TeleporterXCoordOffset = 0x2D00;
		private int TeleporterYCoordOffset = 0x2D40;
	
		public Teleporter Teleporter { get; }
		public AccessRequirement AccessRequirement { get; }

		public FloorTeleporter(Teleporter teleporter, AccessRequirement requirement = AccessRequirement.None)
		{
			Destination = null;
			Teleporter = teleporter;
			AccessRequirement = requirement;
		}

		public override void Write(NesRom rom)
		{
			rom.Put(TeleporterMapIndexOffset + (int)Teleporter, new byte[] { (byte)Destination.EntryPoint.Index });
			rom.Put(TeleporterXCoordOffset + (int)Teleporter, new byte[] { Destination.EntryPoint.CoordinateX });
			rom.Put(TeleporterYCoordOffset + (int)Teleporter, new byte[] { Destination.EntryPoint.CoordinateY });
		}
	}

	public class DungeonExit : TeleporterBase
	{
		public OverworldExit Exit { get; }

		public DungeonExit(OverworldExit exit)
		{
			Exit = exit;
		}

		public override	void Write(NesRom rom)
		{
			// This needs to do the thing.
		}
	}

	public class Floor
	{
		public FloorDestination EntryPoint;
		public Floor Parent;

		public List<TeleporterBase> Exits;
		public List<IRewardSource> Rewards;

		public Floor(FloorDestination entryPoint, Floor parent, TeleporterBase primaryExit = null, TeleporterBase secondaryExit = null)
		{
			EntryPoint = entryPoint;
			Parent = parent;
			if (Parent != null)
			{
				Parent.Exits.Find(exit => exit.Destination == null).Destination = this;
			}

			Exits = new List<TeleporterBase>();
			if (primaryExit != null)
			{
				Exits.Add(primaryExit);
			}
			if (secondaryExit != null)
			{
				Exits.Add(secondaryExit);
			}

		}

		public void SwapWith(Floor other)
		{
			if (this == other)
			{
				return;
			}

			if (Parent == other)
			{
				other.SwapWith(this);
				return;
			}

			if (Exits.Count != other.Exits.Count)
			{
				throw new Exception("Mismatched floors.");
			}

			// Other can still be my child but not the other way around.
			var oldParent = Parent;
			var oldParentExit = oldParent == null ? null : Parent.Exits.Find(exit => exit.Destination == this);

			var newParent = other.Parent == this ? other : other.Parent;

			// Traditional case when we're unrelated
			if (newParent != other)
			{
				// Swap parents' destinations
				var newParentExit = newParent == null ? null : newParent.Exits.Find(exit => exit.Destination == other);
				if (newParentExit != null)
				{
					newParentExit.Destination = this;
				}

				if (oldParentExit != null)
				{
					oldParentExit.Destination = other;
				}

				// Swap parents
				Parent = newParent;
				other.Parent = oldParent;

				// Swap destinations
				if (Exits.Count > 0)
				{
					var myOldDestination = Exits[0].Destination;
					Exits[0].Destination = other.Exits[0].Destination;
					if (Exits[0].Destination != null)
					{ 
						Exits[0].Destination.Parent = this;
					}

					other.Exits[0].Destination = myOldDestination;
					if (other.Exits[0].Destination != null)
					{
						other.Exits[0].Destination.Parent = other;
					}
				}
				
			}
			else // Other is my child and is going to become my parent
			{
				// Update my parent's destinations
				if (oldParentExit != null)
				{
					oldParentExit.Destination = other;
				}

				// Swap "parents"
				other.Parent = Parent;
				Parent = other;

				if (Exits.Count > 0)
				{
					Exits[0].Destination = other.Exits[0].Destination;
					if (Exits[0].Destination != null)
					{
						Exits[0].Destination.Parent = this;
					}

					other.Exits[0].Destination = this;
				}
			}


		}

		public void write(NesRom rom)
		{
			Exits.ForEach(exit =>
			{
				if (exit.Destination != null)
				{
					exit.Destination.write(rom);
				}
			});
		}

		public void print(string indentation = "")
		{
			System.Diagnostics.Debug.WriteLine($"{indentation} -> {Enum.GetName(typeof(MapIndex), EntryPoint.Index)} [{EntryPoint.CoordinateX}, {EntryPoint.CoordinateY}]");
			Exits.ForEach(exit =>
			{
				if (exit.Destination != null)
				{
					exit.Destination.print(indentation + "\t");
				}
			});
		}

	}

}
