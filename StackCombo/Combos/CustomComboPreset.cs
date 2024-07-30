using StackCombo.Attributes;
using StackCombo.Combos.PvE;
using StackCombo.Combos.PvP;

namespace StackCombo.Combos
{
	public enum CustomComboPreset
	{
		#region PvE Combos

		#region ASTROLOGIAN - 1000

		#region Single Target & AoE

		[ReplaceSkill(AST.Malefic, AST.Malefic2, AST.Malefic3, AST.Malefic4, AST.FallMalefic, AST.Combust, AST.Combust2, AST.Combust3, AST.Gravity, AST.Gravity2)]
		[CustomComboInfo("Single Target", "", AST.JobID, 1)]
		AST_ST_DPS = 1000,

		[ParentCombo(AST_ST_DPS)]
		[CustomComboInfo("Combust Uptime", "", AST.JobID, 1)]
		AST_ST_DPS_CombustUptime = 1001,

		[ReplaceSkill(AST.Gravity, AST.Gravity2)]
		[ParentCombo(AST_ST_DPS)]
		[CustomComboInfo("AoE", "", AST.JobID, 2)]
		AST_AoE_DPS = 1002,

		[ParentCombo(AST_ST_DPS)]
		[CustomComboInfo("Lucid Dreaming", "", AST.JobID)]
		AST_DPS_Lucid = 1004,

		[ParentCombo(AST_ST_DPS)]
		[CustomComboInfo("Card Draw", "", AST.JobID, 3)]
		AST_DPS_AutoDraw = 1006,

		#endregion

		#region Single Target Heals

		[ReplaceSkill(AST.Benefic2)]
		[CustomComboInfo("Single Target Heals", "", AST.JobID, 2)]
		AST_ST_SimpleHeals = 1020,

		[ParentCombo(AST_ST_SimpleHeals)]
		[CustomComboInfo("Aspected Benefic", "", AST.JobID, 1)]
		AST_ST_SimpleHeals_AspectedBenefic = 1023,

		#endregion

		#region Utility

		[ReplaceSkill(AST.Benefic2)]
		[CustomComboInfo("Benefic 2 Downgrade", "", AST.JobID, 4)]
		AST_Benefic = 1050,

		[ReplaceSkill(All.Swiftcast)]
		[CustomComboInfo("Swift Raise", "", AST.JobID, 5)]
		AST_Raise_Alternative = 1060,

		[ReplaceSkill(AST.Lightspeed)]
		[CustomComboInfo("Lightspeed Overwrite Protection", "", AST.JobID, 6)]
		AST_Lightspeed_Protection = 1061,

		#endregion

		#region Variant

		[Variant]
		[VariantParent(AST_ST_DPS_CombustUptime, AST_AoE_DPS)]
		[CustomComboInfo("Spirit Dart", "", AST.JobID)]
		AST_Variant_SpiritDart = 1080,

		[Variant]
		[VariantParent(AST_ST_DPS)]
		[CustomComboInfo("Rampart", "", AST.JobID)]
		AST_Variant_Rampart = 1081,

		#endregion

		#endregion

		#region BLACK MAGE - 2000

		[ReplaceSkill(BLM.Fire)]
		[ConflictingCombos(BLM_Scathe_Xeno, BLM_ST_AdvancedMode)]
		[CustomComboInfo("Simple Mode - Single Target", "Replaces Fire with a full one-button single target rotation.\nThis is the ideal for newcomers to the job", BLM.JobID, -10, "", "")]
		BLM_ST_SimpleMode = 2012,

		[ReplaceSkill(BLM.Fire)]
		[ConflictingCombos(BLM_Scathe_Xeno, BLM_ST_SimpleMode)]
		[CustomComboInfo("Advanced Mode - Single Target", "Replaces Fire with a full one-button single target rotation.\nTheses are ideal if you want to customize the rotation", BLM.JobID, -9, "", "")]
		BLM_ST_AdvancedMode = 2021,

		[ParentCombo(BLM_ST_AdvancedMode)]
		[CustomComboInfo("Thunder I/III", "Adds Thunder I/Thunder III when the debuff isn't present or is expiring", BLM.JobID)]
		BLM_ST_Adv_Thunder = 2029,

		[ParentCombo(BLM_ST_Adv_Thunder)]
		[CustomComboInfo("Thundercloud Spender", "Spends Thundercloud as soon as possible rather than waiting until Thunder is expiring", BLM.JobID)]
		BLM_ST_Adv_Thunder_ThunderCloud = 2030,

		[ParentCombo(BLM_ST_AdvancedMode)]
		[CustomComboInfo("Umbral Soul", "Uses Transpose/Umbral Soul when no target is selected", BLM.JobID, 10, "", "")]
		BLM_Adv_UmbralSoul = 2035,

		[ParentCombo(BLM_ST_AdvancedMode)]
		[CustomComboInfo("Movements", "Chooses to be used during movement", BLM.JobID)]
		BLM_Adv_Movement = 2036,

		[ParentCombo(BLM_ST_AdvancedMode)]
		[CustomComboInfo("Triplecast/Swiftcast", "Adds Triplecast/Swiftcast to the rotation", BLM.JobID, -8, "", "")]
		BLM_Adv_Casts = 2039,

		[ParentCombo(BLM_Adv_Casts)]
		[CustomComboInfo("Pool Triplecast", "Keep one Triplecast charge for movement", BLM.JobID)]
		BLM_Adv_Triplecast_Pooling = 2040,

		[ParentCombo(BLM_ST_AdvancedMode)]
		[CustomComboInfo("Cooldowns", "Select which cooldowns to add to the rotation", BLM.JobID, -8, "", "")]
		BLM_Adv_Cooldowns = 2042,

		[ParentCombo(BLM_ST_AdvancedMode)]
		[CustomComboInfo("Opener", "Adds the Lv.90 opener" +
			"\nWill default to the Standard opener when nothing is selected", BLM.JobID, -10, "", "")]
		BLM_Adv_Opener = 2043,

		[ParentCombo(BLM_ST_AdvancedMode)]
		[CustomComboInfo("Rotation", "Choose which rotation to use" +
			"\nWill default to the Standard rotation when nothing is selected", BLM.JobID, -9, "", "")]
		BLM_Adv_Rotation = 2045,

		[ReplaceSkill(BLM.Blizzard2, BLM.HighBlizzard2)]
		[ConflictingCombos(BLM_AoE_AdvancedMode)]
		[CustomComboInfo("Simple Mode - AoE", "Replaces Blizzard II with a full one-button AoE rotation.\nThis is the ideal for newcomers to the job", BLM.JobID, -8, "", "")]
		BLM_AoE_SimpleMode = 2008,

		[ReplaceSkill(BLM.Blizzard2, BLM.HighBlizzard2)]
		[ConflictingCombos(BLM_AoE_SimpleMode)]
		[CustomComboInfo("Advanced Mode - AoE", "Replaces Blizzard II with a full one-button AoE rotation.\nTheses are ideal if you want to customize the rotation", BLM.JobID, -8, "", "")]
		BLM_AoE_AdvancedMode = 2054,

		[ParentCombo(BLM_AoE_AdvancedMode)]
		[CustomComboInfo("Thunder Uptime", "Adds Thunder II/Thunder IV during Umbral Ice", BLM.JobID, 1, "", "")]
		BLM_AoE_Adv_ThunderUptime = 2055,

		[ParentCombo(BLM_AoE_Adv_ThunderUptime)]
		[CustomComboInfo("Uptime in Astral Fire", "Maintains uptime during Astral Fire", BLM.JobID, 1, "", "")]
		BLM_AoE_Adv_ThunderUptime_AstralFire = 2056,

		[ParentCombo(BLM_AoE_AdvancedMode)]
		[CustomComboInfo("Foul", "Adds Foul when available during Astral Fire", BLM.JobID, 2, "", "")]
		BLM_AoE_Adv_Foul = 2044,

		[ParentCombo(BLM_AoE_AdvancedMode)]
		[CustomComboInfo("Umbral Soul", "Use Transpose/Umbral Soul when no target is selected", BLM.JobID, 99, "", "")]
		BLM_AoE_Adv_UmbralSoul = 2049,

		[ParentCombo(BLM_AoE_AdvancedMode)]
		[CustomComboInfo("Cooldowns", "Select which cooldowns to add to the rotation", BLM.JobID, 1, "", "")]
		BLM_AoE_Adv_Cooldowns = 2052,

		[ReplaceSkill(BLM.Transpose)]
		[CustomComboInfo("Umbral Soul/Transpose", "Replaces Transpose with Umbral Soul when Umbral Soul is available", BLM.JobID)]
		BLM_UmbralSoul = 2001,

		[ReplaceSkill(BLM.LeyLines)]
		[CustomComboInfo("Between the Ley Lines", "Replaces Ley Lines with Between the Lines when Ley Lines is active", BLM.JobID)]
		BLM_Between_The_LeyLines = 2002,

		[ReplaceSkill(BLM.Blizzard, BLM.Freeze)]
		[CustomComboInfo("Blizzard I/III", "Replaces Blizzard I with Blizzard III when out of Umbral Ice" +
			"\nReplaces Freeze with Blizzard II when synced below Lv.40", BLM.JobID)]
		BLM_Blizzard_1to3 = 2003,

		[ReplaceSkill(BLM.Scathe)]
		[ConflictingCombos(BLM_ST_SimpleMode, BLM_ST_AdvancedMode)]
		[CustomComboInfo("Xenoglossy", "Replaces Scathe with Xenoglossy when available", BLM.JobID)]
		BLM_Scathe_Xeno = 2004,

		[ReplaceSkill(BLM.Fire)]
		[CustomComboInfo("Fire I/III", "Replaces Fire I with Fire III outside of Astral Fire or when Firestarter is up", BLM.JobID)]
		BLM_Fire_1to3 = 2005,

		[ReplaceSkill(BLM.AetherialManipulation)]
		[CustomComboInfo("Aetherial Manipulation", "Replaces Aetherial Manipulation with Between the Lines when you are out of active Ley Lines and standing still", BLM.JobID)]
		BLM_Aetherial_Manipulation = 2046,

		[Variant]
		[VariantParent(BLM_ST_SimpleMode, BLM_ST_AdvancedMode, BLM_AoE_SimpleMode)]
		[CustomComboInfo("Rampart", "Use Variant Rampart on cooldown", BLM.JobID)]
		BLM_Variant_Rampart = 2032,

		[Variant]
		[CustomComboInfo("Raise", "Turn Swiftcast into Variant Raise whenever you have the Swiftcast buff", BLM.JobID)]
		BLM_Variant_Raise = 2033,

		[Variant]
		[VariantParent(BLM_ST_SimpleMode, BLM_ST_AdvancedMode, BLM_AoE_SimpleMode)]
		[CustomComboInfo("Cure", "Use Variant Cure when HP is below set threshold", BLM.JobID)]
		BLM_Variant_Cure = 2034,

		#endregion

		#region BLUE MAGE - 70000

		[ReplaceSkill(BLU.MoonFlute)]
		[BlueInactive(BLU.Whistle, BLU.Tingle, BLU.RoseOfDestruction, BLU.MoonFlute, BLU.JKick, BLU.TripleTrident, BLU.Nightbloom, BLU.WingedReprobation, BLU.SeaShanty, BLU.BeingMortal, BLU.ShockStrike, BLU.Surpanakha, BLU.MatraMagic, BLU.PhantomFlurry, BLU.Bristle, BLU.FeatherRain)]
		[ConflictingCombos(BLU_Explode, BLU_TripleTrident, BLU_DoTs)]
		[CustomComboInfo("Moon Flute Combo", "Turns Moon Flute into a full opener\nUse the remaining 2 charges of Winged Reprobation before starting the opener again!\nCan be done with 2.50 spell speed", BLU.JobID, 1)]
		BLU_MoonFluteOpener = 70001,

		[BlueInactive(BLU.BreathOfMagic, BLU.MortalFlame)]
		[ParentCombo(BLU_MoonFluteOpener)]
		[CustomComboInfo("DoT Alternative", "Only have 1 DoT active (Breath of Magic OR Mortal Flame)\nRequires 2.20 spell speed or faster", BLU.JobID)]
		BLU_MoonFluteOpener_DoTOpener = 70002,

		#region Combos

		[BlueInactive(BLU.Whistle, BLU.Offguard, BLU.Tingle, BLU.BasicInstinct, BLU.MoonFlute, BLU.FinalSting)]
		[ReplaceSkill(BLU.FinalSting)]
		[ConflictingCombos(BLU_TripleTrident, BLU_DoTs)]
		[CustomComboInfo("Final Sting Combo", "Whistle > Off-guard > Tingle > [Basic Instinct] > Moon Flute > Swiftcast > Final Sting", BLU.JobID)]
		BLU_Sting = 70011,

		[BlueInactive(BLU.ToadOil, BLU.Bristle, BLU.MoonFlute, BLU.SelfDestruct)]
		[ReplaceSkill(BLU.SelfDestruct)]
		[ConflictingCombos(BLU_MoonFluteOpener, BLU_TripleTrident, BLU_DoTs)]
		[CustomComboInfo("Self-destruct Combo", "Toad Oil > Bristle > Moon Flute > Self-destruct", BLU.JobID)]
		BLU_Explode = 70012,

		[BlueInactive(BLU.Whistle, BLU.Tingle, BLU.TripleTrident)]
		[ReplaceSkill(BLU.TripleTrident)]
		[ConflictingCombos(BLU_MoonFluteOpener, BLU_Sting, BLU_Explode)]
		[CustomComboInfo("Triple Trident Combo", "Whistle > Tingle > Triple Trident", BLU.JobID)]
		BLU_TripleTrident = 70013,

		[BlueInactive(BLU.Bristle, BLU.BreathOfMagic, BLU.MortalFlame)]
		[ReplaceSkill(BLU.BreathOfMagic, BLU.MortalFlame)]
		[ConflictingCombos(BLU_MoonFluteOpener, BLU_Sting, BLU_Explode)]
		[CustomComboInfo("Buffed Breath of Magic & Mortal Flame", "Bristle > Breath of Magic > Bristle > Mortal Flame", BLU.JobID)]
		BLU_DoTs = 70014,

		[BlueInactive(BLU.RamsVoice, BLU.Ultravibration)]
		[ReplaceSkill(BLU.Ultravibration)]
		[CustomComboInfo("Vibe Check", "Ram's Voice > Ultravibration", BLU.JobID)]
		BLU_Ultravibration = 70010,

		[BlueInactive(BLU.PeripheralSynthesis, BLU.MustardBomb)]
		[ReplaceSkill(BLU.MustardBomb)]
		[CustomComboInfo("Bomb Combo", "Peripheral Synthesis > Mustard Bomb", BLU.JobID)]
		BLU_Periph = 70015,

		#endregion

		#region Utility

		[BlueInactive(BLU.GoblinPunch, BLU.MightyGuard, BLU.ToadOil, BLU.Devour, BLU.PeatPelt, BLU.DeepClean)]
		[ReplaceSkill(BLU.GoblinPunch)]
		[CustomComboInfo("Tank Combo", "Mighty Guard, Toad Oil, and Devour Checks, then Peat Pelt and Deep Clean combo", BLU.JobID)]
		BLU_Tanking = 70030,

		[BlueInactive(BLU.GoblinPunch, BLU.BloodDrain)]
		[ReplaceSkill(BLU.GoblinPunch)]
		[CustomComboInfo("Blood Drain over Goblin Punch when below specified MP", "", BLU.JobID)]
		BLU_ManaGain = 70031,

		[BlueInactive(BLU.SonicBoom, BLU.GoblinPunch, BLU.ChocoMeteor)]
		[ReplaceSkill(BLU.SonicBoom, BLU.GoblinPunch, BLU.ChocoMeteor)]
		[CustomComboInfo("Lucid Dreaming", "Adds Lucid Dreaming when MP drops below the slider value", BLU.JobID)]
		BLU_Lucid = 70032,

		[BlueInactive(BLU.AngelWhisper)]
		[ReplaceSkill(BLU.AngelWhisper)]
		[CustomComboInfo("Swiftcast > Angel Whisper", "", BLU.JobID)]
		BLU_Raise = 70033,

		#endregion

		#endregion

		#region BARD - 3000

		[ReplaceSkill(BRD.HeavyShot, BRD.BurstShot)]
		[ConflictingCombos(BRD_ST_SimpleMode)]
		[CustomComboInfo("Heavy Shot into Straight Shot", "Replaces Heavy Shot/Burst Shot with Straight Shot/Refulgent Arrow when procced", BRD.JobID)]
		BRD_StraightShotUpgrade = 3001,

		[ConflictingCombos(BRD_ST_SimpleMode)]
		[ParentCombo(BRD_StraightShotUpgrade)]
		[CustomComboInfo("DoT Maintenance", "Enabling this will make Heavy Shot into Straight Shot refresh your DoTs on your current", BRD.JobID)]
		BRD_DoTMaintainance = 3002,

		[ReplaceSkill(BRD.IronJaws)]
		[ConflictingCombos(BRD_IronJaws_Alternate)]
		[CustomComboInfo("Iron Jaws", "Iron Jaws is replaced with Caustic Bite/Stormbite if one or both are not up.\nAlternates between the two if Iron Jaws isn't available", BRD.JobID)]
		BRD_IronJaws = 3003,

		[ReplaceSkill(BRD.IronJaws)]
		[ConflictingCombos(BRD_IronJaws)]
		[CustomComboInfo("Iron Jaws Alternate", "Iron Jaws is replaced with Caustic Bite/Stormbite if one or both are not up.\nIron Jaws will only show up when debuffs are about to expire", BRD.JobID)]
		BRD_IronJaws_Alternate = 3004,

		[ReplaceSkill(BRD.BurstShot, BRD.QuickNock)]
		[ConflictingCombos(BRD_ST_SimpleMode)]
		[CustomComboInfo("Burst Shot/Quick Nock to Apex Arrow", "Replaces Burst Shot and Quick Nock with Apex Arrow when gauge is full and Blast Arrow when you are Blast Arrow ready", BRD.JobID)]
		BRD_Apex = 3005,

		[ReplaceSkill(BRD.Bloodletter)]
		[ConflictingCombos(BRD_ST_SimpleMode)]
		[CustomComboInfo("Single Target oGCD", "All oGCD's on Bloodletter (+ Songs rotation) depending on their CD", BRD.JobID)]
		BRD_ST_oGCD = 3006,

		[ReplaceSkill(BRD.RainOfDeath)]
		[ConflictingCombos(BRD_AoE_Combo)]
		[CustomComboInfo("AoE oGCD", "All AoE oGCD's on Rain of Death depending on their CD", BRD.JobID)]
		BRD_AoE_oGCD = 3007,

		[ReplaceSkill(BRD.QuickNock, BRD.Ladonsbite)]
		[ConflictingCombos(BRD_AoE_SimpleMode)]
		[CustomComboInfo("AoE Combo", "Replaces Quick Nock/Ladonsbite with Shadowbite when ready", BRD.JobID)]
		BRD_AoE_Combo = 3008,

		[ReplaceSkill(BRD.HeavyShot, BRD.BurstShot)]
		[ConflictingCombos(BRD_StraightShotUpgrade, BRD_DoTMaintainance, BRD_Apex, BRD_ST_oGCD, BRD_IronJawsApex)]
		[CustomComboInfo("Simple Bard", "Adds every single target ability to one button,\nIf there are DoTs on target, Simple Bard will try to maintain their uptime", BRD.JobID)]
		BRD_ST_SimpleMode = 3009,

		[ParentCombo(BRD_ST_SimpleMode)]
		[CustomComboInfo("Simple Bard DoTs", "This will make Simple Bard apply DoTs if none are present on the target", BRD.JobID)]
		BRD_Simple_DoT = 3010,

		[ParentCombo(BRD_ST_SimpleMode)]
		[CustomComboInfo("Simple Bard Songs", "This adds the Bard's Songs to the Simple Bard", BRD.JobID)]
		BRD_Simple_Song = 3011,

		[ParentCombo(BRD_AoE_oGCD)]
		[CustomComboInfo("Songs", "Adds Songs onto AoE oGCD", BRD.JobID)]
		BRD_oGCDSongs = 3012,

		[CustomComboInfo("Bard Buffs", "Adds Raging Strikes and Battle Voice onto Barrage", BRD.JobID)]
		BRD_Buffs = 3013,

		[ReplaceSkill(BRD.WanderersMinuet)]
		[CustomComboInfo("One Button Songs", "Add Mage's Ballad and Army's Paeon to Wanderer's Minuet depending on cooldowns", BRD.JobID)]
		BRD_OneButtonSongs = 3014,

		[ReplaceSkill(BRD.QuickNock, BRD.Ladonsbite)]
		[CustomComboInfo("Simple AoE Bard", "Weaves oGCDs onto Quick Nock/Ladonsbite", BRD.JobID)]
		BRD_AoE_SimpleMode = 3015,

		[ParentCombo(BRD_AoE_SimpleMode)]
		[CustomComboInfo("Simple AoE Bard Song", "Weave Songs on the Simple AoE", BRD.JobID)]
		BRD_AoE_Simple_Songs = 3016,

		[ParentCombo(BRD_ST_SimpleMode)]
		[CustomComboInfo("Simple Buffs", "Adds buffs onto the Simple Bard", BRD.JobID)]
		BRD_Simple_Buffs = 3017,

		[ParentCombo(BRD_Simple_Buffs)]
		[CustomComboInfo("Simple Buffs - Radiant", "Adds Radiant Finale to the Simple Buffs", BRD.JobID)]
		BRD_Simple_BuffsRadiant = 3018,

		[ParentCombo(BRD_ST_SimpleMode)]
		[CustomComboInfo("Simple No Waste", "Adds enemy health checking on mobs for buffs, DoTs and Songs.\nThey will not be reapplied if less than specified", BRD.JobID)]
		BRD_Simple_NoWaste = 3019,

		[ParentCombo(BRD_ST_SimpleMode)]
		[CustomComboInfo("Simple Interrupt", "Uses interrupt during the rotation if applicable", BRD.JobID)]
		BRD_Simple_Interrupt = 3020,

		[CustomComboInfo("Disable Apex Arrow", "Removes Apex Arrow from Simple Bard and AoE", BRD.JobID)]
		BRD_RemoveApexArrow = 3021,

		[ParentCombo(BRD_ST_SimpleMode)]
		[CustomComboInfo("Simple Pooling", "Pools Bloodletter charges to allow for optimum burst phases", BRD.JobID)]
		BRD_Simple_Pooling = 3023,

		[ConflictingCombos(BRD_ST_SimpleMode)]
		[ParentCombo(BRD_IronJaws)]
		[CustomComboInfo("Iron Jaws Apex", "Adds Apex and Blast Arrow to Iron Jaws when available", BRD.JobID)]
		BRD_IronJawsApex = 3024,

		[ParentCombo(BRD_ST_SimpleMode)]
		[CustomComboInfo("Simple Raging Jaws", "Enable the snapshotting of DoTs, within the remaining time of Raging Strikes below:", BRD.JobID)]
		BRD_Simple_RagingJaws = 3025,

		[ParentCombo(BRD_ST_SimpleMode)]
		[CustomComboInfo("Second Wind", "Uses Second Wind when below set HP percentage", BRD.JobID)]
		BRD_ST_SecondWind = 3028,

		[ParentCombo(BRD_AoE_SimpleMode)]
		[CustomComboInfo("Second Wind", "Uses Second Wind when below set HP percentage", BRD.JobID)]
		BRD_AoE_SecondWind = 3029,

		[Variant]
		[VariantParent(BRD_ST_SimpleMode, BRD_AoE_SimpleMode)]
		[CustomComboInfo("Rampart", "Use Variant Rampart on cooldown", BRD.JobID)]
		BRD_Variant_Rampart = 3030,

		[Variant]
		[VariantParent(BRD_ST_SimpleMode, BRD_AoE_SimpleMode)]
		[CustomComboInfo("Cure", "Use Variant Cure when HP is below set threshold", BRD.JobID)]
		BRD_Variant_Cure = 3031,

		[ParentCombo(BRD_AoE_Simple_Songs)]
		[CustomComboInfo("Simple AoE Buffs", "Adds buffs onto the Simple AoE Bard", BRD.JobID)]
		BRD_AoE_Simple_Buffs = 3032,

		[ParentCombo(BRD_AoE_SimpleMode)]
		[CustomComboInfo("Simple AoE No Waste", "Adds enemy health checking on targetted mob for songs.\nThey will not be reapplied if less than specified", BRD.JobID)]
		BRD_AoE_Simple_NoWaste = 3033,
		#endregion

		#region DANCER - 4000

		[ReplaceSkill(DNC.Cascade)]
		[ConflictingCombos(DNC_ST_SimpleMode, DNC_AoE_SimpleMode)]
		[CustomComboInfo("Single Target Multibutton", "Single target combo with Fan Dances and Esprit use", DNC.JobID)]
		DNC_ST_MultiButton = 4000,

		[ParentCombo(DNC_ST_MultiButton)]
		[CustomComboInfo("Esprit Overcap", "Adds Saber Dance above the set Esprit threshold", DNC.JobID)]
		DNC_ST_EspritOvercap = 4001,

		[ParentCombo(DNC_ST_MultiButton)]
		[CustomComboInfo("Fan Dance Overcap Protection", "Adds Fan Dance 1 when Fourfold Feathers are full", DNC.JobID)]
		DNC_ST_FanDanceOvercap = 4003,

		[ParentCombo(DNC_ST_MultiButton)]
		[CustomComboInfo("Fan Dance", "Adds Fan Dance 3/4 when available", DNC.JobID)]
		DNC_ST_FanDance34 = 4004,

		[ReplaceSkill(DNC.Windmill)]
		[ConflictingCombos(DNC_ST_SimpleMode, DNC_AoE_SimpleMode)]
		[CustomComboInfo("AoE Multibutton", "AoE combo with Fan Dances and Esprit use", DNC.JobID)]
		DNC_AoE_MultiButton = 4010,

		[ParentCombo(DNC_AoE_MultiButton)]
		[CustomComboInfo("Esprit Overcap", "Adds Saber Dance above the set Esprit threshold", DNC.JobID)]
		DNC_AoE_EspritOvercap = 4011,

		[ParentCombo(DNC_AoE_MultiButton)]
		[CustomComboInfo("AoE Fan Dance Overcap Protection", "Adds Fan Dance 2 when Fourfold Feathers are full", DNC.JobID)]
		DNC_AoE_FanDanceOvercap = 4013,

		[ParentCombo(DNC_AoE_MultiButton)]
		[CustomComboInfo("AoE Fan Dance", "Adds Fan Dance 3/4 when available", DNC.JobID)]
		DNC_AoE_FanDance34 = 4014,

