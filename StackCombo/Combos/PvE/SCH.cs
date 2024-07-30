using Dalamud.Game.ClientState.JobGauge.Types;
using Dalamud.Game.ClientState.Statuses;
using StackCombo.ComboHelper.Functions;
using StackCombo.Combos.PvE.Content;
using StackCombo.CustomCombo;
using StackCombo.Data;
using System.Collections.Generic;

namespace StackCombo.Combos.PvE
{
	internal static class SCH
	{
		public const byte JobID = 28;

		internal const uint

			Physick = 190,
			Adloquium = 185,
			Succor = 186,
			Lustrate = 189,
			SacredSoil = 188,
			Indomitability = 3583,
			Excogitation = 7434,
			Consolation = 16546,
			Resurrection = 173,

			Bio = 17864,
			Bio2 = 17865,
			Biolysis = 16540,
			Ruin = 17869,
			Ruin2 = 17870,
			Broil = 3584,
			Broil2 = 7435,
			Broil3 = 16541,
			Broil4 = 25865,
			EnergyDrain = 167,
			ArtOfWar = 16539,
			ArtOfWarII = 25866,
			BanefulImpaction = 37012,

			SummonSeraph = 16545,
			SummonEos = 17215,
			WhisperingDawn = 16537,
			FeyIllumination = 16538,
			Dissipation = 3587,
			Aetherpact = 7437,
			FeyBlessing = 16543,

			Aetherflow = 166,
			Recitation = 16542,
			ChainStratagem = 7436,
			DeploymentTactics = 3585;

		internal static readonly List<uint>
			BroilList = [Ruin, Broil, Broil2, Broil3, Broil4],
			AetherflowList = [EnergyDrain, Lustrate, SacredSoil, Indomitability, Excogitation],
			FairyList = [WhisperingDawn, FeyBlessing, FeyIllumination, Dissipation, Aetherpact];

		internal static class Buffs
		{
			internal const ushort
				Galvanize = 297,
				SacredSoil = 299,
				Recitation = 1896,
				ImpactImminent = 3882;
		}

		internal static class Debuffs
		{
			internal const ushort
				Bio1 = 179,
				Bio2 = 189,
				Biolysis = 1895,
				ChainStratagem = 1221;
		}

		internal static readonly Dictionary<uint, ushort>
			BioList = new() {
				{ Bio, Debuffs.Bio1 },
				{ Bio2, Debuffs.Bio2 },
				{ Biolysis, Debuffs.Biolysis }
			};

		private static SCHGauge Gauge
		{
			get
			{
				return CustomComboFunctions.GetJobGauge<SCHGauge>();
			}
		}

		public static class Config
		{
			public static UserInt
				SCH_ST_DPS_LucidOption = new("SCH_ST_DPS_LucidOption", 7500),
				SCH_AoE_LucidOption = new("SCH_ST_DPS_LucidOption", 7500);
		}

		internal class SCH_DPS : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SCH_DPS;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID is Broil || actionID is Broil2 || actionID is Broil3 || actionID is Broil4)
				{
					if (IsEnabled(CustomComboPreset.SCH_DPS_Lucid) && ActionReady(All.LucidDreaming) && LocalPlayer.CurrentMp <= 1000)
					{
						return All.LucidDreaming;
					}

					if (IsEnabled(CustomComboPreset.SCH_DPS_Variant_Rampart) &&
						IsEnabled(Variant.VariantRampart) &&
						IsOffCooldown(Variant.VariantRampart) &&
						CanSpellWeave(actionID))
					{
						return Variant.VariantRampart;
					}

					if (IsEnabled(CustomComboPreset.SCH_DPS_Seraph) &&
						ActionReady(OriginalHook(SummonSeraph)) && Gauge.SeraphTimer > 0 && Gauge.SeraphTimer < 5000 &&
						InCombat() && CanSpellWeave(actionID))
					{
						return OriginalHook(SummonSeraph);
					}

					if (IsEnabled(CustomComboPreset.SCH_DPS_Dissipation) &&
						ActionReady(Dissipation) && HasPetPresent() && Gauge.Aetherflow == 0
						&& InCombat() && CanSpellWeave(actionID) && ActionWatching.NumberOfGcdsUsed >= 4)
					{
						return Dissipation;
					}

					if (IsEnabled(CustomComboPreset.SCH_DPS_Aetherflow) &&
						ActionReady(Aetherflow) && Gauge.Aetherflow == 0 &&
						InCombat() && CanSpellWeave(actionID) && ActionWatching.NumberOfGcdsUsed >= 5)
					{
						return Aetherflow;
					}

					if (IsEnabled(CustomComboPreset.SCH_DPS_Lucid) &&
						ActionReady(All.LucidDreaming) &&
						LocalPlayer.CurrentMp <= Config.SCH_ST_DPS_LucidOption &&
						CanSpellWeave(actionID))
					{
						return All.LucidDreaming;
					}

