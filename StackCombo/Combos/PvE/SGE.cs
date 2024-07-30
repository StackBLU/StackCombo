using Dalamud.Game.ClientState.JobGauge.Types;
using Dalamud.Game.ClientState.Objects.Types;
using Dalamud.Game.ClientState.Statuses;
using StackCombo.ComboHelper.Functions;
using StackCombo.Combos.PvE.Content;
using StackCombo.CustomCombo;
using System.Collections.Generic;
using System.Linq;

namespace StackCombo.Combos.PvE
{
	internal static class SGE
	{
		internal const byte JobID = 40;

		internal const uint
			Diagnosis = 24284,
			Prognosis = 24286,
			Physis = 24288,
			Druochole = 24296,
			Kerachole = 24298,
			Ixochole = 24299,
			Pepsis = 24301,
			Physis2 = 24302,
			Taurochole = 24303,
			Haima = 24305,
			Panhaima = 24311,
			Holos = 24310,
			EukrasianDiagnosis = 24291,
			EukrasianPrognosis = 24292,
			Egeiro = 24287,

			Dosis = 24283,
			Dosis2 = 24306,
			Dosis3 = 24312,
			EukrasianDosis = 24293,
			EukrasianDosis2 = 24308,
			EukrasianDosis3 = 24314,
			Phlegma = 24289,
			Phlegma2 = 24307,
			Phlegma3 = 24313,
			Dyskrasia = 24297,
			Dyskrasia2 = 24315,
			Toxikon = 24304,
			Pneuma = 24318,
			EukrasianDyskrasia = 37032,
			Psyche = 37033,

			Soteria = 24294,
			Zoe = 24300,
			Krasis = 24317,
			Philosophia = 37035,

			Kardia = 24285,
			Eukrasia = 24290,
			Rhizomata = 24309;

		internal static readonly List<uint>
			AddersgallList = [Taurochole, Druochole, Ixochole, Kerachole],
			DyskrasiaList = [Dyskrasia, Dyskrasia2];

		internal static class Buffs
		{
			internal const ushort
				Kardia = 2604,
				Kardion = 2605,
				Eukrasia = 2606,
				EukrasianDiagnosis = 2607,
				EukrasianPrognosis = 2609,
				Panhaima = 2613,
				Kerachole = 2618,
				Eudaimonia = 3899;
		}

		internal static class Debuffs
		{
			internal const ushort
				EukrasianDosis = 2614,
				EukrasianDosis2 = 2615,
				EukrasianDosis3 = 2616,
				EukrasianDyskrasia = 3897;
		}

		internal static readonly Dictionary<uint, ushort>
			DosisList = new()
			{
				{ Dosis,  Debuffs.EukrasianDosis  },
				{ Dosis2, Debuffs.EukrasianDosis2 },
				{ Dosis3, Debuffs.EukrasianDosis3 }
			};

		public static SGEGauge Gauge
		{
			get
			{
				return CustomComboFunctions.GetJobGauge<SGEGauge>();
			}
		}

		public static bool HasAddersgall(this SGEGauge gauge)
		{
			return gauge.Addersgall > 0;
		}

		public static bool HasAddersting(this SGEGauge gauge)
		{
			return gauge.Addersting > 0;
		}

		public static class Config
		{
			#region DPS
			public static UserBool
				SGE_ST_DPS_Adv = new("SGE_ST_DPS_Adv"),
				SGE_ST_DPS_EDosis_Adv = new("SGE_ST_Dosis_EDosis_Adv");
			public static UserBoolArray
				SGE_ST_DPS_Movement = new("SGE_ST_DPS_Movement");
			public static UserInt
				SGE_ST_DPS_EDosisHPPer = new("SGE_ST_DPS_EDosisHPPer", 10),
				SGE_ST_DPS_Lucid = new("SGE_ST_DPS_Lucid", 6500),
				SGE_ST_DPS_Rhizo = new("SGE_ST_DPS_Rhizo"),
				SGE_ST_DPS_AddersgallProtect = new("SGE_ST_DPS_AddersgallProtect", 3),
				SGE_AoE_DPS_Lucid = new("SGE_AoE_Phlegma_Lucid", 6500),
				SGE_AoE_DPS_Rhizo = new("SGE_AoE_DPS_Rhizo"),
				SGE_AoE_DPS_AddersgallProtect = new("SGE_AoE_DPS_AddersgallProtect", 3);
			public static UserFloat
				SGE_ST_DPS_EDosisThreshold = new("SGE_ST_Dosis_EDosisThreshold", 3.0f);
			#endregion