		[ConflictingCombos(DNC_ST_SimpleMode, DNC_AoE_SimpleMode)]
		[CustomComboInfo("Dances", "Features ands involving Standard Step and Technical Step.\nCollapsing this category does NOT disable thes inside", DNC.JobID)]
		DNC_Dance_Menu = 4020,

		[ParentCombo(DNC_Dance_Menu)]
		[ConflictingCombos(DNC_DanceStepCombo, DNC_ST_SimpleMode, DNC_AoE_SimpleMode)]
		[CustomComboInfo("Custom Dance Step",
		"Change custom actions into dance steps while dancing" +
		"\nThis helps ensure you can still dance with combos on, without using auto dance" +
		"\nYou can change the respective actions by inputting action IDs below for each dance step" +
		"\nThe defaults are Cascade, Flourish, Fan Dance and Fan Dance II. If set to 0, they will reset to these actions" +
		"\nYou can get Action IDs with Garland Tools by searching for the action and clicking the cog", DNC.JobID)]
		DNC_DanceComboReplacer = 4025,

		[ConflictingCombos(DNC_ST_SimpleMode, DNC_AoE_SimpleMode)]
		[CustomComboInfo("Flourishings", "Features ands involving Fourfold Feathers and Flourish" +
		"\nCollapsing this category does NOT disable thes inside", DNC.JobID)]
		DNC_FlourishingFeatures_Menu = 4030,

		[ReplaceSkill(DNC.Flourish)]
		[ParentCombo(DNC_FlourishingFeatures_Menu)]
		[ConflictingCombos(DNC_ST_SimpleMode, DNC_AoE_SimpleMode)]
		[CustomComboInfo("Flourishing Fan Dance", "Replace Flourish with Fan Dance 3 & 4 during weave-windows, when Flourish is on cooldown", DNC.JobID)]
		DNC_FlourishingFanDances = 4032,

		[ParentCombo(DNC_FlourishingFeatures_Menu)]
		[ConflictingCombos(DNC_ST_SimpleMode, DNC_AoE_SimpleMode)]
		[CustomComboInfo("Fan Dance Combo", "Options for Fan Dance combos" +
		"\nFan Dance 3 takes priority over Fan Dance 4", DNC.JobID)]
		DNC_FanDanceCombos = 4033,

		[ReplaceSkill(DNC.FanDance1)]
		[ParentCombo(DNC_FanDanceCombos)]
		[CustomComboInfo("Fan Dance 1 -> 3", "Changes Fan Dance 1 to Fan Dance 3 when available", DNC.JobID)]
		DNC_FanDance_1to3_Combo = 4034,

		[ReplaceSkill(DNC.FanDance1)]
		[ParentCombo(DNC_FanDanceCombos)]
		[CustomComboInfo("Fan Dance 1 -> 4", "Changes Fan Dance 1 to Fan Dance 4 when available", DNC.JobID)]
		DNC_FanDance_1to4_Combo = 4035,

		[ReplaceSkill(DNC.FanDance2)]
		[ParentCombo(DNC_FanDanceCombos)]
		[CustomComboInfo("Fan Dance 2 -> 3", "Changes Fan Dance 2 to Fan Dance 3 when available", DNC.JobID)]
		DNC_FanDance_2to3_Combo = 4036,

		[ReplaceSkill(DNC.FanDance2)]
		[ParentCombo(DNC_FanDanceCombos)]
		[CustomComboInfo("Fan Dance 2 -> 4", "Changes Fan Dance 2 to Fan Dance 4 when available", DNC.JobID)]
		DNC_FanDance_2to4_Combo = 4037,

		[ReplaceSkill(DNC.Devilment)]
		[ConflictingCombos(DNC_ST_SimpleMode, DNC_AoE_SimpleMode)]
		[CustomComboInfo("Devilment to Starfall", "Change Devilment into Starfall Dance after use", DNC.JobID)]
		DNC_Starfall_Devilment = 4038,

		[ReplaceSkill(DNC.StandardStep, DNC.TechnicalStep)]
		[ConflictingCombos(DNC_DanceComboReplacer)]
		[CustomComboInfo("Dance Step Combo", "Change Standard Step and Technical Step into each dance step, while dancing" +
		"\nWorks with Simple Dancer and Simple Dancer AoE", DNC.JobID)]
		DNC_DanceStepCombo = 4039,

		[ReplaceSkill(DNC.Cascade)]
		[ConflictingCombos(DNC_ST_MultiButton, DNC_AoE_MultiButton, DNC_DanceComboReplacer, DNC_FlourishingFeatures_Menu, DNC_Starfall_Devilment)]
		[CustomComboInfo("Simple Dancer (Single Target)", "Single button, single target. Includes songs, flourishes and overprotections", DNC.JobID)]
		DNC_ST_SimpleMode = 4050,

		[ParentCombo(DNC_ST_SimpleMode)]
		[CustomComboInfo("Simple Interrupt", "Includes an interrupt in the rotation (if applicable to your current target)", DNC.JobID, 0)]
		DNC_ST_Simple_Interrupt = 4051,

		[ParentCombo(DNC_ST_SimpleMode)]
		[ConflictingCombos(DNC_ST_Simple_StandardFill)]
		[CustomComboInfo("Simple Standard Dance", "Includes Standard Step (and all steps) in the rotation", DNC.JobID, 1)]
		DNC_ST_Simple_SS = 4052,

		[ParentCombo(DNC_ST_Simple_SS)]
		[ConflictingCombos(DNC_ST_Simple_StandardFill)]
		[CustomComboInfo("Standard Dance Opener", "Starts Standard Step (and steps) before combat", DNC.JobID)]
		DNC_ST_Simple_SS_Prepull = 4090,

		[ParentCombo(DNC_ST_SimpleMode)]
		[ConflictingCombos(DNC_ST_Simple_SS)]
		[CustomComboInfo("Simple Standard Fill", "Adds ONLY Standard dance steps and Standard Finish to the rotation" +
			"\nStandard Step itself must be initiated manually when using this", DNC.JobID, 2)]
		DNC_ST_Simple_StandardFill = 4061,

		[ParentCombo(DNC_ST_SimpleMode)]
		[CustomComboInfo("Simple Peloton Opener", "Uses Peloton when you are out of combat, do not already have the Peloton buff and are performing Standard Step with greater than 5s remaining of your dance" +
			"\nWill not override Dance Step Combo", DNC.JobID, 3)]
		DNC_ST_Simple_Peloton = 4062,

		[ParentCombo(DNC_ST_SimpleMode)]
		[ConflictingCombos(DNC_ST_Simple_TechFill)]
		[CustomComboInfo("Simple Technical Dance", "Includes Technical Step, all dance steps and Technical Finish in the rotation", DNC.JobID, 4)]
		DNC_ST_Simple_TS = 4053,

		[ParentCombo(DNC_ST_SimpleMode)]
		[ConflictingCombos(DNC_ST_Simple_TS)]
		[CustomComboInfo("Simple Tech Fill", "Adds ONLY Technical dance steps and Technical Finish to the rotation" +
													"\nTechnical Step itself must be initiated manually when using this", DNC.JobID, 5)]
		DNC_ST_Simple_TechFill = 4054,

		[ParentCombo(DNC_ST_SimpleMode)]
		[CustomComboInfo("Simple Devilment", "Includes Devilment in the rotation" +
													"\nWill activate only during Technical Finish if you're Lv70 or above" +
													"\nWill be used on cooldown below Lv70", DNC.JobID, 6)]
		DNC_ST_Simple_Devilment = 4055,

		[ParentCombo(DNC_ST_SimpleMode)]
		[CustomComboInfo("Simple Flourish", "Includes Flourish in the rotation", DNC.JobID, 7)]
		DNC_ST_Simple_Flourish = 4056,

		[ParentCombo(DNC_ST_SimpleMode)]
		[CustomComboInfo("Simple Feathers", "Expends a feather in the next available weave window when capped" +
												   "\nWeaves feathers where possible during Technical Finish" +
												   "\nWeaves feathers outside of burst when target is below set HP percentage (Set to 0 to disable)" +
												   "\nWeaves feathers whenever available when under Lv.70", DNC.JobID, 8)]
		DNC_ST_Simple_Feathers = 4057,

		[ParentCombo(DNC_ST_SimpleMode)]
		[CustomComboInfo("Simple Improvisation", "Includes Improvisation in the rotation when available" +
			"\nWill not use while under Technical Finish", DNC.JobID, 9)]
		DNC_ST_Simple_Improvisation = 4060,

		[ParentCombo(DNC_ST_SimpleMode)]
		[CustomComboInfo("Simple Tillana", "Includes Tillana in the rotation", DNC.JobID, 10)]
		DNC_ST_Simple_Tillana = 4092,

		[ParentCombo(DNC_ST_SimpleMode)]
		[CustomComboInfo("Simple Saber Dance", "Includes Saber Dance in the rotation when at or over the Esprit threshold", DNC.JobID, 11)]
		DNC_ST_Simple_SaberDance = 4063,

		[ParentCombo(DNC_ST_Simple_SaberDance)]
		[CustomComboInfo("Simple Dance of the Dawn", "Includes Dance of the Dawn in the rotation after Saber Dance and when over the threshold, or in the final seconds of Dance of the Dawn ready", DNC.JobID)]
		DNC_ST_Simple_DawnDance = 4064,

		[ParentCombo(DNC_ST_SimpleMode)]
		[CustomComboInfo("Simple Last Dance", "Includes Last Dance in the rotation", DNC.JobID, 12)]
		DNC_ST_Simple_LD = 4093,

		[ParentCombo(DNC_ST_SimpleMode)]
		[CustomComboInfo("Simple Panic Heals", "Includes Curing Waltz and Second Wind in the rotation when available and your HP is below the set percentages", DNC.JobID, 13)]
		DNC_ST_Simple_PanicHeals = 4059,

		[ReplaceSkill(DNC.Windmill)]
		[ConflictingCombos(DNC_ST_MultiButton, DNC_AoE_MultiButton, DNC_DanceComboReplacer, DNC_FlourishingFeatures_Menu, DNC_Starfall_Devilment)]
		[CustomComboInfo("Simple Dancer (AoE)", "Single button, AoE. Includes songs, flourishes and overprotections" +
			"\nConflicts with all other non-simple toggles, except 'Dance Step Combo'", DNC.JobID)]
		DNC_AoE_SimpleMode = 4070,

		[ParentCombo(DNC_AoE_SimpleMode)]
		[CustomComboInfo("Simple AoE Interrupt", "Includes an interrupt in the AoE rotation (if your current target can be interrupted)", DNC.JobID, 0)]
		DNC_AoE_Simple_Interrupt = 4071,

		[ParentCombo(DNC_AoE_SimpleMode)]
		[ConflictingCombos(DNC_AoE_Simple_StandardFill)]
		[CustomComboInfo("Simple AoE Standard Dance", "Includes Standard Step (and all steps) in the AoE rotation", DNC.JobID, 1)]
		DNC_AoE_Simple_SS = 4072,

		[ParentCombo(DNC_AoE_SimpleMode)]
		[ConflictingCombos(DNC_AoE_Simple_SS)]
		[CustomComboInfo("Simple AoE Standard Fill", "Adds ONLY Standard dance steps and Standard Finish to the AoE rotation" +
		"\nStandard Step itself must be initiated manually when using this", DNC.JobID, 2)]
		DNC_AoE_Simple_StandardFill = 4081,

		[ParentCombo(DNC_AoE_SimpleMode)]
		[ConflictingCombos(DNC_AoE_Simple_TechFill)]
		[CustomComboInfo("Simple AoE Technical Dance", "Includes Technical Step, all dance steps and Technical Finish in the AoE rotation", DNC.JobID, 3)]
		DNC_AoE_Simple_TS = 4073,

		[ParentCombo(DNC_AoE_SimpleMode)]
		[ConflictingCombos(DNC_AoE_Simple_TS)]
		[CustomComboInfo("Simple AoE Tech Fill", "Adds ONLY Technical dance steps and Technical Finish to the AoE rotation" +
		"\nTechnical Step itself must be initiated manually when using this", DNC.JobID, 4)]
		DNC_AoE_Simple_TechFill = 4074,

		[ParentCombo(DNC_AoE_SimpleMode)]
		[CustomComboInfo("Simple AoE Tech Devilment", "Includes Devilment in the AoE rotation" +
			"\nWill activate only during Technical Finish if you're Lv70 or above" +
			"\nWill be used on cooldown below Lv70", DNC.JobID, 5)]
		DNC_AoE_Simple_Devilment = 4075,

		[ParentCombo(DNC_AoE_SimpleMode)]
		[CustomComboInfo("Simple AoE Flourish", "Includes Flourish in the AoE rotation", DNC.JobID, 6)]
		DNC_AoE_Simple_Flourish = 4076,

		[ParentCombo(DNC_AoE_SimpleMode)]
		[CustomComboInfo("Simple AoE Feathers", "Expends a feather in the next available weave window when capped" +
	   "\nWeaves feathers where possible during Technical Finish" +
	   "\nWeaves feathers whenever available when under Lv.70", DNC.JobID, 7)]
		DNC_AoE_Simple_Feathers = 4077,

		[ParentCombo(DNC_AoE_SimpleMode)]
		[CustomComboInfo("Simple AoE Improvisation", "Includes Improvisation in the AoE rotation when available" +
		"\nWill not use while under Technical Finish", DNC.JobID, 8)]
		DNC_AoE_Simple_Improvisation = 4080,

		[ParentCombo(DNC_AoE_SimpleMode)]
		[CustomComboInfo("Simple Tillana", "Includes Tillana in the rotation", DNC.JobID, 9)]
		DNC_AoE_Simple_Tillana = 4101,

		[ParentCombo(DNC_AoE_SimpleMode)]
		[CustomComboInfo("Simple AoE Saber Dance", "Includes Saber Dance in the AoE rotation when at or over the Esprit threshold", DNC.JobID, 10)]
		DNC_AoE_Simple_SaberDance = 4082,

		[ParentCombo(DNC_AoE_Simple_SaberDance)]
		[CustomComboInfo("Simple AoE Dance of the Dawn", "Includes Dance of the Dawn in the AoE rotation after Saber Dance and when over the threshold, or in the final seconds of Dance of the Dawn ready", DNC.JobID)]
		DNC_AoE_Simple_DawnDance = 4085,

		[ParentCombo(DNC_AoE_SimpleMode)]
		[CustomComboInfo("Simple Last Dance", "Includes Last Dance in the rotation", DNC.JobID, 11)]
		DNC_AoE_Simple_LD = 4102,

		[ParentCombo(DNC_AoE_SimpleMode)]
		[CustomComboInfo("Simple AoE Panic Heals", "Includes Curing Waltz and Second Wind in the AoE rotation when available and your HP is below the set percentages", DNC.JobID, 12)]
		DNC_AoE_Simple_PanicHeals = 4079,

		[Variant]
		[VariantParent(DNC_ST_SimpleMode, DNC_AoE_SimpleMode)]
		[CustomComboInfo("Rampart", "Use Variant Rampart on cooldown", DNC.JobID)]
		DNC_Variant_Rampart = 4083,

		[Variant]
		[VariantParent(DNC_ST_SimpleMode, DNC_AoE_SimpleMode)]
		[CustomComboInfo("Cure", "Use Variant Cure when HP is below set threshold", DNC.JobID)]
		DNC_Variant_Cure = 4084,

		#endregion

		#region DARK KNIGHT - 5000

		[ReplaceSkill(DRK.Souleater)]
		[CustomComboInfo("Souleater Combo", "Replace Souleater with its combo chain", DRK.JobID)]
		DRK_ST_Combo = 5001,

		[ParentCombo(DRK_ST_Combo)]
		[CustomComboInfo("Delirium/Blood Weapon", "Adds Delirium/Blood Weapon to main combo on cooldown and when Darkside is active", DRK.JobID)]
		DRK_ST_Delirium = 5002,

		[ParentCombo(DRK_ST_Delirium)]
		[CustomComboInfo("Torcleaver", "Adds the Torcleaver chain when Delirium is activated", DRK.JobID)]
		DRK_ST_Delirium_Chain = 5003,

		[ParentCombo(DRK_ST_Combo)]
		[CustomComboInfo("oGCDs", "Collection of abilities to add to the main combo. All of these require Darkside to be active", DRK.JobID)]
		DRK_ST_CDs = 5004,

		[ParentCombo(DRK_ST_CDs)]
		[CustomComboInfo("Carve and Spit", "", DRK.JobID)]
		DRK_ST_CDs_CarveAndSpit = 5005,
		[ParentCombo(DRK_ST_CDs)]
		[CustomComboInfo("Salted Earth", "Will also use Salt and Darkness", DRK.JobID)]
		DRK_ST_CDs_SaltedEarth = 5006,

		[ParentCombo(DRK_ST_CDs)]
		[CustomComboInfo("Living Shadow", "", DRK.JobID)]
		DRK_ST_CDs_LivingShadow = 5007,

		[ParentCombo(DRK_ST_CDs_LivingShadow)]
		[CustomComboInfo("Disesteem", "", DRK.JobID)]
		DRK_ST_CDs_Disesteem = 5008,

		[ParentCombo(DRK_ST_CDs)]
		[CustomComboInfo("Shadowbringer", "Uses on cooldown", DRK.JobID)]
		DRK_ST_CDs_Shadowbringer = 5009,

		[ParentCombo(DRK_ST_CDs_Shadowbringer)]
		[CustomComboInfo("Shadowbringer Burst", "Pools Shadowbringer to use during burst windows", DRK.JobID)]
		DRK_ST_CDs_ShadowbringerBurst = 5010,

		[ParentCombo(DRK_ST_Combo)]
		[CustomComboInfo("Blood Gauge Overcap Protection", "Adds Bloodspiller when at or above chosen amount", DRK.JobID)]
		DRK_ST_BloodOvercap = 5011,

		[ParentCombo(DRK_ST_Combo)]
		[CustomComboInfo("Edge of Shadow Overcap Protection", "Uses Edge of Shadow if you are above chosen amount of MP, Darkside has chosen amount of time remaining, or if you have Dark Arts", DRK.JobID)]
		DRK_ST_ManaOvercap = 5012,

		[ParentCombo(DRK_ST_ManaOvercap)]
		[CustomComboInfo("Edge of Shadow Burst", "Pools Edge of Shadow for burst windows. Otherwise, uses it until chosen MP limit is reached", DRK.JobID)]
		DRK_ST_ManaSpenderPooling = 5013,

		[ParentCombo(DRK_ST_Combo)]
		[CustomComboInfo("Unmend Uptime", "Use Unmend when out of melee range", DRK.JobID)]
		DRK_ST_RangedUptime = 5014,

		[ReplaceSkill(DRK.StalwartSoul)]
		[CustomComboInfo("Stalwart Soul Combo", "Replace Stalwart Soul with its combo chain", DRK.JobID)]
		DRK_AoE_Combo = 5100,

		[ParentCombo(DRK_AoE_Combo)]
		[CustomComboInfo("Delirium/Blood Weapon", "Adds Delirium/Blood Weapon to AoE combo on cooldown and when Darkside is active", DRK.JobID)]
		DRK_AoE_Delirium = 5101,

		[ParentCombo(DRK_AoE_Delirium)]
		[CustomComboInfo("Impalement", "Adds all Impalement uses when Delirium is activated", DRK.JobID)]
		DRK_AoE_Delirium_Chain = 5102,

		[ParentCombo(DRK_AoE_Combo)]
		[CustomComboInfo("oGCDs", "Collection of abilities to add to the AoE combo. All of these require Darkside to be active", DRK.JobID)]
		DRK_AoE_CDs = 5103,

		[ParentCombo(DRK_AoE_CDs)]
		[CustomComboInfo("Abyssal Drain", "Use Abyssal Drain when you fall below the chosen HP%", DRK.JobID)]
		DRK_AoE_CDs_AbyssalDrain = 5104,

		[ParentCombo(DRK_AoE_CDs)]
		[CustomComboInfo("Salted Earth", "Will also use Salt and Darkness", DRK.JobID)]
		DRK_AoE_CDs_SaltedEarth = 5105,

		[ParentCombo(DRK_AoE_CDs)]
		[CustomComboInfo("Living Shadow", "", DRK.JobID)]
		DRK_AoE_CDs_LivingShadow = 5106,

		[ParentCombo(DRK_AoE_CDs_LivingShadow)]
		[CustomComboInfo("Disesteem", "", DRK.JobID)]
		DRK_AoE_CDs_Disesteem = 5107,

		[ParentCombo(DRK_AoE_CDs)]
		[CustomComboInfo("Shadowbringer", "", DRK.JobID)]
		DRK_AoE_CDs_Shadowbringer = 5108,

		[ParentCombo(DRK_AoE_Combo)]
		[CustomComboInfo("Blood Gauge Overcap Protection", "Adds Quietus when at or above chosen amount", DRK.JobID)]
		DRK_AoE_BloodOvercap = 5109,

		[ParentCombo(DRK_AoE_Combo)]
		[CustomComboInfo("Flood of Shadow Overcap Protection", "Uses Flood of Shadow if you are above chosen amount of MP, Darkside has chosen amount of time remaining, or if you have Dark Arts", DRK.JobID)]
		DRK_AoE_ManaOvercap = 5110,

		[ParentCombo(DRK_AoE_Combo)]
		[CustomComboInfo("Flood of Shadow Uptime", "Use Flood of Shadow when out of melee range", DRK.JobID)]
		DRK_AoE_FloodUptime = 5111,

		[Variant]
		[VariantParent(DRK_ST_Combo, DRK_AoE_Combo)]
		[CustomComboInfo("Spirit Dart", "Use Variant Spirit Dart whenever the debuff is not present or less than 3s", DRK.JobID)]
		DRK_Variant_SpiritDart = 5200,

		[Variant]
		[VariantParent(DRK_ST_Combo, DRK_AoE_Combo)]
		[CustomComboInfo("Cure", "Use Variant Cure when HP is below set threshold", DRK.JobID)]
		DRK_Variant_Cure = 5201,

		[Variant]
		[VariantParent(DRK_ST_Combo, DRK_AoE_Combo)]
		[CustomComboInfo("Ultimatum", "Use Variant Ultimatum on cooldown", DRK.JobID)]
		DRK_Variant_Ultimatum = 5202,

		#endregion

		#region DRAGOON - 6000

		#region Single Target

		[ReplaceSkill(DRG.TrueThrust)]
		[CustomComboInfo("Single Target", "", DRG.JobID)]
		DRG_ST_AdvancedMode = 6100,

		#endregion

		#region AoE DPS

		[ReplaceSkill(DRG.DoomSpike)]
		[CustomComboInfo("AoE", "", DRG.JobID)]
		DRG_AOE_AdvancedMode = 6201,

		#endregion

		#region Utility

		#endregion

		#region Variant

		[Variant]
		[VariantParent(DRG_ST_AdvancedMode, DRG_AOE_AdvancedMode)]
		[CustomComboInfo("Cure", "Use Variant Cure when HP is below set threshold", DRG.JobID)]
		DRG_Variant_Cure = 6302,

		[Variant]
		[VariantParent(DRG_ST_AdvancedMode, DRG_AOE_AdvancedMode)]
		[CustomComboInfo("Rampart", "Use Variant Rampart on cooldown", DRG.JobID)]
		DRG_Variant_Rampart = 6303,

		#endregion

		#endregion

		#region GUNBREAKER - 7000

		#region Single Target

		[ReplaceSkill(GNB.KeenEdge)]
		[CustomComboInfo("Single Target", "", GNB.JobID)]
		GNB_ST_MainCombo = 7001,

		[ParentCombo(GNB_ST_MainCombo)]
		[CustomComboInfo("Burst Strike", "", GNB.JobID)]
		GNB_ST_Burst = 7002,

		[ParentCombo(GNB_ST_MainCombo)]
		[CustomComboInfo("Gnashing Fang", "", GNB.JobID)]
		GNB_ST_Gnashing = 7003,

		[ParentCombo(GNB_ST_MainCombo)]
		[CustomComboInfo("Reign Combo", "", GNB.JobID)]
		GNB_ST_Reign = 7004,

		#endregion

		#region AoE

		[ReplaceSkill(GNB.DemonSlice)]
		[CustomComboInfo("AoE", "", GNB.JobID)]
		GNB_AoE_MainCombo = 7300,

		[ParentCombo(GNB_AoE_MainCombo)]
		[CustomComboInfo("Fated Circle", "", GNB.JobID)]
		GNB_AOE_Overcap = 7307,

		#endregion

		#region Utility

		[CustomComboInfo("Aurora Protection", "", GNB.JobID)]
		GNB_AuroraProtection = 7700,

		#endregion

		#region Variant

		[Variant]
		[CustomComboInfo("Spirit Dart", "", GNB.JobID)]
		GNB_Variant_SpiritDart = 7033,

		[Variant]
		[CustomComboInfo("Cure", "", GNB.JobID)]
		GNB_Variant_Cure = 7034,

		[Variant]
		[CustomComboInfo("Ultimatum", "", GNB.JobID)]
		GNB_Variant_Ultimatum = 7035,

		#endregion

		#endregion

		#region MACHINIST - 8000

		[ReplaceSkill(MCH.SplitShot, MCH.HeatedSplitShot)]
		[ConflictingCombos(MCH_ST_AdvancedMode)]
		[CustomComboInfo("Simple Mode - Single Target", "Replaces Split Shot with a one-button full single target rotation.\nThis is ideal for newcomers to the job", MCH.JobID)]
		MCH_ST_SimpleMode = 8001,

		[ReplaceSkill(MCH.SplitShot, MCH.HeatedSplitShot)]
		[ConflictingCombos(MCH_ST_SimpleMode)]
		[CustomComboInfo("Advanced Mode - Single Target", "Replaces Split Shot with a one-button full single target rotation.\nTheses are ideal if you want to customize the rotation", MCH.JobID)]
		MCH_ST_AdvancedMode = 8100,

		[ParentCombo(MCH_ST_AdvancedMode)]
		[ConflictingCombos(MCH_GaussRoundRicochet, MCH_Heatblast_GaussRound)]
		[CustomComboInfo("Level 100 Opener", "Uses the Balance opener", MCH.JobID)]
		MCH_ST_Adv_Opener = 8101,

		[ParentCombo(MCH_ST_AdvancedMode)]
		[CustomComboInfo("Hot Shot / Air Anchor", "Adds Hot Shot/Air Anchor to the rotation", MCH.JobID)]
		MCH_ST_Adv_AirAnchor = 8102,

		[ParentCombo(MCH_ST_AdvancedMode)]
		[CustomComboInfo("Reassemble", "Adds Reassemble to the rotation.\nWill be used priority based.\nOrder from highest to lowest priority :\nExcavator - Chainsaw - Air Anchor - Drill - Clean Shot", MCH.JobID)]
		MCH_ST_Adv_Reassemble = 8103,

