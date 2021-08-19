using HarmonyLib;
using RimWorld;
using System.Collections.Generic;
using Verse;

namespace NudistsEvasion
{
    [HarmonyPatch(typeof(Pawn), "SpecialDisplayStats")]
    internal static class Pawn_SpecialDisplayStats
    {
        private static Pawn pawn;

        [HarmonyPostfix]
        private static void SpecialDisplayStats(ref Pawn __instance)
        {
            pawn = __instance;
        }

        [HarmonyPostfix]
        private static IEnumerable<StatDrawEntry> SpecialDisplayStats(IEnumerable<StatDrawEntry> displayStats)
        {
            foreach (StatDrawEntry item in displayStats)
            {
                yield return item;
            }

            if (pawn?.RaceProps != null && pawn.RaceProps.Humanlike && ConditionsUtility.FulfillsIdeologyRequirements(pawn))
            {
                string label;
                if (ConditionsUtility.HasFullyNude(pawn))
                {
                    label = "NudistsEvasion_Full".Translate();
                }
                else if (ConditionsUtility.HasPantsOnly(pawn))
                {
                    label = "NudistsEvasion_HasPants".Translate();
                }
                else
                {
                    label = "NudistsEvasion_NotActive".Translate();
                }    

                float dodge = EvasionUtility.GetMeleeDodgeForNakedLevel(pawn) * 100f;
                float evade = EvasionUtility.GetRangedEvadeForNakedLevel(pawn) * 100f;
                yield return new StatDrawEntry(StatCategoryDefOf.PawnCombat, "NudistsEvasion_Label".Translate(), label, 
                    "NudistsEvasion_StatsDesc".Translate(dodge, evade), 4101);
            }
        }
    }
}