using Dalamud.Game.ClientState.JobGauge.Types;
using StackCombo.ComboHelper.Functions;
using StackCombo.CustomCombo;

namespace StackCombo.Combos.PvE
{
	internal class VPR
	{
		public const byte JobID = 41;

		public const uint
			ReavingFangs = 34607,
			ReavingMaw = 34615,
			Vicewinder = 34620,
			HuntersCoil = 34621,
			HuntersDen = 34624,
			HuntersSnap = 39166,
			Vicepit = 34623,
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
			TwinbloodThresh = 34639,
			TwinfangThresh = 34638,
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
				PoisedForTwinblood = 3666,
				HonedReavers = 3772,
				HonedSteel = 3672;
		}

		public static class Traits
		{
			public const uint
				EnhancedVipersRattle = 530,
				EnhancedSerpentsLineage = 533,
				SerpentsLegacy = 534;
		}

		private static VPRGauge Gauge
		{
			get
			{
				return CustomComboFunctions.GetJobGauge<VPRGauge>();
			}
		}

		public static class Config
		{

		}

		internal class VPR_ST_DPS : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.VPR_ST_DPS;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID is SteelFangs or ReavingFangs && IsEnabled(CustomComboPreset.VPR_ST_DPS))
				{
					if (CanWeave(actionID))
					{
						if (ActionReady(OriginalHook(SerpentsTail)) && Gauge.SerpentCombo is Dalamud.Game.ClientState.JobGauge.Enums.SerpentCombo.DEATHRATTLE)
						{
							return DeathRattle;
						}

						if (ActionReady(OriginalHook(SerpentsTail)) &&
							(Gauge.SerpentCombo is Dalamud.Game.ClientState.JobGauge.Enums.SerpentCombo.FIRSTLEGACY ||
							Gauge.SerpentCombo is Dalamud.Game.ClientState.JobGauge.Enums.SerpentCombo.SECONDLEGACY ||
							Gauge.SerpentCombo is Dalamud.Game.ClientState.JobGauge.Enums.SerpentCombo.THIRDLEGACY ||
							Gauge.SerpentCombo is Dalamud.Game.ClientState.JobGauge.Enums.SerpentCombo.FOURTHLEGACY))
						{
							return OriginalHook(SerpentsTail);
						}
					}

					if (HasEffect(Buffs.Reawakened))
					{
						if (Gauge.AnguineTribute is 5)
						{
							return OriginalHook(SteelMaw);
						}

						if (Gauge.AnguineTribute is 4)
						{
							return OriginalHook(ReavingMaw);
						}

						if (Gauge.AnguineTribute is 3)
						{
							return OriginalHook(HuntersDen);
						}

						if (Gauge.AnguineTribute is 2)
						{
							return OriginalHook(SwiftskinsDen);
						}

						if (Gauge.AnguineTribute is 1)
						{
							return OriginalHook(Reawaken);
						}
					}

					if (comboTime > 0)
					{
						if (lastComboMove is SteelFangs or ReavingFangs)
						{
							if (!HasEffect(Buffs.Swiftscaled) || GetBuffRemainingTime(Buffs.Swiftscaled) < GetBuffRemainingTime(Buffs.HuntersInstinct))
							{
								return OriginalHook(SwiftskinsSting);
							}

							if (!HasEffect(Buffs.HuntersInstinct) || GetBuffRemainingTime(Buffs.HuntersInstinct) < GetBuffRemainingTime(Buffs.Swiftscaled))
							{
								return OriginalHook(HuntersSting);
							}
						}

						if (lastComboMove is SwiftskinsSting or HuntersSting)
						{
							if (HasEffect(Buffs.FlankstungVenom))
							{
								return OriginalHook(FlankstingStrike);
							}

							if (HasEffect(Buffs.FlanksbaneVenom))
							{
								return OriginalHook(FlanksbaneFang);
							}

							if (HasEffect(Buffs.HindstungVenom))
							{
								return OriginalHook(HindstingStrike);
							}

							if (HasEffect(Buffs.HindsbaneVenom))
							{
								return OriginalHook(HindsbaneFang);
							}

							if (!HasEffect(Buffs.FlankstungVenom) && !HasEffect(Buffs.FlanksbaneVenom)
								&& !HasEffect(Buffs.HindstungVenom) && !HasEffect(Buffs.HindsbaneVenom))
							{
								return OriginalHook(HindstingStrike);
							}
						}

						if (HasEffect(Buffs.HonedReavers))
						{
							return OriginalHook(ReavingFangs);
						}

						if (HasEffect(Buffs.HonedSteel))
						{
							return OriginalHook(SteelFangs);
						}
					}
					return SteelFangs;
				}
				return actionID;
			}
		}

		internal class VPR_AoE_DPS : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.VPR_AoE_DPS;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID is SteelMaw or ReavingMaw && IsEnabled(CustomComboPreset.VPR_AoE_DPS))
				{
					if (CanWeave(actionID))
					{
						if (Gauge.SerpentCombo is Dalamud.Game.ClientState.JobGauge.Enums.SerpentCombo.LASTLASH)
						{
							return LastLash;
						}
					}

					if (comboTime > 0)
					{
						if (lastComboMove is SteelMaw or ReavingMaw)
						{
							if (!HasEffect(Buffs.Swiftscaled) || GetBuffRemainingTime(Buffs.Swiftscaled) < GetBuffRemainingTime(Buffs.HuntersInstinct))
							{
								return OriginalHook(SwiftskinsBite);
							}

							if (!HasEffect(Buffs.HuntersInstinct) || GetBuffRemainingTime(Buffs.HuntersInstinct) < GetBuffRemainingTime(Buffs.Swiftscaled))
							{
								return OriginalHook(HuntersBite);
							}
						}

						if (lastComboMove is SwiftskinsBite or HuntersBite)
						{
							if (HasEffect(Buffs.GrimhuntersVenom))
							{
								return OriginalHook(JaggedMaw);
							}

							if (HasEffect(Buffs.GrimskinsVenom))
							{
								return OriginalHook(BloodiedMaw);
							}

							if (!HasEffect(Buffs.GrimhuntersVenom) && !HasEffect(Buffs.GrimskinsVenom))
							{
								return OriginalHook(BloodiedMaw);
							}
						}

						if (HasEffect(Buffs.HonedReavers))
						{
							return OriginalHook(ReavingMaw);
						}

						if (HasEffect(Buffs.HonedSteel))
						{
							return OriginalHook(SteelMaw);
						}
					}
					return SteelMaw;
				}
				return actionID;
			}
		}

		internal class VPR_Vicewinder : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.VPR_Vicewinder;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID is Vicewinder or HuntersCoil or SwiftskinsCoil && IsEnabled(CustomComboPreset.VPR_Vicewinder))
				{
					if (CanWeave(SwiftskinsCoil))
					{
						if (HasEffect(Buffs.SwiftskinsVenom))
						{
							return TwinbloodBite;
						}

						if (HasEffect(Buffs.HuntersVenom))
						{
							return TwinfangBite;
						}
					}

					if (WasLastWeaponskill(SwiftskinsCoil))
					{
						return HuntersCoil;
					}

					if (WasLastWeaponskill(Vicewinder))
					{
						return SwiftskinsCoil;
					}
				}
				return actionID;
			}
		}

		internal class VPR_Vicepit : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.VPR_Vicepit;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID is Vicepit or HuntersDen or SwiftskinsDen && IsEnabled(CustomComboPreset.VPR_Vicepit))
				{
					if (CanWeave(SwiftskinsDen))
					{
						if (HasEffect(Buffs.FellskinsVenom))
						{
							return TwinbloodThresh;
						}

						if (HasEffect(Buffs.FellhuntersVenom))
						{
							return TwinfangThresh;
						}
					}

					if (WasLastWeaponskill(SwiftskinsDen))
					{
						return HuntersDen;
					}

					if (WasLastWeaponskill(Vicepit))
					{
						return SwiftskinsDen;
					}
				}
				return actionID;
			}
		}

		internal class VPR_Uncoiled : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.VPR_Uncoiled;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID is UncoiledFury && IsEnabled(CustomComboPreset.VPR_Uncoiled))
				{
					if (CanWeave(UncoiledFury))
					{
						if (HasEffect(Buffs.PoisedForTwinfang))
						{
							return UncoiledTwinfang;
						}

						if (HasEffect(Buffs.PoisedForTwinblood))
						{
							return UncoiledTwinblood;
						}
					}
				}
				return actionID;
			}
		}
	}
}