using Dalamud.Game.ClientState.Conditions;
using StackCombo.ComboHelper.Functions;
using StackCombo.Combos.PvE.Content;
using StackCombo.CustomCombo;
using static StackCombo.Combos.JobHelpers.RDMHelper;

namespace StackCombo.Combos.PvE
{
	internal class RDM
	{
		public const byte JobID = 35;

		public const uint
			Verthunder = 7505,
			Veraero = 7507,
			Veraero2 = 16525,
			Veraero3 = 25856,
			Verthunder2 = 16524,
			Verthunder3 = 25855,
			Impact = 16526,
			Redoublement = 7516,
			EnchantedRedoublement = 7529,
			Zwerchhau = 7512,
			EnchantedZwerchhau = 7528,
			Riposte = 7504,
			EnchantedRiposte = 7527,
			Scatter = 7509,
			Verstone = 7511,
			Verfire = 7510,
			Vercure = 7514,
			Jolt = 7503,
			Jolt2 = 7524,
			Jolt3 = 37004,
			Verholy = 7526,
			Verflare = 7525,
			Fleche = 7517,
			ContreSixte = 7519,
			Engagement = 16527,
			Verraise = 7523,
			Scorch = 16530,
			Resolution = 25858,
			Moulinet = 7513,
			EnchantedMoulinet = 7530,
			EnchantedMoulinetDeux = 37002,
			EnchantedMoulinetTrois = 37003,
			Corpsacorps = 7506,
			Displacement = 7515,
			Reprise = 16529,
			ViceOfThorns = 37005,
			GrandImpact = 37006,
			Prefulgence = 37007,

			Acceleration = 7518,
			Manafication = 7521,
			Embolden = 7520,
			MagickBarrier = 25857;

		public static class Buffs
		{
			public const ushort
				VerfireReady = 1234,
				VerstoneReady = 1235,
				Dualcast = 1249,
				Chainspell = 2560,
				Acceleration = 1238,
				Embolden = 1239,
				EmboldenOthers = 1297,
				Manafication = 1971,
				MagickBarrier = 2707,
				MagickedSwordPlay = 3875,
				ThornedFlourish = 3876,
				GrandImpactReady = 3877,
				PrefulugenceReady = 3878;
		}

		public static class Debuffs
		{
		}



		public static class Traits
		{
			public const uint
				EnhancedEmbolden = 620,
				EnhancedManaficationII = 622,
				EnhancedManaficationIII = 622,
				EnhancedAccelerationII = 624;
		}

		public static class Config
		{
			public static UserInt
				RDM_VariantCure = new("RDM_VariantCure"),
				RDM_ST_Lucid_Threshold = new("RDM_LucidDreaming_Threshold", 6500),
				RDM_AoE_Lucid_Threshold = new("RDM_AoE_Lucid_Threshold", 6500),
				RDM_AoE_MoulinetRange = new("RDM_MoulinetRange");
			public static UserBool
				RDM_ST_oGCD_OnAction_Adv = new("RDM_ST_oGCD_OnAction_Adv"),
				RDM_ST_oGCD_Fleche = new("RDM_ST_oGCD_Fleche"),
				RDM_ST_oGCD_ContraSixte = new("RDM_ST_oGCD_ContraSixte"),
				RDM_ST_oGCD_Engagement = new("RDM_ST_oGCD_Engagement"),
				RDM_ST_oGCD_Engagement_Pooling = new("RDM_ST_oGCD_Engagement_Pooling"),
				RDM_ST_oGCD_CorpACorps = new("RDM_ST_oGCD_CorpACorps"),
				RDM_ST_oGCD_CorpACorps_Melee = new("RDM_ST_oGCD_CorpACorps_Melee"),
				RDM_ST_oGCD_CorpACorps_Pooling = new("RDM_ST_oGCD_CorpACorps_Pooling"),
				RDM_ST_oGCD_ViceOfThorns = new("RDM_ST_oGCD_ViceOfThorns"),
				RDM_ST_oGCD_Prefulgence = new("RDM_ST_oGCD_Prefulgence"),
				RDM_ST_MeleeCombo_Adv = new("RDM_ST_MeleeCombo_Adv"),
				RDM_ST_MeleeFinisher_Adv = new("RDM_ST_MeleeFinisher_Adv"),
				RDM_ST_MeleeEnforced = new("RDM_ST_MeleeEnforced"),