		[ParentCombo(MCH_ST_AdvancedMode)]
		[ConflictingCombos(MCH_GaussRoundRicochet, MCH_Heatblast_GaussRound)]
		[CustomComboInfo("Gauss Round / Ricochet \nDouble Check / Checkmate", "Adds Gauss Round and Ricochet or Double Check and Checkmate to the rotation. Will prevent overcapping", MCH.JobID)]
		MCH_ST_Adv_GaussRicochet = 8104,

		[ParentCombo(MCH_ST_AdvancedMode)]
		[CustomComboInfo("Hypercharge", "Adds Hypercharge to the rotation", MCH.JobID)]
		MCH_ST_Adv_Hypercharge = 8105,

		[ParentCombo(MCH_ST_AdvancedMode)]
		[CustomComboInfo("Heat Blast / Blazing Shot", "Adds Heat Blast or Blazing Shot to the rotation", MCH.JobID)]
		MCH_ST_Adv_Heatblast = 8106,

		[ParentCombo(MCH_ST_AdvancedMode)]
		[CustomComboInfo("Rook Autoturret/Automaton Queen", "Adds Rook Autoturret or Automaton Queen to the rotation", MCH.JobID)]
		MCH_Adv_TurretQueen = 8107,

		[ParentCombo(MCH_ST_AdvancedMode)]
		[CustomComboInfo("Wildfire", "Adds Wildfire to the rotation", MCH.JobID)]
		MCH_ST_Adv_WildFire = 8108,

		[ParentCombo(MCH_ST_AdvancedMode)]
		[CustomComboInfo("Drill", "Adds Drill to the rotation", MCH.JobID)]
		MCH_ST_Adv_Drill = 8109,

		[ParentCombo(MCH_ST_AdvancedMode)]
		[CustomComboInfo("Barrel Stabilizer", "Adds Barrel Stabilizer to the rotation", MCH.JobID)]
		MCH_ST_Adv_Stabilizer = 8110,

		[ParentCombo(MCH_ST_AdvancedMode)]
		[CustomComboInfo("Full Metal Field", "Adds Full Metal Field to the rotation", MCH.JobID)]
		MCH_ST_Adv_Stabilizer_FullMetalField = 8111,

		[ParentCombo(MCH_ST_AdvancedMode)]
		[CustomComboInfo("Chain Saw", "Adds Chain Saw to the rotation", MCH.JobID)]
		MCH_ST_Adv_Chainsaw = 8112,

		[ParentCombo(MCH_ST_AdvancedMode)]
		[CustomComboInfo("Excavator", "Adds Excavator to the rotation", MCH.JobID)]
		MCH_ST_Adv_Excavator = 8116,

		[ParentCombo(MCH_ST_AdvancedMode)]
		[CustomComboInfo("Rook / Queen Overdrive", "Adds Rook or Queen Overdrive to the rotation", MCH.JobID)]
		MCH_ST_Adv_QueenOverdrive = 8115,

		[ParentCombo(MCH_ST_AdvancedMode)]
		[CustomComboInfo("Head Graze", "Uses Head Graze to interrupt during the rotation, where applicable", MCH.JobID)]
		MCH_ST_Adv_Interrupt = 8113,

		[ParentCombo(MCH_ST_AdvancedMode)]
		[CustomComboInfo("Second Wind", "Use Second Wind when below the set HP percentage", MCH.JobID)]
		MCH_ST_Adv_SecondWind = 8114,

		[ReplaceSkill(MCH.SpreadShot)]
		[ConflictingCombos(MCH_AoE_AdvancedMode)]
		[CustomComboInfo("Simple Mode - AoE", "Replaces Spread Shot with a one-button full single target rotation.\nThis is ideal for newcomers to the job", MCH.JobID)]
		MCH_AoE_SimpleMode = 8200,

		[ReplaceSkill(MCH.SpreadShot, MCH.Scattergun)]
		[ConflictingCombos(MCH_AoE_SimpleMode)]
		[CustomComboInfo("Advanced Mode - AoE", "Replaces Spread Shot with a one-button full single target rotation.\nTheses are ideal if you want to customize the rotation", MCH.JobID)]
		MCH_AoE_AdvancedMode = 8300,

		[ParentCombo(MCH_AoE_AdvancedMode)]
		[CustomComboInfo("Reassemble", "Adds Reassemble to the rotation", MCH.JobID)]
		MCH_AoE_Adv_Reassemble = 8301,

		[ParentCombo(MCH_AoE_AdvancedMode)]
		[ConflictingCombos(MCH_GaussRoundRicochet, MCH_Heatblast_GaussRound)]
		[CustomComboInfo("Gauss Round / Ricochet \nDouble Check / Checkmate", "Adds Gauss Round and Ricochet or Double Check and Checkmate to the rotation", MCH.JobID)]
		MCH_AoE_Adv_GaussRicochet = 8302,

		[ParentCombo(MCH_AoE_AdvancedMode)]
		[CustomComboInfo("Hypercharge", "Adds Hypercharge to the rotation", MCH.JobID)]
		MCH_AoE_Adv_Hypercharge = 8303,

		[ParentCombo(MCH_AoE_AdvancedMode)]
		[CustomComboInfo("Rook Autoturret/Automaton Queen", "Adds Rook Autoturret or Automaton Queen to the rotation", MCH.JobID)]
		MCH_AoE_Adv_Queen = 8304,

		[ParentCombo(MCH_AoE_AdvancedMode)]
		[CustomComboInfo("Flamethrower", "Adds Flamethrower to the rotation.\n Changes to Savage blade when in use to prevent cancelling", MCH.JobID)]
		MCH_AoE_Adv_FlameThrower = 8305,

		[ParentCombo(MCH_AoE_AdvancedMode)]
		[CustomComboInfo("Bioblaster", "Adds Bioblaster to the rotation", MCH.JobID)]
		MCH_AoE_Adv_Bioblaster = 8306,

		[ParentCombo(MCH_AoE_AdvancedMode)]
		[CustomComboInfo("Barrel Stabilizer", "Adds Barrel Stabilizer to the rotation", MCH.JobID)]
		MCH_AoE_Adv_Stabilizer = 8307,

		[ParentCombo(MCH_AoE_AdvancedMode)]
		[CustomComboInfo("Full Metal Field", "Adds Full Metal Field to the rotation", MCH.JobID)]
		MCH_AoE_Adv_Stabilizer_FullMetalField = 8308,

		[ParentCombo(MCH_AoE_AdvancedMode)]
		[CustomComboInfo("Chain Saw", "Adds Chain Saw to the the rotation", MCH.JobID)]
		MCH_AoE_Adv_Chainsaw = 8309,

		[ParentCombo(MCH_AoE_AdvancedMode)]
		[CustomComboInfo("Excavator", "Adds Excavator to the rotation", MCH.JobID)]
		MCH_AoE_Adv_Excavator = 8310,

		[ParentCombo(MCH_AoE_AdvancedMode)]
		[CustomComboInfo("Second Wind", "Use Second Wind when below the set HP percentage", MCH.JobID)]
		MCH_AoE_Adv_SecondWind = 8399,

		[ReplaceSkill(MCH.RookAutoturret, MCH.AutomatonQueen)]
		[CustomComboInfo("Overdrive", "Replace Rook Autoturret and Automaton Queen with Overdrive while active", MCH.JobID)]
		MCH_Overdrive = 8002,

		[ReplaceSkill(MCH.GaussRound, MCH.Ricochet, MCH.CheckMate, MCH.DoubleCheck)]
		[ConflictingCombos(MCH_ST_Adv_Opener, MCH_ST_Adv_GaussRicochet, MCH_AoE_Adv_GaussRicochet, MCH_Heatblast_GaussRound)]
		[CustomComboInfo("Gauss Round / Ricochet \nDouble Check / Checkmate", "Replace Gauss Round and Ricochet or Double Check and Checkmate with one or the other depending on which has more charges", MCH.JobID)]
		MCH_GaussRoundRicochet = 8003,

		[ReplaceSkill(MCH.Drill, MCH.AirAnchor, MCH.HotShot, MCH.Chainsaw)]
		[CustomComboInfo("Big Hitter", "Replace Hot Shot, Drill, Air Anchor, Chainsaw and Excavator depending on which is on cooldown", MCH.JobID)]
		MCH_HotShotDrillChainsawExcavator = 8004,

		[ReplaceSkill(MCH.Heatblast, MCH.BlazingShot)]
		[CustomComboInfo("Single Button Heat Blast", "Turns Heat Blast or Blazing Shot into Hypercharge \nwhen u have 50 or more heat or when u got Hypercharged buff", MCH.JobID)]
		MCH_Heatblast = 8006,

		[ParentCombo(MCH_Heatblast)]
		[CustomComboInfo("Barrel", "Adds Barrel Stabilizer to the when off cooldown", MCH.JobID)]
		MCH_Heatblast_AutoBarrel = 8052,

		[ParentCombo(MCH_Heatblast)]
		[CustomComboInfo("Wildfire", "Adds Wildfire to the when off cooldown and overheated", MCH.JobID)]
		MCH_Heatblast_Wildfire = 8015,

		[ParentCombo(MCH_Heatblast)]
		[ConflictingCombos(MCH_ST_Adv_Opener, MCH_ST_Adv_GaussRicochet, MCH_AoE_Adv_GaussRicochet, MCH_GaussRoundRicochet)]
		[CustomComboInfo("Gauss Round / Ricochet \nDouble Check / Checkmate", "Switches between Heat Blast and either Gauss Round and Ricochet or Double Check and Checkmate, depending on cooldown timers", MCH.JobID)]
		MCH_Heatblast_GaussRound = 8016,

		[ReplaceSkill(MCH.AutoCrossbow)]
		[CustomComboInfo("Single Button Auto Crossbow", "Turns Auto Crossbow into Hypercharge when at or above 50 heat", MCH.JobID)]
		MCH_AutoCrossbow = 8018,

		[ParentCombo(MCH_AutoCrossbow)]
		[CustomComboInfo("Barrel", "Adds Barrel Stabilizer to the when below 50 Heat Gauge", MCH.JobID)]
		MCH_AutoCrossbow_AutoBarrel = 8019,

		[ParentCombo(MCH_AutoCrossbow)]
		[CustomComboInfo("Gauss Round / Ricochet\n Double Check / Checkmate", "Switches between Auto Crossbow and either Gauss Round and Ricochet or Double Check and Checkmate, depending on cooldown timers", MCH.JobID)]
		MCH_AutoCrossbow_GaussRound = 8020,

		[ReplaceSkill(MCH.Dismantle)]
		[CustomComboInfo("Physical Ranged DPS: Double Dismantle Protection", "Prevents the use of Dismantle when target already has the effect", MCH.JobID)]
		All_PRanged_Dismantle = 8042,

		[ReplaceSkill(MCH.Dismantle)]
		[CustomComboInfo("Dismantle - Tactician", "Swap dismantle with tactician when dismantle is on cooldown", MCH.JobID)]
		MCH_DismantleTactician = 8058,

		[Variant]
		[VariantParent(MCH_ST_AdvancedMode, MCH_AoE_AdvancedMode)]
		[CustomComboInfo("Rampart", "Use Variant Rampart on cooldown", MCH.JobID)]
		MCH_Variant_Rampart = 8039,

		[Variant]
		[VariantParent(MCH_ST_AdvancedMode, MCH_AoE_AdvancedMode)]
		[CustomComboInfo("Cure", "Use Variant Cure when HP is below set threshold", MCH.JobID)]
		MCH_Variant_Cure = 8040,

		#endregion

		#region MONK - 9000

		[ReplaceSkill(MNK.ArmOfTheDestroyer)]
		[CustomComboInfo("Arm of the Destroyer Combo", "Replaces Arm Of The Destroyer with its combo chain", MNK.JobID)]
		MNK_AoE_SimpleMode = 9000,

		[ReplaceSkill(MNK.DragonKick)]
		[CustomComboInfo("Dragon Kick --> Bootshine", "Replaces Dragon Kick with Bootshine if both a form and Leaden Fist are up", MNK.JobID)]
		MNK_DragonKick_Bootshine = 9001,

		[ReplaceSkill(MNK.TrueStrike)]
		[CustomComboInfo("Twin Snakes", "Replaces True Strike with Twin Snakes if Disciplined Fist is not applied or is less than 6 seconds from falling off", MNK.JobID)]
		MNK_TwinSnakes = 9011,

		[ReplaceSkill(MNK.Bootshine)]
		[ConflictingCombos(MNK_ST_SimpleMode)]
		[CustomComboInfo("Basic Rotation", "Basic Monk Combo on one button", MNK.JobID)]
		MNK_BasicCombo = 9002,

		[ReplaceSkill(MNK.PerfectBalance)]
		[CustomComboInfo("Perfect Balance", "Perfect Balance becomes Masterful Blitz while you have 3 Beast Chakra", MNK.JobID)]
		MNK_PerfectBalance = 9003,

		[ReplaceSkill(MNK.DragonKick)]
		[CustomComboInfo("Bootshine Balance", "Replaces Dragon Kick with Masterful Blitz if you have 3 Beast Chakra", MNK.JobID)]
		MNK_BootshineBalance = 9004,

		[ReplaceSkill(MNK.HowlingFist, MNK.Enlightenment)]
		[CustomComboInfo("Howling Fist/Meditation", "Replaces Howling Fist/Enlightenment with Meditation when the Fifth Chakra is not open", MNK.JobID)]
		MNK_HowlingFistMeditation = 9005,

		[ReplaceSkill(MNK.Bootshine)]
		[ConflictingCombos(MNK_BasicCombo)]
		[CustomComboInfo("Bootshine Combo", "Replace Bootshine with its combo chain. \nIf all subs are selected will turn into a full one button rotation (Simple Monk). Slider values can be used to control Disciplined Fist + Demolish uptime", MNK.JobID, -2, "", "")]
		MNK_ST_SimpleMode = 9006,

		[ReplaceSkill(MNK.MasterfulBlitz)]
		[CustomComboInfo("Perfect Balance Plus", "All of the (optimal?) Blitz combos on Masterful Blitz when Perfect Balance is active", MNK.JobID)]
		MNK_PerfectBalance_Plus = 9007,

		[ParentCombo(MNK_ST_SimpleMode)]
		[CustomComboInfo("Masterful Blitz on Main Combo", "Adds Masterful Blitz to the main combo", MNK.JobID)]
		MNK_ST_Simple_MasterfulBlitz = 9008,

		[ParentCombo(MNK_AoE_SimpleMode)]
		[CustomComboInfo("Masterful Blitz to AoE Combo", "Adds Masterful Blitz to the AoE combo", MNK.JobID)]
		MNK_AoE_Simple_MasterfulBlitz = 9009,

		[ReplaceSkill(MNK.RiddleOfFire)]
		[CustomComboInfo("Riddle of Fire/Brotherhood", "Replaces Riddle of Fire with Brotherhood when Riddle of Fire is on cooldown", MNK.JobID)]
		MNK_Riddle_Brotherhood = 9012,

		[ParentCombo(MNK_ST_SimpleMode)]
		[CustomComboInfo("CDs on Main Combo", "Adds various CDs to the main combo when under Riddle of Fire or when Riddle of Fire is on cooldown", MNK.JobID)]
		MNK_ST_Simple_CDs = 9013,

		[ParentCombo(MNK_ST_Simple_CDs)]
		[CustomComboInfo("Riddle of Wind on Main Combo", "Adds Riddle of Wind to the main combo", MNK.JobID)]
		MNK_ST_Simple_CDs_RiddleOfWind = 9014,

		[ParentCombo(MNK_ST_Simple_CDs)]
		[CustomComboInfo("Perfect Balance on Main Combo", "Adds Perfect Balance to the main combo", MNK.JobID)]
		MNK_ST_Simple_CDs_PerfectBalance = 9015,

		[ParentCombo(MNK_ST_Simple_CDs)]
		[CustomComboInfo("Brotherhood on Main Combo", "Adds Brotherhood to the main combo", MNK.JobID)]
		MNK_ST_Simple_CDs_Brotherhood = 9016,

		[ParentCombo(MNK_ST_SimpleMode)]
		[CustomComboInfo("Meditation on Main Combo", "Adds Meditation spender to the main combo", MNK.JobID)]
		MNK_ST_Simple_Meditation = 9017,

		[ParentCombo(MNK_ST_SimpleMode)]
		[CustomComboInfo("Lunar Solar Opener", "Start with the Lunar Solar Opener on the main combo. Requires level 68 for Riddle of Fire.\nA 1.93/1.94 GCD is highly recommended", MNK.JobID)]
		MNK_ST_Simple_LunarSolarOpener = 9018,

		[ParentCombo(MNK_AoE_SimpleMode)]
		[CustomComboInfo("CDs on AoE Combo", "Adds various CDs to the AoE combo when under Riddle of Fire or when Riddle of Fire is on cooldown", MNK.JobID)]
		MNK_AoE_Simple_CDs = 9019,

		[ParentCombo(MNK_AoE_Simple_CDs)]
		[CustomComboInfo("Riddle of Wind on AoE Combo", "Adds Riddle of Wind to the AoE combo", MNK.JobID)]
		MNK_AoE_Simple_CDs_RiddleOfWind = 9020,

		[ParentCombo(MNK_AoE_Simple_CDs)]
		[CustomComboInfo("Perfect Balance on AoE Combo", "Adds Perfect Balance to the AoE combo", MNK.JobID)]
		MNK_AoE_Simple_CDs_PerfectBalance = 9021,

		[ParentCombo(MNK_AoE_Simple_CDs)]
		[CustomComboInfo("Brotherhood on AoE Combo", "Adds Brotherhood to the AoE combo", MNK.JobID)]
		MNK_AoE_Simple_CDs_Brotherhood = 9022,

		[ParentCombo(MNK_AoE_SimpleMode)]
		[CustomComboInfo("Meditation on AoE Combo", "Adds Meditation to the AoE combo", MNK.JobID)]
		MNK_AoE_Simple_Meditation = 9023,

		[ParentCombo(MNK_AoE_SimpleMode)]
		[CustomComboInfo("Thunderclap on AoE Combo", "Adds Thunderclap when out of combat to the AoE combo", MNK.JobID)]
		MNK_AoE_Simple_Thunderclap = 9024,

		[ParentCombo(MNK_ST_SimpleMode)]
		[CustomComboInfo("Thunderclap on Main Combo", "Adds Thunderclap when out of combat to the main combo", MNK.JobID)]
		MNK_ST_Simple_Thunderclap = 9025,

		[ParentCombo(MNK_ST_SimpleMode)]
		[CustomComboInfo("Combo Heals", "Adds Bloodbath and Second Wind to the combo, using them when below the HP Percentage threshold", MNK.JobID)]
		MNK_ST_ComboHeals = 9026,

		[ParentCombo(MNK_AoE_SimpleMode)]
		[CustomComboInfo("Combo Heals", "Adds Bloodbath and Second Wind to the combo, using them when below the HP Percentage threshold", MNK.JobID)]
		MNK_AoE_ComboHeals = 9027,

		[ParentCombo(MNK_ST_Simple_Meditation)]
		[CustomComboInfo("Mediation Uptime", "Replaces Main Combo with Mediation when you are out of range and out of opener/burst", MNK.JobID)]
		MNK_ST_Meditation_Uptime = 9028,

		[ParentCombo(MNK_ST_SimpleMode)]
		[CustomComboInfo("Dynamic True North", "Adds True North to the main combo right before positionals if you aren't in the correct position for their bonuses", MNK.JobID)]
		MNK_TrueNorthDynamic = 9029,

		[Variant]
		[VariantParent(MNK_ST_SimpleMode, MNK_AoE_SimpleMode)]
		[CustomComboInfo("Cure", "Use Variant Cure when HP is below set threshold", MNK.JobID)]
		MNK_Variant_Cure = 9030,

		[Variant]
		[VariantParent(MNK_ST_SimpleMode, MNK_AoE_SimpleMode)]
		[CustomComboInfo("Rampart", "Use Variant Rampart on cooldown", MNK.JobID)]
		MNK_Variant_Rampart = 9031,

		#endregion

		#region NINJA - 10000

		[ReplaceSkill(NIN.SpinningEdge)]
		[ConflictingCombos(NIN_ArmorCrushCombo, NIN_ST_AdvancedMode, NIN_KassatsuChiJin, NIN_KassatsuTrick)]
		[CustomComboInfo("Simple Mode - Single Target", "Replaces Spinning Edge with a one-button full single target rotation.\nThis is the ideal for newcomers to the job", NIN.JobID)]
		NIN_ST_SimpleMode = 10000,

		[ParentCombo(NIN_ST_SimpleMode)]
		[CustomComboInfo("Balance Opener", "Starts with the Balance opener.\nDoes pre-pull first, if you enter combat before hiding the opener will fail.\nLikewise, moving during TCJ will cause the opener to fail too.\nRequires you to be out of combat with majority of your cooldowns available for it to work", NIN.JobID)]
		NIN_ST_SimpleMode_BalanceOpener = 10001,

		[ReplaceSkill(NIN.DeathBlossom)]
		[ConflictingCombos(NIN_AoE_AdvancedMode)]
		[CustomComboInfo("Simple Mode - AoE", "Turns Death Blossom into a one-button full AoE rotation", NIN.JobID)]
		NIN_AoE_SimpleMode = 10002,

		[ReplaceSkill(NIN.SpinningEdge)]
		[ConflictingCombos(NIN_ST_SimpleMode)]
		[CustomComboInfo("Advanced Mode - Single Target", "Replace Spinning Edge with a one-button full single target rotation.\nTheses are ideal if you want to customize the rotation", NIN.JobID)]
		NIN_ST_AdvancedMode = 10003,

		[ParentCombo(NIN_ST_AdvancedMode)]
		[CustomComboInfo("Throwing Dagger Uptime", "Adds Throwing Dagger to Advanced Mode if out of melee range", NIN.JobID)]
		NIN_ST_AdvancedMode_RangedUptime = 10004,

		[ParentCombo(NIN_ST_AdvancedMode)]
		[CustomComboInfo("Mug", "Adds Mug to Advanced Mode", NIN.JobID)]
		NIN_ST_AdvancedMode_Mug = 10005,

		[ConflictingCombos(NIN_ST_AdvancedMode_Mug_AlignBefore)]
		[ParentCombo(NIN_ST_AdvancedMode_Mug)]
		[CustomComboInfo("Align Mug with Trick Attack", "Only uses Mug whilst the target has Trick Attack, otherwise will use on cooldown", NIN.JobID)]
		NIN_ST_AdvancedMode_Mug_AlignAfter = 10006,

		[ConflictingCombos(NIN_ST_AdvancedMode_Mug_AlignAfter)]
		[ParentCombo(NIN_ST_AdvancedMode_Mug)]
		[CustomComboInfo("Use Mug before Trick Attack", "Aligns Mug with Trick Attack but weaves it at least 1 GCD before Trick Attack", NIN.JobID)]
		NIN_ST_AdvancedMode_Mug_AlignBefore = 10007,

		[ParentCombo(NIN_ST_AdvancedMode)]
		[CustomComboInfo("Trick Attack", "Adds Trick Attack to Advanced Mode", NIN.JobID)]
		NIN_ST_AdvancedMode_TrickAttack = 10008,

		[ParentCombo(NIN_ST_AdvancedMode_TrickAttack)]
		[CustomComboInfo("Save Cooldowns Before Trick Attack", "Stops using abilities with longer cooldowns up to 15 seconds before Trick Attack comes off cooldown", NIN.JobID)]
		NIN_ST_AdvancedMode_TrickAttack_Cooldowns = 10009,

		[ParentCombo(NIN_ST_AdvancedMode_TrickAttack)]
		[CustomComboInfo("Delayed Trick Attack", "Waits at least 8 seconds into combat before using Trick Attack", NIN.JobID)]
		NIN_ST_AdvancedMode_TrickAttack_Delayed = 10010,

		[ParentCombo(NIN_ST_AdvancedMode)]
		[CustomComboInfo("Ninjitsu", "Adds Ninjitsu to Advanced Mode", NIN.JobID)]
		NIN_ST_AdvancedMode_Ninjitsus = 10011,

		[ParentCombo(NIN_ST_AdvancedMode_Ninjitsus)]
		[CustomComboInfo("Hold 1 Charge", "Prevent using both charges of Mudra", NIN.JobID)]
		NIN_ST_AdvancedMode_Ninjitsus_ChargeHold = 10012,

		[ParentCombo(NIN_ST_AdvancedMode_Ninjitsus)]
		[CustomComboInfo("Use Fuma Shuriken", "Spends Mudra charges on Fuma Shuriken (only before Raiton is available)", NIN.JobID)]
		NIN_ST_AdvancedMode_Ninjitsus_FumaShuriken = 10013,

		[ParentCombo(NIN_ST_AdvancedMode_Ninjitsus)]
		[CustomComboInfo("Use Raiton", "Spends Mudra charges on Raiton", NIN.JobID)]
		NIN_ST_AdvancedMode_Ninjitsus_Raiton = 10014,

		[ParentCombo(NIN_ST_AdvancedMode_Ninjitsus)]
		[CustomComboInfo("Use Suiton", "Spends Mudra charges on Suiton", NIN.JobID)]
		NIN_ST_AdvancedMode_Ninjitsus_Suiton = 10015,

		[ParentCombo(NIN_ST_AdvancedMode_Ninjitsus)]
		[CustomComboInfo("Use Huton", "Spends Mudra charges on Huton", NIN.JobID)]
		NIN_ST_AdvancedMode_Ninjitsus_Huton = 10016,

		[ParentCombo(NIN_ST_AdvancedMode)]
		[CustomComboInfo("Assassinate/Dream Within a Dream", "Adds Assassinate and Dream Within a Dream to Advanced Mode", NIN.JobID)]
		NIN_ST_AdvancedMode_AssassinateDWAD = 10017,

		[ConflictingCombos(NIN_KassatsuTrick, NIN_KassatsuChiJin)]
		[ParentCombo(NIN_ST_AdvancedMode)]
		[CustomComboInfo("Kassatsu", "Adds Kassatsu to Advanced Mode", NIN.JobID)]
		NIN_ST_AdvancedMode_Kassatsu = 10018,

		[ParentCombo(NIN_ST_AdvancedMode_Kassatsu)]
		[CustomComboInfo($"Use Hyosho Ranryu", "Spends Kassatsu on Hyosho Ranryu", NIN.JobID)]
		NIN_ST_AdvancedMode_Kassatsu_HyoshoRaynryu = 10019,

		[ParentCombo(NIN_ST_AdvancedMode)]
		[CustomComboInfo("Armor Crush", "Adds Armor Crush to Advanced Mode", NIN.JobID)]
		NIN_ST_AdvancedMode_ArmorCrush = 10020,

		[ParentCombo(NIN_ST_AdvancedMode)]
		[CustomComboInfo("Huraijin", "Adds Huraijin to Advanced Mode", NIN.JobID)]
		NIN_ST_AdvancedMode_Huraijin = 10021,

