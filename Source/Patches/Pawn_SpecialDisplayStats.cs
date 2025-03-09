using HarmonyLib;
using RimWorld;
using System;
using System.Collections.Generic;
using Verse;

namespace NudistsEvasion
{
    [HarmonyPatch(typeof(Pawn), "SpecialDisplayStats")]
    internal static class Pawn_SpecialDisplayStats
    {
        private static Pawn p;

        [HarmonyPostfix]
        private static void SpecialDisplayStats(ref Pawn __instance)
        {
            p = __instance;
        }

        [HarmonyPostfix]
        private static IEnumerable<StatDrawEntry> SpecialDisplayStats(IEnumerable<StatDrawEntry> displayStats)
        {
            foreach (StatDrawEntry item in displayStats)
            {
                yield return item;
            }

            if (p?.RaceProps != null && p.RaceProps.Humanlike && EvasionUtility.FulfillsFactionRequirements(p))
            {
                float bonusDodge = EvasionUtility.GetMeleeDodgeForNakedLevel(p) * 100f;
                float bonusEvade = EvasionUtility.GetRangedEvadeForNakedLevel(p) * 100f;
                float massPenalty = (float)Math.Round(EvasionUtility.PenaltyMultiplierDueToApparelMass(p) - 1f, 2, MidpointRounding.AwayFromZero) * 100f;
                float movePenalty = (float)Math.Round(EvasionUtility.PenaltyMultiplierDueToMovingStat(p) - 1f, 2, MidpointRounding.AwayFromZero) * 100f;
                string label = bonusDodge + "NudistsEvasion_Dodge".Translate() + ", " + bonusEvade + "NudistsEvasion_Evade".Translate();
                yield return new StatDrawEntry(StatCategoryDefOf.PawnCombat, "NudistsEvasion_Label".Translate(), label,
                    "NudistsEvasion_StatsDesc".Translate(
                        Math.Round(EvasionUtility.GetApparelMass(p), 2, MidpointRounding.AwayFromZero), 
                        Settings.FullMassPenaltyThreshold, 
                        Settings.NudeMeleeDodge * 100f,
                        massPenalty, 
                        movePenalty, 
                        bonusDodge,
                        Settings.NudeRangedEvade * 100f, 
                        bonusEvade) +
                        "\n\n" + "NudistsEvasion_MultiplicativeNote".Translate(), 4101);
            }
        }
    }
}