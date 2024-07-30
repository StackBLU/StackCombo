using Dalamud.Game.ClientState.JobGauge.Types;
using StackCombo.ComboHelper.Functions;
using StackCombo.Combos.PvE.Content;
using StackCombo.CustomCombo;
using StackCombo.Data;
using System.Collections.Generic;
using System.Linq;
using Status = Dalamud.Game.ClientState.Statuses.Status;

namespace StackCombo.Combos.PvE
{
	internal static class WHM
	{
		public const byte JobID = 24;

		public const uint
			Cure = 120,
			Cure2 = 135,
			Cure3 = 131,
			Regen = 137,
			AfflatusSolace = 16531,
			AfflatusRapture = 16534,
			Raise = 125,
			Benediction = 140,
			AfflatusMisery = 16535,
			Medica1 = 124,
			Medica2 = 133,
			Medica3 = 37010,
			Tetragrammaton = 3570,
			DivineBenison = 7432,
			Aquaveil = 25861,
			DivineCaress = 37011,
			Glare1 = 16533,
			Glare3 = 25859,
			Glare4 = 37009,
			Stone1 = 119,
			Stone2 = 127,
			Stone3 = 3568,
			Stone4 = 7431,
			Assize = 3571,
			Holy = 139,
			Holy3 = 25860,
			Aero = 121,
			Aero2 = 132,
			Dia = 16532,
			ThinAir = 7430,
			PresenceOfMind = 136,
			PlenaryIndulgence = 7433;

		internal static readonly List<uint>
			StoneGlareList = [Stone1, Stone2, Stone3, Stone4, Glare1, Glare3];

		public static class Buffs
		{
			public const ushort
			Regen = 158,
			Medica2 = 150,
			Medica3 = 3880,
			PresenceOfMind = 157,
			ThinAir = 1217,
			DivineBenison = 1218,
			Aquaveil = 2708,
			SacredSight = 3879,
			DivineGrace = 3881;
		}

		public static class Debuffs
		{
			public const ushort
			Aero = 143,
			Aero2 = 144,
			Dia = 1871;
		}

		internal static readonly Dictionary<uint, ushort>
			AeroList = new() {
				{ Aero, Debuffs.Aero },
				{ Aero2, Debuffs.Aero2 },
				{ Dia, Debuffs.Dia }
			};

		public static class Config
		{
			internal static UserInt
				WHM_STDPS_Lucid = new("WHMLucidDreamingFeature"),
				WHM_STDPS_MainCombo_DoT = new("WHM_ST_MainCombo_DoT"),
				WHM_AoEDPS_Lucid = new("WHM_AoE_Lucid"),
				WHM_STHeals_Lucid = new("WHM_STHeals_Lucid"),
				WHM_AoEHeals_Lucid = new("WHM_AoEHeals_Lucid");
			internal static UserBool
				WHM_ST_MainCombo_Adv = new("WHM_ST_MainCombo_Adv"),
				WHM_STHeals_TetraWeave = new("WHM_STHeals_TetraWeave"),
				WHM_AoEHeals_MedicaMO = new("WHM_AoEHeals_MedicaMO"),
				WHM_AoEHeals_Misery_Instant = new("WHM_AoEHeals_Misery_Instant");
		}

		internal class WHM_ST_MainCombo : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.WHM_ST_MainCombo;
			internal static int Glare3Count
			{
				get
				{
					return ActionWatching.CombatActions.Count(x => x == OriginalHook(Glare3));
				}
			}