		[ParentCombo(NIN_ST_AdvancedMode)]
		[CustomComboInfo("Bhavacakra", "Adds Bhavacakra to Advanced Mode", NIN.JobID)]
		NIN_ST_AdvancedMode_Bhavacakra = 10022,

		[ParentCombo(NIN_ST_AdvancedMode)]
		[CustomComboInfo("Ten Chi Jin", "Adds Ten Chi Jin (the cooldown) to Advanced Mode", NIN.JobID)]
		NIN_ST_AdvancedMode_TCJ = 10023,

		[ParentCombo(NIN_ST_AdvancedMode)]
		[CustomComboInfo("Meisui", "Adds Meisui to Advanced Mode", NIN.JobID)]
		NIN_ST_AdvancedMode_Meisui = 10024,

		[ParentCombo(NIN_ST_AdvancedMode)]
		[CustomComboInfo("Bunshin", "Adds Bunshin to Advanced Mode", NIN.JobID)]
		NIN_ST_AdvancedMode_Bunshin = 10025,

		[ParentCombo(NIN_ST_AdvancedMode_Bunshin)]
		[CustomComboInfo("Phantom Kamaitachi", "Adds Phantom Kamaitachi to Advanced Mode", NIN.JobID)]
		NIN_ST_AdvancedMode_Bunshin_Phantom = 10026,

		[ParentCombo(NIN_ST_AdvancedMode)]
		[CustomComboInfo("Raiju", "Adds Fleeting/Forked Raiju to Advanced Mode", NIN.JobID)]
		NIN_ST_AdvancedMode_Raiju = 10027,

		[ParentCombo(NIN_ST_AdvancedMode_Raiju)]
		[CustomComboInfo("Forked Raiju Gap-Closer", "Uses Forked Raiju when out of range", NIN.JobID)]
		NIN_ST_AdvancedMode_Raiju_Forked = 10028,

		[ConflictingCombos(NIN_KassatsuChiJin, NIN_KassatsuTrick)]
		[ParentCombo(NIN_ST_AdvancedMode)]
		[CustomComboInfo("Balance Opener", "Starts with the Balance opener.\nDoes pre-pull first, if you enter combat before hiding the opener will fail.\nLikewise, moving during TCJ will cause the opener to fail too.\nRequires you to be out of combat with majority of your cooldowns available for it to work", NIN.JobID)]
		NIN_ST_AdvancedMode_BalanceOpener = 10029,

		[ParentCombo(NIN_ST_AdvancedMode)]
		[CustomComboInfo("True North", "Adds True North to Advanced Mode", NIN.JobID)]
		NIN_ST_AdvancedMode_TrueNorth = 10030,

		[ParentCombo(NIN_ST_AdvancedMode_TrueNorth)]
		[CustomComboInfo("Use Before Armor Crush Only", "Only triggers the use of True North before Armor Crush", NIN.JobID)]
		NIN_ST_AdvancedMode_TrueNorth_ArmorCrush = 10031,

		[ParentCombo(NIN_ST_AdvancedMode)]
		[CustomComboInfo("Second Wind", "Adds Second Wind to Advanced Mode", NIN.JobID)]
		NIN_ST_AdvancedMode_SecondWind = 10032,

		[ParentCombo(NIN_ST_AdvancedMode)]
		[CustomComboInfo("Shade Shift", "Adds Shade Shift to Advanced Mode", NIN.JobID)]
		NIN_ST_AdvancedMode_ShadeShift = 10033,

		[ParentCombo(NIN_ST_AdvancedMode)]
		[CustomComboInfo("Bloodbath", "Adds Bloodbath to Advanced Mode", NIN.JobID)]
		NIN_ST_AdvancedMode_Bloodbath = 10034,

		[ReplaceSkill(NIN.DeathBlossom)]
		[ConflictingCombos(NIN_AoE_SimpleMode)]
		[CustomComboInfo("Advanced Mode - AoE", "Replace Death Blossom with a one-button full AoE rotation.\nTheses are ideal if you want to customize the rotation", NIN.JobID)]
		NIN_AoE_AdvancedMode = 10035,

		[ParentCombo(NIN_AoE_AdvancedMode)]
		[CustomComboInfo("Assassinate/Dream Within a Dream", "Adds Assassinate/Dream Within a Dream to Advanced Mode", NIN.JobID)]
		NIN_AoE_AdvancedMode_AssassinateDWAD = 10036,

		[ParentCombo(NIN_AoE_AdvancedMode)]
		[CustomComboInfo("Ninjitsu", "Adds Ninjitsu to Advanced Mode", NIN.JobID)]
		NIN_AoE_AdvancedMode_Ninjitsus = 10037,

		[ParentCombo(NIN_AoE_AdvancedMode_Ninjitsus)]
		[CustomComboInfo("Hold 1 Charge", "Prevent using both charges of Mudra", NIN.JobID)]
		NIN_AoE_AdvancedMode_Ninjitsus_ChargeHold = 10038,

		[ParentCombo(NIN_AoE_AdvancedMode_Ninjitsus)]
		[CustomComboInfo("Use Katon", "Spends Mudra charges on Katon", NIN.JobID)]
		NIN_AoE_AdvancedMode_Ninjitsus_Katon = 10039,

		[ParentCombo(NIN_AoE_AdvancedMode_Ninjitsus)]
		[CustomComboInfo("Use Doton", "Spends Mudra charges on Doton", NIN.JobID)]
		NIN_AoE_AdvancedMode_Ninjitsus_Doton = 10040,

		[ParentCombo(NIN_AoE_AdvancedMode_Ninjitsus)]
		[CustomComboInfo("Use Huton", "Spends Mudra charges on Huton", NIN.JobID)]
		NIN_AoE_AdvancedMode_Ninjitsus_Huton = 10041,

		[ConflictingCombos(NIN_KassatsuTrick, NIN_KassatsuChiJin)]
		[ParentCombo(NIN_AoE_AdvancedMode)]
		[CustomComboInfo("Kassatsu", "Adds Kassatsu to Advanced Mode", NIN.JobID)]
		NIN_AoE_AdvancedMode_Kassatsu = 10042,

		[ParentCombo(NIN_AoE_AdvancedMode_Kassatsu)]
		[CustomComboInfo("Goka Mekkyaku", "Adds Goka Mekkyaku to Advanced Mode", NIN.JobID)]
		NIN_AoE_AdvancedMode_GokaMekkyaku = 10043,

		[ParentCombo(NIN_AoE_AdvancedMode)]
		[CustomComboInfo("Huraijin", "Adds Huraijin to Advanced Mode", NIN.JobID)]
		NIN_AoE_AdvancedMode_Huraijin = 10044,

		[ParentCombo(NIN_AoE_AdvancedMode)]
		[CustomComboInfo("Hellfrog Medium", "Adds Hellfrog Medium to Advanced Mode", NIN.JobID)]
		NIN_AoE_AdvancedMode_HellfrogMedium = 10045,

		[ParentCombo(NIN_AoE_AdvancedMode)]
		[CustomComboInfo("Ten Chi Jin", "Adds Ten Chi Jin (the cooldown) to Advanced Mode", NIN.JobID)]
		NIN_AoE_AdvancedMode_TCJ = 10046,

		[ParentCombo(NIN_AoE_AdvancedMode)]
		[CustomComboInfo("Meisui", "Adds Meisui to Advanced Mode", NIN.JobID)]
		NIN_AoE_AdvancedMode_Meisui = 10047,

		[ParentCombo(NIN_AoE_AdvancedMode)]
		[CustomComboInfo("Bunshin", "Adds Bunshin to Advanced Mode", NIN.JobID)]
		NIN_AoE_AdvancedMode_Bunshin = 10048,

		[ParentCombo(NIN_AoE_AdvancedMode_Bunshin)]
		[CustomComboInfo("Phantom Kamaitachi", "Adds Phantom Kamaitachi to Advanced Mode", NIN.JobID)]
		NIN_AoE_AdvancedMode_Bunshin_Phantom = 10049,

		[ParentCombo(NIN_AoE_AdvancedMode)]
		[CustomComboInfo("Second Wind", "Adds Second Wind to Advanced Mode", NIN.JobID)]
		NIN_AoE_AdvancedMode_SecondWind = 10050,

		[ParentCombo(NIN_AoE_AdvancedMode)]
		[CustomComboInfo("Shade Shift", "Adds Shade Shift to Advanced Mode", NIN.JobID)]
		NIN_AoE_AdvancedMode_ShadeShift = 10051,

		[ParentCombo(NIN_AoE_AdvancedMode)]
		[CustomComboInfo("Bloodbath", "Adds Bloodbath to Advanced Mode", NIN.JobID)]
		NIN_AoE_AdvancedMode_Bloodbath = 10052,

		[ReplaceSkill(NIN.ArmorCrush)]
		[ConflictingCombos(NIN_ST_SimpleMode)]
		[CustomComboInfo("Armor Crush Combo", "Replace Armor Crush with its combo chain", NIN.JobID)]
		NIN_ArmorCrushCombo = 10053,

		[ConflictingCombos(NIN_ST_AdvancedMode_BalanceOpener, NIN_ST_AdvancedMode_BalanceOpener, NIN_ST_AdvancedMode_Kassatsu, NIN_AoE_AdvancedMode_Kassatsu, NIN_KassatsuChiJin)]
		[ReplaceSkill(NIN.Kassatsu)]
		[CustomComboInfo("Kassatsu to Trick", "Replaces Kassatsu with Trick Attack while Suiton or Hidden is up.\nCooldown tracking plugin recommended", NIN.JobID)]
		NIN_KassatsuTrick = 10054,

		[ReplaceSkill(NIN.TenChiJin)]
		[CustomComboInfo("Ten Chi Jin to Meisui", "Replaces Ten Chi Jin (the move) with Meisui while Suiton is up.\nCooldown tracking plugin recommended", NIN.JobID)]
		NIN_TCJMeisui = 10055,

		[ConflictingCombos(NIN_ST_AdvancedMode_BalanceOpener, NIN_ST_AdvancedMode_BalanceOpener, NIN_KassatsuTrick, NIN_ST_AdvancedMode_Kassatsu, NIN_AoE_AdvancedMode_Kassatsu)]
		[ReplaceSkill(NIN.Chi)]
		[CustomComboInfo("Kassatsu Chi/Jin", "Replaces Chi with Jin while Kassatsu is up if you have Enhanced Kassatsu", NIN.JobID)]
		NIN_KassatsuChiJin = 10056,

		[ReplaceSkill(NIN.Hide)]
		[CustomComboInfo("Hide to Mug/Trick Attack", "Replaces Hide with Mug while in combat and Trick Attack whilst Hidden", NIN.JobID)]
		NIN_HideMug = 10057,

		[ReplaceSkill(NIN.Ten, NIN.Chi, NIN.Jin)]
		[CustomComboInfo("Simple Mudras", "Simplify the mudra casting to avoid failing", NIN.JobID)]
		NIN_Simple_Mudras = 10062,

		[ReplaceSkill(NIN.TenChiJin)]
		[ParentCombo(NIN_TCJMeisui)]
		[CustomComboInfo("Ten Chi Jin", "Turns Ten Chi Jin (the move) into Ten, Chi, and Jin", NIN.JobID)]
		NIN_TCJ = 10063,

		[ParentCombo(NIN_ST_AdvancedMode_Ninjitsus_Raiton)]
		[CustomComboInfo("Raiton Uptime", "Adds Raiton as an uptime", NIN.JobID)]
		NIN_ST_AdvancedMode_Raiton_Uptime = 10065,

		[ParentCombo(NIN_ST_AdvancedMode_Bunshin_Phantom)]
		[CustomComboInfo("Phantom Kamaitachi Uptime", "Adds Phantom Kamaitachi as an uptime", NIN.JobID)]
		NIN_ST_AdvancedMode_Phantom_Uptime = 10066,

		[ParentCombo(NIN_ST_AdvancedMode_Ninjitsus_Suiton)]
		[CustomComboInfo("Suiton Uptime", "Adds Suiton as an uptime", NIN.JobID)]
		NIN_ST_AdvancedMode_Suiton_Uptime = 10067,

		[ParentCombo(NIN_ST_AdvancedMode_TrueNorth_ArmorCrush)]
		[CustomComboInfo("Dynamic True North", "Adds True North before Armor Crush when you are not in the correct position for the enhanced potency bonus", NIN.JobID)]
		NIN_ST_AdvancedMode_TrueNorth_ArmorCrush_Dynamic = 10068,

		[Variant]
		[VariantParent(NIN_ST_SimpleMode, NIN_ST_AdvancedMode, NIN_AoE_SimpleMode, NIN_AoE_AdvancedMode)]
		[CustomComboInfo("Cure", "Use Variant Cure when HP is below set threshold", NIN.JobID)]
		NIN_Variant_Cure = 10069,

		[Variant]
		[VariantParent(NIN_ST_SimpleMode, NIN_ST_AdvancedMode, NIN_AoE_SimpleMode, NIN_AoE_AdvancedMode)]
		[CustomComboInfo("Rampart", "Use Variant Rampart on cooldown", NIN.JobID)]
		NIN_Variant_Rampart = 10070,

		#endregion

		#region PICTOMANCER - 20000

		[ReplaceSkill(PCT.FireInRed)]
		[CustomComboInfo("Advanced Mode - Single Target", "Replaces Fire In Red with a full one-button single target rotation.\nTheses are ideal if you want to customize the rotation", PCT.JobID, 3)]
		PCT_ST_Adv = 20010,

		[ParentCombo(PCT_ST_Adv)]
		[ReplaceSkill(All.LucidDreaming)]
		[CustomComboInfo("Lucid Dreaming", "Adds Lucid Dreaming when MP drops below the slider value", PCT.JobID)]
		PCT_ST_Lucid = 20011,

		[ParentCombo(PCT_ST_Adv)]
		[ReplaceSkill(PCT.SubtractivePalette)]
		[CustomComboInfo("Subtractive Palette Overcap Protection", "Uses Subtractive Palette when at 100 gauge", PCT.JobID)]
		PCT_ST_Subtractive_OP = 20012,

		[ParentCombo(PCT_ST_Adv)]
		[ReplaceSkill(PCT.HolyInWhite, PCT.CometinBlack)]
		[CustomComboInfo("Comet Overcap Protection", "Uses White/Black Paint when at 5 stacks and Aetherhues II", PCT.JobID)]
		PCT_ST_Comet_OP = 20013,

		[ReplaceSkill(PCT.FireIIinRed)]
		[CustomComboInfo("Advanced Mode - AoE", "Replaces Fire In Red II with a full one-button single target rotation.\nTheses are ideal if you want to customize the rotation", PCT.JobID, 3)]
		PCT_AoE_Adv = 20030,

		[ParentCombo(PCT_AoE_Adv)]
		[ReplaceSkill(All.LucidDreaming)]
		[CustomComboInfo("Lucid Dreaming", "Adds Lucid Dreaming when MP drops below the slider value", PCT.JobID)]
		PCT_AoE_Lucid = 20031,

		[ParentCombo(PCT_AoE_Adv)]
		[ReplaceSkill(PCT.SubtractivePalette)]
		[CustomComboInfo("Subtractive Palette Overcap Protection", "Uses Subtractive Palette when at 100 gauge", PCT.JobID)]
		PCT_AoE_Subtractive_OP = 20032,

		[ParentCombo(PCT_AoE_Adv)]
		[ReplaceSkill(PCT.HolyInWhite, PCT.CometinBlack)]
		[CustomComboInfo("Comet Overcap Protection", "Uses White/Black Paint when at 5 stacks and Aetherhues II", PCT.JobID)]
		PCT_AoE_Comet_OP = 20033,

		[ReplaceSkill(PCT.CreatureMotif, PCT.WeaponMotif)]
		[CustomComboInfo("Creature and Weapon One Button Motifs", "Combine Creature and Weapon Motifs and Muses into one button", PCT.JobID, 4)]
		PCT_CreatureWeapon = 20051,

		[ReplaceSkill(PCT.LandscapeMotif)]
		[CustomComboInfo("Landscape One Button Motif", "Combine Landscape Motif and Muse into one button", PCT.JobID, 4)]
		PCT_Landscape = 20052,

		[ReplaceSkill(PCT.HolyInWhite)]
		[CustomComboInfo("White & Black Paint", "Combines White and Black Paints into one button", PCT.JobID, 5)]
		PCT_Paint = 20053,

		[ReplaceSkill(PCT.SubtractivePalette)]
		[CustomComboInfo("Subtractive to Comet In Black", "Changes Subtractive Palette to Comet in Black if a Black Paint is available", PCT.JobID, 6)]
		PCT_SubPaint_OP = 20054,

		#endregion

		#region PALADIN - 11000

		#region Single Target

		[ReplaceSkill(PLD.FastBlade)]
		[CustomComboInfo("Single Target", "", PLD.JobID, 1)]
		PLD_ST_AdvancedMode = 11002,

		[ParentCombo(PLD_ST_AdvancedMode)]
		[CustomComboInfo("Fight or Flight", "", PLD.JobID, 0)]
		PLD_ST_AdvancedMode_FoF = 11003,

		[ParentCombo(PLD_ST_AdvancedMode)]
		[CustomComboInfo("Circle of Scorn", "", PLD.JobID, 1)]
		PLD_ST_AdvancedMode_CircleOfScorn = 11005,

		[ParentCombo(PLD_ST_AdvancedMode)]
		[CustomComboInfo("Spirits Within", "", PLD.JobID, 1)]
		PLD_ST_AdvancedMode_SpiritsWithin = 11006,

		[ParentCombo(PLD_ST_AdvancedMode)]
		[CustomComboInfo("Sheltron", "", PLD.JobID, 3)]
		PLD_ST_AdvancedMode_Sheltron = 11007,

		[ParentCombo(PLD_ST_AdvancedMode)]
		[CustomComboInfo("Holy Spirit", "", PLD.JobID, 8)]
		PLD_ST_AdvancedMode_HolySpirit = 11009,

		[ParentCombo(PLD_ST_AdvancedMode)]
		[CustomComboInfo("Intervene", "", PLD.JobID, 5)]
		PLD_ST_AdvancedMode_Intervene = 11011,

		[ParentCombo(PLD_ST_AdvancedMode)]
		[CustomComboInfo("Atonement", "", PLD.JobID, 9)]
		PLD_ST_AdvancedMode_Atonement = 11012,

		#endregion

		#region AoE

		[ReplaceSkill(PLD.TotalEclipse)]
		[CustomComboInfo("AoE", "", PLD.JobID, 2)]
		PLD_AoE_AdvancedMode = 11015,

		[ParentCombo(PLD_AoE_AdvancedMode)]
		[CustomComboInfo("Fight or Flight", "", PLD.JobID, 0)]
		PLD_AoE_AdvancedMode_FoF = 11016,

		[ParentCombo(PLD_AoE_AdvancedMode)]
		[CustomComboInfo("Spirits Within", "", PLD.JobID, 1)]
		PLD_AoE_AdvancedMode_SpiritsWithin = 11017,

		[ParentCombo(PLD_AoE_AdvancedMode)]
		[CustomComboInfo("Circle of Scorn", "", PLD.JobID, 2)]
		PLD_AoE_AdvancedMode_CircleOfScorn = 11018,

		[ParentCombo(PLD_AoE_AdvancedMode)]
		[CustomComboInfo("Holy Circle", "", PLD.JobID, 5)]
		PLD_AoE_AdvancedMode_HolyCircle = 11020,

		[ParentCombo(PLD_AoE_AdvancedMode)]
		[CustomComboInfo("Sheltron", "", PLD.JobID, 3)]
		PLD_AoE_AdvancedMode_Sheltron = 11023,

		#endregion

		#region Utility

		[ReplaceSkill(PLD.SpiritsWithin, PLD.Expiacion)]
		[CustomComboInfo("Spirits Within / Circle of Scorn", "", PLD.JobID, 3)]
		PLD_SpiritsWithin = 11025,

		[ReplaceSkill(PLD.Requiescat)]
		[CustomComboInfo("Requiescat Spender", "", PLD.JobID, 4)]
		PLD_Requiescat_Options = 11024,

		#endregion

		#region Variant

		[Variant]
		[CustomComboInfo("Spirit Dart", "", PLD.JobID)]
		PLD_Variant_SpiritDart = 11030,

		[Variant]
		[CustomComboInfo("Cure", "", PLD.JobID)]
		PLD_Variant_Cure = 11031,

		[Variant]
		[CustomComboInfo("Ultimatum", "", PLD.JobID)]
		PLD_Variant_Ultimatum = 11032,

		#endregion

		#endregion

		#region REAPER - 12000

		[ReplaceSkill(RPR.Slice)]
		[ConflictingCombos(RPR_ST_AdvancedMode)]
		[CustomComboInfo("Simple Mode - Single Target", "Replaces Slice with a one-button full single target rotation.\nThis is ideal for newcomers to the job", RPR.JobID)]
		RPR_ST_SimpleMode = 12000,

		[ReplaceSkill(RPR.Slice)]
		[ConflictingCombos(RPR_ST_SimpleMode)]
		[CustomComboInfo("Advanced Mode - Single Target", "Replaces Slice with a full one-button single target rotation.\nTheses are ideal if you want to customize the rotation", RPR.JobID)]
		RPR_ST_AdvancedMode = 12001,

		[ParentCombo(RPR_ST_AdvancedMode)]
		[CustomComboInfo("Level 100 Opener", "Adds the Balance opener to the rotation.\n Does not check positional choice.\n Always does Gibbet first ( FLANK )", RPR.JobID)]
		RPR_ST_Opener = 12002,

		[ParentCombo(RPR_ST_AdvancedMode)]
		[CustomComboInfo("Shadow Of Death", "Adds Shadow of Death to the rotation", RPR.JobID)]
		RPR_ST_SoD = 12003,

		[ParentCombo(RPR_ST_AdvancedMode)]
		[CustomComboInfo("Soul Slice", "Adds Soul Slice to the rotation", RPR.JobID)]
		RPR_ST_SoulSlice = 12004,

		[ParentCombo(RPR_ST_AdvancedMode)]
		[CustomComboInfo("Cooldowns", "Adds various cooldowns to the rotation", RPR.JobID)]
		RPR_ST_CDs = 12005,

		[ParentCombo(RPR_ST_CDs)]
		[CustomComboInfo("Arcane Circle", "Adds Arcane Circle to the rotation", RPR.JobID)]
		RPR_ST_ArcaneCircle = 12006,

		[ParentCombo(RPR_ST_CDs)]
		[CustomComboInfo("Plentiful Harvest", "Adds Plentiful Harvest to the rotation", RPR.JobID)]
		RPR_ST_PlentifulHarvest = 12007,

		[ParentCombo(RPR_ST_CDs)]
		[CustomComboInfo("Bloodstalk", "Adds Bloodstalk to the rotation", RPR.JobID)]
		RPR_ST_Bloodstalk = 12008,

		[ParentCombo(RPR_ST_CDs)]
		[CustomComboInfo("Gluttony", "Adds Gluttony to the rotation", RPR.JobID)]
		RPR_ST_Gluttony = 12009,

		[ParentCombo(RPR_ST_AdvancedMode)]
		[CustomComboInfo("Enshroud", "Adds Enshroud to the rotation", RPR.JobID)]
		RPR_ST_Enshroud = 12010,

		[ParentCombo(RPR_ST_AdvancedMode)]
		[CustomComboInfo("Void/Cross Reaping", "Adds Void Reaping and Cross Reaping to the rotation.\n(Disabling this may stop the one-button combo working during enshroud)", RPR.JobID)]
		RPR_ST_Reaping = 12011,

		[ParentCombo(RPR_ST_AdvancedMode)]
		[CustomComboInfo("Lemure's Slice", "Adds Lemure's Slice to the rotation", RPR.JobID)]
		RPR_ST_Lemure = 12012,

		[ParentCombo(RPR_ST_AdvancedMode)]
		[CustomComboInfo("Sacrificium", "Adds Sacrificium to the rotation", RPR.JobID)]
		RPR_ST_Sacrificium = 12013,

		[ParentCombo(RPR_ST_AdvancedMode)]
		[CustomComboInfo("Communio Finisher", "Adds Communio to the rotation", RPR.JobID)]
		RPR_ST_Communio = 12014,

		[ParentCombo(RPR_ST_AdvancedMode)]
		[CustomComboInfo("Perfectio", "Adds Perfectio to the rotation", RPR.JobID)]
		RPR_ST_Perfectio = 12015,

		[ParentCombo(RPR_ST_AdvancedMode)]
		[CustomComboInfo("Gibbet and Gallows", "Adds Gibbet and Gallows to the rotation", RPR.JobID)]
		RPR_ST_GibbetGallows = 12016,

		[ParentCombo(RPR_ST_AdvancedMode)]
		[CustomComboInfo("Ranged Filler", "Replaces the combo chain with Harpe when outside of melee range. Will not override Communio", RPR.JobID)]
		RPR_ST_RangedFiller = 12017,

		[ParentCombo(RPR_ST_RangedFiller)]
		[CustomComboInfo("Add Harvest Moon", "Adds Harvest Moon if available, when outside of melee range. Will not override Communio", RPR.JobID)]
		RPR_ST_RangedFillerHarvestMoon = 12018,

		[ParentCombo(RPR_ST_AdvancedMode)]
		[CustomComboInfo("Combo Heals", "Adds Bloodbath and Second Wind to the combo, using them when below the HP Percentage threshold", RPR.JobID)]
		RPR_ST_ComboHeals = 12097,

		[ParentCombo(RPR_ST_AdvancedMode)]
		[CustomComboInfo("Dynamic True North", "Adds True North before Gibbet/Gallows when you are not in the correct position", RPR.JobID)]
		RPR_ST_TrueNorthDynamic = 12098,

		[ParentCombo(RPR_ST_TrueNorthDynamic)]
		[CustomComboInfo("Hold True North for Gluttony", "Will hold the last charge of True North for use with Gluttony, even when out of position for Gibbet/Gallows", RPR.JobID)]
		RPR_ST_TrueNorthDynamic_HoldCharge = 12099,

		[ReplaceSkill(RPR.SpinningScythe)]
		[ConflictingCombos(RPR_AoE_AdvancedMode)]
		[CustomComboInfo("Simple Mode - AoE", "Replaces Spinning Scythe with a one-button full single target rotation.\nThis is ideal for newcomers to the job", RPR.JobID)]
		RPR_AoE_SimpleMode = 12100,

		[ReplaceSkill(RPR.SpinningScythe)]
		[ConflictingCombos(RPR_AoE_SimpleMode)]
		[CustomComboInfo("Advanced Mode - AoE", "Replaces Spinning Scythe with a full one-button AoE rotation.\nTheses are ideal if you want to customize the rotation", RPR.JobID)]
		RPR_AoE_AdvancedMode = 12101,

