using System;
using System.Linq;

namespace FF1Lib
{
    public struct EntranceTeleport
    {
        public readonly MapLocation TeleportDestination;
        public readonly byte MapIndex;
        public readonly byte EnterCoordinateX;
        public readonly byte EnterCoordinateY;
        public readonly byte Tileset;
        public readonly byte ExitIndex;
		public string SpoilerText =>
		$"{Enum.GetName(typeof(MapLocation), TeleportDestination)}" +
		$"{string.Join("", Enumerable.Repeat(" ", Math.Max(1, 30 - Enum.GetName(typeof(MapLocation), TeleportDestination).Length)).ToList())}";
        public EntranceTeleport(MapLocation mapLocation, byte mapIndex, byte coordinateX, byte coordinateY,
                           byte tileset, byte exitIndex = 0xFF)
        {
            TeleportDestination = mapLocation;
            MapIndex = mapIndex;
            EnterCoordinateX = coordinateX;
            EnterCoordinateY = coordinateY;
            Tileset = tileset;
            ExitIndex = exitIndex;
        }
    }
    public static class EntranceTeleports
    {
        public static EntranceTeleport ConeriaTown = new EntranceTeleport(MapLocation.ConeriaTown, 0, 16, 23, 0);
        public static EntranceTeleport Pravoka = new EntranceTeleport(MapLocation.Pravoka, 1, 19, 32, 0);
        public static EntranceTeleport ElflandTown = new EntranceTeleport(MapLocation.ElflandTown, 2, 41, 22, 0);
        public static EntranceTeleport Melmond = new EntranceTeleport(MapLocation.Melmond, 3, 1, 16, 0);
        public static EntranceTeleport CresentLake = new EntranceTeleport(MapLocation.CresentLake, 4, 11, 23, 0);
        public static EntranceTeleport Gaia = new EntranceTeleport(MapLocation.Gaia, 5, 61, 61, 0);
        public static EntranceTeleport Onrac = new EntranceTeleport(MapLocation.Onrac, 6, 1, 12, 0, 7);
        public static EntranceTeleport Lefein = new EntranceTeleport(MapLocation.Lefein, 7, 19, 23, 0);
        public static EntranceTeleport ConeriaCastle = new EntranceTeleport(MapLocation.ConeriaCastle, 8, 12, 35, 1, 4);
        public static EntranceTeleport ElflandCastle = new EntranceTeleport(MapLocation.ElflandCastle, 9, 16, 31, 1);
        public static EntranceTeleport NorthwestCastle = new EntranceTeleport(MapLocation.NorthwestCastle, 10, 22, 24, 1);
        public static EntranceTeleport CastleOrdeals = new EntranceTeleport(MapLocation.CastleOrdeals, 11, 12, 21, 1, 3);
        public static EntranceTeleport TempleOfFiends = new EntranceTeleport(MapLocation.TempleOfFiends, 12, 20, 30, 5);
        public static EntranceTeleport EarthCave = new EntranceTeleport(MapLocation.EarthCave, 13, 23, 24, 2, 5);
        public static EntranceTeleport GurguVolcano = new EntranceTeleport(MapLocation.GurguVolcano, 14, 27, 15, 2, 6);
        public static EntranceTeleport IceCave = new EntranceTeleport(MapLocation.IceCave, 15, 7, 1, 3, 2);
        public static EntranceTeleport Cardia1 = new EntranceTeleport(MapLocation.Cardia1, 16, 30, 18, 3);
        public static EntranceTeleport Cardia2 = new EntranceTeleport(MapLocation.Cardia2, 16, 12, 15, 3);
        public static EntranceTeleport Cardia3 = new EntranceTeleport(MapLocation.Cardia3, 17, 2, 2, 3);
        public static EntranceTeleport Cardia4 = new EntranceTeleport(MapLocation.Cardia4, 16, 19, 36, 3);
        public static EntranceTeleport Cardia5 = new EntranceTeleport(MapLocation.Cardia5, 16, 43, 29, 3);
        public static EntranceTeleport Cardia6 = new EntranceTeleport(MapLocation.Cardia6, 16, 58, 55, 3);
        public static EntranceTeleport Waterfall = new EntranceTeleport(MapLocation.Waterfall, 18, 57, 56, 3);
        public static EntranceTeleport DwarfCave = new EntranceTeleport(MapLocation.DwarfCave, 19, 22, 11, 3);
        public static EntranceTeleport MatoyasCave = new EntranceTeleport(MapLocation.MatoyasCave, 20, 15, 11, 3);
        public static EntranceTeleport SardasCave = new EntranceTeleport(MapLocation.SardasCave, 21, 18, 13, 3);
        public static EntranceTeleport MarshCave = new EntranceTeleport(MapLocation.MarshCave, 22, 21, 27, 4);
        public static EntranceTeleport MirageTower = new EntranceTeleport(MapLocation.MirageTower, 23, 17, 31, 4, 8);
        public static EntranceTeleport TitansTunnelA = new EntranceTeleport(MapLocation.TitansTunnelEast, 60, 11, 14, 2, 0);
        public static EntranceTeleport TitansTunnelB = new EntranceTeleport(MapLocation.TitansTunnelWest, 60, 5, 3, 2, 1);
        public static EntranceTeleport Empty = new EntranceTeleport(MapLocation.ConeriaTown, 0, 0, 0, 0);
    }
}
