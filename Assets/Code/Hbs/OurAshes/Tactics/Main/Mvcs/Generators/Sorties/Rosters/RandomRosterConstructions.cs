/*using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Combatants.CallSigns;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Engagements.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Mvcs.Simulations.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Phalanxes.CallSigns;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Generators.Sorties.Combatants;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Generators.Sorties.Insignias;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Engagements.Constructions.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Phalanxes.Constructions.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Rosters.Constructions.Implementaions;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Rosters.Constructions.Interfaces;
using System;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Generators.Sorties.Rosters
{
    /// <summary>
    /// Random Roster Constructions
    /// </summary>
    public static class RandomRosterConstructions
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="random">                </param>
        /// <param name="simulationType">        </param>
        /// <param name="engagementConstruction"></param>
        /// <returns></returns>
        public static IRosterConstruction Generate(Random random, SimulationType simulationType, IEngagementConstruction engagementConstruction)
        {
            ISet<ICombatantConstruction> combatantConstructions = new HashSet<ICombatantConstruction>();
            IDictionary<PhalanxCallSign, IInsigniaReport> phalanxCallSignInsigniaScheme = new Dictionary<PhalanxCallSign, IInsigniaReport>();
            EngagementType engagementType = engagementConstruction.GetEngagementType();
            if (engagementType == EngagementType.Faction)
            {
                IInsigniaReport insigniaSchemeA = RandomInsigniaSchemes.Generate(random);
                IInsigniaReport insigniaSchemeB = RandomInsigniaSchemes.Generate(random);
                ISet<PhalanxCallSign> phalanxCallSignsA = new HashSet<PhalanxCallSign>();
                ISet<PhalanxCallSign> phalanxCallSignsB = new HashSet<PhalanxCallSign>();
                foreach (IPhalanxConstruction phalanxConstruction in engagementConstruction.GetPhalanxConstructions())
                {
                    PhalanxCallSign phalanxCallSign = phalanxConstruction.GetPhalanxCallSign();
                    if (phalanxCallSignsA == null)
                    {
                        phalanxCallSignsA = phalanxConstruction.GetPhalanxCallSigns();
                        phalanxCallSignInsigniaScheme.Add(phalanxCallSign, insigniaSchemeA);
                    }
                    else if (phalanxCallSignsA.Contains(phalanxCallSign))
                    {
                        phalanxCallSignInsigniaScheme.Add(phalanxCallSign, insigniaSchemeA);
                    }
                    else if (phalanxCallSignsB == null)
                    {
                        phalanxCallSignsB = phalanxConstruction.GetPhalanxCallSigns();
                        phalanxCallSignInsigniaScheme.Add(phalanxConstruction.GetPhalanxCallSign(), insigniaSchemeB);
                    }
                    else if (phalanxCallSignsB.Contains(phalanxCallSign))
                    {
                        phalanxCallSignInsigniaScheme.Add(phalanxCallSign, insigniaSchemeB);
                    }
                }
            }
            else if (engagementType == EngagementType.Phalanx)
            {
                foreach (IPhalanxConstruction phalanxConstruction in engagementConstruction.GetPhalanxConstructions())
                {
                    phalanxCallSignInsigniaScheme.Add(phalanxConstruction.GetPhalanxCallSign(),
                        RandomInsigniaSchemes.Generate(random));
                }
            }
            foreach (IPhalanxConstruction phalanxConstruction in engagementConstruction.GetPhalanxConstructions())
            {
                foreach (CombatantCallSign combatantCallSign in phalanxConstruction.GetCombatantCallSigns())
                {
                    ICombatantConstruction combatantConstruction = (simulationType != SimulationType.BlackBox)
                        ? RandomCombatantConstructions.Generate(random, combatantCallSign, phalanxCallSignInsigniaScheme[phalanxConstruction.GetPhalanxCallSign()])
                        : RandomCombatantConstructions.Generate(random, combatantCallSign);
                    combatantConstructions.Add(combatantConstruction);
                }
            }
            return new RosterConstruction.Builder()
                .SetCombatantConstructions(combatantConstructions)
                .Build();
        }
    }
}*/