			#region Healing
			public static UserBool
				SGE_ST_Heal_Adv = new("SGE_ST_Heal_Adv"),
				SGE_ST_Heal_UIMouseOver = new("SGE_ST_Heal_UIMouseOver"),
				SGE_AoE_Heal_KeracholeTrait = new("SGE_AoE_Heal_KeracholeTrait");
			public static UserInt
				SGE_ST_Heal_Zoe = new("SGE_ST_Heal_Zoe"),
				SGE_ST_Heal_Haima = new("SGE_ST_Heal_Haima"),
				SGE_ST_Heal_Krasis = new("SGE_ST_Heal_Krasis"),
				SGE_ST_Heal_Pepsis = new("SGE_ST_Heal_Pepsis"),
				SGE_ST_Heal_Soteria = new("SGE_ST_Heal_Soteria"),
				SGE_ST_Heal_EDiagnosisHP = new("SGE_ST_Heal_EDiagnosisHP"),
				SGE_ST_Heal_Druochole = new("SGE_ST_Heal_Druochole"),
				SGE_ST_Heal_Taurochole = new("SGE_ST_Heal_Taurochole"),
				SGE_ST_Heal_Lucid = new("SGE_ST_Heal_Lucid", 6500),
				SGE_AoE_Heal_Lucid = new("SGE_AoE_Heal_Lucid", 6500),
				SGE_ST_Heal_Esuna = new("SGE_ST_Heal_Esuna");
			public static UserIntArray
				SGE_ST_Heals_Priority = new("SGE_ST_Heals_Priority"),
				SGE_AoE_Heals_Priority = new("SGE_AoE_Heals_Priority");
			public static UserBoolArray
				SGE_ST_Heal_EDiagnosisOpts = new("SGE_ST_Heal_EDiagnosisOpts");
			#endregion

			public static UserInt
				SGE_Eukrasia_Mode = new("SGE_Eukrasia_Mode");
		}

		internal static class Traits
		{
			internal const ushort
				EnhancedKerachole = 375,
				OffensiveMagicMasteryII = 376;
		}

