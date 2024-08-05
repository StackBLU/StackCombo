using ECommons.DalamudServices;
using StackCombo.ComboHelper.Functions;
using StackCombo.CustomCombo;

namespace StackCombo.Combos.PvE
{
	internal static class BLU
	{
		public const byte JobID = 36;

		public const uint
			RoseOfDestruction = 23275,
			ShockStrike = 11429,
			FeatherRain = 11426,
			JKick = 18325,
			PeculiarLight = 11421,
			Eruption = 11427,
			SharpenedKnife = 11400,
			GlassDance = 11430,
			SonicBoom = 18308,
			Surpanakha = 18323,
			Nightbloom = 23290,
			MoonFlute = 11415,
			Whistle = 18309,
			Tingle = 23265,
			TripleTrident = 23264,
			MatraMagic = 23285,
			FinalSting = 11407,
			Bristle = 11393,
			PhantomFlurry = 23288,
			PerpetualRay = 18314,
			AngelWhisper = 18317,
			SongOfTorment = 11386,
			RamsVoice = 11419,
			Ultravibration = 23277,
			Devour = 18320,
			Pomcure = 18303,
			Gobskin = 18304,
			Offguard = 11411,
			BadBreath = 11388,
			MagicHammer = 18305,
			WhiteKnightsTour = 18310,
			BlackKnightsTour = 18311,
			PeripheralSynthesis = 23286,
			BasicInstinct = 23276,
			HydroPull = 23282,
			MustardBomb = 23279,
			WingedReprobation = 34576,
			SeaShanty = 34580,
			BeingMortal = 34582,
			BreathOfMagic = 34567,
			MortalFlame = 34579,
			PeatPelt = 34569,
			DeepClean = 34570,
			GoblinPunch = 34563,
			BloodDrain = 11395,
			SelfDestruct = 11408,
			ToadOil = 11410,
			MightyGuard = 11417,
			ChocoMeteor = 23284;

		public static class Buffs
		{
			public const ushort
				MoonFlute = 1718,
				Bristle = 1716,
				WaningNocturne = 1727,
				PhantomFlurry = 2502,
				Tingle = 2492,
				Whistle = 2118,
				TankMimicry = 2124,
				DPSMimicry = 2125,
				BasicInstinct = 2498,
				ToadOil = 1737,
				MightyGuard = 1719,
				Devour = 2120,
				DeepClean = 3637,
				Gobskin = 2114,
				WingedReprobation = 3640;
		}

		public static class Debuffs
		{
			public const ushort
				Slow = 9,
				Bind = 13,
				Stun = 142,
				DeepFreeze = 1731,
				Offguard = 1717,
				Bleeding = 1714,
				Malodorous = 1715,
				MustardBomb = 2499,
				Conked = 2115,
				Lightheaded = 2501,
				MortalFlame = 3643,
				BreathOfMagic = 3712,
				PeatPelt = 3636;
		}

		public static class Config
		{
			public static UserInt
				BLU_Lucid = new("BLU_Lucid", 7500),
				BLU_TreasureMappinHP = new("BLU_TreasureMappinHP", 50),
				BLU_ManaGain = new("BLU_ManaGain", 7500);
		}

		internal class BLU_MoonFluteOpener : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BLU_MoonFluteOpener;

