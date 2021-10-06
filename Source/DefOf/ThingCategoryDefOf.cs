using RimWorld;
using Verse;

namespace NudistsEvasion
{
	//TODO: Can remove this entirely in the future when next stable build becomes widespread since ApparelUtility is added to vanilla's ThingCategoryDefOf
	[DefOf]
	public static class ThingCategoryDefOf
	{
		public static ThingCategoryDef ApparelUtility;

		static ThingCategoryDefOf()
		{
			DefOfHelper.EnsureInitializedInCtor(typeof(ThingCategoryDefOf));
		}
	}
}
