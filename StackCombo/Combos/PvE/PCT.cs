using Dalamud.Game.ClientState.JobGauge.Types;
using StackCombo.ComboHelper.Functions;
using StackCombo.CustomCombo;

namespace StackCombo.Combos.PvE
{
	internal class PCT
	{
		public const byte JobID = 42;

		public const uint
			BlizzardinCyan = 34653,
			BlizzardIIinCyan = 34659,
			ClawMotif = 34666,
			ClawedMuse = 34672,
			CometinBlack = 34663,
			CreatureMotif = 34689,
			FireInRed = 34650,
			FireIIinRed = 34656,
			HammerStamp = 34678,
			HolyInWhite = 34662,
			LandscapeMotif = 34691,
			LivingMuse = 35347,
			MawMotif = 34667,
			MogoftheAges = 34676,
			PomMotif = 34664,
			PomMuse = 34670,
			RainbowDrip = 34688,
			RetributionoftheMadeen = 34677,
			ScenicMuse = 35349,
			Smudge = 34684,
			StarPrism = 34681,
			SteelMuse = 35348,
			SubtractivePalette = 34683,
			ThunderIIinMagenta = 34661,
			ThunderinMagenta = 34655,
			WaterinBlue = 34652,
			WeaponMotif = 34690,
			WingMotif = 34665;

		public static class Buffs
		{
			public const ushort
				Aetherhues = 3675,
				AetherhuesII = 3676,
				SubtractivePalette = 3674,
				RainbowBright = 3679,
				HammerTime = 3680,
				MonochromeTones = 3691,
				StarryMuse = 3685,
				Hyperphantasia = 3688,
				Inspiration = 3689,
				SubtractiveSpectrum = 3690,
				Starstruck = 3681;
		}

		public static class Debuffs
		{

		}

		public static class Config
		{
			public static UserInt
				PCT_ST_Lucid = new("PCT_ST_Lucid", 7500),
				PCT_AoE_Lucid = new("PCT_AoE_Lucid", 7500);

			public static UserBool
				CombinedMotifsMog = new("CombinedMotifsMog"),
				CombinedMotifsMadeen = new("CombinedMotifsMadeen"),
				CombinedMotifsWeapon = new("CombinedMotifsWeapon"),
				PCT_LandscapeRainbowBright = new("PCT_LandscapeRainbowBright"),
				PCT_LandscapeStarstruck = new("PCT_LandscapeStarstruck");
		}

		internal class PCT_ST_Adv : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.PCT_ST_Adv;

			protected override uint Invoke(uint actionID, uint lastComboActionID, float comboTime, byte level)
			{
				PCTGauge gauge = GetJobGauge<PCTGauge>();

				if (actionID is FireInRed)
				{
					if (IsEnabled(CustomComboPreset.PCT_ST_Lucid) && ActionReady(All.LucidDreaming) && LocalPlayer.CurrentMp <= 1000)
					{
						return All.LucidDreaming;
					}

					if (IsEnabled(CustomComboPreset.PCT_ST_Subtractive_OP) && gauge.PalleteGauge == 100 && ActionReady(SubtractivePalette))
					{
						if (HasEffect(Buffs.MonochromeTones))
						{
							return OriginalHook(CometinBlack);
						}
						if (CanSpellWeave(actionID))
						{
							return SubtractivePalette;
						}
					}

					if (IsEnabled(CustomComboPreset.PCT_ST_Comet_OP) && gauge.Paint == 5 && (LevelChecked(HolyInWhite) || LevelChecked(CometinBlack)))
					{
						return HasEffect(Buffs.MonochromeTones) ? OriginalHook(CometinBlack) : OriginalHook(HolyInWhite);
					}

					if (IsEnabled(CustomComboPreset.PCT_ST_RainbowDrip) && HasEffect(Buffs.RainbowBright))
					{
						return RainbowDrip;
					}

					if (IsEnabled(CustomComboPreset.PCT_ST_Lucid) && ActionReady(All.LucidDreaming) && CanSpellWeave(actionID) && LocalPlayer.CurrentMp <= Config.PCT_ST_Lucid)
					{
						return All.LucidDreaming;
					}

					if (HasEffect(Buffs.SubtractivePalette))
					{
						return OriginalHook(BlizzardinCyan);
					}
				}

				return actionID;
			}
		}

