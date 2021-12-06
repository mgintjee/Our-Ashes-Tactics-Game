using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Reports.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Controllers.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Combats.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Engagements.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Maps.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Orders.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Rosters.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Scores.Inters;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Controllers.Implementaions
{
    /// <summary>
    /// Sortie Model Report Implementation
    /// </summary>
    public class SortieModelReport : AbstractReport, ISortieModelReport
    {
        // Todo
        private readonly ICombatReport _combatReport;

        // Todo
        private readonly IEngagementReport _engagementReport;

        // Todo
        private readonly ISortieMapReport _mapReport;

        // Todo
        private readonly IOrderReport _orderReport;

        // Todo
        private readonly IRosterModelReport _rosterReport;

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
        public SortieModelReport(ICombatReport combatReport, IEngagementReport engagementReport,
            ISortieMapReport mapReport, IOrderReport orderReport, IRosterModelReport rosterReport, IScoreReport scoreReport)
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
                _dateTime, GetType().Name,
                StringUtils.Format(_combatReport),
                StringUtils.Format(_engagementReport),
                StringUtils.Format(_mapReport),
                StringUtils.Format(_orderReport),
                StringUtils.Format(_rosterReport),
                StringUtils.Format(_scoreReport));
        }

        /// <inheritdoc/>
        ICombatReport ISortieModelReport.GetCombatReport()
        {
            return _combatReport;
        }

        /// <inheritdoc/>
        IEngagementReport ISortieModelReport.GetEngagementReport()
        {
            return _engagementReport;
        }

        /// <inheritdoc/>
        ISortieMapReport ISortieModelReport.GetMapReport()
        {
            return _mapReport;
        }

        /// <inheritdoc/>
        IOrderReport ISortieModelReport.GetOrderReport()
        {
            return _orderReport;
        }

        /// <inheritdoc/>
        IRosterModelReport ISortieModelReport.GetRosterReport()
        {
            return _rosterReport;
        }

        /// <inheritdoc/>
        IScoreReport ISortieModelReport.GetScoreReport()
        {
            return _scoreReport;
        }

        /// <inheritdoc/>
        protected override string GetContent()
        {
            return string.Format("{0}: {1}, {2}, {3}",
                _combatReport, _engagementReport, _mapReport, _orderReport, _rosterReport, _scoreReport);
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
            private ISortieMapReport _mapReport = null;

            // Todo
            private IOrderReport _orderReport = null;

            // Todo
            private IRosterModelReport _rosterReport = null;

            // Todo
            private IScoreReport _scoreReport = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public ISortieModelReport Build()
            {
                ISet<string> invalidReasons = IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new construction
                    return new SortieModelReport(_combatReport, _engagementReport, _mapReport, _orderReport, _rosterReport, _scoreReport);
                }
                throw ExceptionUtil.Arguments.Build("Unable to construct {}. Invalid Parameters. {}",
                    GetType(), string.Join("\n", invalidReasons));
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
            public Builder SetMapReport(ISortieMapReport mapReport)
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
            public Builder SetRosterReport(IRosterModelReport rosterReport)
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
                    argumentExceptionSet.Add(typeof(ISortieMapReport).Name + " cannot be null.");
                }
                // Check that _orderReport has been set
                if (_orderReport == null)
                {
                    argumentExceptionSet.Add(typeof(IOrderReport).Name + " cannot be null.");
                }
                // Check that _rosterReport has been set
                if (_rosterReport == null)
                {
                    argumentExceptionSet.Add(typeof(IRosterModelReport).Name + " cannot be null.");
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