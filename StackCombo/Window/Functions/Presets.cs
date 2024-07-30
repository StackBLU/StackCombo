using Dalamud.Interface.Colors;
using Dalamud.Utility;
using ECommons.DalamudServices;
using ECommons.ImGuiMethods;
using ImGuiNET;
using StackCombo.Attributes;
using StackCombo.Combos;
using StackCombo.Core;
using StackCombo.Data;
using StackCombo.Extensions;
using StackCombo.Services;
using System.Linq;
using System.Text;

namespace StackCombo.Window.Functions
{
	internal class Presets : ConfigWindow
	{
		internal static unsafe void DrawPreset(CustomComboPreset preset, CustomComboInfoAttribute info, ref int i)
		{
			bool enabled = PresetStorage.IsEnabled(preset);
			bool secret = PresetStorage.IsPvP(preset);
			CustomComboPreset[] conflicts = PresetStorage.GetConflicts(preset);
			CustomComboPreset? parent = PresetStorage.GetParent(preset);
			BlueInactiveAttribute? blueAttr = preset.GetAttribute<BlueInactiveAttribute>();

			ImGui.Spacing();

			if (ImGui.Checkbox($"{info.FancyName}", ref enabled))
			{
				if (enabled)
				{
					EnableParentPresets(preset);
					_ = Service.Configuration.EnabledActions.Add(preset);
					foreach (CustomComboPreset conflict in conflicts)
					{
						_ = Service.Configuration.EnabledActions.Remove(conflict);
					}
				}

				else
				{
					_ = Service.Configuration.EnabledActions.Remove(preset);
				}

				Service.Configuration.Save();
			}

			ImGui.PushStyleColor(ImGuiCol.Text, ImGuiColors.DalamudGrey);

			DrawReplaceAttribute(preset);

			ImGui.Text($"{info.Description}");

			ImGui.PopStyleColor();
			ImGui.Spacing();

			if (conflicts.Length > 0)
			{
				ImGui.TextColored(ImGuiColors.DalamudRed, "Conflicts with:");
				StringBuilder conflictBuilder = new();
				ImGui.Indent();
				foreach (CustomComboPreset conflict in conflicts)
				{
					CustomComboInfoAttribute? comboInfo = conflict.GetAttribute<CustomComboInfoAttribute>();
					_ = conflictBuilder.Insert(0, $"{comboInfo.FancyName}");
					CustomComboPreset par2 = conflict;

					while (PresetStorage.GetParent(par2) != null)
					{
						CustomComboPreset? subpar = PresetStorage.GetParent(par2);
						_ = conflictBuilder.Insert(0, $"{subpar?.GetAttribute<CustomComboInfoAttribute>().FancyName} -> ");
						par2 = subpar!.Value;

					}

					if (!string.IsNullOrEmpty(comboInfo.JobShorthand))
					{
						_ = conflictBuilder.Insert(0, $"[{comboInfo.JobShorthand}] ");
					}

					ImGuiEx.Text(GradientColor.Get(ImGuiColors.DalamudRed, ComboHelper.Functions.CustomComboFunctions.IsEnabled(conflict) ? ImGuiColors.HealerGreen : ImGuiColors.DalamudRed, 1500), $"- {conflictBuilder}");
					_ = conflictBuilder.Clear();
				}
				ImGui.Unindent();
				ImGui.Spacing();
			}

			if (blueAttr != null)
			{
				if (blueAttr.Actions.Count > 0)
				{
					ImGui.PushStyleColor(ImGuiCol.Text, blueAttr.NoneSet ? ImGuiColors.DPSRed : ImGuiColors.DalamudOrange);
					ImGui.Text($"{(blueAttr.NoneSet ? "No Required Spells Active:" : "Missing active spells:")} {string.Join(", ", blueAttr.Actions.Select(x => ActionWatching.GetBLUIndex(x) + ActionWatching.GetActionName(x)))}");
					ImGui.PopStyleColor();
				}

				else
				{
					ImGui.PushStyleColor(ImGuiCol.Text, ImGuiColors.HealerGreen);
					ImGui.Text($"All required spells active!");
					ImGui.PopStyleColor();
				}
			}

			VariantParentAttribute? varientparents = preset.GetAttribute<VariantParentAttribute>();
			if (varientparents is not null)
			{
				ImGui.PushStyleColor(ImGuiCol.Text, ImGuiColors.HealerGreen);
				ImGui.TextWrapped($"Part of normal combo{(varientparents.ParentPresets.Length > 1 ? "s" : "")}:");
				StringBuilder builder = new();
				foreach (CustomComboPreset par in varientparents.ParentPresets)
				{
					_ = builder.Insert(0, $"{par.GetAttribute<CustomComboInfoAttribute>().FancyName}");
					CustomComboPreset par2 = par;
					while (PresetStorage.GetParent(par2) != null)
					{
						CustomComboPreset? subpar = PresetStorage.GetParent(par2);
						_ = builder.Insert(0, $"{subpar?.GetAttribute<CustomComboInfoAttribute>().FancyName} -> ");
						par2 = subpar!.Value;

					}

					ImGui.TextWrapped($"- {builder}");
					_ = builder.Clear();
				}
				ImGui.PopStyleColor();
			}

			BozjaParentAttribute? bozjaparents = preset.GetAttribute<BozjaParentAttribute>();
			if (bozjaparents is not null)
			{
				ImGui.PushStyleColor(ImGuiCol.Text, ImGuiColors.HealerGreen);
				ImGui.TextWrapped($"Part of normal combo{(varientparents.ParentPresets.Length > 1 ? "s" : "")}:");
				StringBuilder builder = new();
				foreach (CustomComboPreset par in bozjaparents.ParentPresets)
				{
					_ = builder.Insert(0, $"{par.GetAttribute<CustomComboInfoAttribute>().FancyName}");
					CustomComboPreset par2 = par;
					while (PresetStorage.GetParent(par2) != null)
					{
						CustomComboPreset? subpar = PresetStorage.GetParent(par2);
						_ = builder.Insert(0, $"{subpar?.GetAttribute<CustomComboInfoAttribute>().FancyName} -> ");
						par2 = subpar!.Value;

					}

					ImGui.TextWrapped($"- {builder}");
					_ = builder.Clear();
				}
				ImGui.PopStyleColor();
			}

			EurekaParentAttribute? eurekaparents = preset.GetAttribute<EurekaParentAttribute>();
			if (eurekaparents is not null)
			{
				ImGui.PushStyleColor(ImGuiCol.Text, ImGuiColors.HealerGreen);
				ImGui.TextWrapped($"Part of normal combo{(varientparents.ParentPresets.Length > 1 ? "s" : "")}:");
				StringBuilder builder = new();
				foreach (CustomComboPreset par in eurekaparents.ParentPresets)
				{
					_ = builder.Insert(0, $"{par.GetAttribute<CustomComboInfoAttribute>().FancyName}");
					CustomComboPreset par2 = par;
					while (PresetStorage.GetParent(par2) != null)
					{
						CustomComboPreset? subpar = PresetStorage.GetParent(par2);
						_ = builder.Insert(0, $"{subpar?.GetAttribute<CustomComboInfoAttribute>().FancyName} -> ");
						par2 = subpar!.Value;

					}

					ImGui.TextWrapped($"- {builder}");
					_ = builder.Clear();
				}
				ImGui.PopStyleColor();
			}

			UserConfigItems.Draw(preset, enabled);

			i++;

			bool hideChildren = Service.Configuration.HideChildren;
			(CustomComboPreset Preset, CustomComboInfoAttribute Info)[] children = presetChildren[preset];

			if (children.Length > 0)
			{
				if (enabled || !hideChildren)
				{
					ImGui.Indent();

					foreach ((CustomComboPreset childPreset, CustomComboInfoAttribute childInfo) in children)
					{
						if (Service.Configuration.HideConflictedCombos)
						{
							CustomComboPreset[] conflictOriginals = PresetStorage.GetConflicts(childPreset);
							System.Collections.Generic.List<CustomComboPreset> conflictsSource = PresetStorage.GetAllConflicts();

							if (!conflictsSource.Where(x => x == childPreset || x == preset).Any() || conflictOriginals.Length == 0)
							{
								DrawPreset(childPreset, childInfo, ref i);
								continue;
							}

							if (conflictOriginals.Any(PresetStorage.IsEnabled))
							{
								_ = Service.Configuration.EnabledActions.Remove(childPreset);
								Service.Configuration.Save();
							}

							else
							{
								DrawPreset(childPreset, childInfo, ref i);
								continue;
							}
						}

						else
						{
							DrawPreset(childPreset, childInfo, ref i);
						}
					}

					ImGui.Unindent();
				}
				else
				{
					i += AllChildren(presetChildren[preset]);

				}
			}
		}

