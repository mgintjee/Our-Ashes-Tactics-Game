/*using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Combatants.CallSigns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Controls.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Engagements.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Mvcs.Simulations.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Phalanxes.CallSigns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Sorties.Maps.Spawns.Areas;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Utils.Enums;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Generators.Sorties.Insignias;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Generators.Sorties.Phalanxes;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Engagements.Constrs.Implementaions;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Engagements.Constrs.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Phalanxes.Constrs.Inters;
using System;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Generators.Sorties.Engagements
{
    /// <summary>
    /// Random Engagement Constrs
    /// </summary>
    public static class RandomEngagementConstrs
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="random">                  </param>
        /// <param name="simulationType">          </param>
        /// <param name="phalanxCount">            </param>
        /// <param name="maxPhalanxCombatantCount"></param>
        /// <returns></returns>
        public static IEngagementConstruction Generate(Random random, SimulationType simulationType,
            int phalanxCount, int maxPhalanxCombatantCount)
        {
            EngagementType engagementType = RandomEnums.GenerateRandomEnum<EngagementType>(random);
            ISet<IPhalanxConstruction> phalanxConstrs = new HashSet<IPhalanxConstruction>();
            int combatantIndex = 1;
            ControlID ControlType = (simulationType == SimulationType.Interactive)
                ? ControlID.None : ControlID.AI;

            ISet<PhalanxCallSign> phalanxCallSigns = GeneratePhalanxCallSigns(phalanxCount);
            IDictionary<PhalanxCallSign, ISet<PhalanxCallSign>> phalanxCallSignSets = GeneratePhalanxCallSignSets(random, phalanxCallSigns, engagementType);
            IDictionary<PhalanxCallSign, IInsigniaReport> phalanxCallSignInsigniaSchemes = GeneratePhalanxCallSignInsigniaSchemes(
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
                phalanxConstrs.Add(RandomPhalanxConstrs.Generate(random, phalanxCallSign,
                    (ControlType != ControlID.None) ? ControlType : RandomEnums.GenerateRandomEnum<ControlID>(random),
                    phalanxCallSignSets[phalanxCallSign],
                    phalanxCallSignCombatantCallSigns[phalanxCallSign],
                    phalanxCallSignInsigniaSchemes[phalanxCallSign]));
            }
            return new EngagementConstruction.Builder()
                .SetFormationType(engagementType)
                .SetPhalanxConstrs(phalanxConstrs)
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
        private static IDictionary<PhalanxCallSign, IInsigniaReport> GeneratePhalanxCallSignInsigniaSchemes(Random random,
            ISet<PhalanxCallSign> phalanxCallSigns, IDictionary<PhalanxCallSign, ISet<PhalanxCallSign>> phalanxCallSignSets,
            EngagementType engagementType)
        {
            IDictionary<PhalanxCallSign, IInsigniaReport> phalanxCallSignInsigniaSchemes = new Dictionary<PhalanxCallSign, IInsigniaReport>();

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
                IInsigniaReport insigniaSchemeA = RandomInsigniaSchemes.Generate(random);
                IInsigniaReport insigniaSchemeB = RandomInsigniaSchemes.Generate(random);

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
}*/