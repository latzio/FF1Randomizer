using RomUtilities;

using System.Collections.Generic;


namespace FF1Lib
{
	public partial class FF1Rom : NesRom
	{

		public void ShuffleFloors(MT19337 rng)
		{
			Floor MarshCaveB2B = new Floor(new FloorDestination(MapLocation.MarshCave, MapIndex.MarshCaveB2, Tileset.MirageMarsh, 0x22, 0x25),
				null, new FloorTeleporter(Teleporter.MarshCave3));

			Floor GurguVolcano1F = new Floor(new FloorDestination(MapLocation.GurguVolcano, MapIndex.GurguVolcanoB1, Tileset.EarthFire, 0x1B, 0x0F),
				null, new FloorTeleporter(Teleporter.Gurgu1));
			Floor GurguVolcano2F = new Floor(new FloorDestination(MapLocation.GurguVolcano, MapIndex.GurguVolcanoB2, Tileset.EarthFire, 0x1E, 0x20),
				GurguVolcano1F, new FloorTeleporter(Teleporter.Gurgu2));
			Floor GurguVolcano3FA = new Floor(new FloorDestination(MapLocation.GurguVolcano, MapIndex.GurguVolcanoB3, Tileset.EarthFire, 0x12, 0x02),
				GurguVolcano2F, new FloorTeleporter(Teleporter.Gurgu3));
			Floor GurguVolcano4FA = new Floor(new FloorDestination(MapLocation.GurguVolcano, MapIndex.GurguVolcanoB4, Tileset.EarthFire, 0x03, 0x17),
				GurguVolcano3FA, new FloorTeleporter(Teleporter.Gurgu5));
			Floor GurguVolcano3FB = new Floor(new FloorDestination(MapLocation.GurguVolcano, MapIndex.GurguVolcanoB3, Tileset.EarthFire, 0x2E, 0x17),
				GurguVolcano4FA, new FloorTeleporter(Teleporter.Gurgu4));
			Floor GurguVolcano4FB = new Floor(new FloorDestination(MapLocation.GurguVolcano, MapIndex.GurguVolcanoB4, Tileset.EarthFire, 0x23, 0x06),
				GurguVolcano3FB, new FloorTeleporter(Teleporter.Gurgu6));
			Floor GurguVolcano5F = new Floor(new FloorDestination(MapLocation.GurguVolcano, MapIndex.GurguVolcanoB5, Tileset.EarthFire, 0x20, 0x1F),
				GurguVolcano4FB, new DungeonExit(OverworldExit.ExitGurguVolcano));

			Floor IceCaveB1 = new Floor(new FloorDestination(MapLocation.IceCave, MapIndex.IceCaveB1, Tileset.IceCardiaWaterfall, 0x07, 0x01),
				null, new FloorTeleporter(Teleporter.IceCave1));

			List<Floor> GurguVolcano = new List<Floor>{ GurguVolcano2F, GurguVolcano3FA,
			GurguVolcano4FA, GurguVolcano3FB, GurguVolcano4FB };

			while (GurguVolcano.Count > 1)
			{
				var floor = GurguVolcano.SpliceRandom(rng);
				floor.SwapWith(GurguVolcano.PickRandom(rng));
			}

			GurguVolcano1F.print();
			GurguVolcano1F.write(this);
		}

	}
}
