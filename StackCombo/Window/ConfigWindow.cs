using Dalamud.Interface.ManagedFontAtlas;
using Dalamud.Interface.Utility.Raii;
using Dalamud.Utility;
using ECommons.DalamudServices;
using ECommons.ImGuiMethods;
using ImGuiNET;
using StackCombo.Attributes;
using StackCombo.Combos;
using StackCombo.Combos.PvE;
using StackCombo.Core;
using StackCombo.Window.Tabs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace StackCombo.Window
{
	/// <summary> Plugin configuration window. </summary>
	internal class ConfigWindow : Dalamud.Interface.Windowing.Window
	{
		internal static readonly Dictionary<string, List<(CustomComboPreset Preset, CustomComboInfoAttribute Info)>> groupedPresets = GetGroupedPresets();
		internal static readonly Dictionary<CustomComboPreset, (CustomComboPreset Preset, CustomComboInfoAttribute Info)[]> presetChildren = GetPresetChildren();

		internal static Dictionary<string, List<(CustomComboPreset Preset, CustomComboInfoAttribute Info)>> GetGroupedPresets()
		{
			return Enum
			.GetValues<CustomComboPreset>()
			.Where(preset => (int)preset > 100 && preset != CustomComboPreset.Disabled)
			.Select(preset => (Preset: preset, Info: preset.GetAttribute<CustomComboInfoAttribute>()))
			.Where(tpl => tpl.Info != null && PresetStorage.GetParent(tpl.Preset) == null)
			.OrderByDescending(tpl => tpl.Info.JobID == 0)
			.ThenByDescending(tpl => tpl.Info.JobID == DOL.JobID)
			.ThenByDescending(tpl => tpl.Info.JobID == DOH.JobID)
			.ThenByDescending(tpl => tpl.Info.JobID == PLD.JobID)
			.ThenByDescending(tpl => tpl.Info.JobID == WAR.JobID)
			.ThenByDescending(tpl => tpl.Info.JobID == DRK.JobID)
			.ThenByDescending(tpl => tpl.Info.JobID == GNB.JobID)
			.ThenByDescending(tpl => tpl.Info.JobID == WHM.JobID)
			.ThenByDescending(tpl => tpl.Info.JobID == SCH.JobID)
			.ThenByDescending(tpl => tpl.Info.JobID == AST.JobID)
			.ThenByDescending(tpl => tpl.Info.JobID == SGE.JobID)
			.ThenByDescending(tpl => tpl.Info.JobID == MNK.JobID)
			.ThenByDescending(tpl => tpl.Info.JobID == DRG.JobID)
			.ThenByDescending(tpl => tpl.Info.JobID == NIN.JobID)
			.ThenByDescending(tpl => tpl.Info.JobID == SAM.JobID)
			.ThenByDescending(tpl => tpl.Info.JobID == RPR.JobID)
			.ThenByDescending(tpl => tpl.Info.JobID == VPR.JobID)
			.ThenByDescending(tpl => tpl.Info.JobID == BRD.JobID)
			.ThenByDescending(tpl => tpl.Info.JobID == MCH.JobID)
			.ThenByDescending(tpl => tpl.Info.JobID == DNC.JobID)
			.ThenByDescending(tpl => tpl.Info.JobID == BLM.JobID)
			.ThenByDescending(tpl => tpl.Info.JobID == SMN.JobID)
			.ThenByDescending(tpl => tpl.Info.JobID == RDM.JobID)
			.ThenByDescending(tpl => tpl.Info.JobID == PCT.JobID)
			.ThenByDescending(tpl => tpl.Info.JobID == BLU.JobID)
			.ThenByDescending(tpl => tpl.Info.Role == 1)
			.ThenByDescending(tpl => tpl.Info.Role == 4)
			.ThenByDescending(tpl => tpl.Info.Role == 2)
			.ThenByDescending(tpl => tpl.Info.Role == 3)
			.ThenBy(tpl => tpl.Info.ClassJobCategory)
			.ThenBy(tpl => tpl.Info.JobName)
			.ThenBy(tpl => tpl.Info.Order)
			.GroupBy(tpl => tpl.Info.JobName)
			.ToDictionary(
				tpl => tpl.Key,
				tpl => tpl.ToList())!;
		}

		internal static Dictionary<CustomComboPreset, (CustomComboPreset Preset, CustomComboInfoAttribute Info)[]> GetPresetChildren()
		{
			Dictionary<CustomComboPreset, List<CustomComboPreset>> childCombos = Enum.GetValues<CustomComboPreset>().ToDictionary(
				tpl => tpl,
				tpl => new List<CustomComboPreset>());

			foreach (CustomComboPreset preset in Enum.GetValues<CustomComboPreset>())
			{
				CustomComboPreset? parent = preset.GetAttribute<ParentComboAttribute>()?.ParentPreset;
				if (parent != null)
				{
					childCombos[parent.Value].Add(preset);
				}
			}

			return childCombos.ToDictionary(
				kvp => kvp.Key,
				kvp => kvp.Value
					.Select(preset => (Preset: preset, Info: preset.GetAttribute<CustomComboInfoAttribute>()))
					.OrderBy(tpl => tpl.Info.Order).ToArray())!;
		}

		public OpenWindow OpenWindow { get; set; } = OpenWindow.PvE;

		public ConfigWindow() : base($"StackCombo")
		{
			RespectCloseHotkey = true;

			SizeCondition = ImGuiCond.FirstUseEver;
			Size = new Vector2(800, 650);
			SetMinSize();

			Svc.PluginInterface.UiBuilder.DefaultFontHandle.ImFontChanged += SetMinSize;
		}

		private void SetMinSize(IFontHandle? fontHandle = null, ILockedImFont? lockedFont = null)
		{
			SizeConstraints = new()
			{
				MinimumSize = new Vector2(700f.Scale(), 10f.Scale())
			};
		}

		public override void Draw()
		{
			Vector2 region = ImGui.GetContentRegionAvail();
			Vector2 itemSpacing = ImGui.GetStyle().ItemSpacing;

			float topLeftSideHeight = region.Y;

			using ImRaii.Style style = ImRaii.PushStyle(ImGuiStyleVar.CellPadding, new Vector2(4, 0));
			using ImRaii.IEndObject table = ImRaii.Table("###MainTable", 2, ImGuiTableFlags.Resizable);
			if (!table)
			{
				return;
			}

			ImGui.TableSetupColumn("##LeftColumn", ImGuiTableColumnFlags.WidthFixed, ImGui.GetWindowWidth() / 3);

			ImGui.TableNextColumn();

			Vector2 regionSize = ImGui.GetContentRegionAvail();

			ImGui.PushStyleVar(ImGuiStyleVar.SelectableTextAlign, new Vector2(0.5f, 0.5f));

			using (ImRaii.IEndObject leftChild = ImRaii.Child($"###LeftSide", regionSize with { Y = topLeftSideHeight }, false, ImGuiWindowFlags.NoDecoration))
			{
				if (ImGui.Selectable("PvE Features", OpenWindow == OpenWindow.PvE))
				{
					OpenWindow = OpenWindow.PvE;
				}
				if (ImGui.Selectable("PvP Features", OpenWindow == OpenWindow.PvP))
				{
					OpenWindow = OpenWindow.PvP;
				}
				ImGui.Spacing();
				if (ImGui.Selectable("Misc. Settings", OpenWindow == OpenWindow.Settings))
				{
					OpenWindow = OpenWindow.Settings;
				}

#if DEBUG
				ImGui.Spacing();
				if (ImGui.Selectable("Debug", OpenWindow == OpenWindow.Debug))
				{
					OpenWindow = OpenWindow.Debug;
				}
				ImGui.Spacing();
#endif

			}

			ImGui.PopStyleVar();
			ImGui.TableNextColumn();
			using ImRaii.IEndObject rightChild = ImRaii.Child($"###RightSide", Vector2.Zero, false);
			switch (OpenWindow)
			{
				case OpenWindow.PvE:
					PvEFeatures.Draw();
					break;
				case OpenWindow.PvP:
					PvPFeatures.Draw();
					break;
				case OpenWindow.Settings:
					Settings.Draw();
					break;
				case OpenWindow.Debug:
					Debug.Draw();
					break;
				default:
					break;
			};
		}

		public void Dispose()
		{
			Svc.PluginInterface.UiBuilder.DefaultFontHandle.ImFontChanged -= SetMinSize;
		}
	}

	public enum OpenWindow
	{
		None = 0,
		PvE = 1,
		PvP = 2,
		Settings = 3,
		About = 4,
		Debug = 5,
	}
}
