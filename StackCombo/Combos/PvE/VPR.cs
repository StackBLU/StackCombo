using Dalamud.Game.ClientState.JobGauge.Enums;
using Dalamud.Game.ClientState.JobGauge.Types;
using StackCombo.ComboHelper.Functions;
using StackCombo.CustomCombo;

namespace StackCombo.Combos.PvE
{
	internal class VPR
	{
		public const byte JobID = 41;

		public const uint
			DreadFangs = 34607,
			DreadMaw = 34615,
			Dreadwinder = 34620,
			HuntersCoil = 34621,
			HuntersDen = 34624,
			HuntersSnap = 39166,
			PitofDread = 34623,
			RattlingCoil = 39189,
			Reawaken = 34626,
			SerpentsIre = 34647,
			SerpentsTail = 35920,
			Slither = 34646,
			SteelFangs = 34606,
			SteelMaw = 34614,
			SwiftskinsCoil = 34622,
			SwiftskinsDen = 34625,
			Twinblood = 35922,
			Twinfang = 35921,
			UncoiledFury = 34633,
			WrithingSnap = 34632,
			SwiftskinsSting = 34609,
			TwinfangBite = 34636,
			TwinbloodBite = 34637,
			UncoiledTwinfang = 34644,
			UncoiledTwinblood = 34645,
			HindstingStrike = 34612,
			DeathRattle = 34634,
			HuntersSting = 34608,
			HindsbaneFang = 34613,
			FlankstingStrike = 34610,
			FlanksbaneFang = 34611,
			HuntersBite = 34616,
			JaggedMaw = 34618,
			SwiftskinsBite = 34617,
			BloodiedMaw = 34619,
			FirstGeneration = 34627,
			FirstLegacy = 34640,
			SecondGeneration = 34628,
			SecondLegacy = 34641,
			ThirdGeneration = 34629,
			ThirdLegacy = 34642,
			FourthGeneration = 34630,
			FourthLegacy = 34643,
			Ouroboros = 34631,
			LastLash = 34635;

		public static class Buffs
		{
			public const ushort
				FellhuntersVenom = 3659,
				FellskinsVenom = 3660,
				FlanksbaneVenom = 3646,
				FlankstungVenom = 3645,
				HindstungVenom = 3647,
				HindsbaneVenom = 3648,
				GrimhuntersVenom = 3649,
				GrimskinsVenom = 3650,
				HuntersVenom = 3657,
				SwiftskinsVenom = 3658,
				HuntersInstinct = 3668,
				Swiftscaled = 3669,
				Reawakened = 3670,
				ReadyToReawaken = 3671,
				PoisedForTwinfang = 3665,
				PoisedForTwinblood = 3666;
		}

		public static class Debuffs
		{
			public const ushort
				NoxiousGnash = 3667;
		}

		public static class Traits
		{
			public const uint
				EnhancedVipersRattle = 530,
				EnhancedSerpentsLineage = 533,
				SerpentsLegacy = 534;
		}

		public static class Config
		{
			public static UserInt
				VPR_Positional = new("VPR_Positional");

			public static UserFloat
				VPR_ST_NoxiousDebuffRefresh = new("VPR_ST_NoxiousDebuffRefresh", 20.0f),
				VPR_AoE_NoxiousDebuffRefresh = new("VPR_AoE_NoxiousDebuffRefresh", 20.0f);
		}

		internal class VPR_ST_AdvancedMode : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.VPR_ST_AdvancedMode;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				VPRGauge? gauge = GetJobGauge<VPRGauge>();
				float ST_NoxiousDebuffRefresh = Config.VPR_ST_NoxiousDebuffRefresh;
				_ = Config.VPR_Positional;
				_ = gauge.DreadCombo == DreadCombo.Dreadwinder;
				_ = gauge.DreadCombo == DreadCombo.HuntersCoil;
				_ = gauge.DreadCombo == DreadCombo.SwiftskinsCoil;
				_ = GetCooldown(OriginalHook(DreadFangs)).CooldownTotal;

