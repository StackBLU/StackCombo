using StackCombo.ComboHelper.Functions;
using StackCombo.Combos.PvE.Content;
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

		public static class Config
		{
			public static UserInt
				RDM_VariantCure = new("RDM_VariantCure"),
				RDM_ST_Lucid_Threshold = new("RDM_LucidDreaming_Threshold", 6500),
				RDM_AoE_Lucid_Threshold = new("RDM_AoE_Lucid_Threshold", 6500),
				RDM_AoE_MoulinetRange = new("RDM_MoulinetRange");
			public static UserBool
				RDM_ST_oGCD_OnAction_Adv = new("RDM_ST_oGCD_OnAction_Adv"),
				RDM_ST_oGCD_Fleche = new("RDM_ST_oGCD_Fleche"),
				RDM_ST_oGCD_ContraSixte = new("RDM_ST_oGCD_ContraSixte"),
				RDM_ST_oGCD_Engagement = new("RDM_ST_oGCD_Engagement"),
				RDM_ST_oGCD_Engagement_Pooling = new("RDM_ST_oGCD_Engagement_Pooling"),
				RDM_ST_oGCD_CorpACorps = new("RDM_ST_oGCD_CorpACorps"),
				RDM_ST_oGCD_CorpACorps_Melee = new("RDM_ST_oGCD_CorpACorps_Melee"),
				RDM_ST_oGCD_CorpACorps_Pooling = new("RDM_ST_oGCD_CorpACorps_Pooling"),
				RDM_ST_oGCD_ViceOfThorns = new("RDM_ST_oGCD_ViceOfThorns"),
				RDM_ST_oGCD_Prefulgence = new("RDM_ST_oGCD_Prefulgence"),
				RDM_ST_MeleeCombo_Adv = new("RDM_ST_MeleeCombo_Adv"),
				RDM_ST_MeleeFinisher_Adv = new("RDM_ST_MeleeFinisher_Adv"),
				RDM_ST_MeleeEnforced = new("RDM_ST_MeleeEnforced"),

				RDM_AoE_oGCD_OnAction_Adv = new("RDM_AoE_oGCD_OnAction_Adv"),
				RDM_AoE_oGCD_Fleche = new("RDM_AoE_oGCD_Fleche"),
				RDM_AoE_oGCD_ContraSixte = new("RDM_AoE_oGCD_ContraSixte"),
				RDM_AoE_oGCD_Engagement = new("RDM_AoE_oGCD_Engagement"),
				RDM_AoE_oGCD_Engagement_Pooling = new("RDM_AoE_oGCD_Engagement_Pooling"),
				RDM_AoE_oGCD_CorpACorps = new("RDM_AoE_oGCD_CorpACorps"),
				RDM_AoE_oGCD_CorpACorps_Melee = new("RDM_AoE_oGCD_CorpACorps_Melee"),
				RDM_AoE_oGCD_CorpACorps_Pooling = new("RDM_AoE_oGCD_CorpACorps_Pooling"),
				RDM_AoE_oGCD_ViceOfThorns = new("RDM_AoE_oGCD_ViceOfThorns"),
				RDM_AoE_oGCD_Prefulgence = new("RDM_AoE_oGCD_Prefulgence"),
				RDM_AoE_MeleeCombo_Adv = new("RDM_AoE_MeleeCombo_Adv"),
				RDM_AoE_MeleeFinisher_Adv = new("RDM_AoE_MeleeFinisher_Adv");
			public static UserBoolArray
				RDM_ST_oGCD_OnAction = new("RDM_ST_oGCD_OnAction"),
				RDM_ST_MeleeCombo_OnAction = new("RDM_ST_MeleeCombo_OnAction"),
				RDM_ST_MeleeFinisher_OnAction = new("RDM_ST_MeleeFinisher_OnAction"),

				RDM_AoE_oGCD_OnAction = new("RDM_AoE_oGCD_OnAction"),
				RDM_AoE_MeleeCombo_OnAction = new("RDM_AoE_MeleeCombo_OnAction"),
				RDM_AoE_MeleeFinisher_OnAction = new("RDM_AoE_MeleeFinisher_OnAction");
		}

		internal class RDM_VariantVerCure : CustomComboClass
		{
			protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.RDM_Variant_Cure;

			protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
			{
				return actionID is Vercure && IsEnabled(CustomComboPreset.RDM_Variant_Cure2) && IsEnabled(Variant.VariantCure)
					? Variant.VariantCure : actionID;
			}
		}
	}
}