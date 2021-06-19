using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scripts.Unity.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Simulations.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Randoms.Sorties.Engagements;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Randoms.Sorties.Maps;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Randoms.Sorties.Rosters;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Randoms.Sorties.Scores;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Engagements.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constructions.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Rosters.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Scores.Constructions.Interfaces;
using System;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Randoms.Sorties
{
    /// <summary>
    /// Random Sortie Construction
    /// </summary>
    public static class RandomSortieConstructions
    {
        // Provides logging capability to the CENTRAL logs
        private static readonly ILogger _logger = LoggerManager.GetCentralLogger(new StackFrame().GetMethod().DeclaringType);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="random">        </param>
        /// <param name="simulationType"></param>
        /// <param name="unityScript">   </param>
        /// <returns></returns>
        public static IMvcSortieFrameConstruction Generate(Random random,
            SimulationType simulationType, IUnityScript unityScript)
        {
            // Todo: Generate the common information here and pass it along
            int mapSize = random.Next(3, 5);
            int phalanxCount = random.Next(2, GetMaxPhalanxCount(mapSize));
            int maxPhalanxCombatantCount = phalanxCount * random.Next(1, GetMaxCombatantCount(mapSize, phalanxCount));
            _logger.Info("MapSize: {}, PhalanxCount: {}, MaxPhalanxCombatantCount: {}", mapSize, phalanxCount, maxPhalanxCombatantCount);
            IEngagementConstruction engagementConstruction = RandomEngagementConstructions.Generate(random, simulationType, phalanxCount, maxPhalanxCombatantCount);
            IMapConstruction mapConstruction = RandomMapConstructions.Generate(random, mapSize, engagementConstruction);
            IRosterConstruction rosterConstruction = RandomRosterConstructions.Generate(random, simulationType, engagementConstruction);
            IScoreConstruction scoreConstruction = RandomScoreConstructions.Generate(random);
            return new MvcSortieFrameConstruction.Builder()
                .SetSimulationType(simulationType)
                .SetUnityScript(unityScript)
                .SetEngagementConstruction(engagementConstruction)
                .SetMapConstruction(mapConstruction)
                .SetRosterConstruction(rosterConstruction)
                .SetScoreConstruction(scoreConstruction)
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mapSize"></param>
        /// <returns></returns>
        private static int GetMaxPhalanxCount(int mapSize)
        {
            return mapSize;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mapSize">     </param>
        /// <param name="phalanxCount"></param>
        /// <returns></returns>
        private static int GetMaxCombatantCount(int mapSize, int phalanxCount)
        {
            return Math.Max(mapSize + 2 - phalanxCount, 4);
        }
    }
}