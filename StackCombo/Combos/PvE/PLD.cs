using Dalamud.Game.ClientState.JobGauge.Types;
using Dalamud.Game.ClientState.Statuses;
using StackCombo.ComboHelper.Functions;
using StackCombo.Combos.PvE.Content;
using StackCombo.CustomCombo;
using StackCombo.Data;
using StackCombo.Extensions;
using System.Linq;

namespace StackCombo.Combos.PvE
{
	internal static class PLD
	{
		public const byte JobID = 19;

		public const float CooldownThreshold = 0.5f;

		public const uint
			FastBlade = 9,
			RiotBlade = 15,
			ShieldBash = 16,
			RageOfHalone = 21,
			CircleOfScorn = 23,
			ShieldLob = 24,
			SpiritsWithin = 29,
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
				PLD_ST_FoF_Option = new("PLD_ST_FoF_Option", 50),
				PLD_AoE_FoF_Option = new("PLD_AoE_FoF_Option", 50),
				PLD_Intervene_HoldCharges = new("PLDKeepInterveneCharges", 1),
				PLD_VariantCure = new("PLD_VariantCure"),
				PLD_ST_SheltronOption = new("PLD_ST_SheltronOption", 50),
				PLD_AoE_SheltronOption = new("PLD_AoE_SheltronOption", 50),
				PLD_ST_SheltronHP = new("PLD_ST_SheltronHP", 70),
				PLD_AoE_SheltronHP = new("PLD_AoE_SheltronHP", 70),
				PLD_Intervene_MeleeOnly = new("PLD_Intervene_MeleeOnly", 1);
		}

		internal class PLD_ST_AdvancedMode : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.PLD_ST_AdvancedMode;
			internal static int RoyalAuthorityCount
			{
				get
				{
					return ActionWatching.CombatActions.Count(x => x == OriginalHook(RageOfHalone));
				}
			}

