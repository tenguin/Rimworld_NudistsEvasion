using HarmonyLib;
using UnityEngine;
using Verse;

namespace NudistsEvasion
{
	public class NudistsEvasion : Mod
	{
		public NudistsEvasion(ModContentPack content) : base(content)
		{
			Harmony harmony = new Harmony(content.PackageId);
			if (ModsConfig.IdeologyActive)
			{
				harmony.PatchAll();
            }
			GetSettings<Settings>();
		}
		public override string SettingsCategory()
		{
			return "NudistsEvasion_Title".Translate();
		}

		public override void DoSettingsWindowContents(Rect inRect)
		{
			Settings.DoWindowContents(inRect);
		}
	}
}
