/*using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Combatants.CallSigns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Engagements.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Mvcs.Simulations.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Phalanxes.CallSigns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Generators.Sorties.Combatants;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Generators.Sorties.Insignias;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Engagements.Constrs.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Phalanxes.Constrs.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Rosters.Constrs.Implementaions;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Rosters.Constrs.Inters;
using System;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Generators.Sorties.Rosters
{
    /// <summary>
    /// Random Roster Constrs
    /// </summary>
    public static class RandomRosterConstrs
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
            ISet<ICombatantConstruction> combatantConstrs = new HashSet<ICombatantConstruction>();
            IDictionary<PhalanxCallSign, IInsigniaReport> phalanxCallSignInsigniaScheme = new Dictionary<PhalanxCallSign, IInsigniaReport>();
            EngagementType engagementType = engagementConstruction.GetEngagementType();
            if (engagementType == EngagementType.Faction)
            {
                IInsigniaReport insigniaSchemeA = RandomInsigniaSchemes.Generate(random);
                IInsigniaReport insigniaSchemeB = RandomInsigniaSchemes.Generate(random);
                ISet<PhalanxCallSign> phalanxCallSignsA = new HashSet<PhalanxCallSign>();
                ISet<PhalanxCallSign> phalanxCallSignsB = new HashSet<PhalanxCallSign>();
                foreach (IPhalanxConstruction phalanxConstruction in engagementConstruction.GetPhalanxConstrs())
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
                foreach (IPhalanxConstruction phalanxConstruction in engagementConstruction.GetPhalanxConstrs())
                {
                    phalanxCallSignInsigniaScheme.Add(phalanxConstruction.GetPhalanxCallSign(),
                        RandomInsigniaSchemes.Generate(random));
                }
            }
            foreach (IPhalanxConstruction phalanxConstruction in engagementConstruction.GetPhalanxConstrs())
            {
                foreach (CombatantCallSign combatantCallSign in phalanxConstruction.GetCombatantCallSigns())
                {
                    ICombatantConstruction combatantConstruction = (simulationType != SimulationType.BlackBox)
                        ? RandomCombatantConstrs.Generate(random, combatantCallSign, phalanxCallSignInsigniaScheme[phalanxConstruction.GetPhalanxCallSign()])
                        : RandomCombatantConstrs.Generate(random, combatantCallSign);
                    combatantConstrs.Add(combatantConstruction);
                }
            }
            return new RosterConstruction.Builder()
                .SetCombatantConstrs(combatantConstrs)
                .Build();
        }
    }
}*/