using RomUtilities;

using System.Collections.Generic;


namespace FF1Lib
{
	public partial class FF1Rom : NesRom
	{
		

		public void ShuffleFloors(MT19337 rng)
		{

			// Towns (Note Onrac is a CommonFloor not a dead end like the others.)
			var ConeriaTown = Floor.Create(MapLocation.ConeriaTown, MapIndex.ConeriaTown, Tileset.Town, 16, 23);
			var Pravoka = Floor.Create(MapLocation.Pravoka, MapIndex.Pravoka, Tileset.Town, 19, 32);
			var ElflandTown = Floor.Create(MapLocation.ElflandTown, MapIndex.Elfland, Tileset.Town, 41, 22);
			var Melmond = Floor.Create(MapLocation.Melmond, MapIndex.Melmond, Tileset.Town, 1, 16);
			var CresentLake = Floor.Create(MapLocation.CresentLake, MapIndex.CrescentLake, Tileset.Town, 11, 23);
			var Gaia = Floor.Create(MapLocation.Gaia, MapIndex.Gaia, Tileset.Town, 61, 61);
			var Onrac = Floor.Create(MapLocation.Onrac, MapIndex.Onrac, Tileset.Town, 1, 12, Teleporter.SeaShrine1, AccessRequirement.Oxyale);
			var Lefein = Floor.Create(MapLocation.Lefein, MapIndex.Lefein, Tileset.Town, 19, 23);

			// Castles (Entirely not Floor Shuffled yet...)
			var ConeriaCastle = Floor.Create(MapLocation.ConeriaCastle, MapIndex.ConeriaCastle1F, Tileset.Castle, 12, 35, OverworldExit.ExitCastleConeria);
			var ElflandCastle = Floor.Create(MapLocation.ElflandCastle, MapIndex.ElflandCastle, Tileset.Castle, 16, 31);
			var NorthwestCastle = Floor.Create(MapLocation.NorthwestCastle, MapIndex.NorthwestCastle, Tileset.Castle, 22, 24);
			var CastleOrdeals = Floor.Create(MapLocation.CastleOrdeals, MapIndex.CastleOrdeals1F, Tileset.Castle, 12, 21, OverworldExit.ExitCastleOrdeals);
			var TempleOfFiends = Floor.Create(MapLocation.TempleOfFiends, MapIndex.TemploOfFiends, Tileset.SeaShrine, 20, 30);

			// Ice Cave / Cardia / Waterfall Tileset
			var DwarfCave = Floor.Create(MapLocation.DwarfCave, MapIndex.DwarfCave, Tileset.IceCardiaWaterfall, 22, 11);
			var MatoyasCave = Floor.Create(MapLocation.MatoyasCave, MapIndex.MatoyasCave, Tileset.IceCardiaWaterfall, 15, 11);
			var SardasCave = Floor.Create(MapLocation.SardasCave, MapIndex.SardasCave, Tileset.IceCardiaWaterfall, 18, 13);
			var Cardia1 = Floor.Create(MapLocation.Cardia1, MapIndex.Cardia, Tileset.IceCardiaWaterfall, 30, 18);
			var Cardia2 = Floor.Create(MapLocation.Cardia2, MapIndex.Cardia, Tileset.IceCardiaWaterfall, 12, 15);
			var BahamutCaveB1 = Floor.Create(MapLocation.Cardia3, MapIndex.BahamutCaveB1, Tileset.IceCardiaWaterfall, 2, 2, Teleporter.BahamutsRoom);
			var BahamutCaveB2 = Floor.Create(MapLocation.Cardia3, MapIndex.BahamutCaveB2, Tileset.IceCardiaWaterfall, 23, 45);
			var Cardia4 = Floor.Create(MapLocation.Cardia4, MapIndex.Cardia, Tileset.IceCardiaWaterfall, 19, 36);
			var Cardia5 = Floor.Create(MapLocation.Cardia5, MapIndex.Cardia, Tileset.IceCardiaWaterfall, 43, 29);
			var Cardia6 = Floor.Create(MapLocation.Cardia6, MapIndex.Cardia, Tileset.IceCardiaWaterfall, 58, 55);

			var IceCaveB1 = Floor.Create(MapLocation.IceCave, MapIndex.IceCaveB1, Tileset.IceCardiaWaterfall, 7, 1, Teleporter.IceCave1);
			var IceCaveB2 = Floor.Create(MapLocation.IceCave, MapIndex.IceCaveB2, Tileset.IceCardiaWaterfall, 30, 2, Teleporter.IceCave2);
			var IceCaveB3 = Floor.Create(MapLocation.IceCave, MapIndex.IceCaveB3, Tileset.IceCardiaWaterfall, 3, 2, Teleporter.IceCave3);
			var IceCaveB4 = Floor.Create(MapLocation.IceCave, MapIndex.IceCaveB2, Tileset.IceCardiaWaterfall, 55, 5, OverworldExit.ExitIceCave); // Everything after the stairs before the FLOATER room.

			var Waterfall = Floor.Create(MapLocation.Waterfall, MapIndex.Waterfall, Tileset.IceCardiaWaterfall, 0x39, 0x38);

			// Earth / Fire / Tita's Tileset
			// This ain't quite right because it doesn't know they're connected yet....
			var TitansTunnelA = Floor.Create(MapLocation.TitansTunnelEast, MapIndex.TitansTunnel, Tileset.EarthFireTitans, 11, 14, OverworldExit.ExitTitanE);
			var TitansTunnelB = Floor.Create(MapLocation.TitansTunnelWest, MapIndex.TitansTunnel, Tileset.EarthFireTitans, 5, 3, OverworldExit.ExitTitanW);

			var EarthCaveB1 = Floor.Create(MapLocation.EarthCave, MapIndex.EarthCaveB1, Tileset.EarthFireTitans, 23, 24, Teleporter.EarthCave1);
			var EarthCaveB2 = Floor.Create(MapLocation.EarthCave, MapIndex.EarthCaveB2, Tileset.EarthFireTitans, 10, 9, Teleporter.EarthCave2);
			var EarthCaveB3 = Floor.Create(MapLocation.EarthCave, MapIndex.EarthCaveB3, Tileset.EarthFireTitans, 27, 45, Teleporter.EarthCave3, AccessRequirement.Rod);
			var EarthCaveB4 = Floor.Create(MapLocation.EarthCave, MapIndex.EarthCaveB4, Tileset.EarthFireTitans, 61, 33, Teleporter.EarthCave4);
			var EarthCaveB5 = Floor.Create(MapLocation.EarthCave, MapIndex.EarthCaveB5, Tileset.EarthFireTitans, 25, 53, OverworldExit.ExitEarthCave);

			var GurguVolcanoB1 = Floor.Create(MapLocation.GurguVolcano, MapIndex.GurguVolcanoB1, Tileset.EarthFireTitans, 27, 15, Teleporter.Gurgu1);
			var GurguVolcanoB2 = Floor.Create(MapLocation.GurguVolcano, MapIndex.GurguVolcanoB2, Tileset.EarthFireTitans, 30, 32, Teleporter.Gurgu2);
			var GurguVolcanoB3A = Floor.Create(MapLocation.GurguVolcano, MapIndex.GurguVolcanoB3, Tileset.EarthFireTitans, 18, 2, Teleporter.Gurgu3);
			var GurguVolcanoB4A = Floor.Create(MapLocation.GurguVolcano, MapIndex.GurguVolcanoB4, Tileset.EarthFireTitans, 3, 23, Teleporter.Gurgu4);
			var GurguVolcanoB3B = Floor.Create(MapLocation.GurguVolcano, MapIndex.GurguVolcanoB3, Tileset.EarthFireTitans, 46, 23, Teleporter.Gurgu5);
			var GurguVolcanoB4B = Floor.Create(MapLocation.GurguVolcano, MapIndex.GurguVolcanoB4, Tileset.EarthFireTitans, 35, 6, Teleporter.Gurgu6);
			var GurguVolcanoB5 = Floor.Create(MapLocation.GurguVolcano, MapIndex.GurguVolcanoB5, Tileset.EarthFireTitans, 32, 31, OverworldExit.ExitGurguVolcano);

			// Mirage / Marsh
			var MarshCaveB1 = Floor.Create(MapLocation.MarshCave, MapIndex.MarshCaveB1, Tileset.MirageMarsh, 21, 27, Teleporter.MarshCave1, Teleporter.MarshCave3); // Top floor + large empty second floor
			var MarshCaveB2 = Floor.Create(MapLocation.MarshCave, MapIndex.MarshCaveB2, Tileset.MirageMarsh, 18, 16);
			var MarshCaveB3 = Floor.Create(MapLocation.MarshCave, MapIndex.MarshCaveB3, Tileset.MirageMarsh, 5, 6);

			var MirageTower1F = Floor.Create(MapLocation.MirageTower, MapIndex.MirageTower1F, Tileset.MirageMarsh, 17, 31, Teleporter.MirageTower1);
			var MirageTower2F = Floor.Create(MapLocation.MirageTower, MapIndex.MirageTower2F, Tileset.MirageMarsh, 16, 31, Teleporter.MirageTower2);
			var MirageTower3F = Floor.Create(MapLocation.MirageTower, MapIndex.MirageTower3F, Tileset.MirageMarsh, 8, 1, Teleporter.SkyPalace2, AccessRequirement.Cube); // Includes SkyPalace1F due to in room like Marsh

			// Sea Shrine
			var SeaShrineB1 = Floor.Create(MapLocation.Onrac, MapIndex.SeaShrineB1, Tileset.SeaShrine, 12, 26); // Mermaids
			var SeaShrineB2A = Floor.Create(MapLocation.Onrac, MapIndex.SeaShrineB2, Tileset.SeaShrine, 45, 8, Teleporter.SeaShrine3);
			var SeaShrineB3A = Floor.Create(MapLocation.Onrac, MapIndex.SeaShrineB3, Tileset.SeaShrine, 21, 31, Teleporter.SeaShrine4, Teleporter.SeaShrine2); // Entrance Forked Floor
			var SeaShrineB4A = Floor.Create(MapLocation.Onrac, MapIndex.SeaShrineB4, Tileset.SeaShrine, 61, 49, Teleporter.SeaShrine5);
			var SeaShrineB3B = Floor.Create(MapLocation.Onrac, MapIndex.SeaShrineB3, Tileset.SeaShrine, 47, 39, Teleporter.SeaShrine6);
			var SeaShrineB2B = Floor.Create(MapLocation.Onrac, MapIndex.SeaShrineB2, Tileset.SeaShrine, 54, 41, Teleporter.SeaShrine7);
			var SeaShrineB3C = Floor.Create(MapLocation.Onrac, MapIndex.SeaShrineB3, Tileset.SeaShrine, 48, 10, Teleporter.SeaShrine8);
			var SeaShrineB4B = Floor.Create(MapLocation.Onrac, MapIndex.SeaShrineB4, Tileset.SeaShrine, 45, 20, Teleporter.SeaShrine9);
			var SeaShrineB5 = Floor.Create(MapLocation.Onrac, MapIndex.SeaShrineB5, Tileset.SeaShrine, 50, 48, OverworldExit.ExitSeaShrine);

			// Sky Palace
			var SkyPalace2F = Floor.Create(MapLocation.MirageTower, MapIndex.SkyPalace2F, Tileset.SkyPalace, 19, 4, Teleporter.SkyPalace3);
			var SkyPalace3F = Floor.Create(MapLocation.MirageTower, MapIndex.SkyPalace3F, Tileset.SkyPalace, 24, 23, Teleporter.SkyPalace4);
			var SkyPalace4F = Floor.Create(MapLocation.MirageTower, MapIndex.SkyPalace4F, Tileset.SkyPalace, 3, 3, Teleporter.SkyPalace5);
			var SkyPalace5F = Floor.Create(MapLocation.MirageTower, MapIndex.SkyPalace5F, Tileset.SkyPalace, 7, 54, OverworldExit.ExitSkyPalace);

			var SeaShrine = new List<Floor> { SeaShrineB2A, SeaShrineB2B, SeaShrineB3B, SeaShrineB3C, SeaShrineB4A, SeaShrineB4B };
			SeaShrine.Shuffle(rng);
			SeaShrine.Insert(rng.Between(0, SeaShrine.Count - 1), SeaShrineB1);
			SeaShrine.Insert(0, SeaShrineB3A);
			SeaShrine.Add(SeaShrineB5);

			Floor.PrintList(SeaShrine);
			Floor.WriteListToRom(this, SeaShrine);

			var Volcano = new List<Floor> { 	GurguVolcanoB2, GurguVolcanoB3A, GurguVolcanoB3B, GurguVolcanoB4A, GurguVolcanoB4B };
			Volcano.Shuffle(rng);
			Volcano.Insert(0, GurguVolcanoB1);
			Volcano.Add(GurguVolcanoB5);

			Floor.PrintList(Volcano);
			Floor.WriteListToRom(this, Volcano);

			/*
			 * Across Dungeons
			 *
			var FiendMiddleFloors = new List<Floor>
			{
				EarthCaveB2, EarthCaveB3, EarthCaveB4,
				GurguVolcanoB2, GurguVolcanoB3A, GurguVolcanoB3B, GurguVolcanoB4A, GurguVolcanoB4B,
				SeaShrineB2A, SeaShrineB2B, SeaShrineB3B, SeaShrineB3C, SeaShrineB4A, SeaShrineB4B,
				MirageTower2F, MirageTower3F, SkyPalace2F, SkyPalace3F, SkyPalace4F,
			};

			var FiendFinalFloors = new List<Floor>
			{
				EarthCaveB5, GurguVolcanoB5, SeaShrineB5, SkyPalace5F,
			};

			var fiendDungeons = new List<List<Floor>> {
				new List<Floor> { EarthCaveB1 },
				new List<Floor> { GurguVolcanoB1 },
				new List<Floor> { SeaShrineB3A },
				new List<Floor> { MirageTower1F },
			};

			FiendMiddleFloors.ForEach(floor => fiendDungeons.PickRandom(rng).Add(floor));
			fiendDungeons[2].Insert(rng.Between(1, fiendDungeons[2].Count - 1), SeaShrineB1);

			for (int i = 0; i < FiendFinalFloors.Count; ++i)
			{
				fiendDungeons[i].Add(FiendFinalFloors[i]);
			}

			fiendDungeons.ForEach(dungeon =>
			{
				Floor.PrintList(dungeon);
				Floor.WriteListToRom(this, dungeon);
			});
			*/
		}

	}
}
