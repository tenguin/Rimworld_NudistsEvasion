using RimWorld;

namespace NudistsEvasion
{
	[DefOf]
	public static class PreceptDefOf
	{
		[MayRequireRoyalty]
		public static PreceptDef Nudity_Male_Mandatory;

		[MayRequireIdeology]
		public static PreceptDef Nudity_Female_Mandatory;

		[MayRequireIdeology]
		public static PreceptDef Nudity_Male_CoveringAnythingButGroinDisapproved;

		[MayRequireIdeology]
		public static PreceptDef Nudity_Female_CoveringAnythingButGroinDisapproved;

		static PreceptDefOf()
		{
			DefOfHelper.EnsureInitializedInCtor(typeof(PreceptDefOf));
		}
	}
}
