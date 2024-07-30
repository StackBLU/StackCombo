using Dalamud.Game.ClientState.Statuses;
using StackCombo.ComboHelper.Functions;
using StackCombo.Combos.JobHelpers;
using StackCombo.Combos.PvE.Content;
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

		public static class Config
		{
			public static UserInt
				DRG_Variant_Cure = new("DRG_VariantCure");
		}

		internal class DRG_ST_AdvancedMode : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.DRG_ST_AdvancedMode;
			internal static DRGOpenerLogic DRGOpener = new();
			private readonly float GCD = GetCooldown(TrueThrust).CooldownTotal;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				Status? ChaosDoTDebuff;

				ChaosDoTDebuff = LevelChecked(ChaoticSpring) ? FindTargetEffect(Debuffs.ChaoticSpring) : FindTargetEffect(Debuffs.ChaosThrust);

				if (actionID is TrueThrust)
				{
					if (IsEnabled(CustomComboPreset.DRG_Variant_Cure) &&
						IsEnabled(Variant.VariantCure) &&
						PlayerHealthPercentageHp() <= Config.DRG_Variant_Cure)
					{
						return Variant.VariantCure;
					}

					if (IsEnabled(CustomComboPreset.DRG_Variant_Rampart) &&
						IsEnabled(Variant.VariantRampart) &&
						IsOffCooldown(Variant.VariantRampart) &&
						AnimationLock.CanDRGWeave(Variant.VariantRampart))
					{
						return Variant.VariantRampart;
					}

					if (comboTime > 0)
					{
						if (lastComboMove is TrueThrust or RaidenThrust)
						{
							return ChaosDoTDebuff is null || ChaosDoTDebuff.RemainingTime < 5 ? OriginalHook(Disembowel) : OriginalHook(VorpalThrust);
						}

						if (lastComboMove is Disembowel or SpiralBlow && LevelChecked(OriginalHook(ChaosThrust)))
						{
							return OriginalHook(ChaosThrust);
						}
						if (lastComboMove is ChaosThrust or ChaoticSpring && LevelChecked(WheelingThrust))
						{
							return WheelingThrust;
						}

						if (lastComboMove is VorpalThrust or LanceBarrage && LevelChecked(OriginalHook(FullThrust)))
						{
							return OriginalHook(FullThrust);
						}

						if (lastComboMove is FullThrust or HeavensThrust && LevelChecked(FangAndClaw))
						{
							return FangAndClaw;
						}

						if (lastComboMove is WheelingThrust or FangAndClaw && LevelChecked(Drakesbane))
						{
							return Drakesbane;
						}
					}
					return OriginalHook(TrueThrust);
				}
				return actionID;
			}
		}

		internal class DRG_AOE_AdvancedMode : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.DRG_AOE_AdvancedMode;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID is DoomSpike)
				{
					if (IsEnabled(CustomComboPreset.DRG_Variant_Cure) &&
						IsEnabled(Variant.VariantCure) &&
						PlayerHealthPercentageHp() <= Config.DRG_Variant_Cure)
					{
						return Variant.VariantCure;
					}

					if (IsEnabled(CustomComboPreset.DRG_Variant_Rampart) &&
						IsEnabled(Variant.VariantRampart) &&
						IsOffCooldown(Variant.VariantRampart) &&
						AnimationLock.CanDRGWeave(Variant.VariantRampart))
					{
						return Variant.VariantRampart;
					}

					if (comboTime > 0)
					{
						if (lastComboMove is DoomSpike or DraconianFury && LevelChecked(SonicThrust))
						{
							return SonicThrust;
						}

						if (lastComboMove is SonicThrust && LevelChecked(CoerthanTorment))
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