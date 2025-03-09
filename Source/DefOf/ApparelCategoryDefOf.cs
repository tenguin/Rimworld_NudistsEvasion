using RimWorld;
using Verse;

namespace NudistsEvasion
{
    [DefOf]
    public static class ApparelCategoryDefOf
    {
        public static ThingCategoryDef ApparelUtility;

        static ApparelCategoryDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(ApparelCategoryDefOf));
        }
    }
}
