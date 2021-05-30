using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Traits.IDs.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Traits.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Stats.Traits.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Stats.Traits.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Stats.Traits.Managers
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class TraitStatsManager
    {
        // Todo
        private static readonly ISet<ITraitStats> TraitStatsSet = new HashSet<ITraitStats>()
        {
            new ArmorAlphaAlphaTraitStats(),
            new CabinAlphaAlphaTraitStats(),
            new EngineAlphaAlphaTraitStats(),
            new WeaponAlphaAlphaTraitStats(),
        };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="traitID"></param>
        /// <returns></returns>
        public static Optional<ITraitStats> GetStats(TraitID traitID)
        {
            foreach (ITraitStats stats in TraitStatsSet)
            {
                if (stats.GetTraitID() == traitID)
                {
                    return Optional<ITraitStats>.Of(stats);
                }
            }
            return Optional<ITraitStats>.Empty();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="traitType"></param>
        /// <returns></returns>
        public static ISet<ITraitStats> GetStats(TraitType traitType)
        {
            ISet<ITraitStats> traitStats = new HashSet<ITraitStats>();
            foreach (ITraitStats stats in TraitStatsSet)
            {
                if (stats.GetTraitModelStats().GetTraitType() == traitType)
                {
                    traitStats.Add(stats);
                }
            }
            return traitStats;
        }
    }
}