				if (actionID is SteelFangs)
				{
					if (IsEnabled(CustomComboPreset.VPR_ST_ReawakenCombo) &&
						HasEffect(Buffs.Reawakened))
					{
						if (!TraitLevelChecked(Traits.EnhancedSerpentsLineage))
						{
							if (gauge.AnguineTribute is 4)
							{
								return OriginalHook(SteelFangs);
							}

							if (gauge.AnguineTribute is 3)
							{
								return OriginalHook(DreadFangs);
							}

							if (gauge.AnguineTribute is 2)
							{
								return OriginalHook(HuntersCoil);
							}

							if (gauge.AnguineTribute is 1)
							{
								return OriginalHook(SwiftskinsCoil);
							}
						}

						if (TraitLevelChecked(Traits.EnhancedSerpentsLineage))
						{
							if (TraitLevelChecked(Traits.SerpentsLegacy) && CanWeave(actionID) &&
								(WasLastAction(OriginalHook(SteelFangs)) || WasLastAction(OriginalHook(DreadFangs)) ||
								WasLastAction(OriginalHook(HuntersCoil)) || WasLastAction(OriginalHook(SwiftskinsCoil))))
							{
								return OriginalHook(SerpentsTail);
							}

							if (gauge.AnguineTribute is 5)
							{
								return OriginalHook(SteelFangs);
							}

							if (gauge.AnguineTribute is 4)
							{
								return OriginalHook(DreadFangs);
							}

							if (gauge.AnguineTribute is 3)
							{
								return OriginalHook(HuntersCoil);
							}

							if (gauge.AnguineTribute is 2)
							{
								return OriginalHook(SwiftskinsCoil);
							}

							if (gauge.AnguineTribute is 1)
							{
								return OriginalHook(Reawaken);
							}
						}
					}

					if (comboTime > 0 && !HasEffect(Buffs.Reawakened))
					{
						if (lastComboMove is DreadFangs or SteelFangs)
						{
							if ((HasEffect(Buffs.FlankstungVenom) || HasEffect(Buffs.FlanksbaneVenom)) && LevelChecked(HuntersSting))
							{
								return OriginalHook(SteelFangs);
							}

							if ((HasEffect(Buffs.HindstungVenom) || HasEffect(Buffs.HindsbaneVenom) ||
								(!HasEffect(Buffs.Swiftscaled) && !HasEffect(Buffs.HuntersInstinct))) && LevelChecked(SwiftskinsSting))
							{
								return OriginalHook(DreadFangs);
							}
						}

						if (lastComboMove is HuntersSting or SwiftskinsSting)
						{
							if ((HasEffect(Buffs.FlankstungVenom) || HasEffect(Buffs.HindstungVenom)) && LevelChecked(FlanksbaneFang))
							{
								return OriginalHook(SteelFangs);
							}

							if ((HasEffect(Buffs.FlanksbaneVenom) || HasEffect(Buffs.HindsbaneVenom)) && LevelChecked(HindstingStrike))
							{
								return OriginalHook(DreadFangs);
							}
						}

						if (lastComboMove is HindstingStrike or HindsbaneFang or FlankstingStrike or FlanksbaneFang)
						{
							if (IsEnabled(CustomComboPreset.VPR_ST_SerpentsTail) &&
								CanWeave(actionID) && LevelChecked(SerpentsTail) && HasCharges(DeathRattle) &&
								(WasLastWeaponskill(HindstingStrike) || WasLastWeaponskill(HindsbaneFang) ||
								WasLastWeaponskill(FlankstingStrike) || WasLastWeaponskill(FlanksbaneFang)))
							{
								return OriginalHook(SerpentsTail);
							}
						}
						return IsEnabled(CustomComboPreset.VPR_ST_NoxiousGnash) &&
							(GetDebuffRemainingTime(Debuffs.NoxiousGnash) < ST_NoxiousDebuffRefresh)
							? OriginalHook(DreadFangs)
							: OriginalHook(SteelFangs);
					}
					return IsEnabled(CustomComboPreset.VPR_ST_NoxiousGnash) && LevelChecked(DreadFangs)
							? OriginalHook(DreadFangs)
							: OriginalHook(SteelFangs);
				}
				return actionID;
			}
		}

		internal class VPR_AoE_AdvancedMode : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.VPR_AoE_AdvancedMode;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				VPRGauge? gauge = GetJobGauge<VPRGauge>();
				float AoE_NoxiousDebuffRefresh = Config.VPR_AoE_NoxiousDebuffRefresh;
				_ = gauge.DreadCombo == DreadCombo.PitOfDread;
				_ = gauge.DreadCombo == DreadCombo.SwiftskinsDen;
				_ = gauge.DreadCombo == DreadCombo.HuntersDen;
				_ = GetCooldown(DreadMaw).CooldownTotal;

				if (actionID is SteelMaw)
				{
					if (IsEnabled(CustomComboPreset.VPR_AoE_ReawakenCombo) &&
						HasEffect(Buffs.Reawakened))
					{
						if (!TraitLevelChecked(Traits.EnhancedSerpentsLineage))
						{
							if (gauge.AnguineTribute is 4)
							{
								return OriginalHook(SteelMaw);
							}

							if (gauge.AnguineTribute is 3)
							{
								return OriginalHook(DreadMaw);
							}

							if (gauge.AnguineTribute is 2)
							{
								return OriginalHook(HuntersDen);
							}

							if (gauge.AnguineTribute is 1)
							{
								return OriginalHook(SwiftskinsDen);
							}
						}

						if (TraitLevelChecked(Traits.EnhancedSerpentsLineage))
						{
							if (TraitLevelChecked(Traits.SerpentsLegacy) && CanWeave(actionID) &&
								(WasLastAction(OriginalHook(SteelMaw)) || WasLastAction(OriginalHook(DreadMaw)) ||
								WasLastAction(OriginalHook(HuntersDen)) || WasLastAction(OriginalHook(SwiftskinsDen))))
							{
								return OriginalHook(SerpentsTail);
							}

							if (gauge.AnguineTribute is 5)
							{
								return OriginalHook(SteelMaw);
							}

							if (gauge.AnguineTribute is 4)
							{
								return OriginalHook(DreadMaw);
							}

							if (gauge.AnguineTribute is 3)
							{
								return OriginalHook(HuntersDen);
							}

							if (gauge.AnguineTribute is 2)
							{
								return OriginalHook(SwiftskinsDen);
							}

							if (gauge.AnguineTribute is 1)
							{
								return OriginalHook(Reawaken);
							}
						}
					}

					if (comboTime > 0 && !HasEffect(Buffs.Reawakened))
					{
						if (lastComboMove is DreadMaw or SteelMaw)
						{
							if (HasEffect(Buffs.GrimhuntersVenom) && LevelChecked(HuntersBite))
							{
								return OriginalHook(SteelMaw);
							}

							if ((HasEffect(Buffs.GrimskinsVenom) ||
								(!HasEffect(Buffs.Swiftscaled) && !HasEffect(Buffs.HuntersInstinct))) && LevelChecked(SwiftskinsBite))
							{
								return OriginalHook(DreadMaw);
							}
						}

						if (lastComboMove is HuntersBite or SwiftskinsBite)
						{
							if (HasEffect(Buffs.GrimhuntersVenom) && LevelChecked(JaggedMaw))
							{
								return OriginalHook(SteelMaw);
							}

							if (HasEffect(Buffs.GrimskinsVenom) && LevelChecked(BloodiedMaw))
							{
								return OriginalHook(DreadMaw);
							}
						}

						if (lastComboMove is BloodiedMaw or JaggedMaw)
						{
							if (IsEnabled(CustomComboPreset.VPR_AoE_SerpentsTail) &&
								CanWeave(actionID) && LevelChecked(SerpentsTail) && HasCharges(LastLash) &&
								(WasLastWeaponskill(BloodiedMaw) || WasLastWeaponskill(JaggedMaw)))
							{
								return OriginalHook(SerpentsTail);
							}
						}
						return IsEnabled(CustomComboPreset.VPR_AoE_NoxiousGnash) &&
							(GetDebuffRemainingTime(Debuffs.NoxiousGnash) < AoE_NoxiousDebuffRefresh)
							? OriginalHook(DreadMaw)
							: OriginalHook(SteelMaw);
					}
					return IsEnabled(CustomComboPreset.VPR_AoE_NoxiousGnash) &&
						LevelChecked(DreadMaw)
							? OriginalHook(DreadMaw)
							: OriginalHook(SteelMaw);
				}
				return actionID;
			}
		}

		internal class VPR_DreadwinderCoils : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.VPR_DreadwinderCoils;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				VPRGauge? gauge = GetJobGauge<VPRGauge>();
				int positionalChoice = Config.VPR_Positional;
				bool DreadwinderReady = gauge.DreadCombo == DreadCombo.Dreadwinder;
				bool HuntersCoilReady = gauge.DreadCombo == DreadCombo.HuntersCoil;
				bool SwiftskinsCoilReady = gauge.DreadCombo == DreadCombo.SwiftskinsCoil;

				if (actionID is Dreadwinder)
				{
					if (IsEnabled(CustomComboPreset.VPR_DreadwinderCoils_oGCDs))
					{
						if (HasEffect(Buffs.HuntersVenom))
						{
							return OriginalHook(Twinfang);
						}

						if (HasEffect(Buffs.SwiftskinsVenom))
						{
							return OriginalHook(Twinblood);
						}
					}

					if (positionalChoice is 0)
					{
						if (SwiftskinsCoilReady)
						{
							return HuntersCoil;
						}

						if (DreadwinderReady)
						{
							return SwiftskinsCoil;
						}
					}

					if (positionalChoice is 1)
					{
						if (HuntersCoilReady)
						{
							return SwiftskinsCoil;
						}

						if (DreadwinderReady)
						{
							return HuntersCoil;
						}
					}
				}
				return actionID;
			}
		}

		internal class VPR_PitOfDreadDens : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.VPR_PitOfDreadDens;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				VPRGauge? gauge = GetJobGauge<VPRGauge>();
				bool PitOfDreadReady = gauge.DreadCombo == DreadCombo.PitOfDread;
				bool SwiftskinsDenReady = gauge.DreadCombo == DreadCombo.SwiftskinsDen;

				if (actionID is PitofDread)
				{
					if (IsEnabled(CustomComboPreset.VPR_PitOfDreadDens_oGCDs))
					{
						if (HasEffect(Buffs.FellhuntersVenom))
						{
							return OriginalHook(Twinfang);
						}

						if (HasEffect(Buffs.FellskinsVenom))
						{
							return OriginalHook(Twinblood);
						}
					}

					if (SwiftskinsDenReady)
					{
						return HuntersDen;
					}

					if (PitOfDreadReady)
					{
						return SwiftskinsDen;
					}
				}
				return actionID;
			}
		}

		internal class VPR_UncoiledTwins : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.VPR_UncoiledTwins;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID is UncoiledFury)
				{
					if (HasEffect(Buffs.PoisedForTwinfang))
					{
						return OriginalHook(Twinfang);
					}

					if (HasEffect(Buffs.PoisedForTwinblood))
					{
						return OriginalHook(Twinblood);
					}
				}
				return actionID;
			}
		}
	}
}