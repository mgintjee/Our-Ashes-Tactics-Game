using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Controllers.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Mvcs.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Phalanxes.CallSigns.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Phalanxes.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Phalanxes.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Phalanxes.Reports.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Phalanxes.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Phalanxes.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Phalanxes.Implementaions
{
    /// <summary>
    /// Phalanx Model Implementation
    /// </summary>
    public class PhalanxModel
        : IPhalanxModel
    {
        // Provides logging capability to the SORTIE logs
        private readonly ILogger _logger = LoggerManager.GetLogger(MvcType.Sortie, new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly PhalanxCallSign phalanxCallSign;

        // Todo
        private readonly PhalanxType phalanxType;

        // Todo
        private ISet<CombatantCallSign> combatantCallSigns;

        // Todo
        private ControllerType controllerType;

        // Todo
        private ISet<PhalanxCallSign> phalanxCallSigns;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="phalanxConstruction"></param>
        public PhalanxModel(IPhalanxConstruction phalanxConstruction)
        {
            _logger.Info("Instantiating with {}", phalanxConstruction);
            phalanxCallSign = phalanxConstruction.GetPhalanxCallSign();
            phalanxType = phalanxConstruction.GetPhalanxType();
            controllerType = phalanxConstruction.GetControllerType();
            phalanxCallSigns = phalanxConstruction.GetPhalanxCallSigns();
            combatantCallSigns = phalanxConstruction.GetCombatantCallSigns();
        }

        /// <inheritdoc/>
        IPhalanxReport IPhalanxModel.GetReport()
        {
            return new PhalanxReport.Builder()
                .SetControllerType(controllerType)
                .SetPhalanxCallSign(phalanxCallSign)
                .SetPhalanxType(phalanxType)
                .SetPhalanxCallSigns(phalanxCallSigns)
                .SetCombatantCallSigns(combatantCallSigns)
                .Build();
        }
    }
}