		private static void DrawReplaceAttribute(CustomComboPreset preset)
		{
			ReplaceSkillAttribute? att = preset.GetReplaceAttribute();
			if (att != null)
			{
				string skills = string.Join(", ", att.ActionNames);

				ImGui.Text($"Replaces: {skills}");
				ImGui.SameLine();
				foreach (ushort icon in att.ActionIcons)
				{
					Dalamud.Interface.Textures.TextureWraps.IDalamudTextureWrap img = Svc.Texture.GetFromGameIcon(new(icon)).GetWrapOrEmpty();
					ImGui.Image(img.ImGuiHandle, img.Size / 2f * ImGui.GetIO().FontGlobalScale);
					ImGui.SameLine();
				}
			}
		}

		internal static int AllChildren((CustomComboPreset Preset, CustomComboInfoAttribute Info)[] children)
		{
			int output = 0;

			foreach ((CustomComboPreset Preset, CustomComboInfoAttribute Info) in children)
			{
				output++;
				output += AllChildren(presetChildren[Preset]);
			}

			return output;
		}

		private static void EnableParentPresets(CustomComboPreset preset)
		{
			CustomComboPreset? parentMaybe = PresetStorage.GetParent(preset);

			while (parentMaybe != null)
			{
				CustomComboPreset parent = parentMaybe.Value;

				if (!Service.Configuration.EnabledActions.Contains(parent))
				{
					_ = Service.Configuration.EnabledActions.Add(parent);
					foreach (CustomComboPreset conflict in PresetStorage.GetConflicts(parent))
					{
						_ = Service.Configuration.EnabledActions.Remove(conflict);
					}
				}

				parentMaybe = PresetStorage.GetParent(parent);
			}
		}
	}
}