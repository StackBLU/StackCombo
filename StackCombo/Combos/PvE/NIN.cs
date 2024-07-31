using Dalamud.Game.ClientState.JobGauge.Types;
using Dalamud.Game.ClientState.Statuses;
using StackCombo.Combos.PvE.Content;
using StackCombo.Core;
using StackCombo.CustomCombo;
using StackCombo.Data;
using StackCombo.Extensions;

namespace StackCombo.Combos.PvE
{
	internal class NIN
	{
		public const byte JobID = 30;

		public const uint
			SpinningEdge = 2240,
			ShadeShift = 2241,
			GustSlash = 2242,
			Hide = 2245,
			Assassinate = 2246,
			ThrowingDaggers = 2247,
			Mug = 2248,
			DeathBlossom = 2254,
			AeolianEdge = 2255,
			TrickAttack = 2258,
			Kassatsu = 2264,
			ArmorCrush = 3563,
			DreamWithinADream = 3566,
			TenChiJin = 7403,
			Bhavacakra = 7402,
			HakkeMujinsatsu = 16488,
			Meisui = 16489,
			Bunshin = 16493,
			PhantomKamaitachi = 25774,
			ForkedRaiju = 25777,
			FleetingRaiju = 25778,
			Hellfrog = 7401,
			HollowNozuchi = 25776,

			Ninjutsu = 2260,
			Rabbit = 2272,

			Ten = 2259,
			Chi = 2261,
			Jin = 2263,

			TenCombo = 18805,
			ChiCombo = 18806,
			JinCombo = 18807,

			FumaShuriken = 2265,
			Hyoton = 2268,
			Doton = 2270,
			Katon = 2266,
			Suiton = 2271,
			Raiton = 2267,
			Huton = 2269,
			GokaMekkyaku = 16491,
			HyoshoRanryu = 16492,

			TCJFumaShurikenTen = 18873,
			TCJFumaShurikenChi = 18874,
			TCJFumaShurikenJin = 18875,
			TCJKaton = 18876,
			TCJRaiton = 18877,
			TCJHyoton = 18878,
			TCJHuton = 18879,
			TCJDoton = 18880,
			TCJSuiton = 18881;

		public static class Buffs
		{
			public const ushort
				Mudra = 496,
				Kassatsu = 497,
				Suiton = 507,
				Hidden = 614,
				TenChiJin = 1186,
				AssassinateReady = 1955,
				RaijuReady = 2690,
				PhantomReady = 2723,
				Meisui = 2689,
				Doton = 501,
				Bunshin = 1954;
		}

		public static class Debuffs
		{
			public const ushort
				TrickAttack = 3254,
				Mug = 638;
		}

		public static class Traits
		{
			public const uint
				EnhancedKasatsu = 250;
		}

		public static class Config
		{
			public const string
				Trick_CooldownRemaining = "Trick_CooldownRemaining",
				Huton_RemainingHuraijinST = "Huton_RemainingHuraijinST",
				Huton_RemainingHuraijinAoE = "Huton_RemainingHuraijinAoE",
				Huton_RemainingArmorCrush = "Huton_RemainingArmorCrush",
				Mug_NinkiGauge = "Mug_NinkiGauge",
				Ninki_BhavaPooling = "Ninki_BhavaPooling",
				Ninki_HellfrogPooling = "Ninki_HellfrogPooling",
				NIN_SimpleMudra_Choice = "NIN_SimpleMudra_Choice",
				Ninki_BunshinPoolingST = "Ninki_BunshinPoolingST",
				Ninki_BunshinPoolingAoE = "Ninki_BunshinPoolingAoE",
				Advanced_Trick_Cooldown = "Advanced_Trick_Cooldown",
				Advanced_DoubleArmorCrush = "Advanced_DoubleArmorCrush",
				Advanced_DotonTimer = "Advanced_DotonTimer",
				Advanced_DotonHP = "Advanced_DotonHP",
				Advanced_TCJEnderAoE = "Advanced_TCJEnderAoe",
				Advanced_ChargePool = "Advanced_ChargePool",
				SecondWindThresholdST = "SecondWindThresholdST",
				ShadeShiftThresholdST = "ShadeShiftThresholdST",
				BloodbathThresholdST = "BloodbathThresholdST",
				SecondWindThresholdAoE = "SecondWindThresholdAoE",
				ShadeShiftThresholdAoE = "ShadeShiftThresholdAoE",
				BloodbathThresholdAoE = "BloodbathThresholdAoE",
				NIN_VariantCure = "NIN_VariantCure";
		}

