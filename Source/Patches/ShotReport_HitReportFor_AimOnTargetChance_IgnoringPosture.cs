using HarmonyLib;
using Verse;

namespace NudistsEvasion
{
    [HarmonyPatch(typeof(ShotReport), "AimOnTargetChance_IgnoringPosture", MethodType.Getter)]
    internal static class ShotReport_HitReportFor_AimOnTargetChance_IgnoringPosture
    {
        [HarmonyPostfix]
        private static void AimOnTargetChance_IgnoringPosture(ref float __result, ref TargetInfo ___target)
        {
            if (___target != null)
            {
                Pawn pawn = ___target.Thing as Pawn;
                if (pawn?.RaceProps != null && pawn.RaceProps.Humanlike)
                {
                    __result *= EvasionUtility.GetRangedHitChanceForNakedLevel(pawn);
                }
            }
        }
    }
}