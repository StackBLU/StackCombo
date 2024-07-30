using StackCombo.CustomCombo;

namespace StackCombo.Combos.PvP
{
	internal static class VPRPvP
	{
		public const byte JobID = 41;

		internal const uint
			Malefic = 29242,
			AspectedBenefic = 29243,
			Gravity = 29244,
			DoubleCast = 29245,
			DoubleMalefic = 29246,
			NocturnalBenefic = 29247,
			DoubleGravity = 29248,
			Draw = 29249,
			Macrocosmos = 29253,
			Microcosmos = 29254;

		internal class Buffs
		{
			internal const ushort
				BalanceDrawn = 3101,
				BoleDrawn = 3403,
				ArrowDrawn = 3404,
				Arrow = 3402,
				Balance = 1338,
				Bole = 1339;
		}

		internal class ASTPvP_Burst : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.ASTPvP_Burst;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID is Malefic)
				{
					if (IsOffCooldown(Draw) && !InCombat() && IsEnabled(CustomComboPreset.ASTPvP_Card))
					{
						return Draw;
					}

					if (!InCombat() &&
						(IsOffCooldown(Draw) || HasEffect(Buffs.BoleDrawn) || HasEffect(Buffs.ArrowDrawn)))
					{
						return Malefic;
					}

					if (lastComboMove == Draw && !CanWeave(actionID))
					{
						return Malefic;
					}

					if (HasCharges(DoubleCast) && IsOffCooldown(Gravity) && IsOffCooldown(Macrocosmos) && HasEffect(Buffs.BalanceDrawn) && IsEnabled(CustomComboPreset.ASTPvP_Card))
					{
						return OriginalHook(Draw);
					}

					if (!TargetHasEffectAny(PvPCommon.Buffs.Guard))
					{
						if (lastComboMove == DoubleGravity && IsOffCooldown(Macrocosmos))
						{
							return Macrocosmos;
						}

						if (lastComboMove == Gravity && HasCharges(DoubleCast) && IsEnabled(CustomComboPreset.ASTPvP_DoubleCast))
						{
							return DoubleGravity;
						}

						if (IsOffCooldown(Gravity))
						{
							return Gravity;
						}

						if (lastComboMove == Malefic && (GetRemainingCharges(DoubleCast) > 1 ||
							GetCooldownRemainingTime(Gravity) > 7.5f) && CanWeave(actionID) && IsEnabled(CustomComboPreset.ASTPvP_DoubleCast))
						{
							return DoubleMalefic;
						}
					}

					if (((GetBuffRemainingTime(Buffs.BalanceDrawn) < 3) ||
						(GetBuffRemainingTime(Buffs.BoleDrawn) < 3) ||
						(GetBuffRemainingTime(Buffs.ArrowDrawn) < 3)) &&
						CanWeave(actionID) && IsEnabled(CustomComboPreset.ASTPvP_Card))
					{
						return OriginalHook(Draw);
					}

					if (IsOffCooldown(Draw) && CanWeave(actionID) && IsEnabled(CustomComboPreset.ASTPvP_Card))
					{
						return Draw;
					}

					if (CanWeave(actionID) && GetCooldownRemainingTime(Macrocosmos) > 7.5f && (IsOffCooldown(Draw) ||
						HasEffect(Buffs.BalanceDrawn) || HasEffect(Buffs.BoleDrawn) || HasEffect(Buffs.ArrowDrawn)) && IsEnabled(CustomComboPreset.ASTPvP_Card))
					{
						return OriginalHook(Draw);
					}
				}

				return actionID;
			}

			internal class ASTPvP_Heal : CustomComboClass
			{
				protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.ASTPvP_Heal;

				protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
				{
					return actionID is AspectedBenefic && CanWeave(actionID) &&
						lastComboMove == AspectedBenefic &&
						HasCharges(DoubleCast)
						? OriginalHook(DoubleCast)
						: actionID;
				}
			}
		}
	}
}