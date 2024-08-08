using Dalamud.Game.ClientState.JobGauge.Types;
using StackCombo.ComboHelper.Functions;
using StackCombo.CustomCombo;

namespace StackCombo.Combos.PvE
{
	internal class DRG
	{
		public const byte JobID = 22;

		public const uint
			PiercingTalon = 90,
			ElusiveJump = 94,
			LanceCharge = 85,
			BattleLitany = 3557,
			Jump = 92,
			LifeSurge = 83,
			HighJump = 16478,
			MirageDive = 7399,
			BloodOfTheDragon = 3553,
			Stardiver = 16480,
			CoerthanTorment = 16477,
			DoomSpike = 86,
			SonicThrust = 7397,
			ChaosThrust = 88,
			RaidenThrust = 16479,
			TrueThrust = 75,
			Disembowel = 87,
			FangAndClaw = 3554,
			WheelingThrust = 3556,
			FullThrust = 84,
			VorpalThrust = 78,
			WyrmwindThrust = 25773,
			DraconianFury = 25770,
			ChaoticSpring = 25772,
			DragonfireDive = 96,
			Geirskogul = 3555,
			Nastrond = 7400,
			HeavensThrust = 25771,
			Drakesbane = 36952,
			RiseOfTheDragon = 36953,
			LanceBarrage = 36954,
			SpiralBlow = 36955,
			Starcross = 36956;

		public static class Buffs
		{
			public const ushort
				LanceCharge = 1864,
				BattleLitany = 786,
				DiveReady = 1243,
				RaidenThrustReady = 1863,
				PowerSurge = 2720,
				LifeSurge = 116,
				DraconianFire = 1863,
				NastrondReady = 3844,
				StarcrossReady = 3846,
				DragonsFlight = 3845;
		}

		public static class Debuffs
		{
			public const ushort
				ChaosThrust = 118,
				ChaoticSpring = 2719;
		}

		public static class Traits
		{
			public const uint
				EnhancedLifeSurge = 438;
		}

		public static DRGGauge Gauge
		{
			get
			{
				return CustomComboFunctions.GetJobGauge<DRGGauge>();
			}
		}

		public static class Config
		{

		}

		internal class DRG_ST_DPS : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.DRG_ST_DPS;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if ((actionID is TrueThrust or RaidenThrust or VorpalThrust or LanceBarrage or Disembowel or SpiralBlow or FullThrust
					or HeavensThrust or ChaosThrust or ChaoticSpring or FangAndClaw or WheelingThrust) && IsEnabled(CustomComboPreset.DRG_ST_DPS))
				{
					if (comboTime > 0)
					{
						if (lastComboMove is TrueThrust or RaidenThrust)
						{
							if ((ActionReady(ChaoticSpring) && GetDebuffRemainingTime(Debuffs.ChaoticSpring) < 7)
								|| (!ActionReady(ChaoticSpring) && GetDebuffRemainingTime(Debuffs.ChaosThrust) < 7))
							{
								return OriginalHook(Disembowel);
							}
							return OriginalHook(VorpalThrust);
						}

						if ((lastComboMove is Disembowel or SpiralBlow) && ActionReady(OriginalHook(ChaosThrust)))
						{
							return OriginalHook(ChaosThrust);
						}
						if ((lastComboMove is ChaosThrust or ChaoticSpring) && ActionReady(WheelingThrust))
						{
							return WheelingThrust;
						}

						if ((lastComboMove is VorpalThrust or LanceBarrage) && ActionReady(OriginalHook(FullThrust)))
						{
							return OriginalHook(FullThrust);
						}

						if ((lastComboMove is FullThrust or HeavensThrust) && ActionReady(FangAndClaw))
						{
							return FangAndClaw;
						}

						if ((lastComboMove is WheelingThrust or FangAndClaw) && ActionReady(Drakesbane))
						{
							return Drakesbane;
						}
					}
					return OriginalHook(TrueThrust);
				}
				return actionID;
			}
		}

		internal class DRG_AoE_DPS : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.DRG_AoE_DPS;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID is DoomSpike && IsEnabled(CustomComboPreset.DRG_AoE_DPS))
				{
					if (comboTime > 0)
					{
						if ((lastComboMove is DoomSpike or DraconianFury) && ActionReady(SonicThrust))
						{
							return SonicThrust;
						}

						if (lastComboMove is SonicThrust && ActionReady(CoerthanTorment))
						{
							return CoerthanTorment;
						}
					}
				}
				return actionID;
			}
		}
	}
}