		internal class NIN_ST_AdvancedMode : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.NIN_ST_AdvancedMode;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID == SpinningEdge)
				{
					NINGauge gauge = GetJobGauge<NINGauge>();
					bool canWeave = CanWeave(SpinningEdge);
					bool canDelayedWeave = CanDelayedWeave(SpinningEdge);
					bool inTrickBurstSaveWindow = IsEnabled(CustomComboPreset.NIN_ST_AdvancedMode_TrickAttack_Cooldowns) && IsEnabled(CustomComboPreset.NIN_ST_AdvancedMode_TrickAttack) && GetCooldownRemainingTime(TrickAttack) <= GetOptionValue(Config.Advanced_Trick_Cooldown);
					bool useBhakaBeforeTrickWindow = GetCooldownRemainingTime(TrickAttack) >= 3;
					bool inMudraState = HasEffect(Buffs.Mudra);
					_ = GetCooldownRemainingTime(TrickAttack) <= GetOptionValue(Config.Trick_CooldownRemaining) && !HasEffect(Buffs.Suiton);
					bool setupKassatsuWindow = GetCooldownRemainingTime(TrickAttack) <= 10 && HasEffect(Buffs.Suiton);
					_ = IsNotEnabled(CustomComboPreset.NIN_ST_AdvancedMode_Ninjitsus_ChargeHold) || (IsEnabled(CustomComboPreset.NIN_ST_AdvancedMode_Ninjitsus_ChargeHold) && (GetRemainingCharges(Ten) == 2 || (GetRemainingCharges(Ten) == 1 && GetCooldownChargeRemainingTime(Ten) < 3)));
					bool doubleArmorCrush = IsEnabled(CustomComboPreset.NIN_ST_AdvancedMode_ArmorCrush) && PluginConfiguration.GetCustomBoolValue(Config.Advanced_DoubleArmorCrush) && GetOptionValue(Config.Huton_RemainingArmorCrush) <= 12;
					_ = !GetOptionBool(Config.Advanced_ChargePool) || (GetRemainingCharges(Ten) == 1 && GetCooldownChargeRemainingTime(Ten) < 2) || TargetHasEffect(Debuffs.TrickAttack);
					_ = IsEnabled(CustomComboPreset.NIN_ST_AdvancedMode_Raiton_Uptime);
					_ = IsEnabled(CustomComboPreset.NIN_ST_AdvancedMode_Suiton_Uptime);
					int timesLastEnderWasArmorCrush = ActionWatching.HowManyTimesUsedAfterAnotherAction(ArmorCrush, AeolianEdge);
					_ = doubleArmorCrush && HasEffect(All.Buffs.TrueNorth) && timesLastEnderWasArmorCrush == 1;
					_ = GetOptionValue(Config.Huton_RemainingHuraijinST) * 1000;
					int bhavaPool = GetOptionValue(Config.Ninki_BhavaPooling);
					_ = GetOptionValue(Config.Huton_RemainingArmorCrush) * 1000;
					int bunshinPool = GetOptionValue(Config.Ninki_BunshinPoolingST);
					int SecondWindThreshold = PluginConfiguration.GetCustomIntValue(Config.SecondWindThresholdST);
					int ShadeShiftThreshold = PluginConfiguration.GetCustomIntValue(Config.ShadeShiftThresholdST);
					int BloodbathThreshold = PluginConfiguration.GetCustomIntValue(Config.BloodbathThresholdST);
					double playerHP = PlayerHealthPercentageHp();
					_ = IsEnabled(CustomComboPreset.NIN_ST_AdvancedMode_Phantom_Uptime);