			internal static int DiaCount
			{
				get
				{
					return ActionWatching.CombatActions.Count(x => x == OriginalHook(Dia));
				}
			}

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID is Glare3 || actionID is Glare1)
				{
					WHMGauge? gauge = GetJobGauge<WHMGauge>();
					bool liliesFull = gauge.Lily == 3;
					bool liliesNearlyFull = gauge.Lily == 2 && gauge.LilyTimer >= 17500;
					bool liliesNearlyFull2 = gauge.Lily == 2 && gauge.LilyTimer >= 12500;

					if (IsEnabled(CustomComboPreset.WHM_ST_MainCombo_Lucid) && ActionReady(All.LucidDreaming) && LocalPlayer.CurrentMp <= 1000)
					{
						return All.LucidDreaming;
					}

					if (CanSpellWeave(actionID))
					{
						bool lucidReady = ActionReady(All.LucidDreaming) && LevelChecked(All.LucidDreaming) && LocalPlayer.CurrentMp <= Config.WHM_STDPS_Lucid;
						bool pomReady = LevelChecked(PresenceOfMind) && IsOffCooldown(PresenceOfMind);
						_ = LevelChecked(Assize) && IsOffCooldown(Assize);
						bool pomEnabled = IsEnabled(CustomComboPreset.WHM_ST_MainCombo_PresenceOfMind);
						bool lucidEnabled = IsEnabled(CustomComboPreset.WHM_ST_MainCombo_Lucid);

						if (IsEnabled(CustomComboPreset.WHM_DPS_Variant_Rampart) &&
							IsEnabled(Variant.VariantRampart) &&
							IsOffCooldown(Variant.VariantRampart) &&
							CanSpellWeave(actionID))
						{
							return Variant.VariantRampart;
						}

						if (pomEnabled && pomReady)
						{
							return PresenceOfMind;
						}

						if (lucidEnabled && lucidReady)
						{
							return All.LucidDreaming;
						}
					}

					if (InCombat())
					{
						if (IsEnabled(CustomComboPreset.WHM_ST_MainCombo_DoT) && LevelChecked(Aero) && HasBattleTarget())
						{
							Status? sustainedDamage = FindTargetEffect(Variant.Debuffs.SustainedDamage);
							if (IsEnabled(CustomComboPreset.WHM_DPS_Variant_SpiritDart) &&
								IsEnabled(Variant.VariantSpiritDart) &&
								(sustainedDamage is null || sustainedDamage?.RemainingTime <= 3) &&
								CanSpellWeave(actionID))
							{
								return Variant.VariantSpiritDart;
							}

							uint dot = OriginalHook(Aero);
							Status? dotDebuff = FindTargetEffect(AeroList[dot]);

							if (dotDebuff is null || dotDebuff.RemainingTime <= 3)
							{
								return OriginalHook(Aero);
							}
						}

						return IsEnabled(CustomComboPreset.WHM_ST_MainCombo_Misery) && LevelChecked(AfflatusMisery) &&
							gauge.BloodLily >= 3
							? IsEnabled(CustomComboPreset.WHM_ST_MainCombo_Misery_Save) && !liliesNearlyFull2
								? IsEnabled(CustomComboPreset.WHM_ST_MainCombo_GlareIV)
								&& HasEffect(Buffs.SacredSight)
								&& GetBuffStacks(Buffs.SacredSight) > 0
									? OriginalHook(Glare4)
									: OriginalHook(Glare3)
								: AfflatusMisery
							: IsEnabled(CustomComboPreset.WHM_ST_MainCombo_LilyOvercap) && LevelChecked(AfflatusRapture) &&
							(liliesFull || liliesNearlyFull)
							? AfflatusRapture
							: IsEnabled(CustomComboPreset.WHM_ST_MainCombo_GlareIV)
							&& HasEffect(Buffs.SacredSight)
							&& GetBuffStacks(Buffs.SacredSight) > 0
							? OriginalHook(Glare4)
							: OriginalHook(Stone1);
					}
				}
				return actionID;
			}
		}

		internal class WHM_AoE_DPS : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.WHM_AoE_DPS;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID is Holy or Holy3)
				{
					WHMGauge? gauge = GetJobGauge<WHMGauge>();

					bool liliesFullNoBlood = gauge.Lily == 3 && gauge.BloodLily < 3;
					bool liliesNearlyFull = gauge.Lily == 2 && gauge.LilyTimer >= 17500;
					bool liliesNearlyFull2 = gauge.Lily == 2 && gauge.LilyTimer >= 12500;

					if (IsEnabled(CustomComboPreset.WHM_AoE_DPS_Lucid) && ActionReady(All.LucidDreaming) && LocalPlayer.CurrentMp <= 1000)
					{
						return All.LucidDreaming;
					}

					if (IsEnabled(CustomComboPreset.WHM_DPS_Variant_Rampart) &&
						IsEnabled(Variant.VariantRampart) &&
						IsOffCooldown(Variant.VariantRampart))
					{
						return Variant.VariantRampart;
					}

					Status? sustainedDamage = FindTargetEffect(Variant.Debuffs.SustainedDamage);
					if (IsEnabled(CustomComboPreset.WHM_DPS_Variant_SpiritDart) &&
						IsEnabled(Variant.VariantSpiritDart) &&
						(sustainedDamage is null || sustainedDamage?.RemainingTime <= 3) &&
						HasBattleTarget())
					{
						return Variant.VariantSpiritDart;
					}

					if (CanSpellWeave(actionID) || IsMoving)
					{
						if (IsEnabled(CustomComboPreset.WHM_AoE_DPS_PresenceOfMind) && ActionReady(PresenceOfMind))
						{
							return PresenceOfMind;
						}

						if (IsEnabled(CustomComboPreset.WHM_AoE_DPS_Lucid) && ActionReady(All.LucidDreaming) &&
							LocalPlayer.CurrentMp <= Config.WHM_AoEDPS_Lucid)
						{
							return All.LucidDreaming;
						}
					}

					if (IsEnabled(CustomComboPreset.WHM_AoE_DPS_Misery) && LevelChecked(AfflatusMisery) &&
						gauge.BloodLily >= 3)
					{
						return IsEnabled(CustomComboPreset.WHM_AoE_DPS_Misery_Save) && !liliesNearlyFull2
							? IsEnabled(CustomComboPreset.WHM_AoE_DPS_GlareIV)
							&& HasEffect(Buffs.SacredSight)
							&& GetBuffStacks(Buffs.SacredSight) > 0
								? OriginalHook(Glare4)
								: OriginalHook(Holy)
							: AfflatusMisery;
					}

					if (IsEnabled(CustomComboPreset.WHM_AoE_DPS_LilyOvercap) && LevelChecked(AfflatusRapture) &&
						(liliesFullNoBlood || liliesNearlyFull))
					{
						return AfflatusRapture;
					}

					if (IsEnabled(CustomComboPreset.WHM_AoE_DPS_GlareIV)
						&& HasEffect(Buffs.SacredSight)
						&& GetBuffStacks(Buffs.SacredSight) > 0)
					{
						return OriginalHook(Glare4);
					}
				}

				return actionID;
			}
		}

		internal class WHM_ST_Heals : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.WHM_STHeals;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID is Cure)
				{
					WHMGauge? gauge = GetJobGauge<WHMGauge>();
					bool thinAirReady = ActionReady(ThinAir) && !HasEffect(Buffs.ThinAir);

					if (IsEnabled(CustomComboPreset.WHM_STHeals_Tetragrammaton) && ActionReady(Tetragrammaton) && CanSpellWeave(Tetragrammaton))
					{
						return Tetragrammaton;
					}

					if (IsEnabled(CustomComboPreset.WHM_STHeals_Misery) && gauge.BloodLily == 3)
					{
						return AfflatusMisery;
					}

					if (IsEnabled(CustomComboPreset.WHM_STHeals_Solace) && gauge.Lily > 0 && ActionReady(AfflatusSolace))
					{
						return AfflatusSolace;
					}

					Status? regenBuff = FindTargetEffectAny(Buffs.Regen);
					if (regenBuff is null)
					{
						return Regen;
					}

					if (IsEnabled(CustomComboPreset.WHM_STHeals_ThinAir) && thinAirReady && CanSpellWeave(ThinAir))
					{
						return ThinAir;
					}

					if (ActionReady(Cure2))
					{
						return Cure2;
					}
				}

				return actionID;
			}
		}

		internal class WHM_AoEHeals : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.WHM_AoEHeals;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID is Medica1)
				{
					WHMGauge? gauge = GetJobGauge<WHMGauge>();
					bool thinAirReady = ActionReady(ThinAir) && !HasEffect(Buffs.ThinAir);
					bool canWeave = CanSpellWeave(actionID, 0.3);
					bool lucidReady = ActionReady(All.LucidDreaming) && LocalPlayer.CurrentMp <= Config.WHM_AoEHeals_Lucid;
					_ = ActionReady(DivineCaress) && HasEffect(Buffs.DivineGrace);
					_ = GetHealTarget(Config.WHM_AoEHeals_MedicaMO);

					if (IsEnabled(CustomComboPreset.WHM_AoEHeals_Lucid) && ActionReady(All.LucidDreaming) && LocalPlayer.CurrentMp <= 1000)
					{
						return All.LucidDreaming;
					}

					if (IsEnabled(CustomComboPreset.WHM_AoEHeals_Plenary) & ActionReady(PlenaryIndulgence))
					{
						return PlenaryIndulgence;
					}

					if (IsEnabled(CustomComboPreset.WHM_AoEHeals_Lucid) && canWeave && lucidReady)
					{
						return All.LucidDreaming;
					}

					if (IsEnabled(CustomComboPreset.WHM_AoEHeals_Misery) && gauge.BloodLily == 3)
					{
						return AfflatusMisery;
					}

					if (IsEnabled(CustomComboPreset.WHM_AoEHeals_Rapture) && LevelChecked(AfflatusRapture) && gauge.Lily > 0)
					{
						return AfflatusRapture;
					}

					if (IsEnabled(CustomComboPreset.WHM_AoEHeals_ThinAir) && thinAirReady)
					{
						return ThinAir;
					}

					if (IsEnabled(CustomComboPreset.WHM_AoEHeals_Medica2)
						&& !HasEffect(Buffs.Medica2) && !HasEffect(Buffs.Medica3)
						&& (LevelChecked(Medica2) || LevelChecked(Medica3)))
					{
						return OriginalHook(Medica3);
					}

					if (IsEnabled(CustomComboPreset.WHM_AoEHeals_Cure3) && LevelChecked(Cure3))
					{
						return Cure3;
					}
				}

				return actionID;
			}
		}

		internal class WHM_CureSync : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.WHM_CureSync;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				return actionID is Cure2 && !LevelChecked(Cure2)
					? Cure
					: actionID;
			}
		}

		internal class WHM_Raise : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.WHM_Raise;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID is Raise)
				{
					bool thinAirReady = !HasEffect(Buffs.ThinAir) && LevelChecked(ThinAir) && HasCharges(ThinAir);

					if (IsOffCooldown(All.Swiftcast))
					{
						return All.Swiftcast;
					}

					if (IsOnCooldown(All.Swiftcast) && thinAirReady)
					{
						return ThinAir;
					}

					if (IsOnCooldown(All.Swiftcast) && !thinAirReady)
					{
						return Raise;
					}
				}
				return actionID;
			}
		}
	}
}