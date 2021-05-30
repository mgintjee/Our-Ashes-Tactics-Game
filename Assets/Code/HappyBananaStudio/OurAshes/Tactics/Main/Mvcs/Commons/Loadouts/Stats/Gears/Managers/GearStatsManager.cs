using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.IDs.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Stats.Gears.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Stats.Gears.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Stats.Gears.Managers
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class GearStatsManager
    {
        // Todo
        private static readonly ISet<IGearStats> GearStatsSet = new HashSet<IGearStats>()
        {
            new ArmorAlphaAlphaGearStats(),
            new CabinAlphaAlphaGearStats(),
            new EngineAlphaAlphaGearStats(),
            new WeaponAlphaAlphaGearStats(),
        };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="gearID"></param>
        /// <returns></returns>
        public static Optional<IGearStats> GetStats(GearID gearID)
        {
            foreach (IGearStats stats in GearStatsSet)
            {
                if (stats.GetGearID() == gearID)
                {
                    return Optional<IGearStats>.Of(stats);
                }
            }
            return Optional<IGearStats>.Empty();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="gearType"></param>
        /// <returns></returns>
        public static ISet<IGearStats> GetStats(GearType gearType)
        {
            ISet<IGearStats> gearStats = new HashSet<IGearStats>();
            foreach (IGearStats stats in GearStatsSet)
            {
                if (stats.GetGearModelStats().GetGearType() == gearType)
                {
                    gearStats.Add(stats);
                }
            }
            return gearStats;
        }
    }
}