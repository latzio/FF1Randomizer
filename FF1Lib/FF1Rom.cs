﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RomUtilities;
using System.Collections;
using System.IO;

namespace FF1Lib
{
	// ReSharper disable once InconsistentNaming
	public partial class FF1Rom : NesRom
	{
		public const string Version = "2.0.0";

		public const int CopyrightOffset1 = 0x384A8;
		public const int CopyrightOffset2 = 0x384BA;

		public const int RngOffset = 0x7F100;
		public const int RngSize = 256;

		public const int LevelRequirementsOffset = 0x2D000;
		public const int LevelRequirementsSize = 3;
		public const int LevelRequirementsCount = 49;

		public const int StartingGoldOffset = 0x0301C;

		public const int GoldItemOffset = 108; // 108 items before gold chests
		public const int GoldItemCount = 68;
		public static readonly List<int> UnusedGoldItems = new List<int> { 110, 111, 112, 113, 114, 116, 120, 121, 122, 124, 125, 127, 132, 158, 165, 166, 167, 168, 170, 171, 172 };

		public void PutInBank(int bank, int address, Blob data)
		{
			if (bank == 0x1F)
			{
				if ((address - 0xC000) + data.Length >= 0x4000)
				{
					throw new Exception("Data is too large to fit within its bank.");
				}
				int offset = (bank * 0x4000) + (address - 0xC000);
				this.Put(offset, data);
			}
			else
			{
				if ((address - 0x8000) + data.Length >= 0x4000)
				{
					throw new Exception("Data is too large to fit within its bank.");
				}
				int offset = (bank * 0x4000) + (address - 0x8000);
				this.Put(offset, data);
			}

		}
		private Blob CreateLongJumpTableEntry(byte bank, ushort addr)
		{
			List<byte> tmp = new List<byte> { 0x20, 0xC8, 0xD7 }; // JSR $D7C8, beginning of each table entry

			var addrBytes = BitConverter.GetBytes(addr); // next add the address to jump to
			tmp.Add(addrBytes[0]);
			tmp.Add(addrBytes[1]);
			tmp.Add(bank); //finally, add the bank that the routine is located in

			return tmp.ToArray();
		}

		public FF1Rom(string filename) : base(filename)
		{ }

		public FF1Rom(Stream readStream) : base(readStream)
		{ }

		private FF1Rom()
		{ }

		public static async Task<FF1Rom> CreateAsync(Stream readStream)
		{
			var rom = new FF1Rom();
			await rom.LoadAsync(readStream);

			return rom;
		}