		[ParentCombo(RPR_AoE_AdvancedMode)]
		[CustomComboInfo("Whorl Of Death", "Adds Whorl of Death to the rotation", RPR.JobID)]
		RPR_AoE_WoD = 12102,

		[ParentCombo(RPR_AoE_AdvancedMode)]
		[CustomComboInfo("Soul Scythe", "Adds Soul Scythe to the rotation", RPR.JobID)]
		RPR_AoE_SoulScythe = 12103,

		[ParentCombo(RPR_AoE_AdvancedMode)]
		[CustomComboInfo("Cooldowns", "Adds various cooldowns to the rotation", RPR.JobID)]
		RPR_AoE_CDs = 12104,

		[ParentCombo(RPR_AoE_CDs)]
		[CustomComboInfo("Arcane Circle", "Adds Arcane Circle to the rotation", RPR.JobID)]
		RPR_AoE_ArcaneCircle = 12105,

		[ParentCombo(RPR_AoE_CDs)]
		[CustomComboInfo("Plentiful Harvest", "Adds Plentiful Harvest to the rotation", RPR.JobID)]
		RPR_AoE_PlentifulHarvest = 12106,

		[ParentCombo(RPR_AoE_CDs)]
		[CustomComboInfo("Grim Swathe", "Adds Grim Swathe to the rotation", RPR.JobID)]
		RPR_AoE_GrimSwathe = 12107,

		[ParentCombo(RPR_AoE_CDs)]
		[CustomComboInfo("Gluttony", "Adds Gluttony to the rotation", RPR.JobID)]
		RPR_AoE_Gluttony = 12108,

		[ParentCombo(RPR_AoE_AdvancedMode)]
		[CustomComboInfo("Enshroud", "Adds Enshroud to the rotation", RPR.JobID)]
		RPR_AoE_Enshroud = 12109,

		[ParentCombo(RPR_AoE_AdvancedMode)]
		[CustomComboInfo("Grim Reaping", "Adds Grim Reaping to the rotation.\n(Disabling this may stop the one-button combo working during enshroud)", RPR.JobID)]
		RPR_AoE_Reaping = 12110,

		[ParentCombo(RPR_AoE_AdvancedMode)]
		[CustomComboInfo("Lemure's Scythe", "Adds Lemure's Scythe to the rotation", RPR.JobID)]
		RPR_AoE_Lemure = 12111,

		[ParentCombo(RPR_AoE_AdvancedMode)]
		[CustomComboInfo("Sacrificium", "Adds Sacrificium to the rotation", RPR.JobID)]
		RPR_AoE_Sacrificium = 12112,

		[ParentCombo(RPR_AoE_AdvancedMode)]
		[CustomComboInfo("Communio Finisher", "Adds Communio to the rotation", RPR.JobID)]
		RPR_AoE_Communio = 12113,

		[ParentCombo(RPR_AoE_AdvancedMode)]
		[CustomComboInfo("Perfectio", "Adds Perfectio to the rotation", RPR.JobID)]
		RPR_AoE_Perfectio = 12114,

		[ParentCombo(RPR_AoE_AdvancedMode)]
		[CustomComboInfo("Guillotine", "Adds Guillotine to the rotation", RPR.JobID)]
		RPR_AoE_Guillotine = 12115,

		[ParentCombo(RPR_AoE_AdvancedMode)]
		[CustomComboInfo("Combo Heals", "Adds Bloodbath and Second Wind to the combo, using them when below the HP Percentage threshold", RPR.JobID)]
		RPR_AoE_ComboHeals = 12116,

		[ReplaceSkill(RPR.BloodStalk, RPR.GrimSwathe)]
		[CustomComboInfo("Gluttony on Blood Stalk/Grim Swathe", "Blood Stalk and Grim Swathe will turn into Gluttony when it is available", RPR.JobID)]
		RPR_GluttonyBloodSwathe = 12200,

		[ParentCombo(RPR_GluttonyBloodSwathe)]
		[CustomComboInfo("Gibbet and Gallows/Guillotine on Blood Stalk/Grim Swathe", "Adds (Executioner's) Gibbet and Gallows on Blood Stalk.\nAdds (Executioner's) Guillotine on Grim Swathe", RPR.JobID)]
		RPR_GluttonyBloodSwathe_BloodSwatheCombo = 12201,

		[ParentCombo(RPR_GluttonyBloodSwathe)]
		[CustomComboInfo("Enshroud Combo", "Adds Enshroud combo (Void/Cross Reaping, Communio, Lemure's Slice, Sacrificium and Perfectio) on Blood Stalk and Grim Swathe", RPR.JobID)]
		RPR_GluttonyBloodSwathe_Enshroud = 12202,

		[ReplaceSkill(RPR.ArcaneCircle)]
		[CustomComboInfo("Arcane Circle Harvest", "Replaces Arcane Circle with Plentiful Harvest when you have stacks of Immortal Sacrifice", RPR.JobID)]
		RPR_ArcaneCirclePlentifulHarvest = 12300,

		[ReplaceSkill(RPR.HellsEgress, RPR.HellsIngress)]
		[CustomComboInfo("Regress", "Changes both Hell's Ingress and Hell's Egress turn into Regress when Threshold is active", RPR.JobID)]
		RPR_Regress = 12301,

		[ReplaceSkill(RPR.Slice, RPR.SpinningScythe, RPR.ShadowOfDeath, RPR.Harpe, RPR.BloodStalk)]
		[CustomComboInfo("Soulsow Reminder", "Adds Soulsow to the skills selected below when out of combat. \nWill also add Soulsow to Harpe when in combat and no target is selected", RPR.JobID)]
		RPR_Soulsow = 12302,

		[ReplaceSkill(RPR.Harpe)]
		[ParentCombo(RPR_Soulsow)]
		[CustomComboInfo("Harpe Harvest Moon", "Replaces Harpe with Harvest Moon when you are in combat with Soulsow active", RPR.JobID)]
		RPR_Soulsow_HarpeHarvestMoon = 12303,

		[ReplaceSkill(RPR.Enshroud)]
		[CustomComboInfo("Enshroud Protection", "Turns Enshroud into Gibbet/Gallows to protect Soul Reaver waste", RPR.JobID)]
		RPR_EnshroudProtection = 12304,

		[ReplaceSkill(RPR.Gibbet, RPR.Gallows, RPR.Guillotine)]
		[CustomComboInfo("Communio on Gibbet/Gallows and Guillotine", "Adds Communio to Gibbet/Gallows and Guillotine", RPR.JobID)]
		RPR_CommunioOnGGG = 12305,

		[ParentCombo(RPR_CommunioOnGGG)]
		[CustomComboInfo("Lemure's Slice/Scythe", "Adds Lemure's Slice to Gibbet/Gallows and Lemure's Scythe to Guillotine", RPR.JobID)]
		RPR_LemureOnGGG = 12306,

		[ReplaceSkill(RPR.Enshroud)]
		[CustomComboInfo("Enshroud to Communio to Perfectio", "Turns Enshroud to Communio and Perfectio when available to use", RPR.JobID)]
		RPR_EnshroudCommunio = 12307,

		[ParentCombo(RPR_EnshroudProtection)]
		[CustomComboInfo("True North", "Adds True North when under Gluttony and if Gibbet/Gallowss are selected to replace those skills", RPR.JobID, 0)]
		RPR_TrueNorthEnshroud = 12308,

		[ReplaceSkill(RPR.Harpe)]
		[ParentCombo(RPR_Soulsow)]
		[CustomComboInfo("Soulsow Reminder during Combat", "Adds Soulsow to Harpe during combat when no target is selected", RPR.JobID)]
		RPR_Soulsow_Combat = 12309,

		[ParentCombo(RPR_GluttonyBloodSwathe)]
		[CustomComboInfo("True North", "Adds True North when under Gluttony and if Gibbet/Gallowss are selected to replace those skills", RPR.JobID, 0)]
		RPR_TrueNorthGluttony = 12310,

		[Variant]
		[VariantParent(RPR_ST_AdvancedMode, RPR_AoE_AdvancedMode)]
		[CustomComboInfo("Cure", "Use Variant Cure when HP is below set threshold", RPR.JobID)]
		RPR_Variant_Cure = 12311,

		[Variant]
		[VariantParent(RPR_ST_AdvancedMode, RPR_AoE_AdvancedMode)]
		[CustomComboInfo("Rampart", "Use Variant Rampart on cooldown", RPR.JobID)]
		RPR_Variant_Rampart = 12312,

		#endregion

		#region RED MAGE - 13000

		[ReplaceSkill(RDM.Jolt, RDM.Jolt2)]
		[CustomComboInfo("Single Target DPSs", "Enables various Single Targets below", RDM.JobID, 1)]
		RDM_ST_DPS = 13000,

		[ParentCombo(RDM_ST_DPS)]
		[CustomComboInfo("Balance Opener [Lv.90]", "Replaces Jolt with the Balance opener ending with Resolution.\n**Must move into melee range before melee combo**", RDM.JobID, 110)]
		RDM_Balance_Opener = 13110,

		[ParentCombo(RDM_Balance_Opener)]
		[CustomComboInfo("Use Opener at any Mana", "Removes 0/0 Mana reqirement to reset opener\n**All other actions must be off cooldown**", RDM.JobID, 111)]
		RDM_Balance_Opener_AnyMana = 13111,

		[ParentCombo(RDM_ST_DPS)]
		[CustomComboInfo("Verthunder/Veraero", "Replace Jolt with Verthunder and Veraero", RDM.JobID, 210)]
		RDM_ST_ThunderAero = 13210,

		[ParentCombo(RDM_ST_ThunderAero)]
		[CustomComboInfo("Acceleration", "Add Acceleration when no Verfire/Verstone proc is available", RDM.JobID, 211)]
		RDM_ST_ThunderAero_Accel = 13211,

		[ParentCombo(RDM_ST_ThunderAero_Accel)]
		[CustomComboInfo("Include Swiftcast", "Add Swiftcast when all Acceleration charges are used", RDM.JobID, 212)]
		RDM_ST_ThunderAero_Accel_Swiftcast = 13212,

		[ParentCombo(RDM_ST_DPS)]
		[CustomComboInfo("Verfire/Verstone", "Replace Jolt with Verfire and Verstone", RDM.JobID, 220)]
		RDM_ST_FireStone = 13220,

		[ParentCombo(RDM_ST_DPS)]
		[CustomComboInfo("Weave oGCD Damage", "Weave the following oGCD actions", RDM.JobID, 240)]
		RDM_ST_oGCD = 13240,

		[ParentCombo(RDM_ST_DPS)]
		[CustomComboInfo("Single Target Melee Combo", "Add the Reposte combo.\n**Must be in melee range or have Gap close with Corps-a-corps enabled**", RDM.JobID, 410)]
		RDM_ST_MeleeCombo = 13410,

		[ParentCombo(RDM_ST_MeleeCombo)]
		[CustomComboInfo("Use Manafication and Embolden", "Add Manafication and Embolden.\n**Must be in melee range or have Gap close with Corps-a-corps enabled**", RDM.JobID, 411)]
		RDM_ST_MeleeCombo_ManaEmbolden = 13411,

		[ParentCombo(RDM_ST_MeleeCombo_ManaEmbolden)]
		[CustomComboInfo("Hold for Double Melee Combo [Lv.90]", "Hold both actions until you can perform a double melee combo", RDM.JobID, 412)]
		RDM_ST_MeleeCombo_ManaEmbolden_DoubleCombo = 13412,

		[ParentCombo(RDM_ST_MeleeCombo)]
		[CustomComboInfo("Gap close with Corps-a-corps", "Use Corp-a-corps when out of melee range and you have enough mana to start the melee combo", RDM.JobID, 430)]
		RDM_ST_MeleeCombo_CorpsGapCloser = 13430,

		[ParentCombo(RDM_ST_MeleeCombo)]
		[CustomComboInfo("Unbalance Mana", "Use Acceleration to unbalance mana prior to starting melee combo", RDM.JobID, 410)]
		RDM_ST_MeleeCombo_UnbalanceMana = 13440,

		[ParentCombo(RDM_ST_DPS)]
		[CustomComboInfo("Melee Finisher", "Add Verflare/Verholy and other finishing moves", RDM.JobID, 510)]
		RDM_ST_MeleeFinisher = 13510,

		[ParentCombo(RDM_ST_DPS)]
		[CustomComboInfo("Lucid Dreaming", "Adds Lucid Dreaming when MP drops below the slider value", RDM.JobID, 610)]
		RDM_ST_Lucid = 13610,

		[ReplaceSkill(RDM.Scatter, RDM.Impact)]
		[CustomComboInfo("AoE DPS", "Enables various AoE Targets below", RDM.JobID, 310)]
		RDM_AoE_DPS = 13310,

		[ParentCombo(RDM_AoE_DPS)]
		[ReplaceSkill(RDM.Scatter, RDM.Impact)]
		[CustomComboInfo("AoE Acceleration", "Use Acceleration for increased damage", RDM.JobID, 320)]
		RDM_AoE_Accel = 13320,

		[ParentCombo(RDM_AoE_Accel)]
		[CustomComboInfo("Include Swiftcast", "Add Swiftcast when all Acceleration charges are used or when below level 50", RDM.JobID, 321)]
		RDM_AoE_Accel_Swiftcast = 13321,

		[ParentCombo(RDM_AoE_Accel)]
		[CustomComboInfo("Weave Acceleration", "Only use acceleration during weave windows", RDM.JobID, 322)]
		RDM_AoE_Accel_Weave = 13322,

		[ParentCombo(RDM_AoE_DPS)]
		[CustomComboInfo("Weave oGCD Damage", "Weave the following oGCD actions:", RDM.JobID, 240)]
		RDM_AoE_oGCD = 13241,

		[ParentCombo(RDM_AoE_DPS)]
		[CustomComboInfo("Moulinet Melee Combo", "Use Moulinet when over 50/50 mana", RDM.JobID, 420)]
		RDM_AoE_MeleeCombo = 13420,

		[ParentCombo(RDM_AoE_MeleeCombo)]
		[CustomComboInfo("Use Manafication and Embolden", "Add Manafication and Embolden.\n**Must be in range of Moulinet**", RDM.JobID, 411)]
		RDM_AoE_MeleeCombo_ManaEmbolden = 13421,

		[ParentCombo(RDM_AoE_MeleeCombo)]
		[CustomComboInfo("Gap close with Corps-a-corps", "Use Corp-a-corps when out of melee range and you have enough mana to start the melee combo", RDM.JobID, 430)]
		RDM_AoE_MeleeCombo_CorpsGapCloser = 13422,

		[ParentCombo(RDM_AoE_DPS)]
		[CustomComboInfo("Melee Finisher", "Add Verflare/Verholy and other finishing moves", RDM.JobID, 510)]
		RDM_AoE_MeleeFinisher = 13424,

		[ParentCombo(RDM_AoE_DPS)]
		[CustomComboInfo("Lucid Dreaming", "Adds Lucid Dreaming when MP drops below the slider value", RDM.JobID, 610)]
		RDM_AoE_Lucid = 13425,

		[ReplaceSkill(All.Swiftcast)]
		[ConflictingCombos(ALL_Caster_Raise)]
		[CustomComboInfo("Verraise", "Changes Swiftcast to Verraise when under the effect of Swiftcast or Dualcast", RDM.JobID, 620)]
		RDM_Raise = 13620,

		[ReplaceSkill(RDM.Displacement)]
		[CustomComboInfo("Displacement <> Corps-a-corps", "Replace Displacement with Corps-a-corps when out of range", RDM.JobID, 810)]
		RDM_CorpsDisplacement = 13810,

		[ReplaceSkill(RDM.Embolden)]
		[CustomComboInfo("Embolden to Manafication", "Changes Embolden to Manafication when on cooldown", RDM.JobID, 820)]
		RDM_EmboldenManafication = 13820,

		[ReplaceSkill(RDM.MagickBarrier)]
		[CustomComboInfo("Magick Barrier to Addle", "Changes Magick Barrier to Addle when on cooldown", RDM.JobID, 820)]
		RDM_MagickBarrierAddle = 13821,

		[ReplaceSkill(RDM.Embolden)]
		[CustomComboInfo("Embolden Overlap Protection", "Disables Embolden when buffed by another Red Mage's Embolden", RDM.JobID, 820)]
		RDM_EmboldenProtection = 13835,

		[ReplaceSkill(RDM.MagickBarrier)]
		[CustomComboInfo("Magick Barrier Overlap Protection", "Disables Magick Barrier when buffed by another Red Mage's Magick Barrier", RDM.JobID, 820)]
		RDM_MagickProtection = 13836,

		[Variant]
		[VariantParent(RDM_ST_DPS, RDM_AoE_DPS)]
		[CustomComboInfo("Rampart", "Use Variant Rampart on cooldown. Replaces Jolts", RDM.JobID)]
		RDM_Variant_Rampart = 13830,

		[Variant]
		[VariantParent(RDM_Raise)]
		[CustomComboInfo("Raise", "Turn Swiftcast into Variant Raise whenever you have the Swiftcast or Dualcast buffs", RDM.JobID)]
		RDM_Variant_Raise = 13831,

		[Variant]
		[VariantParent(RDM_ST_DPS, RDM_AoE_DPS)]
		[CustomComboInfo("Cure", "Use Variant Cure when HP is below set threshold. Replaces Jolts", RDM.JobID)]
		RDM_Variant_Cure = 13832,

		[Variant]
		[CustomComboInfo("Cure on Vercure", "Replaces Vercure with Variant Cure", RDM.JobID)]
		RDM_Variant_Cure2 = 13833,

		#endregion

		#region SAGE - 14000

		[ReplaceSkill(SGE.Dosis, SGE.Dosis2, SGE.Dosis3)]
		[CustomComboInfo("Single Target", "", SGE.JobID, 1)]
		SGE_ST_DPS = 14001,

		[ParentCombo(SGE_ST_DPS)]
		[CustomComboInfo("Lucid Dreaming", "Adds Lucid Dreaming when MP drops below the slider value", SGE.JobID)]
		SGE_ST_DPS_Lucid = 14002,

		[ParentCombo(SGE_ST_DPS)]
		[CustomComboInfo("Eukrasian Dosis", "Automatic DoT Uptime", SGE.JobID)]
		SGE_ST_DPS_EDosis = 14003,

		[ParentCombo(SGE_ST_DPS)]
		[CustomComboInfo("Movement", "Use selected instant cast actions while moving", SGE.JobID)]
		SGE_ST_DPS_Movement = 14004,

		[ParentCombo(SGE_ST_DPS)]
		[CustomComboInfo("Phlegma", "Use Phlegma if available and within range", SGE.JobID)]
		SGE_ST_DPS_Phlegma = 14005,

		[ParentCombo(SGE_ST_DPS)]
		[CustomComboInfo("Kardia Reminder", "Adds Kardia when not under the effect", SGE.JobID)]
		SGE_ST_DPS_Kardia = 14006,

		[ParentCombo(SGE_ST_DPS)]
		[CustomComboInfo("Rhizomata", "Weaves Rhizomata when Addersgall gauge falls below the specified value", SGE.JobID)]
		SGE_ST_DPS_Rhizo = 14007,

		[ParentCombo(SGE_ST_DPS)]
		[CustomComboInfo("Psych", "Weaves Psych when available", SGE.JobID)]
		SGE_ST_DPS_Psyche = 14008,

		[ParentCombo(SGE_ST_DPS)]
		[CustomComboInfo("Addersgall Overflow Protection", "Weaves Druochole when Addersgall gauge is greater than or equal to the specified value", SGE.JobID)]
		SGE_ST_DPS_AddersgallProtect = 14009,

		[ReplaceSkill(SGE.Dyskrasia, SGE.Dyskrasia2)]
		[CustomComboInfo("AoE DPS", "Adds variouss to Dyskrasia I & II. Requires a target", SGE.JobID, 2)]
		SGE_AoE_DPS = 14020,

		[ParentCombo(SGE_AoE_DPS)]
		[CustomComboInfo("Phlegma", "Uses Phlegma if available", SGE.JobID)]
		SGE_AoE_DPS_Phlegma = 14021,

		[ParentCombo(SGE_AoE_DPS)]
		[CustomComboInfo("Toxikon", "Use Toxikon if available", SGE.JobID)]
		SGE_AoE_DPS_Toxikon = 14022,

		[ParentCombo(SGE_AoE_DPS)]
		[CustomComboInfo("Psyche", "Weaves Psyche if available", SGE.JobID)]
		SGE_AoE_DPS_Psyche = 14023,

		[ParentCombo(SGE_AoE_DPS)]
		[CustomComboInfo("Eukrasia", "Uses Eukrasia for Eukrasia Dyskrasia", SGE.JobID)]
		SGE_AoE_DPS_EDyskrasia = 14024,

		[ParentCombo(SGE_AoE_DPS)]
		[CustomComboInfo("Lucid Dreaming", "Adds Lucid Dreaming when MP drops below the slider value", SGE.JobID)]
		SGE_AoE_DPS_Lucid = 14025,

		[ParentCombo(SGE_AoE_DPS)]
		[CustomComboInfo("Rhizomata", "Weaves Rhizomata when Addersgall gauge falls below the specified value", SGE.JobID)]
		SGE_AoE_DPS_Rhizo = 14026,

		[ParentCombo(SGE_AoE_DPS)]
		[CustomComboInfo("Addersgall Overflow Protection", "Weaves Druochole when Addersgall gauge is greater than or equal to the specified value", SGE.JobID)]
		SGE_AoE_DPS_AddersgallProtect = 14027,

		[ReplaceSkill(SGE.Diagnosis)]
		[CustomComboInfo("Single Target Heals", "Supports soft-targeting", SGE.JobID, 3)]
		SGE_ST_Heal = 14040,

		[ParentCombo(SGE_ST_Heal)]
		[CustomComboInfo("Esuna", "Applies Esuna to your target if there is a cleansable debuff", SGE.JobID)]
		SGE_ST_Heal_Esuna = 14041,

		[ParentCombo(SGE_ST_Heal)]
		[CustomComboInfo("Kardia", "Applies Kardia to your target if it's not applied to anyone else", SGE.JobID)]
		SGE_ST_Heal_Kardia = 14042,

		[ParentCombo(SGE_ST_Heal)]
		[CustomComboInfo("Eukrasian Diagnosis", "Diagnosis becomes Eukrasian Diagnosis if the shield is not applied to the target", SGE.JobID)]
		SGE_ST_Heal_EDiagnosis = 14043,

		[ParentCombo(SGE_ST_Heal)]
		[CustomComboInfo("Soteria", "Applies Soteria", SGE.JobID)]
		SGE_ST_Heal_Soteria = 14044,

		[ParentCombo(SGE_ST_Heal)]
		[CustomComboInfo("Zoe", "Applies Zoe", SGE.JobID)]
		SGE_ST_Heal_Zoe = 14045,

		[ParentCombo(SGE_ST_Heal)]
		[CustomComboInfo("Pepsis", "Triggers Pepsis if a shield is present", SGE.JobID)]
		SGE_ST_Heal_Pepsis = 14046,

		[ParentCombo(SGE_ST_Heal)]
		[CustomComboInfo("Taurochole", "Adds Taurochole", SGE.JobID)]
		SGE_ST_Heal_Taurochole = 14047,

		[ParentCombo(SGE_ST_Heal)]
		[CustomComboInfo("Haima", "Applies Haima", SGE.JobID)]
		SGE_ST_Heal_Haima = 14048,

		[ParentCombo(SGE_ST_Heal)]
		[CustomComboInfo("Rhizomata", "Adds Rhizomata when Addersgall is 0", SGE.JobID)]
		SGE_ST_Heal_Rhizomata = 14049,

		[ParentCombo(SGE_ST_Heal)]
		[CustomComboInfo("Krasis", "Applies Krasis", SGE.JobID)]
		SGE_ST_Heal_Krasis = 14050,

		[ParentCombo(SGE_ST_Heal)]
		[CustomComboInfo("Druochole", "Applies Druochole", SGE.JobID)]
		SGE_ST_Heal_Druochole = 14051,

		[ParentCombo(SGE_ST_Heal)]
		[CustomComboInfo("Lucid Dreaming", "Adds Lucid Dreaming when MP drops below the slider value", SGE.JobID)]
		SGE_ST_Heal_Lucid = 14052,

		[ReplaceSkill(SGE.Prognosis)]
		[CustomComboInfo("AoE Heals", "Customize your AoE healing to your liking", SGE.JobID, 4)]
		SGE_AoE_Heal = 14060,

		[ParentCombo(SGE_AoE_Heal)]
		[CustomComboInfo("Physis", "Adds Physis", SGE.JobID)]
		SGE_AoE_Heal_Physis = 14061,

		[ParentCombo(SGE_AoE_Heal)]
		[CustomComboInfo("Philosophia", "Adds Philosophia", SGE.JobID)]
		SGE_AoE_Heal_Philosophia = 14062,

		[ParentCombo(SGE_AoE_Heal)]
		[CustomComboInfo("Eukrasian Prognosis", "Prognosis becomes Eukrasian Prognosis if the shield is not applied", SGE.JobID)]
		SGE_AoE_Heal_EPrognosis = 14063,

		[ParentCombo(SGE_AoE_Heal_EPrognosis)]
		[CustomComboInfo("Ignore Shield Check", "Warning, will force the use of Eukrasia Prognosis, and normal Prognosis will be unavailable", SGE.JobID)]
		SGE_AoE_Heal_EPrognosis_IgnoreShield = 14064,

		[ParentCombo(SGE_AoE_Heal)]
		[CustomComboInfo("Holos", "Adds Holos", SGE.JobID)]
		SGE_AoE_Heal_Holos = 14065,

		[ParentCombo(SGE_AoE_Heal)]
		[CustomComboInfo("Panhaima", "Adds Panhaima", SGE.JobID)]
		SGE_AoE_Heal_Panhaima = 14066,

		[ParentCombo(SGE_AoE_Heal)]
		[CustomComboInfo("Pepsis", "Triggers Pepsis if a shield is present", SGE.JobID)]
		SGE_AoE_Heal_Pepsis = 14067,

		[ParentCombo(SGE_AoE_Heal)]
		[CustomComboInfo("Ixochole", "Adds Ixochole", SGE.JobID)]
		SGE_AoE_Heal_Ixochole = 14068,

		[ParentCombo(SGE_AoE_Heal)]
		[CustomComboInfo("Kerachole", "Adds Kerachole", SGE.JobID)]
		SGE_AoE_Heal_Kerachole = 14069,

		[ParentCombo(SGE_AoE_Heal)]
		[CustomComboInfo("Rhizomata", "Adds Rhizomata when Addersgall is 0", SGE.JobID)]
		SGE_AoE_Heal_Rhizomata = 14070,

