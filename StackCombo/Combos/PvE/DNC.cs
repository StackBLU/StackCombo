using Dalamud.Game.ClientState.JobGauge.Types;
using StackCombo.Combos.PvE.Content;
using StackCombo.Core;
using StackCombo.CustomCombo;
using StackCombo.Services;

namespace StackCombo.Combos.PvE
{
	internal static class DNC
	{
		public const byte JobID = 38;

		public const uint
			Cascade = 15989,
			Fountain = 15990,
			ReverseCascade = 15991,
			Fountainfall = 15992,
			StarfallDance = 25792,
			Windmill = 15993,
			Bladeshower = 15994,
			RisingWindmill = 15995,
			Bloodshower = 15996,
			Tillana = 25790,
			StandardStep = 15997,
			TechnicalStep = 15998,
			StandardFinish0 = 16003,
			StandardFinish1 = 16191,
			StandardFinish2 = 16192,
			TechnicalFinish0 = 16004,
			TechnicalFinish1 = 16193,
			TechnicalFinish2 = 16194,
			TechnicalFinish3 = 16195,
			TechnicalFinish4 = 16196,
			FanDance1 = 16007,
			FanDance2 = 16008,
			FanDance3 = 16009,
			FanDance4 = 25791,
			Peloton = 7557,
			SaberDance = 16005,
			EnAvant = 16010,
			Devilment = 16011,
			ShieldSamba = 16012,
			Flourish = 16013,
			Improvisation = 16014,
			CuringWaltz = 16015,
			LastDance = 36983,
			FinishingMove = 36984,
			DanceOfTheDawn = 36985;

		public static class Buffs
		{
			public const ushort
				FlourishingCascade = 1814,
				FlourishingFountain = 1815,
				FlourishingWindmill = 1816,
				FlourishingShower = 1817,
				FlourishingFanDance = 2021,
				SilkenSymmetry = 2693,
				SilkenFlow = 2694,
				FlourishingFinish = 2698,
				FlourishingStarfall = 2700,
				FlourishingSymmetry = 3017,
				FlourishingFlow = 3018,
				StandardStep = 1818,
				TechnicalStep = 1819,
				StandardFinish = 1821,
				TechnicalFinish = 1822,
				ThreeFoldFanDance = 1820,
				FourFoldFanDance = 2699,
				Peloton = 1199,
				ShieldSamba = 1826,
				LastDanceReady = 3867,
				FinishingMoveReady = 3868,
				DanceOfTheDawnReady = 3869,
				Devilment = 1825;
		}

		public static class Config
		{
			public const string
				DNCEspritThreshold_ST = "DNCEspritThreshold_ST";
			public const string
				DNCEspritThreshold_AoE = "DNCEspritThreshold_AoE";

			#region Simple ST Sliders
			public const string
				DNCSimpleSSBurstPercent = "DNCSimpleSSBurstPercent";
			public const string
				DNCSimpleTSBurstPercent = "DNCSimpleTSBurstPercent";
			public const string
				DNCSimpleFeatherBurstPercent = "DNCSimpleFeatherBurstPercent";
			public const string
				DNCSimpleSaberThreshold = "DNCSimpleSaberThreshold";
			public const string
				DNCSimplePanicHealWaltzPercent = "DNCSimplePanicHealWaltzPercent";
			public const string
				DNCSimplePanicHealWindPercent = "DNCSimplePanicHealWindPercent";
			#endregion

			#region Simple AoE Sliders
			public const string
				DNCSimpleSSAoEBurstPercent = "DNCSimpleSSAoEBurstPercent";
			public const string
				DNCSimpleTSAoEBurstPercent = "DNCSimpleTSAoEBurstPercent";
			public const string
				DNCSimpleAoESaberThreshold = "DNCSimpleAoESaberThreshold";
			public const string
				DNCSimpleAoEPanicHealWaltzPercent = "DNCSimpleAoEPanicHealWaltzPercent";
			public const string
				DNCSimpleAoEPanicHealWindPercent = "DNCSimpleAoEPanicHealWindPercent";
			#endregion

			public const string
				DNCVariantCurePercent = "DNCVariantCurePercent";
		}

