using Dalamud.Game.ClientState.JobGauge.Types;
using Dalamud.Game.ClientState.Statuses;
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

		public static class Config
		{
			public const string
				GNB_VariantCure = "GNB_VariantCure";
		}

		internal class GNB_ST_MainCombo : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.GNB_ST_MainCombo;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID is KeenEdge)
				{
					GNBGauge gauge = GetJobGauge<GNBGauge>();
					_ = GetCooldownRemainingTime(actionID) is < 1 and > (float)0.6;
					float GCD = GetCooldown(KeenEdge).CooldownTotal;

					if (IsEnabled(CustomComboPreset.GNB_Variant_Cure) && IsEnabled(Variant.VariantCure) && PlayerHealthPercentageHp() <= GetOptionValue(Config.GNB_VariantCure))
					{
						return Variant.VariantCure;
					}

					if (CanWeave(actionID))
					{
						Status? sustainedDamage = FindTargetEffect(Variant.Debuffs.SustainedDamage);
						if (IsEnabled(CustomComboPreset.GNB_Variant_SpiritDart) &&
							IsEnabled(Variant.VariantSpiritDart) &&
							(sustainedDamage is null || sustainedDamage?.RemainingTime <= 3))
						{
							return Variant.VariantSpiritDart;
						}

						if (IsEnabled(CustomComboPreset.GNB_Variant_Ultimatum) && IsEnabled(Variant.VariantUltimatum) && IsOffCooldown(Variant.VariantUltimatum))
						{
							return Variant.VariantUltimatum;
						}
					}

					if (LevelChecked(Continuation) && (HasEffect(Buffs.ReadyToRip) || HasEffect(Buffs.ReadyToTear) || HasEffect(Buffs.ReadyToGouge)
						|| (HasEffect(Buffs.ReadyToBlast) && LevelChecked(Hypervelocity))))
					{
						return OriginalHook(Continuation);
					}

					/*if (IsEnabled(CustomComboPreset.GNB_ST_Reign) && LevelChecked(ReignOfBeasts))
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

					if (gauge.Ammo == MaxCartridges(level) && GetCooldownRemainingTime(GnashingFang) > GCD * 3 && lastComboMove == BrutalShell)
					{
						return BurstStrike;
					}

					if ((gauge.Ammo >= 1 && GetCooldownRemainingTime(GnashingFang) < 1.5) || gauge.AmmoComboStep == 1 || gauge.AmmoComboStep == 2)
					{
						return OriginalHook(GnashingFang);
					}

					if (comboTime > 0)
					{
						if (lastComboMove == KeenEdge && LevelChecked(BrutalShell))
						{
							return BrutalShell;
						}

						if (lastComboMove == BrutalShell && LevelChecked(SolidBarrel))
						{
							return SolidBarrel;
						}
					}
					return KeenEdge;
				}
				return actionID;
			}
		}

		internal class GNB_AoE_MainCombo : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.GNB_AoE_MainCombo;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{

				if (actionID == DemonSlice)
				{
					GNBGauge gauge = GetJobGauge<GNBGauge>();

					if (IsEnabled(CustomComboPreset.GNB_Variant_Cure) && IsEnabled(Variant.VariantCure) && PlayerHealthPercentageHp() <= GetOptionValue(Config.GNB_VariantCure))
					{
						return Variant.VariantCure;
					}

					if (InCombat())
					{
						if (CanWeave(actionID))
						{
							Status? sustainedDamage = FindTargetEffect(Variant.Debuffs.SustainedDamage);
							if (IsEnabled(CustomComboPreset.GNB_Variant_SpiritDart) &&
								IsEnabled(Variant.VariantSpiritDart) &&
								(sustainedDamage is null || sustainedDamage?.RemainingTime <= 3))
							{
								return Variant.VariantSpiritDart;
							}

							if (IsEnabled(CustomComboPreset.GNB_Variant_Ultimatum) && IsEnabled(Variant.VariantUltimatum) && IsOffCooldown(Variant.VariantUltimatum))
							{
								return Variant.VariantUltimatum;
							}
						}
					}

					return comboTime > 0 && lastComboMove == DemonSlice && LevelChecked(DemonSlaughter)
						? IsEnabled(CustomComboPreset.GNB_AOE_Overcap) && LevelChecked(FatedCircle) && gauge.Ammo == MaxCartridges(level) ? FatedCircle : DemonSlaughter
						: DemonSlice;
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