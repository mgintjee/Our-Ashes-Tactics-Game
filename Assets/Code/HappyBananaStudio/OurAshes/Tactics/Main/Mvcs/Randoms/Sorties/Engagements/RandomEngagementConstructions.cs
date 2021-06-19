using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Controllers.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Engagements.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Maps.Spawns.Areas.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Phalanxes.CallSigns.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Simulations.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Schemes.Insignias.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Randoms.Commons.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Randoms.Sorties.Insignias;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Randoms.Sorties.Phalanxes;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Engagements.Constructions.Implementaions;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Engagements.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Phalanxes.Constructions.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Randoms.Sorties.Engagements
{
    /// <summary>
    /// Random Engagement Constructions
    /// </summary>
    public static class RandomEngagementConstructions
    {
        // Provides logging capability to the CENTRAL logs
        private static readonly ILogger _logger = LoggerManager.GetCentralLogger(new StackFrame().GetMethod().DeclaringType);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="random">                         </param>
        /// <param name="simulationType">                 </param>
        /// <param name="phalanxCount">                   </param>
        /// <param name="maxPhalanxCombatantCount">       </param>
        /// <param name="combatantCallSignSpawnPositions"></param>
        /// <param name="">                               </param>
        /// <returns></returns>
        public static IEngagementConstruction Generate(Random random, SimulationType simulationType,
            int phalanxCount, int maxPhalanxCombatantCount)
        {
            EngagementType engagementType = RandomEnums.GenerateRandomEnum<EngagementType>(random);
            _logger.Debug("engagementType: {}", engagementType);
            ISet<IPhalanxConstruction> phalanxConstructions = new HashSet<IPhalanxConstruction>();
            int combatantIndex = 1;
            ControllerType controllerType = (simulationType == SimulationType.Interactive)
                ? ControllerType.None : ControllerType.AI;

            ISet<PhalanxCallSign> phalanxCallSigns = GeneratePhalanxCallSigns(phalanxCount);
            IDictionary<PhalanxCallSign, ISet<PhalanxCallSign>> phalanxCallSignSets = GeneratePhalanxCallSignSets(random, phalanxCallSigns, engagementType);
            IDictionary<PhalanxCallSign, IInsigniaScheme> phalanxCallSignInsigniaSchemes = GeneratePhalanxCallSignInsigniaSchemes(
                random, phalanxCallSigns, phalanxCallSignSets, engagementType);
            IDictionary<PhalanxCallSign, ISet<CombatantCallSign>> phalanxCallSignCombatantCallSigns = new Dictionary<PhalanxCallSign, ISet<CombatantCallSign>>();
            for (int i = 0; i < phalanxCount; ++i)
            {
                PhalanxCallSign phalanxCallSign = (PhalanxCallSign)(i + 1);
                phalanxCallSigns.Add(phalanxCallSign);
                ISet<CombatantCallSign> phalanxCombatantCallSigns = new HashSet<CombatantCallSign>();
                int phalanxCombatantCount = random.Next(1, maxPhalanxCombatantCount);
                for (int j = 0; j < phalanxCombatantCount; ++j)
                {
                    phalanxCombatantCallSigns.Add((CombatantCallSign)(combatantIndex));
                    combatantIndex++;
                }
                phalanxCallSignCombatantCallSigns.Add(phalanxCallSign, phalanxCombatantCallSigns);
            }

            foreach (PhalanxCallSign phalanxCallSign in phalanxCallSigns)
            {
                phalanxConstructions.Add(RandomPhalanxConstructions.Generate(random, phalanxCallSign,
                    (controllerType != ControllerType.None) ? controllerType : RandomEnums.GenerateRandomEnum<ControllerType>(random),
                    phalanxCallSignSets[phalanxCallSign],
                    phalanxCallSignCombatantCallSigns[phalanxCallSign],
                    phalanxCallSignInsigniaSchemes[phalanxCallSign]));
            }
            return new EngagementConstruction.Builder()
                .SetFormationType(engagementType)
                .SetPhalanxConstructions(phalanxConstructions)
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="spawnAreas"></param>
        /// <returns></returns>
        private static SpawnArea GenerateSpawnArea(Random random, ISet<SpawnArea> spawnAreas)
        {
            SpawnArea spawnArea = RandomEnums.GenerateRandomEnum<SpawnArea>(random);

            if (spawnAreas.Contains(spawnArea))
            {
                return GenerateSpawnArea(random, spawnAreas);
            }

            return spawnArea;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="count"></param>
        private static ISet<PhalanxCallSign> GeneratePhalanxCallSigns(int count)
        {
            ISet<PhalanxCallSign> phalanxCallSigns = new HashSet<PhalanxCallSign>();

            for (int i = 0; i < count; ++i)
            {
                phalanxCallSigns.Add((PhalanxCallSign)i + 1);
            }

            return phalanxCallSigns;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="random">          </param>
        /// <param name="phalanxCallSigns"></param>
        /// <param name="engagementType">  </param>
        /// <returns></returns>
        private static IDictionary<PhalanxCallSign, ISet<PhalanxCallSign>> GeneratePhalanxCallSignSets(Random random,
            ISet<PhalanxCallSign> phalanxCallSigns, EngagementType engagementType)
        {
            IDictionary<PhalanxCallSign, ISet<PhalanxCallSign>> phalanxCallSignSets = new Dictionary<PhalanxCallSign, ISet<PhalanxCallSign>>();
            if (engagementType == EngagementType.Faction)
            {
                ISet<PhalanxCallSign> phalanxCallSignsA = new HashSet<PhalanxCallSign>() { (PhalanxCallSign)1 };
                ISet<PhalanxCallSign> phalanxCallSignsB = new HashSet<PhalanxCallSign>() { (PhalanxCallSign)2 };
                foreach (PhalanxCallSign phalanxCallSign in phalanxCallSigns)
                {
                    if (!phalanxCallSignsA.Contains(phalanxCallSign) &&
                        !phalanxCallSignsB.Contains(phalanxCallSign))
                    {
                        if (random.Next() % 2 == 0)
                        {
                            phalanxCallSignsA.Add(phalanxCallSign);
                        }
                        else
                        {
                            phalanxCallSignsB.Add(phalanxCallSign);
                        }
                    }
                }
                foreach (PhalanxCallSign phalanxCallSign in phalanxCallSignsA)
                {
                    phalanxCallSignSets.Add(phalanxCallSign, phalanxCallSignsA);
                }
                foreach (PhalanxCallSign phalanxCallSign in phalanxCallSignsB)
                {
                    phalanxCallSignSets.Add(phalanxCallSign, phalanxCallSignsB);
                }
            }
            else if (engagementType == EngagementType.Phalanx)
            {
                foreach (PhalanxCallSign phalanxCallSign in phalanxCallSigns)
                {
                    phalanxCallSignSets.Add(phalanxCallSign, new HashSet<PhalanxCallSign>() { phalanxCallSign });
                }
            }
            return phalanxCallSignSets;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="random">          </param>
        /// <param name="phalanxCallSigns"></param>
        /// <param name="engagementType">  </param>
        /// <returns></returns>
        private static IDictionary<PhalanxCallSign, IInsigniaScheme> GeneratePhalanxCallSignInsigniaSchemes(Random random,
            ISet<PhalanxCallSign> phalanxCallSigns, IDictionary<PhalanxCallSign, ISet<PhalanxCallSign>> phalanxCallSignSets,
            EngagementType engagementType)
        {
            IDictionary<PhalanxCallSign, IInsigniaScheme> phalanxCallSignInsigniaSchemes = new Dictionary<PhalanxCallSign, IInsigniaScheme>();

            if (engagementType == EngagementType.Phalanx)
            {
                foreach (PhalanxCallSign phalanxCallSign in phalanxCallSigns)
                {
                    phalanxCallSignInsigniaSchemes.Add(phalanxCallSign, RandomInsigniaSchemes.Generate(random));
                }
            }
            else if (engagementType == EngagementType.Faction)
            {
                ISet<PhalanxCallSign> phalanxCallSignsA = null;
                ISet<PhalanxCallSign> phalanxCallSignsB = null;
                IInsigniaScheme insigniaSchemeA = RandomInsigniaSchemes.Generate(random);
                IInsigniaScheme insigniaSchemeB = RandomInsigniaSchemes.Generate(random);

                foreach (PhalanxCallSign phalanxCallSign in phalanxCallSigns)
                {
                    if (phalanxCallSignsA == null)
                    {
                        phalanxCallSignsA = phalanxCallSignSets[phalanxCallSign];
                        phalanxCallSignInsigniaSchemes.Add(phalanxCallSign, insigniaSchemeA);
                    }
                    else if (phalanxCallSignsA.Contains(phalanxCallSign))
                    {
                        phalanxCallSignInsigniaSchemes.Add(phalanxCallSign, insigniaSchemeA);
                    }
                    else if (phalanxCallSignsB == null)
                    {
                        phalanxCallSignsB = phalanxCallSignSets[phalanxCallSign];
                        phalanxCallSignInsigniaSchemes.Add(phalanxCallSign, insigniaSchemeB);
                    }
                    else if (phalanxCallSignsB.Contains(phalanxCallSign))
                    {
                        phalanxCallSignInsigniaSchemes.Add(phalanxCallSign, insigniaSchemeB);
                    }
                }
            }

            return phalanxCallSignInsigniaSchemes;
        }
    }
}