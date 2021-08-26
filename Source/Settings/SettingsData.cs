using System;
using Verse;

namespace NudistsEvasion
{
    internal partial class Settings : ModSettings
    {
        private const float maxChance = 0.75f;

        public static float NudeMeleeDodge;
        public static float NudeRangedEvade;
        public static float PantsOnlyMeleeDodge;
        public static float PantsOnlyRangedEvade;
        public static bool DisableSpeedBonus;
        public static RequiredIdeologyOptions RequiredIdeology;
        private static void Initialize()
        {
            NudeMeleeDodge = 0.4f;
            NudeRangedEvade = 0.4f;
            PantsOnlyMeleeDodge = 0.3f;
            PantsOnlyRangedEvade = 0.3f;
            DisableSpeedBonus = false;
            RequiredIdeology = RequiredIdeologyOptions.Meme;
        }
        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref NudeMeleeDodge, "NudeMeleeDodge", 0.4f);
            Scribe_Values.Look(ref NudeRangedEvade, "NudeRangedEvade", 0.4f);
            Scribe_Values.Look(ref PantsOnlyMeleeDodge, "PantsOnlyMeleeDodge", 0.3f);
            Scribe_Values.Look(ref PantsOnlyRangedEvade, "PantsOnlyRangedEvade", 0.3f);
            Scribe_Values.Look(ref DisableSpeedBonus, "DisableSpeedBonus", false);
            Scribe_Values.Look(ref RequiredIdeology, "RequiredIdeology", RequiredIdeologyOptions.Meme);
        }
        public enum RequiredIdeologyOptions : byte
        {
            Meme,
            Precept,
            None
        }
        private static string TranslateRequiredIdeologyOptions(RequiredIdeologyOptions mode)
        {
            switch (mode)
            {
                case RequiredIdeologyOptions.Meme:
                    return "NudistsEvasion_Meme".Translate();
                case RequiredIdeologyOptions.Precept:
                    return "NudistsEvasion_Precept".Translate();
                case RequiredIdeologyOptions.None:
                    return "NudistsEvasion_None".Translate();
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
