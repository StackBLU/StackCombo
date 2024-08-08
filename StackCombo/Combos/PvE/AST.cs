using Dalamud.Game.ClientState.JobGauge.Enums;
using Dalamud.Game.ClientState.JobGauge.Types;
using StackCombo.ComboHelper.Functions;
using StackCombo.CustomCombo;
using StackCombo.Data;
using System.Collections.Generic;
using System.Linq;

namespace StackCombo.Combos.PvE
{
	internal static class AST
	{
		internal const byte JobID = 33;

		internal const uint
			Malefic = 3596,
			Malefic2 = 3598,
			Malefic3 = 7442,
			Malefic4 = 16555,
			FallMalefic = 25871,
			Gravity = 3615,
			Gravity2 = 25872,
			Oracle = 37029,

			AstralDraw = 37017,
			Play1 = 37019,
			Play2 = 37020,
			Play3 = 37021,
			Arrow = 37024,
			Balance = 37023,
			Bole = 37027,
			Ewer = 37028,
			Spear = 37026,
			Spire = 37025,
			MinorArcana = 37022,
			Divination = 16552,
			Lightspeed = 3606,

			Combust = 3599,
			Combust2 = 3608,
			Combust3 = 16554,

			Benefic = 3594,
			Benefic2 = 3610,
			AspectedBenefic = 3595,
			Helios = 3600,
			AspectedHelios = 3601,
			HeliosConjuction = 37030,
			Ascend = 3603,
			EssentialDignity = 3614,
			CelestialOpposition = 16553,
			CelestialIntersection = 16556,
			Horoscope = 16557,
			Exaltation = 25873,
			Macrocosmos = 25874,
			Synastry = 3612;

		internal static class Buffs
		{
			internal const ushort
				AspectedBenefic = 835,
				AspectedHelios = 836,
				HeliosConjunction = 3894,
				Horoscope = 1890,
				HoroscopeHelios = 1891,
				NeutralSect = 1892,
				NeutralSectShield = 1921,
				Divination = 1878,
				LordOfCrownsDrawn = 2054,
				LadyOfCrownsDrawn = 2055,
				ClarifyingDraw = 2713,
				Macrocosmos = 2718,
				BalanceDrawn = 913,
				BoleDrawn = 914,
				ArrowDrawn = 915,
				SpearDrawn = 916,
				EwerDrawn = 917,
				SpireDrawn = 918,
				BalanceBuff = 3887,
				BoleBuff = 3890,
				ArrowBuff = 3888,
				SpearBuff = 3889,
				EwerBuff = 3891,
				SpireBuff = 3892,
				Lightspeed = 841,
				SelfSynastry = 845,
				TargetSynastry = 846,
				Divining = 3893;
		}

		internal static class Debuffs
		{
			internal const ushort
				Combust = 838,
				Combust2 = 843,
				Combust3 = 1881;
		}

		internal static Dictionary<uint, ushort>
			CombustList = new() {
				{ Combust,  Debuffs.Combust  },
				{ Combust2, Debuffs.Combust2 },
				{ Combust3, Debuffs.Combust3 }
			};

		public static ASTGauge Gauge
		{
			get
			{
				return CustomComboFunctions.GetJobGauge<ASTGauge>();
			}
		}

		public static class Config
		{
			public static UserInt
				AST_ST_DPS_Lucid = new("AST_ST_DPS_Lucid", 7500),
				AST_AoE_DPS_Lucid = new("AST_AoE_DPS_Lucid", 7500);
			public static UserBool
				AST_ST_DPS_OverwriteCards = new("AST_ST_DPS_OverwriteCards"),
				AST_AoE_DPS_OverwriteCards = new("AST_AoE_DPS_OverwriteCards");
		}

		internal class AST_ST_DPS : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.AST_ST_DPS;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if ((actionID is Malefic or Malefic2 or Malefic3 or Malefic4 or FallMalefic) && IsEnabled(CustomComboPreset.AST_ST_DPS))
				{
					if (IsEnabled(CustomComboPreset.AST_ST_DPS_Lucid) && ActionReady(All.LucidDreaming) && LocalPlayer.CurrentMp <= 1000)
					{
						return All.LucidDreaming;
					}

					if (IsEnabled(CustomComboPreset.AST_ST_DPS_Lucid) && ActionReady(All.LucidDreaming)
						&& LocalPlayer.CurrentMp <= GetOptionValue(Config.AST_ST_DPS_Lucid) && CanSpellWeave(actionID))
					{
						return All.LucidDreaming;
					}

