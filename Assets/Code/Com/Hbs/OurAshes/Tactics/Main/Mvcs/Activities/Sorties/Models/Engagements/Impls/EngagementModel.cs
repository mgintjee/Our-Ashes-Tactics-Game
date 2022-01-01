﻿using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.CallSigns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Engagements.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Phalanxes.CallSigns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Constrs.Models.Engagements.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Constrs.Models.Engagements.Phalanxes.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Models.Engagements.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Models.Phalanxes.Implementaions;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Models.Phalanxes.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Reports.Models.Engagements.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Reports.Models.Engagements.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Reports.Models.Phalanxes.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Reports.Models.Rosters.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Models.Engagements.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class EngagementModel : IEngagementModel
    {
        // Todo
        private readonly ISet<PhalanxCallSign> _activeCallSigns;

        // Todo
        private readonly ISet<IPhalanxModel> _models;

        // Todo
        private readonly EngagementType _engagementType;

        // Todo
        private IEngagementReport _report;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="formationConstruction"></param>
        public EngagementModel(IEngagementModelConstruction formationConstruction)
        {
            _engagementType = formationConstruction.GetEngagementType();
            _models = new HashSet<IPhalanxModel>();
            _activeCallSigns = new HashSet<PhalanxCallSign>();
            foreach (IPhalanxModelConstruction construction in formationConstruction.GetPhalanxConstrs())
            {
                _activeCallSigns.Add(construction.GetPhalanxCallSign());
                _models.Add(new PhalanxModel(construction));
            }
            this.BuildReport();
        }

        /// <inheritdoc/>
        IEngagementReport IEngagementModel.GetReport()
        {
            return _report;
        }

        /// <inheritdoc/>
        void IEngagementModel.Process(IRosterModelReport rosterReport)
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
        bool IEngagementModel.AreFriendly(PhalanxCallSign callSignA, PhalanxCallSign callSignB)
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
        bool IEngagementModel.AreFriendly(CombatantCallSign callSignA, CombatantCallSign callSignB)
        {
            return ((IEngagementModel)this).AreFriendly(
                this.GetPhalanxCallSign(callSignA),
                this.GetPhalanxCallSign(callSignB));
        }

        /// <inheritdoc/>
        bool IEngagementModel.AreFriendly(CombatantCallSign combatantCallSign, PhalanxCallSign phalanxCallSign)
        {
            return ((IEngagementModel)this).AreFriendly(
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

            _report = new EngagementReport.Builder()
                .SetEngagementType(_engagementType)
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