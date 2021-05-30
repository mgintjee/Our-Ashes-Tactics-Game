using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Requests.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Models.Responses.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Combats.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Formations.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Models.Responses.IDs.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Models.Responses.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Models.Rosters.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Orders.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Scores.Reports.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Models.Responses.Implementations
{
    /// <summary>
    /// Sortie Model Response Implementation
    /// </summary>
    public struct SortieModelResponse
        : ISortieModelResponse
    {
        // Todo
        private readonly IRosterReport _rosterReport;

        // Todo
        private readonly ICombatReport _combatReport;

        // Todo
        private readonly IMapReport _mapReport;

        // Todo
        private readonly IMvcControllerRequest _mvcControllerRequest;

        // Todo
        private readonly ISet<IMvcControllerRequest> _mvcControllerRequests;

        // Todo
        private readonly IOrderReport _orderReport;

        // Todo
        private readonly IFormationReport _formationReport;

        // Todo
        private readonly IScoreReport _scoreReport;

        // Todo
        private readonly ISortieResponseID _sortieResponseID;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="rosterReport">         </param>
        /// <param name="combatReport">         </param>
        /// <param name="mvcControllerRequest"> </param>
        /// <param name="mvcControllerRequests"></param>
        /// <param name="mapReport">            </param>
        /// <param name="orderReport">          </param>
        /// <param name="sortieResponseID">     </param>
        /// <param name="scoreReport">          </param>
        /// <param name="formationReport">      </param>
        private SortieModelResponse(IRosterReport rosterReport,
            ICombatReport combatReport, IMvcControllerRequest mvcControllerRequest,
            ISet<IMvcControllerRequest> mvcControllerRequests, IMapReport mapReport,
            IOrderReport orderReport, ISortieResponseID sortieResponseID,
            IScoreReport scoreReport, IFormationReport formationReport)
        {
            _rosterReport = rosterReport;
            _combatReport = combatReport;
            _mvcControllerRequest = mvcControllerRequest;
            _mvcControllerRequests = mvcControllerRequests;
            _mapReport = mapReport;
            _orderReport = orderReport;
            _sortieResponseID = sortieResponseID;
            _scoreReport = scoreReport;
            _formationReport = formationReport;
        }

        /// <inheritdoc/>
        IRosterReport ISortieModelResponse.GetRosterReport()
        {
            return _rosterReport;
        }

        /// <inheritdoc/>
        ICombatReport ISortieModelResponse.GetCombatReport()
        {
            return _combatReport;
        }

        /// <inheritdoc/>
        ISet<IMvcControllerRequest> IMvcModelResponse.GetControllerRequests()
        {
            return new HashSet<IMvcControllerRequest>(_mvcControllerRequests);
        }

        /// <inheritdoc/>
        IMapReport ISortieModelResponse.GetMapReport()
        {
            return _mapReport;
        }

        /// <inheritdoc/>
        Optional<IMvcControllerRequest> IMvcModelResponse.GetMvcControllerRequest()
        {
            return Optional<IMvcControllerRequest>.Of(_mvcControllerRequest);
        }

        /// <inheritdoc/>
        IOrderReport ISortieModelResponse.GetOrderReport()
        {
            return _orderReport;
        }

        /// <inheritdoc/>
        IFormationReport ISortieModelResponse.GetFormationReport()
        {
            return _formationReport;
        }

        /// <inheritdoc/>
        IScoreReport ISortieModelResponse.GetScoreReport()
        {
            return _scoreReport;
        }

        /// <inheritdoc/>
        ISortieResponseID ISortieModelResponse.SortieResponseID()
        {
            return _sortieResponseID;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private IRosterReport _rosterReport = null;

            // Todo
            private ICombatReport _combatReport = null;

            // Todo
            private IMapReport _mapReport = null;

            // Todo
            private IMvcControllerRequest _mvcControllerRequest = null;

            // Todo
            private ISet<IMvcControllerRequest> _mvcControllerRequests = null;

            // Todo
            private IOrderReport _orderReport = null;

            // Todo
            private IFormationReport _formationReport = null;

            // Todo
            private IScoreReport _scoreReport = null;

            // Todo
            private ISortieResponseID _sortieResponseID = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public ISortieModelResponse Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new response
                    return new SortieModelResponse(_rosterReport, _combatReport,
                        _mvcControllerRequest, _mvcControllerRequests, _mapReport,
                        _orderReport, _sortieResponseID, _scoreReport, _formationReport);
                }
                throw ExceptionUtil.Arguments.Build("Unable to construct {}. Invalid Parameters. {}",
                    this.GetType(), string.Join("\n", invalidReasons));
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
            /// <param name="mvcControllerRequest"></param>
            /// <returns></returns>
            public Builder SetMvcControllerRequest(IMvcControllerRequest mvcControllerRequest)
            {
                _mvcControllerRequest = mvcControllerRequest;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="mvcControllerRequests"></param>
            /// <returns></returns>
            public Builder SetMvcControllerRequests(ISet<IMvcControllerRequest> mvcControllerRequests)
            {
                if (mvcControllerRequests != null)
                {
                    _mvcControllerRequests = new HashSet<IMvcControllerRequest>(mvcControllerRequests);
                }
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
            /// <param name="sortieResponseID"></param>
            /// <returns></returns>
            public Builder SetSortieResponseID(ISortieResponseID sortieResponseID)
            {
                _sortieResponseID = sortieResponseID;
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
            /// <param name="formationReport"></param>
            /// <returns></returns>
            public Builder SetFormationReport(IFormationReport formationReport)
            {
                _formationReport = formationReport;
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
                // Todo: Add the non-null checks
                return argumentExceptionSet;
            }
        }
    }
}