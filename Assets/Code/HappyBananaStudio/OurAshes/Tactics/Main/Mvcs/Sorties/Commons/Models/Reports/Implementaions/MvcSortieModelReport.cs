using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Reports.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Combats.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Engagements.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Models.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Orders.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Rosters.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Scores.Reports.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Models.Reports.Implementaions
{
    /// <summary>
    /// Mvc Sortie Model Report Implementation
    /// </summary>
    public class MvcSortieModelReport
        : AbstractReport, IMvcSortieModelReport
    {
        // Todo
        private readonly ICombatReport _combatReport;

        // Todo
        private readonly IEngagementReport _engagementReport;

        // Todo
        private readonly IMapReport _mapReport;

        // Todo
        private readonly IOrderReport _orderReport;

        // Todo
        private readonly IRosterReport _rosterReport;

        // Todo
        private readonly IScoreReport _scoreReport;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="combatReport">    </param>
        /// <param name="engagementReport"></param>
        /// <param name="mapReport">       </param>
        /// <param name="orderReport">     </param>
        /// <param name="rosterReport">    </param>
        /// <param name="scoreReport">     </param>
        public MvcSortieModelReport(ICombatReport combatReport, IEngagementReport engagementReport,
            IMapReport mapReport, IOrderReport orderReport, IRosterReport rosterReport, IScoreReport scoreReport)
        {
            _combatReport = combatReport;
            _engagementReport = engagementReport;
            _mapReport = mapReport;
            _orderReport = orderReport;
            _rosterReport = rosterReport;
            _scoreReport = scoreReport;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}:{1}: " +
                "\n{2}" +
                "\n{3}" +
                "\n{4}" +
                "\n{5}" +
                "\n{6}" +
                "\n{7}",
                this._dateTime, this.GetType().Name,
                StringUtils.Format(typeof(ICombatReport), this._combatReport),
                StringUtils.Format(typeof(IEngagementReport), this._engagementReport),
                StringUtils.Format(typeof(IMapReport), this._mapReport),
                StringUtils.Format(typeof(IOrderReport), this._orderReport),
                StringUtils.Format(typeof(IRosterReport), this._rosterReport),
                StringUtils.Format(typeof(IScoreReport), this._scoreReport));
        }

        /// <inheritdoc/>
        ICombatReport IMvcSortieModelReport.GetCombatReport()
        {
            return _combatReport;
        }

        /// <inheritdoc/>
        IEngagementReport IMvcSortieModelReport.GetEngagementReport()
        {
            return _engagementReport;
        }

        /// <inheritdoc/>
        IMapReport IMvcSortieModelReport.GetMapReport()
        {
            return _mapReport;
        }

        /// <inheritdoc/>
        IOrderReport IMvcSortieModelReport.GetOrderReport()
        {
            return _orderReport;
        }

        /// <inheritdoc/>
        IRosterReport IMvcSortieModelReport.GetRosterReport()
        {
            return _rosterReport;
        }

        /// <inheritdoc/>
        IScoreReport IMvcSortieModelReport.GetScoreReport()
        {
            return _scoreReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private ICombatReport _combatReport = null;

            // Todo
            private IEngagementReport _engagementReport = null;

            // Todo
            private IMapReport _mapReport = null;

            // Todo
            private IOrderReport _orderReport = null;

            // Todo
            private IRosterReport _rosterReport = null;

            // Todo
            private IScoreReport _scoreReport = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IMvcSortieModelReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new construction
                    return new MvcSortieModelReport(_combatReport, _engagementReport, _mapReport, _orderReport, _rosterReport, _scoreReport);
                }
                throw ExceptionUtil.Arguments.Build("Unable to construct {}. Invalid Parameters. {}",
                    this.GetType(), string.Join("\n", invalidReasons));
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="combatReport"></param>
            /// <returns></returns>
            public Builder SetCombatReport(ICombatReport combatReport)
            {
                _combatReport = combatReport;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="engagementReport"></param>
            /// <returns></returns>
            public Builder SetEngagementReport(IEngagementReport engagementReport)
            {
                _engagementReport = engagementReport;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="mapReport"></param>
            /// <returns></returns>
            public Builder SetMapReport(IMapReport mapReport)
            {
                _mapReport = mapReport;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="orderReport"></param>
            /// <returns></returns>
            public Builder SetOrderReport(IOrderReport orderReport)
            {
                _orderReport = orderReport;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="rosterReport"></param>
            /// <returns></returns>
            public Builder SetRosterReport(IRosterReport rosterReport)
            {
                _rosterReport = rosterReport;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="scoreReport"></param>
            /// <returns></returns>
            public Builder SetScoreReport(IScoreReport scoreReport)
            {
                _scoreReport = scoreReport;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            private ISet<string> IsInvalid()
            {
                // Default an empty Set: String
                ISet<string> argumentExceptionSet = new HashSet<string>();
                // Check that _combatReport has been set
                if (_combatReport == null)
                {
                    argumentExceptionSet.Add(typeof(ICombatReport).Name + " cannot be null.");
                }
                // Check that _engagementReport has been set
                if (_engagementReport == null)
                {
                    argumentExceptionSet.Add(typeof(IEngagementReport).Name + " cannot be null.");
                }
                // Check that _mapReport has been set
                if (_mapReport == null)
                {
                    argumentExceptionSet.Add(typeof(IMapReport).Name + " cannot be null.");
                }
                // Check that _orderReport has been set
                if (_orderReport == null)
                {
                    argumentExceptionSet.Add(typeof(IOrderReport).Name + " cannot be null.");
                }
                // Check that _rosterReport has been set
                if (_rosterReport == null)
                {
                    argumentExceptionSet.Add(typeof(IRosterReport).Name + " cannot be null.");
                }
                // Check that _scoreReport has been set
                if (_scoreReport == null)
                {
                    argumentExceptionSet.Add(typeof(IScoreReport).Name + " cannot be null.");
                }
                return argumentExceptionSet;
            }
        }
    }
}