			protected override uint Invoke(uint actionID, uint lastComboActionID, float comboTime, byte level)
			{
				if (actionID is MoonFlute && IsEnabled(CustomComboPreset.BLU_MoonFluteOpener))
				{
					if (!HasEffect(Buffs.MoonFlute) && actionID is MoonFlute)
					{
						if (!HasEffect(Buffs.Whistle) && actionID is MoonFlute && IsSpellActive(Whistle))
						{
							return Whistle;
						}

						if (!HasEffect(Buffs.Tingle) && actionID is MoonFlute && IsSpellActive(Tingle))
						{
							return Tingle;
						}

						if (IsOffCooldown(RoseOfDestruction) && actionID is MoonFlute && IsSpellActive(RoseOfDestruction))
						{
							return RoseOfDestruction;
						}
						if (IsSpellActive(MoonFlute))
						{
							return MoonFlute;
						}
					}

					if (IsOffCooldown(JKick) && actionID is MoonFlute && IsSpellActive(JKick))
					{
						return JKick;
					}

					if (IsOffCooldown(TripleTrident) && actionID is MoonFlute && IsSpellActive(TripleTrident))
					{
						return TripleTrident;
					}

					if (IsOffCooldown(Nightbloom) && actionID is MoonFlute && IsSpellActive(Nightbloom))
					{
						return Nightbloom;
					}

					if (IsEnabled(CustomComboPreset.BLU_MoonFluteOpener_DoTOpener) && actionID is MoonFlute)
					{
						if (!TargetHasEffectAny(Debuffs.BreathOfMagic) && !TargetHasEffectAny(Debuffs.MortalFlame))
						{
							if (WasLastAbility(Nightbloom) && !WasLastSpell(Bristle) && actionID is MoonFlute && IsSpellActive(Bristle))
							{
								return Bristle;
							}
							if (IsOffCooldown(FeatherRain) && actionID is MoonFlute && IsSpellActive(FeatherRain))
							{
								return FeatherRain;
							}

							if (IsOffCooldown(SeaShanty) && actionID is MoonFlute && IsSpellActive(SeaShanty))
							{
								return SeaShanty;
							}

							if (!WasLastSpell(BreathOfMagic) && !WasLastSpell(MortalFlame) && actionID is MoonFlute)
							{
								if (IsSpellActive(BreathOfMagic) && actionID is MoonFlute && IsSpellActive(BreathOfMagic))
								{
									return BreathOfMagic;
								}

								if (IsSpellActive(MortalFlame) && actionID is MoonFlute && IsSpellActive(MortalFlame))
								{
									return MortalFlame;
								}
							}
						}
						if (IsOffCooldown(ShockStrike) && actionID is MoonFlute && IsSpellActive(ShockStrike))
						{
							return ShockStrike;
						}

						if (!HasEffect(Buffs.Bristle) && actionID is MoonFlute && IsSpellActive(Bristle))
						{
							return Bristle;
						}

						if (IsOffCooldown(All.Swiftcast) && WasLastSpell(Bristle) && actionID is MoonFlute)
						{
							return All.Swiftcast;
						}

						if (GetRemainingCharges(Surpanakha) > 0 && actionID is MoonFlute && IsSpellActive(Surpanakha))
						{
							return Surpanakha;
						}

						if (IsOffCooldown(MatraMagic) && actionID is MoonFlute && IsSpellActive(MatraMagic))
						{
							return MatraMagic;
						}

						if (IsOffCooldown(BeingMortal) && actionID is MoonFlute && IsSpellActive(BeingMortal))
						{
							return BeingMortal;
						}

						if (IsOffCooldown(PhantomFlurry) && actionID is MoonFlute && IsSpellActive(PhantomFlurry))
						{
							return PhantomFlurry;
						}

						if (HasEffect(Buffs.PhantomFlurry) && actionID is MoonFlute)
						{
							return OriginalHook(11);
						}
					}

					if (IsNotEnabled(CustomComboPreset.BLU_MoonFluteOpener_DoTOpener) && actionID is MoonFlute)
					{
						if (IsOffCooldown(WingedReprobation) && actionID is MoonFlute && IsSpellActive(WingedReprobation)
							&& !WasLastSpell(WingedReprobation) && !WasLastAbility(FeatherRain)
							&& (!HasEffect(Buffs.WingedReprobation) || FindEffect(Buffs.WingedReprobation).StackCount < 2))
						{
							return WingedReprobation;
						}

						if (IsOffCooldown(FeatherRain) && actionID is MoonFlute && IsSpellActive(FeatherRain))
						{
							return FeatherRain;
						}

						if (IsOffCooldown(SeaShanty) && actionID is MoonFlute && IsSpellActive(SeaShanty))
						{
							return SeaShanty;
						}

						if (IsOffCooldown(WingedReprobation) && actionID is MoonFlute && IsSpellActive(WingedReprobation)
							&& !WasLastAbility(ShockStrike) && FindEffect(Buffs.WingedReprobation).StackCount < 2)
						{
							return WingedReprobation;
						}

						if (IsOffCooldown(ShockStrike) && actionID is MoonFlute && IsSpellActive(ShockStrike))
						{
							return ShockStrike;
						}

						if (IsOffCooldown(BeingMortal) && actionID is MoonFlute && IsSpellActive(BeingMortal))
						{
							return BeingMortal;
						}

						if (!HasEffect(Buffs.Bristle) && actionID is MoonFlute && IsSpellActive(Bristle))
						{
							return Bristle;
						}

						if (IsOffCooldown(All.Swiftcast) && WasLastSpell(Bristle) && actionID is MoonFlute)
						{
							return All.Swiftcast;
						}

						if (GetRemainingCharges(Surpanakha) > 0 && actionID is MoonFlute && IsSpellActive(Surpanakha))
						{
							return Surpanakha;
						}

						if (IsOffCooldown(MatraMagic) && actionID is MoonFlute && IsSpellActive(MatraMagic))
						{
							return MatraMagic;
						}

						if (IsOffCooldown(PhantomFlurry) && actionID is MoonFlute && IsSpellActive(PhantomFlurry))
						{
							return PhantomFlurry;
						}

						if (HasEffect(Buffs.MoonFlute) && actionID is MoonFlute)
						{
							return OriginalHook(11);
						}
					}
				}
				return actionID;
			}
		}

