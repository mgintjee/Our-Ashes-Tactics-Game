/*using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Combatants.CallSigns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Controls.AIs.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Controls.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Phalanxes.CallSigns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Phalanxes.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Utils.Enums;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Insignias.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Phalanxes.Constrs.Implementaions;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Phalanxes.Constrs.Inters;
using System;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Generators.Sorties.Phalanxes
{
    /// <summary>
    /// Random Phalanx Constrs
    /// </summary>
    public static class RandomPhalanxConstrs
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="random">            </param>
        /// <param name="phalanxCallSign">   </param>
        /// <param name="ControlType">       </param>
        /// <param name="phalanxCallSigns">  </param>
        /// <param name="combatantCallSigns"></param>
        /// <param name="insigniaScheme">    </param>
        /// <returns></returns>
        public static IPhalanxConstruction Generate(Random random, PhalanxCallSign phalanxCallSign,
            ControlID ControlType, ISet<PhalanxCallSign> phalanxCallSigns,
            ISet<CombatantCallSign> combatantCallSigns, IInsigniaReport insigniaScheme)
        {
            return new PhalanxConstruction.Builder()
                .SetPhalanxCallSign(phalanxCallSign)
                .SetControlType(ControlType)
                .SetAIType((ControlType == ControlID.AI)
                    ? RandomEnums.GenerateRandomEnum<AIType>(random)
                    : AIType.None)
                .SetCombatantCallSigns(combatantCallSigns)
                .SetInsigniaScheme(insigniaScheme)
                .SetPhalanxCallSigns(phalanxCallSigns)
                .SetPhalanxType(RandomEnums.GenerateRandomEnum<PhalanxType>(random))
                .Build();
        }
    }
}*/