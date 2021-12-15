/*using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Combatants.CallSigns;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Phalanxes.CallSigns;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Sorties.Maps.Spawns.Areas;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Sorties.Maps.Spawns.Sides;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Utils.Enums;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Engagements.Constrs.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Constrs.Models.Implementaions;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Constrs.Models.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Spawns.Positions.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Spawns.Positions.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Phalanxes.Constrs.Inters;
using System;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Generators.Sorties.Maps
{
    /// <summary>
    /// Random Map Constrs
    /// </summary>
    public static class RandomMapConstrs
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="random"></param>
        /// <returns></returns>
        public static ISortieMapModelConstruction Generate(Random random, int size,
            IEngagementConstruction engagementConstruction)
        {
            IDictionary<CombatantCallSign, ISpawnPosition> combatantCallSignSpawnPositions = new Dictionary<CombatantCallSign, ISpawnPosition>();
            IDictionary<PhalanxCallSign, SpawnArea> phalanxCallSignSpawnArea = new Dictionary<PhalanxCallSign, SpawnArea>();
            ISet<IPhalanxConstruction> phalanxConstrs = new HashSet<IPhalanxConstruction>(engagementConstruction.GetPhalanxConstrs());
            IList<SpawnArea> spawnAreas = EnumUtils.GetEnumList<SpawnArea>(phalanxConstrs.Count);
            int spawnAreaIndex = 0;
            foreach (IPhalanxConstruction phalanxConstruction in phalanxConstrs)
            {
                SpawnArea spawnArea = spawnAreas[spawnAreaIndex];
                phalanxCallSignSpawnArea.Add(phalanxConstruction.GetPhalanxCallSign(), spawnArea);
                int spawnSide = 1;
                foreach (CombatantCallSign combatantCallSign in phalanxConstruction.GetCombatantCallSigns())
                {
                    combatantCallSignSpawnPositions.Add(combatantCallSign,
                        SpawnPosition.Builder.Get()
                        .SetSpawnArea(spawnArea)
                        .SetSpawnSide((SpawnSide)spawnSide)
                        .Build());
                    spawnSide++;
                }
                spawnAreaIndex++;
            }
            // Todo: Populate the SortieTileModelConstrs
            return SortieMapModelConstruction.Builder.Get()
                .SetSortieTileModelConstruction()
                .Build();
        }
    }
}*/