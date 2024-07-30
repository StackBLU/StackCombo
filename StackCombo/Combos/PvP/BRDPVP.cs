using StackCombo.CustomCombo;

namespace StackCombo.Combos.PvP
{
	internal static class BRDPvP
	{
		public const byte ClassID = 5;
		public const byte JobID = 23;

		public const uint
			PowerfulShot = 29391,
			ApexArrow = 29393,
			SilentNocturne = 29395,
			EmpyrealArrow = 29398,
			RepellingShot = 29399,
			WardensPaean = 29400,
			PitchPerfect = 29392,
			BlastArrow = 29394;

		public static class Buffs
		{
			public const ushort
				FrontlinersMarch = 3138,
				FrontlinersForte = 3140,
				Repertoire = 3137,
				BlastArrowReady = 3142;
		}

		internal class BRDPvP_BurstMode : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BRDPvP_BurstMode;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{

				if (actionID == PowerfulShot)
				{
					bool canWeave = CanWeave(actionID, 0.5);

					if (canWeave)
					{
						if (GetCooldown(EmpyrealArrow).RemainingCharges == 3)
						{
							return OriginalHook(EmpyrealArrow);
						}

						if (IsEnabled(CustomComboPreset.BRDPvP_SilentNocturne) && !GetCooldown(SilentNocturne).IsCooldown)
						{
							return OriginalHook(SilentNocturne);
						}
					}

					return HasEffect(Buffs.BlastArrowReady)
						? OriginalHook(BlastArrow)
						: HasEffect(Buffs.Repertoire)
						? OriginalHook(PowerfulShot)
						: !GetCooldown(ApexArrow).IsCooldown ? OriginalHook(ApexArrow) : OriginalHook(PowerfulShot);
				}

				return actionID;
			}
		}
	}
}