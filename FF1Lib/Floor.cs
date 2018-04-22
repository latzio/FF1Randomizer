using RomUtilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FF1Lib
{
	public enum MapIndex : byte
	{
		ConeriaTown = 0,
		Pravoka = 1,
		Elfland = 2,
		Melmond = 3,
		CrescentLake = 4,
		Gaia = 5,
		Onrac = 6,
		Lefein = 7,
		ConeriaCastle1F = 8,
		ElflandCastle = 9,
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
		BahamutCaveB2 = 39,
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
		EarthFireTitans = 2,
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
		ExitCastleOrdeals = 3,
		ExitCastleConeria = 4,
		ExitEarthCave = 5,
		ExitGurguVolcano = 6,
		ExitSeaShrine = 7,
		ExitSkyPalace = 8,
		ExitUnused1 = 9,
		ExitUnused2 = 10,
		ExitUnused3 = 11,
		ExitUnused4 = 12,
		ExitUnused5 = 13,
		ExitUnused6 = 14,
		ExitUnused7 = 15,
	}

	// Dead end with no point of egress beyond a possible WARP back to where you entered.
	public class Floor
	{
		private static int MapPaletteOffset = 0x2000;
		private static int MapPaletteSize = 48;
		private static int MapCount = 64;

		private static List<Blob> FloorPalettes;
		private static Object FloorPalettesLock = new Object();


		public MapLocation Location { get; set; }
		public MapIndex Index { get; set; }
		public Tileset Tileset { get; set; }

		public byte CoordinateX { get; set; }
		public byte CoordinateY { get; set; }

		public List<IRewardSource> Rewards;

		public static Floor Create(MapLocation location, MapIndex index, Tileset tileset, byte x, byte y)
		{
			return new Floor(location, index, tileset, x, y);
		}

		public static Floor Create(MapLocation location, MapIndex index, Tileset tileset, byte x, byte y, OverworldExit exit)
		{
			return new ExitFloor(location, index, tileset, x, y, exit);
		}

		public static Floor Create(MapLocation location, MapIndex index, Tileset tileset, byte x, byte y, Teleporter teleporter, AccessRequirement requirement = AccessRequirement.None)
		{
			return new CommonFloor(location, index, tileset, x, y, teleporter, requirement);
		}

		public static Floor Create(MapLocation location, MapIndex index, Tileset tileset, byte x, byte y, Teleporter teleporter, Teleporter teleporter2)
		{
			return new ForkedFloor(location, index, tileset, x, y, teleporter, teleporter2);
		}

		public Floor(MapLocation location, MapIndex index, Tileset tileset, byte x, byte y)
		{
			Location = location;
			Index = index;
			Tileset = tileset;
			CoordinateX = x;
			CoordinateY = y;
		}

		// Since walking the floors recusively destroys the list we copy it here.
		public static void WriteListToRom(NesRom rom, List<Floor> floors)
		{
			// Just need this lock for the single write to this long lived lookup.
			lock (FloorPalettesLock)
			{
				if (FloorPalettes == null)
				{
					FloorPalettes = rom.Get(0x2000, MapCount * MapPaletteSize).Chunk(MapPaletteSize);
				}
			}

			List<Floor> copy = new List<Floor>(floors);
			Floor first = copy[0];
			copy.RemoveAt(0);
			first.WriteToRom(rom, copy);
		}

		public virtual void WriteToRom(NesRom rom, List<Floor> next)
		{
			if (Index >= MapIndex.EarthCaveB1)
			{
				//rom.Put(MapPaletteOffset + (int)Index * MapPaletteSize, FloorPalettes[(int)MapIndex.MarshCaveB3]);
			}
		}

		public static void PrintList(List<Floor> floors)
		{
			System.Diagnostics.Debug.Write("FLOOR LIST BEGIN: { ");
			floors.ForEach(floor => floor.Print());
			System.Diagnostics.Debug.WriteLine("");
		}

		public virtual void Print()
		{
			System.Diagnostics.Debug.Write($"{Enum.GetName(typeof(MapIndex), Index)} [{CoordinateX}, {CoordinateY}] {'}'} ");
		}
	}

	// A final floor with one point of egress to the overworld
	public class ExitFloor : Floor
	{
		public OverworldExit Exit { get; }

		public ExitFloor(MapLocation location, MapIndex index, Tileset tileset, byte x, byte y, OverworldExit exit)
			: base(location, index, tileset, x, y)
		{
			Exit = exit;
		}

		public override void WriteToRom(NesRom rom, List<Floor> floors)
		{
			base.WriteToRom(rom, floors);
		}

		public override void Print()
		{
			System.Diagnostics.Debug.Write($"{Enum.GetName(typeof(MapIndex), Index)} [{CoordinateX}, {CoordinateY}] -> EXIT {'}'}");
		}
	}

	// A common floor with one point of egress to another floor.
	public class CommonFloor : Floor
	{
		private const int TeleporterMapIndexOffset = 0x2D80;
		private const int TeleporterXCoordOffset = 0x2D00;
		private const int TeleporterYCoordOffset = 0x2D40;

		public Teleporter Teleporter { get; protected set; }
		public AccessRequirement AccessRequirement { get; }

		public CommonFloor(MapLocation location, MapIndex index, Tileset tileset, byte x, byte y, Teleporter teleporter, AccessRequirement accessRequirement = AccessRequirement.None)
			: base(location, index, tileset, x, y)
		{
			Teleporter = teleporter;
		}

		public override void WriteToRom(NesRom rom, List<Floor> floors)
		{
			base.WriteToRom(rom, floors);

			Floor next = floors[0];
			floors.RemoveAt(0);
			rom.Put(TeleporterMapIndexOffset + (int)Teleporter, new byte[] { (byte)next.Index });
			rom.Put(TeleporterXCoordOffset + (int)Teleporter, new byte[] { next.CoordinateX });
			rom.Put(TeleporterYCoordOffset + (int)Teleporter, new byte[] { next.CoordinateY });

			next.WriteToRom(rom, floors);
		}

		public override void Print()
		{
			System.Diagnostics.Debug.Write($"{Enum.GetName(typeof(MapIndex), Index)} [{CoordinateX}, {CoordinateY}] -> ");
		}
	}

	// A two-of-a-kind floor with two point of egress to other floors.
	public class ForkedFloor : CommonFloor
	{
		public Teleporter Teleporter2 { get; protected set; }

		public ForkedFloor(MapLocation location, MapIndex index, Tileset tileset, byte x, byte y, Teleporter teleporter, Teleporter teleporter2)
			: base(location, index, tileset, x, y, teleporter)
		{
			Teleporter2 = teleporter2;
		}

		public override void WriteToRom(NesRom rom, List<Floor> floors)
		{
			// This will do the first branch using Teleporter, removing all the floors from floors until the first end.
			// Then we repeat the CommonFloor logic with the old Teleporter switcheroo.
			base.WriteToRom(rom, floors);
			(Teleporter, Teleporter2) = (Teleporter2, Teleporter);
			base.WriteToRom(rom, floors);
			(Teleporter, Teleporter2) = (Teleporter2, Teleporter);
		}

		public override void Print()
		{
			System.Diagnostics.Debug.Write($"{Enum.GetName(typeof(MapIndex), Index)} [{CoordinateX}, {CoordinateY}] -> {'{'} Branch: ");
		}
	}

}
