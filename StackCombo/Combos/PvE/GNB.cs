using Dalamud.Game.ClientState.JobGauge.Types;
using StackCombo.ComboHelper.Functions;
using StackCombo.Combos.PvE.Content;
using StackCombo.CustomCombo;

namespace StackCombo.Combos.PvE
{
	internal static class GNB
	{
		public const byte JobID = 37;

		public static int MaxCartridges(byte level)
		{
			return level >= 88 ? 3 : 2;
		}

		public const uint
			KeenEdge = 16137,
			NoMercy = 16138,
			BrutalShell = 16139,
			DemonSlice = 16141,
			SolidBarrel = 16145,
			GnashingFang = 16146,
			SavageClaw = 16147,
			DemonSlaughter = 16149,
			WickedTalon = 16150,
			Superbolide = 16152,
			SonicBreak = 16153,
			Continuation = 16155,
			JugularRip = 16156,
			AbdomenTear = 16157,
			EyeGouge = 16158,
			BowShock = 16159,
			HeartOfLight = 16160,
			BurstStrike = 16162,
			FatedCircle = 16163,
			Aurora = 16151,
			DoubleDown = 25760,
			DangerZone = 16144,
			BlastingZone = 16165,
			Bloodfest = 16164,
			Hypervelocity = 25759,
			LionHeart = 36939,
			NobleBlood = 36938,
			ReignOfBeasts = 36937,
			FatedBrand = 36936,
			LightningShot = 16143;

		public static class Buffs
		{
			public const ushort
				NoMercy = 1831,
				Aurora = 1835,
				ReadyToRip = 1842,
				ReadyToTear = 1843,
				ReadyToGouge = 1844,
				ReadyToRaze = 3839,
				ReadyToBreak = 3886,
				ReadyToReign = 3840,
				ReadyToBlast = 2686;
		}

		public static class Debuffs
		{
			public const ushort
				BowShock = 1838,
				SonicBreak = 1837;
		}

		private static GNBGauge Gauge
		{
			get
			{
				return CustomComboFunctions.GetJobGauge<GNBGauge>();
			}
		}

		public static class Config
		{
			public static UserInt
				GNB_VariantCure = new("GNB_VariantCure", 50);
		}

		internal class GNB_ST_DPS : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.GNB_ST_DPS;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID is KeenEdge or BrutalShell or SolidBarrel && IsEnabled(CustomComboPreset.GNB_ST_DPS))
				{
					if (IsEnabled(CustomComboPreset.GNB_Variant_Cure) && IsEnabled(Variant.VariantCure)
						&& PlayerHealthPercentageHp() <= Config.GNB_VariantCure)
					{
						return Variant.VariantCure;
					}

					if (IsEnabled(CustomComboPreset.GNB_Variant_SpiritDart) && IsEnabled(Variant.VariantSpiritDart)
						&& (!TargetHasEffectAny(Variant.Debuffs.SustainedDamage) || GetDebuffRemainingTime(Variant.Debuffs.SustainedDamage) <= 3))
					{
						return Variant.VariantSpiritDart;
					}

					if (IsEnabled(CustomComboPreset.GNB_Variant_Ultimatum) && IsEnabled(Variant.VariantUltimatum) && IsOffCooldown(Variant.VariantUltimatum))
					{
						return Variant.VariantUltimatum;
					}

					if (IsEnabled(CustomComboPreset.GNB_ST_Invuln) && PlayerHealthPercentageHp() <= 10)
					{
						return Superbolide;
					}

					if (ActionReady(Continuation)
						&& (HasEffect(Buffs.ReadyToRip) || HasEffect(Buffs.ReadyToTear) || HasEffect(Buffs.ReadyToGouge) || HasEffect(Buffs.ReadyToBlast)))
					{
						return OriginalHook(Continuation);
					}

