using Dalamud.Game.ClientState.JobGauge.Types;
using StackCombo.ComboHelper.Functions;
using StackCombo.Combos.PvE.Content;
using StackCombo.CustomCombo;
using StackCombo.Data;
using System.Collections.Generic;

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

		public static class Config
		{
			public static UserInt
				SGE_ST_DPS_Lucid = new("SGE_ST_DPS_Lucid", 7500),
				SGE_ST_DPS_Rhizo = new("SGE_ST_DPS_Rhizo", 0),
				SGE_ST_DPS_AddersgallProtect = new("SGE_ST_DPS_AddersgallProtect", 3),
				SGE_AoE_DPS_Lucid = new("SGE_AoE_Phlegma_Lucid", 7500),
				SGE_AoE_DPS_Rhizo = new("SGE_AoE_DPS_Rhizo", 0),
				SGE_AoE_DPS_AddersgallProtect = new("SGE_AoE_DPS_AddersgallProtect", 3);
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
				if (actionID is Dosis or Dosis2 or Dosis3)
				{
					if (IsEnabled(CustomComboPreset.SGE_ST_DPS_Lucid) && ActionReady(All.LucidDreaming) && LocalPlayer.CurrentMp <= 1000)
					{
						return All.LucidDreaming;
					}

					if (IsEnabled(CustomComboPreset.SGE_DPS_Variant_Rampart) && IsEnabled(Variant.VariantRampart) && IsOffCooldown(Variant.VariantRampart))
					{
						return Variant.VariantRampart;
					}

					if (IsEnabled(CustomComboPreset.SGE_DPS_Variant_SpiritDart) && IsEnabled(Variant.VariantSpiritDart)
						&& (!TargetHasEffectAny(Variant.Debuffs.SustainedDamage) || GetDebuffRemainingTime(Variant.Debuffs.SustainedDamage) <= 3))
					{
						return Variant.VariantSpiritDart;
					}

					if (IsEnabled(CustomComboPreset.SGE_ST_DPS_Kardia) && ActionReady(Kardia) && !HasEffect(Buffs.Kardia))
					{
						return Kardia;
					}

					if (IsEnabled(CustomComboPreset.SGE_ST_DPS_Lucid) && ActionReady(All.LucidDreaming)
						&& CanSpellWeave(actionID) && LocalPlayer.CurrentMp <= Config.SGE_ST_DPS_Lucid)
					{
						return All.LucidDreaming;
					}

					if (IsEnabled(CustomComboPreset.SGE_ST_DPS_Rhizo) && CanSpellWeave(actionID) &&
						ActionReady(Rhizomata) && Gauge.Addersgall <= Config.SGE_ST_DPS_Rhizo)
					{
						return Rhizomata;
					}

					if (IsEnabled(CustomComboPreset.SGE_ST_DPS_Soteria) && CanSpellWeave(actionID) && ActionReady(Soteria))
					{
						return Soteria;
					}

					if (IsEnabled(CustomComboPreset.SGE_ST_DPS_AddersgallProtect) && CanSpellWeave(actionID) &&
						ActionReady(Druochole) && Gauge.Addersgall >= Config.SGE_ST_DPS_AddersgallProtect)
					{
						return Druochole;
					}

					if (IsEnabled(CustomComboPreset.SGE_ST_DPS_EDosis) && ActionReady(OriginalHook(EukrasianDosis3)) && ActionWatching.NumberOfGcdsUsed >= 3
						&& (!TargetHasEffect(DosisList[OriginalHook(Dosis3)]) || (GetDebuffRemainingTime(DosisList[OriginalHook(Dosis3)]) <= 3)))
					{
						if (!HasEffect(Buffs.Eukrasia) && ActionReady(Eukrasia))
						{
							return Eukrasia;
						}
						return OriginalHook(Dosis3);
					}

					if (IsEnabled(CustomComboPreset.SGE_ST_DPS_Phlegma) && InActionRange(OriginalHook(Phlegma3)) && ActionReady(OriginalHook(Phlegma3))
						&& ActionWatching.NumberOfGcdsUsed >= 4)
					{
						return OriginalHook(Phlegma3);
					}

					if (IsEnabled(CustomComboPreset.SGE_ST_DPS_Psyche) && ActionReady(Psyche) && CanSpellWeave(actionID)
						&& ActionWatching.NumberOfGcdsUsed >= 3)
					{
						return Psyche;
					}

					if (IsEnabled(CustomComboPreset.SGE_ST_DPS_Movement) && IsMoving)
					{
						if (ActionReady(Toxikon) && Gauge.Addersting > 0)
						{
							return OriginalHook(Toxikon);
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
				if (actionID is Dyskrasia or Dyskrasia2)
				{
					if (IsEnabled(CustomComboPreset.SGE_AoE_DPS_Lucid) && ActionReady(All.LucidDreaming) && LocalPlayer.CurrentMp <= 1000)
					{
						return All.LucidDreaming;
					}

					if (IsEnabled(CustomComboPreset.SGE_DPS_Variant_Rampart) && IsEnabled(Variant.VariantRampart) && IsOffCooldown(Variant.VariantRampart))
					{
						return Variant.VariantRampart;
					}

					if (IsEnabled(CustomComboPreset.SGE_DPS_Variant_SpiritDart) && IsEnabled(Variant.VariantSpiritDart)
						&& (!TargetHasEffectAny(Variant.Debuffs.SustainedDamage) || GetDebuffRemainingTime(Variant.Debuffs.SustainedDamage) <= 3))
					{
						return Variant.VariantSpiritDart;
					}

					if (IsEnabled(CustomComboPreset.SGE_AoE_DPS_Rhizo) && CanSpellWeave(actionID) &&
						ActionReady(Rhizomata) && Gauge.Addersgall <= Config.SGE_AoE_DPS_Rhizo)
					{
						return Rhizomata;
					}

					if (IsEnabled(CustomComboPreset.SGE_AoE_DPS_Soteria) && CanSpellWeave(actionID) && ActionReady(Soteria))
					{
						return Soteria;
					}

					if (IsEnabled(CustomComboPreset.SGE_AoE_DPS_Lucid) && ActionReady(All.LucidDreaming)
						&& CanSpellWeave(actionID) && LocalPlayer.CurrentMp <= Config.SGE_AoE_DPS_Lucid)
					{
						return All.LucidDreaming;
					}

					if (IsEnabled(CustomComboPreset.SGE_AoE_DPS_AddersgallProtect) && CanSpellWeave(actionID) &&
						ActionReady(Druochole) && Gauge.Addersgall >= Config.SGE_AoE_DPS_AddersgallProtect)
					{
						return Druochole;
					}

					if (IsEnabled(CustomComboPreset.SGE_AoE_DPS_EDyskrasia) && ActionReady(OriginalHook(EukrasianDyskrasia))
						&& (!TargetHasEffect(Debuffs.EukrasianDyskrasia) || (GetDebuffRemainingTime(Debuffs.EukrasianDyskrasia) <= 3)))
					{
						if (!HasEffect(Buffs.Eukrasia) && ActionReady(Eukrasia))
						{
							return Eukrasia;
						}
						return OriginalHook(EukrasianDyskrasia);
					}

					if (IsEnabled(CustomComboPreset.SGE_AoE_DPS_Phlegma) && InActionRange(OriginalHook(Phlegma3)) && ActionReady(OriginalHook(Phlegma3)))
					{
						return OriginalHook(Phlegma3);
					}

					if (IsEnabled(CustomComboPreset.SGE_AoE_DPS_Psyche) && ActionReady(Psyche) && CanSpellWeave(actionID))
					{
						return Psyche;
					}
				}
				return actionID;
			}
		}

		internal class SGE_Raise : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SGE_Raise;
			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				return actionID is Egeiro && IsOffCooldown(All.Swiftcast) && ActionReady(Egeiro) ? All.Swiftcast : actionID;
			}
		}

		internal class SGE_OverProtect : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SGE_OverProtect;
			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (IsEnabled(CustomComboPreset.SGE_OverProtect))
				{
					if (actionID is Kerachole && ActionReady(Kerachole))
					{
						if (!HasEffectAny(Buffs.Kerachole) && !HasEffectAny(SCH.Buffs.SacredSoil))
						{
							return Kerachole;
						}
						return OriginalHook(11);
					}
					if (actionID is Panhaima && ActionReady(Panhaima))
					{
						if (!HasEffectAny(Buffs.Panhaima))
						{
							return Panhaima;
						}
						return OriginalHook(11);
					}
					if (actionID is Philosophia && ActionReady(Philosophia))
					{
						if (!HasEffectAny(Buffs.Eudaimonia))
						{
							return Philosophia;
						}
						return OriginalHook(11);
					}
				}
				return actionID;
			}
		}
	}
}