					if (canWeave && !inMudraState)
					{
						if (IsEnabled(CustomComboPreset.NIN_Variant_Rampart) &&
							IsEnabled(Variant.VariantRampart) &&
							IsOffCooldown(Variant.VariantRampart))
						{
							return Variant.VariantRampart;
						}

						if (IsEnabled(CustomComboPreset.NIN_ST_AdvancedMode_Mug_AlignBefore) &&
							HasEffect(Buffs.Suiton) &&
							GetCooldownRemainingTime(TrickAttack) <= 3 &&
							((IsEnabled(CustomComboPreset.NIN_ST_AdvancedMode_TrickAttack_Delayed) && InCombat() && combatDuration.TotalSeconds > 6) ||
							IsNotEnabled(CustomComboPreset.NIN_ST_AdvancedMode_TrickAttack_Delayed)) &&
							IsOffCooldown(Mug) &&
							Mug.ActionReady())
						{
							return OriginalHook(Mug);
						}

						if (IsEnabled(CustomComboPreset.NIN_ST_AdvancedMode_TrickAttack) &&
							HasEffect(Buffs.Suiton) &&
							IsOffCooldown(TrickAttack) &&
							((IsEnabled(CustomComboPreset.NIN_ST_AdvancedMode_TrickAttack_Delayed) && InCombat() && combatDuration.TotalSeconds > 8) ||
							IsNotEnabled(CustomComboPreset.NIN_ST_AdvancedMode_TrickAttack_Delayed)))
						{
							return OriginalHook(TrickAttack);
						}

						if (IsEnabled(CustomComboPreset.NIN_ST_AdvancedMode_Bunshin) && Bunshin.ActionReady() && IsOffCooldown(Bunshin) && gauge.Ninki >= bunshinPool)
						{
							return OriginalHook(Bunshin);
						}

						if (IsEnabled(CustomComboPreset.NIN_ST_AdvancedMode_Kassatsu) && (TargetHasEffect(Debuffs.TrickAttack) || setupKassatsuWindow) && IsOffCooldown(Kassatsu) && Kassatsu.ActionReady())
						{
							return OriginalHook(Kassatsu);
						}

						if (IsEnabled(CustomComboPreset.NIN_ST_AdvancedMode_SecondWind) && All.SecondWind.ActionReady() && playerHP <= SecondWindThreshold && IsOffCooldown(All.SecondWind))
						{
							return All.SecondWind;
						}

						if (IsEnabled(CustomComboPreset.NIN_ST_AdvancedMode_ShadeShift) && ShadeShift.ActionReady() && playerHP <= ShadeShiftThreshold && IsOffCooldown(ShadeShift))
						{
							return ShadeShift;
						}

						if (IsEnabled(CustomComboPreset.NIN_ST_AdvancedMode_Bloodbath) && All.Bloodbath.ActionReady() && playerHP <= BloodbathThreshold && IsOffCooldown(All.Bloodbath))
						{
							return All.Bloodbath;
						}

						if (IsEnabled(CustomComboPreset.NIN_ST_AdvancedMode_Bhavacakra) &&
							((TargetHasEffect(Debuffs.TrickAttack) && gauge.Ninki >= 50) || (useBhakaBeforeTrickWindow && gauge.Ninki == 100)) &&
							(IsNotEnabled(CustomComboPreset.NIN_ST_AdvancedMode_Mug) || (IsEnabled(CustomComboPreset.NIN_ST_AdvancedMode_Mug) && IsOnCooldown(Mug))) &&
							Bhavacakra.ActionReady())
						{
							return OriginalHook(Bhavacakra);
						}

						if (IsEnabled(CustomComboPreset.NIN_ST_AdvancedMode_Bhavacakra) &&
							((TargetHasEffect(Debuffs.TrickAttack) && gauge.Ninki >= 50) || (useBhakaBeforeTrickWindow && gauge.Ninki >= 60)) &&
							(IsNotEnabled(CustomComboPreset.NIN_ST_AdvancedMode_Mug) || (IsEnabled(CustomComboPreset.NIN_ST_AdvancedMode_Mug) && IsOnCooldown(Mug))) &&
							!Bhavacakra.ActionReady() && Hellfrog.ActionReady())
						{
							return OriginalHook(Hellfrog);
						}

						if (!inTrickBurstSaveWindow)
						{
							if (IsEnabled(CustomComboPreset.NIN_ST_AdvancedMode_Mug) && IsOffCooldown(Mug) && Mug.ActionReady())
							{
								if (IsNotEnabled(CustomComboPreset.NIN_ST_AdvancedMode_Mug_AlignAfter) || (IsEnabled(CustomComboPreset.NIN_ST_AdvancedMode_Mug_AlignAfter) && TargetHasEffect(Debuffs.TrickAttack)))
								{
									return OriginalHook(Mug);
								}
							}

							if (IsEnabled(CustomComboPreset.NIN_ST_AdvancedMode_Meisui) && HasEffect(Buffs.Suiton) && gauge.Ninki <= 50 && IsOffCooldown(Meisui) && Meisui.ActionReady())
							{
								return OriginalHook(Meisui);
							}

							if (IsEnabled(CustomComboPreset.NIN_ST_AdvancedMode_Bhavacakra) && gauge.Ninki >= bhavaPool && Bhavacakra.ActionReady())
							{
								return OriginalHook(Bhavacakra);
							}

							if (IsEnabled(CustomComboPreset.NIN_ST_AdvancedMode_Bhavacakra) && gauge.Ninki >= bhavaPool && !Bhavacakra.ActionReady() && Hellfrog.ActionReady())
							{
								return OriginalHook(Hellfrog);
							}

							if (IsEnabled(CustomComboPreset.NIN_ST_AdvancedMode_AssassinateDWAD) && IsOffCooldown(OriginalHook(Assassinate)) && Assassinate.ActionReady())
							{
								return OriginalHook(Assassinate);
							}

							if (IsEnabled(CustomComboPreset.NIN_ST_AdvancedMode_TCJ) && IsOffCooldown(TenChiJin) && !IsMoving && TenChiJin.ActionReady())
							{
								return OriginalHook(TenChiJin);
							}
						}

						if (IsEnabled(CustomComboPreset.NIN_ST_AdvancedMode_SecondWind) && All.SecondWind.ActionReady() && playerHP <= SecondWindThreshold && IsOffCooldown(All.SecondWind))
						{
							return All.SecondWind;
						}

						if (IsEnabled(CustomComboPreset.NIN_ST_AdvancedMode_ShadeShift) && ShadeShift.ActionReady() && playerHP <= ShadeShiftThreshold && IsOffCooldown(ShadeShift))
						{
							return ShadeShift;
						}

						if (IsEnabled(CustomComboPreset.NIN_ST_AdvancedMode_Bloodbath) && All.Bloodbath.ActionReady() && playerHP <= BloodbathThreshold && IsOffCooldown(All.Bloodbath))
						{
							return All.Bloodbath;
						}
					}