		[ParentCombo(SGE_AoE_Heal)]
		[CustomComboInfo("Lucid Dreaming", "Adds Lucid Dreaming when MP drops below the slider value", SGE.JobID)]
		SGE_AoE_Heal_Lucid = 14071,

		[ReplaceSkill(All.Swiftcast)]
		[CustomComboInfo("Swiftcast Raise", "Changes Swiftcast to Egeiro while Swiftcast is on cooldown", SGE.JobID)]
		SGE_Raise = 14080,

		[ReplaceSkill(SGE.Soteria)]
		[CustomComboInfo("Soteria to Kardia", "Soteria turns into Kardia when not active or Soteria is on-cooldown", SGE.JobID)]
		SGE_Kardia = 14081,

		[ReplaceSkill(SGE.Eukrasia)]
		[CustomComboInfo("Eukrasia", "Eukrasia turns into the selected Eukrasian-type action when active", SGE.JobID)]
		SGE_Eukrasia = 14082,

		[ReplaceSkill(SGE.Kerachole)]
		[CustomComboInfo("Spell Overlap Protection", "Prevents you from wasting actions if under the effect of someone else's actions", SGE.JobID)]
		SGE_OverProtect = 14083,

		[ParentCombo(SGE_OverProtect)]
		[CustomComboInfo("Under Kerachole", "Don't use Kerachole when under the effect of someone's Kerachole", SGE.JobID)]
		SGE_OverProtect_Kerachole = 14084,

		[ParentCombo(SGE_OverProtect_Kerachole)]
		[CustomComboInfo("Under Sacred Soil", "Don't use Kerachole when under the effect of someone's Sacred Soil", SGE.JobID)]
		SGE_OverProtect_SacredSoil = 14085,

		[ParentCombo(SGE_OverProtect)]
		[CustomComboInfo("Under Panhaima", "Don't use Panhaima when under the effect of someone's Panhaima", SGE.JobID)]
		SGE_OverProtect_Panhaima = 14086,

		[ParentCombo(SGE_OverProtect)]
		[CustomComboInfo("Under Philosophia", "Don't use Philosophia when under the effect of someone's Philosophia", SGE.JobID)]
		SGE_OverProtect_Philosophia = 14087,

		[ReplaceSkill(SGE.Taurochole, SGE.Druochole, SGE.Ixochole, SGE.Kerachole)]
		[CustomComboInfo("Rhizomata", "Replaces Addersgall skills with Rhizomata when empty", SGE.JobID)]
		SGE_Rhizo = 14090,

		[ReplaceSkill(SGE.Druochole)]
		[CustomComboInfo("Druochole to Taurochole", "Upgrades Druochole to Taurochole when Taurochole is available", SGE.JobID)]
		SGE_DruoTauro = 14091,

		[ReplaceSkill(SGE.Pneuma)]
		[CustomComboInfo("Zoe to Pneuma", "Places Zoe on top of Pneuma when both actions are on cooldown", SGE.JobID)]
		SGE_ZoePneuma = 14092,

		[Variant]
		[VariantParent(SGE_ST_DPS_EDosis, SGE_AoE_DPS)]
		[CustomComboInfo("Spirit Dart", "Use Variant Spirit Dart whenever the debuff is not present or less than 3s", SGE.JobID)]
		SGE_DPS_Variant_SpiritDart = 14100,

		[Variant]
		[VariantParent(SGE_ST_DPS, SGE_AoE_DPS)]
		[CustomComboInfo("Rampart", "Use Variant Rampart on cooldown", SGE.JobID)]
		SGE_DPS_Variant_Rampart = 14101,

		#endregion

		#region SAMURAI - 15000

		[ReplaceSkill(SAM.Kasha, SAM.Gekko, SAM.Yukikaze)]
		[CustomComboInfo("Samurai Overcap", "Adds Shinten onto main combo when Kenki is at the selected amount or more", SAM.JobID)]
		SAM_ST_Overcap = 15001,

		[ReplaceSkill(SAM.Mangetsu, SAM.Oka)]
		[CustomComboInfo("Samurai AoE Overcap", "Adds Kyuten onto main AoE combos when Kenki is at the selected amount or more", SAM.JobID)]
		SAM_AoE_Overcap = 15002,

		[ReplaceSkill(SAM.Gekko)]
		[CustomComboInfo("Gekko Combo", "Replace Gekko with its combo chain.\nIf all subs are selected will turn into a full one button rotation (Advanced Samurai)", SAM.JobID)]
		SAM_ST_GekkoCombo = 15003,

		[ParentCombo(SAM_ST_GekkoCombo)]
		[CustomComboInfo("Enpi Uptime", "Replace main combo with Enpi when you are out of range", SAM.JobID)]
		SAM_ST_GekkoCombo_RangedUptime = 15004,

		[ParentCombo(SAM_ST_GekkoCombo)]
		[CustomComboInfo("Yukikaze Combo on Main Combo", "Adds Yukikaze combo to main combo. Will add Yukikaze during Meikyo Shisui as well", SAM.JobID)]
		SAM_ST_GekkoCombo_Yukikaze = 15005,

		[ParentCombo(SAM_ST_GekkoCombo)]
		[CustomComboInfo("Kasha Combo on Main Combo", "Adds Kasha combo to main combo. Will add Kasha during Meikyo Shisui as well", SAM.JobID)]
		SAM_ST_GekkoCombo_Kasha = 15006,

		[ConflictingCombos(SAM_GyotenYaten)]
		[ParentCombo(SAM_ST_GekkoCombo)]
		[CustomComboInfo("Level 90 Samurai Opener", "Adds the Level 90 Opener to the main combo.\nOpener triggered by using Meikyo Shisui before combat. If you have any Sen, Hagakure will be used to clear them.\nWill work at any levels of Kenki, requires 2 charges of Meikyo Shisui and all CDs ready. If conditions aren't met it will skip into the regular rotation. \nIf the Opener is interrupted, it will exit the opener via a Goken and a Kaeshi: Goken at the end or via the last Yukikaze. If the latter, CDs will be used on cooldown regardless of bursts", SAM.JobID)]
		SAM_ST_GekkoCombo_Opener = 15007,

		[ConflictingCombos(SAM_GyotenYaten)]
		[ParentCombo(SAM_ST_GekkoCombo)]
		[CustomComboInfo("Filler Combo", "Adds selected Filler combos to main combo at the appropriate time.\nChoose Skill Speed tier with Fuka buff below.\nWill disable if you die or if you don't activate the opener", SAM.JobID)]
		SAM_ST_GekkoCombo_FillerCombos = 15008,

		[ParentCombo(SAM_ST_GekkoCombo)]
		[CustomComboInfo("CDs on Main Combo", "Collection of CDs on main combo", SAM.JobID)]
		SAM_ST_GekkoCombo_CDs = 15099,

		[ParentCombo(SAM_ST_GekkoCombo_CDs)]
		[CustomComboInfo("Ikishoten on Main Combo", "Adds Ikishoten when at or below 50 Kenki.\nWill dump Kenki at 10 seconds left to allow Ikishoten to be used", SAM.JobID)]
		SAM_ST_GekkoCombo_CDs_Ikishoten = 15009,

		[ParentCombo(SAM_ST_GekkoCombo_CDs)]
		[CustomComboInfo("Iaijutsu on Main Combo", "Adds Midare: Setsugekka, Higanbana, and Kaeshi: Setsugekka when ready and when you're not moving to main combo", SAM.JobID)]
		SAM_ST_GekkoCombo_CDs_Iaijutsu = 15010,

		[ParentCombo(SAM_ST_GekkoCombo_CDs)]
		[CustomComboInfo("Ogi Namikiri on Main Combo", "Ogi Namikiri and Kaeshi: Namikiri when ready and when you're not moving to main combo", SAM.JobID)]
		SAM_ST_GekkoCombo_CDs_OgiNamikiri = 15011,

		[ParentCombo(SAM_ST_GekkoCombo_CDs_OgiNamikiri)]
		[CustomComboInfo("Ogi Namikiri Burst", "Saves Ogi Namikiri for even minute burst windows.\nIf you don't activate the opener or die, Ogi Namikiri will instead be used on CD", SAM.JobID)]
		SAM_ST_GekkoCombo_CDs_OgiNamikiri_Burst = 15012,

		[ParentCombo(SAM_ST_GekkoCombo_CDs)]
		[CustomComboInfo("Meikyo Shisui on Main Combo", "Adds Meikyo Shisui to main combo when off cooldown", SAM.JobID)]
		SAM_ST_GekkoCombo_CDs_MeikyoShisui = 15013,

		[ParentCombo(SAM_ST_GekkoCombo_CDs_MeikyoShisui)]
		[CustomComboInfo("Meikyo Shisui Burst", "Saves Meikyo Shisui for burst windows.\nIf you don't activate the opener or die, Meikyo Shisui will instead be used on CD", SAM.JobID)]
		SAM_ST_GekkoCombo_CDs_MeikyoShisui_Burst = 15014,

		[ParentCombo(SAM_ST_GekkoCombo_CDs)]
		[CustomComboInfo("Shoha on Main Combo", "Adds Shoha to main combo when there are three meditation stacks", SAM.JobID)]
		SAM_ST_GekkoCombo_CDs_Shoha = 15015,

		[ConflictingCombos(SAM_Shinten_Shoha_Senei)]
		[ParentCombo(SAM_ST_GekkoCombo_CDs)]
		[CustomComboInfo("Senei on Main Combo", "Adds Senei to main combo when off cooldown and above 25 Kenki", SAM.JobID)]
		SAM_ST_GekkoCombo_CDs_Senei = 15016,

		[ParentCombo(SAM_ST_GekkoCombo_CDs_Senei)]
		[CustomComboInfo("Senei Burst", "Saves Senei for even minute burst windows.\nIf you don't activate the opener or die, Senei will instead be used on CD", SAM.JobID)]
		SAM_ST_GekkoCombo_CDs_Senei_Burst = 15017,

		[ParentCombo(SAM_ST_Overcap)]
		[CustomComboInfo("Execute", "Adds Shinten to the main combo when Kenki > 25 and your current target is below the HP percentage threshold", SAM.JobID)]
		SAM_ST_Execute = 15046,

		[ReplaceSkill(SAM.Yukikaze)]
		[CustomComboInfo("Yukikaze Combo", "Replace Yukikaze with its combo chain", SAM.JobID)]
		SAM_ST_YukikazeCombo = 15018,

		[ReplaceSkill(SAM.Kasha)]
		[CustomComboInfo("Kasha Combo", "Replace Kasha with its combo chain", SAM.JobID)]
		SAM_ST_KashaCombo = 15019,

		[ReplaceSkill(SAM.Mangetsu)]
		[CustomComboInfo("Mangetsu Combo", "Replace Mangetsu with its combo chain.\nIf all subs are toggled will turn into a full one button AoE rotation", SAM.JobID)]
		SAM_AoE_MangetsuCombo = 15020,

		[ParentCombo(SAM_AoE_MangetsuCombo)]
		[ConflictingCombos(SAM_AoE_OkaCombo_TwoTarget)]
		[CustomComboInfo("Oka to Mangetsu Combo", "Adds Oka combo after Mangetsu combo loop.\nWill add Oka if needed during Meikyo Shisui", SAM.JobID)]
		SAM_AoE_MangetsuCombo_Oka = 15021,

		[ParentCombo(SAM_AoE_MangetsuCombo)]
		[CustomComboInfo("Iaijutsu on Mangetsu Combo", "Adds Tenka Goken, Midare: Setsugekka, and Kaeshi: Goken when ready and when you're not moving to Mangetsu combo", SAM.JobID)]
		SAM_AoE_MangetsuCombo_TenkaGoken = 15022,

		[ParentCombo(SAM_AoE_MangetsuCombo)]
		[CustomComboInfo("Ogi Namikiri on Mangetsu Combo", "Adds Ogi Namikiri and Kaeshi: Namikiri when ready and when you're not moving to Mangetsu combo", SAM.JobID)]
		SAM_AoE_MangetsuCombo_OgiNamikiri = 15023,

		[ParentCombo(SAM_AoE_MangetsuCombo)]
		[CustomComboInfo("Shoha 2 on Mangetsu Combo", "Adds Shoha 2 when you have 3 meditation stacks to Mangetsu combo", SAM.JobID)]
		SAM_AoE_MangetsuCombo_Shoha2 = 15024,

		[ConflictingCombos(SAM_Kyuten_Shoha2_Guren)]
		[ParentCombo(SAM_AoE_MangetsuCombo)]
		[CustomComboInfo("Guren on Mangetsu Combo", "Adds Guren when it's off cooldown and you have 25 Kenki to Mangetsu combo", SAM.JobID)]
		SAM_AoE_MangetsuCombo_Guren = 15025,

		[ParentCombo(SAM_AoE_MangetsuCombo)]
		[CustomComboInfo("Meikyo Shisui on Mangetsu Combo", "Adds Meikyo Shisui to Mangetsu combo", SAM.JobID)]
		SAM_AoE_MangetsuCombo_MeikyoShisui = 15039,

		[ParentCombo(SAM_AoE_MangetsuCombo)]
		[CustomComboInfo("Ikishoten on Mangetsu Combo", "Adds Ikishoten when at or below 50 Kenki.\nWill dump Kenki at 10 seconds left to allow Ikishoten to be used", SAM.JobID)]
		SAM_AOE_GekkoCombo_CDs_Ikishoten = 15040,

		[ParentCombo(SAM_AoE_MangetsuCombo)]
		[CustomComboInfo("Hagakure on Mangetsu Combo", "Adds Hagakure to Mangetsu combo when there are three Sen", SAM.JobID)]
		SAM_AoE_MangetsuCombo_Hagakure = 15041,

		[ReplaceSkill(SAM.Oka)]
		[CustomComboInfo("Oka Combo", "Replace Oka with its combo chain", SAM.JobID)]
		SAM_AoE_OkaCombo = 15026,

		[ParentCombo(SAM_AoE_OkaCombo)]
		[ConflictingCombos(SAM_AoE_MangetsuCombo_Oka)]
		[CustomComboInfo("Oka Two Target Rotation", "Adds the Yukikaze combo, Mangetsu combo, Senei, Shinten, and Shoha to Oka combo.\nUsed for two targets only and when Lv86 and above", SAM.JobID)]
		SAM_AoE_OkaCombo_TwoTarget = 150261,

		[ReplaceSkill(SAM.MeikyoShisui)]
		[CustomComboInfo("Jinpu/Shifu", "Replace Meikyo Shisui with Jinpu, Shifu, and Yukikaze depending on what is needed", SAM.JobID)]
		SAM_JinpuShifu = 15027,

		[ReplaceSkill(SAM.Iaijutsu)]
		[CustomComboInfo("Iaijutsus", "Collection of Iaijutsus", SAM.JobID)]
		SAM_Iaijutsu = 15028,

		[ParentCombo(SAM_Iaijutsu)]
		[CustomComboInfo("Iaijutsu to Tsubame-Gaeshi", "Replace Iaijutsu with  Tsubame-gaeshi when Sen is empty", SAM.JobID)]
		SAM_Iaijutsu_TsubameGaeshi = 15029,

		[ParentCombo(SAM_Iaijutsu)]
		[CustomComboInfo("Iaijutsu to Shoha", "Replace Iaijutsu with Shoha when meditation is 3", SAM.JobID)]
		SAM_Iaijutsu_Shoha = 15030,

		[ParentCombo(SAM_Iaijutsu)]
		[CustomComboInfo("Iaijutsu to Ogi Namikiri", "Replace Iaijutsu with Ogi Namikiri and Kaeshi: Namikiri when buffed with Ogi Namikiri Ready", SAM.JobID)]
		SAM_Iaijutsu_OgiNamikiri = 15031,

		[ReplaceSkill(SAM.Shinten)]
		[CustomComboInfo("Shinten to Shoha", "Replace Hissatsu: Shinten with Shoha when Meditation is full", SAM.JobID)]
		SAM_Shinten_Shoha = 15032,

		[ConflictingCombos(SAM_ST_GekkoCombo_CDs_Senei)]
		[ParentCombo(SAM_Shinten_Shoha)]
		[CustomComboInfo("Shinten to Senei", "Replace Hissatsu: Shinten with Senei when its cooldown is up", SAM.JobID)]
		SAM_Shinten_Shoha_Senei = 15033,

		[ReplaceSkill(SAM.Kyuten)]
		[CustomComboInfo("Kyuten to Shoha II", "Replace Hissatsu: Kyuten with Shoha II when Meditation is full", SAM.JobID)]
		SAM_Kyuten_Shoha2 = 15034,

		[ConflictingCombos(SAM_AoE_MangetsuCombo_Guren)]
		[ParentCombo(SAM_Kyuten_Shoha2)]
		[CustomComboInfo("Kyuten to Guren", "Replace Hissatsu: Kyuten with Guren when its cooldown is up", SAM.JobID)]
		SAM_Kyuten_Shoha2_Guren = 15035,

		[ConflictingCombos(SAM_ST_GekkoCombo_Opener, SAM_ST_GekkoCombo_FillerCombos)]
		[ReplaceSkill(SAM.Gyoten)]
		[CustomComboInfo("Gyoten", "Hissatsu: Gyoten becomes Yaten/Gyoten depending on the distance from your target", SAM.JobID)]
		SAM_GyotenYaten = 15036,

		[ReplaceSkill(SAM.Ikishoten)]
		[CustomComboInfo("Ikishoten Namikiri", "Replace Ikishoten with Ogi Namikiri and then Kaeshi Namikiri when available.\nIf you have full Meditation stacks, Ikishoten becomes Shoha while you have Ogi Namikiri ready", SAM.JobID)]
		SAM_Ikishoten_OgiNamikiri = 15037,

		[ReplaceSkill(SAM.Gekko, SAM.Yukikaze, SAM.Kasha)]
		[CustomComboInfo("True North", "Adds True North on all single target combos if Meikyo Shisui's buff is on you", SAM.JobID)]
		SAM_TrueNorth = 15038,

		[ParentCombo(SAM_ST_GekkoCombo)]
		[CustomComboInfo("Combo Heals", "Adds Bloodbath and Second Wind to the combo, using them when below the HP Percentage threshold", SAM.JobID)]
		SAM_ST_ComboHeals = 15043,

		[ParentCombo(SAM_AoE_MangetsuCombo)]
		[CustomComboInfo("Combo Heals", "Adds Bloodbath and Second Wind to the combo, using them when below the HP Percentage threshold", SAM.JobID)]
		SAM_AoE_ComboHeals = 15045,

		[Variant]
		[VariantParent(SAM_ST_GekkoCombo, SAM_AoE_MangetsuCombo)]
		[CustomComboInfo("Cure", "Use Variant Cure when HP is below set threshold", SAM.JobID)]
		SAM_Variant_Cure = 15047,

		[Variant]
		[VariantParent(SAM_ST_GekkoCombo, SAM_AoE_MangetsuCombo)]
		[CustomComboInfo("Rampart", "Use Variant Rampart on cooldown", SAM.JobID)]
		SAM_Variant_Rampart = 15048,

		#endregion

		#region SCHOLAR - 16000

		#region Single Target

		[ReplaceSkill(SCH.Ruin, SCH.Broil, SCH.Broil2, SCH.Broil3, SCH.Broil4)]
		[CustomComboInfo("Single Target DPS", "Replaces Broil with below", SCH.JobID, 1)]
		SCH_DPS = 16001,

		[ParentCombo(SCH_DPS)]
		[CustomComboInfo("Bio / Biolysis", "Automatic DoT uptime", SCH.JobID, 1)]
		SCH_DPS_Bio = 16008,

		[ParentCombo(SCH_DPS)]
		[CustomComboInfo("Aetherflow", "Use Aetherflow when out of Aetherflow stacks", SCH.JobID, 2)]
		SCH_DPS_Aetherflow = 16004,

		[ParentCombo(SCH_DPS)]
		[CustomComboInfo("Energy Drain", "Use Energy Drain to consume remaining Aetherflow stacks when Aetherflow is about to come off cooldown", SCH.JobID, 3)]
		SCH_DPS_EnergyDrain = 16005,

		[ParentCombo(SCH_DPS_EnergyDrain)]
		[CustomComboInfo("Energy Drain Burst", "Holds Energy Drain when Chain Stratagem is ready or has less than 10 seconds cooldown remaining", SCH.JobID)]
		SCH_DPS_EnergyDrain_BurstSaver = 16006,

		[ParentCombo(SCH_DPS_EnergyDrain)]
		[CustomComboInfo("Check Dissipation cooldown", "If enabled, Energy Drain will take both Aetherflow and Dissipation cooldowns into account. If Dissipation is available, it will dump all Aetherflow stacks", SCH.JobID)]
		SCH_ST_DPS_ED_Dissipation = 16010,

		[ParentCombo(SCH_DPS)]
		[CustomComboInfo("Dissipation", "Use Dissipation", SCH.JobID, 4)]
		SCH_DPS_Dissipation = 16009,

		[ParentCombo(SCH_DPS)]
		[CustomComboInfo("Aetherpact", "Use Aetherpact at 100 gauge", SCH.JobID, 5)]
		SCH_DPS_Aetherpact = 16011,

		[ParentCombo(SCH_DPS)]
		[CustomComboInfo("Seraph", "Use Seraph charges when 2 sec left", SCH.JobID, 5)]
		SCH_DPS_Seraph = 16012,

		[ParentCombo(SCH_DPS)]
		[CustomComboInfo("Chain Stratagem / Baneful Impact", "Adds Chain Stratagem & Baneful Impact on cooldown with overlap protection", SCH.JobID, 6)]
		SCH_DPS_ChainStrat = 16003,

		[ParentCombo(SCH_DPS)]
		[CustomComboInfo("Ruin II Movement", "Use Ruin II when you have to move", SCH.JobID, 7)]
		SCH_DPS_Ruin2Movement = 16007,

		[ParentCombo(SCH_DPS)]
		[CustomComboInfo("Lucid Dreaming", "Adds Lucid Dreaming when MP drops below the slider value", SCH.JobID)]
		SCH_DPS_Lucid = 16002,

		#endregion

		#region AoE DPS

		[ReplaceSkill(SCH.ArtOfWar, SCH.ArtOfWarII)]
		[CustomComboInfo("AoE DPS", "Replaces Art of War withs below", SCH.JobID, 2)]
		SCH_AoE = 16020,

		[ParentCombo(SCH_AoE)]
		[CustomComboInfo("Aetherflow", "Use Aetherflow when out of Aetherflow stacks", SCH.JobID, 1)]
		SCH_AoE_Aetherflow = 16022,

		[ParentCombo(SCH_AoE)]
		[CustomComboInfo("Lucid Dreaming", "Adds Lucid Dreaming when MP drops below the slider value", SCH.JobID)]
		SCH_AoE_Lucid = 16021,

		#endregion

		#region Utility

		[ReplaceSkill(SCH.WhisperingDawn, SCH.FeyBlessing, SCH.Aetherpact, SCH.Dissipation)]
		[CustomComboInfo("Ensure Fairy", "Change all fairy actions into Summon Eos when the Fairy is not summoned", SCH.JobID, 3)]
		SCH_FairyReminder = 16060,

		[ReplaceSkill(SCH.Lustrate)]
		[CustomComboInfo("Lustrate to Excogitation", "Change Lustrate into Excogitation when Excogitation is ready", SCH.JobID, 5)]
		SCH_Lustrate = 16051,

		[ReplaceSkill(All.Swiftcast)]
		[CustomComboInfo("Swift Raise", "", SCH.JobID, 6)]
		SCH_Raise = 16059,

		#endregion

		#region Variant

		[Variant]
		[VariantParent(SCH_DPS_Bio, SCH_AoE)]
		[CustomComboInfo("Spirit Dart", "Use Variant Spirit Dart whenever the debuff is not present or less than 3s", SCH.JobID)]
		SCH_DPS_Variant_SpiritDart = 16070,

		[Variant]
		[VariantParent(SCH_DPS, SCH_AoE)]
		[CustomComboInfo("Rampart", "Use Variant Rampart on cooldown", SCH.JobID)]
		SCH_DPS_Variant_Rampart = 16071,

		#endregion

		#endregion

		#region SUMMONER - 17000

		[ReplaceSkill(SMN.Ruin, SMN.Ruin2, SMN.Outburst, SMN.Tridisaster)]
		[ConflictingCombos(SMN_Simple_Combo)]
		[CustomComboInfo("Advanced Summoner", "Advanced combos for a greater degree of customisation.\nAccommodates SpS builds.\nRuin III is left unchanged for mobility purposes", SMN.JobID)]
		SMN_Advanced_Combo = 17000,

		[ParentCombo(SMN_Advanced_Combo)]
		[CustomComboInfo("Demi Attacks Combo", "Adds Demi Summon oGCDs to the single target and AoE combos", SMN.JobID, 11, "", "")]
		SMN_Advanced_Combo_DemiSummons_Attacks = 17002,

		[ParentCombo(SMN_Advanced_Combo)]
		[CustomComboInfo("Egi Attacks Combo", "Adds Gemshine and Precious Brilliance to the single target and AoE combos, respectively", SMN.JobID, 4, "", "")]
		SMN_Advanced_Combo_EgiSummons_Attacks = 17004,

		[ReplaceSkill(SMN.Fester)]
		[CustomComboInfo("Energy Drain to Fester", "Change Fester into Energy Drain when out of Aetherflow stacks", SMN.JobID, 6, "", "")]
		SMN_EDFester = 17008,

		[ReplaceSkill(SMN.Painflare)]
		[CustomComboInfo("Energy Siphon to Painflare", "Change Painflare into Energy Siphon when out of Aetherflow stacks", SMN.JobID, 7, "", "")]
		SMN_ESPainflare = 17009,

		[CustomComboInfo("Carbuncle Reminder", "Replaces most offensive actions with Summon Carbuncle when it is not summoned", SMN.JobID, 8, "", "")]
		SMN_CarbuncleReminder = 17010,

		[ParentCombo(SMN_Advanced_Combo)]
		[CustomComboInfo("Ruin IV Combo", "Adds Ruin IV to the single target and AoE combos.\nUses when moving during Garuda Phase and you have no attunement, when moving during Ifrit phase, or when you have no active Egi or Demi summon", SMN.JobID)]
		SMN_Advanced_Combo_Ruin4 = 17011,

		[ParentCombo(SMN_EDFester)]
		[CustomComboInfo("Ruin IV Fester", "Changes Fester to Ruin IV when out of Aetherflow stacks, Energy Drain is on cooldown, and Ruin IV is available", SMN.JobID)]
		SMN_EDFester_Ruin4 = 17013,

		[ParentCombo(SMN_Advanced_Combo)]
		[CustomComboInfo("Energy Attacks Combo", "Adds Energy Drain and Fester to the single target combo.\nAdds Energy Siphon and Painflare to the AoE combo.\nWill be used on cooldown", SMN.JobID, 1, "", "")]
		SMN_Advanced_Combo_EDFester = 17014,