					/*if (IsEnabled(CustomComboPreset.GNB_ST_Reign) && ActionReady(ReignOfBeasts))
					{
						if (GetBuffRemainingTime(Buffs.ReadyToReign) > 0 && IsOnCooldown(GnashingFang) && IsOnCooldown(DoubleDown) && gauge.AmmoComboStep == 0 && GetCooldownRemainingTime(Bloodfest) > GCD * 12)
						{
							if (WasLastWeaponskill(WickedTalon) || WasLastAbility(EyeGouge))
							{
								return OriginalHook(ReignOfBeasts);
							}
						}

						if (WasLastWeaponskill(ReignOfBeasts) || WasLastWeaponskill(NobleBlood))
						{
							return OriginalHook(ReignOfBeasts);
						}
					}*/

					if ((Gauge.Ammo > 0 && ActionReady(OriginalHook(GnashingFang)) && IsEnabled(CustomComboPreset.GNB_ST_Gnashing)
						&& GetCooldownRemainingTime(GnashingFang) < 1.5)
						|| Gauge.AmmoComboStep == 1
						|| Gauge.AmmoComboStep == 2)
					{
						return OriginalHook(GnashingFang);
					}

					if ((ActionReady(BurstStrike) && IsEnabled(CustomComboPreset.GNB_ST_Burst)
						&& Gauge.Ammo == MaxCartridges(level) && lastComboMove == BrutalShell)
						|| (HasEffect(Buffs.NoMercy) && Gauge.Ammo > 0
						&& (GetCooldownRemainingTime(OriginalHook(GnashingFang)) > 5 || !ActionReady(GnashingFang))
						&& (GetCooldownRemainingTime(DoubleDown) > 10 || !ActionReady(DoubleDown))))
					{
						return BurstStrike;
					}

					if (comboTime > 0)
					{
						if (lastComboMove == KeenEdge && ActionReady(BrutalShell))
						{
							return BrutalShell;
						}

						if (lastComboMove == BrutalShell && ActionReady(SolidBarrel))
						{
							return SolidBarrel;
						}
					}
					return KeenEdge;
				}
				return actionID;
			}
		}

		internal class GNB_AoE_DPS : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.GNB_AoE_DPS;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID is DemonSlice or DemonSlaughter && IsEnabled(CustomComboPreset.GNB_AoE_DPS))
				{
					if (IsEnabled(CustomComboPreset.GNB_Variant_Cure) && IsEnabled(Variant.VariantCure)
						&& PlayerHealthPercentageHp() <= Config.GNB_VariantCure)
					{
						return Variant.VariantCure;
					}

					if (IsEnabled(CustomComboPreset.GNB_Variant_SpiritDart) && IsEnabled(Variant.VariantSpiritDart)
						&& (!TargetHasEffectAny(Variant.Debuffs.SustainedDamage) || GetDebuffRemainingTime(Variant.Debuffs.SustainedDamage) <= 3))
					{
						return Variant.VariantSpiritDart;
					}

					if (IsEnabled(CustomComboPreset.GNB_Variant_Ultimatum) && IsEnabled(Variant.VariantUltimatum) && IsOffCooldown(Variant.VariantUltimatum))
					{
						return Variant.VariantUltimatum;
					}

					if (IsEnabled(CustomComboPreset.GNB_AoE_Invuln) && PlayerHealthPercentageHp() <= 10)
					{
						return Superbolide;
					}

					if (IsEnabled(CustomComboPreset.GNB_AoE_Fated) && ActionReady(FatedCircle) && LevelChecked(DoubleDown)
						&& GetCooldownRemainingTime(DoubleDown) > 10 && IsEnabled(CustomComboPreset.GNB_AoE_Fated)
						&& ((Gauge.Ammo == MaxCartridges(level) && lastComboMove is DemonSlice) || (HasEffect(Buffs.NoMercy) && Gauge.Ammo > 0)))
					{
						return FatedCircle;
					}

					if (comboTime > 0 && lastComboMove is DemonSlice && ActionReady(DemonSlaughter))
					{
						return DemonSlaughter;
					}
				}
				return actionID;
			}
		}

		internal class GNB_AuroraProtection : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.GNB_AuroraProtection;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID is Aurora)
				{
					if ((HasFriendlyTarget() && TargetHasEffectAny(Buffs.Aurora)) || (!HasFriendlyTarget() && HasEffectAny(Buffs.Aurora)))
					{
						return OriginalHook(11);
					}
				}
				return actionID;
			}
		}
	}
}