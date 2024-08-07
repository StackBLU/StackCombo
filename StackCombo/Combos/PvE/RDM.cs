using Dalamud.Game.ClientState.JobGauge.Types;
using StackCombo.ComboHelper.Functions;
using StackCombo.CustomCombo;

namespace StackCombo.Combos.PvE
{
	internal class RDM
	{
		public const byte JobID = 35;

		public const uint
			Verthunder = 7505,
			Veraero = 7507,
			Veraero2 = 16525,
			Veraero3 = 25856,
			Verthunder2 = 16524,
			Verthunder3 = 25855,
			Impact = 16526,
			Redoublement = 7516,
			EnchantedRedoublement = 7529,
			Zwerchhau = 7512,
			EnchantedZwerchhau = 7528,
			Riposte = 7504,
			EnchantedRiposte = 7527,
			Scatter = 7509,
			Verstone = 7511,
			Verfire = 7510,
			Vercure = 7514,
			Jolt = 7503,
			Jolt2 = 7524,
			Jolt3 = 37004,
			Verholy = 7526,
			Verflare = 7525,
			Fleche = 7517,
			ContreSixte = 7519,
			Engagement = 16527,
			Verraise = 7523,
			Scorch = 16530,
			Resolution = 25858,
			Moulinet = 7513,
			EnchantedMoulinet = 7530,
			EnchantedMoulinetDeux = 37002,
			EnchantedMoulinetTrois = 37003,
			Corpsacorps = 7506,
			Displacement = 7515,
			Reprise = 16529,
			ViceOfThorns = 37005,
			GrandImpact = 37006,
			Prefulgence = 37007,

			Acceleration = 7518,
			Manafication = 7521,
			Embolden = 7520,
			MagickBarrier = 25857;

		public static class Buffs
		{
			public const ushort
				VerfireReady = 1234,
				VerstoneReady = 1235,
				Dualcast = 1249,
				Chainspell = 2560,
				Acceleration = 1238,
				Embolden = 1239,
				EmboldenOthers = 1297,
				Manafication = 1971,
				MagickBarrier = 2707,
				MagickedSwordPlay = 3875,
				ThornedFlourish = 3876,
				GrandImpactReady = 3877,
				PrefulugenceReady = 3878;
		}

		public static class Debuffs
		{
		}



		public static class Traits
		{
			public const uint
				EnhancedEmbolden = 620,
				EnhancedManaficationII = 622,
				EnhancedManaficationIII = 622,
				EnhancedAccelerationII = 624;
		}

		public static RDMGauge Gauge
		{
			get
			{
				return CustomComboFunctions.GetJobGauge<RDMGauge>();
			}
		}

		public static class Config
		{
			internal static UserInt
				RDM_ST_Lucid = new("RDM_ST_Lucid", 7500),
				RDM_AoE_Lucid = new("RDM_AoE_Lucid", 7500);
		}

		internal class RDM_ST_DPS : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.RDM_ST_DPS;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID is Jolt or Jolt2 or Jolt3 or Verthunder or Verthunder3 or Veraero or Veraero3 or Verfire or Verstone && IsEnabled(CustomComboPreset.RDM_ST_DPS))
				{
					if (IsEnabled(CustomComboPreset.RDM_ST_Lucid) && ActionReady(All.LucidDreaming) && LocalPlayer.CurrentMp <= 1000)
					{
						return All.LucidDreaming;
					}

					if (IsEnabled(CustomComboPreset.RDM_ST_Lucid) && ActionReady(All.LucidDreaming)
						&& LocalPlayer.CurrentMp <= Config.RDM_ST_Lucid && CanSpellWeave(actionID))
					{
						return All.LucidDreaming;
					}

					if (WasLastSpell(Scorch))
					{
						return Resolution;
					}

					if (WasLastSpell(Verholy) || WasLastSpell(Verflare))
					{
						return Scorch;
					}

					if (Gauge.ManaStacks is 3)
					{
						if (Gauge.BlackMana >= Gauge.WhiteMana)
						{
							return Verholy;
						}

						if (Gauge.WhiteMana >= Gauge.BlackMana)
						{
							return Verflare;
						}
					}

					if (HasEffect(Buffs.Dualcast))
					{
						if (Gauge.BlackMana >= Gauge.WhiteMana)
						{
							return OriginalHook(Veraero3);
						}

						if (Gauge.WhiteMana >= Gauge.BlackMana)
						{
							return OriginalHook(Verthunder3);
						}
					}

					if (HasEffect(Buffs.VerstoneReady))
					{
						return Verstone;
					}

