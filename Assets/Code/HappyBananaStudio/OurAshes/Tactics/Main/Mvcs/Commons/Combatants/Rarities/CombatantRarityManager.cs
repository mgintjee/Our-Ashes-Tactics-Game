using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.IDs.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Rarities.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Stats.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Rarities;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Reports.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Rarities
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class CombatantRarityManager
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="combatantID"></param>
        /// <returns></returns>
        public static float GetValue(CombatantID combatantID)
        {
            float value = 0.0f;

            CombatantStatsManager.GetStats(combatantID).IfPresent(combatantStats =>
            {
                switch (combatantStats.GetRarity())
                {
                    case Rarity.Common:
                        value = 8.0f;
                        break;

                    case Rarity.Uncommon:
                        value = 13.0f;
                        break;

                    case Rarity.Epic:
                        value = 21.0f;
                        break;

                    case Rarity.Unique:
                        value = 34.0f;
                        break;
                }
            });

            return value;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="combatantID"></param>
        /// <returns></returns>
        public static float GetValue(CombatantID combatantID, ILoadoutReport loadoutReport)
        {
            // Default the value to the CombatantID's value
            float value = GetValue(combatantID);

            // Iterate over all of the GearReports
            foreach (IGearReport gearReport in loadoutReport.GetGearReports())
            {
                // Increment the value by the GearReport's value
                value += GearRarityManager.GetValue(gearReport);
            }

            return value;
        }
    }
}