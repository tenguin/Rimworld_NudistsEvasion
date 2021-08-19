using Verse;

namespace NudistsEvasion
{
    internal static class EvasionUtility
    {
        public static float GetRangedEvadeForNakedLevel(Pawn p)
        {
            if (ConditionsUtility.FulfillsIdeologyRequirements(p))
            {
                if (ConditionsUtility.HasFullyNude(p))
                {
                    return Settings.NudeRangedEvade;
                }
                else if (ConditionsUtility.HasPantsOnly(p))
                {
                    return Settings.PantsOnlyRangedEvade;
                }
            }
            return 0f;
        }

        public static float GetMeleeDodgeForNakedLevel(Pawn p)
        {
            if (ConditionsUtility.FulfillsIdeologyRequirements(p))
            {
                if (ConditionsUtility.HasFullyNude(p))
                {
                    return Settings.NudeMeleeDodge;
                }
                else if (ConditionsUtility.HasPantsOnly(p))
                {
                    return Settings.PantsOnlyMeleeDodge;
                }
            }
            return 0f;
        }

        public static float GetRangedHitChanceForNakedLevel(Pawn p)
        {
            return 1f - GetRangedEvadeForNakedLevel(p);
        }

        public static float GetMeleeHitChanceForNakedLevel(Pawn p)
        {
            return 1f - GetMeleeDodgeForNakedLevel(p);
        }
    }
}
