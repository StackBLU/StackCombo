using Dalamud.Game.ClientState.JobGauge.Types;
using StackCombo.Combos.PvE.Content;
using StackCombo.Core;
using StackCombo.CustomCombo;

namespace StackCombo.Combos.PvE
{
	internal static class DRK
	{
		public const byte JobID = 32;

		public const uint
			HardSlash = 3617,
			SyphonStrike = 3623,
			Souleater = 3632,

			Unleash = 3621,
			StalwartSoul = 16468,

			CarveAndSpit = 3643,
			EdgeOfDarkness = 16467,
			EdgeOfShadow = 16470,
			Bloodspiller = 7392,
			ScarletDelirium = 36928,
			Comeuppance = 36929,
			Torcleaver = 36930,

			AbyssalDrain = 3641,
			FloodOfDarkness = 16466,
			FloodOfShadow = 16469,
			Quietus = 7391,
			SaltedEarth = 3639,
			SaltAndDarkness = 25755,
			Impalement = 36931,

			BloodWeapon = 3625,
			Delirium = 7390,

			LivingShadow = 16472,
			Shadowbringer = 25757,
			Disesteem = 36932,

			Unmend = 3624;

		public static class Buffs
		{
			public const ushort
				BloodWeapon = 742,
				Delirium = 3836,

				Darkside = 741,
				BlackestNight = 1178,

				SaltedEarth = 749,
				Scorn = 3837;
		}

		public static class Debuffs
		{
			public const ushort
				Placeholder = 1;
		}

		public static class Config
		{
			public const string
				DRK_ST_ManaSpenderPooling = "DRK_ST_ManaSpenderPooling",
				DRK_ST_LivingDeadThreshold = "DRK_ST_LivingDeadThreshold",
				DRK_AoE_LivingDeadThreshold = "DRK_AoE_LivingDeadThreshold",
				DRK_VariantCure = "DRKVariantCure";
		}

		internal class DRK_Souleater_Combo : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.DRK_ST_Combo;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID != Souleater)
				{
					return actionID;
				}

				DRKGauge gauge = GetJobGauge<DRKGauge>();
				int mpRemaining = PluginConfiguration.GetCustomIntValue(Config.DRK_ST_ManaSpenderPooling);
				int hpRemaining = PluginConfiguration.GetCustomIntValue(Config.DRK_ST_LivingDeadThreshold);

				if (IsEnabled(CustomComboPreset.DRK_Variant_Cure)
					&& IsEnabled(Variant.VariantCure)
					&& PlayerHealthPercentageHp() <= GetOptionValue(Config.DRK_VariantCure))
				{
					return Variant.VariantCure;
				}

				if (IsEnabled(CustomComboPreset.DRK_ST_RangedUptime)
					&& ActionReady(Unmend)
					&& !InMeleeRange()
					&& HasBattleTarget())
				{
					return Unmend;
				}

				if (!InCombat())
				{
					return HardSlash;
				}

				if (ActionReady(LivingShadow)
					&& ActionReady(Disesteem)
					&& IsEnabled(CustomComboPreset.DRK_ST_CDs_Disesteem)
					&& HasEffect(Buffs.Scorn)
					&& ((gauge.DarksideTimeRemaining > 0 && GetBuffRemainingTime(Buffs.Scorn) < 26)
						|| GetBuffRemainingTime(Buffs.Scorn) < 14)
					)
				{
					return OriginalHook(Disesteem);
				}