		public void Randomize(Blob seed, Flags flags)
		{
			var rng = new MT19337(BitConverter.ToUInt32(seed, 0));

			UpgradeToMMC3();
			EasterEggs();
			DynamicWindowColor();
			PermanentCaravan();
			var map = new OverworldMap(this, flags);
			var shopItemLocation = ItemLocations.CaravanItemShop1;
			
			if (flags.ModernBattlefield)
			{
				SetBattleUI(true);
			}

			if (flags.TitansTrove)
			{
				EnableTitansTrove();
			}

			// This has to be done before we shuffle spell levels.
			if (flags.SpellBugs)
			{
				FixSpellBugs();
			}

			if (flags.Shops)
			{
				shopItemLocation = ShuffleShops(rng, flags.EnemyStatusAttacks);
			}

			if (flags.Treasures || flags.NPCItems || flags.NPCFetchItems)
			{
				var incentivesData = new IncentiveData(rng, flags, map.MapLocationRequirements);
				ShuffleTreasures(rng, flags, incentivesData, shopItemLocation, map.MapLocationRequirements);
			}

			if (flags.MagicShops)
			{
				ShuffleMagicShops(rng);
			}

			if (flags.MagicLevels)
			{
				ShuffleMagicLevels(rng, flags.MagicPermissions);
			}

			if (flags.Rng)
			{
				ShuffleRng(rng);
			}

			if (flags.EnemyScripts)
			{
				ShuffleEnemyScripts(rng);
			}

			if (flags.EnemySkillsSpells)
			{
				ShuffleEnemySkillsSpells(rng);
			}

			if (flags.EnemyStatusAttacks)
			{
				ShuffleEnemyStatusAttacks(rng);
			}

			if (flags.EnemyFormationsUnrunnable)
			{
				ShuffleUnrunnable(rng);
			}

			if (flags.EnemyFormationsSurprise)
			{
				ShuffleSurpriseBonus(rng);
			}

			if (flags.EnemyFormationsFrequency)
			{
				ShuffleEnemyFormations(rng);
			}

			if (flags.OrdealsPillars)
			{
				ShuffleOrdeals(rng);
			}

			if (flags.CrownlessOrdeals)
			{
				EnableEarlyOrdeals();
			}

			if (flags.KeylessToFR)
			{
				EnableKeylessToFR();
			}

			if (flags.EarlySarda && !flags.NPCItems)
			{
				EnableEarlySarda();
			}

			if (flags.EarlySage && !flags.NPCItems)
			{
				EnableEarlySage();
			}
			
			if (flags.FreeBridge)
			{
				EnableFreeBridge();
			}

			if (flags.FreeAirship)
			{
				EnableFreeAirship();
			}

			if (flags.FreeOrbs)
			{
				EnableFreeOrbs();
			}
			
			if (flags.NoPartyShuffle)
			{
				DisablePartyShuffle();
			}

			if (flags.SpeedHacks)
			{
				EnableSpeedHacks();
			}

			if (flags.IdentifyTreasures)
			{
				EnableIdentifyTreasures();
			}

			if (flags.Dash)
			{
				EnableDash();
			}

			if (flags.BuyTen)
			{
				EnableBuyTen();
			}

			if (flags.EnemyFormationsUnrunnable || flags.WaitWhenUnrunnable)
			{
				ChangeUnrunnableRunToWait();
			}

			if (flags.EasyMode)
			{
				EnableEasyMode();
			}

			if (flags.HouseMPRestoration)
			{
				FixHouse();
			}

			if (flags.WeaponStats)
			{
				FixWeaponStats();
			}

			if (flags.ChanceToRun)
			{
				FixChanceToRun();
			}

			if (flags.EnemyStatusAttackBug)
			{
				FixEnemyStatusAttackBug();
			}

			if (flags.BlackBeltAbsorb)
			{
				FixBBAbsorbBug();
			}

			if (flags.EnemyElementalResistancesBug)
			{
				FixEnemyElementalResistances();
			}

			if (flags.FunEnemyNames)
			{
				FunEnemyNames(flags.TeamSteak);
			}

			var itemText = ReadText(ItemTextPointerOffset, ItemTextPointerBase, ItemTextPointerCount);
			itemText[99] = FF1Text.TextToBytes("Ribbon ", useDTE: false);

			ExpGoldBoost(flags.ExpBonus, flags.ExpMultiplier);
			ScalePrices(flags.PriceScaleFactor, flags.ExpMultiplier, itemText, rng);

			map.ApplyMapEdits();

			WriteText(itemText, ItemTextPointerOffset, ItemTextPointerBase, ItemTextOffset, UnusedGoldItems);

			if (flags.EnemyScaleFactor > 1)
			{
				ScaleEnemyStats(flags.EnemyScaleFactor, rng);
			}

			if (flags.ForcedPartyMembers > 0)
			{
				PartyRandomize(rng, flags.ForcedPartyMembers);
			}

			if (flags.MapCanalBridge)
			{
				EnableCanalBridge();
			}

			// We have to do "fun" stuff last because it alters the RNG state.
			RollCredits(rng);

			if (flags.PaletteSwap)
			{
				PaletteSwap(rng);
			}

			if (flags.TeamSteak)
			{
				TeamSteak();
			}

			if (flags.Music != MusicShuffle.None)
			{
				ShuffleMusic(flags.Music, rng);
			}

			WriteSeedAndFlags(Version, seed.ToHex(), Flags.EncodeFlagsText(flags));
			ExtraTrackingAndInitCode();
		}

