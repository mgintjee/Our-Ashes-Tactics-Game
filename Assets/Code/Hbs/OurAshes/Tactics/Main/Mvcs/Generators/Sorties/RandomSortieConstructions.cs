/*using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Mvcs.Simulations.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Mvcs.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Scripts.Unity.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Constrs.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Constrs.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Constrs.Inters;
using System;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Generators.Sorties
{
    /// <summary>
    /// Random Sortie Construction
    /// </summary>
    public static class RandomSortieConstrs
    {
        public static IMvcFrameConstruction Generate(IUnityScript unityScript)
        {
            SimulationType simulationType = SimulationType.BlackBox;
            IMvcControllerConstruction mvcControllerConstruction = null;
            IMvcModelConstruction mvcModelConstruction = null;
            IMvcViewConstruction mvcViewConstruction = null;
            return new MvcFrameConstruction.Builder()
                .SetMvcType(MvcType.Sortie)
                .SetSimulationType(simulationType)
                .SetUnityScript(unityScript)
                .SetMvcControllerConstruction(mvcControllerConstruction)
                .SetMvcModelConstruction(mvcModelConstruction)
                .SetMvcViewConstruction(mvcViewConstruction)
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="random">        </param>
        /// <param name="simulationType"></param>
        /// <param name="unityScript">   </param>
        /// <returns></returns>
        *//*
        public static IMvcFrameConstruction Generate(Random random,
            SimulationType simulationType, IUnityScript unityScript)
        {
            int mapSize = random.Next(3, 5);
            int phalanxCount = random.Next(2, GetMaxPhalanxCount(mapSize));
            int maxPhalanxCombatantCount = random.Next(1, GetMaxCombatantCount(mapSize, phalanxCount));
            IEngagementConstruction engagementConstruction = RandomEngagementConstrs.Generate(random, simulationType, phalanxCount, maxPhalanxCombatantCount);
            IMapConstruction mapConstruction = RandomMapConstrs.Generate(random, mapSize, engagementConstruction);
            IRosterConstruction rosterConstruction = RandomRosterConstrs.Generate(random, simulationType, engagementConstruction);
            IScoreConstruction scoreConstruction = RandomScoreConstrs.Generate(random);
            return new MvcSortieFrameConstruction.Builder()
                .SetSimulationType(simulationType)
                .SetUnityScript(unityScript)
                .SetEngagementConstruction(engagementConstruction)
                .SetMapConstruction(mapConstruction)
                .SetRosterConstruction(rosterConstruction)
                .SetScoreConstruction(scoreConstruction)
                .Build();
        }*//*

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
}*/