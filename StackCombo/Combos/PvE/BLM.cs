using Dalamud.Game.ClientState.JobGauge.Types;
using Dalamud.Game.ClientState.Statuses;
using StackCombo.ComboHelper.Functions;
using StackCombo.Combos.PvE.Content;
using StackCombo.CustomCombo;
using StackCombo.Extensions;
using System.Collections.Generic;

namespace StackCombo.Combos.PvE
{
	internal class BLM
	{
		public const byte JobID = 25;

		public const uint
			Fire = 141,
			Blizzard = 142,
			Thunder = 144,
			Fire2 = 147,
			Transpose = 149,
			Fire3 = 152,
			Thunder3 = 153,
			Blizzard3 = 154,
			AetherialManipulation = 155,
			Scathe = 156,
			Manafont = 158,
			Freeze = 159,
			Flare = 162,
			LeyLines = 3573,
			Sharpcast = 3574,
			Blizzard4 = 3576,
			Fire4 = 3577,
			BetweenTheLines = 7419,
			Thunder4 = 7420,
			Triplecast = 7421,
			Foul = 7422,
			Thunder2 = 7447,
			Despair = 16505,
			UmbralSoul = 16506,
			Xenoglossy = 16507,
			Blizzard2 = 25793,
			HighFire2 = 25794,
			HighBlizzard2 = 25795,
			Amplifier = 25796,
			Paradox = 25797;

		public static class Buffs
		{
			public const ushort
				Thundercloud = 164,
				Firestarter = 165,
				LeyLines = 737,
				CircleOfPower = 738,
				Sharpcast = 867,
				Triplecast = 1211,
				EnhancedFlare = 2960;
		}

		public static class Debuffs
		{
			public const ushort
				Thunder = 161,
				Thunder2 = 162,
				Thunder3 = 163,
				Thunder4 = 1210;
		}

		public static class Traits
		{
			public const uint
				EnhancedFreeze = 295,
				EnhancedPolyGlot = 297,
				AspectMasteryIII = 459,
				EnhancedFoul = 461,
				EnhancedManafont = 463,
				Enochian = 460;
		}

		public static class MP
		{
			public const int MaxMP = 10000;

			public const int AllMPSpells = 800;
			public static int ThunderST
			{
				get
				{
					return CustomComboFunctions.GetResourceCost(CustomComboFunctions.OriginalHook(Thunder));
				}
			}

			public static int ThunderAoE
			{
				get
				{
					return CustomComboFunctions.GetResourceCost(CustomComboFunctions.OriginalHook(Thunder2));
				}
			}

			public static int FireI
			{
				get
				{
					return CustomComboFunctions.GetResourceCost(CustomComboFunctions.OriginalHook(Fire));
				}
			}

			public static int FireAoE
			{
				get
				{
					return CustomComboFunctions.GetResourceCost(CustomComboFunctions.OriginalHook(Fire2));
				}
			}

			public static int FireIII
			{
				get
				{
					return CustomComboFunctions.GetResourceCost(CustomComboFunctions.OriginalHook(Fire3));
				}
			}

			public static int BlizzardAoE
			{
				get
				{
					return CustomComboFunctions.GetResourceCost(CustomComboFunctions.OriginalHook(Blizzard2));
				}
			}

			public static int BlizzardI
			{
				get
				{
					return CustomComboFunctions.GetResourceCost(CustomComboFunctions.OriginalHook(Blizzard));
				}
			}

			public static int Freeze
			{
				get
				{
					return CustomComboFunctions.GetResourceCost(CustomComboFunctions.OriginalHook(BLM.Freeze));
				}
			}
		}

		public static readonly Dictionary<uint, ushort>
			ThunderList = new()
			{
				{ Thunder,  Debuffs.Thunder  },
				{ Thunder2, Debuffs.Thunder2 },
				{ Thunder3, Debuffs.Thunder3 },
				{ Thunder4, Debuffs.Thunder4 }
			};

		public static class Config
		{
			public static UserBool
				BLM_Adv_Xeno_Burst = new("BLM_Adv_Xeno_Burst");

			public static UserBoolArray
				BLM_Adv_Cooldowns_Choice = new("BLM_Adv_Cooldowns_Choice"),
				BLM_AoE_Adv_Cooldowns_Choice = new("BLM_AoE_Adv_Cooldowns_Choice"),
				BLM_Adv_Movement_Choice = new("BLM_Adv_Movement_Choice");

