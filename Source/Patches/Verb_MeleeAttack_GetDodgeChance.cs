using HarmonyLib;
using RimWorld;
using Verse;

namespace NudistsEvasion
{
    [HarmonyPatch(typeof(Verb_MeleeAttack), "GetDodgeChance")]
    internal static class Verb_MeleeAttack_GetDodgeChance
    {
        [HarmonyPostfix]
        private static void GetDodgeChance(LocalTargetInfo target, ref float __result)
        {
            if (target != null && target.Pawn?.RaceProps != null && target.Pawn.RaceProps.Humanlike)
            {
                //Multiply as hit chances for diminishing returns so dodge never reaches 100%
                __result = 1f - ((1f - __result) * EvasionUtility.GetMeleeHitChanceForNakedLevel(target.Pawn));
            }
        }
    }
}