		internal class BLU_TripleTrident : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BLU_TripleTrident;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID is TripleTrident && IsEnabled(CustomComboPreset.BLU_TripleTrident) && IsSpellActive(TripleTrident))
				{
					if (GetCooldownRemainingTime(TripleTrident) > 3 && actionID is TripleTrident)
					{
						return TripleTrident;
					}
					if (!HasEffect(Buffs.Whistle) && actionID is TripleTrident && IsSpellActive(Whistle))
					{
						return Whistle;
					}
					if (!HasEffect(Buffs.Tingle) && actionID is TripleTrident && IsSpellActive(Tingle))
					{
						return Tingle;
					}
					if (HasEffect(Buffs.Whistle) && HasEffect(Buffs.Tingle) && actionID is TripleTrident)
					{
						return TripleTrident;
					}
				}
				return actionID;
			}
		}

		internal class BLU_Sting : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BLU_Sting;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID is FinalSting && IsEnabled(CustomComboPreset.BLU_Sting) && IsSpellActive(FinalSting))
				{
					if (!HasEffect(Buffs.Whistle) && actionID is FinalSting && IsSpellActive(Whistle))
					{
						return Whistle;
					}
					if (!TargetHasEffectAny(Debuffs.Offguard) && IsOffCooldown(Offguard) && actionID is FinalSting && IsSpellActive(Offguard))
					{
						return Offguard;
					}
					if (!HasEffect(Buffs.Tingle) && actionID is FinalSting && IsSpellActive(Tingle))
					{
						return Tingle;
					}
					if (!HasEffect(Buffs.BasicInstinct) && IsSpellActive(BasicInstinct) && actionID is FinalSting)
					{
						return BasicInstinct;
					}
					if (!HasEffect(Buffs.MoonFlute) && actionID is FinalSting && IsSpellActive(ToadOil))
					{
						return ToadOil;
					}
					if (IsOffCooldown(All.Swiftcast) && actionID is FinalSting)
					{
						return All.Swiftcast;
					}
					if (HasEffect(Buffs.Whistle) && HasEffect(Buffs.Tingle) && HasEffect(Buffs.MoonFlute) && actionID is FinalSting)
					{
						return FinalSting;
					}
				}
				return actionID;
			}
		}

		internal class BLU_Explode : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BLU_Explode;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID is SelfDestruct && IsEnabled(CustomComboPreset.BLU_Explode) && IsSpellActive(SelfDestruct))
				{
					if (!HasEffect(Buffs.ToadOil) && actionID is SelfDestruct && IsSpellActive(ToadOil))
					{
						return ToadOil;
					}
					if (!HasEffect(Buffs.Bristle) && actionID is SelfDestruct && IsSpellActive(Bristle))
					{
						return Bristle;
					}
					if (!HasEffect(Buffs.MoonFlute) && actionID is SelfDestruct && IsSpellActive(BasicInstinct))
					{
						return BasicInstinct;
					}
					if (IsOffCooldown(All.Swiftcast) && actionID is SelfDestruct)
					{
						return All.Swiftcast;
					}
					if (HasEffect(Buffs.ToadOil) && HasEffect(Buffs.Bristle) && HasEffect(Buffs.MoonFlute) && actionID is SelfDestruct)
					{
						return SelfDestruct;
					}
				}
				return actionID;
			}
		}

		internal class BLU_DoTs : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BLU_DoTs;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if ((actionID is BreathOfMagic or MortalFlame or SongOfTorment or MatraMagic) && IsEnabled(CustomComboPreset.BLU_DoTs))
				{
					if (!HasEffect(Buffs.Bristle) && IsSpellActive(Bristle) && (actionID is BreathOfMagic or MortalFlame or SongOfTorment or MatraMagic))
					{
						return Bristle;
					}
					if (IsSpellActive(BreathOfMagic) && IsSpellActive(BreathOfMagic) && (actionID is BreathOfMagic or MortalFlame or SongOfTorment or MatraMagic) && (!TargetHasEffectAny(Debuffs.BreathOfMagic) || GetDebuffRemainingTime(Debuffs.BreathOfMagic) < 3))
					{
						return BreathOfMagic;
					}
					if (IsSpellActive(MortalFlame) && IsSpellActive(MortalFlame) && !TargetHasEffectAny(Debuffs.MortalFlame) && (actionID is BreathOfMagic or MortalFlame or SongOfTorment or MatraMagic))
					{
						return MortalFlame;
					}
					if (IsSpellActive(SongOfTorment) && IsSpellActive(SongOfTorment) && (actionID is BreathOfMagic or MortalFlame or SongOfTorment or MatraMagic) && (!TargetHasEffectAny(Debuffs.Bleeding) || GetDebuffRemainingTime(Debuffs.Bleeding) < 3))
					{
						return SongOfTorment;
					}
					if (IsSpellActive(MatraMagic) && IsSpellActive(MatraMagic) && ActionReady(MatraMagic) && (actionID is BreathOfMagic or MortalFlame or SongOfTorment or MatraMagic))
					{
						return MatraMagic;
					}
				}
				return actionID;
			}
		}

		internal class BLU_Periph : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BLU_Periph;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if ((actionID is PeripheralSynthesis or MustardBomb) && IsEnabled(CustomComboPreset.BLU_Periph))
				{
					if (IsSpellActive(MustardBomb) && (WasLastSpell(PeripheralSynthesis) || HasEffect(Buffs.Bristle) || TargetHasEffectAny(Debuffs.MustardBomb)))
					{
						return MustardBomb;
					}
					return PeripheralSynthesis;
				}
				return actionID;
			}
		}

		internal class BLU_Ultravibration : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BLU_Ultravibration;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if ((actionID is HydroPull or RamsVoice or Ultravibration) && IsEnabled(CustomComboPreset.BLU_Ultravibration))
				{
					if (IsSpellActive(HydroPull) && !WasLastSpell(HydroPull))
					{
						return HydroPull;
					}
					if (IsSpellActive(RamsVoice) && (WasLastSpell(HydroPull) || !WasLastSpell(RamsVoice)))
					{
						return RamsVoice;
					}
					if (WasLastSpell(RamsVoice) && IsOffCooldown(All.Swiftcast))
					{
						return All.Swiftcast;
					}
					if (IsSpellActive(Ultravibration) && WasLastSpell(RamsVoice))
					{
						return Ultravibration;
					}
				}
				return actionID;
			}
		}

		internal class BLU_ManaGain : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BLU_ManaGain;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if ((actionID is GoblinPunch or SonicBoom or ChocoMeteor) && IsEnabled(CustomComboPreset.BLU_ManaGain))
				{
					if (ActionReady(All.LucidDreaming) && LocalPlayer.CurrentMp <= 1000)
					{
						return All.LucidDreaming;
					}
					if (ActionReady(All.LucidDreaming) && CanSpellWeave(actionID) && LocalPlayer.CurrentMp <= Config.BLU_Lucid)
					{
						return All.LucidDreaming;
					}
					if (LocalPlayer.CurrentMp <= Config.BLU_ManaGain && IsSpellActive(BloodDrain))
					{
						return BloodDrain;
					}
				}
				return actionID;
			}
		}

		internal class BLU_Tanking : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BLU_Tanking;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID is GoblinPunch && IsEnabled(CustomComboPreset.BLU_Tanking))
				{
					if (!HasEffect(Buffs.MightyGuard) && IsSpellActive(MightyGuard))
					{
						return MightyGuard;
					}
					if (!HasEffect(Buffs.ToadOil) && IsSpellActive(ToadOil))
					{
						return ToadOil;
					}
					if (IsOffCooldown(Devour) & InMeleeRange() && IsSpellActive(Devour))
					{
						return Devour;
					}
					if (IsOffCooldown(PeculiarLight) & InMeleeRange() && IsSpellActive(PeculiarLight))
					{
						return PeculiarLight;
					}
					if (!TargetHasEffect(Debuffs.PeatPelt) && !HasEffect(Buffs.DeepClean) && !WasLastSpell(PeatPelt) && IsSpellActive(PeatPelt))
					{
						return PeatPelt;
					}
					if ((WasLastSpell(PeatPelt) || TargetHasEffect(Debuffs.PeatPelt)) && IsSpellActive(DeepClean))
					{
						return DeepClean;
					}
					if (HasEffect(Buffs.DeepClean) && IsSpellActive(GoblinPunch))
					{
						return GoblinPunch;
					}
				}
				return actionID;
			}
		}

		internal class BLU_Raise : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BLU_Raise;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID is AngelWhisper && IsEnabled(CustomComboPreset.BLU_Raise))
				{
					if (IsOffCooldown(All.Swiftcast))
					{
						return All.Swiftcast;
					}
					if (IsSpellActive(AngelWhisper))
					{
						return AngelWhisper;
					}
				}
				return actionID;
			}
		}

		internal class BLU_TreasureMappin : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BLU_TreasureMappin;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID is GoblinPunch && IsEnabled(CustomComboPreset.BLU_TreasureMappin))
				{
					if (HasEffect(Buffs.MightyGuard) && !HasEffect(Buffs.TankMimicry) &&
						Svc.ClientState.TerritoryType != 712 && Svc.ClientState.TerritoryType != 794 && IsSpellActive(MightyGuard))
					{
						return MightyGuard;
					}
					if (HasEffect(Buffs.PhantomFlurry) && IsSpellActive(PhantomFlurry))
					{
						if (GetBuffRemainingTime(Buffs.PhantomFlurry) <= 0.75f)
						{
							return OriginalHook(PhantomFlurry);
						}
						return OriginalHook(11);
					}
					if (Svc.ClientState.TerritoryType is 712 or 794)
					{
						if (!IsInParty())
						{
							if (!HasEffect(Buffs.BasicInstinct) && IsSpellActive(BasicInstinct))
							{
								return BasicInstinct;
							}
							if (!HasEffect(Buffs.MightyGuard) && IsSpellActive(MightyGuard))
							{
								return MightyGuard;
							}
						}
						if (PlayerHealthPercentageHp() <= (float)Config.BLU_TreasureMappinHP * 0.01f && IsSpellActive(Pomcure))
						{
							return Pomcure;
						}
						if ((!HasEffect(Buffs.Gobskin) || LocalPlayer.ShieldPercentage < 10) && IsSpellActive(Gobskin))
						{
							return Gobskin;
						}
					}
				}
				return actionID;
			}
		}
	}
}