			public static UserInt
				BLM_VariantCure = new("BLM_VariantCure"),
				BLM_Adv_Cooldowns = new("BLM_Adv_Cooldowns"),
				BLM_Adv_Thunder = new("BLM_Adv_Thunder"),
				BLM_Adv_Rotation_Options = new("BLM_Adv_Rotation_Options"),
				BLM_Advanced_OpenerSelection = new("BLM_Advanced_OpenerSelection"),
				BLM_ST_Adv_ThunderHP = new("BLM_ST_Adv_ThunderHP"),
				BLM_AoE_Adv_ThunderHP = new("BLM_AoE_Adv_ThunderHP"),
				BLM_AoE_Adv_ThunderUptime = new("BLM_AoE_Adv_ThunderUptime"),
				BLM_Adv_ThunderCloud = new("BLM_Adv_ThunderCloud"),
				BLM_Adv_InitialCast = new("BLM_Adv_InitialCast");

			public static UserFloat
				BLM_AstralFire_Refresh = new("BLM_AstralFire_Refresh");
		}

		internal class BLM_ST_SimpleMode : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BLM_ST_SimpleMode;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				uint currentMP = LocalPlayer.CurrentMp;
				float astralFireRefresh = 8000;
				Status? dotDebuff = FindTargetEffect(ThunderList[OriginalHook(Thunder)]);
				BLMGauge? gauge = GetJobGauge<BLMGauge>();

				if (actionID is Fire)
				{

					if (gauge.ElementTimeRemaining > 0)
					{
						if (CurrentTarget is null)
						{
							if (gauge.InAstralFire && ActionReady(Transpose))
							{
								return Transpose;
							}

							if (gauge.InUmbralIce && ActionReady(UmbralSoul))
							{
								return UmbralSoul;
							}
						}

						if (IsEnabled(CustomComboPreset.BLM_Variant_Cure) &&
							IsEnabled(Variant.VariantCure) && PlayerHealthPercentageHp() <= Config.BLM_VariantCure)
						{
							return Variant.VariantCure;
						}

						if (IsEnabled(CustomComboPreset.BLM_Variant_Rampart) &&
							IsEnabled(Variant.VariantRampart) &&
							IsOffCooldown(Variant.VariantRampart) &&
							CanSpellWeave(actionID))
						{
							return Variant.VariantRampart;
						}

						if (IsMoving && InCombat())
						{
							if (!HasEffect(Buffs.Sharpcast) && ActionReady(Sharpcast))
							{
								return Sharpcast;
							}

							if (HasEffect(Buffs.Thundercloud) && HasEffect(Buffs.Sharpcast) &&
								(dotDebuff is null || dotDebuff?.RemainingTime <= 10))
							{
								return OriginalHook(Thunder);
							}

							if (HasEffect(Buffs.Firestarter) && gauge.InAstralFire && ActionReady(Fire3))
							{
								return Fire3;
							}

							if (ActionReady(Paradox) && gauge.IsParadoxActive && gauge.InUmbralIce)
							{
								return Paradox;
							}

							if (ActionReady(Xenoglossy) && gauge.PolyglotStacks > 1)
							{
								return Xenoglossy;
							}

							if (ActionReady(All.Swiftcast) && !HasEffect(Buffs.Triplecast))
							{
								return All.Swiftcast;
							}

							if (ActionReady(Triplecast) && GetBuffStacks(Buffs.Triplecast) is 0 && !HasEffect(All.Buffs.Swiftcast))
							{
								return Triplecast;
							}

							if ((GetBuffStacks(Buffs.Triplecast) is 0) && ActionReady(Scathe))
							{
								return Scathe;
							}
						}

						if (!ThunderList.ContainsKey(lastComboMove) &&
							(currentMP >= MP.ThunderST || (HasEffect(Buffs.Sharpcast) && HasEffect(Buffs.Thundercloud))))
						{
							if (ActionReady(Thunder3) &&
								GetDebuffRemainingTime(Debuffs.Thunder3) <= 4)
							{
								return Thunder3;
							}

							if (ActionReady(Thunder) && !ActionReady(Thunder3) &&
								GetDebuffRemainingTime(Debuffs.Thunder) <= 4)
							{
								return Thunder;
							}
						}

						if (GetRemainingCharges(Triplecast) is 2 &&
							ActionReady(Triplecast) && !HasEffect(Buffs.Triplecast) && !HasEffect(All.Buffs.Swiftcast) &&
							(gauge.InAstralFire || gauge.UmbralHearts is 3) &&
							currentMP >= MP.FireI * 2)
						{
							return Triplecast;
						}

						if (CanSpellWeave(actionID))
						{
							if (ActionReady(Amplifier) && gauge.PolyglotStacks < 2)
							{
								return Amplifier;
							}

							if (ActionReady(LeyLines))
							{
								return LeyLines;
							}
						}
					}

					if (gauge.ElementTimeRemaining <= 0)
					{
						return ActionReady(Fire3)
							? (currentMP >= MP.FireIII)
								? Fire3
								: Blizzard3
							: (currentMP >= MP.FireI)
							? Fire
							: Blizzard;
					}

					if (!ActionReady(Blizzard3))
					{
						if (gauge.InAstralFire)
						{
							return (currentMP < MP.FireI)
								? Transpose
								: Fire;
						}

						if (gauge.InUmbralIce)
						{
							return (currentMP >= MP.MaxMP - MP.BlizzardI)
								? Transpose
								: Blizzard;
						}
					}

					if (!ActionReady(Fire4))
					{
						if (gauge.InAstralFire)
						{
							return HasEffect(Buffs.Firestarter) && GetBuffRemainingTime(Buffs.Firestarter) <= 27
								? Fire3
								: (currentMP < MP.FireI)
								? Blizzard3
								: Fire;
						}

						if (gauge.InUmbralIce)
						{
							return ActionReady(Blizzard4) && gauge.UmbralHearts < 3
								? Blizzard4
								: (currentMP == MP.MaxMP || gauge.UmbralHearts is 3)
								? Fire3
								: Blizzard;
						}
					}

					if (gauge.InAstralFire)
					{
						return (gauge.PolyglotStacks is 2 && (gauge.EnochianTimer <= 3000) && TraitActionReady(Traits.EnhancedPolyGlot)) ||
							(gauge.PolyglotStacks is 1 && (gauge.EnochianTimer <= 6000) && !TraitActionReady(Traits.EnhancedPolyGlot))
							? ActionReady(Xenoglossy)
								? Xenoglossy
								: Foul
							: gauge.AstralFireStacks < 3 || (gauge.ElementTimeRemaining <= 3000 && HasEffect(Buffs.Firestarter))
							? Fire3
							: gauge.ElementTimeRemaining <= astralFireRefresh && !HasEffect(Buffs.Firestarter) && currentMP >= MP.FireI
							? OriginalHook(Fire)
							: ActionReady(Manafont) && WasLastAction(Despair)
							? Manafont
							: IsOnCooldown(Manafont) && WasLastAction(Manafont) && Fire4.ActionReady()
							? Fire4
							: currentMP < MP.FireI || gauge.ElementTimeRemaining <= 5000
							? currentMP >= MP.FireI
								? OriginalHook(Fire)
								: currentMP < MP.FireI && currentMP >= MP.AllMPSpells && ActionReady(Despair) ? Despair : Blizzard3
							: Fire4;
					}
				}

