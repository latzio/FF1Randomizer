﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace FF1Lib
{
	public class Flags : IIncentiveFlags, IMapEditFlags
	{
		// Character Groupings
		private const int ITEMS = 0;
		private const int ALT_GAME_MODE = 1;
		private const int MAGIC = 2;
		private const int ENCOUNTERS = 3;
		private const int BATTLES = 4;
		private const int STANDARD_MAPS = 5;
		private const int OVERWORLD_MAP = 6;
		private const int INCENTIVES_MAIN = 7;
		private const int INCENTIVES_CHESTS1 = 8;
		private const int INCENTIVES_CHESTS2 = 9;
		private const int INCENTIVES_ITEMS1 = 10;
		private const int INCENTIVES_ITEMS2 = 11;
		private const int ITEM_REQUIREMENTS = 12;
		private const int FILTHY_CASUALS = 13;
		private const int CONVENIENCES = 14;
		private const int BUG_FIXES = 15;
		private const int ENEMY_BUG_FIXES = 16;
		
		[FlagString(Character = ITEMS, FlagBit = 1)]
		public bool Shops { get; set; }
		[FlagString(Character = ITEMS, FlagBit = 2)]
		public bool Treasures { get; set; }
		[FlagString(Character = ITEMS, FlagBit = 4)]
		public bool NPCItems { get; set; }
		[FlagString(Character = ITEMS, FlagBit = 8)]
		public bool NPCFetchItems { get; set; }
		[FlagString(Character = ITEMS, FlagBit = 16)]
		public bool RandomWares { get; set; } // Planned 2.x feature - random weapons and armor in shops
		[FlagString(Character = ITEMS, FlagBit = 32)]
		public bool RandomLoot { get; set; } // Planned 2.x feature - random non-quest-item treasures
		
		[FlagString(Character = ALT_GAME_MODE, FlagBit = 1)]
		public bool OrbHunt { get; set; } // Planned 2.1 or 2.2 features - shard hunt

		[FlagString(Character = MAGIC, FlagBit = 1)]
		public bool MagicShops { get; set; }
		[FlagString(Character = MAGIC, FlagBit = 2)]
		public bool MagicLevels { get; set; }
		[FlagString(Character = MAGIC, FlagBit = 4)]
		public bool MagicPermissions { get; set; }

		[FlagString(Character = ENCOUNTERS, FlagBit = 1)]
		public bool Rng { get; set; }
		[FlagString(Character = ENCOUNTERS, FlagBit = 2)]
		public bool EnemyFormationsFrequency { get; set; }
		[FlagString(Character = ENCOUNTERS, FlagBit = 4)]
		public bool EnemyFormationsUnrunnable { get; set; }
		[FlagString(Character = ENCOUNTERS, FlagBit = 8)]
		public bool EnemyFormationsSurprise { get; set; }
		
		[FlagString(Character = BATTLES, FlagBit = 1)]
		public bool EnemyScripts { get; set; }
		[FlagString(Character = BATTLES, FlagBit = 2)]
		public bool EnemySkillsSpells { get; set; }
		[FlagString(Character = BATTLES, FlagBit = 4)]
		public bool EnemyStatusAttacks { get; set; }

		[FlagString(Character = STANDARD_MAPS, FlagBit = 1)]
		public bool OrdealsPillars { get; set; }
		[FlagString(Character = STANDARD_MAPS, FlagBit = 2)]
		public bool TitansTrove { get; set; }
		[FlagString(Character = STANDARD_MAPS, FlagBit = 4)]
		public bool CrownlessOrdeals { get; set; }
		[FlagString(Character = STANDARD_MAPS, FlagBit = 8)]
		public bool Entrances { get; set; } // Planned x.x feature - non-town entrance shuffle
		[FlagString(Character = STANDARD_MAPS, FlagBit = 16)]
		public bool Towns { get; set; } // Planned x.x feature - town entrance shuffle
		[FlagString(Character = STANDARD_MAPS, FlagBit = 32)]
		public bool Floors { get; set; } // Planned x.x feature - interior floors shuffle

		[FlagString(Character = OVERWORLD_MAP, FlagBit = 1)]
		public bool MapOpenProgression { get; set; }
		
		[FlagString(Character = INCENTIVES_MAIN, FlagBit = 1)]
		public bool IncentivizeFreeNPCs { get; set; }
		[FlagString(Character = INCENTIVES_MAIN, FlagBit = 2)]
		public bool IncentivizeFetchNPCs { get; set; }
		[FlagString(Character = INCENTIVES_MAIN, FlagBit = 4)]
		public bool IncentivizeTail { get; set; }
		[FlagString(Character = INCENTIVES_MAIN, FlagBit = 8)]
		public bool IncentivizeFetchItems { get; set; }
		
		[FlagString(Character = INCENTIVES_CHESTS1, FlagBit = 1)]
		public bool IncentivizeMarsh { get; set; }
		[FlagString(Character = INCENTIVES_CHESTS1, FlagBit = 2)]
		public bool IncentivizeEarth { get; set; }
		[FlagString(Character = INCENTIVES_CHESTS1, FlagBit = 4)]
		public bool IncentivizeVolcano { get; set; }
		[FlagString(Character = INCENTIVES_CHESTS1, FlagBit = 8)]
		public bool IncentivizeIceCave { get; set; }
		[FlagString(Character = INCENTIVES_CHESTS1, FlagBit = 16)]
		public bool IncentivizeOrdeals { get; set; }
		[FlagString(Character = INCENTIVES_CHESTS1, FlagBit = 32)]
		public bool IncentivizeSeaShrine { get; set; }
		
		[FlagString(Character = INCENTIVES_CHESTS2, FlagBit = 1)]
		public bool IncentivizeConeria { get; set; }
		[FlagString(Character = INCENTIVES_CHESTS2, FlagBit = 2)]
		public bool IncentivizeMarshKeyLocked { get; set; }
		[FlagString(Character = INCENTIVES_CHESTS2, FlagBit = 4)]
		public bool IncentivizeSkyPalace { get; set; }
		
		[FlagString(Character = INCENTIVES_ITEMS1, FlagBit = 1)]
		public bool IncentivizeMasamune { get; set; }
		[FlagString(Character = INCENTIVES_ITEMS1, FlagBit = 2)]
		public bool IncentivizeOpal { get; set; }
		[FlagString(Character = INCENTIVES_ITEMS1, FlagBit = 4)]
		public bool IncentivizeRibbon { get; set; }
		[FlagString(Character = INCENTIVES_ITEMS1, FlagBit = 8)]
		public bool IncentivizeRibbon2 { get; set; }
		[FlagString(Character = INCENTIVES_ITEMS1, FlagBit = 16)]
		public bool Incentivize65K { get; set; }
		[FlagString(Character = INCENTIVES_ITEMS1, FlagBit = 32)]
		public bool IncentivizeBad { get; set; }

		[FlagString(Character = INCENTIVES_ITEMS2, FlagBit = 1)]
		public bool IncentivizeDefCastArmor { get; set; }
		[FlagString(Character = INCENTIVES_ITEMS2, FlagBit = 2)]
		public bool IncentivizeOffCastArmor { get; set; }
		[FlagString(Character = INCENTIVES_ITEMS2, FlagBit = 4)]
		public bool IncentivizeOtherCastArmor { get; set; }
		[FlagString(Character = INCENTIVES_ITEMS2, FlagBit = 8)]
		public bool IncentivizeDefCastWeapon { get; set; }
		[FlagString(Character = INCENTIVES_ITEMS2, FlagBit = 16)]
		public bool IncentivizeOffCastWeapon { get; set; }
		[FlagString(Character = INCENTIVES_ITEMS2, FlagBit = 32)]
		public bool IncentivizeOtherCastWeapon { get; set; }
		
		[FlagString(Character = ITEM_REQUIREMENTS, FlagBit = 1)]
		public bool EarlySarda { get; set; }
		[FlagString(Character = ITEM_REQUIREMENTS, FlagBit = 2)]
		public bool EarlySage { get; set; }
		[FlagString(Character = ITEM_REQUIREMENTS, FlagBit = 32)]
		public bool OnlyRequireGameIsBeatable { get; set; }
		
		[FlagString(Character = FILTHY_CASUALS, FlagBit = 1)]
		public bool FreeBridge { get; set; }
		[FlagString(Character = FILTHY_CASUALS, FlagBit = 2)]
		public bool FreeAirship { get; set; }
		[FlagString(Character = FILTHY_CASUALS, FlagBit = 32)]
		public bool EasyMode { get; set; }
		
		[FlagString(Character = CONVENIENCES, FlagBit = 1)]
		public bool SpeedHacks { get; set; }
		[FlagString(Character = CONVENIENCES, FlagBit = 2)]
		public bool NoPartyShuffle { get; set; }
		[FlagString(Character = CONVENIENCES, FlagBit = 4)]
		public bool Dash { get; set; }
		[FlagString(Character = CONVENIENCES, FlagBit = 8)]
		public bool BuyTen { get; set; }
		[FlagString(Character = CONVENIENCES, FlagBit = 16)]
		public bool IdentifyTreasures { get; set; }
		[FlagString(Character = CONVENIENCES, FlagBit = 32)]
		public bool WaitWhenUnrunnable { get; set; }

		[FlagString(Character = BUG_FIXES, FlagBit = 1)]
		public bool HouseMPRestoration { get; set; }
		[FlagString(Character = BUG_FIXES, FlagBit = 2)]
		public bool WeaponStats { get; set; }
		[FlagString(Character = BUG_FIXES, FlagBit = 4)]
		public bool ChanceToRun { get; set; }
		[FlagString(Character = BUG_FIXES, FlagBit = 8)]
		public bool SpellBugs { get; set; }
		[FlagString(Character = BUG_FIXES, FlagBit = 16)]
		public bool BlackBeltAbsorb { get; set; } // Planned 2.1 feature
		
		[FlagString(Character = ENEMY_BUG_FIXES, FlagBit = 1)]
		public bool EnemyStatusAttackBug { get; set; }
		[FlagString(Character = ENEMY_BUG_FIXES, FlagBit = 2)]
		public bool EnemySpellsTargetingAllies { get; set; }// Planned 2.1 feature
		[FlagString(Character = ENEMY_BUG_FIXES, FlagBit = 4)]
		public bool EnemyElementalResistancesBug { get; set; }// Planned 2.1 feature

		[FlagString(Character = 17, Multiplier = 0.1)]
		public double EnemyScaleFactor { get; set; }
		[FlagString(Character = 18, Multiplier = 0.1)]
		public double PriceScaleFactor { get; set; }
		[FlagString(Character = 19, Multiplier = 0.1)]
		public double ExpMultiplier { get; set; }
		[FlagString(Character = 20, Multiplier = 10)]
		public int ExpBonus { get; set; }
		[FlagString(Character = 21, Multiplier = 1)]
		public int ForcedPartyMembers { get; set; }
		
		
		public bool ModernBattlefield { get; set; }
		public bool FunEnemyNames { get; set; }
		public bool PaletteSwap { get; set; }
		public bool TeamSteak { get; set; }
		public MusicShuffle Music { get; set; }


		public bool MapCanalBridge => NPCItems || NPCFetchItems;
		public bool MapOnracDock => MapOpenProgression;
		public bool MapMirageDock => MapOpenProgression;
		public bool MapConeriaDwarves => MapOpenProgression;
		public bool MapVolcanoIceRiver => MapOpenProgression;
		
		public bool IncentivizeAdamant => IncentivizeFetchItems;
		public bool IncentivizeRuby => (!EarlySage && !NPCItems) || IncentivizeFetchItems;
		public bool IncentivizeCrown => !NPCFetchItems || IncentivizeFetchItems;
		public bool IncentivizeTnt => (!NPCFetchItems && !NPCItems) || IncentivizeFetchItems; // If Canoe and Fetch Quests are unshuffled then TNT is required
		public bool IncentivizeSlab => !NPCFetchItems || IncentivizeFetchItems;
		public bool IncentivizeBottle => !NPCFetchItems || IncentivizeFetchItems;

		public bool IncentivizeFloater => true;
		public bool IncentivizeBridge => !MapOpenProgression || IncentivizeFetchItems;
		public bool IncentivizeLute => true;
		public bool IncentivizeShip => !MapOpenProgression || IncentivizeFetchItems;
		public bool IncentivizeRod => true;
		public bool IncentivizeCanoe => true;
		public bool IncentivizeCube => true;
		
		public bool IncentivizeCrystal => IncentivizeFetchItems;
		public bool IncentivizeHerb => IncentivizeFetchItems;
		public bool IncentivizeKey => true;
		public bool IncentivizeCanal => !NPCItems || IncentivizeFetchItems; // If Canoe is unshuffled then Canal is Required
		public bool IncentivizeChime => true;
		public bool IncentivizeOxyale => true;
		public bool IncentivizeXcalber => false;
		
		public bool IncentivizeKingConeria => IncentivizeFreeNPCs;
		public bool IncentivizePrincess => IncentivizeFreeNPCs;
		public bool IncentivizeBikke => IncentivizeFreeNPCs;
		public bool IncentivizeSarda => IncentivizeFreeNPCs;
		public bool IncentivizeCanoeSage => IncentivizeFreeNPCs;
		public bool IncentivizeCaravan => IncentivizeFreeNPCs;
		public bool IncentivizeCubeBot => IncentivizeFreeNPCs;
		
		public bool IncentivizeFairy => IncentivizeFetchNPCs;
		public bool IncentivizeAstos => IncentivizeFetchNPCs;
		public bool IncentivizeMatoya => IncentivizeFetchNPCs;
		public bool IncentivizeElfPrince => IncentivizeFetchNPCs;
		public bool IncentivizeNerrick => IncentivizeFetchNPCs;
		public bool IncentivizeLefein => IncentivizeFetchNPCs;
		public bool IncentivizeSmith => IncentivizeFetchNPCs;
		

		public static Dictionary<string, FlagStringAttribute> GetFlagStringAttributes()
		{
			var allProps =
				typeof(Flags).GetProperties()
					.Where(x => (x.GetCustomAttributes(typeof(FlagStringAttribute), false).FirstOrDefault() as FlagStringAttribute) != null);
			return allProps
				.ToDictionary(x => x.Name,
							x => x.GetCustomAttributes(typeof(FlagStringAttribute), false)
								.FirstOrDefault() as FlagStringAttribute);
		}

		public string GetString()
		{
			return EncodeFlagsText(this);
		}

		// ! and % are printable in FF, + and / are not.
		private const string base64CharString = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-!";
		public static string EncodeFlagsText(Flags flags)
		{
			var base64Chars = base64CharString.ToCharArray();
			var flagAttributes = GetFlagStringAttributes().GroupBy(x => x.Value.Character).OrderBy(x => x.Key);
			var result = "";

			foreach (var flagCharacterPropertyGroup in flagAttributes)
			{
				var flagCharacterIndex = 0;
				foreach (var flagProperty in flagCharacterPropertyGroup)
				{
					var flagsPropertyValue = typeof(Flags).GetProperty(flagProperty.Key).GetValue(flags, null);
					if (flagProperty.Value.FlagBit > 0)
					{
						if ((flagsPropertyValue as bool?).GetValueOrDefault())
							flagCharacterIndex += flagProperty.Value.FlagBit;
						continue;
					}
					flagCharacterIndex += Convert.ToInt32((Convert.ToDouble(flagsPropertyValue) / flagProperty.Value.Multiplier));
				}
				flagCharacterIndex = flagCharacterIndex % 64;
				result += base64Chars[flagCharacterIndex];
			}
			return result;
		}

		public static Flags DecodeFlagsText(string text)
		{
			var inputCharacters = text.ToCharArray();
			var flagAttributes = GetFlagStringAttributes().GroupBy(x => x.Value.Character).ToDictionary(x => x.Key, x => x.ToList());
			var result = new Flags();
			var index = 0;
			foreach (var inputChar in inputCharacters)
			{
				var charFlagValue = base64CharString.IndexOf(inputChar);
				var flagAttributesForChar = flagAttributes[index];
				if (flagAttributesForChar.Any(x => x.Value.FlagBit < 1))
				{
					var multiplierAttribute = flagAttributesForChar.First(x => x.Value.FlagBit < 1);
					var outputValue = charFlagValue * multiplierAttribute.Value.Multiplier;
					typeof(Flags).GetProperty(multiplierAttribute.Key).SetValue(result, outputValue);
					continue;
				}
				foreach (var flagAttribute in flagAttributesForChar)
				{
					var outputValue = (charFlagValue & flagAttribute.Value.FlagBit) > 0;
					typeof(Flags).GetProperty(flagAttribute.Key).SetValue(result, outputValue);
				}
			}
			return result;
		}
	}

	public class FlagStringAttribute : Attribute
	{
		public int Character { get; set; }
		public int FlagBit { get; set; }
		public double Multiplier { get; set; }

		public string ToVueComputedPropertyString()
		{
			if (FlagBit > 0)
				return $"{{get:function(){{if(this.flagString.length <= {Character}) return false;" +
				$"return (base64Chars.indexOf(this.flagString.charAt({Character})) & {FlagBit}) > 0; }}, " +
				$"set:function(){{while(this.flagString.length <= {Character})this.flagString += base64Chars[0];" +
				$"var toggled = (base64Chars.indexOf(this.flagString.charAt({Character}))) ^ {FlagBit};" +
				$"this.flagString = this.flagString.substr(0,{Character}) + base64Chars[toggled] + this.flagString.substr({Character + 1});}}}}";

			return $"{{get:function (){{ if (this.flagString.length <= {Character}) return 0; " +
			$"return base64Chars.indexOf(this.flagString[{Character}]) * {Multiplier};}}," +
			$"set:function(newValue){{while(this.flagString.length <= {Character})this.flagString += base64Chars[0];" +
			$"var scaledValue = (newValue / {Multiplier}).toFixed() % base64Chars.length;" +
			$"this.flagString = this.flagString.substr(0,{Character}) + base64Chars[scaledValue] + this.flagString.substr({Character + 1});}} }}";

		}
	}
}