		[ParentCombo(SMN_Advanced_Combo)]
		[CustomComboInfo("Egi Summons Combo", "Adds Egi summons to the single target and AoE combos.\nWill prioritise the Egi selected below.\nIf no is selected, the will default to summoning Titan first", SMN.JobID, 3, "", "")]
		SMN_DemiEgiMenu_EgiOrder = 17016,

		[ParentCombo(SMN_Advanced_Combo)]
		[CustomComboInfo("Searing Light Combo", "Adds Searing Light to the single target and AoE combos.\nWill be used on cooldown", SMN.JobID, 9, "", "")]
		SMN_SearingLight = 17017,

		[ParentCombo(SMN_SearingLight)]
		[CustomComboInfo("Searing Light Burst", "Casts Searing Light only during Demi phases.\nReflects Demi choice selected under 'Pooled oGCDs'.\nNot recommended for SpS Builds", SMN.JobID, 0, "")]
		SMN_SearingLight_Burst = 17018,

		[ParentCombo(SMN_SearingLight)]
		[CustomComboInfo("Searing Flash Combo", "Adds Searing Flash to the single target and AoE combos", SMN.JobID, 1, "", "")]
		SMN_SearingFlash = 17019,

		[ParentCombo(SMN_Advanced_Combo)]
		[CustomComboInfo("Demi Summons Combo", "Adds Demi summons to the single target and AoE combos", SMN.JobID, 10, "", "")]
		SMN_Advanced_Combo_DemiSummons = 17020,

		[ParentCombo(SMN_Advanced_Combo)]
		[CustomComboInfo("Swiftcast Egi Ability", "Uses Swiftcast during the selected Egi summon", SMN.JobID, 8, "", "")]
		SMN_DemiEgiMenu_SwiftcastEgi = 17023,

		[CustomComboInfo("Astral Flow/Enkindle on Demis", "Adds Enkindle Bahamut, Enkindle Phoenix and Astral Flow to their relevant summons", SMN.JobID, 11, "", "")]
		SMN_DemiAbilities = 17024,

		[ParentCombo(SMN_Advanced_Combo_EDFester)]
		[CustomComboInfo("Pooled oGCDs", "Pools damage oGCDs for use inside the selected Demi phase while under the Searing Light buff.\nBahamut Burst becomes Solar Bahamut Burst at Lv100", SMN.JobID, 1, "", "")]
		SMN_DemiEgiMenu_oGCDPooling = 17025,

		[ConflictingCombos(ALL_Caster_Raise)]
		[CustomComboInfo("Alternative Raise", "Changes Swiftcast to Raise when on cooldown", SMN.JobID, 8, "", "")]
		SMN_Raise = 17027,

		[ParentCombo(SMN_Advanced_Combo_DemiSummons_Attacks)]
		[CustomComboInfo("Rekindle Combo", "Adds Rekindle to the single target and AoE combos", SMN.JobID, 13, "", "")]
		SMN_Advanced_Combo_DemiSummons_Rekindle = 17028,

		[ParentCombo(SMN_Advanced_Combo_DemiSummons_Attacks)]
		[CustomComboInfo("Lux Solaris Combo", "Adds Lux Solaris to the single target and AoE combos", SMN.JobID, 14, "", "")]
		SMN_Advanced_Combo_DemiSummons_LuxSolaris = 17029,

		[ReplaceSkill(SMN.Ruin4)]
		[CustomComboInfo("Ruin III Mobility", "Puts Ruin III on Ruin IV when you don't have Further Ruin", SMN.JobID, 9, "", "")]
		SMN_RuinMobility = 17030,

		[ParentCombo(SMN_Advanced_Combo)]
		[CustomComboInfo("Lucid Dreaming", "Adds Lucid Dreaming when MP drops below the slider value", SMN.JobID, 2, "", "")]
		SMN_Lucid = 17031,

		[CustomComboInfo("Egi Abilities on Summons", "Adds Egi Abilities (Astral Flow) to Egi summons when ready.\nEgi abilities will appear on their respective Egi summon ability, as well as Titan", SMN.JobID, 12, "", "")]
		SMN_Egi_AstralFlow = 17034,

		[ParentCombo(SMN_SearingLight)]
		[CustomComboInfo("Use only on Single Target combo", "Prevent this from applying to the AoE combo", SMN.JobID, 2, "", "")]
		SMN_SearingLight_STOnly = 17036,

		[ParentCombo(SMN_DemiEgiMenu_oGCDPooling)]
		[CustomComboInfo("Use only on Single Target combo", "Prevent this from applying to the AoE combo", SMN.JobID, 3, "", "")]
		SMN_DemiEgiMenu_oGCDPooling_Only = 17037,

		[ParentCombo(SMN_DemiEgiMenu_SwiftcastEgi)]
		[CustomComboInfo("Use only on Single Target combo", "Prevent this from applying to the AoE combo", SMN.JobID, 2, "", "")]
		SMN_DemiEgiMenu_SwiftcastEgi_Only = 17038,

		[ParentCombo(SMN_ESPainflare)]
		[CustomComboInfo("Ruin IV Painflare", "Changes Painflare to Ruin IV when out of Aetherflow stacks, Energy Siphon is on cooldown, and Ruin IV is up", SMN.JobID)]
		SMN_ESPainflare_Ruin4 = 17039,

		[ParentCombo(SMN_Advanced_Combo)]
		[CustomComboInfo("Add Egi Astralflow", "Choose which Egi Astralflows to add to the rotation", SMN.JobID, 0, "", "")]
		SMN_ST_Egi_AstralFlow = 17048,

		[ConflictingCombos(SMN_Advanced_Combo)]
		[ReplaceSkill(SMN.Ruin, SMN.Ruin2, SMN.Outburst, SMN.Tridisaster)]
		[CustomComboInfo("Simple Summoner", "General purpose one-button combo.\nBursts on Bahamut phase.\nSummons Titan, Garuda, then Ifrit.\nSwiftcasts on Slipstream unless drifted", SMN.JobID, -1, "", "")]
		SMN_Simple_Combo = 17041,

		[ParentCombo(SMN_DemiEgiMenu_oGCDPooling)]
		[CustomComboInfo("Burst Delay", "Only follows Burst Delay settings for the opener burst.\nThis is for high SPS builds", SMN.JobID, 2, "", "")]
		SMN_Advanced_Burst_Delay_Option = 17043,

		[ParentCombo(SMN_DemiEgiMenu_oGCDPooling)]
		[CustomComboInfo("Any Searing Burst", "Checks for any Searing light for bursting rather than just your own.\nUse this if partied with multiple SMN and are worried about your Searing being overwritten", SMN.JobID, 1, "", "")]
		SMN_Advanced_Burst_Any_Option = 17044,

		[Variant]
		[VariantParent(SMN_Simple_Combo, SMN_Advanced_Combo)]
		[CustomComboInfo("Rampart", "Use Variant Rampart on cooldown", SMN.JobID)]
		SMN_Variant_Rampart = 17045,

		[Variant]
		[VariantParent(SMN_Raise)]
		[CustomComboInfo("Raise", "Turn Swiftcast into Variant Raise whenever you have the Swiftcast buff", SMN.JobID)]
		SMN_Variant_Raise = 17046,

		[Variant]
		[VariantParent(SMN_Simple_Combo, SMN_Advanced_Combo)]
		[CustomComboInfo("Cure", "Use Variant Cure when HP is below set threshold", SMN.JobID)]
		SMN_Variant_Cure = 17047,

		#endregion

		#region VIPER

		[ReplaceSkill(VPR.SteelFangs)]
		[CustomComboInfo("Advanced Mode - Single Target", "Replaces Steel Fangs with a full one-button single target rotation.\nTheses are ideal if you want to customize the rotation", VPR.JobID)]
		VPR_ST_AdvancedMode = 30001,

		[ParentCombo(VPR_ST_AdvancedMode)]
		[CustomComboInfo("Noxious Gnash", "Adds Noxious Gnash if it is not present on current target, or is about to expire", VPR.JobID)]
		VPR_ST_NoxiousGnash = 30003,

		[ParentCombo(VPR_ST_AdvancedMode)]
		[CustomComboInfo("Serpents Tail", "Adds Serpents Tail to the rotation", VPR.JobID)]
		VPR_ST_SerpentsTail = 30008,

		[ParentCombo(VPR_ST_AdvancedMode)]
		[CustomComboInfo("Reawaken Combo", "Adds Generation and Legacy to the rotation", VPR.JobID)]
		VPR_ST_ReawakenCombo = 30012,

		[ReplaceSkill(VPR.SteelMaw)]
		[CustomComboInfo("Advanced Mode AoE", "Replaces Steel Maw with a full one-button AoE rotation.\nTheses are ideal if you want to customize the rotation", VPR.JobID)]
		VPR_AoE_AdvancedMode = 30101,

		[ParentCombo(VPR_AoE_AdvancedMode)]
		[CustomComboInfo("Noxious Gnash", "Adds Noxious Gnash if it is not present on current target, or is about to expire", VPR.JobID)]
		VPR_AoE_NoxiousGnash = 30102,

		[ParentCombo(VPR_AoE_AdvancedMode)]
		[CustomComboInfo("Serpents Tail", "Adds Serpents Tail to the rotation", VPR.JobID)]
		VPR_AoE_SerpentsTail = 30107,

		[ParentCombo(VPR_AoE_AdvancedMode)]
		[CustomComboInfo("Reawaken Combo", "Adds Generation and Legacy to the rotation", VPR.JobID)]
		VPR_AoE_ReawakenCombo = 30112,

		[ReplaceSkill(VPR.Dreadwinder)]
		[CustomComboInfo("Dreadwinder - Coils", "Replaces Dreadwinder with Hunter's/Swiftskin's Coils", VPR.JobID)]
		VPR_DreadwinderCoils = 30200,

		[ParentCombo(VPR_DreadwinderCoils)]
		[CustomComboInfo("Include Twin Combo Actions", "Adds Twinfang and Twinblood to the button", VPR.JobID)]
		VPR_DreadwinderCoils_oGCDs = 30206,

		[ReplaceSkill(VPR.PitofDread)]
		[CustomComboInfo("Pit Of Dread - Dens", "Replaces Pit Of Dread with Hunter's/Swiftskin's Dens", VPR.JobID)]
		VPR_PitOfDreadDens = 30201,

		[ParentCombo(VPR_PitOfDreadDens)]
		[CustomComboInfo("Include Twin Combo Actions", "Adds Twinfang and Twinblood to the button", VPR.JobID)]
		VPR_PitOfDreadDens_oGCDs = 30207,

		[ReplaceSkill(VPR.UncoiledFury)]
		[CustomComboInfo("Uncoiled - Twins", "Replaces Uncoiled Fury with Uncoiled Twinfang and Uncoiled Twinblood", VPR.JobID)]
		VPR_UncoiledTwins = 30202,

		#endregion

		#region WARRIOR - 18000

		#region Single Target

		[ReplaceSkill(WAR.StormsPath)]
		[CustomComboInfo("Single Target DPS", "asfasf", WAR.JobID)]
		WAR_ST_StormsPath = 18000,

		[ParentCombo(WAR_ST_StormsPath)]
		[CustomComboInfo("Storm's Eye", "", WAR.JobID)]
		WAR_ST_StormsPath_StormsEye = 18023,

		[ParentCombo(WAR_ST_StormsPath)]
		[CustomComboInfo("Upheaval", "", WAR.JobID)]
		WAR_ST_StormsPath_Upheaval = 18007,

		[ParentCombo(WAR_ST_StormsPath)]
		[CustomComboInfo("Fell Cleave", "", WAR.JobID)]
		WAR_ST_StormsPath_FellCleave = 18012,

		[ParentCombo(WAR_ST_StormsPath)]
		[CustomComboInfo("Inner Release", "", WAR.JobID)]
		WAR_ST_StormsPath_InnerRelease = 18020,

		#endregion

		#region AoE

		[ReplaceSkill(WAR.Overpower)]
		[CustomComboInfo("AoE DPS", "", WAR.JobID)]
		WAR_AoE_Overpower = 18002,

		[ParentCombo(WAR_AoE_Overpower)]
		[CustomComboInfo("Orogeny", "", WAR.JobID)]
		WAR_AoE_Overpower_Orogeny = 18010,

		[ParentCombo(WAR_AoE_Overpower)]
		[CustomComboInfo("Decimate", "", WAR.JobID)]
		WAR_AoE_Overpower_Decimate = 18029,

		[ParentCombo(WAR_AoE_Overpower)]
		[CustomComboInfo("Inner Release", "", WAR.JobID)]
		WAR_AoE_Overpower_InnerRelease = 18015,

		#endregion

		#region Utility

		[ReplaceSkill(WAR.FellCleave, WAR.Decimate)]
		[CustomComboInfo("Infuriate on Fell Cleave / Decimate", "", WAR.JobID)]
		WAR_InfuriateFellCleave = 18031,

		[ParentCombo(WAR_InfuriateFellCleave)]
		[CustomComboInfo("Inner Release Priority", "Prevents the use of Infuriate while you have Inner Release stacks available", WAR.JobID)]
		WAR_InfuriateFellCleave_IRFirst = 18022,

		#endregion

		#region Variant

		[Variant]
		[VariantParent(WAR_ST_StormsPath, WAR_AoE_Overpower)]
		[CustomComboInfo("Spirit Dart", "", WAR.JobID)]
		WAR_Variant_SpiritDart = 18026,

		[Variant]
		[VariantParent(WAR_ST_StormsPath, WAR_AoE_Overpower)]
		[CustomComboInfo("Cure", "", WAR.JobID)]
		WAR_Variant_Cure = 18027,

		[Variant]
		[VariantParent(WAR_ST_StormsPath, WAR_AoE_Overpower)]
		[CustomComboInfo("Ultimatum", "", WAR.JobID)]
		WAR_Variant_Ultimatum = 18028,

		#endregion

		#endregion

		#region WHITE MAGE - 19000

		#region Single Target

		[ReplaceSkill(WHM.Stone1, WHM.Stone2, WHM.Stone3, WHM.Stone4, WHM.Glare1, WHM.Glare3)]
		[CustomComboInfo("Single Target", "", WHM.JobID, 1)]
		WHM_ST_MainCombo = 19001,

		[ParentCombo(WHM_ST_MainCombo)]
		[CustomComboInfo("Aero/Dia Uptime", "", WHM.JobID, 1)]
		WHM_ST_MainCombo_DoT = 19003,

		[ParentCombo(WHM_ST_MainCombo)]
		[CustomComboInfo("Afflatus Misery", "", WHM.JobID, 2)]
		WHM_ST_MainCombo_Misery = 19006,

		[ParentCombo(WHM_ST_MainCombo_Misery)]
		[CustomComboInfo("Save Misery", "", WHM.JobID, 3)]
		WHM_ST_MainCombo_Misery_Save = 19007,

		[ParentCombo(WHM_ST_MainCombo)]
		[CustomComboInfo("Lily Overcap Protection", "", WHM.JobID, 4)]
		WHM_ST_MainCombo_LilyOvercap = 19008,

		[ParentCombo(WHM_ST_MainCombo)]
		[CustomComboInfo("Presence of Mind", "", WHM.JobID, 5)]
		WHM_ST_MainCombo_PresenceOfMind = 19009,

		[ParentCombo(WHM_ST_MainCombo)]
		[CustomComboInfo("Glare IV", "", WHM.JobID, 6)]
		WHM_ST_MainCombo_GlareIV = 19005,

		[ParentCombo(WHM_ST_MainCombo)]
		[CustomComboInfo("Lucid Dreaming", "", WHM.JobID, 7)]
		WHM_ST_MainCombo_Lucid = 19010,

		#endregion

		#region AoE

		[ReplaceSkill(WHM.Holy, WHM.Holy3)]
		[CustomComboInfo("AoE", "", WHM.JobID, 2)]
		WHM_AoE_DPS = 19020,

		[ParentCombo(WHM_AoE_DPS)]
		[CustomComboInfo("Afflatus Misery", "", WHM.JobID, 1)]
		WHM_AoE_DPS_Misery = 19023,

		[ParentCombo(WHM_AoE_DPS_Misery)]
		[CustomComboInfo("Save Misery", "", WHM.JobID, 2)]
		WHM_AoE_DPS_Misery_Save = 19024,

		[ParentCombo(WHM_AoE_DPS)]
		[CustomComboInfo("Lily Overcap Protection", "", WHM.JobID, 3)]
		WHM_AoE_DPS_LilyOvercap = 19025,

		[ParentCombo(WHM_AoE_DPS)]
		[CustomComboInfo("Presence of Mind", "", WHM.JobID, 4)]
		WHM_AoE_DPS_PresenceOfMind = 19026,

		[ParentCombo(WHM_AoE_DPS)]
		[CustomComboInfo("Glare IV", "", WHM.JobID, 5)]
		WHM_AoE_DPS_GlareIV = 19022,

		[ParentCombo(WHM_AoE_DPS)]
		[CustomComboInfo("Lucid Dreaming", "", WHM.JobID, 6)]
		WHM_AoE_DPS_Lucid = 19027,

		#endregion

		#region Single Target Heals

		[ReplaceSkill(WHM.Cure)]
		[CustomComboInfo("Single Target Heals", "", WHM.JobID, 3)]
		WHM_STHeals = 19030,

		[ParentCombo(WHM_STHeals)]
		[CustomComboInfo("Tetragrammaton", "", WHM.JobID, 1)]
		WHM_STHeals_Tetragrammaton = 19036,

		[ParentCombo(WHM_STHeals)]
		[CustomComboInfo("Afflatus Solace", "", WHM.JobID, 2)]
		WHM_STHeals_Solace = 19033,

		[ParentCombo(WHM_STHeals)]
		[CustomComboInfo("Afflatus Misery", "", WHM.JobID, 3)]
		WHM_STHeals_Misery = 19034,

		[ParentCombo(WHM_STHeals)]
		[CustomComboInfo("Regen", "", WHM.JobID, 4)]
		WHM_STHeals_Regen = 19031,

		[ParentCombo(WHM_STHeals)]
		[CustomComboInfo("Thin Air", "", WHM.JobID, 5)]
		WHM_STHeals_ThinAir = 19035,

		#endregion

		#region AoE Heals

		[ReplaceSkill(WHM.Medica1)]
		[CustomComboInfo("AoE Heals", "", WHM.JobID, 4)]
		WHM_AoEHeals = 19050,

		[ParentCombo(WHM_AoEHeals)]
		[CustomComboInfo("Plenary Indulgence", "", WHM.JobID, 1)]
		WHM_AoEHeals_Plenary = 19056,

		[ParentCombo(WHM_AoEHeals)]
		[CustomComboInfo("Afflatus Rapture", "", WHM.JobID, 2)]
		WHM_AoEHeals_Rapture = 19051,

		[ParentCombo(WHM_AoEHeals)]
		[CustomComboInfo("Afflatus Misery", "", WHM.JobID, 3)]
		WHM_AoEHeals_Misery = 19052,

		[ParentCombo(WHM_AoEHeals)]
		[CustomComboInfo("Thin Air", "", WHM.JobID, 4)]
		WHM_AoEHeals_ThinAir = 19053,

		[ParentCombo(WHM_AoEHeals)]
		[CustomComboInfo("Cure III", "", WHM.JobID, 5)]
		WHM_AoEHeals_Cure3 = 19054,

		[ParentCombo(WHM_AoEHeals)]
		[CustomComboInfo("Medica II/III", "", WHM.JobID, 6)]
		WHM_AoEHeals_Medica2 = 19058,

		[ParentCombo(WHM_AoEHeals)]
		[CustomComboInfo("Lucid Dreaming", "", WHM.JobID, 7)]
		WHM_AoEHeals_Lucid = 19057,

		#endregion

		#region Utility

		[ReplaceSkill(WHM.Cure2)]
		[CustomComboInfo("Cure II Sync", "", WHM.JobID)]
		WHM_CureSync = 19072,

		[ReplaceSkill(All.Swiftcast)]
		[CustomComboInfo("Swift Raise", "", WHM.JobID)]
		WHM_Raise = 19073,

		[ReplaceSkill(WHM.Raise)]
		[CustomComboInfo("Thin Air Raise", "", WHM.JobID)]
		WHM_ThinAirRaise = 19074,

		#endregion

		#region Variant

		[Variant]
		[VariantParent(WHM_ST_MainCombo_DoT, WHM_AoE_DPS)]
		[CustomComboInfo("Spirit Dart", "", WHM.JobID)]
		WHM_DPS_Variant_SpiritDart = 19080,

		[Variant]
		[VariantParent(WHM_ST_MainCombo, WHM_AoE_DPS)]
		[CustomComboInfo("Rampart", "", WHM.JobID)]
		WHM_DPS_Variant_Rampart = 19081,

		#endregion

		#endregion

		#endregion

		#region PvP Combos

		#region PvP GLOBALS
		[PvPCustomCombo]
		[CustomComboInfo("Emergency Heals", "Uses Recuperate when your HP is under the set threshold and you have sufficient MP", ADV.JobID, 1)]
		PvP_EmergencyHeals = 1100000,

		[PvPCustomCombo]
		[CustomComboInfo("Emergency Guard", "Uses Guard when your HP is under the set threshold", ADV.JobID, 2)]
		PvP_EmergencyGuard = 1100010,

		[PvPCustomCombo]
		[CustomComboInfo("Quick Purify", "Uses Purify when afflicted with any selected debuff", ADV.JobID, 4)]
		PvP_QuickPurify = 1100020,

		[PvPCustomCombo]
		[CustomComboInfo("Prevent Mash Cancelling", "Stops you cancelling your guard if you're pressing buttons quickly", ADV.JobID, 3)]
		PvP_MashCancel = 1100030,

		#endregion

		#region ASTROLOGIAN
		[PvPCustomCombo]
		[CustomComboInfo("Burst Mode", "Turns Fall Malefic into an all-in-one damage button", AST.JobID)]
		ASTPvP_Burst = 111000,

		[ParentCombo(ASTPvP_Burst)]
		[CustomComboInfo("Double Cast", "Adds Double Cast to Burst Mode", AST.JobID)]
		ASTPvP_DoubleCast = 111001,

		[ParentCombo(ASTPvP_Burst)]
		[CustomComboInfo("Card", "Adds Drawing and Playing Cards to Burst Mode", AST.JobID)]
		ASTPvP_Card = 111002,

		[PvPCustomCombo]
		[CustomComboInfo("Double Cast Heal", "Adds Double Cast to Aspected Benefic", AST.JobID)]
		ASTPvP_Heal = 111003,

		#endregion

		#region BLACK MAGE
		[PvPCustomCombo]
		[CustomComboInfo("Burst Mode", "Turns Fire and Blizzard into all-in-one damage buttons", BLM.JobID)]
		BLMPvP_BurstMode = 112000,

		[ParentCombo(BLMPvP_BurstMode)]
		[PvPCustomCombo]
		[CustomComboInfo("Night Wing", "Adds Night Wing to Burst Mode", BLM.JobID)]
		BLMPvP_BurstMode_NightWing = 112001,

		[ParentCombo(BLMPvP_BurstMode)]
		[PvPCustomCombo]
		[CustomComboInfo("Aetherial Manipulation", "Uses Aetherial Manipulation to gap close if Burst is off cooldown", BLM.JobID)]
		BLMPvP_BurstMode_AetherialManip = 112002,

		#endregion

		#region BARD
		[PvPCustomCombo]
		[CustomComboInfo("Burst Mode", "Turns Powerful Shot into an all-in-one damage button", BRDPvP.JobID)]
		BRDPvP_BurstMode = 113000,

		[PvPCustomCombo]
		[ParentCombo(BRDPvP_BurstMode)]
		[CustomComboInfo("Silent Nocturne", "Adds Silent Nocturne to Burst Mode", BRD.JobID)]
		BRDPvP_SilentNocturne = 113001,

		#endregion

		#region DANCER
		[PvPCustomCombo]
		[CustomComboInfo("Burst Mode", "Turns Fountain Combo into an all-in-one damage button", DNC.JobID)]
		DNCPvP_BurstMode = 114000,

		[PvPCustomCombo]
		[ParentCombo(DNCPvP_BurstMode)]
		[CustomComboInfo("Honing Dance", "Adds Honing Dance to the main combo when in melee range (respects global offset).\nThis prevents early use of Honing Ovation!\nKeep Honing Dance bound to another key if you want to end early", DNC.JobID)]
		DNCPvP_BurstMode_HoningDance = 114001,

		[PvPCustomCombo]
		[ParentCombo(DNCPvP_BurstMode)]
		[CustomComboInfo("Curing Waltz", "Adds Curing Waltz to the combo when available, and your HP is at or below the set percentage", DNC.JobID)]
		DNCPvP_BurstMode_CuringWaltz = 114002,

		#endregion

		#region DARK KNIGHT
		[PvPCustomCombo]
		[CustomComboInfo("Burst Mode", "Turns Souleater Combo into an all-in-one damage button", DRK.JobID)]
		DRKPvP_Burst = 115000,

		[PvPCustomCombo]
		[ParentCombo(DRKPvP_Burst)]
		[CustomComboInfo("Plunge", "Adds Plunge to Burst Mode", DRK.JobID)]
		DRKPvP_Plunge = 115001,

		[PvPCustomCombo]
		[ParentCombo(DRKPvP_Plunge)]
		[CustomComboInfo("Melee Plunge", "Uses Plunge whilst in melee range, and not just as a gap-closer", DRK.JobID)]
		DRKPvP_PlungeMelee = 115002,

		[PvPCustomCombo]
		[ParentCombo(DRKPvP_Burst)]
		[CustomComboInfo("Salted Earth", "Adds Salted Earth to Burst mode", DRK.JobID)]
		DRKPvP_SaltedEarth = 115003,

		#endregion

		#region DRAGOON
		[PvPCustomCombo]
		[CustomComboInfo("Burst Mode", "Using Elusive Jump turns Wheeling Thrust Combo into all-in-one burst damage button", DRG.JobID)]
		DRGPvP_Burst = 116000,

		[ParentCombo(DRGPvP_Burst)]
		[CustomComboInfo("Geirskogul", "Adds Geirskogul to Burst Mode", DRG.JobID)]
		DRGPvP_Geirskogul = 116001,

		[ParentCombo(DRGPvP_Geirskogul)]
		[CustomComboInfo("Nastrond", "Adds Nastrond to Burst Mode", DRG.JobID)]
		DRGPvP_Nastrond = 116002,

		[ParentCombo(DRGPvP_Burst)]
		[CustomComboInfo("Horrid Roar", "Adds Horrid Roar to Burst Mode", DRG.JobID)]
		DRGPvP_HorridRoar = 116003,

