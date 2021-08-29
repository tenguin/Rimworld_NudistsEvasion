using System;
using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace NudistsEvasion
{
    internal partial class Settings : ModSettings
    {
        internal static void DoWindowContents(Rect inRect)
        {
            //30f for top page description and bottom close button
            Rect viewRect = new Rect(0f, 30f, inRect.width, inRect.height - 30f);

            Listing_Standard listingStandard = new Listing_Standard();
            listingStandard.ColumnWidth = viewRect.width;
            listingStandard.Begin(viewRect);

            listingStandard.Gap(5f);
            listingStandard.Label("NudistsEvasion_SettingsDescription".Translate());

            //Mass Penalty Slider
            listingStandard.Label("     " + "NudistsEvasion_MaximumMassPenalty".Translate() + ": " + FullMassPenaltyThreshold + " kg");
            FullMassPenaltyThreshold = (float)Math.Round(listingStandard.Slider(FullMassPenaltyThreshold, 0, maxMass), 0, MidpointRounding.AwayFromZero);

            //Evasion Sliders
            listingStandard.Label("     " + "NudistsEvasion_MeleeDodge".Translate() + ": " + NudeMeleeDodge * 100f + "%");
            NudeMeleeDodge = (float)Math.Round(listingStandard.Slider(NudeMeleeDodge, 0, maxChance), 2, MidpointRounding.AwayFromZero);


            listingStandard.Label("     " + "NudistsEvasion_RangedEvade".Translate() + ": " + NudeRangedEvade * 100f + "%");
            NudeRangedEvade = (float)Math.Round(listingStandard.Slider(NudeRangedEvade, 0, maxChance), 2, MidpointRounding.AwayFromZero);

            //Multiplicative note
            listingStandard.Gap(5f);
            listingStandard.Label("NudistsEvasion_MultiplicativeNote".Translate());

            //Required Ideology Dropdown
            listingStandard.Gap(30f);
            if (ModsConfig.IdeologyActive)
            {
                if (listingStandard.ButtonTextLabeled("NudistsEvasion_RequiredIdeology".Translate(), TranslateRequiredIdeologyOptions(RequiredIdeology)))
                {
                    List<FloatMenuOption> menuOptions = new List<FloatMenuOption>();
                    foreach (RequiredIdeologyOptions currentOption in Enum.GetValues(typeof(RequiredIdeologyOptions)))
                    {
                        menuOptions.Add(new FloatMenuOption(TranslateRequiredIdeologyOptions(currentOption), delegate
                        {
                            if (RequiredIdeology != currentOption)
                            {
                                RequiredIdeology = currentOption;
                            }
                        }));
                    }
                    Find.WindowStack.Add(new FloatMenu(menuOptions));
                }
            }

            //Disable Only Apply to Own Faction Checkbox
            listingStandard.Gap(5f);
            listingStandard.CheckboxLabeled("NudistsEvasion_OnlyApplyToOwnFaction".Translate() + ":", ref OnlyApplyToOwnFaction);

            //Disable Speed Bonus Checkbox
            listingStandard.Gap(5f);
            listingStandard.CheckboxLabeled("NudistsEvasion_DisableSpeedBonus".Translate() + ":", ref DisableSpeedBonus);


            //Reset
            listingStandard.Gap(120f);
            if (listingStandard.ButtonText("NudistsEvasion_ResetAll".Translate()))
            {
                Initialize();
            }
            listingStandard.End();
        }
    }
}