		private void ExtraTrackingAndInitCode()
		{
			// Expanded game init code, does several things:
			//	- Encounter table emu/hardware fix
			//	- track hard/soft resets
			//	- initialize tracking variables if no game is saved
			PutInBank(0x0F, 0x8000, Blob.FromHex("A9008D00208D012085FEA90885FF85FDA51BC901D00160A901851BA94DC5F9F008A9FF85F585F685F7182088C8B049A94DC5F918F013ADA36469018DA364ADA46469008DA464189010ADA56469018DA564ADA66469008DA664A9008DFD64A200187D00647D00657D00667D0067E8D0F149FF8DFD64189010A2A0A9009D00609D0064E8D0F7EEFB64ADFB648DFB6060"));
			Put(0x7C012, Blob.FromHex("A90F2003FE200080EAEAEAEAEAEAEAEA"));
			Data[0x30FB] = 0x01;


			// Move controller handling out of bank 1F
			// This bit of code is also altered to allow a hard reset using Up+A on controller 2
			PutInBank(0x0F, 0x8200, Blob.FromHex("20108220008360"));
			PutInBank(0x0F, 0x8210, Blob.FromHex("A9018D1640A9008D1640A208AD16402903C9012620AD17402903C901261ECAD0EBA51EC988F0016020A8FE20A8FE20A8FEA2FF9AA900851E9500CAD0FBA6004C12C0"));
			PutInBank(0x0F, 0x8300, Blob.FromHex("A5202903F002A2038611A520290CF0058A090C8511A52045212511452185214520AA2910F00EA5202910F002E623A521491085218A2920F00EA5202920F002E622A521492085218A2940F00EA5202940F002E625A521494085218A2980F00EA5202980F002E624A5214980852160"));
			PutInBank(0x1F, 0xD7C2, CreateLongJumpTableEntry(0x0F, 0x8200));

			// Battles use 2 separate and independent controller handlers for a total of 3 (because why not), so we patch these to respond to Up+A also
			PutInBank(0x0F, 0x8580, Blob.FromHex("A0018C1640888C1640A008AD16404AB0014A6EB368AD17402903C901261E88D0EAA51EC988F004ADB3686020A8FE20A8FE20A8FEA2FF9AA900851E9500CAD0FBA6004C12C0"));
			PutInBank(0x1F, 0xD828, CreateLongJumpTableEntry(0x0F, 0x8580));
			PutInBank(0x0B, 0x9A06, Blob.FromHex("4C28D8"));
			PutInBank(0x0C, 0x97C7, Blob.FromHex("2027F22028D82029ABADB36860"));


			// Put LongJump routine 6 bytes after UpdateJoy used to be
			PutInBank(0x1F, 0xD7C8, Blob.FromHex("85E99885EA6885EB6885ECA001B1EB85EDC8B1EB85EEC8ADFC6085E8B1EB2003FEA9D748A9F548A5E9A4EA6CED0085E9A5E82003FEA5E960"));
			// LongJump entries can start at 0xD800 and must stop before 0xD850 (at which point additional space will need to be freed to make room)

			/* Locations of tracked stats:
			 *	Steps:          $60A0 (24-bit)
			 *	Hard Resets:    $64A3 (16-bit)
			 *	Soft Resets:    $64A5 (16-bit)
			 *	Battles:        $60A7 (16-bit)
			 *	Ambushes:       $60A9 (16-bit)
			 *	Strike Firsts:  $60AB (16-bit)
			 *	Close Calls...: $60AD (16-bit)
			 *	Damage Dealt:   $60AF (24-bit)
			 *	Damage Taken:   $60B2 (24-bit)
			 *	Perished:		$64B5 (8-bit)
			 *	"Nothing Here":	$60B6 (8-bit)
			*/

			// Patches for various tracking variables follow:
			// Pedometer
			PutInBank(0x0F, 0x8100, Blob.FromHex("18A532D027A52D2901F006A550D01DF00398D018ADA06069018DA060ADA16069008DA160ADA26069008DA260A52F8530A9FF851860"));
			Put(0x7D023, Blob.FromHex("A90F2003FE200081"));
			// Count number of battles
			PutInBank(0x0F, 0x8400, Blob.FromHex("18ADA76069018DA7609003EEA86020A8FE60"));
			PutInBank(0x1F, 0xD800, CreateLongJumpTableEntry(0x0F, 0x8400));
			PutInBank(0x1F, 0xF28D, Blob.FromHex("2000D8"));
			// Ambushes / Strike First
			PutInBank(0x0F, 0x8420, Blob.FromHex("AD5668C90B9015C95A901F18ADAB6069018DAB609014EEAC6018900E18ADA96069018DA9609003EEAA60AC5668AE576860"));
			PutInBank(0x1F, 0xD806, CreateLongJumpTableEntry(0x0F, 0x8420));
			Put(0x313FB, Blob.FromHex("eaeaea2006D8"));
			// Runs
			PutInBank(0x0F, 0x8480, Blob.FromHex("AD5868F00E18ADAD6069018DAD609003EEAE60AD586860"));
			PutInBank(0x1F, 0xD81C, CreateLongJumpTableEntry(0x0F, 0x8480));
			Put(0x32418, Blob.FromHex("201CD8"));
			// Physical Damage
			PutInBank(0x0F, 0x84B0, Blob.FromHex("8E7D68AD8768F01DADB2606D82688DB260ADB3606D83688DB360ADB46069008DB46018901AADAF606D82688DAF60ADB0606D83688DB060ADB16069008DB160AE7D6860"));
			PutInBank(0x1F, 0xD822, CreateLongJumpTableEntry(0x0F, 0x84B0));
			Put(0x32968, Blob.FromHex("2022D8"));
			// Magic Damage
			PutInBank(0x0F, 0x8500, Blob.FromHex("AD8A6C2980F01CADB2606D58688DB260ADB3606D59688DB360ADB46069008DB460901AADAF606D58688DAF60ADB0606D59688DB060ADB16069008DB160A912A212A00160"));
			PutInBank(0x1F, 0xD83A, CreateLongJumpTableEntry(0x0F, 0x8500));
			PutInBank(0x0C, 0xB8ED, Blob.FromHex("203AD8eaeaea"));
			// Party Wipes
			PutInBank(0x0F, 0x85D0, Blob.FromHex("EEB564A9008DFD64A200187D00647D00657D00667D0067E8D0F149FF8DFD64A952854B60"));
			PutInBank(0x1F, 0xD82E, CreateLongJumpTableEntry(0x0F, 0x85D0));
			PutInBank(0x0B, 0x9AF5, Blob.FromHex("202ED8EAEA"));
			// "Nothing Here"s
			PutInBank(0x0F, 0x8600, Blob.FromHex("A54429C2D005A545F00360A900EEB66060"));
			PutInBank(0x1F, 0xD834, CreateLongJumpTableEntry(0x0F, 0x8600));
			PutInBank(0x1F, 0xCBF3, Blob.FromHex("4C34D8"));

			// Add select button handler on game start menu to change color
			PutInBank(0x0F, 0x8620, Blob.FromHex("203CC4A662A9488540ADFB60D003EEFB60A522F022EEFB60ADFB60C90D300EF007A9018DFB60D005A90F8DFB60A90085222029EBA90060A90160"));
			PutInBank(0x1F, 0xD840, CreateLongJumpTableEntry(0x0F, 0x8620));
			Put(0x3A1B5, Blob.FromHex("2040D8D0034C56A1EA"));
			// Move Most of LoadBorderPalette_Blue out of the way to do a dynamic version.
			PutInBank(0x0F, 0x8700, Blob.FromHex("988DCE038DEE03A90F8DCC03A9008DCD03A9308DCF0360"));

			// Move DrawCommandMenu out of Bank F so we can add no Escape to it
			PutInBank(0x0F, 0x8740, Blob.FromHex("A000A200B91BFA9D9E6AE8C01BD015AD916D2901F00EA9139D9E6AE8C8A9F79D9E6AE8C8E005D0052090F6A200C8C01ED0D260"));

			// Create a clone of IsOnBridge that checks the canal too.
			PutInBank(0x0F, 0x8780, Blob.FromHex("AD0860F014A512CD0960D00DA513CD0A60D006A90085451860A512CD0D60D00DA513CD0E60D006A900854518603860"));

			// BB Aborb fix.
			PutInBank(0x0F, 0x8800, Blob.FromHex("A000B186C902F005C908F00160A018B186301BC8B1863016C8B1863011C8B186300CA026B1861869010AA0209186A01CB186301AC8B1863015C8B1863010C8B186300BA026B186186901A022918660"));

			// Copyright overhaul, see 0F_8960_DrawSeedAndFlags.asm
			PutInBank(0x0F, 0x8960, Blob.FromHex("A9238D0620A9208D0620A200BD00898D0720E8E060D0F560"));
		}

