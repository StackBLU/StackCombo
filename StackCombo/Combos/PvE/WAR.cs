using Dalamud.Game.ClientState.JobGauge.Types;
using Dalamud.Game.ClientState.Statuses;
using StackCombo.Combos.PvE.Content;
using StackCombo.Core;
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

		public static class Debuffs
		{
			public const ushort
				Placeholder = 1;
		}

		public static class Config
		{
			public const string
				WAR_InfuriateRange = "WarInfuriateRange",
				WAR_SurgingRefreshRange = "WarSurgingRefreshRange",
				WAR_VariantCure = "WAR_VariantCure",
				WAR_FellCleaveGauge = "WAR_FellCleaveGauge",
				WAR_DecimateGauge = "WAR_DecimateGauge",
				WAR_InfuriateSTGauge = "WAR_InfuriateSTGauge",
				WAR_InfuriateAoEGauge = "WAR_InfuriateAoEGauge";
		}

		internal class WAR_ST_StormsPath : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.WAR_ST_StormsPath;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (IsEnabled(CustomComboPreset.WAR_ST_StormsPath) && actionID == StormsPath)
				{
					byte gauge = GetJobGauge<WARGauge>().BeastGauge;
					int surgingThreshold = PluginConfiguration.GetCustomIntValue(Config.WAR_SurgingRefreshRange);
					int fellCleaveGaugeSpend = PluginConfiguration.GetCustomIntValue(Config.WAR_FellCleaveGauge);
					_ = GetCooldown(HeavySwing).CooldownTotal;

					if (IsEnabled(CustomComboPreset.WAR_Variant_Cure) && IsEnabled(Variant.VariantCure) && PlayerHealthPercentageHp() <= GetOptionValue(Config.WAR_VariantCure))
					{
						return Variant.VariantCure;
					}

					if (IsEnabled(CustomComboPreset.WAR_ST_StormsPath_InnerRelease) && CanWeave(actionID) && IsOffCooldown(OriginalHook(Berserk)) && ActionReady(Berserk) && !ActionReady(StormsEye) && InCombat())
					{
						return OriginalHook(Berserk);
					}

					if (HasEffect(Buffs.SurgingTempest) && InCombat())
					{
						if (CanWeave(actionID))
						{
							Status? sustainedDamage = FindTargetEffect(Variant.Debuffs.SustainedDamage);
							if (IsEnabled(CustomComboPreset.WAR_Variant_SpiritDart) &&
								IsEnabled(Variant.VariantSpiritDart) &&
								(sustainedDamage is null || sustainedDamage?.RemainingTime <= 3))
							{
								return Variant.VariantSpiritDart;
							}

							if (IsEnabled(CustomComboPreset.WAR_Variant_Ultimatum) && IsEnabled(Variant.VariantUltimatum) && IsOffCooldown(Variant.VariantUltimatum))
							{
								return Variant.VariantUltimatum;
							}

							if (IsEnabled(CustomComboPreset.WAR_ST_StormsPath_InnerRelease) && CanWeave(actionID) && IsOffCooldown(OriginalHook(Berserk)) && ActionReady(Berserk))
							{
								return OriginalHook(Berserk);
							}

							if (IsEnabled(CustomComboPreset.WAR_ST_StormsPath_Upheaval) && IsOffCooldown(Upheaval) && ActionReady(Upheaval))
							{
								return Upheaval;
							}
						}

						if (IsEnabled(CustomComboPreset.WAR_ST_StormsPath_FellCleave) && ActionReady(InnerBeast))
						{
							if (HasEffect(Buffs.InnerReleaseStacks) || (HasEffect(Buffs.NascentChaos) && !ActionReady(InnerChaos)))
							{
								return OriginalHook(InnerBeast);
							}

							if (HasEffect(Buffs.NascentChaos) && gauge >= 50 && !ActionReady(InnerChaos))
							{
								return OriginalHook(Decimate);
							}
						}

					}

					if (comboTime > 0)
					{
						if (IsEnabled(CustomComboPreset.WAR_ST_StormsPath_FellCleave) && ActionReady(InnerBeast) && (!ActionReady(StormsEye) || HasEffectAny(Buffs.SurgingTempest)) && gauge >= fellCleaveGaugeSpend)
						{
							return OriginalHook(InnerBeast);
						}

						if (lastComboMove == HeavySwing && ActionReady(Maim))
						{
							return Maim;
						}

						if (lastComboMove == Maim && ActionReady(StormsPath) && IsEnabled(CustomComboPreset.WAR_ST_StormsPath_StormsEye))
						{
							return GetBuffRemainingTime(Buffs.SurgingTempest) <= surgingThreshold && ActionReady(StormsEye) ? StormsEye : StormsPath;
						}
						if (lastComboMove == Maim && ActionReady(StormsPath) && IsNotEnabled(CustomComboPreset.WAR_ST_StormsPath_StormsEye))
						{
							return StormsPath;
						}
					}
					return HeavySwing;
				}
				return actionID;
			}
		}

		internal class WAR_AoE_Overpower : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.WAR_AoE_Overpower;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID == Overpower)
				{
					byte gauge = GetJobGauge<WARGauge>().BeastGauge;
					int decimateGaugeSpend = PluginConfiguration.GetCustomIntValue(Config.WAR_DecimateGauge);

					if (IsEnabled(CustomComboPreset.WAR_Variant_Cure) && IsEnabled(Variant.VariantCure) && PlayerHealthPercentageHp() <= GetOptionValue(Config.WAR_VariantCure))
					{
						return Variant.VariantCure;
					}

					if (IsEnabled(CustomComboPreset.WAR_AoE_Overpower_InnerRelease) && CanWeave(actionID) && IsOffCooldown(OriginalHook(Berserk)) && ActionReady(Berserk) && !ActionReady(MythrilTempest) && InCombat())
					{
						return OriginalHook(Berserk);
					}

					if (HasEffect(Buffs.SurgingTempest) && InCombat())
					{
						if (CanWeave(actionID))
						{
							Status? sustainedDamage = FindTargetEffect(Variant.Debuffs.SustainedDamage);
							if (IsEnabled(CustomComboPreset.WAR_Variant_SpiritDart) &&
								IsEnabled(Variant.VariantSpiritDart) &&
								(sustainedDamage is null || sustainedDamage?.RemainingTime <= 3))
							{
								return Variant.VariantSpiritDart;
							}

							if (IsEnabled(CustomComboPreset.WAR_Variant_Ultimatum) && IsEnabled(Variant.VariantUltimatum) && IsOffCooldown(Variant.VariantUltimatum))
							{
								return Variant.VariantUltimatum;
							}

							if (IsEnabled(CustomComboPreset.WAR_AoE_Overpower_InnerRelease) && CanWeave(actionID) && IsOffCooldown(OriginalHook(Berserk)) && ActionReady(Berserk))
							{
								return OriginalHook(Berserk);
							}

							if (IsEnabled(CustomComboPreset.WAR_AoE_Overpower_Orogeny) && IsOffCooldown(Orogeny) && ActionReady(Orogeny) && HasEffect(Buffs.SurgingTempest))
							{
								return Orogeny;
							}
						}
					}
					if (IsEnabled(CustomComboPreset.WAR_AoE_Overpower_Decimate) && ActionReady(SteelCyclone) && (gauge >= decimateGaugeSpend || HasEffect(Buffs.InnerReleaseStacks) || HasEffect(Buffs.NascentChaos)))
					{
						return OriginalHook(SteelCyclone);
					}

					if (comboTime > 0)
					{
						return lastComboMove == Overpower && ActionReady(MythrilTempest) ? MythrilTempest : Overpower;
					}
				}
				return actionID;
			}
		}

		internal class WAR_InfuriateFellCleave : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.WAR_InfuriateFellCleave;

			protected override uint Invoke(uint actionID, uint lastComboActionID, float comboTime, byte level)
			{
				if (actionID is InnerBeast or FellCleave or SteelCyclone or Decimate)
				{
					WARGauge rageGauge = GetJobGauge<WARGauge>();
					int rageThreshold = PluginConfiguration.GetCustomIntValue(Config.WAR_InfuriateRange);
					bool hasNascent = HasEffect(Buffs.NascentChaos);
					bool hasInnerRelease = HasEffect(Buffs.InnerReleaseStacks);

					if (InCombat() && rageGauge.BeastGauge <= rageThreshold && ActionReady(Infuriate) && !hasNascent
					&& ((!hasInnerRelease) || IsNotEnabled(CustomComboPreset.WAR_InfuriateFellCleave_IRFirst)))
					{
						return OriginalHook(Infuriate);
					}
				}

				return actionID;
			}
		}
	}
}