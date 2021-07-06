using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.Sizes;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Rarities;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Stats.Implementations.Armors;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Stats.Implementations.Cabins;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Stats.Implementations.Engines;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Stats.Implementations.Weapons;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Stats.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Stats.Managers
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
            new ArmorBravoAlphaGearStats(),
            new CabinAlphaAlphaGearStats(),
            new CabinBravoAlphaGearStats(),
            new EngineAlphaAlphaGearStats(),
            new WeaponAlphaAlphaGearStats(),
            new WeaponBravoAlphaGearStats(),
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
        /// <returns></returns>
        public static ISet<IGearStats> GetStats()
        {
            return new HashSet<IGearStats>(GearStatsSet);
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
                if (stats.GetGearType() == gearType)
                {
                    gearStats.Add(stats);
                }
            }
            return gearStats;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="gearSize"></param>
        /// <returns></returns>
        public static ISet<IGearStats> GetStats(GearSize gearSize)
        {
            ISet<IGearStats> gearStats = new HashSet<IGearStats>();
            foreach (IGearStats stats in GearStatsSet)
            {
                if (stats.GetGearSize() == gearSize)
                {
                    gearStats.Add(stats);
                }
            }
            return gearStats;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="rarity"></param>
        /// <returns></returns>
        public static ISet<IGearStats> GetStats(Rarity rarity)
        {
            ISet<IGearStats> gearStats = new HashSet<IGearStats>();
            foreach (IGearStats stats in GearStatsSet)
            {
                if (stats.GetRarity() == rarity)
                {
                    gearStats.Add(stats);
                }
            }
            return gearStats;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="combatantType"></param>
        /// <returns></returns>
        public static ISet<IGearStats> GetStats(CombatantType combatantType)
        {
            ISet<IGearStats> gearStats = new HashSet<IGearStats>();
            foreach (IGearStats stats in GearStatsSet)
            {
                if (stats.GetCombatantTypes().Contains(combatantType))
                {
                    gearStats.Add(stats);
                }
            }
            return gearStats;
        }
    }
}