		[ParentCombo(DRGPvP_Burst)]
		[CustomComboInfo("Sustain Chaos Spring", "Adds Chaos Spring to Burst Mode when below the set HP percentage", DRG.JobID)]
		DRGPvP_ChaoticSpringSustain = 116004,

		[ParentCombo(DRGPvP_Burst)]
		[CustomComboInfo("Wyrmwind Thrust", "Adds Wyrmwind Thrust to Burst Mode", DRG.JobID)]
		DRGPvP_WyrmwindThrust = 116006,

		[ParentCombo(DRGPvP_Burst)]
		[CustomComboInfo("High Jump Weave", "Adds High Jump to Burst Mode", DRG.JobID)]
		DRGPvP_HighJump = 116007,

		[ParentCombo(DRGPvP_Burst)]
		[CustomComboInfo("Elusive Jump Burst Protection", "Disables Elusive Jump if Burst is not ready", DRG.JobID)]
		DRGPvP_BurstProtection = 116008,

		#endregion

		#region GUNBREAKER

		[PvPCustomCombo]
		[CustomComboInfo("Burst Mode", "Turns Solid Barrel Combo into an all-in-one damage button", GNB.JobID)]
		GNBPvP_Burst = 117000,

		[ParentCombo(GNBPvP_Burst)]
		[CustomComboInfo("Double Down", "Adds Double Down to Burst Mode while under the No Mercy buff", GNB.JobID)]
		GNBPvP_DoubleDown = 117001,

		[PvPCustomCombo]
		[CustomComboInfo("Gnashing Fang Continuation", "Adds Continuation onto Gnashing Fang", GNB.JobID)]
		GNBPvP_GnashingFang = 117002,

		[ParentCombo(GNBPvP_Burst)]
		[CustomComboInfo("Draw And Junction", "Adds Draw And Junction to Burst Mode", GNB.JobID)]
		GNBPvP_DrawAndJunction = 117003,

		[ParentCombo(GNBPvP_Burst)]
		[CustomComboInfo("Gnashing Fang", "Adds Gnashing Fang to Burst Mode while under the No Mercy buff", GNB.JobID)]
		GNBPvP_ST_GnashingFang = 117004,

		[ParentCombo(GNBPvP_Burst)]
		[CustomComboInfo("Continuation", "Adds Continuation to Burst Mode", GNB.JobID)]
		GNBPvP_ST_Continuation = 117005,

		[ParentCombo(GNBPvP_Burst)]
		[CustomComboInfo("Rough Divide", "Weaves Rough Divide when No Mercy Buff is about to expire", GNB.JobID)]
		GNBPvP_RoughDivide = 117006,

		[ParentCombo(GNBPvP_Burst)]
		[CustomComboInfo("Junction Cast DPS", "Adds Junction Cast (DPS) to Burst Mode", GNB.JobID)]
		GNBPvP_JunctionDPS = 117007,

		[ParentCombo(GNBPvP_Burst)]
		[CustomComboInfo("Junction Cast Healer", "Adds Junction Cast (Healer) to Burst Mode", GNB.JobID)]
		GNBPvP_JunctionHealer = 117008,

		[ParentCombo(GNBPvP_Burst)]
		[CustomComboInfo("Junction Cast Tank", "Adds Junction Cast (Tank) to Burst Mode", GNB.JobID)]
		GNBPvP_JunctionTank = 117009,

		#endregion

		#region MACHINIST
		[PvPCustomCombo]
		[CustomComboInfo("Burst Mode", "Turns Blast Charge into an all-in-one damage button", MCHPvP.JobID)]
		MCHPvP_BurstMode = 118000,

		[PvPCustomCombo]
		[ParentCombo(MCHPvP_BurstMode)]
		[CustomComboInfo("Alternate Drill", "Saves Drill for use after Wildfire", MCHPvP.JobID)]
		MCHPvP_BurstMode_AltDrill = 118001,

		[PvPCustomCombo]
		[ParentCombo(MCHPvP_BurstMode)]
		[CustomComboInfo("Alternate Analysis", "Uses Analysis with Air Anchor instead of Chain Saw", MCHPvP.JobID)]
		MCHPvP_BurstMode_AltAnalysis = 118002,

		#endregion

		#region MONK
		[PvPCustomCombo]
		[CustomComboInfo("Burst Mode", "Turns Phantom Rush Combo into an all-in-one damage button", MNK.JobID)]
		MNKPvP_Burst = 119000,

		[ParentCombo(MNKPvP_Burst)]
		[PvPCustomCombo]
		[CustomComboInfo("Thunderclap", "Adds Thunderclap to Burst Mode when not buffed with Wind Resonance", MNK.JobID)]
		MNKPvP_Burst_Thunderclap = 119001,

		[ParentCombo(MNKPvP_Burst)]
		[PvPCustomCombo]
		[CustomComboInfo("Riddle of Earth", "Adds Riddle of Earth and Earth's Reply to Burst Mode when in combat", MNK.JobID)]
		MNKPvP_Burst_RiddleOfEarth = 119002,

		[ParentCombo(MNKPvP_Burst)]
		[PvPCustomCombo]
		[CustomComboInfo("Six-sided Star", "Adds Six-sided Star to Burst Mode", MNK.JobID)]
		MNKPvP_Burst_SixSidedStar = 119003,

		#endregion

		#region NINJA
		[PvPCustomCombo]
		[CustomComboInfo("Burst Mode", "Turns Aeolian Edge Combo into an all-in-one damage button", NINPvP.JobID)]
		NINPvP_ST_BurstMode = 120000,

		[PvPCustomCombo]
		[CustomComboInfo("AoE Burst Mode", "Turns Fuma Shuriken into an all-in-one AoE damage button", NINPvP.JobID)]
		NINPvP_AoE_BurstMode = 120001,

		[ParentCombo(NINPvP_ST_BurstMode)]
		[PvPCustomCombo]
		[CustomComboInfo("Meisui", "Uses Three Mudra on Meisui when HP is under the set threshold", NINPvP.JobID)]
		NINPvP_ST_Meisui = 120002,

		[ParentCombo(NINPvP_AoE_BurstMode)]
		[PvPCustomCombo]
		[CustomComboInfo("Meisui", "Uses Three Mudra on Meisui when HP is under the set threshold", NINPvP.JobID)]
		NINPvP_AoE_Meisui = 120003,

		#endregion

		#region PALADIN
		[PvPCustomCombo]
		[CustomComboInfo("Burst Mode", "Turns Royal Authority Combo into an all-in-one damage button", PLD.JobID)]
		PLDPvP_Burst = 121000,

		[ParentCombo(PLDPvP_Burst)]
		[CustomComboInfo("Shield Bash", "Adds Shield Bash to Burst Mode", PLD.JobID)]
		PLDPvP_ShieldBash = 121001,

		[ParentCombo(PLDPvP_Burst)]
		[CustomComboInfo("Confiteor", "Adds Confiteor to Burst Mode", PLD.JobID)]
		PLDPvP_Confiteor = 121002,

		#endregion

		#region REAPER
		[PvPCustomCombo]
		[CustomComboInfo("Burst Mode", "Turns Slice Combo into an all-in-one damage button.\nAdds Soul Slice to the main combo", RPR.JobID)]
		RPRPvP_Burst = 122000,

		[PvPCustomCombo]
		[ParentCombo(RPRPvP_Burst)]
		[CustomComboInfo("Death Warrant", "Adds Death Warrant onto the main combo when Plentiful Harvest is ready to use, or when Plentiful Harvest's cooldown is longer than Death Warrant's.\nRespects Immortal Sacrifice Pooling", RPR.JobID)]
		RPRPvP_Burst_DeathWarrant = 122001,

		[PvPCustomCombo]
		[ParentCombo(RPRPvP_Burst)]
		[CustomComboInfo("Plentiful Harvest Opener", "Starts combat with Plentiful Harvest to immediately begin Limit Break generation", RPR.JobID)]
		RPRPvP_Burst_PlentifulOpener = 122002,

		[PvPCustomCombo]
		[ParentCombo(RPRPvP_Burst)]
		[CustomComboInfo("Plentiful Harvest + Immortal Sacrifice Pooling", "Pools stacks of Immortal Sacrifice before using Plentiful Harvest.\nAlso holds Plentiful Harvest if Death Warrant is on cooldown.\nSet the value to 3 or below to use Plentiful Harvest as soon as it's available", RPR.JobID)]
		RPRPvP_Burst_ImmortalPooling = 122003,

		[PvPCustomCombo]
		[ParentCombo(RPRPvP_Burst)]
		[CustomComboInfo("Enshrouded Burst", "Adds Lemure's Slice to the main combo during the Enshroud burst phase.\nContains bursts", RPR.JobID)]
		RPRPvP_Burst_Enshrouded = 122004,

		#region RPR Enshrouded
		[PvPCustomCombo]
		[ParentCombo(RPRPvP_Burst_Enshrouded)]
		[CustomComboInfo("Enshrouded Death Warrant", "Adds Death Warrant onto the main combo during the Enshroud burst when available", RPR.JobID)]
		RPRPvP_Burst_Enshrouded_DeathWarrant = 122005,

		[PvPCustomCombo]
		[ParentCombo(RPRPvP_Burst_Enshrouded)]
		[CustomComboInfo("Communio Finisher", "Adds Communio onto the main combo when you have 1 stack of Enshroud remaining.\nWill not trigger if you are moving", RPR.JobID)]
		RPRPvP_Burst_Enshrouded_Communio = 122006,
		#endregion

		[PvPCustomCombo]
		[ParentCombo(RPRPvP_Burst)]
		[CustomComboInfo("Ranged Harvest Moon", "Adds Harvest Moon onto the main combo when you're out of melee range, the GCD is not rolling and it's available for use", RPR.JobID)]
		RPRPvP_Burst_RangedHarvest = 122007,

		[PvPCustomCombo]
		[ParentCombo(RPRPvP_Burst)]
		[CustomComboInfo("Arcane Crest", "Adds Arcane Crest to the main combo when under the set HP perecentage", RPR.JobID)]
		RPRPvP_Burst_ArcaneCircle = 122008,

		#endregion

		#region RED MAGE
		[PvPCustomCombo]
		[CustomComboInfo("Burst Mode", "Turns Verstone/Verfire into an all-in-one damage button", RDMPvP.JobID)]
		RDMPvP_BurstMode = 123000,

		[PvPCustomCombo]
		[ParentCombo(RDMPvP_BurstMode)]
		[CustomComboInfo("No Frazzle", "Prevents Frazzle from being used in Burst Mode", RDMPvP.JobID)]
		RDMPvP_FrazzleOption = 123001,

		#endregion

		#region SAGE
		[PvPCustomCombo]
		[CustomComboInfo("Burst Mode", "Turns Dosis III into an all-in-one damage button", SGE.JobID)]
		SGEPvP_BurstMode = 124000,

		[ParentCombo(SGEPvP_BurstMode)]
		[CustomComboInfo("Pneuma", "Adds Pneuma to Burst Mode", SGE.JobID)]
		SGEPvP_BurstMode_Pneuma = 124001,

		#endregion

		#region SAMURAI

		#region Burst Mode
		[PvPCustomCombo]
		[CustomComboInfo("Burst Mode", "Adds Meikyo Shisui, Midare: Setsugekka, Ogi Namikiri, Kaeshi: Namikiri and Soten to Meikyo Shisui.\nWill only cast Midare: Setsugekka and Ogi Namikiri when you're not moving.\nWill not use if target is guarding", SAM.JobID)]
		SAMPvP_BurstMode = 125000,

		[PvPCustomCombo]
		[ParentCombo(SAMPvP_BurstMode)]
		[CustomComboInfo("Chiten", "Adds Chiten to Burst Mode when in combat and HP is below 95%", SAM.JobID)]
		SAMPvP_BurstMode_Chiten = 125001,

		[PvPCustomCombo]
		[ParentCombo(SAMPvP_BurstMode)]
		[CustomComboInfo("Mineuchi", "Adds Mineuchi to Burst Mode", SAM.JobID)]
		SAMPvP_BurstMode_Stun = 125002,

		[PvPCustomCombo]
		[ParentCombo(SAMPvP_BurstMode)]
		[CustomComboInfo("Burst Mode on Kasha Combo", "Adds Burst Mode to Kasha Combo instead", SAM.JobID, 1)]
		SAMPvP_BurstMode_MainCombo = 125003,
		#endregion

		#region Kashas
		[PvPCustomCombo]
		[CustomComboInfo("Kasha Combos", "Collection ofs for Kasha Combo", SAM.JobID)]
		SAMPvP_KashaFeatures = 125004,

		[PvPCustomCombo]
		[ParentCombo(SAMPvP_KashaFeatures)]
		[CustomComboInfo("Soten Gap Closer", "Adds Soten to the Kasha Combo when out of melee range", SAM.JobID)]
		SAMPvP_KashaFeatures_GapCloser = 125005,

		[PvPCustomCombo]
		[ParentCombo(SAMPvP_KashaFeatures)]
		[CustomComboInfo("AoE Melee Protection", "Makes the AoE combos unusable if not in melee range of target", SAM.JobID)]
		SAMPvP_KashaFeatures_AoEMeleeProtection = 125006,
		#endregion

		#endregion

		#region SCHOLAR
		[PvPCustomCombo]
		[CustomComboInfo("Burst Mode", "Turns Broil IV into all-in-one damage button", SCH.JobID)]
		SCHPvP_Burst = 126000,

		[ParentCombo(SCHPvP_Burst)]
		[CustomComboInfo("Expedient", "Adds Expedient to Burst Mode to empower Biolysis", SCH.JobID)]
		SCHPvP_Expedient = 126001,

		[ParentCombo(SCHPvP_Burst)]
		[CustomComboInfo("Biolysis", "Adds Biolysis use on cooldown to Burst Mode", SCH.JobID)]
		SCHPvP_Biolysis = 126002,

		[ParentCombo(SCHPvP_Burst)]
		[CustomComboInfo("Deployment Tactics", "Adds Deployment Tactics to Burst Mode when available", SCH.JobID)]
		SCHPvP_DeploymentTactics = 126003,

		#endregion

		#region SUMMONER
		[PvPCustomCombo]
		[CustomComboInfo("Burst Mode", "Turns Ruin III into an all-in-one damage button.\nOnly uses Crimson Cyclone when in melee range", SMNPvP.JobID)]
		SMNPvP_BurstMode = 127000,

		[PvPCustomCombo]
		[ParentCombo(SMNPvP_BurstMode)]
		[CustomComboInfo("Radiant Aegis", "Adds Radiant Aegis to Burst Mode when available, and your HP is at or below the set percentage", SMNPvP.JobID)]
		SMNPvP_BurstMode_RadiantAegis = 127001,

		#endregion

		#region WARRIOR
		[PvPCustomCombo]
		[CustomComboInfo("Burst Mode", "Turns Heavy Swing into an all-in-one damage button", WARPvP.JobID)]
		WARPvP_BurstMode = 128000,

		[PvPCustomCombo]
		[ParentCombo(WARPvP_BurstMode)]
		[CustomComboInfo("Bloodwhetting", "Allows use of Bloodwhetting any time, not just between GCDs", WARPvP.JobID)]
		WARPvP_BurstMode_Bloodwhetting = 128001,

		[PvPCustomCombo]
		[ParentCombo(WARPvP_BurstMode)]
		[CustomComboInfo("Blota", "Adds Blota to Burst Mode when not in melee range", WARPvP.JobID)]
		WARPvP_BurstMode_Blota = 128003,

		[PvPCustomCombo]
		[ParentCombo(WARPvP_BurstMode)]
		[CustomComboInfo("Primal Rend", "Adds Primal Rend to Burst Mode", WARPvP.JobID)]
		WARPvP_BurstMode_PrimalRend = 128004,

		#endregion

		#region WHITE MAGE
		[PvPCustomCombo]
		[CustomComboInfo("Burst Mode", "Turns Glare into an all-in-one damage button", WHM.JobID)]
		WHMPvP_Burst = 129000,

		[ParentCombo(WHMPvP_Burst)]
		[CustomComboInfo("Misery", "Adds Afflatus Misery to Burst Mode", WHM.JobID)]
		WHMPvP_Afflatus_Misery = 129001,

		[ParentCombo(WHMPvP_Burst)]
		[CustomComboInfo("Miracle of Nature", "Adds Miracle of Nature to Burst Mode", WHM.JobID)]
		WHMPvP_Mirace_of_Nature = 129002,

		[ParentCombo(WHMPvP_Burst)]
		[CustomComboInfo("Seraph Strike", "Adds Seraph Strike to Burst Mode", WHM.JobID)]
		WHMPvP_Seraph_Strike = 129003,

		[PvPCustomCombo]
		[CustomComboInfo("Aquaveil", "Adds Aquaveil to Cure II when available", WHM.JobID)]
		WHMPvP_Aquaveil = 129004,

		[PvPCustomCombo]
		[CustomComboInfo("Cure III", "Adds Cure III to Cure II when available", WHM.JobID)]
		WHMPvP_Cure3 = 129005,

		#endregion

		#endregion

		#region Extra

		#region Required

		[CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled", ADV.JobID)]
		AdvAny = 0,

		[CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled", DOH.JobID)]
		DohAny = AdvAny + DOH.JobID,

		[CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled", DOL.JobID)]
		DolAny = AdvAny + DOL.JobID,

		[CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled", PLD.JobID)]
		PldAny = AdvAny + PLD.JobID,

		[CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled", WAR.JobID)]
		WarAny = AdvAny + WAR.JobID,

		[CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled", DRK.JobID)]
		DrkAny = AdvAny + DRK.JobID,

		[CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled", GNB.JobID)]
		GnbAny = AdvAny + GNB.JobID,

		[CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled", WHM.JobID)]
		WhmAny = AdvAny + WHM.JobID,

		[CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled", SCH.JobID)]
		SchAny = AdvAny + SCH.JobID,

		[CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled", AST.JobID)]
		AstAny = AdvAny + AST.JobID,

		[CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled", SGE.JobID)]
		SgeAny = AdvAny + SGE.JobID,

		[CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled", MNK.JobID)]
		MnkAny = AdvAny + MNK.JobID,

		[CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled", DRG.JobID)]
		DrgAny = AdvAny + DRG.JobID,

		[CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled", NIN.JobID)]
		NinAny = AdvAny + NIN.JobID,

		[CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled", SAM.JobID)]
		SamAny = AdvAny + SAM.JobID,

		[CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled", RPR.JobID)]
		RprAny = AdvAny + RPR.JobID,

		[CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled", VPR.JobID)]
		VprAny = AdvAny + VPR.JobID,

		[CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled", BRD.JobID)]
		BrdAny = AdvAny + BRD.JobID,

		[CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled", MCH.JobID)]
		MchAny = AdvAny + MCH.JobID,

		[CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled", DNC.JobID)]
		DncAny = AdvAny + DNC.JobID,

		[CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled", BLM.JobID)]
		BlmAny = AdvAny + BLM.JobID,

		[CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled", SMN.JobID)]
		SmnAny = AdvAny + SMN.JobID,

		[CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled", RDM.JobID)]
		RdmAny = AdvAny + RDM.JobID,

		[CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled", PCT.JobID)]
		PctAny = AdvAny + PCT.JobID,

		[CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled", BLU.JobID)]
		BluAny = AdvAny + BLU.JobID,

		[CustomComboInfo("Disabled", "This should not be used", ADV.JobID)]
		Disabled = 99999,

		#endregion

		#region DOL - 51000

		[ReplaceSkill(DOL.AgelessWords, DOL.SolidReason)]
		[CustomComboInfo("[BTN/MIN] Eureka", "Replaces Ageless Words and Solid Reason with Wise to the World when available", DOL.JobID)]
		DOL_Eureka = 51001,

		[ReplaceSkill(DOL.ArborCall, DOL.ArborCall2, DOL.LayOfTheLand, DOL.LayOfTheLand2)]
		[CustomComboInfo("[BTN/MIN] Locate & Truth", "Replaces Lay of the Lands or Arbor Calls with Prospect/Triangulate and Truth of Mountains/Forests if not active", DOL.JobID)]
		DOL_NodeSearchingBuffs = 51012,

		[ReplaceSkill(DOL.Cast)]
		[CustomComboInfo("[FSH] Cast to Hook", "Replaces Cast with Hook when fishing", DOL.JobID)]
		FSH_CastHook = 51002,

		[CustomComboInfo("[FSH] Diving", "Replace fishing abilities with diving abilities when underwater", DOL.JobID)]
		FSH_Swim = 51008,

		[ReplaceSkill(DOL.Cast)]
		[ParentCombo(FSH_Swim)]
		[CustomComboInfo("[FSH] Cast to Gig", "Replaces Cast with Gig when diving", DOL.JobID)]
		FSH_CastGig = 51003,

		[ReplaceSkill(DOL.SurfaceSlap)]
		[ParentCombo(FSH_Swim)]
		[CustomComboInfo("Surface Slap to Veteran Trade", "Replaces Surface Slap with Veteran Trade when diving", DOL.JobID)]
		FSH_SurfaceTrade = 51004,

		[ReplaceSkill(DOL.PrizeCatch)]
		[ParentCombo(FSH_Swim)]
		[CustomComboInfo("Prize Catch to Nature's Bounty", "Replaces Prize Catch with Nature's Bounty when diving", DOL.JobID)]
		FSH_PrizeBounty = 51005,

		[ReplaceSkill(DOL.Snagging)]
		[ParentCombo(FSH_Swim)]
		[CustomComboInfo("Snagging to Salvage", "Replaces Snagging with Salvage when diving", DOL.JobID)]
		FSH_SnaggingSalvage = 51006,

		[ReplaceSkill(DOL.CastLight)]
		[ParentCombo(FSH_Swim)]
		[CustomComboInfo("Cast Light to Electric Current", "Replaces Cast Light with Electric Current when diving", DOL.JobID)]
		FSH_CastLight_ElectricCurrent = 51007,

		[ReplaceSkill(DOL.Mooch, DOL.MoochII)]
		[ParentCombo(FSH_Swim)]
		[CustomComboInfo("Mooch to Shark Eye", "Replaces Mooch with Shark Eye when diving", DOL.JobID)]
		FSH_Mooch_SharkEye = 51009,

		[ReplaceSkill(DOL.FishEyes)]
		[ParentCombo(FSH_Swim)]
		[CustomComboInfo("Fish Eyes to Vital Sight", "Replaces Fish Eyes with Vital Sight when diving", DOL.JobID)]
		FSH_FishEyes_VitalSight = 51010,

		[ReplaceSkill(DOL.Chum)]
		[ParentCombo(FSH_Swim)]
		[CustomComboInfo("Chum to Baited Breath", "Replaces Chum with Baited Breath when diving", DOL.JobID)]
		FSH_Chum_BaitedBreath = 51011,

		#endregion

		#region GLOBALS - 100000
		[ReplaceSkill(All.Sprint)]
		[CustomComboInfo("Island Sanctuary Sprint", "Replaces Sprint with Isle Sprint.\nOnly works at the Island Sanctuary. Icon does not change.\nDo not use with SimpleTweaks' Island Sanctuary Sprint fix", ADV.JobID)]
		ALL_IslandSanctuary_Sprint = 100000,

		[CustomComboInfo("Global Tanks", "Features ands involving shared role actions for Tanks.\nCollapsing this category does NOT disable thes inside", ADV.JobID)]
		ALL_Tank_Menu = 100010,

		[ReplaceSkill(All.LowBlow, PLD.ShieldBash)]
		[ParentCombo(ALL_Tank_Menu)]
		[CustomComboInfo("Tank: Interrupt", "Replaces Low Blow (Stun) with Interject (Interrupt) when the target can be interrupted.\nPLDs can slot Shield Bash to have the to work with Shield Bash", ADV.JobID)]
		ALL_Tank_Interrupt = 100011,

		[ReplaceSkill(All.Reprisal)]
		[ParentCombo(ALL_Tank_Menu)]
		[CustomComboInfo("Tank: Double Reprisal Protection", "Prevents the use of Reprisal when target already has the effect by replacing it with Stone", ADV.JobID)]
		ALL_Tank_Reprisal = 100012,

		[CustomComboInfo("Global Magical Rangeds", "Features ands involving shared role actions for Magical Ranged DPS.\nCollapsing this category does NOT disable thes inside", ADV.JobID)]
		ALL_Caster_Menu = 100030,

		[ReplaceSkill(All.Addle)]
		[ParentCombo(ALL_Caster_Menu)]
		[CustomComboInfo("Magical Ranged DPS: Double Addle Protection", "Prevents the use of Addle when target already has the effect by replacing it with Fell Cleave", ADV.JobID)]
		ALL_Caster_Addle = 100031,

		[ReplaceSkill(RDM.Verraise, SMN.Resurrection, BLU.AngelWhisper)]
		[ConflictingCombos(SMN_Raise, RDM_Raise)]
		[ParentCombo(ALL_Caster_Menu)]
		[CustomComboInfo("Magical Ranged DPS: Raise", "Changes the class' Raise Ability into Swiftcast or Dualcast in the case of RDM", ADV.JobID)]
		ALL_Caster_Raise = 100032,

		[CustomComboInfo("Global Melee DPSs", "Features ands involving shared role actions for Melee DPS.\nCollapsing this category does NOT disable thes inside", ADV.JobID)]
		ALL_Melee_Menu = 100040,

		[ReplaceSkill(All.Feint)]
		[ParentCombo(ALL_Melee_Menu)]
		[CustomComboInfo("Melee DPS: Double Feint Protection", "Prevents the use of Feint when target already has the effect by replacing it with Fire", ADV.JobID)]
		ALL_Melee_Feint = 100041,

		[ReplaceSkill(All.TrueNorth)]
		[ParentCombo(ALL_Melee_Menu)]
		[CustomComboInfo("Melee DPS: True North Protection", "Prevents the use of True North when its buff is already active by replacing it with Fire", ADV.JobID)]
		ALL_Melee_TrueNorth = 100042,

		[CustomComboInfo("Global Physical Rangeds", "Features ands involving shared role actions for Physical Ranged DPS.\nCollapsing this category does NOT disable thes inside", ADV.JobID)]
		ALL_Ranged_Menu = 100050,

		[ReplaceSkill(MCH.Tactician, BRD.Troubadour, DNC.ShieldSamba)]
		[ParentCombo(ALL_Ranged_Menu)]
		[CustomComboInfo("Physical Ranged DPS: Double Mitigation Protection", "Prevents the use of Tactician/Troubadour/Shield Samba when target already has one of those three effects", ADV.JobID)]
		ALL_Ranged_Mitigation = 100051,

		[ReplaceSkill(All.FootGraze)]
		[ParentCombo(ALL_Ranged_Menu)]
		[CustomComboInfo("Physical Ranged DPS: Ranged Interrupt", "Replaces Foot Graze with Head Graze when target can be interrupted", ADV.JobID)]
		ALL_Ranged_Interrupt = 100052,

		#endregion

		#endregion
	}
}