		public override bool Validate()
		{
			return Get(0, 16) == Blob.FromHex("06400e890e890e401e400e400e400b42");
		}

		public void UpgradeToMMC3()
		{
			Header[4] = 32; // 32 pages of 16 kB
			Header[6] = 0x43; // original is 0x13 where 1 = MMC1 and 4 = MMC3

			// Expand ROM size, moving bank 0F to the end.
			Blob newData = new byte[0x80000];
			Array.Copy(Data, newData, 0x3C000);
			Array.Copy(Data, 0x3C000, newData, 0x7C000, 0x4000);
			Data = newData;

			// Change bank swap code.
			// We put this code at SwapPRG_L, so we don't have to move any of the "long" calls to it.
			// We completely overwrite SetMMC1SwapMode, since we don't need it anymore, and partially overwrite the original SwapPRG.
			Put(0x7FE03, Blob.FromHex("8dfc6048a9068d0080680a8d018048a9078d00806869018d0180a90060"));

			// Initialize MMC3
			Put(0x7FE48, Blob.FromHex("8d00e0a9808d01a0a0008c00a08c00808c0180c88c0080c88c01808c0080c8c88c0180a9038d0080c88c0180a9048d00804ccdffa900"));
			Put(0x7FFCD, Blob.FromHex("c88c0180a9058d0080c88c01804c7cfeea"));

			// Rewrite the lone place where SwapPRG was called directly and not through SwapPRG_L.
			Data[0x7FE97] = 0x03;
		}

