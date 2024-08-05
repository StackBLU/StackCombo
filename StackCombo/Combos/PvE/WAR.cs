using Dalamud.Game.ClientState.JobGauge.Types;
using StackCombo.ComboHelper.Functions;
using StackCombo.Combos.PvE.Content;
using StackCombo.CustomCombo;

namespace StackCombo.Combos.PvE
{
	internal static class WAR
	{
		public const byte JobID = 21;

		public const uint
			HeavySwing = 31,
			Maim = 37,
			Berserk = 38,
			Overpower = 41,
			StormsPath = 42,
			Holmgang = 43,
			StormsEye = 45,
			Tomahawk = 46,
			InnerBeast = 49,
			SteelCyclone = 51,
			Infuriate = 52,
			FellCleave = 3549,
			Decimate = 3550,
			Upheaval = 7387,
			InnerRelease = 7389,
			RawIntuition = 3551,
			MythrilTempest = 16462,
			ChaoticCyclone = 16463,
			NascentFlash = 16464,
			InnerChaos = 16465,
			Orogeny = 25752,
			PrimalRend = 25753,
			PrimalWrath = 36924,
			PrimalRuination = 36925,
			Onslaught = 7386;

		public static class Buffs
		{
			public const ushort
				InnerReleaseStacks = 1177,
				InnerReleaseBuff = 1303,
				SurgingTempest = 2677,
				NascentChaos = 1897,
				PrimalRendReady = 2624,
				Wrathful = 3901,
				PrimalRuinationReady = 3834,
				BurgeoningFury = 3833,
				Berserk = 86;
		}

		private static WARGauge Gauge
		{
			get
			{
				return CustomComboFunctions.GetJobGauge<WARGauge>();
			}
		}

		public static class Config
		{
			public static UserInt
				WAR_VariantCure = new("WAR_VariantCure", 50),
				WAR_SurgingRefreshRange = new("WAR_SurgingRefreshRange", 20),
				WAR_FellCleaveGauge = new("WAR_FellCleaveGauge", 50),
				WAR_DecimateGauge = new("WAR_DecimateGauge", 50),
				WAR_ST_Invuln = new("WAR_ST_Invuln", 10),
				WAR_AoE_Invuln = new("WAR_AoE_Invuln", 10);
		}

		internal class WAR_ST_DPS : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.WAR_ST_DPS;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID is HeavySwing or Maim or StormsPath or StormsEye && IsEnabled(CustomComboPreset.WAR_ST_DPS))
				{
					if (IsEnabled(CustomComboPreset.WAR_Variant_Cure) && IsEnabled(Variant.VariantCure)
						&& PlayerHealthPercentageHp() <= Config.WAR_VariantCure)
					{
						return Variant.VariantCure;
					}

					if (IsEnabled(CustomComboPreset.WAR_Variant_SpiritDart) && IsEnabled(Variant.VariantSpiritDart)
						&& (!TargetHasEffectAny(Variant.Debuffs.SustainedDamage) || GetDebuffRemainingTime(Variant.Debuffs.SustainedDamage) <= 3))
					{
						return Variant.VariantSpiritDart;
					}

					if (IsEnabled(CustomComboPreset.WAR_Variant_Ultimatum) && IsEnabled(Variant.VariantUltimatum) && IsOffCooldown(Variant.VariantUltimatum))
					{
						return Variant.VariantUltimatum;
					}

					if (IsEnabled(CustomComboPreset.WAR_ST_Invuln) && PlayerHealthPercentageHp() <= GetOptionValue(Config.WAR_ST_Invuln))
					{
						return Holmgang;
					}

					if (CanWeave(actionID) && GetBuffRemainingTime(Buffs.SurgingTempest) > 3)
					{
						if (IsEnabled(CustomComboPreset.WAR_ST_InnerRelease) && ActionReady(OriginalHook(InnerRelease)))
						{
							return OriginalHook(InnerRelease);
						}

						if (IsEnabled(CustomComboPreset.WAR_ST_Upheaval) && ActionReady(Upheaval) & InMeleeRange())
						{
							return Upheaval;
						}
					}

					if (IsEnabled(CustomComboPreset.WAR_ST_FellCleave) && ActionReady(OriginalHook(FellCleave))
						&& GetBuffRemainingTime(Buffs.SurgingTempest) > 3
						&& (HasEffect(Buffs.InnerReleaseStacks) || HasEffect(Buffs.NascentChaos) || Gauge.BeastGauge >= Config.WAR_FellCleaveGauge))
					{
						return OriginalHook(FellCleave);
					}

					if (comboTime > 0)
					{
						if (lastComboMove is HeavySwing && ActionReady(Maim))
						{
							return Maim;
						}

						if (lastComboMove is Maim && ActionReady(StormsPath) && IsEnabled(CustomComboPreset.WAR_ST_StormsEye) & ActionReady(StormsEye))
						{
							if (GetBuffRemainingTime(Buffs.SurgingTempest) <= Config.WAR_SurgingRefreshRange)
							{
								return StormsEye;
							}
							if (ActionReady(StormsPath))
							{
								return StormsPath;
							}
						}
					}
					return HeavySwing;
				}
				return actionID;
			}
		}

		internal class WAR_AoE_DPS : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.WAR_AoE_DPS;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID is Overpower or MythrilTempest && IsEnabled(CustomComboPreset.WAR_AoE_DPS))
				{
					if (IsEnabled(CustomComboPreset.WAR_Variant_Cure) && IsEnabled(Variant.VariantCure)
						&& PlayerHealthPercentageHp() <= Config.WAR_VariantCure)
					{
						return Variant.VariantCure;
					}

					if (IsEnabled(CustomComboPreset.WAR_Variant_SpiritDart) && IsEnabled(Variant.VariantSpiritDart)
						&& (!TargetHasEffectAny(Variant.Debuffs.SustainedDamage) || GetDebuffRemainingTime(Variant.Debuffs.SustainedDamage) <= 3))
					{
						return Variant.VariantSpiritDart;
					}

					if (IsEnabled(CustomComboPreset.WAR_Variant_Ultimatum) && IsEnabled(Variant.VariantUltimatum) && IsOffCooldown(Variant.VariantUltimatum))
					{
						return Variant.VariantUltimatum;
					}

					if (IsEnabled(CustomComboPreset.WAR_AoE_Invuln) && PlayerHealthPercentageHp() <= GetOptionValue(Config.WAR_AoE_Invuln))
					{
						return Holmgang;
					}

					if (CanWeave(actionID) && GetBuffRemainingTime(Buffs.SurgingTempest) > 3)
					{
						if (IsEnabled(CustomComboPreset.WAR_AoE_InnerRelease) && ActionReady(OriginalHook(InnerRelease)))
						{
							return OriginalHook(InnerRelease);
						}

						if (IsEnabled(CustomComboPreset.WAR_AoE_Orogeny) && ActionReady(Orogeny) & InMeleeRange())
						{
							return Orogeny;
						}
					}

					if (IsEnabled(CustomComboPreset.WAR_AoE_Decimate) && ActionReady(OriginalHook(Decimate))
						&& GetBuffRemainingTime(Buffs.SurgingTempest) > 3
						&& (HasEffect(Buffs.InnerReleaseStacks) || HasEffect(Buffs.NascentChaos) || Gauge.BeastGauge >= Config.WAR_DecimateGauge))
					{
						return OriginalHook(Decimate);
					}

					if (comboTime > 0)
					{
						if (lastComboMove is Overpower && ActionReady(MythrilTempest))
						{
							return MythrilTempest;
						}
					}
					return Overpower;
				}
				return actionID;
			}
		}
	}
}