		internal class DNC_DanceComboReplacer : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.DNC_DanceComboReplacer;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (GetJobGauge<DNCGauge>().IsDancing)
				{
					uint[]? actionIDs = Service.Configuration.DancerDanceCompatActionIDs;

					if (actionID == actionIDs[0] || (actionIDs[0] == 0 && actionID == Cascade))
					{
						return OriginalHook(Cascade);
					}

					if (actionID == actionIDs[1] || (actionIDs[1] == 0 && actionID == Flourish))
					{
						return OriginalHook(Fountain);
					}

					if (actionID == actionIDs[2] || (actionIDs[2] == 0 && actionID == FanDance1))
					{
						return OriginalHook(ReverseCascade);
					}

					if (actionID == actionIDs[3] || (actionIDs[3] == 0 && actionID == FanDance2))
					{
						return OriginalHook(Fountainfall);
					}
				}

				return actionID;
			}
		}

		internal class DNC_FanDanceCombos : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.DNC_FanDanceCombos;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID is FanDance1)
				{
					if (IsEnabled(CustomComboPreset.DNC_FanDance_1to3_Combo) &&
						HasEffect(Buffs.ThreeFoldFanDance))
					{
						return FanDance3;
					}

					if (IsEnabled(CustomComboPreset.DNC_FanDance_1to4_Combo) &&
						HasEffect(Buffs.FourFoldFanDance))
					{
						return FanDance4;
					}
				}

				if (actionID is FanDance2)
				{
					if (IsEnabled(CustomComboPreset.DNC_FanDance_2to3_Combo) &&
						HasEffect(Buffs.ThreeFoldFanDance))
					{
						return FanDance3;
					}

					if (IsEnabled(CustomComboPreset.DNC_FanDance_2to4_Combo) &&
						HasEffect(Buffs.FourFoldFanDance))
					{
						return FanDance4;
					}
				}

				return actionID;
			}
		}

		internal class DNC_DanceStepCombo : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.DNC_DanceStepCombo;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				DNCGauge? gauge = GetJobGauge<DNCGauge>();

				return actionID is StandardStep && gauge.IsDancing && HasEffect(Buffs.StandardStep)
					? gauge.CompletedSteps < 2
						? gauge.NextStep
						: StandardFinish2
					: actionID is TechnicalStep && gauge.IsDancing && HasEffect(Buffs.TechnicalStep)
					? gauge.CompletedSteps < 4
						? gauge.NextStep
						: TechnicalFinish4
					: actionID;
			}
		}

		internal class DNC_FlourishingFanDances : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.DNC_FlourishingFanDances;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID is Flourish && CanWeave(actionID))
				{
					if (HasEffect(Buffs.ThreeFoldFanDance))
					{
						return FanDance3;
					}

					if (HasEffect(Buffs.FourFoldFanDance))
					{
						return FanDance4;
					}
				}

				return actionID;
			}
		}

		internal class DNC_Starfall_Devilment : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.DNC_Starfall_Devilment;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				return actionID is Devilment && HasEffect(Buffs.FlourishingStarfall)
					? StarfallDance
					: actionID;
			}
		}

		internal class DNC_ST_SimpleMode : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.DNC_ST_SimpleMode;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID is not Cascade)
				{
					return actionID;
				}

				#region Variables
				DNCGauge? gauge = GetJobGauge<DNCGauge>();

				bool flow = HasEffect(Buffs.SilkenFlow) || HasEffect(Buffs.FlourishingFlow);
				bool symmetry = HasEffect(Buffs.SilkenSymmetry) || HasEffect(Buffs.FlourishingSymmetry);
				int targetHpThresholdFeather = PluginConfiguration.GetCustomIntValue(Config.DNCSimpleFeatherBurstPercent);
				int targetHpThresholdStandard = PluginConfiguration.GetCustomIntValue(Config.DNCSimpleSSBurstPercent);
				int targetHpThresholdTechnical = PluginConfiguration.GetCustomIntValue(Config.DNCSimpleTSBurstPercent);

				bool needToTech =
					IsEnabled(CustomComboPreset.DNC_ST_Simple_TS) &&
					GetCooldownRemainingTime(TechnicalStep) < 0.05 &&
					!HasEffect(Buffs.StandardStep) &&
					IsOnCooldown(StandardStep) &&
					GetTargetHPPercent() > targetHpThresholdTechnical &&
					LevelChecked(TechnicalStep);

				bool needToStandardOrFinish =
					IsEnabled(CustomComboPreset.DNC_ST_Simple_SS) &&
					GetCooldownRemainingTime(StandardStep) < 0.05 &&
					GetTargetHPPercent() > targetHpThresholdStandard &&
					(IsOffCooldown(TechnicalStep) ||
					 GetCooldownRemainingTime(TechnicalStep) > 5) &&
					LevelChecked(StandardStep);

				bool needToFinish =
					HasEffect(Buffs.FinishingMoveReady) &&
					!HasEffect(Buffs.LastDanceReady);

				bool needToStandard =
					!HasEffect(Buffs.FinishingMoveReady) &&
					(IsOffCooldown(Flourish) ||
					 GetCooldownRemainingTime(Flourish) > 5) &&
					!HasEffect(Buffs.TechnicalFinish);
				#endregion

				#region Pre-pull

				if (!InCombat())
				{
					if (IsEnabled(CustomComboPreset.DNC_ST_Simple_SS_Prepull) &&
						ActionReady(StandardStep) &&
						!HasEffect(Buffs.FinishingMoveReady) &&
						!HasEffect(Buffs.TechnicalFinish) &&
						IsOffCooldown(TechnicalStep) &&
						IsOffCooldown(StandardStep) &&
						!HasTarget())
					{
						return StandardStep;
					}

					if ((IsEnabled(CustomComboPreset.DNC_ST_Simple_SS) ||
						 IsEnabled(CustomComboPreset.DNC_ST_Simple_StandardFill) ||
						 IsEnabled(CustomComboPreset.DNC_ST_Simple_SS_Prepull)) &&
						HasEffect(Buffs.StandardStep) &&
						gauge.CompletedSteps < 2 &&
						!HasTarget())
					{
						return gauge.NextStep;
					}

					if (IsEnabled(CustomComboPreset.DNC_ST_Simple_Peloton) &&
						!HasEffectAny(Buffs.Peloton) &&
						GetBuffRemainingTime(Buffs.StandardStep) > 5)
					{
						return Peloton;
					}
				}
				#endregion

				#region Dance Fills
				if ((IsEnabled(CustomComboPreset.DNC_ST_Simple_SS) ||
					 IsEnabled(CustomComboPreset.DNC_ST_Simple_StandardFill)) &&
					HasEffect(Buffs.StandardStep))
				{
					return gauge.CompletedSteps < 2
						? gauge.NextStep
						: StandardFinish2;
				}

				if ((IsEnabled(CustomComboPreset.DNC_ST_Simple_TS) || IsEnabled(CustomComboPreset.DNC_ST_Simple_TechFill)) &&
					HasEffect(Buffs.TechnicalStep))
				{
					return gauge.CompletedSteps < 4
						? gauge.NextStep
						: TechnicalFinish4;
				}
				#endregion

				#region Weaves
				if (IsEnabled(CustomComboPreset.DNC_ST_Simple_Devilment) &&
					CanWeave(actionID) &&
					LevelChecked(Devilment) &&
					GetCooldownRemainingTime(Devilment) < 0.05 &&
					(HasEffect(Buffs.TechnicalFinish) ||
					 WasLastAction(TechnicalFinish4) ||
					 !LevelChecked(TechnicalStep)))
				{
					return Devilment;
				}

				if (IsEnabled(CustomComboPreset.DNC_ST_Simple_Flourish) &&
					CanWeave(actionID) &&
					ActionReady(Flourish) &&
					!WasLastWeaponskill(TechnicalFinish4) &&
					IsOnCooldown(Devilment) &&
					(GetCooldownRemainingTime(Devilment) > 50 ||
					 (HasEffect(Buffs.Devilment) &&
					  GetBuffRemainingTime(Buffs.Devilment) < 19)) &&
					!HasEffect(Buffs.ThreeFoldFanDance) &&
					!HasEffect(Buffs.FourFoldFanDance) &&
					!HasEffect(Buffs.FlourishingSymmetry) &&
					!HasEffect(Buffs.FlourishingFlow) &&
					!HasEffect(Buffs.FinishingMoveReady) &&
					((CombatEngageDuration().TotalSeconds < 20 &&
					  HasEffect(Buffs.TechnicalFinish)) ||
					 CombatEngageDuration().TotalSeconds > 20))
				{
					return Flourish;
				}

				if (IsEnabled(CustomComboPreset.DNC_ST_Simple_Interrupt) &&
					CanInterruptEnemy() &&
					ActionReady(All.HeadGraze) &&
					!HasEffect(Buffs.TechnicalFinish))
				{
					return All.HeadGraze;
				}

				if (IsEnabled(CustomComboPreset.DNC_Variant_Cure) &&
					IsEnabled(Variant.VariantCure) &&
					PlayerHealthPercentageHp() <= GetOptionValue(Config.DNCVariantCurePercent))
				{
					return Variant.VariantCure;
				}

				if (IsEnabled(CustomComboPreset.DNC_Variant_Rampart) &&
					IsEnabled(Variant.VariantRampart) &&
					IsOffCooldown(Variant.VariantRampart) &&
					CanWeave(actionID))
				{
					return Variant.VariantRampart;
				}

				if (CanWeave(actionID) && !WasLastWeaponskill(TechnicalFinish4))
				{
					if (HasEffect(Buffs.ThreeFoldFanDance))
					{
						return FanDance3;
					}

					if (HasEffect(Buffs.FourFoldFanDance))
					{
						return FanDance4;
					}

					if (IsEnabled(CustomComboPreset.DNC_ST_Simple_Feathers) &&
						LevelChecked(FanDance1))
					{
						if (GetTargetHPPercent() <= targetHpThresholdFeather && gauge.Feathers > 0)
						{
							return FanDance1;
						}

						if (LevelChecked(TechnicalStep))
						{
							if (HasEffect(Buffs.TechnicalFinish) && gauge.Feathers > 0)
							{
								return FanDance1;
							}

							if (gauge.Feathers > 3 &&
								(GetCooldownRemainingTime(TechnicalStep) > 2.5f ||
								 IsOffCooldown(TechnicalStep)))
							{
								return FanDance1;
							}
						}

						if (!LevelChecked(TechnicalStep) && gauge.Feathers > 0)
						{
							return FanDance1;
						}
					}

					if (IsEnabled(CustomComboPreset.DNC_ST_Simple_PanicHeals))
					{
						if (ActionReady(CuringWaltz) &&
							PlayerHealthPercentageHp() < PluginConfiguration.GetCustomIntValue(Config.DNCSimplePanicHealWaltzPercent))
						{
							return CuringWaltz;
						}

						if (ActionReady(All.SecondWind) &&
							PlayerHealthPercentageHp() < PluginConfiguration.GetCustomIntValue(Config.DNCSimplePanicHealWindPercent))
						{
							return All.SecondWind;
						}
					}

					if (IsEnabled(CustomComboPreset.DNC_ST_Simple_Improvisation) &&
						ActionReady(Improvisation) &&
						!HasEffect(Buffs.TechnicalFinish))
					{
						return Improvisation;
					}
				}
				#endregion

				#region GCD
				if (needToTech)
				{
					return TechnicalStep;
				}

				if (IsEnabled(CustomComboPreset.DNC_ST_Simple_LD) &&
					HasEffect(Buffs.LastDanceReady) &&
					(HasEffect(Buffs.TechnicalFinish) ||
					 !(IsOnCooldown(TechnicalStep) &&
					   GetCooldownRemainingTime(TechnicalStep) < 20 &&
					   GetBuffRemainingTime(Buffs.LastDanceReady) > GetCooldownRemainingTime(TechnicalStep) + 4) ||
					 GetBuffRemainingTime(Buffs.LastDanceReady) < 4))
				{
					return LastDance;
				}

				if (needToStandardOrFinish && needToFinish)
				{
					return OriginalHook(FinishingMove);
				}

				if (needToStandardOrFinish && needToStandard)
				{
					return StandardStep;
				}

				if (HasEffect(Buffs.FlourishingStarfall) &&
					GetBuffRemainingTime(Buffs.FlourishingStarfall) < 4)
				{
					return StarfallDance;
				}

				if (IsEnabled(CustomComboPreset.DNC_ST_Simple_DawnDance) &&
					HasEffect(Buffs.DanceOfTheDawnReady) &&
					LevelChecked(DanceOfTheDawn) &&
					(GetCooldownRemainingTime(TechnicalStep) > 5 ||
					 IsOffCooldown(TechnicalStep)) &&
					(gauge.Esprit >= PluginConfiguration.GetCustomIntValue(Config.DNCSimpleSaberThreshold) ||
					 (GetBuffRemainingTime(Buffs.DanceOfTheDawnReady) < 5 && gauge.Esprit >= 50)))
				{
					return OriginalHook(DanceOfTheDawn);
				}

				if (IsEnabled(CustomComboPreset.DNC_ST_Simple_SaberDance) &&
					LevelChecked(SaberDance) &&
					gauge.Esprit >= 80 &&
					ActionReady(SaberDance))
				{
					return SaberDance;
				}

				if (HasEffect(Buffs.FlourishingStarfall))
				{
					return StarfallDance;
				}

				if (HasEffect(Buffs.FlourishingFinish) &&
					IsEnabled(CustomComboPreset.DNC_ST_Simple_Tillana))
				{
					return Tillana;
				}

				if ((IsEnabled(CustomComboPreset.DNC_ST_Simple_SaberDance) &&
					LevelChecked(SaberDance) &&
					gauge.Esprit >= PluginConfiguration.GetCustomIntValue(Config.DNCSimpleSaberThreshold)) ||
					(HasEffect(Buffs.TechnicalFinish) && gauge.Esprit >= 50 &&
					(GetCooldownRemainingTime(TechnicalStep) > 5 ||
					 IsOffCooldown(TechnicalStep))))
				{
					return SaberDance;
				}

				if (LevelChecked(Fountain) &&
					lastComboMove is Cascade &&
					comboTime is < 2 and > 0)
				{
					return Fountain;
				}

				if (LevelChecked(Fountainfall) && flow)
				{
					return Fountainfall;
				}

				if (LevelChecked(ReverseCascade) && symmetry)
				{
					return ReverseCascade;
				}

				if (LevelChecked(Fountain) && lastComboMove is Cascade && comboTime > 0)
				{
					return Fountain;
				}
				#endregion

				return actionID;
			}
		}

		internal class DNC_ST_MultiButton : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.DNC_ST_MultiButton;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID is Cascade)
				{
					#region Types
					DNCGauge? gauge = GetJobGauge<DNCGauge>();
					bool flow = HasEffect(Buffs.SilkenFlow) || HasEffect(Buffs.FlourishingFlow);
					bool symmetry = HasEffect(Buffs.SilkenSymmetry) || HasEffect(Buffs.FlourishingSymmetry);
					#endregion

					if (IsEnabled(CustomComboPreset.DNC_ST_EspritOvercap) &&
						LevelChecked(DanceOfTheDawn) &&
						HasEffect(Buffs.DanceOfTheDawnReady) &&
						gauge.Esprit >= PluginConfiguration.GetCustomIntValue(Config.DNCEspritThreshold_ST))
					{
						return OriginalHook(DanceOfTheDawn);
					}

					if (IsEnabled(CustomComboPreset.DNC_ST_EspritOvercap) &&
						LevelChecked(SaberDance) &&
						gauge.Esprit >= PluginConfiguration.GetCustomIntValue(Config.DNCEspritThreshold_ST))
					{
						return SaberDance;
					}

					if (CanWeave(actionID))
					{
						if (IsEnabled(CustomComboPreset.DNC_ST_FanDanceOvercap) &&
							LevelChecked(FanDance1) && gauge.Feathers is 4)
						{
							return FanDance1;
						}

						if (IsEnabled(CustomComboPreset.DNC_ST_FanDance34))
						{
							if (HasEffect(Buffs.ThreeFoldFanDance))
							{
								return FanDance3;
							}

							if (HasEffect(Buffs.FourFoldFanDance))
							{
								return FanDance4;
							}
						}
					}

					if (LevelChecked(Fountainfall) && flow)
					{
						return Fountainfall;
					}

					if (LevelChecked(ReverseCascade) && symmetry)
					{
						return ReverseCascade;
					}

					if (LevelChecked(Fountain) && lastComboMove is Cascade)
					{
						return Fountain;
					}
				}

				return actionID;
			}
		}

		internal class DNC_AoE_SimpleMode : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.DNC_AoE_SimpleMode;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID is not Windmill)
				{
					return actionID;
				}

				#region Variables
				DNCGauge? gauge = GetJobGauge<DNCGauge>();

				bool flow = HasEffect(Buffs.SilkenFlow) || HasEffect(Buffs.FlourishingFlow);
				bool symmetry = HasEffect(Buffs.SilkenSymmetry) || HasEffect(Buffs.FlourishingSymmetry);
				int targetHpThresholdStandard = PluginConfiguration.GetCustomIntValue(Config.DNCSimpleSSAoEBurstPercent);
				int targetHpThresholdTechnical = PluginConfiguration.GetCustomIntValue(Config.DNCSimpleTSAoEBurstPercent);

				bool needToTech =
					IsEnabled(CustomComboPreset.DNC_AoE_Simple_TS) &&
					ActionReady(TechnicalStep) &&
					!HasEffect(Buffs.StandardStep) &&
					IsOnCooldown(StandardStep) &&
					GetTargetHPPercent() > targetHpThresholdTechnical &&
					LevelChecked(TechnicalStep);

				bool needToStandardOrFinish =
					IsEnabled(CustomComboPreset.DNC_AoE_Simple_SS) &&
					ActionReady(StandardStep) &&
					GetTargetHPPercent() > targetHpThresholdStandard &&
					(IsOffCooldown(TechnicalStep) ||
					 GetCooldownRemainingTime(TechnicalStep) > 5) &&
					LevelChecked(StandardStep);

				bool needToFinish =
					HasEffect(Buffs.FinishingMoveReady) &&
					!HasEffect(Buffs.LastDanceReady);

				bool needToStandard =
					!HasEffect(Buffs.FinishingMoveReady) &&
					(IsOffCooldown(Flourish) ||
					 GetCooldownRemainingTime(Flourish) > 5) &&
					!HasEffect(Buffs.TechnicalFinish);
				#endregion

				#region Dance Fills
				if ((IsEnabled(CustomComboPreset.DNC_AoE_Simple_SS) ||
					 IsEnabled(CustomComboPreset.DNC_AoE_Simple_StandardFill)) &&
					HasEffect(Buffs.StandardStep))
				{
					return gauge.CompletedSteps < 2
						? gauge.NextStep
						: StandardFinish2;
				}

				if ((IsEnabled(CustomComboPreset.DNC_AoE_Simple_TS) ||
					 IsEnabled(CustomComboPreset.DNC_AoE_Simple_TechFill)) &&
					HasEffect(Buffs.TechnicalStep))
				{
					return gauge.CompletedSteps < 4
						? gauge.NextStep
						: TechnicalFinish4;
				}
				#endregion

				#region Weaves
				if (IsEnabled(CustomComboPreset.DNC_AoE_Simple_Devilment) &&
					CanWeave(actionID) &&
					LevelChecked(Devilment) &&
					GetCooldownRemainingTime(Devilment) < 0.05 &&
					(HasEffect(Buffs.TechnicalFinish) ||
					 WasLastAction(TechnicalFinish4) ||
					 !LevelChecked(TechnicalStep)))
				{
					return Devilment;
				}

				if (IsEnabled(CustomComboPreset.DNC_AoE_Simple_Flourish) &&
					CanWeave(actionID) &&
					ActionReady(Flourish) &&
					!WasLastWeaponskill(TechnicalFinish4) &&
					IsOnCooldown(Devilment) &&
					(GetCooldownRemainingTime(Devilment) > 50 ||
					 (HasEffect(Buffs.Devilment) &&
					  GetBuffRemainingTime(Buffs.Devilment) < 19)) &&
					!HasEffect(Buffs.ThreeFoldFanDance) &&
					!HasEffect(Buffs.FourFoldFanDance) &&
					!HasEffect(Buffs.FlourishingSymmetry) &&
					!HasEffect(Buffs.FlourishingFlow) &&
					!HasEffect(Buffs.FinishingMoveReady))
				{
					return Flourish;
				}

				if (IsEnabled(CustomComboPreset.DNC_AoE_Simple_Interrupt) &&
					CanInterruptEnemy() && ActionReady(All.HeadGraze) &&
					!HasEffect(Buffs.TechnicalFinish))
				{
					return All.HeadGraze;
				}

				if (IsEnabled(CustomComboPreset.DNC_Variant_Cure) &&
					IsEnabled(Variant.VariantCure) &&
					PlayerHealthPercentageHp() <= GetOptionValue(Config.DNCVariantCurePercent))
				{
					return Variant.VariantCure;
				}

				if (IsEnabled(CustomComboPreset.DNC_Variant_Rampart) &&
					IsEnabled(Variant.VariantRampart) &&
					IsOffCooldown(Variant.VariantRampart) &&
					CanWeave(actionID))
				{
					return Variant.VariantRampart;
				}

				if (CanWeave(actionID) && !WasLastWeaponskill(TechnicalFinish4))
				{
					if (IsEnabled(CustomComboPreset.DNC_AoE_Simple_Feathers) &&
						LevelChecked(FanDance1))
					{
						if (HasEffect(Buffs.ThreeFoldFanDance))
						{
							return FanDance3;
						}

						if (LevelChecked(FanDance2))
						{
							if (LevelChecked(TechnicalStep))
							{
								if (HasEffect(Buffs.TechnicalFinish) &&
									gauge.Feathers > 0)
								{
									return FanDance2;
								}

								if (gauge.Feathers > 3 &&
									(GetCooldownRemainingTime(TechnicalStep) > 2.5f ||
									 IsOffCooldown(TechnicalStep)))
								{
									return FanDance2;
								}
							}

							if (!LevelChecked(TechnicalStep) &&
								gauge.Feathers > 0)
							{
								return FanDance2;
							}
						}

						if (!LevelChecked(FanDance2) &&
							gauge.Feathers > 0)
						{
							return FanDance1;
						}
					}

					if (HasEffect(Buffs.FourFoldFanDance))
					{
						return FanDance4;
					}

					if (IsEnabled(CustomComboPreset.DNC_AoE_Simple_PanicHeals))
					{
						if (ActionReady(CuringWaltz) &&
							PlayerHealthPercentageHp() < PluginConfiguration.GetCustomIntValue(Config.DNCSimpleAoEPanicHealWaltzPercent))
						{
							return CuringWaltz;
						}

						if (ActionReady(All.SecondWind) &&
							PlayerHealthPercentageHp() < PluginConfiguration.GetCustomIntValue(Config.DNCSimpleAoEPanicHealWindPercent))
						{
							return All.SecondWind;
						}
					}

					if (IsEnabled(CustomComboPreset.DNC_AoE_Simple_Improvisation) &&
						ActionReady(Improvisation) &&
						!HasEffect(Buffs.TechnicalStep))
					{
						return Improvisation;
					}
				}
				#endregion

				#region GCD
				if (needToTech)
				{
					return TechnicalStep;
				}

				if (IsEnabled(CustomComboPreset.DNC_AoE_Simple_LD) &&
					HasEffect(Buffs.LastDanceReady) &&
					(HasEffect(Buffs.TechnicalFinish) ||
					 !(IsOnCooldown(TechnicalStep) &&
					   GetCooldownRemainingTime(TechnicalStep) < 20 &&
					   GetBuffRemainingTime(Buffs.LastDanceReady) > GetCooldownRemainingTime(TechnicalStep) + 4) ||
					 GetBuffRemainingTime(Buffs.LastDanceReady) < 4))
				{
					return LastDance;
				}

				if (needToStandardOrFinish && needToFinish)
				{
					return OriginalHook(FinishingMove);
				}

				if (needToStandardOrFinish && needToStandard)
				{
					return StandardStep;
				}

				if (HasEffect(Buffs.FlourishingStarfall) &&
					GetBuffRemainingTime(Buffs.FlourishingStarfall) < 4)
				{
					return StarfallDance;
				}

				if (IsEnabled(CustomComboPreset.DNC_ST_Simple_DawnDance) &&
					HasEffect(Buffs.DanceOfTheDawnReady) &&
					LevelChecked(DanceOfTheDawn) &&
					(GetCooldownRemainingTime(TechnicalStep) > 5 ||
					 IsOffCooldown(TechnicalStep)) &&
					(gauge.Esprit >= PluginConfiguration.GetCustomIntValue(Config.DNCSimpleSaberThreshold) ||
					 (GetBuffRemainingTime(Buffs.DanceOfTheDawnReady) < 5 && gauge.Esprit >= 50)))
				{
					return OriginalHook(DanceOfTheDawn);
				}

				if (IsEnabled(CustomComboPreset.DNC_AoE_Simple_SaberDance) &&
					LevelChecked(SaberDance) &&
					gauge.Esprit >= 80 &&
					ActionReady(SaberDance))
				{
					return SaberDance;
				}

				if (HasEffect(Buffs.FlourishingStarfall))
				{
					return StarfallDance;
				}

				if (HasEffect(Buffs.FlourishingFinish) &&
					IsEnabled(CustomComboPreset.DNC_AoE_Simple_Tillana))
				{
					return Tillana;
				}

				if ((IsEnabled(CustomComboPreset.DNC_AoE_Simple_SaberDance) &&
					LevelChecked(SaberDance) &&
					gauge.Esprit >= PluginConfiguration.GetCustomIntValue(Config.DNCSimpleSaberThreshold)) ||
					(HasEffect(Buffs.TechnicalFinish) && gauge.Esprit >= 50 &&
					(GetCooldownRemainingTime(TechnicalStep) > 5 ||
					 IsOffCooldown(TechnicalStep))))
				{
					return SaberDance;
				}

				if (LevelChecked(Bladeshower) &&
					lastComboMove is Windmill &&
					comboTime is < 2 and > 0)
				{
					return Bladeshower;
				}

				if (LevelChecked(Bloodshower) && flow)
				{
					return Bloodshower;
				}

				if (LevelChecked(RisingWindmill) && symmetry)
				{
					return RisingWindmill;
				}

				if (LevelChecked(Bladeshower) && lastComboMove is Windmill && comboTime > 0)
				{
					return Bladeshower;
				}
				#endregion

				return actionID;
			}
		}

		internal class DNC_AoE_MultiButton : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.DNC_AoE_MultiButton;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID is Windmill)
				{
					#region Types
					DNCGauge? gauge = GetJobGauge<DNCGauge>();
					bool flow = HasEffect(Buffs.SilkenFlow) || HasEffect(Buffs.FlourishingFlow);
					bool symmetry = HasEffect(Buffs.SilkenSymmetry) || HasEffect(Buffs.FlourishingSymmetry);
					#endregion

					if (IsEnabled(CustomComboPreset.DNC_AoE_EspritOvercap) &&
						LevelChecked(DanceOfTheDawn) &&
						HasEffect(Buffs.DanceOfTheDawnReady) &&
						gauge.Esprit >= PluginConfiguration.GetCustomIntValue(Config.DNCEspritThreshold_ST))
					{
						return OriginalHook(DanceOfTheDawn);
					}

					if (IsEnabled(CustomComboPreset.DNC_AoE_EspritOvercap) &&
						LevelChecked(SaberDance) &&
						gauge.Esprit >= PluginConfiguration.GetCustomIntValue(Config.DNCEspritThreshold_AoE))
					{
						return SaberDance;
					}

					if (CanWeave(actionID))
					{
						if (IsEnabled(CustomComboPreset.DNC_AoE_FanDanceOvercap) &&
							LevelChecked(FanDance2) && gauge.Feathers is 4)
						{
							return FanDance2;
						}

						if (IsEnabled(CustomComboPreset.DNC_AoE_FanDance34))
						{
							if (HasEffect(Buffs.ThreeFoldFanDance))
							{
								return FanDance3;
							}

							if (HasEffect(Buffs.FourFoldFanDance))
							{
								return FanDance4;
							}
						}
					}

					if (LevelChecked(Bloodshower) && flow)
					{
						return Bloodshower;
					}

					if (LevelChecked(RisingWindmill) && symmetry)
					{
						return RisingWindmill;
					}

					if (LevelChecked(Bladeshower) && lastComboMove is Windmill)
					{
						return Bladeshower;
					}
				}

				return actionID;
			}
		}
	}
}