					if (HasEffect(Buffs.VerfireReady))
					{
						return Verfire;
					}
					return OriginalHook(Jolt3);
				}
				return actionID;
			}
		}

		internal class RDM_AoE_DPS : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.RDM_AoE_DPS;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID is Scatter or Impact or Verthunder2 or Veraero2 && IsEnabled(CustomComboPreset.RDM_AoE_DPS))
				{
					if (IsEnabled(CustomComboPreset.RDM_AoE_Lucid) && ActionReady(All.LucidDreaming) && LocalPlayer.CurrentMp <= 1000)
					{
						return All.LucidDreaming;
					}

					if (IsEnabled(CustomComboPreset.RDM_AoE_Lucid) && ActionReady(All.LucidDreaming)
						&& LocalPlayer.CurrentMp <= Config.RDM_AoE_Lucid && CanSpellWeave(actionID))
					{
						return All.LucidDreaming;
					}

					if (WasLastSpell(Scorch))
					{
						return Resolution;
					}

					if (WasLastSpell(Verholy) || WasLastSpell(Verflare))
					{
						return Scorch;
					}

					if (Gauge.ManaStacks is 3)
					{
						if (Gauge.BlackMana >= Gauge.WhiteMana)
						{
							return Verholy;
						}

						if (Gauge.WhiteMana >= Gauge.BlackMana)
						{
							return Verflare;
						}
					}

					if (HasEffect(Buffs.Dualcast))
					{
						return OriginalHook(Impact);
					}

					if (Gauge.BlackMana >= Gauge.WhiteMana)
					{
						return Veraero2;
					}

					if (Gauge.WhiteMana >= Gauge.BlackMana)
					{
						return Verthunder2;
					}

					return OriginalHook(Jolt3);
				}
				return actionID;
			}
		}

		internal class RDM_ST_Melee : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.RDM_ST_Melee;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID is Riposte or Zwerchhau or Redoublement && IsEnabled(CustomComboPreset.RDM_ST_Melee))
				{
					if (WasLastSpell(Scorch))
					{
						return Resolution;
					}

					if (WasLastSpell(Verholy) || WasLastSpell(Verflare))
					{
						return Scorch;
					}

					if (Gauge.ManaStacks is 3)
					{
						if (Gauge.BlackMana >= Gauge.WhiteMana)
						{
							return Verholy;
						}

						if (Gauge.WhiteMana >= Gauge.BlackMana)
						{
							return Verflare;
						}
					}

					if (WasLastWeaponskill(OriginalHook(Zwerchhau)))
					{
						return OriginalHook(Redoublement);
					}

					if (WasLastWeaponskill(OriginalHook(Riposte)))
					{
						return OriginalHook(Zwerchhau);
					}
					return OriginalHook(Riposte);
				}
				return actionID;
			}
		}

		internal class RDM_AoE_Melee : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.RDM_AoE_Melee;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID is Moulinet && IsEnabled(CustomComboPreset.RDM_AoE_Melee))
				{
					if (WasLastSpell(Scorch))
					{
						return Resolution;
					}

					if (WasLastSpell(Verholy) || WasLastSpell(Verflare))
					{
						return Scorch;
					}

					if (Gauge.ManaStacks is 3)
					{
						if (Gauge.BlackMana >= Gauge.WhiteMana)
						{
							return Verholy;
						}

						if (Gauge.WhiteMana >= Gauge.BlackMana)
						{
							return Verflare;
						}
					}

					return OriginalHook(Moulinet);
				}
				return actionID;
			}
		}

		internal class RDM_Raise : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.RDM_Raise;
			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID is Verraise && IsEnabled(CustomComboPreset.RDM_Raise))
				{
					if (IsOffCooldown(All.Swiftcast))
					{
						return All.Swiftcast;
					}
					if (ActionReady(Verraise))
					{
						return Verraise;
					}
				}
				return actionID;
			}
		}

		internal class RDM_EmboldenProtection : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.RDM_EmboldenProtection;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID is Embolden && IsEnabled(CustomComboPreset.RDM_EmboldenProtection))
				{
					if (HasEffectAny(Buffs.Embolden))
					{
						return OriginalHook(11);
					}
				}
				return actionID;
			}
		}

		internal class RDM_MagickProtection : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.RDM_MagickProtection;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID is MagickBarrier && IsEnabled(CustomComboPreset.RDM_MagickProtection))
				{
					if (HasEffectAny(Buffs.MagickBarrier))
					{
						return OriginalHook(11);
					}
				}
				return actionID;
			}
		}
	}
}