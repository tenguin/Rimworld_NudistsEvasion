using System;
using Verse;

namespace NudistsEvasion
{
    internal partial class Settings : ModSettings
    {
        private const float maxChance = 0.75f;
        private const float maxMass = 50f;

        public static float FullMassPenaltyThreshold;
        public static float NudeMeleeDodge;
        public static float NudeRangedEvade;
        public static bool DisableSpeedBonus;
        public static bool OnlyApplyToOwnFaction;
        private static void Initialize()
        {
            FullMassPenaltyThreshold = 8f;
            NudeMeleeDodge = 0.4f;
            NudeRangedEvade = 0.4f;
            DisableSpeedBonus = false;
            OnlyApplyToOwnFaction = true;
        }
        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref FullMassPenaltyThreshold, "FullMassPenaltyThreshold", 8f);
            Scribe_Values.Look(ref NudeMeleeDodge, "NudeMeleeDodge", 0.4f);
            Scribe_Values.Look(ref NudeRangedEvade, "NudeRangedEvade", 0.4f);
            Scribe_Values.Look(ref DisableSpeedBonus, "DisableSpeedBonus", false);
            Scribe_Values.Look(ref OnlyApplyToOwnFaction, "OnlyApplyToOwnFaction", true);
        }
        public Settings()
        {
            Initialize();
        }
    }
}
