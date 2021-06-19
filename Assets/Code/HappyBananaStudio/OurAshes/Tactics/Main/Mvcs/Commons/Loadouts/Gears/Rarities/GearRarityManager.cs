using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.IDs.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Traits.IDs.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Rarities.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Stats.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Traits.Rarities;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Rarities
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class GearRarityManager
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="gearID"></param>
        /// <returns></returns>
        public static float GetValue(GearID gearID)
        {
            float value = 0.0f;

            GearStatsManager.GetStats(gearID).IfPresent(gearStats =>
            {
                switch (gearStats.GetRarity())
                {
                    case Rarity.Common:
                        value = 2.0f;
                        break;

                    case Rarity.Uncommon:
                        value = 3.0f;
                        break;

                    case Rarity.Epic:
                        value = 5.0f;
                        break;

                    case Rarity.Unique:
                        value = 8.0f;
                        break;
                }
            });

            return value;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="gearID"></param>
        /// <returns></returns>
        public static float GetValue(IGearReport gearReport)
        {
            // Default the value to the GearID's value
            float value = GetValue(gearReport.GetGearID());

            // Iterate over all of the TraitIDs
            foreach (TraitID traitID in gearReport.GetTraitReport().GetTraitIDs())
            {
                // Increment the value by the TraitID's value
                value += TraitRarityManager.GetValue(traitID);
            }

            return value;
        }
    }
}