		internal class PCT_AoE_Adv : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.PCT_AoE_Adv;

			protected override uint Invoke(uint actionID, uint lastComboActionID, float comboTime, byte level)
			{
				PCTGauge gauge = GetJobGauge<PCTGauge>();

				if (actionID is FireIIinRed)
				{
					if (IsEnabled(CustomComboPreset.PCT_AoE_Lucid) && ActionReady(All.LucidDreaming) && LocalPlayer.CurrentMp <= 1000)
					{
						return All.LucidDreaming;
					}

					if (IsEnabled(CustomComboPreset.PCT_AoE_Subtractive_OP) && gauge.PalleteGauge == 100 && CanSpellWeave(actionID) && ActionReady(SubtractivePalette))
					{
						return HasEffect(Buffs.MonochromeTones) ? OriginalHook(CometinBlack) : SubtractivePalette;
					}

					if (IsEnabled(CustomComboPreset.PCT_AoE_Comet_OP) && gauge.Paint == 5 && (LevelChecked(HolyInWhite) || LevelChecked(CometinBlack)))
					{
						return HasEffect(Buffs.MonochromeTones) ? OriginalHook(CometinBlack) : OriginalHook(HolyInWhite);
					}

					if (IsEnabled(CustomComboPreset.PCT_AoE_RainbowDrip) && HasEffect(Buffs.RainbowBright))
					{
						return RainbowDrip;
					}

					if (IsEnabled(CustomComboPreset.PCT_AoE_Lucid) && ActionReady(All.LucidDreaming) && CanSpellWeave(actionID) && LocalPlayer.CurrentMp <= Config.PCT_AoE_Lucid)
					{
						return All.LucidDreaming;
					}

					if (HasEffect(Buffs.SubtractivePalette))
					{
						return OriginalHook(BlizzardIIinCyan);
					}
				}

				return actionID;
			}
		}

		internal class PCT_CreatureWeapon : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.PCT_CreatureWeapon;

			protected override uint Invoke(uint actionID, uint lastComboActionID, float comboTime, byte level)
			{
				PCTGauge gauge = GetJobGauge<PCTGauge>();

				if (actionID == CreatureMotif)
				{
					if ((Config.CombinedMotifsMog && gauge.MooglePortraitReady) || (Config.CombinedMotifsMadeen && gauge.MadeenPortraitReady && IsOffCooldown(OriginalHook(MogoftheAges))))
					{
						return OriginalHook(MogoftheAges);
					}

					if (gauge.CreatureMotifDrawn)
					{
						return OriginalHook(LivingMuse);
					}
				}

				if (actionID == WeaponMotif)
				{
					if (Config.CombinedMotifsWeapon && HasEffect(Buffs.HammerTime))
					{
						return OriginalHook(HammerStamp);
					}

					if (gauge.WeaponMotifDrawn)
					{
						return OriginalHook(SteelMuse);
					}
				}

				return actionID;
			}
		}

		internal class PCT_Landscape : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.PCT_Landscape;

			protected override uint Invoke(uint actionID, uint lastComboActionID, float comboTime, byte level)
			{
				PCTGauge gauge = GetJobGauge<PCTGauge>();

				if (actionID is LandscapeMotif)
				{
					if (HasEffect(Buffs.Starstruck))
					{
						return StarPrism;
					}
					if (gauge.LandscapeMotifDrawn)
					{
						return OriginalHook(ScenicMuse);
					}
				}
				return actionID;
			}
		}

		internal class PCT_Paint : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.PCT_Paint;

			protected override uint Invoke(uint actionID, uint lastComboActionID, float comboTime, byte level)
			{
				if (actionID == HolyInWhite)
				{
					if (HasEffect(Buffs.MonochromeTones))
					{
						return CometinBlack;
					}
				}

				return actionID;
			}
		}

		internal class PCT_SubPaint_OP : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.PCT_SubPaint_OP;

			protected override uint Invoke(uint actionID, uint lastComboActionID, float comboTime, byte level)
			{
				if (actionID is SubtractivePalette)
				{
					if (HasEffect(Buffs.MonochromeTones))
					{
						return CometinBlack;
					}
				}

				return actionID;
			}
		}
	}
}