					if (HasBattleTarget())
					{
						if (IsEnabled(CustomComboPreset.SCH_DPS_ChainStrat))
						{
							if (ActionReady(ChainStratagem) && !TargetHasEffectAny(Debuffs.ChainStratagem)
								&& InCombat() && CanSpellWeave(actionID)
								&& ActionWatching.NumberOfGcdsUsed >= 2)
							{
								return ChainStratagem;
							}

							if (LevelChecked(BanefulImpaction) &&
								HasEffect(Buffs.ImpactImminent) &&
								InCombat() &&
								CanSpellWeave(actionID))
							{
								return BanefulImpaction;
							}
						}

						if (IsEnabled(CustomComboPreset.SCH_DPS_EnergyDrain))
						{
							if (LevelChecked(EnergyDrain) && InCombat() && Gauge.Aetherflow > 0
								&& (GetCooldownRemainingTime(Aetherflow) <= 10f || GetCooldownRemainingTime(Dissipation) <= 10f || TargetHasEffect(Debuffs.ChainStratagem))
								&& CanSpellWeave(actionID))
							{
								return EnergyDrain;
							}
						}

						if (IsEnabled(CustomComboPreset.SCH_DPS_Bio) && LevelChecked(Bio) && InCombat())
						{
							Status? dotDebuff = FindTargetEffect(BioList[OriginalHook(Bio)]);
							Status? sustainedDamage = FindTargetEffect(Variant.Debuffs.SustainedDamage);

							if (IsEnabled(CustomComboPreset.SCH_DPS_Variant_SpiritDart) &&
								IsEnabled(Variant.VariantSpiritDart) &&
								(sustainedDamage is null || sustainedDamage?.RemainingTime <= 3) &&
								CanSpellWeave(actionID))
							{
								return Variant.VariantSpiritDart;
							}

							if ((dotDebuff is null && ActionWatching.NumberOfGcdsUsed >= 3) || dotDebuff?.RemainingTime <= 3)
							{
								return OriginalHook(Bio);
							}
						}

						if (IsEnabled(CustomComboPreset.SCH_DPS_Aetherpact) &&
							ActionReady(Aetherpact) && Gauge.FairyGauge == 100 &&
							InCombat() && CanSpellWeave(actionID))
						{
							return Aetherpact;
						}

						if (IsEnabled(CustomComboPreset.SCH_DPS_Ruin2Movement) &&
							LevelChecked(Ruin2) && IsMoving)
						{
							return OriginalHook(Ruin2);
						}
					}
				}
				return actionID;
			}
		}

		internal class SCH_AoE : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SCH_AoE;
			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				if (actionID is ArtOfWar or ArtOfWarII)
				{
					if (IsEnabled(CustomComboPreset.SCH_DPS_Variant_Rampart) &&
						IsEnabled(Variant.VariantRampart) &&
						IsOffCooldown(Variant.VariantRampart) &&
						CanSpellWeave(actionID))
					{
						return Variant.VariantRampart;
					}

					Status? sustainedDamage = FindTargetEffect(Variant.Debuffs.SustainedDamage);
					if (IsEnabled(CustomComboPreset.SCH_DPS_Variant_SpiritDart) &&
						IsEnabled(Variant.VariantSpiritDart) &&
						(sustainedDamage is null || sustainedDamage?.RemainingTime <= 3) &&
						HasBattleTarget() &&
						CanSpellWeave(actionID))
					{
						return Variant.VariantSpiritDart;
					}

					if (IsEnabled(CustomComboPreset.SCH_AoE_Lucid) && ActionReady(All.LucidDreaming) && LocalPlayer.CurrentMp <= 1000)
					{
						return All.LucidDreaming;
					}

					if (IsEnabled(CustomComboPreset.SCH_AoE_Aetherflow) &&
						ActionReady(Aetherflow) && Gauge.Aetherflow == 0 &&
						InCombat() && CanSpellWeave(actionID))
					{
						return Aetherflow;
					}

					if (IsEnabled(CustomComboPreset.SCH_AoE_Lucid) &&
						ActionReady(All.LucidDreaming) &&
						LocalPlayer.CurrentMp <= Config.SCH_AoE_LucidOption &&
						CanSpellWeave(actionID))
					{
						return All.LucidDreaming;
					}
				}
				return actionID;
			}
		}

		internal class SCH_Lustrate : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SCH_Lustrate;
			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				return actionID is Lustrate && LevelChecked(Excogitation) && IsOffCooldown(Excogitation) ? Excogitation : actionID;
			}
		}

		internal class SCH_Raise : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SCH_Raise;
			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				return actionID is Resurrection && IsOnCooldown(All.Swiftcast) ? Resurrection : actionID;
			}
		}

		internal class SCH_FairyReminder : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SCH_FairyReminder;
			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				return FairyList.Contains(actionID) && !HasPetPresent() && Gauge.SeraphTimer == 0 ? SummonEos : actionID;
			}
		}
	}
}