				RDM_AoE_oGCD_OnAction_Adv = new("RDM_AoE_oGCD_OnAction_Adv"),
				RDM_AoE_oGCD_Fleche = new("RDM_AoE_oGCD_Fleche"),
				RDM_AoE_oGCD_ContraSixte = new("RDM_AoE_oGCD_ContraSixte"),
				RDM_AoE_oGCD_Engagement = new("RDM_AoE_oGCD_Engagement"),
				RDM_AoE_oGCD_Engagement_Pooling = new("RDM_AoE_oGCD_Engagement_Pooling"),
				RDM_AoE_oGCD_CorpACorps = new("RDM_AoE_oGCD_CorpACorps"),
				RDM_AoE_oGCD_CorpACorps_Melee = new("RDM_AoE_oGCD_CorpACorps_Melee"),
				RDM_AoE_oGCD_CorpACorps_Pooling = new("RDM_AoE_oGCD_CorpACorps_Pooling"),
				RDM_AoE_oGCD_ViceOfThorns = new("RDM_AoE_oGCD_ViceOfThorns"),
				RDM_AoE_oGCD_Prefulgence = new("RDM_AoE_oGCD_Prefulgence"),
				RDM_AoE_MeleeCombo_Adv = new("RDM_AoE_MeleeCombo_Adv"),
				RDM_AoE_MeleeFinisher_Adv = new("RDM_AoE_MeleeFinisher_Adv");
			public static UserBoolArray
				RDM_ST_oGCD_OnAction = new("RDM_ST_oGCD_OnAction"),
				RDM_ST_MeleeCombo_OnAction = new("RDM_ST_MeleeCombo_OnAction"),
				RDM_ST_MeleeFinisher_OnAction = new("RDM_ST_MeleeFinisher_OnAction"),

				RDM_AoE_oGCD_OnAction = new("RDM_AoE_oGCD_OnAction"),
				RDM_AoE_MeleeCombo_OnAction = new("RDM_AoE_MeleeCombo_OnAction"),
				RDM_AoE_MeleeFinisher_OnAction = new("RDM_AoE_MeleeFinisher_OnAction");
		}