		internal class SGE_ST_DPS : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SGE_ST_DPS;
			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID is Dosis || actionID is Dosis2 || actionID is Dosis3)
				{
					if (IsEnabled(CustomComboPreset.SGE_ST_DPS_Lucid) && ActionReady(All.LucidDreaming) && LocalPlayer.CurrentMp <= 1000)
					{
						return All.LucidDreaming;
					}

					if (IsEnabled(CustomComboPreset.SGE_ST_DPS_Kardia) && LevelChecked(Kardia) &&
						FindEffect(Buffs.Kardia) is null)
					{
						return Kardia;
					}

					if (IsEnabled(CustomComboPreset.SGE_ST_DPS_Lucid) &&
						ActionReady(All.LucidDreaming) && CanSpellWeave(actionID) &&
						LocalPlayer.CurrentMp <= Config.SGE_ST_DPS_Lucid)
					{
						return All.LucidDreaming;
					}

					if (IsEnabled(CustomComboPreset.SGE_DPS_Variant_Rampart) &&
						IsEnabled(Variant.VariantRampart) &&
						IsOffCooldown(Variant.VariantRampart) &&
						CanSpellWeave(actionID))
					{
						return Variant.VariantRampart;
					}

					if (IsEnabled(CustomComboPreset.SGE_ST_DPS_Rhizo) && CanSpellWeave(actionID) &&
						ActionReady(Rhizomata) && Gauge.Addersgall <= Config.SGE_ST_DPS_Rhizo)
					{
						return Rhizomata;
					}

					if (IsEnabled(CustomComboPreset.SGE_ST_DPS_AddersgallProtect) && CanSpellWeave(Dosis) &&
						ActionReady(Druochole) && Gauge.Addersgall >= Config.SGE_ST_DPS_AddersgallProtect)
					{
						return Druochole;
					}

					if (HasBattleTarget() && !HasEffect(Buffs.Eukrasia))
					{
						if (IsEnabled(CustomComboPreset.SGE_ST_DPS_EDosis) && LevelChecked(Eukrasia) && InCombat())
						{
							if (DosisList.TryGetValue(OriginalHook(actionID), out ushort dotDebuffID))
							{
								Status? sustainedDamage = FindTargetEffect(Variant.Debuffs.SustainedDamage);
								if (IsEnabled(CustomComboPreset.SGE_DPS_Variant_SpiritDart) &&
									IsEnabled(Variant.VariantSpiritDart) &&
									(sustainedDamage is null || sustainedDamage?.RemainingTime <= 3) &&
									CanSpellWeave(actionID))
								{
									return Variant.VariantSpiritDart;
								}

								Status? dosisDebuff = FindTargetEffect(dotDebuffID);
								Status? dyskrasiaDebuff = null;
								if (TraitLevelChecked(Traits.OffensiveMagicMasteryII))
								{
									dyskrasiaDebuff = FindTargetEffect(Debuffs.EukrasianDyskrasia);
								}

								Status? dotDebuff = dosisDebuff ?? dyskrasiaDebuff;
								float refreshtimer = Config.SGE_ST_DPS_EDosis_Adv ? Config.SGE_ST_DPS_EDosisThreshold : 3;

								if ((dotDebuff is null || dotDebuff.RemainingTime <= refreshtimer) &&
									GetTargetHPPercent() > Config.SGE_ST_DPS_EDosisHPPer)
								{
									return Eukrasia;
								}
							}
						}

						if (IsEnabled(CustomComboPreset.SGE_ST_DPS_Phlegma) && InCombat())
						{
							uint phlegma = OriginalHook(Phlegma);
							if (InActionRange(phlegma) && ActionReady(phlegma))
							{
								return phlegma;
							}
						}

						if (IsEnabled(CustomComboPreset.SGE_ST_DPS_Psyche) &&
							ActionReady(Psyche) &&
							InCombat() &&
							CanSpellWeave(actionID))
						{
							return Psyche;
						}

						if (IsEnabled(CustomComboPreset.SGE_ST_DPS_Movement) && InCombat() && IsMoving)
						{
							if (Config.SGE_ST_DPS_Movement[3] && ActionReady(Psyche))
							{
								return Psyche;
							}

							if (Config.SGE_ST_DPS_Movement[0] && LevelChecked(Toxikon) && Gauge.HasAddersting())
							{
								return OriginalHook(Toxikon);
							}

							if (Config.SGE_ST_DPS_Movement[1] && LevelChecked(Dyskrasia) && InActionRange(Dyskrasia))
							{
								return OriginalHook(Dyskrasia);
							}

							if (Config.SGE_ST_DPS_Movement[2] && LevelChecked(Eukrasia))
							{
								return Eukrasia;
							}
						}
					}
				}
				return actionID;
			}
		}

		internal class SGE_AoE_DPS : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SGE_AoE_DPS;
			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (DyskrasiaList.Contains(actionID))
				{

					if (IsEnabled(CustomComboPreset.SGE_AoE_DPS_Lucid) && ActionReady(All.LucidDreaming) && LocalPlayer.CurrentMp <= 1000)
					{
						return All.LucidDreaming;
					}

					if (!HasEffect(Buffs.Eukrasia))
					{
						if (IsEnabled(CustomComboPreset.SGE_DPS_Variant_Rampart) &&
							IsEnabled(Variant.VariantRampart) &&
							IsOffCooldown(Variant.VariantRampart) &&
							CanSpellWeave(actionID))
						{
							return Variant.VariantRampart;
						}

						Status? sustainedDamage = FindTargetEffect(Variant.Debuffs.SustainedDamage);
						if (IsEnabled(CustomComboPreset.SGE_DPS_Variant_SpiritDart) &&
							IsEnabled(Variant.VariantSpiritDart) &&
							(sustainedDamage is null || sustainedDamage?.RemainingTime <= 3) &&
							CanSpellWeave(actionID))
						{
							return Variant.VariantSpiritDart;
						}

						if (IsEnabled(CustomComboPreset.SGE_AoE_DPS_Lucid) &&
							ActionReady(All.LucidDreaming) && CanSpellWeave(Dosis) &&
							LocalPlayer.CurrentMp <= Config.SGE_AoE_DPS_Lucid)
						{
							return All.LucidDreaming;
						}

						if (IsEnabled(CustomComboPreset.SGE_AoE_DPS_Rhizo) && CanSpellWeave(Dosis) &&
							ActionReady(Rhizomata) && Gauge.Addersgall <= Config.SGE_AoE_DPS_Rhizo)
						{
							return Rhizomata;
						}

						if (IsEnabled(CustomComboPreset.SGE_AoE_DPS_AddersgallProtect) && CanSpellWeave(Dosis) &&
							ActionReady(Druochole) && Gauge.Addersgall >= Config.SGE_AoE_DPS_AddersgallProtect)
						{
							return Druochole;
						}

						if (IsEnabled(CustomComboPreset.SGE_AoE_DPS_EDyskrasia))
						{
							if (IsOffCooldown(Eukrasia) &&
								!WasLastSpell(EukrasianDyskrasia) &&
								TraitLevelChecked(Traits.OffensiveMagicMasteryII) &&
								HasBattleTarget() &&
								InActionRange(Dyskrasia))
							{
								Status? dosisDebuff = FindTargetEffect(Debuffs.EukrasianDosis3);
								Status? dyskrasiaDebuff = FindTargetEffect(Debuffs.EukrasianDyskrasia);
								Status? dotDebuff = dosisDebuff ?? dyskrasiaDebuff;

								float refreshtimer = 3;

								if ((dotDebuff is null || dotDebuff.RemainingTime <= refreshtimer) &&
									GetTargetHPPercent() > 10)
								{
									return Eukrasia;
								}
							}
						}

						if (IsEnabled(CustomComboPreset.SGE_AoE_DPS_Psyche))
						{
							if (ActionReady(Psyche) &&
								HasBattleTarget() &&
								InActionRange(Psyche) &&
								CanSpellWeave(actionID))
							{
								return Psyche;
							}
						}

						if (IsEnabled(CustomComboPreset.SGE_AoE_DPS_Phlegma))
						{
							uint PhlegmaID = OriginalHook(Phlegma);
							if (ActionReady(PhlegmaID) &&
								HasBattleTarget() &&
								InActionRange(PhlegmaID))
							{
								return PhlegmaID;
							}
						}

						if (IsEnabled(CustomComboPreset.SGE_AoE_DPS_Toxikon))
						{
							uint ToxikonID = OriginalHook(Toxikon);
							if (ActionReady(ToxikonID) &&
								HasBattleTarget() &&
								InActionRange(ToxikonID) &&
								Gauge.HasAddersting())
							{
								return ToxikonID;
							}
						}
					}
				}
				return actionID;
			}
		}

		internal class SGE_ST_Heal : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SGE_ST_Heal;
			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID is Diagnosis)
				{
					if (IsEnabled(CustomComboPreset.SGE_ST_Heal_Lucid) && ActionReady(All.LucidDreaming) && LocalPlayer.CurrentMp <= 1000)
					{
						return All.LucidDreaming;
					}

					if (HasEffect(Buffs.Eukrasia))
					{
						return EukrasianDiagnosis;
					}

					IGameObject? healTarget = GetHealTarget(Config.SGE_ST_Heal_Adv && Config.SGE_ST_Heal_UIMouseOver);

					if (IsEnabled(CustomComboPreset.SGE_ST_Heal_Esuna) && ActionReady(All.Esuna) &&
						GetTargetHPPercent(healTarget) >= Config.SGE_ST_Heal_Esuna &&
						HasCleansableDebuff(healTarget))
					{
						return All.Esuna;
					}

					if (IsEnabled(CustomComboPreset.SGE_ST_Heal_Rhizomata) && ActionReady(Rhizomata) &&
						!Gauge.HasAddersgall())
					{
						return Rhizomata;
					}

					if (IsEnabled(CustomComboPreset.SGE_ST_Heal_Lucid) &&
						ActionReady(All.LucidDreaming) &&
						LocalPlayer.CurrentMp <= Config.SGE_ST_Heal_Lucid &&
						CanSpellWeave(actionID))
					{
						return All.LucidDreaming;
					}

					if (IsEnabled(CustomComboPreset.SGE_ST_Heal_Kardia) && LevelChecked(Kardia) &&
						FindEffect(Buffs.Kardia) is null &&
						FindEffect(Buffs.Kardion, healTarget, LocalPlayer?.GameObjectId) is null)
					{
						return Kardia;
					}

					foreach (int prio in Config.SGE_ST_Heals_Priority.Items.OrderBy(x => x))
					{
						int index = Config.SGE_ST_Heals_Priority.IndexOf(prio);
						int config = JobHelpers.SGE.GetMatchingConfigST(index, out uint spell, out bool enabled);

						if (enabled)
						{
							if (GetTargetHPPercent(healTarget) <= config &&
								ActionReady(spell))
							{
								return spell;
							}
						}
					}

					if (IsEnabled(CustomComboPreset.SGE_ST_Heal_EDiagnosis) && LevelChecked(Eukrasia) &&
						GetTargetHPPercent(healTarget) <= Config.SGE_ST_Heal_EDiagnosisHP &&
						(Config.SGE_ST_Heal_EDiagnosisOpts[0] || FindEffectOnMember(Buffs.EukrasianDiagnosis, healTarget) is null) &&
						(!Config.SGE_ST_Heal_EDiagnosisOpts[1] || FindEffectOnMember(SCH.Buffs.Galvanize, healTarget) is null))
					{
						return Eukrasia;
					}
				}

				return actionID;
			}
		}

		internal class SGE_AoE_Heal : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SGE_AoE_Heal;
			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID is Prognosis)
				{
					if (IsEnabled(CustomComboPreset.SGE_AoE_Heal_Lucid) && ActionReady(All.LucidDreaming) && LocalPlayer.CurrentMp <= 1000)
					{
						return All.LucidDreaming;
					}

					if (IsEnabled(CustomComboPreset.SGE_AoE_Heal_EPrognosis) && HasEffect(Buffs.Eukrasia))
					{
						return OriginalHook(Prognosis);
					}

					if (IsEnabled(CustomComboPreset.SGE_AoE_Heal_Rhizomata) && ActionReady(Rhizomata) &&
						!Gauge.HasAddersgall())
					{
						return Rhizomata;
					}

					if (IsEnabled(CustomComboPreset.SGE_AoE_Heal_Lucid) &&
					   ActionReady(All.LucidDreaming) &&
					   LocalPlayer.CurrentMp <= Config.SGE_AoE_Heal_Lucid &&
					   CanSpellWeave(actionID))
					{
						return All.LucidDreaming;
					}

					foreach (int prio in Config.SGE_AoE_Heals_Priority.Items.OrderBy(x => x))
					{
						int index = Config.SGE_AoE_Heals_Priority.IndexOf(prio);
						int config = JobHelpers.SGE.GetMatchingConfigAoE(index, out uint spell, out bool enabled);

						if (enabled)
						{
							if (ActionReady(spell))
							{
								return spell;
							}
						}
					}

					if (IsEnabled(CustomComboPreset.SGE_AoE_Heal_EPrognosis) && LevelChecked(Eukrasia) &&
						(IsEnabled(CustomComboPreset.SGE_AoE_Heal_EPrognosis_IgnoreShield) ||
						 FindEffect(Buffs.EukrasianPrognosis) is null))
					{
						return Eukrasia;
					}
				}

				return actionID;
			}
		}

		internal class SGE_Kardia : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SGE_Kardia;
			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				return actionID is Soteria && (!HasEffect(Buffs.Kardia) || IsOnCooldown(Soteria)) ? Kardia : actionID;
			}
		}

		internal class SGE_Rhizo : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SGE_Rhizo;
			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				return AddersgallList.Contains(actionID) && ActionReady(Rhizomata) && !Gauge.HasAddersgall() && IsOffCooldown(actionID) ? Rhizomata : actionID;
			}
		}

		internal class SGE_DruoTauro : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SGE_DruoTauro;
			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				return actionID is Druochole && ActionReady(Taurochole) ? Taurochole : actionID;
			}
		}

		internal class SGE_ZoePneuma : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SGE_ZoePneuma;
			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				return actionID is Pneuma && ActionReady(Pneuma) && IsOffCooldown(Zoe) ? Zoe : actionID;
			}
		}

		internal class SGE_Raise : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SGE_Raise;
			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				return actionID is Egeiro && IsOnCooldown(All.Swiftcast) ? Egeiro : actionID;
			}
		}

		internal class SGE_Eukrasia : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SGE_Eukrasia;
			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID is Eukrasia && HasEffect(Buffs.Eukrasia))
				{
					switch ((int)Config.SGE_Eukrasia_Mode)
					{
						case 0: return OriginalHook(Dosis);
						case 1: return OriginalHook(Diagnosis);
						case 2: return OriginalHook(Prognosis);
						case 3: return OriginalHook(Dyskrasia);
						default: break;
					}
				}

				return actionID;
			}
		}

		internal class SGE_OverProtect : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SGE_OverProtect;
			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID is Kerachole && IsEnabled(CustomComboPreset.SGE_OverProtect_Kerachole) && ActionReady(Kerachole))
				{
					if (HasEffectAny(Buffs.Kerachole) ||
						(IsEnabled(CustomComboPreset.SGE_OverProtect_SacredSoil) && HasEffectAny(SCH.Buffs.SacredSoil)))
					{
						return SCH.SacredSoil;
					}
				}

				return actionID is Panhaima && IsEnabled(CustomComboPreset.SGE_OverProtect_Panhaima) &&
					ActionReady(Panhaima) && HasEffectAny(Buffs.Panhaima)
					? SCH.SacredSoil
					: actionID is Philosophia && IsEnabled(CustomComboPreset.SGE_OverProtect_Philosophia) &&
					ActionReady(Philosophia) && HasEffectAny(Buffs.Eudaimonia)
					? SCH.Consolation
					: actionID;
			}
		}
	}
}