					if (IsEnabled(CustomComboPreset.NIN_ST_AdvancedMode_Raiju) && HasEffect(Buffs.RaijuReady))
					{
						return IsEnabled(CustomComboPreset.NIN_ST_AdvancedMode_Raiju_Forked) && !InMeleeRange()
							? OriginalHook(ForkedRaiju)
							: OriginalHook(FleetingRaiju);
					}

					if (IsEnabled(CustomComboPreset.NIN_ST_AdvancedMode_Bunshin_Phantom) &&
						HasEffect(Buffs.PhantomReady) &&
						((GetCooldownRemainingTime(TrickAttack) > GetBuffRemainingTime(Buffs.PhantomReady) && GetBuffRemainingTime(Buffs.PhantomReady) < 5) || TargetHasEffect(Debuffs.TrickAttack) || (HasEffect(Buffs.Bunshin) && TargetHasEffect(Debuffs.Mug))) &&
						PhantomKamaitachi.ActionReady())
					{
						return OriginalHook(PhantomKamaitachi);
					}


					if (IsEnabled(CustomComboPreset.NIN_ST_AdvancedMode_ArmorCrush) &&
						!HasEffect(Buffs.RaijuReady) &&
						lastComboMove == GustSlash &&
						((IsEnabled(CustomComboPreset.NIN_ST_AdvancedMode_TrickAttack) && IsOnCooldown(TrickAttack)) ||
						IsNotEnabled(CustomComboPreset.NIN_ST_AdvancedMode_TrickAttack)) &&
						doubleArmorCrush && timesLastEnderWasArmorCrush == 1 &&
						ArmorCrush.ActionReady() &&
						comboTime > 1f)
					{
						return IsEnabled(CustomComboPreset.NIN_ST_AdvancedMode_TrueNorth) &&
							GetRemainingCharges(All.TrueNorth) > 0 &&
							All.TrueNorth.ActionReady() && !HasEffect(All.Buffs.TrueNorth) &&
							!(IsEnabled(CustomComboPreset.NIN_ST_AdvancedMode_TrueNorth_ArmorCrush_Dynamic) && TargetNeedsPositionals() && OnTargetsFlank()) &&
							canDelayedWeave
							? OriginalHook(All.TrueNorth)
							: OriginalHook(ArmorCrush);
					}

					if (comboTime > 1f)
					{
						if (lastComboMove == SpinningEdge && GustSlash.ActionReady())
						{
							return OriginalHook(GustSlash);
						}

						if (IsEnabled(CustomComboPreset.NIN_ST_AdvancedMode_TrueNorth) && TargetNeedsPositionals() &&
							IsNotEnabled(CustomComboPreset.NIN_ST_AdvancedMode_TrueNorth_ArmorCrush) &&
							lastComboMove == GustSlash && GetRemainingCharges(All.TrueNorth) > 0 &&
							All.TrueNorth.ActionReady() && !HasEffect(All.Buffs.TrueNorth) &&
							canWeave)
						{
							return OriginalHook(All.TrueNorth);
						}

						if (lastComboMove == GustSlash && AeolianEdge.ActionReady())
						{
							return OriginalHook(AeolianEdge);
						}
					}

