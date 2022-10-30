using RimWorld;
using System;
using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace NudistsEvasion
{
    internal static class EvasionUtility
    {
        public static float GetRangedEvadeForNakedLevel(Pawn p)
        {
            if (FulfillsFactionRequirements(p))
            {
                return (float)Math.Round(Settings.NudeRangedEvade * PenaltyMultiplierDueToApparelMass(p) * PenaltyMultiplierDueToMovingStat(p), 2, MidpointRounding.AwayFromZero);
            }
            return 0f;
        }

        public static float GetMeleeDodgeForNakedLevel(Pawn p)
        {
            if (FulfillsFactionRequirements(p))
            {
                return (float)Math.Round(Settings.NudeMeleeDodge * PenaltyMultiplierDueToApparelMass(p) * PenaltyMultiplierDueToMovingStat(p), 2, MidpointRounding.AwayFromZero);
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

        public static float PenaltyMultiplierDueToApparelMass(Pawn p)
        {
            return Mathf.Clamp(1f - (GetApparelMass(p) / Settings.FullMassPenaltyThreshold), 0f, 1f);
        }

        //Want 0% dodge at the incapableOfMoving threshold, which is at 15% moving stat in vanilla.
        //Shift down then multiply so that input of 15% -> 0% and 100% -> 100%
        public static float PenaltyMultiplierDueToMovingStat(Pawn p)
        {
            float penaltyMultiplier = p.health.capacities.GetLevel(PawnCapacityDefOf.Moving) - PawnCapacityDefOf.Moving.minForCapable;
            penaltyMultiplier *= 1f / (1f - PawnCapacityDefOf.Moving.minForCapable);
            return Mathf.Clamp(penaltyMultiplier, 0f, 1f);
        }

        public static float GetApparelMass(Pawn p)
        {
            float apparelMass = 0f;
            if (p.apparel != null)
            {
                List<Apparel> wornApparel = p.apparel.WornApparel;
                for (int i = 0; i < wornApparel.Count; i++)
                {
                    //Log.Message($"{p}: item: {wornApparel[i]}, thingCategories: {wornApparel[i]?.def?.thingCategories}, isUtility: {wornApparel[i].HasThingCategory(ThingCategoryDefOf.ApparelUtility)}, mass: {wornApparel[i].GetStatValue(StatDefOf.Mass)}"); 
                    if (wornApparel[i]?.def?.thingCategories != null && wornApparel[i].HasThingCategory(ThingCategoryDefOf.ApparelUtility))
                    {
                        continue;
                    }
                    apparelMass += wornApparel[i].GetStatValue(StatDefOf.Mass);
                }
            }
            return apparelMass;
        }

        //Free colonist = Colonists and Controlled slaves, not rebelling slaves or prisoners.
        public static bool FulfillsFactionRequirements(Pawn p)
        {
            if (Settings.OnlyApplyToOwnFaction)
            {
                return p.IsFreeColonist;
            }
            return true;
        }
    }
}
