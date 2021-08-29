using RimWorld;
using Verse;

namespace NudistsEvasion
{
    internal static class ConditionsUtility
    {
        public static bool FulfillsIdeologyRequirements(Pawn p)
        {
            if (!ModsConfig.IdeologyActive)
                return true;

            if (p?.Ideo != null)
            {
                if (Settings.RequiredIdeology == Settings.RequiredIdeologyOptions.None)
                {
                    return true;
                }
                else if (Settings.RequiredIdeology == Settings.RequiredIdeologyOptions.Meme && p.Ideo.HasMeme(MemeDefOf.Nudism))
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
            }
            return false;
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