				if (CanWeave(actionID))
				{
					Dalamud.Game.ClientState.Statuses.Status? sustainedDamage = FindTargetEffect(Variant.Debuffs.SustainedDamage);
					if (IsEnabled(CustomComboPreset.DRK_Variant_SpiritDart)
						&& IsEnabled(Variant.VariantSpiritDart)
						&& (sustainedDamage is null || sustainedDamage?.RemainingTime <= 3))
					{
						return Variant.VariantSpiritDart;
					}

					if (IsEnabled(CustomComboPreset.DRK_Variant_Ultimatum)
						&& IsEnabled(Variant.VariantUltimatum)
						&& IsOffCooldown(Variant.VariantUltimatum))
					{
						return Variant.VariantUltimatum;
					}

					if (IsEnabled(CustomComboPreset.DRK_ST_ManaOvercap)
						&& ((CombatEngageDuration().TotalSeconds > 4 && CombatEngageDuration().TotalSeconds < 10 && gauge.DarksideTimeRemaining == 0)
							|| CombatEngageDuration().TotalSeconds >= 10))
					{
						if (IsEnabled(CustomComboPreset.DRK_ST_ManaSpenderPooling)
							&& GetCooldownRemainingTime(LivingShadow) >= 45
							&& LocalPlayer.CurrentMp > (mpRemaining + 3000)
							&& ActionReady(EdgeOfDarkness)
							&& CanDelayedWeave(actionID))
						{
							return OriginalHook(EdgeOfDarkness);
						}

						if (LocalPlayer.CurrentMp > 8500
							|| (gauge.DarksideTimeRemaining < 10000 && LocalPlayer.CurrentMp > (mpRemaining + 3000)))
						{
							if (ActionReady(EdgeOfDarkness))
							{
								return OriginalHook(EdgeOfDarkness);
							}

							if (ActionReady(FloodOfDarkness)
								&& !ActionReady(EdgeOfDarkness))
							{
								return FloodOfDarkness;
							}
						}
					}

					if (gauge.DarksideTimeRemaining > 1)
					{
						if (IsEnabled(CustomComboPreset.DRK_ST_CDs)
							&& IsEnabled(CustomComboPreset.DRK_ST_CDs_LivingShadow)
							&& IsOffCooldown(LivingShadow)
							&& ActionReady(LivingShadow)
							&& GetTargetHPPercent() > hpRemaining)
						{
							return LivingShadow;
						}

						if (IsEnabled(CustomComboPreset.DRK_ST_Delirium)
							&& IsOffCooldown(BloodWeapon)
							&& ActionReady(BloodWeapon))
						{
							return OriginalHook(Delirium);
						}

						if (IsEnabled(CustomComboPreset.DRK_ST_CDs))
						{
							if (IsEnabled(CustomComboPreset.DRK_ST_CDs_SaltedEarth))
							{
								if (!HasEffect(Buffs.SaltedEarth)
									&& ActionReady(SaltedEarth))
								{
									return SaltedEarth;
								}

								if (HasEffect(Buffs.SaltedEarth)
								 && GetBuffRemainingTime(Buffs.SaltedEarth) < 9
								 && ActionReady(SaltAndDarkness))
								{
									return OriginalHook(SaltAndDarkness);
								}
							}

							if (ActionReady(Shadowbringer)
								&& IsEnabled(CustomComboPreset.DRK_ST_CDs_Shadowbringer))
							{
								if ((GetRemainingCharges(Shadowbringer) > 0 && IsNotEnabled(CustomComboPreset.DRK_ST_CDs_ShadowbringerBurst)) ||
									(IsEnabled(CustomComboPreset.DRK_ST_CDs_ShadowbringerBurst) && GetRemainingCharges(Shadowbringer) > 0 && gauge.ShadowTimeRemaining > 1 && IsOnCooldown(Delirium)))
								{
									return Shadowbringer;
								}
							}

							if (IsEnabled(CustomComboPreset.DRK_ST_CDs_CarveAndSpit)
								&& IsOffCooldown(CarveAndSpit)
								&& ActionReady(CarveAndSpit))
							{
								return CarveAndSpit;
							}
						}
					}
				}

				if (ActionReady(Delirium)
					&& ActionReady(ScarletDelirium)
					&& IsEnabled(CustomComboPreset.DRK_ST_Delirium_Chain)
					&& HasEffect(Buffs.Delirium)
					&& gauge.DarksideTimeRemaining > 0)
				{
					return OriginalHook(Bloodspiller);
				}

				if (ActionReady(Delirium))
				{
					if (GetBuffStacks(Buffs.Delirium) > 0)
					{
						return Bloodspiller;
					}

					if (IsEnabled(CustomComboPreset.DRK_ST_Delirium)
						&& (
							(gauge.Blood >= 60 && GetCooldownRemainingTime(Delirium) is > 0 and < 3)
							|| (gauge.Blood >= 50 && GetCooldownRemainingTime(Delirium) > 37)
							))
					{
						return Bloodspiller;
					}
				}