					if (IsEnabled(CustomComboPreset.AST_ST_DPS_AutoDraw) && ActionReady(OriginalHook(AstralDraw))
						&& (Gauge.DrawnCards.All(x => x is CardType.NONE)
						|| (!Gauge.DrawnCards.Any(x => x is CardType.BALANCE) && !Gauge.DrawnCards.Any(x => x is CardType.SPEAR) && Config.AST_ST_DPS_OverwriteCards))
						&& CanSpellWeave(actionID))
					{
						return OriginalHook(AstralDraw);
					}

					if (IsEnabled(CustomComboPreset.AST_ST_DPS_CombustUptime) && ActionReady(OriginalHook(Combust3)) && ActionWatching.NumberOfGcdsUsed >= 3
						&& (!TargetHasEffect(CombustList[OriginalHook(Combust3)]) || GetDebuffRemainingTime(CombustList[OriginalHook(Combust3)]) <= 3))
					{
						return OriginalHook(Combust3);
					}

				}
				return actionID;
			}
		}

		internal class AST_AoE_DPS : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.AST_AoE_DPS;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if ((actionID is Gravity or Gravity2) && IsEnabled(CustomComboPreset.AST_AoE_DPS))
				{
					if (IsEnabled(CustomComboPreset.AST_AoE_DPS_Lucid) && ActionReady(All.LucidDreaming) && LocalPlayer.CurrentMp <= 1000)
					{
						return All.LucidDreaming;
					}

					if (IsEnabled(CustomComboPreset.AST_AoE_DPS_Lucid) && ActionReady(All.LucidDreaming)
						&& LocalPlayer.CurrentMp <= GetOptionValue(Config.AST_AoE_DPS_Lucid) && CanSpellWeave(actionID))
					{
						return All.LucidDreaming;
					}

					if (IsEnabled(CustomComboPreset.AST_AoE_DPS_AutoDraw) && ActionReady(OriginalHook(AstralDraw))
						&& (Gauge.DrawnCards.All(x => x is CardType.NONE)
						|| (!Gauge.DrawnCards.Any(x => x is CardType.BALANCE) && !Gauge.DrawnCards.Any(x => x is CardType.SPEAR) && Config.AST_AoE_DPS_OverwriteCards))
						&& CanSpellWeave(actionID))
					{
						return OriginalHook(AstralDraw);
					}
				}
				return actionID;
			}
		}

		internal class AST_ST_SimpleHeals : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.AST_ST_SimpleHeals;
			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID is Benefic2)
				{
					if (IsEnabled(CustomComboPreset.AST_ST_SimpleHeals_AspectedBenefic) && ActionReady(AspectedBenefic))
					{
						if (!TargetHasEffect(Buffs.AspectedBenefic))
						{
							return AspectedBenefic;
						}
					}
				}
				return actionID;
			}
		}

		internal class AST_Benefic : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.AST_Benefic;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				return actionID is Benefic2 && !ActionReady(Benefic2) ? Benefic : actionID;
			}
		}

		internal class AST_Raise_Alternative : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.AST_Raise_Alternative;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				return actionID is Ascend && IsOffCooldown(All.Swiftcast) && ActionReady(Ascend) ? All.Swiftcast : actionID;
			}
		}

		internal class AST_Lightspeed_Protection : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.AST_Lightspeed_Protection;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				return actionID is Lightspeed && HasEffect(Buffs.Lightspeed) && ActionReady(Lightspeed) ? OriginalHook(11) : actionID;
			}
		}

		internal class AST_DrawCooldown : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.AST_DrawCooldown;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID is Play1)
				{
					if (!Gauge.DrawnCards.Any(x => x is CardType.BALANCE) && !Gauge.DrawnCards.Any(x => x is CardType.SPEAR))
					{
						return OriginalHook(AstralDraw);
					}
					return actionID;
				}

				if (actionID is Play2)
				{
					if (!Gauge.DrawnCards.Any(x => x is CardType.ARROW) && !Gauge.DrawnCards.Any(x => x is CardType.BOLE))
					{
						return OriginalHook(AstralDraw);
					}
					return actionID;
				}

				if (actionID is Play3)
				{
					if (!Gauge.DrawnCards.Any(x => x is CardType.SPIRE) && !Gauge.DrawnCards.Any(x => x is CardType.EWER))
					{
						return OriginalHook(AstralDraw);
					}
					return actionID;
				}
				return actionID;
			}
		}
	}
}