		public void WriteSeedAndFlags(string version, string seed, string flags)
		{
			// Replace most of the old copyright string printing with a JSR to a LongJump
			Put(0x38486, Blob.FromHex("20FCFE60"));

			// DrawSeedAndFlags LongJump
			PutInBank(0x1F, 0xFEFC, CreateLongJumpTableEntry(0x0F, 0x8960));

			// Put the new string data in a known location.
			PutInBank(0x0F, 0x8900, Blob.Concat(new Blob[]
			{
				FF1Text.TextToCopyrightLine("Final Fantasy Randomizer " + version),
				FF1Text.TextToCopyrightLine("Seed  " + seed),
				FF1Text.TextToCopyrightLine(flags),
			}));
		}

		public void ShuffleRng(MT19337 rng)
		{
			var rngTable = Get(RngOffset, RngSize).Chunk(1).ToList();
			rngTable.Shuffle(rng);

			Put(RngOffset, rngTable.SelectMany(blob => blob.ToBytes()).ToArray());
		}

		public void ExpGoldBoost(double bonus, double multiplier)
		{
			var enemyBlob = Get(EnemyOffset, EnemySize * EnemyCount);
			var enemies = enemyBlob.Chunk(EnemySize);

			foreach (var enemy in enemies)
			{
				var exp = BitConverter.ToUInt16(enemy, 0);
				var gold = BitConverter.ToUInt16(enemy, 2);

				exp += (ushort)(bonus / multiplier);
				gold += (ushort)(bonus / multiplier);

				var expBytes = BitConverter.GetBytes(exp);
				var goldBytes = BitConverter.GetBytes(gold);
				Array.Copy(expBytes, 0, enemy, 0, 2);
				Array.Copy(goldBytes, 0, enemy, 2, 2);
			}

			enemyBlob = Blob.Concat(enemies);

			Put(EnemyOffset, enemyBlob);

			var levelRequirementsBlob = Get(LevelRequirementsOffset, LevelRequirementsSize * LevelRequirementsCount);
			var levelRequirementsBytes = levelRequirementsBlob.Chunk(3).Select(threeBytes => new byte[] { threeBytes[0], threeBytes[1], threeBytes[2], 0 }).ToList();
			for (int i = 0; i < LevelRequirementsCount; i++)
			{
				uint levelRequirement = (uint)(BitConverter.ToUInt32(levelRequirementsBytes[i], 0) / multiplier);
				levelRequirementsBytes[i] = BitConverter.GetBytes(levelRequirement);
			}

			Put(LevelRequirementsOffset, Blob.Concat(levelRequirementsBytes.Select(bytes => (Blob)new byte[] { bytes[0], bytes[1], bytes[2] })));

			// A dirty, ugly, evil piece of code that sets the level requirement for level 2, even though that's already defined in the above table.
			byte firstLevelRequirement = Data[0x7C04B];
			firstLevelRequirement = (byte)(firstLevelRequirement / multiplier);
			Data[0x7C04B] = firstLevelRequirement;
		}
	}
}