				return IsEnabled(CustomComboPreset.DRK_ST_ManaOvercap)
					&& (CanWeave(actionID) || CanDelayedWeave(actionID))
					&& gauge.HasDarkArts
					&& ActionReady(EdgeOfDarkness)
					&& CombatEngageDuration().TotalSeconds >= 25
					? OriginalHook(EdgeOfDarkness)
					: !(comboTime > 0)
					? HardSlash
					: lastComboMove == HardSlash && ActionReady(SyphonStrike)
					? SyphonStrike
					: lastComboMove == SyphonStrike && ActionReady(Souleater)
					? IsEnabled(CustomComboPreset.DRK_ST_BloodOvercap)
						&& ActionReady(Bloodspiller) && gauge.Blood >= 90
						? Bloodspiller
						: Souleater
					: HardSlash;
			}
		}

		internal class DRK_StalwartSoul_Combo : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.DRK_AoE_Combo;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID != StalwartSoul)
				{
					return actionID;
				}

				DRKGauge gauge = GetJobGauge<DRKGauge>();
				int hpRemaining = PluginConfiguration.GetCustomIntValue(Config.DRK_AoE_LivingDeadThreshold);

				if (IsEnabled(CustomComboPreset.DRK_Variant_Cure)
					&& IsEnabled(Variant.VariantCure)
					&& PlayerHealthPercentageHp() <= GetOptionValue(Config.DRK_VariantCure))
				{
					return Variant.VariantCure;
				}

				if (ActionReady(LivingShadow)
					&& ActionReady(Disesteem)
					&& IsEnabled(CustomComboPreset.DRK_AoE_CDs_Disesteem)
					&& HasEffect(Buffs.Scorn)
					&& (gauge.DarksideTimeRemaining > 0
						|| GetBuffRemainingTime(Buffs.Scorn) < 5))
				{
					return OriginalHook(Disesteem);
				}

				if (CanWeave(actionID))
				{
					Dalamud.Game.ClientState.Statuses.Status? sustainedDamage = FindTargetEffect(Variant.Debuffs.SustainedDamage);
					if (IsEnabled(CustomComboPreset.DRK_Variant_SpiritDart)
						&& IsEnabled(Variant.VariantSpiritDart)
						&& (sustainedDamage is null || sustainedDamage?.RemainingTime <= 3))
					{
						return Variant.VariantSpiritDart;
					}

					if (IsEnabled(CustomComboPreset.DRK_Variant_Ultimatum)
						&& IsEnabled(Variant.VariantUltimatum)
						&& IsOffCooldown(Variant.VariantUltimatum))
					{
						return Variant.VariantUltimatum;
					}

					if (IsEnabled(CustomComboPreset.DRK_AoE_ManaOvercap)
						&& ActionReady(FloodOfDarkness)
						&& (LocalPlayer.CurrentMp > 8500 || (gauge.DarksideTimeRemaining < 10 && LocalPlayer.CurrentMp >= 3000)))
					{
						return OriginalHook(FloodOfDarkness);
					}

					if (IsEnabled(CustomComboPreset.DRK_AoE_CDs_LivingShadow)
						&& IsOffCooldown(LivingShadow)
						&& ActionReady(LivingShadow)
						&& GetTargetHPPercent() > hpRemaining)
					{
						return LivingShadow;
					}

					if (IsEnabled(CustomComboPreset.DRK_AoE_Delirium)
						&& IsOffCooldown(BloodWeapon)
						&& ActionReady(BloodWeapon))
					{
						return OriginalHook(Delirium);
					}

					if (gauge.DarksideTimeRemaining > 1)
					{
						if (IsEnabled(CustomComboPreset.DRK_AoE_CDs_SaltedEarth))
						{
							if (!HasEffect(Buffs.SaltedEarth)
								&& ActionReady(SaltedEarth))
							{
								return SaltedEarth;
							}

							if (HasEffect(Buffs.SaltedEarth)
								&& GetBuffRemainingTime(Buffs.SaltedEarth) < 9
								&& ActionReady(SaltAndDarkness))
							{
								return OriginalHook(SaltAndDarkness);
							}
						}

						if (IsEnabled(CustomComboPreset.DRK_AoE_CDs_Shadowbringer)
							&& ActionReady(Shadowbringer)
							&& GetRemainingCharges(Shadowbringer) > 0)
						{
							return Shadowbringer;
						}

						if (IsEnabled(CustomComboPreset.DRK_AoE_CDs_AbyssalDrain)
							&& ActionReady(AbyssalDrain)
							&& IsOffCooldown(AbyssalDrain)
							&& PlayerHealthPercentageHp() <= 60)
						{
							return AbyssalDrain;
						}
					}
				}

				return ActionReady(Delirium)
					&& ActionReady(Impalement)
					&& IsEnabled(CustomComboPreset.DRK_AoE_Delirium_Chain)
					&& HasEffect(Buffs.Delirium)
					&& gauge.DarksideTimeRemaining > 1
					? OriginalHook(Quietus)
					: IsEnabled(CustomComboPreset.DRK_AoE_ManaOvercap)
					&& (CanWeave(actionID) || CanDelayedWeave(actionID))
					&& gauge.HasDarkArts
					&& ActionReady(FloodOfDarkness)
					? OriginalHook(FloodOfDarkness)
					: !(comboTime > 0)
					? Unleash
					: lastComboMove == Unleash && ActionReady(StalwartSoul)
					? IsEnabled(CustomComboPreset.DRK_AoE_BloodOvercap)
						&& gauge.Blood >= 90
						&& ActionReady(Quietus)
						? Quietus
						: StalwartSoul
					: Unleash;
			}
		}
	}
}