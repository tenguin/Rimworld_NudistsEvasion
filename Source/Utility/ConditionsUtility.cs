using RimWorld;
using Verse;

namespace NudistsEvasion
{
    internal static class ConditionsUtility
    {
        public static bool FulfillsIdeologyRequirements(Pawn p)
        {
            if (p?.Ideo != null)
            {
                if (Settings.RequiredIdeology == Settings.RequiredIdeologyOptions.Meme && p.Ideo.HasMeme(MemeDefOf.Nudism))
                {
                    return true;
                }
                else if (Settings.RequiredIdeology == Settings.RequiredIdeologyOptions.Precept && p?.gender != null)
                {
                    if ((p.Ideo.HasPrecept(PreceptDefOf.Nudity_Male_Mandatory) ||
                        p.Ideo.HasPrecept(PreceptDefOf.Nudity_Male_CoveringAnythingButGroinDisapproved)) &&
                        p.gender == Gender.Male)
                        return true;
                    else if ((p.Ideo.HasPrecept(PreceptDefOf.Nudity_Female_Mandatory) ||
                        p.Ideo.HasPrecept(PreceptDefOf.Nudity_Female_CoveringAnythingButGroinDisapproved)) &&
                        p.gender == Gender.Female)
                        return true;
                }
                else if (Settings.RequiredIdeology == Settings.RequiredIdeologyOptions.None)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool HasFullyNude(Pawn p)
        {
            if (!HasUnnecessarilyCoveredBodyParts(p))
            {
                return true;
            }
            return false;
        }

        public static bool HasPantsOnly(Pawn p)
        {
            if (!ThoughtWorker_Precept_AnyBodyPartButGroinCovered.HasCoveredBodyPartsButGroin(p))
            {
                return true;
            }
            return false;
        }

        private static bool HasUnnecessarilyCoveredBodyParts(Pawn p)
        {
            if (p.apparel != null && p.apparel.AnyClothing && PawnUtility.HasClothingNotRequiredByKind(p))
            {
                return true;
            }
            return false;
        }
    }
}