		internal class RDM_VariantVerCure : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.RDM_Variant_Cure;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				return actionID is Vercure && IsEnabled(CustomComboPreset.RDM_Variant_Cure2) && IsEnabled(Variant.VariantCure)
					? Variant.VariantCure : actionID;
			}
		}

		internal class RDM_ST_DPS : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.RDM_ST_DPS;

			internal static bool inOpener = false;
			internal static bool readyOpener = false;
			internal static bool openerStarted = false;
			internal static byte step = 0;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				int blackmana = RDMMana.Black;
				int whitemana = RDMMana.White;
				if (actionID is Jolt or Jolt2 or Jolt3)
				{
					if (IsEnabled(CustomComboPreset.RDM_Variant_Cure) &&
						IsEnabled(Variant.VariantCure) &&
						PlayerHealthPercentageHp() <= GetOptionValue(Config.RDM_VariantCure))
					{
						return Variant.VariantCure;
					}

					if (IsEnabled(CustomComboPreset.RDM_Variant_Rampart) &&
						IsEnabled(Variant.VariantRampart) &&
						IsOffCooldown(Variant.VariantRampart) &&
						CanSpellWeave(actionID))
					{
						return Variant.VariantRampart;
					}

					if (IsEnabled(CustomComboPreset.RDM_Balance_Opener) && level >= 90)
					{
						bool inCombat = HasCondition(ConditionFlag.InCombat);

						if (openerStarted && lastComboMove is Verthunder3 && HasEffect(Buffs.Dualcast)) { inOpener = true; openerStarted = false; readyOpener = false; }
						if ((readyOpener || openerStarted) && !inOpener && LocalPlayer.CastActionId == Verthunder3) { openerStarted = true; return Veraero3; } else { openerStarted = false; }

						if ((IsEnabled(CustomComboPreset.RDM_Balance_Opener_AnyMana) || (blackmana == 0 && whitemana == 0))
							&& IsOffCooldown(Embolden) && IsOffCooldown(Manafication) && IsOffCooldown(All.Swiftcast)
							&& GetRemainingCharges(Acceleration) == 2 && GetRemainingCharges(Corpsacorps) == 2 && GetRemainingCharges(Engagement) == 2
							&& IsOffCooldown(Fleche) && IsOffCooldown(ContreSixte)
							&& GetTargetHPPercent() == 100 && !inCombat && !inOpener && !openerStarted)
						{
							readyOpener = true;
							inOpener = false;
							step = 0;
							return Verthunder3;
						}
						else
						{ readyOpener = false; }

						if ((step == 0 && lastComboMove is Verthunder3 && !HasEffect(Buffs.Dualcast))
							|| (inOpener && step >= 1 && IsOffCooldown(actionID) && !inCombat))
						{
							inOpener = false;
						}

						if (inOpener)
						{
							if (step == 0)
							{
								if (lastComboMove == Veraero3)
								{
									step++;
								}
								else
								{
									return Veraero3;
								}
							}

							if (step == 1)
							{
								if (IsOnCooldown(All.Swiftcast))
								{
									step++;
								}
								else
								{
									return All.Swiftcast;
								}
							}

							if (step == 2)
							{
								if (GetRemainingCharges(Acceleration) < 2)
								{
									step++;
								}
								else
								{
									return Acceleration;
								}
							}

							if (step == 3)
							{
								if (lastComboMove == Verthunder3 && !HasEffect(Buffs.Acceleration))
								{
									step++;
								}
								else
								{
									return Verthunder3;
								}
							}

							if (step == 4)
							{
								if (lastComboMove == Verthunder3 && !HasEffect(All.Buffs.Swiftcast))
								{
									step++;
								}
								else
								{
									return Verthunder3;
								}
							}

							if (step == 5)
							{
								if (IsOnCooldown(Embolden))
								{
									step++;
								}
								else
								{
									return Embolden;
								}
							}

							if (step == 6)
							{
								if (IsOnCooldown(Manafication))
								{
									step++;
								}
								else
								{
									return Manafication;
								}
							}

							if (step == 7)
							{
								if (lastComboMove == Riposte)
								{
									step++;
								}
								else
								{
									return EnchantedRiposte;
								}
							}

							if (step == 8)
							{
								if (IsOnCooldown(Fleche))
								{
									step++;
								}
								else
								{
									return Fleche;
								}
							}

							if (step == 9)
							{
								if (lastComboMove == Zwerchhau)
								{
									step++;
								}
								else
								{
									return EnchantedZwerchhau;
								}
							}

							if (step == 10)
							{
								if (IsOnCooldown(ContreSixte))
								{
									step++;
								}
								else
								{
									return ContreSixte;
								}
							}

							if (step == 11)
							{
								if (lastComboMove == Redoublement || RDMMana.ManaStacks == 3)
								{
									step++;
								}
								else
								{
									return EnchantedRedoublement;
								}
							}

							if (step == 12)
							{
								if (GetRemainingCharges(Corpsacorps) < 2)
								{
									step++;
								}
								else
								{
									return Corpsacorps;
								}
							}

							if (step == 13)
							{
								if (GetRemainingCharges(Engagement) < 2)
								{
									step++;
								}
								else
								{
									return Engagement;
								}
							}

							if (step == 14)
							{
								if (lastComboMove == Verholy)
								{
									step++;
								}
								else
								{
									return Verholy;
								}
							}

							if (step == 15)
							{
								if (GetRemainingCharges(Corpsacorps) < 1)
								{
									step++;
								}
								else
								{
									return Corpsacorps;
								}
							}

							if (step == 16)
							{
								if (GetRemainingCharges(Engagement) < 1)
								{
									step++;
								}
								else
								{
									return Engagement;
								}
							}

							if (step == 17)
							{
								if (lastComboMove == Scorch)
								{
									step++;
								}
								else
								{
									return Scorch;
								}
							}

							if (step == 18)
							{
								if (lastComboMove == Resolution)
								{
									step++;
								}
								else
								{
									return Resolution;
								}
							}

							inOpener = false;
						}
					}
				}

				if (IsEnabled(CustomComboPreset.RDM_ST_Lucid)
					&& actionID is Jolt or Jolt2 or Jolt3
					&& All.CanUseLucid(actionID, Config.RDM_ST_Lucid_Threshold)
					&& InCombat()
					&& RDMLucid.SafetoUse(lastComboMove))
				{
					return All.LucidDreaming;
				}

				if (IsEnabled(CustomComboPreset.RDM_ST_oGCD))
				{
					bool ActionFound =
						(!Config.RDM_ST_oGCD_OnAction_Adv && actionID is Jolt or Jolt2 or Jolt3) ||
						  (Config.RDM_ST_oGCD_OnAction_Adv &&
							((Config.RDM_ST_oGCD_OnAction[0] && actionID is Jolt or Jolt2 or Jolt3) ||
							 (Config.RDM_ST_oGCD_OnAction[1] && actionID is Fleche) ||
							 (Config.RDM_ST_oGCD_OnAction[2] && actionID is Riposte) ||
							 (Config.RDM_ST_oGCD_OnAction[3] && actionID is Reprise)
							))
						  ;
					if (ActionFound && LevelChecked(Corpsacorps))
					{
						if (OGCDHelper.CanUse(actionID, true, out uint oGCDAction))
						{
							return oGCDAction;
						}
					}
				}
				if (IsEnabled(CustomComboPreset.RDM_ST_MeleeFinisher))
				{
					bool ActionFound =
						(!Config.RDM_ST_MeleeFinisher_Adv && actionID is Jolt or Jolt2 or Jolt3) ||
						(Config.RDM_ST_MeleeFinisher_Adv &&
							((Config.RDM_ST_MeleeFinisher_OnAction[0] && actionID is Jolt or Jolt2 or Jolt3) ||
							 (Config.RDM_ST_MeleeFinisher_OnAction[1] && actionID is Riposte or EnchantedRiposte) ||
							 (Config.RDM_ST_MeleeFinisher_OnAction[2] && actionID is Veraero or Veraero3 or Verthunder or Verthunder3)));

					if (ActionFound && MeleeFinisher.CanUse(lastComboMove, out uint finisherAction))
					{
						return finisherAction;
					}
				}
				if (IsEnabled(CustomComboPreset.RDM_ST_MeleeCombo)
					&& LocalPlayer.IsCasting == false)
				{
					bool ActionFound =
						(!Config.RDM_ST_MeleeCombo_Adv && actionID is Jolt or Jolt2 or Jolt3) ||
						(Config.RDM_ST_MeleeCombo_Adv &&
							((Config.RDM_ST_MeleeCombo_OnAction[0] && actionID is Jolt or Jolt2 or Jolt3) ||
							 (Config.RDM_ST_MeleeCombo_OnAction[1] && actionID is Riposte or EnchantedRiposte)));

					if (ActionFound)
					{
						if (IsEnabled(CustomComboPreset.RDM_ST_MeleeCombo_ManaEmbolden)
							&& LevelChecked(Embolden)
							&& HasCondition(ConditionFlag.InCombat)
							&& !HasEffect(Buffs.Dualcast)
							&& !HasEffect(All.Buffs.Swiftcast)
							&& !HasEffect(Buffs.Acceleration)
							&& (GetTargetDistance() <= 3 || (IsEnabled(CustomComboPreset.RDM_ST_MeleeCombo_CorpsGapCloser) && HasCharges(Corpsacorps))))
						{
							if (IsEnabled(CustomComboPreset.RDM_ST_MeleeCombo_ManaEmbolden_DoubleCombo)
								&& level >= 90
								&& RDMMana.ManaStacks == 0
								&& lastComboMove is not Verflare
								&& lastComboMove is not Verholy
								&& lastComboMove is not Scorch
								&& RDMMana.Max <= 50
								&& (RDMMana.Max >= 42
									|| (IsEnabled(CustomComboPreset.RDM_ST_MeleeCombo_UnbalanceMana) && blackmana == whitemana && blackmana >= 38 && HasCharges(Acceleration)))
								&& RDMMana.Min >= 31
								&& IsOffCooldown(Manafication)
								&& (IsOffCooldown(Embolden) || GetCooldownRemainingTime(Embolden) <= 3))
							{
								return IsEnabled(CustomComboPreset.RDM_ST_MeleeCombo_UnbalanceMana)
									&& blackmana == whitemana
									&& blackmana <= 44
									&& blackmana >= 38
									&& HasCharges(Acceleration)
									? Acceleration
									: Manafication;
							}
							if (IsEnabled(CustomComboPreset.RDM_ST_MeleeCombo_ManaEmbolden_DoubleCombo)
								&& level >= 90
								&& lastComboMove is Zwerchhau or EnchantedZwerchhau
								&& RDMMana.Max >= 57
								&& RDMMana.Min >= 46
								&& GetCooldownRemainingTime(Manafication) >= 100
								&& IsOffCooldown(Embolden))
							{
								return Embolden;
							}

							if (IsEnabled(CustomComboPreset.RDM_ST_MeleeCombo_ManaEmbolden_DoubleCombo)
								&& level >= 90
								&& lastComboMove is Zwerchhau or EnchantedZwerchhau
								&& RDMMana.Max <= 57
								&& RDMMana.Min <= 46
								&& (GetCooldownRemainingTime(Manafication) <= 7 || IsOffCooldown(Manafication))
								&& IsOffCooldown(Embolden))
							{
								return Embolden;
							}
							if (IsEnabled(CustomComboPreset.RDM_ST_MeleeCombo_ManaEmbolden_DoubleCombo)
								&& level >= 90
								&& (RDMMana.ManaStacks == 0 || RDMMana.ManaStacks == 3)
								&& lastComboMove is not Verflare
								&& lastComboMove is not Verholy
								&& lastComboMove is not Scorch
								&& RDMMana.Max <= 50
								&& (HasEffect(Buffs.Embolden) || WasLastAction(Embolden))
								&& IsOffCooldown(Manafication))
							{
								return Manafication;
							}

							if ((IsNotEnabled(CustomComboPreset.RDM_ST_MeleeCombo_ManaEmbolden_DoubleCombo) || level < 90)
								&& ActionReady(Embolden)
								&& RDMMana.ManaStacks == 0
								&& RDMMana.Max <= 50
								&& (IsOffCooldown(Manafication) || !LevelChecked(Manafication)))
							{
								return IsEnabled(CustomComboPreset.RDM_ST_MeleeCombo_UnbalanceMana)
									&& blackmana == whitemana
									&& blackmana <= 44
									&& HasCharges(Acceleration)
									? Acceleration
									: Embolden;
							}
							if ((IsNotEnabled(CustomComboPreset.RDM_ST_MeleeCombo_ManaEmbolden_DoubleCombo) || level < 90)
								&& ActionReady(Manafication)
								&& (RDMMana.ManaStacks == 0 || RDMMana.ManaStacks == 3)
								&& lastComboMove is not Verflare
								&& lastComboMove is not Verholy
								&& lastComboMove is not Scorch
								&& RDMMana.Max <= 50
								&& (HasEffect(Buffs.Embolden) || WasLastAction(Embolden)))
							{
								return Manafication;
							}

							if (!LevelChecked(Manafication) &&
								ActionReady(Embolden) &&
								RDMMana.Min >= 50)
							{
								return Embolden;
							}

						}

						if (GetTargetDistance() <= 3 || Config.RDM_ST_MeleeEnforced)
						{
							if (lastComboMove is Riposte or EnchantedRiposte
								&& LevelChecked(Zwerchhau)
								&& comboTime > 0f)
							{
								return OriginalHook(Zwerchhau);
							}

							if (lastComboMove is Zwerchhau
								&& LevelChecked(Redoublement)
								&& comboTime > 0f)
							{
								return OriginalHook(Redoublement);
							}
						}

						if (((RDMMana.Min >= 50 && LevelChecked(Redoublement))
							|| (RDMMana.Min >= 35 && !LevelChecked(Redoublement))
							|| (RDMMana.Min >= 20 && !LevelChecked(Zwerchhau)))
							&& !HasEffect(Buffs.Dualcast))
						{
							if (IsEnabled(CustomComboPreset.RDM_ST_MeleeCombo_CorpsGapCloser)
								&& LevelChecked(Corpsacorps) && HasCharges(Corpsacorps)
								&& GetTargetDistance() > 3)
							{
								return Corpsacorps;
							}

							if (IsEnabled(CustomComboPreset.RDM_ST_MeleeCombo_UnbalanceMana)
								&& LevelChecked(Acceleration)
								&& blackmana == whitemana
								&& blackmana >= 50
								&& !HasEffect(Buffs.Embolden))
							{
								if (HasEffect(Buffs.Acceleration) || WasLastAction(Buffs.Acceleration))
								{
									(_, _, bool useThunder, bool useAero, _, _) = RDMMana.CheckBalance();

									if (useAero && LevelChecked(OriginalHook(Veraero)))
									{
										return OriginalHook(Veraero);
									}

									if (useThunder && LevelChecked(OriginalHook(Verthunder)))
									{
										return OriginalHook(Verthunder);
									}
								}

								if (HasCharges(Acceleration))
								{
									return Acceleration;
								}
							}
							if (GetTargetDistance() <= 3)
							{
								return OriginalHook(Riposte);
							}
						}

					}
				}
				if (IsEnabled(CustomComboPreset.RDM_ST_ThunderAero) && IsEnabled(CustomComboPreset.RDM_ST_ThunderAero_Accel)
					&& actionID is Jolt or Jolt2 or Jolt3
					&& HasCondition(ConditionFlag.InCombat)
					&& LocalPlayer.IsCasting == false
					&& RDMMana.ManaStacks == 0
					&& lastComboMove is not Verflare
					&& lastComboMove is not Verholy
					&& lastComboMove is not Scorch
					&& !HasEffect(Buffs.VerfireReady)
					&& !HasEffect(Buffs.VerstoneReady)
					&& !HasEffect(Buffs.Acceleration)
					&& !HasEffect(Buffs.Dualcast)
					&& !HasEffect(All.Buffs.Swiftcast))
				{
					if (ActionReady(Acceleration)
						&& GetCooldown(Acceleration).ChargeCooldownRemaining < 54.5)
					{
						return Acceleration;
					}

					if (IsEnabled(CustomComboPreset.RDM_ST_ThunderAero_Accel_Swiftcast)
						&& ActionReady(All.Swiftcast)
						&& !HasCharges(Acceleration))
					{
						return All.Swiftcast;
					}
				}

				if (actionID is Jolt or Jolt2 or Jolt3)
				{
					if (TraitLevelChecked(Traits.EnhancedAccelerationII)
						&& HasEffect(Buffs.GrandImpactReady))
					{
						return GrandImpact;
					}

					if (IsEnabled(CustomComboPreset.RDM_ST_FireStone)
						&& !HasEffect(Buffs.Acceleration)
						&& !HasEffect(Buffs.Dualcast))
					{
						(bool useFire, bool useStone, _, _, _, _) = RDMMana.CheckBalance();
						if (useFire)
						{
							return Verfire;
						}

						if (useStone)
						{
							return Verstone;
						}
					}
					if (IsEnabled(CustomComboPreset.RDM_ST_ThunderAero))
					{
						(_, _, bool useThunder, bool useAero, _, _) = RDMMana.CheckBalance();
						if (useThunder)
						{
							return OriginalHook(Verthunder);
						}

						if (useAero)
						{
							return OriginalHook(Veraero);
						}
					}
				}

				return actionID;
			}
		}

		internal class RDM_AoE_DPS : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.RDM_AoE_DPS;
			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (IsEnabled(CustomComboPreset.RDM_Variant_Cure) &&
					IsEnabled(Variant.VariantCure) &&
					PlayerHealthPercentageHp() <= GetOptionValue(Config.RDM_VariantCure))
				{
					return Variant.VariantCure;
				}

				if (IsEnabled(CustomComboPreset.RDM_Variant_Rampart) &&
					IsEnabled(Variant.VariantRampart) &&
					IsOffCooldown(Variant.VariantRampart) &&
					CanSpellWeave(actionID))
				{
					return Variant.VariantRampart;
				}

				if (IsEnabled(CustomComboPreset.RDM_AoE_Lucid)
					&& actionID is Scatter or Impact
					&& All.CanUseLucid(actionID, Config.RDM_AoE_Lucid_Threshold)
					&& InCombat()
					&& RDMLucid.SafetoUse(lastComboMove))
				{
					return All.LucidDreaming;
				}

				if (IsEnabled(CustomComboPreset.RDM_AoE_oGCD)
					&& LevelChecked(Corpsacorps) &&
					actionID is Scatter or Impact &&
					OGCDHelper.CanUse(actionID, false, out uint oGCDAction))
				{
					return oGCDAction;
				}

				if (IsEnabled(CustomComboPreset.RDM_AoE_MeleeFinisher))
				{
					bool ActionFound =
						(!Config.RDM_AoE_MeleeFinisher_Adv && actionID is Scatter or Impact) ||
						(Config.RDM_AoE_MeleeFinisher_Adv &&
							((Config.RDM_AoE_MeleeFinisher_OnAction[0] && actionID is Scatter or Impact) ||
							 (Config.RDM_AoE_MeleeFinisher_OnAction[1] && actionID is Moulinet) ||
							 (Config.RDM_AoE_MeleeFinisher_OnAction[2] && actionID is Veraero2 or Verthunder2)));


					if (ActionFound && MeleeFinisher.CanUse(lastComboMove, out uint finisherAction))
					{
						return finisherAction;
					}
				}
				if (IsEnabled(CustomComboPreset.RDM_AoE_MeleeCombo))
				{
					bool ActionFound =
						(!Config.RDM_AoE_MeleeCombo_Adv && actionID is Scatter or Impact) ||
						(Config.RDM_AoE_MeleeCombo_Adv &&
							((Config.RDM_AoE_MeleeCombo_OnAction[0] && actionID is Scatter or Impact) ||
								(Config.RDM_AoE_MeleeCombo_OnAction[1] && actionID is Moulinet)));


					if (ActionFound)
					{
						if (LevelChecked(Moulinet)
							&& lastComboMove is EnchantedMoulinet or EnchantedMoulinetDeux
							&& comboTime > 0f)
						{
							return OriginalHook(Moulinet);
						}

						if (IsEnabled(CustomComboPreset.RDM_AoE_MeleeCombo_ManaEmbolden))
						{
							if (HasCondition(ConditionFlag.InCombat)
								&& !HasEffect(Buffs.Dualcast)
								&& !HasEffect(All.Buffs.Swiftcast)
								&& !HasEffect(Buffs.Acceleration)
								&& ((GetTargetDistance() <= Config.RDM_AoE_MoulinetRange && RDMMana.ManaStacks == 0) || RDMMana.ManaStacks > 0))
							{
								if (ActionReady(Manafication))
								{
									if (RDMMana.ManaStacks == 2
										&& RDMMana.Min >= 22
										&& IsOffCooldown(Embolden))
									{
										return Embolden;
									}
									if (((RDMMana.ManaStacks == 3 && RDMMana.Min >= 2) || (RDMMana.ManaStacks == 0 && RDMMana.Min >= 10))
										&& lastComboMove is not Verflare
										&& lastComboMove is not Verholy
										&& lastComboMove is not Scorch
										&& RDMMana.Max <= 50
										&& (HasEffect(Buffs.Embolden) || WasLastAction(Embolden)))
									{
										return Manafication;
									}

									if (RDMMana.ManaStacks == 0
										&& lastComboMove is not Verflare
										&& lastComboMove is not Verholy
										&& lastComboMove is not Scorch
										&& RDMMana.Max <= 50
										&& RDMMana.Min >= 10
										&& IsOffCooldown(Embolden))
									{
										return Embolden;
									}
									if (RDMMana.ManaStacks == 0
										&& lastComboMove is not Verflare
										&& lastComboMove is not Verholy
										&& lastComboMove is not Scorch
										&& RDMMana.Max <= 50
										&& RDMMana.Min >= 10
										&& (HasEffect(Buffs.Embolden) || WasLastAction(Embolden)))
									{
										return Manafication;
									}
								}

								if (ActionReady(Embolden) && !LevelChecked(Manafication)
									&& RDMMana.Min >= 20)
								{
									return Embolden;
								}
							}
						}

						if (LevelChecked(Moulinet)
							&& LocalPlayer.IsCasting == false
							&& !HasEffect(Buffs.Dualcast)
							&& !HasEffect(All.Buffs.Swiftcast)
							&& !HasEffect(Buffs.Acceleration)
							&& RDMMana.Min >= 50)
						{
							if (IsEnabled(CustomComboPreset.RDM_AoE_MeleeCombo_CorpsGapCloser)
								&& ActionReady(Corpsacorps)
								&& GetTargetDistance() > Config.RDM_AoE_MoulinetRange)
							{
								return Corpsacorps;
							}

							if ((GetTargetDistance() <= Config.RDM_AoE_MoulinetRange && RDMMana.ManaStacks == 0) || RDMMana.ManaStacks >= 1)
							{
								return OriginalHook(Moulinet);
							}
						}
					}
				}
				if (IsEnabled(CustomComboPreset.RDM_AoE_Accel)
					&& actionID is Scatter or Impact
					&& LocalPlayer.IsCasting == false
					&& RDMMana.ManaStacks == 0
					&& lastComboMove is not Verflare
					&& lastComboMove is not Verholy
					&& lastComboMove is not Scorch
					&& !WasLastAction(Embolden)
					&& (IsNotEnabled(CustomComboPreset.RDM_AoE_Accel_Weave) || CanSpellWeave(actionID))
					&& !HasEffect(Buffs.Acceleration)
					&& !HasEffect(Buffs.Dualcast)
					&& !HasEffect(All.Buffs.Swiftcast))
				{
					if (ActionReady(Acceleration)
						&& GetCooldown(Acceleration).ChargeCooldownRemaining < 54.5)
					{
						return Acceleration;
					}

					if (IsEnabled(CustomComboPreset.RDM_AoE_Accel_Swiftcast)
						&& ActionReady(All.Swiftcast)
						&& !HasCharges(Acceleration)
						&& GetCooldown(Acceleration).ChargeCooldownRemaining < 54.5)
					{
						return All.Swiftcast;
					}
				}
				if (actionID is Scatter or Impact)
				{

					if (TraitLevelChecked(Traits.EnhancedAccelerationII)
						&& HasEffect(Buffs.GrandImpactReady))
					{
						return GrandImpact;
					}

					(_, _, _, _, bool useThunder2, bool useAero2) = RDMMana.CheckBalance();
					if (useThunder2)
					{
						return OriginalHook(Verthunder2);
					}

					if (useAero2)
					{
						return OriginalHook(Veraero2);
					}
				}
				return actionID;
			}
		}

		internal class RDM_Verraise : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.RDM_Raise;
			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID is All.Swiftcast)
				{
					if (HasEffect(All.Buffs.Swiftcast) && IsEnabled(CustomComboPreset.SMN_Variant_Raise) && IsEnabled(Variant.VariantRaise))
					{
						return Variant.VariantRaise;
					}

					if (LevelChecked(Verraise) &&
						(GetCooldownRemainingTime(All.Swiftcast) > 0 ||
						HasEffect(Buffs.Dualcast)))
					{
						return Verraise;
					}
				}

				return actionID;
			}
		}

		internal class RDM_CorpsDisplacement : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.RDM_CorpsDisplacement;
			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				return actionID is Displacement
				&& LevelChecked(Displacement)
				&& HasTarget()
				&& GetTargetDistance() >= 5 ? Corpsacorps : actionID;
			}
		}

		internal class RDM_EmboldenManafication : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.RDM_EmboldenManafication;
			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				return actionID is Embolden
				&& IsOnCooldown(Embolden)
				&& ActionReady(Manafication) ? Manafication : actionID;
			}
		}

		internal class RDM_MagickBarrierAddle : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.RDM_MagickBarrierAddle;
			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				return actionID is MagickBarrier
				&& (IsOnCooldown(MagickBarrier) || !LevelChecked(MagickBarrier))
				&& ActionReady(All.Addle)
				&& !TargetHasEffectAny(All.Debuffs.Addle) ? All.Addle : actionID;
			}
		}

		internal class RDM_EmboldenProtection : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.RDM_EmboldenProtection;
			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				return actionID is Embolden &&
				ActionReady(Embolden) &&
				HasEffectAny(Buffs.EmboldenOthers) ? OriginalHook(11) : actionID;
			}
		}

		internal class RDM_MagickProtection : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.RDM_MagickProtection;
			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				return actionID is MagickBarrier &&
				ActionReady(MagickBarrier) &&
				HasEffectAny(Buffs.MagickBarrier) ? OriginalHook(11) : actionID;
			}
		}
	}
}
