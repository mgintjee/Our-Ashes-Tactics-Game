using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.IDs.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Traits.IDs.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Traits.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Stats.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Traits.Reports.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Traits.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Traits.Stats.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Traits.Stats.Managers;
using System;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Randoms.Sorties.Combatants.Loadouts.Traits
{
    /// <summary>
    /// Random Trait Reports
    /// </summary>
    public static class RandomTraitReports
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="random"></param>
        /// <returns></returns>
        public static ITraitReport Generate(Random random, GearID gearID)
        {
            ISet<TraitID> traitIDs = new HashSet<TraitID>();
            GearStatsManager.GetStats(gearID).IfPresent(gearStats =>
            {
                int traitCount = gearStats.GetTraitCount();
                ISet<TraitType> traitTypes = gearStats.GetTraitTypes();
                for (int i = 0; i < traitCount; ++i)
                {
                    if (traitTypes.Count == 0)
                    {
                        break;
                    }
                    traitIDs.Add(GenerateID(random, traitTypes));
                }
            });
            return new TraitReport.Builder()
                .SetTraitIDs(traitIDs)
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="random">    </param>
        /// <param name="traitTypes"></param>
        /// <returns></returns>
        private static TraitID GenerateID(Random random, ISet<TraitType> traitTypes)
        {
            ISet<ITraitStats> traitStats = new HashSet<ITraitStats>();
            foreach (TraitType traitType in traitTypes)
            {
                traitStats.UnionWith(TraitStatsManager.GetStats(traitType));
            }
            ISet<TraitID> traitIDs = new HashSet<TraitID>();
            foreach (ITraitStats stats in traitStats)
            {
                traitIDs.Add(stats.GetTraitID());
            }
            TraitID traitID = TraitID.None;
            if (traitIDs.Count > 0)
            {
                traitID = new List<TraitID>(traitIDs)
                    [random.Next(traitIDs.Count)];
            }
            TraitStatsManager.GetStats(traitID).IfPresent(traitStats =>
                { traitTypes.Remove(traitStats.GetTraitType()); });
            return traitID;
        }
    }
}