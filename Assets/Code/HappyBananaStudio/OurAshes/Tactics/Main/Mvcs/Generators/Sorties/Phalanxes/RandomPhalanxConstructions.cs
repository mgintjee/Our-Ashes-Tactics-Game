using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.AIs.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Controllers.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Phalanxes.CallSigns;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Phalanxes.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Utils.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Schemes.Insignias.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Phalanxes.Constructions.Implementaions;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Phalanxes.Constructions.Interfaces;
using System;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Generators.Sorties.Phalanxes
{
    /// <summary>
    /// Random Phalanx Constructions
    /// </summary>
    public static class RandomPhalanxConstructions
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="random">            </param>
        /// <param name="phalanxCallSign">   </param>
        /// <param name="controllerType">    </param>
        /// <param name="phalanxCallSigns">  </param>
        /// <param name="combatantCallSigns"></param>
        /// <param name="insigniaScheme">    </param>
        /// <returns></returns>
        public static IPhalanxConstruction Generate(Random random, PhalanxCallSign phalanxCallSign,
            ControllerType controllerType, ISet<PhalanxCallSign> phalanxCallSigns,
            ISet<CombatantCallSign> combatantCallSigns, IInsigniaScheme insigniaScheme)
        {
            return new PhalanxConstruction.Builder()
                .SetPhalanxCallSign(phalanxCallSign)
                .SetControllerType(controllerType)
                .SetAIType((controllerType == ControllerType.AI)
                    ? RandomEnums.GenerateRandomEnum<AIType>(random)
                    : AIType.None)
                .SetCombatantCallSigns(combatantCallSigns)
                .SetInsigniaScheme(insigniaScheme)
                .SetPhalanxCallSigns(phalanxCallSigns)
                .SetPhalanxType(RandomEnums.GenerateRandomEnum<PhalanxType>(random))
                .Build();
        }
    }
}