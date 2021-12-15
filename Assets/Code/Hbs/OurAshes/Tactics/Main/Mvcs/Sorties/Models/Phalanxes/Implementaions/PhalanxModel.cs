using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Frames.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Classes.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.CallSigns;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Phalanxes.CallSigns;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Phalanxes.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Models.Engagements.Phalanxes.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Phalanxes.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Phalanxes.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Phalanxes.Inters;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Phalanxes.Implementaions
{
    /// <summary>
    /// Phalanx Model Impl
    /// </summary>
    public class PhalanxModel : IPhalanxModel
    {
        // Provides logging capability to the SORTIE logs
        private readonly IClassLogger _logger = LoggerManager.GetLogger(MvcType.Sortie)
            .GetClassLogger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly PhalanxCallSign phalanxCallSign;

        // Todo
        private readonly PhalanxType phalanxType;

        // Todo
        private ISet<CombatantCallSign> combatantCallSigns;

        // Todo
        private ISet<PhalanxCallSign> phalanxCallSigns;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="phalanxConstruction"></param>
        public PhalanxModel(IPhalanxModelConstruction phalanxConstruction)
        {
            _logger.Info("Instantiating with {}", phalanxConstruction);
            phalanxCallSign = phalanxConstruction.GetPhalanxCallSign();
            phalanxType = phalanxConstruction.GetPhalanxType();
            phalanxCallSigns = phalanxConstruction.GetPhalanxCallSigns();
            combatantCallSigns = phalanxConstruction.GetCombatantCallSigns();
        }

        /// <inheritdoc/>
        IPhalanxReport IPhalanxModel.GetReport()
        {
            return new PhalanxReport.Builder()
                .SetPhalanxCallSign(phalanxCallSign)
                .SetPhalanxType(phalanxType)
                .SetPhalanxCallSigns(phalanxCallSigns)
                .SetCombatantCallSigns(combatantCallSigns)
                .Build();
        }
    }
}