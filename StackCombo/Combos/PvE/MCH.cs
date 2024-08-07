using Dalamud.Game.ClientState.JobGauge.Types;
using StackCombo.ComboHelper.Functions;
using StackCombo.CustomCombo;

namespace StackCombo.Combos.PvE
{
	internal class MCH
	{
		public const byte JobID = 31;

		public const uint
			CleanShot = 2873,
			HeatedCleanShot = 7413,
			SplitShot = 2866,
			HeatedSplitShot = 7411,
			SlugShot = 2868,
			HeatedSlugShot = 7412,
			GaussRound = 2874,
			Ricochet = 2890,
			Reassemble = 2876,
			Drill = 16498,
			HotShot = 2872,
			AirAnchor = 16500,
			Hypercharge = 17209,
			Heatblast = 7410,
			SpreadShot = 2870,
			Scattergun = 25786,
			AutoCrossbow = 16497,
			RookAutoturret = 2864,
			RookOverdrive = 7415,
			AutomatonQueen = 16501,
			QueenOverdrive = 16502,
			Tactician = 16889,
			Chainsaw = 25788,
			Bioblaster = 16499,
			BarrelStabilizer = 7414,
			Wildfire = 2878,
			Dismantle = 2887,
			Flamethrower = 7418,
			BlazingShot = 36978,
			DoubleCheck = 36979,
			CheckMate = 36980,
			Excavator = 36981,
			FullMetalField = 36982;

		public static class Buffs
		{
			public const ushort
				Reassembled = 851,
				Tactician = 1951,
				Wildfire = 1946,
				Overheated = 2688,
				Flamethrower = 1205,
				Hypercharged = 3864,
				ExcavatorReady = 3865,
				FullMetalMachinist = 3866;
		}

		public static class Debuffs
		{
			public const ushort
				Dismantled = 860,
				Bioblaster = 1866;
		}

		public static class Traits
		{
			public const ushort
				EnhancedMultiWeapon = 605;
		}

		private static MCHGauge Gauge
		{
			get
			{
				return CustomComboFunctions.GetJobGauge<MCHGauge>();
			}
		}

		public static class Config
		{
			public static UserInt
				MCH_ST_SecondWindThreshold = new("MCH_ST_SecondWindThreshold", 25);
		}

		internal class MCH_ST_DPS : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.MCH_ST_DPS;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID is SplitShot or SlugShot or CleanShot or HeatedSplitShot or HeatedSlugShot or HeatedCleanShot && IsEnabled(CustomComboPreset.MCH_ST_DPS))
				{
					if (CanWeave(actionID))
					{
						if (IsEnabled(CustomComboPreset.MCH_ST_Wildfire) && ActionReady(Wildfire)
							&& (Gauge.Heat == 100 || HasEffect(Buffs.Hypercharged) || HasEffect(Buffs.Overheated)))
						{
							return Wildfire;
						}

						if (IsEnabled(CustomComboPreset.MCH_ST_HeatProtect) && !HasEffect(Buffs.Overheated) && ActionReady(Hypercharge)
						&& (Gauge.Heat == 100 || HasEffect(Buffs.Hypercharged)))
						{
							return Hypercharge;
						}

						if (IsEnabled(CustomComboPreset.MCH_ST_QueenProtect) && ActionReady(OriginalHook(AutomatonQueen)) && Gauge.Battery == 100)
						{
							return OriginalHook(AutomatonQueen);
						}
					}

					if (IsEnabled(CustomComboPreset.MCH_ST_HeatBlast) && ActionReady(OriginalHook(Heatblast)) && HasEffect(Buffs.Overheated))
					{
						return OriginalHook(Heatblast);
					}

					if (comboTime > 0)
					{
						if (lastComboMove is SplitShot or HeatedSplitShot && ActionReady(OriginalHook(SlugShot)))
						{
							return OriginalHook(SlugShot);
						}

						if (lastComboMove is SlugShot or HeatedSlugShot && ActionReady(OriginalHook(CleanShot)))
						{
							return OriginalHook(CleanShot);
						}
					}
					return OriginalHook(SplitShot);
				}
				return actionID;
			}
		}

		internal class MCH_AoE_DPS : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.MCH_AoE_DPS;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID is SpreadShot or Scattergun or AutoCrossbow && IsEnabled(CustomComboPreset.MCH_AoE_DPS))
				{
					if (CanWeave(actionID))
					{
						if (IsEnabled(CustomComboPreset.MCH_AoE_HeatProtect) && !HasEffect(Buffs.Overheated) && ActionReady(Hypercharge)
							&& (Gauge.Heat == 100 || HasEffect(Buffs.Hypercharged)))
						{
							return Hypercharge;
						}

						if (IsEnabled(CustomComboPreset.MCH_AoE_QueenProtect) && ActionReady(OriginalHook(AutomatonQueen)) && Gauge.Battery == 100)
						{
							return OriginalHook(AutomatonQueen);
						}

						if (IsEnabled(CustomComboPreset.MCH_AoE_GaussRicochet) && HasEffect(Buffs.Overheated))
						{
							if (ActionReady(OriginalHook(GaussRound)) && GetRemainingCharges(OriginalHook(GaussRound)) >= GetRemainingCharges(OriginalHook(Ricochet)))
							{
								return OriginalHook(GaussRound);
							}

							if (ActionReady(OriginalHook(Ricochet)) && GetRemainingCharges(OriginalHook(Ricochet)) > GetRemainingCharges(OriginalHook(GaussRound)))
							{
								return OriginalHook(Ricochet);
							}
						}
					}

					if (IsEnabled(CustomComboPreset.MCH_AoE_Bioblaster) && ActionReady(Bioblaster) && !HasEffect(Buffs.Overheated))
					{
						return Bioblaster;
					}

					if (IsEnabled(CustomComboPreset.MCH_AoE_AutoCrossbow) && ActionReady(AutoCrossbow) && HasEffect(Buffs.Overheated))
					{
						return AutoCrossbow;
					}

					if (ActionReady(OriginalHook(Scattergun)))
					{
						return OriginalHook(Scattergun);
					}
				}
				return actionID;
			}
		}

		internal class MCH_GaussRoundRicochet : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.MCH_GaussRicochet;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID is GaussRound or Ricochet or CheckMate or DoubleCheck && IsEnabled(CustomComboPreset.MCH_GaussRicochet))
				{
					if (ActionReady(OriginalHook(GaussRound)) && GetRemainingCharges(OriginalHook(GaussRound)) >= GetRemainingCharges(OriginalHook(Ricochet)))
					{
						return OriginalHook(GaussRound);
					}

					if (ActionReady(OriginalHook(Ricochet)) && GetRemainingCharges(OriginalHook(Ricochet)) > GetRemainingCharges(OriginalHook(GaussRound)))
					{
						return OriginalHook(Ricochet);
					}
				}
				return actionID;
			}
		}

		internal class MCH_DismantleProtect : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.MCH_DismantleProtect;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID is Dismantle && IsEnabled(CustomComboPreset.MCH_DismantleProtect))
				{
					if (TargetHasEffectAny(Debuffs.Dismantled))
					{
						return OriginalHook(11);
					}
				}
				return actionID;
			}
		}
	}
}