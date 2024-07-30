using StackCombo.CustomCombo;

namespace StackCombo.Combos.PvP
{
	internal static class WHMPvP
	{
		public const byte JobID = 24;

		public const uint
			Glare = 29223,
			Cure2 = 29224,
			Cure3 = 29225,
			AfflatusMisery = 29226,
			Aquaveil = 29227,
			MiracleOfNature = 29228,
			SeraphStrike = 29229;

		internal class Buffs
		{
			internal const ushort
				Cure3Ready = 3083;
		}

		internal class WHMPvP_Burst : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.WHMPvP_Burst;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID is Glare)
				{
					if (!TargetHasEffectAny(PvPCommon.Buffs.Guard))
					{
						if (IsEnabled(CustomComboPreset.WHMPvP_Afflatus_Misery) && IsOffCooldown(AfflatusMisery))
						{
							return AfflatusMisery;
						}

						if (CanWeave(actionID))
						{
							if (IsEnabled(CustomComboPreset.WHMPvP_Mirace_of_Nature) && IsOffCooldown(MiracleOfNature))
							{
								return MiracleOfNature;
							}

							if (IsEnabled(CustomComboPreset.WHMPvP_Seraph_Strike) && IsOffCooldown(SeraphStrike))
							{
								return SeraphStrike;
							}
						}
					}
				}

				return actionID;
			}
		}
		internal class WHMPvP_Aquaveil : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.WHMPvP_Aquaveil;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				return actionID is Cure2 && IsOffCooldown(Aquaveil) ? Aquaveil : actionID;
			}
		}

		internal class WHMPvP_Cure3 : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.WHMPvP_Cure3;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				return actionID is Cure2 && HasEffect(Buffs.Cure3Ready) ? Cure3 : actionID;
			}
		}
	}
}