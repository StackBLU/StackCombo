using StackCombo.ComboHelper.Functions;
using StackCombo.Data;

namespace StackCombo.Extensions
{
	internal static class UIntExtensions
	{
		internal static bool LevelChecked(this uint value)
		{
			return CustomComboFunctions.LevelChecked(value);
		}

		internal static bool TraitLevelChecked(this uint value)
		{
			return CustomComboFunctions.TraitLevelChecked(value);
		}

		internal static string ActionName(this uint value)
		{
			return ActionWatching.GetActionName(value);
		}
	}

	internal static class UShortExtensions
	{
		internal static string StatusName(this ushort value)
		{
			return ActionWatching.GetStatusName(value);
		}
	}
}
