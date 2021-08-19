using HarmonyLib;
using Verse;

namespace NudistsEvasion
{
    [HarmonyPatch(typeof(ShotReport), "GetTextReadout")]
    internal static class ShotReport_HitReportFor_GetTextReadout
    {
        //Method is called per frame, so translate label only once since it's expensive
        private static readonly string nudistsEvasionLabel = "NudistsEvasion_Label".Translate();

        [HarmonyPostfix]
        private static void GetTextReadout(ref string __result, ref TargetInfo ___target)
        {
            if (___target != null )
            {
                Pawn pawn = ___target.Thing as Pawn;
                if (pawn?.RaceProps != null && pawn.RaceProps.Humanlike)
                {
                    float hitChance = EvasionUtility.GetRangedHitChanceForNakedLevel(pawn);
                    if (hitChance < 1f)
                    {
                        __result = __result + "   " + nudistsEvasionLabel + "         " + hitChance * 100f + "%";
                    }
                }
            }
        }
    }
}