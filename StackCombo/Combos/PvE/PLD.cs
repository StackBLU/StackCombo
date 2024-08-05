using Dalamud.Game.ClientState.JobGauge.Types;
using StackCombo.ComboHelper.Functions;
using StackCombo.Combos.PvE.Content;
using StackCombo.CustomCombo;

namespace StackCombo.Combos.PvE
{
	internal static class PLD
	{
		public const byte JobID = 19;

		public const uint
			FastBlade = 9,
			RiotBlade = 15,
			ShieldBash = 16,
			RageOfHalone = 21,
			CircleOfScorn = 23,
			ShieldLob = 24,
			SpiritsWithin = 29,
			HallowedGround = 30,
			GoringBlade = 3538,
			RoyalAuthority = 3539,
			TotalEclipse = 7381,
			Requiescat = 7383,
			Imperator = 36921,
			HolySpirit = 7384,
			Prominence = 16457,
			HolyCircle = 16458,
			Confiteor = 16459,
			Expiacion = 25747,
			BladeOfFaith = 25748,
			BladeOfTruth = 25749,
			BladeOfValor = 25750,
			FightOrFlight = 20,
			Atonement = 16460,
			Intervene = 16461,
			BladeOfHonor = 36922,
			Sheltron = 3542;

		public static class Buffs
		{
			public const ushort
				Requiescat = 1368,
				AtonementReady = 1902,
				SupplicationReady = 3827,
				SepulchreReady = 3828,
				GoringBladeReady = 3847,
				BladeOfHonor = 3831,
				FightOrFlight = 76,
				ConfiteorReady = 3019,
				DivineMight = 2673,
				HolySheltron = 2674,
				Sheltron = 1856;
		}

		public static class Debuffs
		{
			public const ushort
				BladeOfValor = 2721,
				GoringBlade = 725;
		}

		private static PLDGauge Gauge
		{
			get
			{
				return CustomComboFunctions.GetJobGauge<PLDGauge>();
			}
		}

		public static class Config
		{
			public static UserInt
				PLD_VariantCure = new("PLD_VariantCure", 50),
				PLD_ST_SheltronOption = new("PLD_ST_SheltronOption", 50),
				PLD_AoE_SheltronOption = new("PLD_AoE_SheltronOption", 50);
		}

		internal class PLD_ST_DPS : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.PLD_ST_DPS;

			protected override uint Invoke(uint actionID, uint lastComboActionID, float comboTime, byte level)
			{
				if (actionID is FastBlade or RiotBlade or RageOfHalone or RoyalAuthority && IsEnabled(CustomComboPreset.PLD_ST_DPS))
				{
					if (IsEnabled(CustomComboPreset.PLD_Variant_Cure) && IsEnabled(Variant.VariantCure) &&
						PlayerHealthPercentageHp() <= Config.PLD_VariantCure)
					{
						return Variant.VariantCure;
					}
					if (IsEnabled(CustomComboPreset.PLD_Variant_SpiritDart) && IsEnabled(Variant.VariantSpiritDart)
						&& (!TargetHasEffectAny(Variant.Debuffs.SustainedDamage) || GetDebuffRemainingTime(Variant.Debuffs.SustainedDamage) <= 3))
					{
						return Variant.VariantSpiritDart;
					}

					if (IsEnabled(CustomComboPreset.PLD_Variant_Ultimatum) && IsEnabled(Variant.VariantUltimatum) &&
						IsOffCooldown(Variant.VariantUltimatum))
					{
						return Variant.VariantUltimatum;
					}

					if (IsEnabled(CustomComboPreset.PLD_ST_Invuln) && PlayerHealthPercentageHp() <= 10)
					{
						return HallowedGround;
					}

					if (CanWeave(actionID))
					{
						if (IsEnabled(CustomComboPreset.PLD_ST_SpiritsWithin) && ActionReady(SpiritsWithin) && InMeleeRange())
						{
							return OriginalHook(Expiacion);
						}

						if (IsEnabled(CustomComboPreset.PLD_ST_CircleOfScorn) && ActionReady(CircleOfScorn) && InMeleeRange())
						{
							return CircleOfScorn;
						}

						if (IsEnabled(CustomComboPreset.PLD_ST_Sheltron) && CanWeave(actionID) &&
							ActionReady(Sheltron) && !HasEffect(Buffs.Sheltron) && !HasEffect(Buffs.HolySheltron) &&
							Gauge.OathGauge >= Config.PLD_ST_SheltronOption)
						{
							return OriginalHook(Sheltron);
						}
					}

					if (IsEnabled(CustomComboPreset.PLD_ST_Atonement) && ActionReady(OriginalHook(Atonement))
						&& (HasEffect(Buffs.AtonementReady) || HasEffect(Buffs.SupplicationReady) || HasEffect(Buffs.SepulchreReady)))
					{
						return OriginalHook(Atonement);
					}

					if (IsEnabled(CustomComboPreset.PLD_ST_HolySpirit) && ActionReady(HolySpirit)
						&& (HasEffect(Buffs.DivineMight) || (HasEffect(Buffs.Requiescat) && !LevelChecked(BladeOfFaith)))
						&& LocalPlayer.CurrentMp >= GetResourceCost(HolySpirit))
					{
						return HolySpirit;
					}

					if (comboTime > 0)
					{
						if (lastComboActionID is FastBlade && ActionReady(RiotBlade))
						{
							return RiotBlade;
						}

						if (lastComboActionID is RiotBlade && ActionReady(OriginalHook(RoyalAuthority)))
						{
							return OriginalHook(RoyalAuthority);
						}
					}
					return FastBlade;
				}
				return actionID;
			}
		}

