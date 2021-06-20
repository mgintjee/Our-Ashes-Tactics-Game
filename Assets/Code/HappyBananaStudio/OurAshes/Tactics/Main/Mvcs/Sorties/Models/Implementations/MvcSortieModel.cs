using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Requests.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Models.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Models.Responses.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Combatants.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Implementaions.Fires;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Models.Reports.Implementaions;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Models.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Models.Responses.IDs.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Models.Responses.IDs.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Models.Responses.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Orders.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Rosters.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Controllers.Requests.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Controllers.Requests.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Combats.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Combats.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Engagements.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Engagements.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Maps.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Maps.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Orders.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Orders.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Rosters.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Rosters.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Scores.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Scores.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Implementations
{
    /// <summary>
    /// Mvc Sortie Model Implementation
    /// </summary>
    public class MvcSortieModel
        : IMvcSortieModel
    {
        // Provides logging capability to the SORTIE logs
        private static readonly ILogger _logger = LoggerManager.GetSortieLogger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly ICombatModel _combatModel;

        // Todo
        private readonly IEngagementModel _engagementModel;

        // Todo
        private readonly IMapModel _mapModel;

        // Todo
        private readonly IOrderModel _orderModel;

        // Todo
        private readonly IRosterModel _rosterModel;

        // Todo
        private readonly IScoreModel _scoreModel;

        // Todo
        private CombatantCallSign _previousCallSign = CombatantCallSign.None;

        // Todo
        private ISortieResponseID _sortieResponseID;

        // Todo
        private IMvcModelResponse _mvcModelResponse;

        // Todo
        private IMvcSortieModelReport _report;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="sortieFrameConstruction"></param>
        public MvcSortieModel(IMvcSortieFrameConstruction sortieFrameConstruction)
        {
            _logger.Info("Instantiating");
            _sortieResponseID = new SortieResponseID(0, 0, 0);
            _rosterModel = new RosterModel(sortieFrameConstruction.GetRosterConstruction());
            _engagementModel = new EngagementModel(sortieFrameConstruction.GetFormationConstruction());
            _mapModel = new MapModel(sortieFrameConstruction.GetMapConstruction());
            _scoreModel = new ScoreModel(sortieFrameConstruction.GetScoreConstruction());
            _orderModel = new OrderModel();
            _combatModel = new CombatModel();
            _logger.Info(" {} ", _rosterModel.GetReport());
            _orderModel.Process(_rosterModel.GetReport());
            _logger.Info(" {} ", _orderModel.GetReport());
            this.RefreshModels(null);
            this.BuildMvcModelResponse(null);
        }

        /// <inheritdoc/>
        ISet<IMvcControllerRequest> IMvcModel.GetControllerRequests()
        {
            ISet<IMvcControllerRequest> mvcControllerRequests = new HashSet<IMvcControllerRequest>();
            IOrderReport orderReport = _orderModel.GetReport();
            _logger.Info(":{}", orderReport);
            if (orderReport.GetCurrentCallSigns().Count > 0)
            {
                CombatantCallSign callSign = orderReport.GetCurrentCallSigns()[0];
                _logger.Info("Acting {} ", callSign);
                IRosterReport rosterReport = _rosterModel.GetReport();
                _logger.Info(" {} ", rosterReport);
                ICombatantReport combatantReport = rosterReport.GetCombatantReport(callSign).GetValue();
                _logger.Info(" {} ", combatantReport);
                ISet<IPath> paths = _mapModel.GetPaths(combatantReport);
                IMapReport mapReport = _mapModel.GetReport();
                foreach (IPath path in paths)
                {
                    if (path is FirePath)
                    {
                        Optional<ITileReport> tileReport = mapReport.GetTileReport(path.GetEnd());
                        if (tileReport.IsPresent())
                        {
                            CombatantCallSign targetCallSign = tileReport.GetValue().GetCombatantCallSign();
                            if (_engagementModel.AreFriendly(callSign, targetCallSign))
                            {
                                continue;
                            }
                        }
                    }
                    mvcControllerRequests.Add(new SortieControllerRequest.Builder()
                        .SetCombatantCallSign(callSign)
                        .SetPath(path)
                        .Build());
                }
                return mvcControllerRequests;
            }
            else
            {
                _logger.Warn("Current {} is empty.", typeof(CombatantCallSign));
                return new HashSet<IMvcControllerRequest>();
            }
        }

        /// <inheritdoc/>
        bool IMvcSortieModel.IsProcessing()
        {
            return !_scoreModel.GetReport().IsScoreReached();
        }

        /// <inheritdoc/>
        void IMvcModel.Process(IMvcControllerRequest mvcControllerRequest)
        {
            _logger.Info("Processing {}", mvcControllerRequest);
            this.RefreshModels((ISortieControllerRequest)mvcControllerRequest);
            this.IncrementSortieResponseID((ISortieControllerRequest)mvcControllerRequest);
            this.BuildMvcModelResponse(mvcControllerRequest);
        }

        /// <inheritdoc/>
        IMvcModelResponse IMvcModel.GetMvcModelResponse()
        {
            return _mvcModelResponse;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="sortieControllerRequest"></param>
        private void IncrementSortieResponseID(ISortieControllerRequest sortieControllerRequest)
        {
            CombatantCallSign currentCallSign = sortieControllerRequest.GetCallSign();
            _logger.Info("IncrementSortieResponseId: Prev={}, Curr={}", _previousCallSign, currentCallSign);
            _logger.Info(" {}", _rosterModel.GetReport());
            _logger.Info(" {}", _orderModel.GetReport());
            if (_orderModel.GetReport().GetUpcomingCallSigns().Count == 0 &&
                _rosterModel.GetReport().GetCombatantReport(currentCallSign).GetValue().GetCurrentAttributes().GetMovableAttributes().GetActions() <= 0)
            {
                _rosterModel.ResetForNewPhase();
                _orderModel.Process(_rosterModel.GetReport());
                _logger.Info("Increment Phase");
                _sortieResponseID = _sortieResponseID.IncrementPhase();
            }
            else if (_previousCallSign != currentCallSign)
            {
                _logger.Info("Increment Turn since {} != {}", _previousCallSign, currentCallSign);
                _previousCallSign = currentCallSign;
                _sortieResponseID = _sortieResponseID.IncrementTurn();
            }
            else
            {
                _logger.Info("Increment Action");
                _sortieResponseID = _sortieResponseID.IncrementAction();
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void BuildMvcModelResponse(IMvcControllerRequest mvcControllerRequest)
        {
            _mvcModelResponse = new SortieModelResponse.Builder()
                .SetSortieResponseID(_sortieResponseID)
                .SetMvcControllerRequest(mvcControllerRequest)
                .SetMvcControllerRequests(((IMvcSortieModel)this).GetControllerRequests())
                .SetMvcSortieModelReport(_report)
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="sortieControllerRequest"></param>
        private void RefreshModels(ISortieControllerRequest sortieControllerRequest)
        {
            _combatModel.Process(sortieControllerRequest, _rosterModel.GetReport(), _mapModel.GetReport());
            _rosterModel.Process(sortieControllerRequest, _combatModel.GetReport());
            _orderModel.Process(_rosterModel.GetReport());
            _engagementModel.Process(_rosterModel.GetReport());
            _mapModel.Process(sortieControllerRequest, _rosterModel.GetReport());
            _scoreModel.Process(sortieControllerRequest);

            _report = new MvcSortieModelReport.Builder()
                .SetCombatReport(_combatModel.GetReport())
                .SetEngagementReport(_engagementModel.GetReport())
                .SetMapReport(_mapModel.GetReport())
                .SetOrderReport(_orderModel.GetReport())
                .SetRosterReport(_rosterModel.GetReport())
                .SetScoreReport(_scoreModel.GetReport())
                .Build();
        }
    }
}