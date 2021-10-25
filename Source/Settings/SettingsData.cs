using System;
using Verse;

namespace NudistsEvasion
{
    internal partial class Settings : ModSettings
    {
        private const float maxChance = 0.6f;
        private const float maxMass = 12f;

        public static float FullMassPenaltyThreshold;
        public static float NudeMeleeDodge;
        public static float NudeRangedEvade;
        public static bool DisableSpeedBonus;
        public static bool OnlyApplyToOwnFaction;
        public static RequiredIdeologyOptions RequiredIdeology;
        private static void Initialize()
        {
            FullMassPenaltyThreshold = 6f;
            NudeMeleeDodge = 0.4f;
            NudeRangedEvade = 0.4f;
            DisableSpeedBonus = false;
            OnlyApplyToOwnFaction = true;
            RequiredIdeology = RequiredIdeologyOptions.None;
        }
        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref FullMassPenaltyThreshold, "FullMassPenaltyThreshold", 6f);
            Scribe_Values.Look(ref NudeMeleeDodge, "NudeMeleeDodge", 0.4f);
            Scribe_Values.Look(ref NudeRangedEvade, "NudeRangedEvade", 0.4f);
            Scribe_Values.Look(ref DisableSpeedBonus, "DisableSpeedBonus", false);
            Scribe_Values.Look(ref OnlyApplyToOwnFaction, "OnlyApplyToOwnFaction", true);
            Scribe_Values.Look(ref RequiredIdeology, "RequiredIdeology", RequiredIdeologyOptions.None);
        }
        public enum RequiredIdeologyOptions : byte
        {
            None,
            Meme,
            Precept            
        }
        private static string TranslateRequiredIdeologyOptions(RequiredIdeologyOptions mode)
        {
            switch (mode)
            {
                case RequiredIdeologyOptions.None:
                    return "NudistsEvasion_None".Translate();
                case RequiredIdeologyOptions.Meme:
                    return "NudistsEvasion_Meme".Translate();
                case RequiredIdeologyOptions.Precept:
                    return "NudistsEvasion_Precept".Translate();
                default:
                    throw new NotImplementedException();
            }
        }
        public Settings()
        {
            Initialize();
        }
    }
}