		internal class PLD_AoE_DPS : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.PLD_AoE_DPS;

			protected override uint Invoke(uint actionID, uint lastComboActionID, float comboTime, byte level)
			{
				if (actionID is TotalEclipse or Prominence && IsEnabled(CustomComboPreset.PLD_AoE_DPS))
				{
					if (IsEnabled(CustomComboPreset.PLD_Variant_Cure) && IsEnabled(Variant.VariantCure)
						&& PlayerHealthPercentageHp() <= Config.PLD_VariantCure)
					{
						return Variant.VariantCure;
					}

					if (IsEnabled(CustomComboPreset.PLD_Variant_SpiritDart) && IsEnabled(Variant.VariantSpiritDart)
						&& (!TargetHasEffectAny(Variant.Debuffs.SustainedDamage) || GetDebuffRemainingTime(Variant.Debuffs.SustainedDamage) <= 3))
					{
						return Variant.VariantSpiritDart;
					}

					if (IsEnabled(CustomComboPreset.PLD_Variant_Ultimatum) && IsEnabled(Variant.VariantUltimatum) && IsOffCooldown(Variant.VariantUltimatum))
					{
						return Variant.VariantUltimatum;
					}

					if (IsEnabled(CustomComboPreset.PLD_AoE_Invuln) && PlayerHealthPercentageHp() <= 10)
					{
						return HallowedGround;
					}

					if (ActionReady(SpiritsWithin) && IsEnabled(CustomComboPreset.PLD_AoE_SpiritsWithin) && CanWeave(actionID))
					{
						return OriginalHook(Expiacion);
					}

					if (ActionReady(CircleOfScorn) && IsEnabled(CustomComboPreset.PLD_AoE_CircleOfScorn) && CanWeave(actionID))
					{
						return CircleOfScorn;
					}

					if (IsEnabled(CustomComboPreset.PLD_AoE_Sheltron) && CanWeave(actionID) &&
						ActionReady(Sheltron) && !HasEffect(Buffs.Sheltron) && !HasEffect(Buffs.HolySheltron) &&
						Gauge.OathGauge >= Config.PLD_AoE_SheltronOption)
					{
						return OriginalHook(Sheltron);
					}

					if (IsEnabled(CustomComboPreset.PLD_AoE_HolyCircle) && ActionReady(HolyCircle)
						&& LocalPlayer.CurrentMp >= GetResourceCost(HolyCircle)
						&& (HasEffect(Buffs.DivineMight) || (HasEffect(Buffs.Requiescat) && !LevelChecked(BladeOfFaith))))
					{
						return HolyCircle;
					}

					if (comboTime > 0 && WasLastWeaponskill(TotalEclipse) && ActionReady(Prominence))
					{
						return Prominence;
					}
				}
				return actionID;
			}
		}

		internal class PLD_Blades : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.PLD_Blades;

			protected override uint Invoke(uint actionID, uint lastComboActionID, float comboTime, byte level)
			{
				if (actionID is Requiescat or Imperator && IsEnabled(CustomComboPreset.PLD_Blades))
				{
					if (ActionReady(OriginalHook(Confiteor)) && HasEffect(Buffs.Requiescat))
					{
						return OriginalHook(Confiteor);
					}
					if (ActionReady(OriginalHook(Imperator)))
					{
						return OriginalHook(Imperator);
					}
				}
				return actionID;
			}
		}

		internal class PLD_ExpiScorn : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.PLD_ExpiScorn;

			protected override uint Invoke(uint actionID, uint lastComboActionID, float comboTime, byte level)
			{
				if (actionID is SpiritsWithin or Expiacion or CircleOfScorn && IsEnabled(CustomComboPreset.PLD_ExpiScorn))
				{
					if (ActionReady(OriginalHook(Expiacion)))
					{
						return Expiacion;
					}
					if (ActionReady(CircleOfScorn))
					{
						return CircleOfScorn;
					}
				}
				return actionID;
			}
		}
	}
}