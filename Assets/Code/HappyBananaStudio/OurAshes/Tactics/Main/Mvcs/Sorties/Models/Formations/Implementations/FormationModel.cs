using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Phalanxes.CallSigns.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Formations.Reports.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Formations.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Formations.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constructions.Formations.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constructions.Phalanxes.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Models.Rosters.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Phalanxes.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Formations.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Phalanxes.Implementaions;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Phalanxes.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Formations.Implementations
{
    /// <summary>
    /// Todo
    /// </summary>
    public class FormationModel
        : IFormationModel
    {
        // Todo
        private readonly ISet<PhalanxCallSign> _activeCallSigns;

        // Todo
        private readonly ISet<IPhalanxModel> _models;

        // Todo
        private readonly FormationType _formationType;

        // Todo
        private IFormationReport _report;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="formationConstruction"></param>
        public FormationModel(IFormationConstruction formationConstruction)
        {
            _formationType = formationConstruction.GetFormationType();
            _models = new HashSet<IPhalanxModel>();
            _activeCallSigns = new HashSet<PhalanxCallSign>();
            foreach (IPhalanxConstruction construction in formationConstruction.GetPhalanxConstructions())
            {
                _activeCallSigns.Add(construction.GetPhalanxCallSign());
                _models.Add(new PhalanxModel(construction.GetPhalanxModelConstruction()));
            }
            this.BuildReport();
        }

        /// <inheritdoc/>
        IFormationReport IFormationModel.GetReport()
        {
            return _report;
        }

        /// <inheritdoc/>
        void IFormationModel.Process(IRosterReport rosterReport)
        {
            ISet<PhalanxCallSign> activePhalanxCallSigns = new HashSet<PhalanxCallSign>();

            foreach (CombatantCallSign combatantCallSign in rosterReport.GetActiveCombatantCallSigns())
            {
                foreach (IPhalanxModel model in _models)
                {
                    IPhalanxReport phalanxReport = model.GetReport();
                    if (phalanxReport.GetCombatantCallSigns().Contains(combatantCallSign))
                    {
                        activePhalanxCallSigns.Add(phalanxReport.GetPhalanxCallSign());
                        break;
                    }
                }
            }

            _activeCallSigns.Clear();
            _activeCallSigns.UnionWith(activePhalanxCallSigns);
            this.BuildReport();
        }

        /// <inheritdoc/>
        bool IFormationModel.AreFriendly(PhalanxCallSign callSignA, PhalanxCallSign callSignB)
        {
            if (callSignA == PhalanxCallSign.None ||
                callSignB == PhalanxCallSign.None)
            {
                return false;
            }
            else if (callSignA == callSignB)
            {
                return true;
            }
            ISet<PhalanxCallSign> friendlyCallSignsA = new HashSet<PhalanxCallSign>() { callSignA };
            ISet<PhalanxCallSign> friendlyCallSignsB = new HashSet<PhalanxCallSign>() { callSignB };
            IPhalanxReport phalanxReportA = _report.GetPhalanxReport(callSignA).GetValue();
            IPhalanxReport phalanxReportB = _report.GetPhalanxReport(callSignB).GetValue();
            friendlyCallSignsA.UnionWith(phalanxReportA.GetPhalanxCallSigns());
            friendlyCallSignsB.UnionWith(phalanxReportB.GetPhalanxCallSigns());
            return friendlyCallSignsA.Contains(callSignB) &&
                friendlyCallSignsB.Contains(callSignA);
        }

        /// <inheritdoc/>
        bool IFormationModel.AreFriendly(CombatantCallSign callSignA, CombatantCallSign callSignB)
        {
            return ((IFormationModel)this).AreFriendly(
                this.GetPhalanxCallSign(callSignA),
                this.GetPhalanxCallSign(callSignB));
        }

        /// <inheritdoc/>
        bool IFormationModel.AreFriendly(CombatantCallSign combatantCallSign, PhalanxCallSign phalanxCallSign)
        {
            return ((IFormationModel)this).AreFriendly(
                this.GetPhalanxCallSign(combatantCallSign),
                phalanxCallSign);
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void BuildReport()
        {
            ISet<IPhalanxReport> phalanxReports = new HashSet<IPhalanxReport>();
            ISet<PhalanxCallSign> phalanxCallSigns = new HashSet<PhalanxCallSign>();

            foreach (IPhalanxModel model in _models)
            {
                IPhalanxReport report = model.GetReport();
                phalanxCallSigns.Add(report.GetPhalanxCallSign());
                phalanxReports.Add(report);
            }

            _report = new FormationReport.Builder()
                .SetFormationType(_formationType)
                .SetActivePhalanxCallSigns(_activeCallSigns)
                .SetAllPhalanxCallSigns(phalanxCallSigns)
                .SetPhalanxReports(phalanxReports)
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="callSign"></param>
        private PhalanxCallSign GetPhalanxCallSign(CombatantCallSign callSign)
        {
            // Iterate over all of the models
            foreach (IPhalanxModel model in _models)
            {
                IPhalanxReport phalanxReport = model.GetReport();
                // Check if the combatantCallSigns contains the CombatantCallSign
                if (phalanxReport.GetCombatantCallSigns().Contains(callSign))
                {
                    return phalanxReport.GetPhalanxCallSign();
                }
            }
            return PhalanxCallSign.None;
        }
    }
}