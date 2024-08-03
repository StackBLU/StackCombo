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
				if (actionID is MoonFlute && HasEffect(Buffs.DPSMimicry) && !HasEffect(Buffs.ToadOil))
				{
					if (!HasEffect(Buffs.MoonFlute))
					{
						if (!HasEffect(Buffs.Whistle))
						{
							return Whistle;
						}

						if (IsSpellActive(Tingle) && !HasEffect(Buffs.Tingle))
						{
							return Tingle;
						}

						if (IsSpellActive(RoseOfDestruction) && GetCooldown(RoseOfDestruction).CooldownRemaining < 1f)
						{
							return RoseOfDestruction;
						}

						if (IsSpellActive(MoonFlute))
						{
							return MoonFlute;
						}
					}

					if (IsSpellActive(JKick) && IsOffCooldown(JKick))
					{
						return JKick;
					}

					if (IsSpellActive(TripleTrident) && IsOffCooldown(TripleTrident))
					{
						return TripleTrident;
					}

					if (IsSpellActive(Nightbloom) && IsOffCooldown(Nightbloom))
					{
						return Nightbloom;
					}

					if (IsEnabled(CustomComboPreset.BLU_MoonFluteOpener_DoTOpener))
					{
						if (!TargetHasEffectAny(Debuffs.BreathOfMagic) && (!TargetHasEffectAny(Debuffs.MortalFlame)))
						{
							if (WasLastAbility(Nightbloom) && !WasLastSpell(Bristle))
							{
								return Bristle;
							}
							if (IsSpellActive(FeatherRain) && IsOffCooldown(FeatherRain))
							{
								return FeatherRain;
							}

							if (IsSpellActive(SeaShanty) && IsOffCooldown(SeaShanty))
							{
								return SeaShanty;
							}

							if (!WasLastSpell(BreathOfMagic) && !WasLastSpell(MortalFlame))
							{
								if (IsSpellActive(BreathOfMagic))
								{
									return BreathOfMagic;
								}

								if (IsSpellActive(MortalFlame))
								{
									return MortalFlame;
								}
							}
						}
						if (WasLastAbility(ShockStrike) && !WasLastSpell(Bristle))
						{
							return Bristle;
						}
					}
					else
					{
						if (IsSpellActive(WingedReprobation) && IsOffCooldown(WingedReprobation)
							&& !WasLastSpell(WingedReprobation) && !WasLastAbility(FeatherRain)
							&& (!HasEffect(Buffs.WingedReprobation) || FindEffect(Buffs.WingedReprobation)?.StackCount < 2))
						{
							return WingedReprobation;
						}

						if (IsSpellActive(FeatherRain) && IsOffCooldown(FeatherRain))
						{
							return FeatherRain;
						}

						if (IsSpellActive(SeaShanty) && IsOffCooldown(SeaShanty))
						{
							return SeaShanty;
						}
					}



					if (IsSpellActive(WingedReprobation) && IsOffCooldown(WingedReprobation)
						&& !WasLastAbility(ShockStrike) && FindEffect(Buffs.WingedReprobation)?.StackCount < 2)
					{
						return WingedReprobation;
					}

					if (IsSpellActive(ShockStrike) && IsOffCooldown(ShockStrike))
					{
						return ShockStrike;
					}

					if (IsSpellActive(BeingMortal) && IsOffCooldown(BeingMortal) && IsNotEnabled(CustomComboPreset.BLU_MoonFluteOpener_DoTOpener))
					{
						return BeingMortal;
					}

					if (IsSpellActive(Bristle) && !HasEffect(Buffs.Bristle) && IsOffCooldown(MatraMagic) && IsSpellActive(MatraMagic) && WasLastAbility(BeingMortal))
					{
						return Bristle;
					}

					if (IsOffCooldown(All.Swiftcast) && WasLastSpell(Bristle))
					{
						return All.Swiftcast;
					}

					if (IsSpellActive(Surpanakha))
					{
						if (GetRemainingCharges(Surpanakha) > 0)
						{
							return Surpanakha;
						}
					}

					if (IsSpellActive(MatraMagic) && HasEffect(All.Buffs.Swiftcast))
					{
						return MatraMagic;
					}

					if (IsSpellActive(BeingMortal) && IsOffCooldown(BeingMortal) && IsEnabled(CustomComboPreset.BLU_MoonFluteOpener_DoTOpener))
					{
						return BeingMortal;
					}

					if (IsSpellActive(PhantomFlurry) && IsOffCooldown(PhantomFlurry))
					{
						return PhantomFlurry;
					}

					if (HasEffect(Buffs.MoonFlute))
					{
						return OriginalHook(11);
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
				if (actionID is TripleTrident && IsSpellActive(TripleTrident) && !IsSpellActive(MoonFlute))
				{
					if (GetCooldownRemainingTime(TripleTrident) > 3)
					{
						return TripleTrident;
					}
					if (!HasEffect(Buffs.Whistle))
					{
						return Whistle;
					}
					if (!HasEffect(Buffs.Tingle))
					{
						return Tingle;
					}
					if (HasEffect(Buffs.Whistle) && HasEffect(Buffs.Tingle))
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
				if (actionID is FinalSting && IsSpellActive(FinalSting))
				{
					if (!HasEffect(Buffs.Whistle))
					{
						return Whistle;
					}
					if (!TargetHasEffectAny(Debuffs.Offguard) && IsOffCooldown(Offguard))
					{
						return Offguard;
					}
					if (!HasEffect(Buffs.Tingle))
					{
						return Tingle;
					}
					if (!IsInParty() && !HasEffect(Buffs.BasicInstinct) && IsSpellActive(BasicInstinct))
					{
						return BasicInstinct;
					}
					if (!HasEffect(Buffs.MoonFlute))
					{
						return MoonFlute;
					}
					if (IsOffCooldown(All.Swiftcast))
					{
						return All.Swiftcast;
					}
					if (HasEffect(Buffs.Whistle) && HasEffect(Buffs.Tingle) && HasEffect(Buffs.MoonFlute))
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
				if (actionID is SelfDestruct && IsSpellActive(SelfDestruct))
				{
					if (!HasEffect(Buffs.ToadOil))
					{
						return ToadOil;
					}
					if (!HasEffect(Buffs.Bristle))
					{
						return Bristle;
					}
					if (!HasEffect(Buffs.MoonFlute))
					{
						return MoonFlute;
					}
					if (IsOffCooldown(All.Swiftcast))
					{
						return All.Swiftcast;
					}
					if (HasEffect(Buffs.ToadOil) && HasEffect(Buffs.Bristle) && HasEffect(Buffs.MoonFlute))
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
				if ((actionID is BreathOfMagic or MortalFlame or SongOfTorment or MatraMagic) && !IsSpellActive(MoonFlute))
				{
					if (!HasEffect(Buffs.Bristle))
					{
						return Bristle;
					}
					if (IsSpellActive(BreathOfMagic) && (!TargetHasEffectAny(Debuffs.BreathOfMagic) || GetDebuffRemainingTime(Debuffs.BreathOfMagic) < 3))
					{
						return BreathOfMagic;
					}
					if (IsSpellActive(MortalFlame) && !TargetHasEffectAny(Debuffs.MortalFlame))
					{
						return MortalFlame;
					}
					if (IsSpellActive(SongOfTorment) && (!TargetHasEffectAny(Debuffs.Bleeding) || GetDebuffRemainingTime(Debuffs.Bleeding) < 3))
					{
						return SongOfTorment;
					}
					if (IsSpellActive(MatraMagic) && ActionReady(MatraMagic))
					{
						return MatraMagic;
					}
					return Bristle;
				}
				return actionID;
			}
		}

		internal class BLU_Periph : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BLU_Periph;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID is PeripheralSynthesis or MustardBomb)
				{
					if (TargetHasEffectAny(Debuffs.MustardBomb))
					{
						return OriginalHook(11);
					}
					if (WasLastSpell(PeripheralSynthesis) || HasEffect(Buffs.Bristle))
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
				if (actionID is Ultravibration)
				{
					if (WasLastSpell(HydroPull))
					{
						return RamsVoice;
					}
					if (WasLastSpell(RamsVoice) && IsOffCooldown(All.Swiftcast))
					{
						return All.Swiftcast;
					}
					if (WasLastSpell(RamsVoice))
					{
						return Ultravibration;
					}
					return HydroPull;
				}
				return actionID;
			}
		}

		internal class BLU_ManaGain : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BLU_ManaGain;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID is GoblinPunch || actionID is SonicBoom)
				{
					if (IsEnabled(CustomComboPreset.BLU_Lucid) && ActionReady(All.LucidDreaming) && LocalPlayer.CurrentMp <= Config.BLU_Lucid)
					{
						return All.LucidDreaming;
					}
					if (LocalPlayer.CurrentMp <= Config.BLU_ManaGain)
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
				if (actionID is GoblinPunch)
				{
					if (!HasEffect(Buffs.MightyGuard))
					{
						return MightyGuard;
					}
					if (!HasEffect(Buffs.ToadOil))
					{
						return ToadOil;
					}
					if (IsOffCooldown(Devour))
					{
						return Devour;
					}
					if (IsEnabled(CustomComboPreset.BLU_Lucid) && ActionReady(All.LucidDreaming) && LocalPlayer.CurrentMp <= Config.BLU_Lucid)
					{
						return All.LucidDreaming;
					}
					if (!TargetHasEffect(Debuffs.PeatPelt) && !HasEffect(Buffs.DeepClean) && !WasLastSpell(PeatPelt))
					{
						return PeatPelt;
					}
					if (WasLastSpell(PeatPelt) || TargetHasEffect(Debuffs.PeatPelt))
					{
						return DeepClean;
					}
					if (HasEffect(Buffs.DeepClean))
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
				return actionID is AngelWhisper
					? IsOffCooldown(All.Swiftcast) ? All.Swiftcast : IsOffCooldown(AngelWhisper) ? AngelWhisper : All.Swiftcast
					: actionID;
			}
		}

		internal class BLU_Lucid : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BLU_Lucid;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID is SonicBoom || actionID is GoblinPunch || actionID is ChocoMeteor)
				{
					if (IsEnabled(CustomComboPreset.BLU_Lucid) && ActionReady(All.LucidDreaming) && LocalPlayer.CurrentMp <= 1000)
					{
						return All.LucidDreaming;
					}

					if (IsEnabled(CustomComboPreset.BLU_Lucid) && ActionReady(All.LucidDreaming) && CanSpellWeave(actionID) && LocalPlayer.CurrentMp <= Config.BLU_Lucid)
					{
						return All.LucidDreaming;
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
				if (actionID is GoblinPunch)
				{
					if (HasEffect(Buffs.MightyGuard) && !HasEffect(Buffs.TankMimicry) &&
						Svc.ClientState.TerritoryType != 712 && Svc.ClientState.TerritoryType != 794)
					{
						return MightyGuard;
					}
					if (Svc.ClientState.TerritoryType is 712 or 794)
					{
						if (IsEnabled(CustomComboPreset.BLU_TreasureMappin) && !IsInParty())
						{
							if (!HasEffect(Buffs.BasicInstinct))
							{
								return BasicInstinct;
							}
							if (!HasEffect(Buffs.MightyGuard))
							{
								return MightyGuard;
							}
						}
						if (IsEnabled(CustomComboPreset.BLU_TreasureMappin)
							&& LocalPlayer.CurrentHp / (float)LocalPlayer.MaxHp <= (float)Config.BLU_TreasureMappinHP * 0.01f)
						{
							return Pomcure;
						}
						if (IsEnabled(CustomComboPreset.BLU_TreasureMappin)
							&& (!HasEffect(Buffs.Gobskin) || LocalPlayer.ShieldPercentage < 10))
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