					return OriginalHook(SpinningEdge);
				}
				return actionID;
			}
		}

		internal class NIN_AoE_AdvancedMode : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.NIN_AoE_AdvancedMode;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID == DeathBlossom)
				{
					Status? dotonBuff = FindEffect(Buffs.Doton);
					NINGauge? gauge = GetJobGauge<NINGauge>();
					bool canWeave = CanWeave(GustSlash);
					bool chargeCheck = IsNotEnabled(CustomComboPreset.NIN_AoE_AdvancedMode_Ninjitsus_ChargeHold) || (IsEnabled(CustomComboPreset.NIN_AoE_AdvancedMode_Ninjitsus_ChargeHold) && GetRemainingCharges(Ten) == 2);
					bool inMudraState = HasEffect(Buffs.Mudra);
					int hellfrogPool = GetOptionValue(Config.Ninki_HellfrogPooling);
					_ = GetOptionValue(Config.Huton_RemainingHuraijinAoE) * 1000;
					int dotonTimer = GetOptionValue(Config.Advanced_DotonTimer);
					int dotonThreshold = GetOptionValue(Config.Advanced_DotonHP);
					int tcjPath = GetOptionValue(Config.Advanced_TCJEnderAoE);
					int bunshingPool = GetOptionValue(Config.Ninki_BunshinPoolingAoE);
					int SecondWindThreshold = PluginConfiguration.GetCustomIntValue(Config.SecondWindThresholdAoE);
					int ShadeShiftThreshold = PluginConfiguration.GetCustomIntValue(Config.ShadeShiftThresholdAoE);
					int BloodbathThreshold = PluginConfiguration.GetCustomIntValue(Config.BloodbathThresholdAoE);
					double playerHP = PlayerHealthPercentageHp();

					if (OriginalHook(Ninjutsu) is Rabbit)
					{
						return OriginalHook(Ninjutsu);
					}

					if (HasEffect(Buffs.TenChiJin))
					{
						if (tcjPath == 0)
						{
							if (OriginalHook(Chi) == TCJFumaShurikenChi)
							{
								return OriginalHook(Chi);
							}

							if (OriginalHook(Ten) == TCJKaton)
							{
								return OriginalHook(Ten);
							}

							if (OriginalHook(Jin) == TCJSuiton)
							{
								return OriginalHook(Jin);
							}
						}
						else
						{
							if (OriginalHook(Jin) == TCJFumaShurikenJin)
							{
								return OriginalHook(Jin);
							}

							if (OriginalHook(Ten) == TCJKaton)
							{
								return OriginalHook(Ten);
							}

							if (OriginalHook(Chi) == TCJDoton)
							{
								return OriginalHook(Chi);
							}
						}

					}

					if (IsEnabled(CustomComboPreset.NIN_Variant_Cure) && IsEnabled(Variant.VariantCure) && PlayerHealthPercentageHp() <= GetOptionValue(Config.NIN_VariantCure))
					{
						return Variant.VariantCure;
					}

					if (canWeave && !inMudraState)
					{
						if (IsEnabled(CustomComboPreset.NIN_Variant_Rampart) &&
							IsEnabled(Variant.VariantRampart) &&
							IsOffCooldown(Variant.VariantRampart))
						{
							return Variant.VariantRampart;
						}

						if (IsEnabled(CustomComboPreset.NIN_AoE_AdvancedMode_Bunshin) && Bunshin.ActionReady() && IsOffCooldown(Bunshin) && gauge.Ninki >= bunshingPool)
						{
							return OriginalHook(Bunshin);
						}

						if (IsEnabled(CustomComboPreset.NIN_AoE_AdvancedMode_HellfrogMedium) && gauge.Ninki >= hellfrogPool && Hellfrog.ActionReady())
						{
							return HasEffect(Buffs.Meisui) && level >= 88 ? OriginalHook(Bhavacakra) : OriginalHook(Hellfrog);
						}

						if (IsEnabled(CustomComboPreset.NIN_AoE_AdvancedMode_HellfrogMedium) && gauge.Ninki >= hellfrogPool && !Hellfrog.ActionReady() && Bhavacakra.ActionReady())
						{
							return OriginalHook(Bhavacakra);
						}

						if (IsEnabled(CustomComboPreset.NIN_AoE_AdvancedMode_Kassatsu) &&
							IsOffCooldown(Kassatsu) &&
							Kassatsu.ActionReady() &&
							((IsEnabled(CustomComboPreset.NIN_AoE_AdvancedMode_Ninjitsus_Doton) && (dotonBuff != null || GetTargetHPPercent() < dotonThreshold)) ||
							IsNotEnabled(CustomComboPreset.NIN_AoE_AdvancedMode_Ninjitsus_Doton)))
						{
							return OriginalHook(Kassatsu);
						}

						if (IsEnabled(CustomComboPreset.NIN_AoE_AdvancedMode_Meisui) && HasEffect(Buffs.Suiton) && gauge.Ninki <= 50 && IsOffCooldown(Meisui) && Meisui.ActionReady())
						{
							return OriginalHook(Meisui);
						}

						if (IsEnabled(CustomComboPreset.NIN_AoE_AdvancedMode_AssassinateDWAD) && IsOffCooldown(OriginalHook(Assassinate)) && Assassinate.ActionReady())
						{
							return OriginalHook(Assassinate);
						}

						if (IsEnabled(CustomComboPreset.NIN_AoE_AdvancedMode_SecondWind) && All.SecondWind.ActionReady() && playerHP <= SecondWindThreshold && IsOffCooldown(All.SecondWind))
						{
							return All.SecondWind;
						}

						if (IsEnabled(CustomComboPreset.NIN_AoE_AdvancedMode_ShadeShift) && ShadeShift.ActionReady() && playerHP <= ShadeShiftThreshold && IsOffCooldown(ShadeShift))
						{
							return ShadeShift;
						}

						if (IsEnabled(CustomComboPreset.NIN_AoE_AdvancedMode_Bloodbath) && All.Bloodbath.ActionReady() && playerHP <= BloodbathThreshold && IsOffCooldown(All.Bloodbath))
						{
							return All.Bloodbath;
						}

						if (IsEnabled(CustomComboPreset.NIN_AoE_AdvancedMode_TCJ) &&
							IsOffCooldown(TenChiJin) &&
							!IsMoving &&
							TenChiJin.ActionReady())
						{
							if ((IsEnabled(CustomComboPreset.NIN_AoE_AdvancedMode_Ninjitsus_Doton) && tcjPath == 1 &&
							   (dotonBuff?.RemainingTime <= dotonTimer || dotonBuff is null) &&
							   GetTargetHPPercent() >= dotonThreshold &&
							   !WasLastAction(Doton)) ||
							   tcjPath == 0)
							{
								return OriginalHook(TenChiJin);
							}
						}

					}

					if (IsEnabled(CustomComboPreset.NIN_AoE_AdvancedMode_GokaMekkyaku))
					{
						return actionID;
					}

					if (IsEnabled(CustomComboPreset.NIN_AoE_AdvancedMode_Ninjitsus))
					{
						if (IsEnabled(CustomComboPreset.NIN_AoE_AdvancedMode_Ninjitsus_Doton) &&
							(dotonBuff?.RemainingTime <= dotonTimer || dotonBuff is null) &&
							GetTargetHPPercent() >= dotonThreshold &&
							chargeCheck &&
							!(WasLastAction(Doton) || WasLastAction(TCJDoton) || dotonBuff is not null))
						{
							return actionID;
						}

						if (IsEnabled(CustomComboPreset.NIN_AoE_AdvancedMode_Ninjitsus_Katon) &&
							chargeCheck &&
							((IsEnabled(CustomComboPreset.NIN_AoE_AdvancedMode_Ninjitsus_Doton) && (dotonBuff != null || GetTargetHPPercent() < dotonThreshold)) ||
							IsNotEnabled(CustomComboPreset.NIN_AoE_AdvancedMode_Ninjitsus_Doton)))
						{
							return actionID;
						}
					}

					if (IsEnabled(CustomComboPreset.NIN_AoE_AdvancedMode_Bunshin_Phantom) && HasEffect(Buffs.PhantomReady) && PhantomKamaitachi.ActionReady())
					{
						return OriginalHook(PhantomKamaitachi);
					}

					if (comboTime > 1f)
					{
						if (lastComboMove is DeathBlossom && HakkeMujinsatsu.ActionReady())
						{
							return OriginalHook(HakkeMujinsatsu);
						}
					}

					return OriginalHook(DeathBlossom);
				}
				return actionID;
			}
		}


		internal class NIN_ST_SimpleMode : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.NIN_ST_SimpleMode;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID == SpinningEdge)
				{
					NINGauge gauge = GetJobGauge<NINGauge>();
					bool canWeave = CanWeave(SpinningEdge);
					bool inTrickBurstSaveWindow = GetCooldownRemainingTime(TrickAttack) <= 15 && Suiton.ActionReady();
					bool useBhakaBeforeTrickWindow = GetCooldownRemainingTime(TrickAttack) >= 3;
					bool inMudraState = HasEffect(Buffs.Mudra);

					if (OriginalHook(Ninjutsu) is Rabbit)
					{
						return OriginalHook(Ninjutsu);
					}

					if (IsEnabled(CustomComboPreset.NIN_ST_SimpleMode_BalanceOpener))
					{
						return actionID;
					}

					if (HasEffect(Buffs.TenChiJin))
					{
						return WasLastAction(TCJFumaShurikenTen) ? OriginalHook(Chi) : WasLastAction(TCJRaiton) ? OriginalHook(Jin) : OriginalHook(Ten);
					}

					if (IsEnabled(CustomComboPreset.NIN_Variant_Cure) && IsEnabled(Variant.VariantCure) && PlayerHealthPercentageHp() <= GetOptionValue(Config.NIN_VariantCure))
					{
						return Variant.VariantCure;
					}

					if (canWeave && !inMudraState)
					{
						if (IsEnabled(CustomComboPreset.NIN_Variant_Rampart) &&
							IsEnabled(Variant.VariantRampart) &&
							IsOffCooldown(Variant.VariantRampart))
						{
							return Variant.VariantRampart;
						}

						if (Bunshin.ActionReady() && IsOffCooldown(Bunshin) && gauge.Ninki >= 50)
						{
							return OriginalHook(Bunshin);
						}

						if (HasEffect(Buffs.Suiton) && IsOffCooldown(TrickAttack))
						{
							return OriginalHook(TrickAttack);
						}

						if (Bhavacakra.ActionReady() && ((TargetHasEffect(Debuffs.TrickAttack) && gauge.Ninki >= 50) || (useBhakaBeforeTrickWindow && gauge.Ninki == 100)))
						{
							return OriginalHook(Bhavacakra);
						}

						if ((TargetHasEffect(Debuffs.TrickAttack) && gauge.Ninki >= 50) || (useBhakaBeforeTrickWindow && gauge.Ninki == 100 && !Bhavacakra.ActionReady() && Hellfrog.ActionReady()))
						{
							return OriginalHook(Hellfrog);
						}

						if (!inTrickBurstSaveWindow)
						{
							if (HasEffect(Buffs.Suiton) && gauge.Ninki <= 50 && IsOffCooldown(Meisui) && Meisui.ActionReady())
							{
								return OriginalHook(Meisui);
							}

							if (IsOffCooldown(Mug) && Mug.ActionReady())
							{
								return OriginalHook(Mug);
							}

							if (gauge.Ninki >= 85 && Bhavacakra.ActionReady())
							{
								return OriginalHook(Bhavacakra);
							}

							if (IsOffCooldown(OriginalHook(Assassinate)) && Assassinate.ActionReady())
							{
								return OriginalHook(Assassinate);
							}

							if (IsOffCooldown(TenChiJin) && TenChiJin.ActionReady())
							{
								return OriginalHook(TenChiJin);
							}

							if (IsOffCooldown(Kassatsu) && Kassatsu.ActionReady())
							{
								return OriginalHook(Kassatsu);
							}
						}
					}
					else
					{
						if (HasEffect(Buffs.RaijuReady))
						{
							return OriginalHook(FleetingRaiju);
						}

						if (HasEffect(Buffs.PhantomReady) && PhantomKamaitachi.ActionReady())
						{
							return OriginalHook(PhantomKamaitachi);
						}
					}

					if (comboTime > 1f)
					{
						if (lastComboMove == SpinningEdge && GustSlash.ActionReady())
						{
							return OriginalHook(GustSlash);
						}

						if (lastComboMove == GustSlash && ArmorCrush.ActionReady())
						{
							return OriginalHook(ArmorCrush);
						}

						if (lastComboMove == GustSlash && TargetNeedsPositionals() && GetRemainingCharges(All.TrueNorth) > 0 && All.TrueNorth.ActionReady() && !HasEffect(All.Buffs.TrueNorth) && canWeave)
						{
							return OriginalHook(All.TrueNorth);
						}

						if (lastComboMove == GustSlash && AeolianEdge.ActionReady())
						{
							return OriginalHook(AeolianEdge);
						}
					}

					return OriginalHook(SpinningEdge);
				}
				return actionID;
			}
		}

		internal class NIN_AoE_SimpleMode : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.NIN_AoE_SimpleMode;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID == DeathBlossom)
				{
					_ = FindEffect(Buffs.Doton);
					NINGauge gauge = GetJobGauge<NINGauge>();
					bool canWeave = CanWeave(GustSlash);

					if (OriginalHook(Ninjutsu) is Rabbit)
					{
						return OriginalHook(Ninjutsu);
					}

					if (HasEffect(Buffs.TenChiJin))
					{
						return WasLastAction(TCJFumaShurikenChi)
							? OriginalHook(Ten)
							: WasLastAction(TCJKaton) || WasLastAction(HollowNozuchi) ? OriginalHook(Jin) : OriginalHook(Chi);
					}

					if (IsEnabled(CustomComboPreset.NIN_Variant_Cure) && IsEnabled(Variant.VariantCure) && PlayerHealthPercentageHp() <= GetOptionValue(Config.NIN_VariantCure))
					{
						return Variant.VariantCure;
					}

					if (canWeave)
					{
						if (IsEnabled(CustomComboPreset.NIN_Variant_Rampart) &&
							IsEnabled(Variant.VariantRampart) &&
							IsOffCooldown(Variant.VariantRampart))
						{
							return Variant.VariantRampart;
						}

						if (IsOffCooldown(Bunshin) && gauge.Ninki >= 50 && Bunshin.ActionReady())
						{
							return OriginalHook(Bunshin);
						}

						if (HasEffect(Buffs.Suiton) && gauge.Ninki < 50 && IsOffCooldown(Meisui) && Meisui.ActionReady())
						{
							return OriginalHook(Meisui);
						}

						if (HasEffect(Buffs.Meisui) && gauge.Ninki >= 50)
						{
							return OriginalHook(Bhavacakra);
						}

						if (gauge.Ninki >= 50 && Hellfrog.ActionReady())
						{
							return OriginalHook(Hellfrog);
						}

						if (gauge.Ninki >= 50 && !Hellfrog.ActionReady() && Bhavacakra.ActionReady())
						{
							return OriginalHook(Bhavacakra);
						}

						if (IsOffCooldown(Kassatsu) && Kassatsu.ActionReady())
						{
							return OriginalHook(Kassatsu);
						}

						if (IsOffCooldown(TenChiJin) && TenChiJin.ActionReady())
						{
							return OriginalHook(TenChiJin);
						}
					}
					else
					{
						if (HasEffect(Buffs.PhantomReady))
						{
							return OriginalHook(PhantomKamaitachi);
						}
					}

					if (comboTime > 1f)
					{
						if (lastComboMove is DeathBlossom && HakkeMujinsatsu.ActionReady())
						{
							return OriginalHook(HakkeMujinsatsu);
						}
					}

					return OriginalHook(DeathBlossom);
				}
				return actionID;
			}
		}

		internal class NIN_ArmorCrushCombo : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.NIN_ArmorCrushCombo;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID == ArmorCrush)
				{
					if (comboTime > 0f)
					{
						if (lastComboMove == SpinningEdge && level >= 4)
						{
							return GustSlash;
						}

						if (lastComboMove == GustSlash && level >= 54)
						{
							return ArmorCrush;
						}
					}
					return SpinningEdge;
				}
				return actionID;
			}
		}


		internal class NIN_HideMug : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.NIN_HideMug;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID == Hide)
				{
					if (HasCondition(Dalamud.Game.ClientState.Conditions.ConditionFlag.InCombat))
					{
						return Mug;
					}

					if (HasEffect(Buffs.Hidden))
					{
						return TrickAttack;
					}

				}

				return actionID;
			}
		}

		internal class NIN_KassatsuChiJin : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.NIN_KassatsuChiJin;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				return actionID == Chi && level >= 76 && HasEffect(Buffs.Kassatsu) ? Jin : actionID;
			}
		}

		internal class NIN_KassatsuTrick : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.NIN_KassatsuTrick;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				return actionID == Kassatsu
					? HasEffect(Buffs.Suiton) || HasEffect(Buffs.Hidden) ? OriginalHook(TrickAttack) : OriginalHook(Kassatsu)
					: actionID;
			}
		}

		internal class NIN_TCJMeisui : CustomComboClass
		{
			protected internal override CustomComboPreset Preset
			{
				get
				{
					return CustomComboPreset.NIN_TCJMeisui;
				}
			}

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID == TenChiJin)
				{

					if (HasEffect(Buffs.Suiton))
					{
						return Meisui;
					}

					if (HasEffect(Buffs.TenChiJin) && IsEnabled(CustomComboPreset.NIN_TCJ))
					{
						float tcjTimer = FindEffectAny(Buffs.TenChiJin).RemainingTime;

						if (tcjTimer > 5)
						{
							return OriginalHook(Ten);
						}

						if (tcjTimer > 4)
						{
							return OriginalHook(Chi);
						}

						if (tcjTimer > 3)
						{
							return OriginalHook(Jin);
						}
					}
				}
				return actionID;
			}
		}

		internal class NIN_Simple_Mudras : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.NIN_Simple_Mudras;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID is Ten or Chi or Jin)
				{
					int mudrapath = GetOptionValue(Config.NIN_SimpleMudra_Choice);

					if (HasEffect(Buffs.Mudra))
					{

						if (mudrapath == 1)
						{
							if (Ten.ActionReady() && actionID == Ten)
							{
								if (Jin.ActionReady() && (OriginalHook(Ninjutsu) is Raiton))
								{
									return OriginalHook(JinCombo);
								}

								if (Chi.ActionReady() && (OriginalHook(Ninjutsu) is HyoshoRanryu))
								{
									return OriginalHook(ChiCombo);
								}

								if (OriginalHook(Ninjutsu) == FumaShuriken)
								{
									if (HasEffect(Buffs.Kassatsu) && Traits.EnhancedKasatsu.TraitActionReady())
									{
										return JinCombo;
									}

									if (Chi.ActionReady())
									{
										return OriginalHook(ChiCombo);
									}

									if (Jin.ActionReady())
									{
										return OriginalHook(JinCombo);
									}
								}
							}

							if (Chi.ActionReady() && actionID == Chi)
							{
								if (OriginalHook(Ninjutsu) is Hyoton)
								{
									return OriginalHook(TenCombo);
								}

								if (Jin.ActionReady() && OriginalHook(Ninjutsu) == FumaShuriken)
								{
									return OriginalHook(JinCombo);
								}
							}

							if (Jin.ActionReady() && actionID == Jin)
							{
								if (OriginalHook(Ninjutsu) is GokaMekkyaku or Katon)
								{
									return OriginalHook(ChiCombo);
								}

								if (OriginalHook(Ninjutsu) == FumaShuriken)
								{
									return OriginalHook(TenCombo);
								}
							}

							return OriginalHook(Ninjutsu);
						}

						if (mudrapath == 2)
						{
							if (Ten.ActionReady() && actionID == Ten)
							{
								if (Chi.ActionReady() && (OriginalHook(Ninjutsu) is Hyoton or HyoshoRanryu))
								{
									return OriginalHook(Chi);
								}

								if (OriginalHook(Ninjutsu) == FumaShuriken)
								{
									if (Jin.ActionReady())
									{
										return OriginalHook(JinCombo);
									}
									else if (Chi.ActionReady())
									{
										return OriginalHook(ChiCombo);
									}
								}
							}

							if (Chi.ActionReady() && actionID == Chi)
							{
								if (Jin.ActionReady() && (OriginalHook(Ninjutsu) is Katon or GokaMekkyaku))
								{
									return OriginalHook(Jin);
								}

								if (OriginalHook(Ninjutsu) == FumaShuriken)
								{
									return OriginalHook(Ten);
								}
							}

							if (Jin.ActionReady() && actionID == Jin)
							{
								if (OriginalHook(Ninjutsu) is Raiton)
								{
									return OriginalHook(Ten);
								}

								if (OriginalHook(Ninjutsu) == GokaMekkyaku)
								{
									return OriginalHook(Chi);
								}

								if (OriginalHook(Ninjutsu) == FumaShuriken)
								{
									return HasEffect(Buffs.Kassatsu) && Traits.EnhancedKasatsu.TraitActionReady() ? OriginalHook(Ten) : OriginalHook(Chi);
								}
							}

							return OriginalHook(Ninjutsu);
						}
					}
				}
				return actionID;
			}
		}
	}
}
