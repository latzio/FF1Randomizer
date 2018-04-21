using System;
using System.Collections.Generic;
using System.Linq;

namespace FF1Lib
{
    public struct OWTeleportLocation
    {
        public readonly OverworldTeleportIndex TeleportIndex;
        public readonly byte CoordinateX;
        public readonly byte CoordinateY;
        public readonly string LocationName;
        public readonly EntranceTeleport PlacedTeleport;
        public string SpoilerText =>
        $"{LocationName}{string.Join("", Enumerable.Repeat(" ", Math.Max(1, 30 - LocationName.Length)).ToList())}" +
        $"\t{PlacedTeleport.SpoilerText}";
        public OWTeleportLocation(OverworldTeleportIndex teleportIndex, byte coordinateX, byte coordinateY,
                                  EntranceTeleport placedLocation)
        {
            TeleportIndex = teleportIndex;
            CoordinateX = coordinateX;
            CoordinateY = coordinateY;
            PlacedTeleport = placedLocation;
			LocationName = Enum.GetName(typeof(OverworldTeleportIndex), TeleportIndex);
        }
        public OWTeleportLocation(OWTeleportLocation copyFromTeleportLocation,
                                  EntranceTeleport newPlacement)
        {
            TeleportIndex = copyFromTeleportLocation.TeleportIndex;
            CoordinateX = copyFromTeleportLocation.CoordinateX;
            CoordinateY = copyFromTeleportLocation.CoordinateY;
            PlacedTeleport = newPlacement;
			LocationName = Enum.GetName(typeof(OverworldTeleportIndex), TeleportIndex);
        }
    }
	public static class TeleportLocations
	{
		public static OWTeleportLocation Cardia1 = new OWTeleportLocation(OverworldTeleportIndex.Cardia1, 92, 48, EntranceTeleports.Cardia1);
		public static OWTeleportLocation ConeriaTown = new OWTeleportLocation(OverworldTeleportIndex.ConeriaTown, 152, 162,  EntranceTeleports.ConeriaTown);
		public static OWTeleportLocation Pravoka = new OWTeleportLocation(OverworldTeleportIndex.Pravoka, 210, 150, EntranceTeleports.Pravoka);
		public static OWTeleportLocation ElflandTown = new OWTeleportLocation(OverworldTeleportIndex.ElflandTown, 136, 222, EntranceTeleports.ElflandTown);
		public static OWTeleportLocation Melmond = new OWTeleportLocation(OverworldTeleportIndex.Melmond, 81, 160, EntranceTeleports.Melmond);
		public static OWTeleportLocation CresentLake = new OWTeleportLocation(OverworldTeleportIndex.CresentLake, 219, 218, EntranceTeleports.CresentLake);
		public static OWTeleportLocation Gaia = new OWTeleportLocation(OverworldTeleportIndex.Gaia, 221, 28, EntranceTeleports.Gaia);
		public static OWTeleportLocation Onrac = new OWTeleportLocation(OverworldTeleportIndex.Onrac, 62, 56, EntranceTeleports.Onrac);
		public static OWTeleportLocation Lefein = new OWTeleportLocation(OverworldTeleportIndex.Lefein, 235, 99, EntranceTeleports.Lefein);
		public static OWTeleportLocation ConeriaCastle = new OWTeleportLocation(OverworldTeleportIndex.ConeriaCastle, 153, 159, EntranceTeleports.ConeriaCastle);
		public static OWTeleportLocation ElflandCastle = new OWTeleportLocation(OverworldTeleportIndex.ElflandCastle, 136, 221, EntranceTeleports.ElflandCastle);
		public static OWTeleportLocation NorthwestCastle = new OWTeleportLocation(OverworldTeleportIndex.NorthwestCastle, 103, 186, EntranceTeleports.NorthwestCastle);
		public static OWTeleportLocation CastleOrdeals = new OWTeleportLocation(OverworldTeleportIndex.CastleOrdeals, 130, 45, EntranceTeleports.CastleOrdeals);
		public static OWTeleportLocation TempleOfFiends = new OWTeleportLocation(OverworldTeleportIndex.TempleOfFiends, 130, 123, EntranceTeleports.TempleOfFiends);
		public static OWTeleportLocation EarthCave = new OWTeleportLocation(OverworldTeleportIndex.EarthCave, 65, 187, EntranceTeleports.EarthCave);
		public static OWTeleportLocation GurguVolcano = new OWTeleportLocation(OverworldTeleportIndex.GurguVolcano, 188, 205, EntranceTeleports.GurguVolcano);
		public static OWTeleportLocation IceCave = new OWTeleportLocation(OverworldTeleportIndex.IceCave, 197, 183, EntranceTeleports.IceCave);
		public static OWTeleportLocation Cardia2 = new OWTeleportLocation(OverworldTeleportIndex.Cardia2, 79, 49, EntranceTeleports.Cardia2);//(chests 9, 10, and 11)
		public static OWTeleportLocation Cardia3 = new OWTeleportLocation(OverworldTeleportIndex.Cardia3, 96, 51, EntranceTeleports.Cardia3);
		public static OWTeleportLocation Waterfall = new OWTeleportLocation(OverworldTeleportIndex.Waterfall, 54, 29, EntranceTeleports.Waterfall);
		public static OWTeleportLocation DwarfCave = new OWTeleportLocation(OverworldTeleportIndex.DwarfCave, 100, 155, EntranceTeleports.DwarfCave);
		public static OWTeleportLocation MatoyasCave = new OWTeleportLocation(OverworldTeleportIndex.MatoyasCave, 168, 117, EntranceTeleports.MatoyasCave);
		public static OWTeleportLocation SardasCave = new OWTeleportLocation(OverworldTeleportIndex.SardasCave, 30, 190, EntranceTeleports.SardasCave);
		public static OWTeleportLocation MarshCave = new OWTeleportLocation(OverworldTeleportIndex.MarshCave, 102, 236, EntranceTeleports.MarshCave);
		public static OWTeleportLocation MirageTower = new OWTeleportLocation(OverworldTeleportIndex.MirageTower, 194, 59, EntranceTeleports.MirageTower);
		public static OWTeleportLocation TitansTunnelEast = new OWTeleportLocation(OverworldTeleportIndex.TitansTunnelEast, 42, 174, EntranceTeleports.TitansTunnelA);
		public static OWTeleportLocation TitansTunnelWest = new OWTeleportLocation(OverworldTeleportIndex.TitansTunnelWest, 30, 175, EntranceTeleports.TitansTunnelB);
		public static OWTeleportLocation Cardia4 = new OWTeleportLocation(OverworldTeleportIndex.Cardia4, 93, 58, EntranceTeleports.Cardia4); // (chests 6, 7, and 8)
		public static OWTeleportLocation Cardia5 = new OWTeleportLocation(OverworldTeleportIndex.Cardia5, 105, 59, EntranceTeleports.Cardia5);
		public static OWTeleportLocation Cardia6 = new OWTeleportLocation(OverworldTeleportIndex.Cardia6, 116, 66, EntranceTeleports.Cardia6); // (chests 1, 2, 3, 4, 5, 12, and 13)
		public static OWTeleportLocation Unused1 = new OWTeleportLocation(OverworldTeleportIndex.Unused1, 0, 0, EntranceTeleports.Empty);
		public static OWTeleportLocation Unused2 = new OWTeleportLocation(OverworldTeleportIndex.Unused2, 0, 0, EntranceTeleports.Empty);
		public static IReadOnlyCollection<OWTeleportLocation> AllTownLocations =
			new List<OWTeleportLocation>
			{
			ConeriaTown,Pravoka,ElflandTown,Melmond,CresentLake,Gaia,Onrac,Lefein
		};
		public static IReadOnlyCollection<OWTeleportLocation> AllNonTownLocations =
			new List<OWTeleportLocation>
			{
			Cardia1,ConeriaCastle,ElflandCastle,NorthwestCastle,CastleOrdeals,
			TempleOfFiends,EarthCave,GurguVolcano,IceCave,Cardia2,Cardia3,
			Waterfall,DwarfCave,MatoyasCave,SardasCave,MarshCave,MirageTower,
			TitansTunnelEast,TitansTunnelWest,Cardia4,Cardia5,Cardia6,Unused1,Unused2
		};
		public static IReadOnlyCollection<OWTeleportLocation> AllLocations =
			new List<OWTeleportLocation>
			{
			Cardia1,ConeriaTown,Pravoka,ElflandTown,Melmond,CresentLake,Gaia,
			Onrac,Lefein,ConeriaCastle,ElflandCastle,NorthwestCastle,CastleOrdeals,
			TempleOfFiends,EarthCave,GurguVolcano,IceCave,Cardia2,Cardia3,
			Waterfall,DwarfCave,MatoyasCave,SardasCave,MarshCave,MirageTower,
			TitansTunnelEast,TitansTunnelWest,Cardia4,Cardia5,Cardia6,Unused1,Unused2
		};
		public static IReadOnlyCollection<OWTeleportLocation> UnusedLocations =
			 new List<OWTeleportLocation>
			 {
			Unused1,Unused2
		};
	}
	public enum OverworldTeleportIndex : byte
	{
		Cardia1 = 0,
		ConeriaTown = 1,
		Pravoka = 2,
		ElflandTown = 3,
		Melmond = 4,
		CresentLake = 5,
		Gaia = 6,
		Onrac = 7,
		Lefein = 8,
		ConeriaCastle = 9,
		ElflandCastle = 10,
		NorthwestCastle = 11,
		CastleOrdeals = 12,
		TempleOfFiends = 13,
		EarthCave = 14,
		GurguVolcano = 15,
		IceCave = 16,
		Cardia2 = 17,
		Cardia3 = 18,
		Waterfall = 19,
		DwarfCave = 20,
		MatoyasCave = 21,
		SardasCave = 22,
		MarshCave = 23,
		MirageTower = 24,
		TitansTunnelEast = 25,
		TitansTunnelWest = 26,
		Cardia4 = 27,
		Cardia5 = 28,
		Cardia6 = 29,
		Unused1 = 30,
		Unused2 = 31
	}
}