			protected override uint Invoke(uint actionID, uint lastComboActionID, float comboTime, byte level)
			{
				if (actionID is FastBlade)
				{
					bool hasDivineMight = HasEffect(Buffs.DivineMight);
					bool inAtonementStarter = HasEffect(Buffs.AtonementReady);
					bool inAtonementFinisher = HasEffect(Buffs.SepulchreReady);
					bool inBurstPhase = ActionReady(BladeOfFaith) && RoyalAuthorityCount > 0;
					bool inAtonementPhase = HasEffect(Buffs.AtonementReady) || HasEffect(Buffs.SupplicationReady) || HasEffect(Buffs.SepulchreReady);
					bool isAtonementExpiring = (HasEffect(Buffs.AtonementReady) && GetBuffRemainingTime(Buffs.AtonementReady) < 10) ||
												(HasEffect(Buffs.SupplicationReady) && GetBuffRemainingTime(Buffs.SupplicationReady) < 10) ||
												(HasEffect(Buffs.SepulchreReady) && GetBuffRemainingTime(Buffs.SepulchreReady) < 10);

					if (IsEnabled(CustomComboPreset.PLD_Variant_Cure) && IsEnabled(Variant.VariantCure) &&
						PlayerHealthPercentageHp() <= Config.PLD_VariantCure)
					{
						return Variant.VariantCure;
					}

					if (HasBattleTarget())
					{
						if (InMeleeRange())
						{
							if (CanWeave(actionID))
							{
								Status? sustainedDamage = FindTargetEffect(Variant.Debuffs.SustainedDamage);

								if (IsEnabled(CustomComboPreset.PLD_Variant_SpiritDart) && IsEnabled(Variant.VariantSpiritDart) &&
									(sustainedDamage is null || sustainedDamage?.RemainingTime <= 3))
								{
									return Variant.VariantSpiritDart;
								}

								if (IsEnabled(CustomComboPreset.PLD_Variant_Ultimatum) && IsEnabled(Variant.VariantUltimatum) &&
									IsOffCooldown(Variant.VariantUltimatum))
								{
									return Variant.VariantUltimatum;
								}
							}
						}

						if (HasEffect(Buffs.FightOrFlight))
						{
							if (CanWeave(actionID))
							{
								if (InMeleeRange())
								{
									if (IsEnabled(CustomComboPreset.PLD_ST_AdvancedMode_CircleOfScorn) && ActionReady(CircleOfScorn))
									{
										return CircleOfScorn;
									}

									if (IsEnabled(CustomComboPreset.PLD_ST_AdvancedMode_SpiritsWithin) && ActionReady(SpiritsWithin))
									{
										return OriginalHook(SpiritsWithin);
									}
								}

								if (IsEnabled(CustomComboPreset.PLD_ST_AdvancedMode_Intervene) &&
									ActionReady(Intervene) && GetRemainingCharges(Intervene) > Config.PLD_Intervene_HoldCharges && !IsMoving && !WasLastAction(Intervene) &&
									GetTargetDistance() == 0 && Config.PLD_Intervene_MeleeOnly == 2)
								{
									return Intervene;
								}
							}

							if (HasEffect(Buffs.Requiescat))
							{
								if (IsEnabled(CustomComboPreset.PLD_ST_AdvancedMode_HolySpirit) && GetResourceCost(HolySpirit) <= LocalPlayer.CurrentMp)
								{
									return HolySpirit;
								}
							}
						}

						if (CanWeave(actionID) && InMeleeRange())
						{
							if (IsEnabled(CustomComboPreset.PLD_ST_AdvancedMode_FoF) && ActionReady(FightOrFlight) && GetTargetHPPercent() >= Config.PLD_ST_FoF_Option)
							{
								if (!ActionReady(Requiescat))
								{
									if (!ActionReady(RageOfHalone))
									{
										if (lastComboActionID is FastBlade)
										{
											return FightOrFlight;
										}
									}

									else if (lastComboActionID is RiotBlade)
									{
										return FightOrFlight;
									}
								}

								else if (GetCooldownRemainingTime(Requiescat) < 0.5f && CanWeave(actionID, 1.5f) && (lastComboActionID is RoyalAuthority || inBurstPhase))
								{
									return FightOrFlight;
								}
							}

							if (GetCooldownRemainingTime(FightOrFlight) > 15)
							{
								if (IsEnabled(CustomComboPreset.PLD_ST_AdvancedMode_CircleOfScorn) && ActionReady(CircleOfScorn))
								{
									return CircleOfScorn;
								}

								if (IsEnabled(CustomComboPreset.PLD_ST_AdvancedMode_SpiritsWithin) && ActionReady(SpiritsWithin))
								{
									return OriginalHook(SpiritsWithin);
								}
							}
						}

						if (IsEnabled(CustomComboPreset.PLD_ST_AdvancedMode_Sheltron) && InCombat() && CanWeave(actionID) &&
							ActionReady(Sheltron) && !HasEffect(Buffs.Sheltron) && !HasEffect(Buffs.HolySheltron) &&
							Gauge.OathGauge >= Config.PLD_ST_SheltronOption)
						{
							return OriginalHook(Sheltron);
						}

						if (IsEnabled(CustomComboPreset.PLD_ST_AdvancedMode_HolySpirit) && hasDivineMight && GetResourceCost(HolySpirit) <= LocalPlayer.CurrentMp)
						{
							if (inAtonementFinisher && (GetCooldownRemainingTime(FightOrFlight) < 6 || GetBuffRemainingTime(Buffs.FightOrFlight) > 3))
							{
								return HolySpirit;
							}

							if (!inAtonementFinisher && HasEffect(Buffs.FightOrFlight) && GetBuffRemainingTime(Buffs.FightOrFlight) < 3)
							{
								return HolySpirit;
							}
						}

						if (IsEnabled(CustomComboPreset.PLD_ST_AdvancedMode_Atonement) &&
							inAtonementPhase && InMeleeRange() && (JustUsed(FightOrFlight, 30f) || isAtonementExpiring || lastComboActionID is RiotBlade || inAtonementStarter))
						{
							return OriginalHook(Atonement);
						}

						if (IsEnabled(CustomComboPreset.PLD_ST_AdvancedMode_HolySpirit) &&
							hasDivineMight && GetResourceCost(HolySpirit) <= LocalPlayer.CurrentMp && (JustUsed(FightOrFlight, 30f) ||
							!InMeleeRange() || GetBuffRemainingTime(Buffs.DivineMight) < 10 || lastComboActionID is RiotBlade))
						{
							return HolySpirit;
						}

						if (comboTime > 0)
						{
							if (lastComboActionID is FastBlade && ActionReady(RiotBlade))
							{
								return RiotBlade;
							}

							if (lastComboActionID is RiotBlade && ActionReady(RageOfHalone))
							{
								return OriginalHook(RageOfHalone);
							}
						}
					}
				}
				return actionID;
			}
		}

		internal class PLD_AoE_AdvancedMode : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.PLD_AoE_AdvancedMode;

			protected override uint Invoke(uint actionID, uint lastComboActionID, float comboTime, byte level)
			{
				if (actionID is TotalEclipse)
				{
					if (IsEnabled(CustomComboPreset.PLD_Variant_Cure) && IsEnabled(Variant.VariantCure) &&
						PlayerHealthPercentageHp() <= Config.PLD_VariantCure)
					{
						return Variant.VariantCure;
					}

					if (HasBattleTarget())
					{
						if (InMeleeRange() && CanWeave(actionID))
						{
							Status? sustainedDamage = FindTargetEffect(Variant.Debuffs.SustainedDamage);

							if (IsEnabled(CustomComboPreset.PLD_Variant_SpiritDart) && IsEnabled(Variant.VariantSpiritDart) &&
								(sustainedDamage is null || sustainedDamage?.RemainingTime <= 3))
							{
								return Variant.VariantSpiritDart;
							}

							if (IsEnabled(CustomComboPreset.PLD_Variant_Ultimatum) &&
								IsEnabled(Variant.VariantUltimatum) && IsOffCooldown(Variant.VariantUltimatum))
							{
								return Variant.VariantUltimatum;
							}
						}

						if (HasEffect(Buffs.FightOrFlight))
						{
							if (CanWeave(actionID))
							{
								if (InMeleeRange())
								{
									if (ActionReady(CircleOfScorn) && IsEnabled(CustomComboPreset.PLD_AoE_AdvancedMode_CircleOfScorn))
									{
										return CircleOfScorn;
									}

									if (ActionReady(SpiritsWithin) && IsEnabled(CustomComboPreset.PLD_AoE_AdvancedMode_SpiritsWithin))
									{
										return OriginalHook(SpiritsWithin);
									}
								}
							}
						}

						if (CanWeave(actionID) && InMeleeRange())
						{
							if (ActionReady(FightOrFlight) && IsEnabled(CustomComboPreset.PLD_AoE_AdvancedMode_FoF) && GetTargetHPPercent() >= Config.PLD_AoE_FoF_Option &&
								((GetCooldownRemainingTime(Requiescat) < 0.5f && CanWeave(actionID, 1.5f)) || !ActionReady(Requiescat)))
							{
								return FightOrFlight;
							}

							if (GetCooldownRemainingTime(FightOrFlight) > 15)
							{
								if (ActionReady(CircleOfScorn) && IsEnabled(CustomComboPreset.PLD_AoE_AdvancedMode_CircleOfScorn))
								{
									return CircleOfScorn;
								}

								if (ActionReady(SpiritsWithin) && IsEnabled(CustomComboPreset.PLD_AoE_AdvancedMode_SpiritsWithin))
								{
									return OriginalHook(SpiritsWithin);
								}
							}
						}

						if (IsEnabled(CustomComboPreset.PLD_AoE_AdvancedMode_Sheltron) && InCombat() && CanWeave(actionID) &&
							ActionReady(Sheltron) && !HasEffect(Buffs.Sheltron) && !HasEffect(Buffs.HolySheltron) &&
							Gauge.OathGauge >= Config.PLD_AoE_SheltronOption)
						{
							return OriginalHook(Sheltron);
						}
					}

					if (IsEnabled(CustomComboPreset.PLD_AoE_AdvancedMode_HolyCircle) && ActionReady(HolyCircle) && GetResourceCost(HolyCircle) <= LocalPlayer.CurrentMp &&
						(HasEffect(Buffs.DivineMight) || HasEffect(Buffs.Requiescat)))
					{
						return HolyCircle;
					}

					if (comboTime > 0 && lastComboActionID is TotalEclipse && ActionReady(Prominence))
					{
						return Prominence;
					}
				}
				return actionID;
			}
		}

		internal class PLD_Requiescat_Confiteor : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.PLD_Requiescat_Options;

			protected override uint Invoke(uint actionID, uint lastComboActionID, float comboTime, byte level)
			{
				if (actionID is Requiescat)
				{
					if (HasEffect(Buffs.ConfiteorReady) && Confiteor.ActionReady() && GetResourceCost(Confiteor) <= LocalPlayer.CurrentMp)
					{
						return OriginalHook(Confiteor);
					}

					if (HasEffect(Buffs.Requiescat))
					{
						if (OriginalHook(Confiteor) != Confiteor && BladeOfFaith.ActionReady() && GetResourceCost(Confiteor) <= LocalPlayer.CurrentMp)
						{
							return OriginalHook(Confiteor);
						}
					}
				}
				return actionID;
			}
		}

		internal class PLD_CircleOfScorn : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.PLD_SpiritsWithin;

			protected override uint Invoke(uint actionID, uint lastComboActionID, float comboTime, byte level)
			{
				return (actionID == SpiritsWithin || actionID == Expiacion) && ActionReady(CircleOfScorn)
					? IsOffCooldown(OriginalHook(SpiritsWithin)) ? OriginalHook(SpiritsWithin) : CircleOfScorn
					: actionID;
			}
		}
	}
}