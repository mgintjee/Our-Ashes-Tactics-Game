/*using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Loadouts.Gears.IDs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Loadouts.Traits.IDs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Loadouts.Traits.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Constants.Loadouts.Models.Gears.Managers;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Constants.Loadouts.Models.Traits.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Constants.Loadouts.Models.Traits.Managers;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Reports.Traits.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Reports.Traits.Inters;
using System;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Generators.Sorties.Combatants.Loadouts.Traits
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
            GearModelConstantsManager.GetConstants(gearID).IfPresent(gearStats =>
            {
                int traitCount = 0;
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
            return TraitReport.Builder.Get()
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
            ISet<ITraitModelConstants> traitStats = new HashSet<ITraitModelConstants>();
            foreach (TraitType traitType in traitTypes)
            {
                traitStats.UnionWith(TraitModelConstantsManager.GetConstants(traitType));
            }
            ISet<TraitID> traitIDs = new HashSet<TraitID>();
            foreach (ITraitModelConstants stats in traitStats)
            {
                traitIDs.Add(stats.GetTraitID());
            }
            TraitID traitID = TraitID.None;
            if (traitIDs.Count > 0)
            {
                traitID = new List<TraitID>(traitIDs)
                    [random.Next(traitIDs.Count)];
            }
            TraitModelConstantsManager.GetConstants(traitID).IfPresent(traitStats =>
                { traitTypes.Remove(traitStats.GetTraitType()); });
            return traitID;
        }
    }
}*/