				return actionID;
			}
		}

		internal class BLM_ST_AdvancedMode : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BLM_ST_AdvancedMode;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				uint currentMP = LocalPlayer.CurrentMp;
				float astralFireRefresh = Config.BLM_AstralFire_Refresh * 1000;
				int rotationSelection = Config.BLM_Adv_Rotation_Options;
				Status? dotDebuff = FindTargetEffect(ThunderList[OriginalHook(Thunder)]);
				BLMGauge? gauge = GetJobGauge<BLMGauge>();
				int thunderRefreshTime = Config.BLM_Adv_Thunder;
				int ThunderHP = Config.BLM_ST_Adv_ThunderHP;

				if (actionID is Fire)
				{
					if (IsEnabled(CustomComboPreset.BLM_Adv_Opener))
					{
					}

					if (IsEnabled(CustomComboPreset.BLM_ST_Adv_Thunder_ThunderCloud) &&
						HasEffect(Buffs.Thundercloud) &&
						((CanSpellWeave(actionID) && Config.BLM_Adv_ThunderCloud == 0) || Config.BLM_Adv_ThunderCloud == 1))
					{
						return OriginalHook(Thunder);
					}

					if (gauge.ElementTimeRemaining > 0)
					{
						if (IsEnabled(CustomComboPreset.BLM_Adv_UmbralSoul) && CurrentTarget is null)
						{
							if (gauge.InAstralFire && ActionReady(Transpose))
							{
								return Transpose;
							}

							if (gauge.InUmbralIce && ActionReady(UmbralSoul))
							{
								return UmbralSoul;
							}
						}

						if (IsEnabled(CustomComboPreset.BLM_Variant_Cure) &&
							IsEnabled(Variant.VariantCure) && PlayerHealthPercentageHp() <= Config.BLM_VariantCure)
						{
							return Variant.VariantCure;
						}

						if (IsEnabled(CustomComboPreset.BLM_Variant_Rampart) &&
							IsEnabled(Variant.VariantRampart) &&
							IsOffCooldown(Variant.VariantRampart) &&
							CanSpellWeave(actionID))
						{
							return Variant.VariantRampart;
						}

						if (IsEnabled(CustomComboPreset.BLM_Adv_Movement) && IsMoving && InCombat())
						{
							if (Config.BLM_Adv_Movement_Choice[0] &&
								!HasEffect(Buffs.Sharpcast) && ActionReady(Sharpcast))
							{
								return Sharpcast;
							}

							if (Config.BLM_Adv_Movement_Choice[1] &&
								HasEffect(Buffs.Thundercloud) && HasEffect(Buffs.Sharpcast) &&
								(dotDebuff is null || dotDebuff?.RemainingTime <= 10))
							{
								return OriginalHook(Thunder);
							}

							if (Config.BLM_Adv_Movement_Choice[2] &&
								HasEffect(Buffs.Firestarter) && gauge.InAstralFire && ActionReady(Fire3))
							{
								return Fire3;
							}

							if (Config.BLM_Adv_Movement_Choice[3] &&
								ActionReady(Paradox) && gauge.IsParadoxActive && gauge.InUmbralIce)
							{
								return Paradox;
							}

							if (Config.BLM_Adv_Movement_Choice[4] &&
								ActionReady(Xenoglossy) && gauge.PolyglotStacks > 1)
							{
								return Xenoglossy;
							}

							if ((rotationSelection is 0 || level < 90) &&
								Config.BLM_Adv_Movement_Choice[5] &&
								ActionReady(All.Swiftcast) && !HasEffect(Buffs.Triplecast))
							{
								return All.Swiftcast;
							}

							if (Config.BLM_Adv_Movement_Choice[6] &&
								ActionReady(Triplecast) && GetBuffStacks(Buffs.Triplecast) is 0 && !HasEffect(All.Buffs.Swiftcast))
							{
								return Triplecast;
							}

							if (Config.BLM_Adv_Movement_Choice[7] && (GetBuffStacks(Buffs.Triplecast) is 0) && ActionReady(Scathe))
							{
								return Scathe;
							}
						}

						if (rotationSelection is 1 &&
							gauge.InUmbralIce && ActionReady(All.Swiftcast) && level >= 90)
						{
							if (gauge.UmbralIceStacks < 3 &&
								ActionReady(All.LucidDreaming) && ActionReady(All.Swiftcast))
							{
								return All.LucidDreaming;
							}

							if (HasEffect(All.Buffs.LucidDreaming) && ActionReady(All.Swiftcast))
							{
								return All.Swiftcast;
							}
						}

						if (Config.BLM_Adv_Cooldowns_Choice[1] &&
							ActionReady(Sharpcast) && !HasEffect(Buffs.Sharpcast) &&
							!WasLastAction(Thunder3) && CanSpellWeave(actionID))
						{
							return Sharpcast;
						}

						if (IsEnabled(CustomComboPreset.BLM_Adv_Casts) &&
							((IsNotEnabled(CustomComboPreset.BLM_Adv_Triplecast_Pooling) && GetRemainingCharges(Triplecast) > 0) || GetRemainingCharges(Triplecast) is 2) &&
							ActionReady(Triplecast) && !HasEffect(Buffs.Triplecast) && !HasEffect(All.Buffs.Swiftcast) &&
							gauge.InAstralFire &&
							currentMP >= MP.FireI * 2)
						{
							return Triplecast;
						}

						if (IsEnabled(CustomComboPreset.BLM_Adv_Cooldowns) && CanSpellWeave(actionID))
						{
							if (Config.BLM_Adv_Cooldowns_Choice[3] && ActionReady(LeyLines))
							{
								return LeyLines;
							}

							if (Config.BLM_Adv_Cooldowns_Choice[2] &&
								ActionReady(Amplifier) && gauge.PolyglotStacks < 2)
							{
								return Amplifier;
							}
						}

						if (IsEnabled(CustomComboPreset.BLM_ST_Adv_Thunder) &&
							!ThunderList.ContainsKey(lastComboMove) &&
							(currentMP >= MP.ThunderST || (HasEffect(Buffs.Sharpcast) && HasEffect(Buffs.Thundercloud))))
						{
							if (ActionReady(Thunder) &&
								(dotDebuff is null || dotDebuff.RemainingTime <= thunderRefreshTime) && GetTargetHPPercent() > ThunderHP)
							{
								return OriginalHook(Thunder);
							}
						}
					}

					if (gauge.ElementTimeRemaining <= 0)
					{
						return (ActionReady(Blizzard3) && Config.BLM_Adv_InitialCast == 1) || (ActionReady(Fire3) && Config.BLM_Adv_InitialCast == 0 && currentMP < MP.FireIII)
							? Blizzard3
							: ActionReady(Fire3) && Config.BLM_Adv_InitialCast == 0
							? Fire3
							: (currentMP >= MP.FireI)
							? Fire
							: Blizzard;
					}

					if (!ActionReady(Blizzard3))
					{
						if (gauge.InAstralFire)
						{
							return (currentMP < MP.FireI)
								? Transpose
								: Fire;
						}

						if (gauge.InUmbralIce)
						{
							return (currentMP >= MP.MaxMP - MP.BlizzardI)
								? Transpose
								: Blizzard;
						}
					}

					if (!ActionReady(Fire4))
					{
						if (gauge.InAstralFire)
						{
							return HasEffect(Buffs.Firestarter) && GetBuffRemainingTime(Buffs.Firestarter) <= 27
								? Fire3
								: (currentMP < MP.FireI)
								? Blizzard3
								: Fire;
						}

						if (gauge.InUmbralIce)
						{
							return ActionReady(Blizzard4) && gauge.UmbralHearts < 3
								? Blizzard4
								: (currentMP == MP.MaxMP || gauge.UmbralHearts is 3)
								? Fire3
								: Blizzard;
						}
					}

					if (gauge.InAstralFire)
					{
						if (level >= 70 && ((gauge.PolyglotStacks is 2 && (gauge.EnochianTimer <= 3000) && TraitActionReady(Traits.EnhancedPolyGlot)) ||
							(gauge.PolyglotStacks is 1 && (gauge.EnochianTimer <= 6000) && !TraitActionReady(Traits.EnhancedPolyGlot))))
						{
							return ActionReady(Xenoglossy)
								? Xenoglossy
								: Foul;
						}

						if (gauge.AstralFireStacks < 3 || HasEffect(Buffs.Firestarter))
						{
							return Fire3;
						}

						if (gauge.ElementTimeRemaining <= (astralFireRefresh + 3000) && !HasEffect(Buffs.Thundercloud) && HasEffect(Buffs.Sharpcast) && currentMP >= MP.FireI && IsEnabled(CustomComboPreset.BLM_ST_Adv_Thunder))
						{
							return OriginalHook(Thunder);
						}

						if (gauge.ElementTimeRemaining <= astralFireRefresh && !HasEffect(Buffs.Firestarter) && currentMP >= MP.FireI)
						{
							return OriginalHook(Fire);
						}

						if (IsEnabled(CustomComboPreset.BLM_Adv_Cooldowns) &&
							Config.BLM_Adv_Cooldowns_Choice[0] &&
							ActionReady(Manafont) && WasLastAction(Despair))
						{
							return Manafont;
						}

						if (IsOnCooldown(Manafont) && WasLastAction(Manafont))
						{
							return Fire4;
						}

						if (rotationSelection is 1 && level >= 90 &&
							!WasLastAction(Manafont) && IsOnCooldown(Manafont) && ActionReady(All.Swiftcast) &&
							currentMP < MP.FireI && gauge.PolyglotStacks is 2)
						{
							if (WasLastAction(Despair))
							{
								return Transpose;
							}

							if (HasEffect(Buffs.Thundercloud) && HasEffect(Buffs.Sharpcast))
							{
								return Thunder3;
							}
						}

						return currentMP < MP.FireI || gauge.ElementTimeRemaining <= 5000
							? currentMP >= MP.FireI
								? OriginalHook(Fire)
								: currentMP < MP.FireI && currentMP >= MP.AllMPSpells && ActionReady(Despair) ? Despair : Blizzard3
							: Fire4;
					}

					if (gauge.InUmbralIce)
					{
						if (level >= 70 && gauge.EnochianTimer <= 20000 &&
							((gauge.PolyglotStacks is 2 && TraitActionReady(Traits.EnhancedPolyGlot)) ||
							(gauge.PolyglotStacks is 1 && !TraitActionReady(Traits.EnhancedPolyGlot))))
						{
							return ActionReady(Xenoglossy)
								? Xenoglossy
								: Foul;
						}

						if (rotationSelection is 1 && level >= 90 && HasEffect(All.Buffs.LucidDreaming))
						{
							if (ActionReady(Xenoglossy))
							{
								return Xenoglossy;
							}

							if (WasLastAction(Xenoglossy))
							{
								return Transpose;
							}
						}

						return rotationSelection is 0 && level >= 70
							? ActionReady(Xenoglossy)
									? Xenoglossy
									: Foul
							: Config.BLM_Adv_Xeno_Burst &&
							(rotationSelection is 0 && level >= 70) && gauge.PolyglotStacks is 2
							? ActionReady(Xenoglossy)
									? Xenoglossy
									: Foul
							: ActionReady(Paradox) && gauge.IsParadoxActive && gauge.UmbralHearts is 3 && currentMP == MP.MaxMP
							? Paradox
							: (gauge.UmbralHearts is 3 && currentMP == MP.MaxMP)
							? Fire3
							: Blizzard4;
					}

				}
				return actionID;
			}
		}

		internal class BLM_AoE_SimpleMode : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BLM_AoE_SimpleMode;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				uint currentMP = LocalPlayer.CurrentMp;
				BLMGauge? gauge = GetJobGauge<BLMGauge>();

				if (actionID is Blizzard2 or HighBlizzard2)
				{
					if (gauge.ElementTimeRemaining <= 0)
					{
						return OriginalHook(Blizzard2);
					}

					if (gauge.ElementTimeRemaining > 0)
					{
						if (CurrentTarget is null)
						{
							if (gauge.InAstralFire && ActionReady(Transpose))
							{
								return Transpose;
							}

							if (gauge.InUmbralIce && ActionReady(UmbralSoul))
							{
								return UmbralSoul;
							}
						}

						if (IsEnabled(CustomComboPreset.BLM_Variant_Cure) &&
							IsEnabled(Variant.VariantCure) &&
							PlayerHealthPercentageHp() <= Config.BLM_VariantCure)
						{
							return Variant.VariantCure;
						}

						if (IsEnabled(CustomComboPreset.BLM_Variant_Rampart) &&
							IsEnabled(Variant.VariantRampart) &&
							IsOffCooldown(Variant.VariantRampart) &&
							CanSpellWeave(actionID))
						{
							return Variant.VariantRampart;
						}
					}

					if (gauge.InAstralFire)
					{
						if (ActionReady(Flare))
						{
							if (ActionReady(Manafont) && currentMP is 0)
							{
								return Manafont;
							}

							if (WasLastAction(Manafont))
							{
								return Flare;
							}
						}

						if (ActionReady(Foul) && WasLastAction(OriginalHook(Flare)))
						{
							return Foul;
						}

						if ((currentMP is 0 && WasLastAction(Flare)) ||
							(currentMP < MP.FireAoE && !ActionReady(Flare)))
						{
							return OriginalHook(Blizzard2);
						}

						if (currentMP >= MP.AllMPSpells)
						{
							if (!ThunderList.ContainsKey(lastComboMove) && currentMP >= MP.ThunderAoE)
							{
								if (ActionReady(Thunder4) &&
									GetDebuffRemainingTime(Debuffs.Thunder4) <= 4)
								{
									return Thunder4;
								}

								if (ActionReady(Thunder2) && !ActionReady(Thunder4) &&
									GetDebuffRemainingTime(Debuffs.Thunder2) <= 4)
								{
									return Thunder2;
								}
							}

							if (ActionReady(Flare) && HasEffect(Buffs.EnhancedFlare) &&
								(gauge.UmbralHearts is 1 || currentMP < MP.FireAoE) &&
								ActionReady(Triplecast) && !HasEffect(Buffs.Triplecast))
							{
								return Triplecast;
							}

							if (ActionReady(Flare) && HasEffect(Buffs.EnhancedFlare) &&
								(gauge.UmbralHearts is 1 || currentMP < MP.FireAoE))
							{
								return Flare;
							}

							if (currentMP > MP.FireAoE)
							{
								return OriginalHook(Fire2);
							}
						}
					}

					if (gauge.InUmbralIce)
					{
						if (gauge.UmbralHearts < 3 && ActionReady(Freeze) && TraitActionReady(Traits.EnhancedFreeze) && currentMP >= MP.Freeze)
						{
							return Freeze;
						}

						if (!ThunderList.ContainsKey(lastComboMove) && currentMP >= MP.ThunderAoE)
						{
							if (ActionReady(Thunder4) &&
								GetDebuffRemainingTime(Debuffs.Thunder4) <= 4)
							{
								return Thunder4;
							}

							if (ActionReady(Thunder2) && !ActionReady(Thunder4) &&
								GetDebuffRemainingTime(Debuffs.Thunder2) <= 4)
							{
								return Thunder2;
							}
						}

						if (currentMP < 9400 && !TraitActionReady(Traits.EnhancedFreeze) && Freeze.ActionReady() && currentMP >= MP.Freeze)
						{
							return Freeze;
						}

						if (currentMP >= 9400 && !TraitActionReady(Traits.AspectMasteryIII))
						{
							return Transpose;
						}

						if ((gauge.UmbralHearts is 3 || currentMP == MP.MaxMP) &&
							TraitActionReady(Traits.AspectMasteryIII))
						{
							return OriginalHook(Fire2);
						}
					}
				}

				return actionID;
			}
		}

		internal class BLM_AoE_AdvancedMode : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BLM_AoE_AdvancedMode;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				uint currentMP = LocalPlayer.CurrentMp;
				int thunderRefreshTime = Config.BLM_AoE_Adv_ThunderUptime;
				BLMGauge? gauge = GetJobGauge<BLMGauge>();
				int ThunderHP = Config.BLM_AoE_Adv_ThunderHP;

				if (actionID is Blizzard2 or HighBlizzard2)
				{
					if (gauge.ElementTimeRemaining <= 0)
					{
						return OriginalHook(Blizzard2);
					}

					if (gauge.ElementTimeRemaining > 0)
					{
						if (IsEnabled(CustomComboPreset.BLM_AoE_Adv_UmbralSoul) && CurrentTarget is null)
						{
							if (gauge.InAstralFire && ActionReady(Transpose))
							{
								return Transpose;
							}

							if (gauge.InUmbralIce && ActionReady(UmbralSoul))
							{
								return UmbralSoul;
							}
						}

						if (IsEnabled(CustomComboPreset.BLM_Variant_Cure) &&
							IsEnabled(Variant.VariantCure) &&
							PlayerHealthPercentageHp() <= Config.BLM_VariantCure)
						{
							return Variant.VariantCure;
						}

						if (IsEnabled(CustomComboPreset.BLM_Variant_Rampart) &&
							IsEnabled(Variant.VariantRampart) &&
							IsOffCooldown(Variant.VariantRampart) &&
							CanSpellWeave(actionID))
						{
							return Variant.VariantRampart;
						}

						if (IsEnabled(CustomComboPreset.BLM_AoE_Adv_Cooldowns) && CanSpellWeave(actionID))
						{
							if (Config.BLM_AoE_Adv_Cooldowns_Choice[3] && ActionReady(LeyLines))
							{
								return LeyLines;
							}

							if (Config.BLM_AoE_Adv_Cooldowns_Choice[2] &&
								ActionReady(Amplifier) && gauge.PolyglotStacks < 2)
							{
								return Amplifier;
							}

							if (Config.BLM_AoE_Adv_Cooldowns_Choice[1] &&
								ActionReady(Sharpcast) && !HasEffect(Buffs.Sharpcast) &&
								!WasLastAction(Thunder3) && CanSpellWeave(actionID))
							{
								return Sharpcast;
							}
						}
					}

					if (gauge.InAstralFire)
					{
						if ((ActionReady(Foul) &&
							gauge.PolyglotStacks is 2 && (gauge.EnochianTimer <= 3000) && TraitActionReady(Traits.EnhancedPolyGlot)) ||
							(gauge.PolyglotStacks is 1 && (gauge.EnochianTimer <= 6000) && !TraitActionReady(Traits.EnhancedPolyGlot)))
						{
							return Foul;
						}

						if (ActionReady(Flare))
						{
							if (Config.BLM_AoE_Adv_Cooldowns_Choice[0] && ActionReady(Manafont) &&
								currentMP is 0)
							{
								return Manafont;
							}

							if (WasLastAction(Manafont))
							{
								return Flare;
							}
						}

						if (IsEnabled(CustomComboPreset.BLM_AoE_Adv_Foul) && ActionReady(Foul)
							&& WasLastAction(OriginalHook(Flare)))
						{
							return Foul;
						}

						if ((currentMP is 0 && WasLastAction(Flare)) ||
							(currentMP < MP.FireAoE && !ActionReady(Flare)))
						{
							return OriginalHook(Blizzard2);
						}

						if (currentMP >= MP.AllMPSpells)
						{
							if (IsEnabled(CustomComboPreset.BLM_AoE_Adv_ThunderUptime_AstralFire) &&
								!ThunderList.ContainsKey(lastComboMove) && currentMP >= MP.ThunderAoE)
							{
								if (ActionReady(Thunder4) &&
									 (GetDebuffRemainingTime(Debuffs.Thunder4) <= thunderRefreshTime))
								{
									return Thunder4;
								}

								if (ActionReady(Thunder2) && !ActionReady(Thunder4) &&
									(GetDebuffRemainingTime(Debuffs.Thunder2) <= thunderRefreshTime))
								{
									return Thunder2;
								}
							}

							if (ActionReady(Flare) && HasEffect(Buffs.EnhancedFlare) && TraitActionReady(Traits.Enochian) &&
								(gauge.UmbralHearts is 1 || currentMP < MP.FireAoE) && Config.BLM_AoE_Adv_Cooldowns_Choice[4] && IsEnabled(CustomComboPreset.BLM_AoE_Adv_Cooldowns) &&
								ActionReady(Triplecast) && !HasEffect(Buffs.Triplecast))
							{
								return Triplecast;
							}

							if (ActionReady(Flare) && HasEffect(Buffs.EnhancedFlare) && TraitActionReady(Traits.Enochian) &&
							(gauge.UmbralHearts is 1 || currentMP < MP.FireAoE))
							{
								return Flare;
							}

							if (currentMP > MP.FireAoE)
							{
								return OriginalHook(Fire2);
							}

							if (ActionReady(Flare))
							{
								return Flare;
							}
						}
					}

					if (gauge.InUmbralIce)
					{
						if (ActionReady(Foul) && gauge.EnochianTimer <= 20000 &&
							((gauge.PolyglotStacks is 2 && TraitActionReady(Traits.EnhancedPolyGlot)) ||
							(gauge.PolyglotStacks is 1 && !TraitActionReady(Traits.EnhancedPolyGlot))))
						{
							return Foul;
						}

						if (gauge.UmbralHearts < 3 && ActionReady(Freeze) && TraitActionReady(Traits.EnhancedFreeze) && currentMP >= MP.Freeze)
						{
							return Freeze;
						}

						if (IsEnabled(CustomComboPreset.BLM_AoE_Adv_ThunderUptime) &&
						   !ThunderList.ContainsKey(lastComboMove) && currentMP >= MP.ThunderAoE)
						{
							if (ActionReady(Thunder4) &&
								(GetDebuffRemainingTime(Debuffs.Thunder4) <= thunderRefreshTime) && GetTargetHPPercent() > ThunderHP)
							{
								return Thunder4;
							}

							if (ActionReady(Thunder2) && !ActionReady(Thunder4) &&
								(GetDebuffRemainingTime(Debuffs.Thunder2) <= thunderRefreshTime) && GetTargetHPPercent() > ThunderHP)
							{
								return Thunder2;
							}
						}

						if (currentMP < 9400 && !TraitActionReady(Traits.EnhancedFreeze) && ActionReady(Freeze) && currentMP >= MP.Freeze)
						{
							return Freeze;
						}

						if (currentMP >= 9400 && !TraitActionReady(Traits.AspectMasteryIII))
						{
							return Transpose;
						}

						if ((gauge.UmbralHearts is 3 || currentMP == MP.MaxMP) &&
							TraitActionReady(Traits.AspectMasteryIII))
						{
							return OriginalHook(Fire2);
						}
					}
				}

				return actionID;
			}
		}

		internal class BLM_Variant_Raise : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BLM_Variant_Raise;

			protected override uint Invoke(uint actionID, uint lastComboActionID, float comboTime, byte level)
			{
				return (actionID is All.Swiftcast && HasEffect(All.Buffs.Swiftcast) && IsEnabled(Variant.VariantRaise))
				? Variant.VariantRaise
				: actionID;
			}
		}

		internal class BLM_Scathe_Xeno : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BLM_Scathe_Xeno;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				return (actionID is Scathe && ActionReady(Xenoglossy))
				? Xenoglossy
				: actionID;
			}
		}

		internal class BLM_Blizzard_1to3 : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BLM_Blizzard_1to3;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				return actionID is Blizzard && ActionReady(Freeze) && !GetJobGauge<BLMGauge>().InUmbralIce
					? Blizzard3
					: actionID is Freeze && !ActionReady(Freeze) ? Blizzard2 : actionID;
			}
		}

		internal class BLM_Fire_1to3 : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BLM_Fire_1to3;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				return (actionID is Fire && ((ActionReady(Fire3) && !GetJobGauge<BLMGauge>().InAstralFire) || HasEffect(Buffs.Firestarter)))
				? Fire3
				: actionID;
			}
		}

		internal class BLM_Between_The_LeyLines : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BLM_Between_The_LeyLines;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				return actionID is LeyLines && HasEffect(Buffs.LeyLines) && ActionReady(BetweenTheLines)
				? BetweenTheLines
				: actionID;
			}
		}

		internal class BLM_Aetherial_Manipulation : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BLM_Aetherial_Manipulation;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				return actionID is AetherialManipulation &&
				ActionReady(BetweenTheLines) &&
				HasEffect(Buffs.LeyLines) &&
				!HasEffect(Buffs.CircleOfPower) &&
				!IsMoving
				? BetweenTheLines
				: actionID;
			}
		}

		internal class BLM_UmbralSoul : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BLM_UmbralSoul;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				return actionID is Transpose && GetJobGauge<BLMGauge>().InUmbralIce && ActionReady(UmbralSoul)
				? UmbralSoul
				: actionID;
			}
		}
	}
}