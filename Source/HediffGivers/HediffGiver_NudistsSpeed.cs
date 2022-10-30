using Verse;

namespace NudistsEvasion
{
    public class HediffGiver_NudistsSpeed : HediffGiver
    {
        public override void OnIntervalPassed(Pawn p, Hediff cause)
        {
            if (p.Drafted && EvasionUtility.FulfillsFactionRequirements(p) && !Settings.DisableSpeedBonus)
            {
                float massPenalty = EvasionUtility.PenaltyMultiplierDueToApparelMass(p);
                if (massPenalty > 0f)
                {
                    Hediff firstHediffOfDef = p.health.hediffSet.GetFirstHediffOfDef(hediff);
                    if (firstHediffOfDef == null)
                    {
                        firstHediffOfDef = HediffMaker.MakeHediff(hediff, p);
                        p.health.AddHediff(firstHediffOfDef);
                    }
                    firstHediffOfDef.Severity = massPenalty;
                }
            }
        }
    }
}
