using StackCombo.ComboHelper.Functions;
using StackCombo.Combos.PvE;

namespace StackCombo.Combos.JobHelpers
{
	internal class SGE : CustomComboFunctions
	{
		public static int GetMatchingConfigST(int i, out uint action, out bool enabled)
		{
			Dalamud.Game.ClientState.Objects.Types.IGameObject? healTarget = GetHealTarget(StackCombo.Combos.PvE.SGE.Config.SGE_ST_Heal_Adv && StackCombo.Combos.PvE.SGE.Config.SGE_ST_Heal_UIMouseOver);

			switch (i)
			{
				case 0:
					action = StackCombo.Combos.PvE.SGE.Soteria;
					enabled = IsEnabled(CustomComboPreset.SGE_ST_Heal_Soteria);
					return StackCombo.Combos.PvE.SGE.Config.SGE_ST_Heal_Soteria;
				case 1:
					action = StackCombo.Combos.PvE.SGE.Zoe;
					enabled = IsEnabled(CustomComboPreset.SGE_ST_Heal_Zoe);
					return StackCombo.Combos.PvE.SGE.Config.SGE_ST_Heal_Zoe;
				case 2:
					action = StackCombo.Combos.PvE.SGE.Pepsis;
					enabled = IsEnabled(CustomComboPreset.SGE_ST_Heal_Pepsis) && FindEffect(StackCombo.Combos.PvE.SGE.Buffs.EukrasianDiagnosis, healTarget, LocalPlayer?.GameObjectId) is not null;
					return StackCombo.Combos.PvE.SGE.Config.SGE_ST_Heal_Pepsis;
				case 3:
					action = StackCombo.Combos.PvE.SGE.Taurochole;
					enabled = IsEnabled(CustomComboPreset.SGE_ST_Heal_Taurochole) && StackCombo.Combos.PvE.SGE.Gauge.HasAddersgall();
					return StackCombo.Combos.PvE.SGE.Config.SGE_ST_Heal_Taurochole;
				case 4:
					action = StackCombo.Combos.PvE.SGE.Haima;
					enabled = IsEnabled(CustomComboPreset.SGE_ST_Heal_Haima);
					return StackCombo.Combos.PvE.SGE.Config.SGE_ST_Heal_Haima;
				case 5:
					action = StackCombo.Combos.PvE.SGE.Krasis;
					enabled = IsEnabled(CustomComboPreset.SGE_ST_Heal_Krasis);
					return StackCombo.Combos.PvE.SGE.Config.SGE_ST_Heal_Krasis;
				case 6:
					action = StackCombo.Combos.PvE.SGE.Druochole;
					enabled = IsEnabled(CustomComboPreset.SGE_ST_Heal_Druochole) && StackCombo.Combos.PvE.SGE.Gauge.HasAddersgall();
					return StackCombo.Combos.PvE.SGE.Config.SGE_ST_Heal_Druochole;
			}

			enabled = false;
			action = 0;
			return 0;
		}

		public static int GetMatchingConfigAoE(int i, out uint action, out bool enabled)
		{
			switch (i)
			{
				case 0:
					action = StackCombo.Combos.PvE.SGE.Kerachole;
					enabled = IsEnabled(CustomComboPreset.SGE_AoE_Heal_Kerachole) && (!StackCombo.Combos.PvE.SGE.Config.SGE_AoE_Heal_KeracholeTrait || (StackCombo.Combos.PvE.SGE.Config.SGE_AoE_Heal_KeracholeTrait && TraitLevelChecked(StackCombo.Combos.PvE.SGE.Traits.EnhancedKerachole))) && StackCombo.Combos.PvE.SGE.Gauge.HasAddersgall();
					return 0;
				case 1:
					action = StackCombo.Combos.PvE.SGE.Ixochole;
					enabled = IsEnabled(CustomComboPreset.SGE_AoE_Heal_Ixochole) && StackCombo.Combos.PvE.SGE.Gauge.HasAddersgall();
					return 0;
				case 2:
					action = OriginalHook(StackCombo.Combos.PvE.SGE.Physis);
					enabled = IsEnabled(CustomComboPreset.SGE_AoE_Heal_Physis);
					return 0;
				case 3:
					action = StackCombo.Combos.PvE.SGE.Holos;
					enabled = IsEnabled(CustomComboPreset.SGE_AoE_Heal_Holos);
					return 0;
				case 4:
					action = StackCombo.Combos.PvE.SGE.Panhaima;
					enabled = IsEnabled(CustomComboPreset.SGE_AoE_Heal_Panhaima);
					return 0;
				case 5:
					action = StackCombo.Combos.PvE.SGE.Pepsis;
					enabled = IsEnabled(CustomComboPreset.SGE_AoE_Heal_Pepsis) && FindEffect(StackCombo.Combos.PvE.SGE.Buffs.EukrasianPrognosis) is not null;
					return 0;
				case 6:
					action = StackCombo.Combos.PvE.SGE.Philosophia;
					enabled = IsEnabled(CustomComboPreset.SGE_AoE_Heal_Philosophia);
					return 0;
			}

			enabled = false;
			action = 0;
			return 0;
		}
	}
}
