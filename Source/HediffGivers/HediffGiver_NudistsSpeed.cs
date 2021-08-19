using Verse;

namespace NudistsEvasion
{
    public class HediffGiver_NudistsSpeed : HediffGiver
    {
        public override void OnIntervalPassed(Pawn p, Hediff cause)
        {
            if (p.Drafted && ConditionsUtility.FulfillsIdeologyRequirements(p) && !Settings.DisableSpeedBonus)
            {
                bool fullyNude = ConditionsUtility.HasFullyNude(p);
                bool hasPants = ConditionsUtility.HasPantsOnly(p);
                if (fullyNude || hasPants)
                {
                    Hediff firstHediffOfDef = p.health.hediffSet.GetFirstHediffOfDef(hediff);
                    if (firstHediffOfDef == null)
                    {
                        firstHediffOfDef = HediffMaker.MakeHediff(hediff, p);
                        p.health.AddHediff(firstHediffOfDef);
                    }

                    if (fullyNude)
                    {
                        firstHediffOfDef.Severity = 1f;
                    }
                    else if (hasPants)
                    {
                        firstHediffOfDef.Severity = 0.25f;
                    }
                }
            }
        }
    }
}
