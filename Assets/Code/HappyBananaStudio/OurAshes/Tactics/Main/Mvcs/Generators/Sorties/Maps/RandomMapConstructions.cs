/*using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Phalanxes.CallSigns;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Sorties.Maps.Spawns.Areas;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Sorties.Maps.Spawns.Sides;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Utils.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Engagements.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Constructions.Models.Implementaions;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Constructions.Models.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Spawns.Positions.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Spawns.Positions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Phalanxes.Constructions.Interfaces;
using System;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Generators.Sorties.Maps
{
    /// <summary>
    /// Random Map Constructions
    /// </summary>
    public static class RandomMapConstructions
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
            ISet<IPhalanxConstruction> phalanxConstructions = new HashSet<IPhalanxConstruction>(engagementConstruction.GetPhalanxConstructions());
            IList<SpawnArea> spawnAreas = EnumUtils.GetEnumList<SpawnArea>(phalanxConstructions.Count);
            int spawnAreaIndex = 0;
            foreach (IPhalanxConstruction phalanxConstruction in phalanxConstructions)
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
            // Todo: Populate the SortieTileModelConstructions
            return SortieMapModelConstruction.Builder.Get()
                .SetSortieTileModelConstruction()
                .Build();
        }
    }
}*/