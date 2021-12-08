/*using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Combatants.CallSigns;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Mvcs.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Requests.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Responses.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Combatants.Reports.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constrs.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Implementaions.Fires;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Reports.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Reports.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Models.Reports.Implementaions;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Models.Reports.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Models.Responses.IDs.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Models.Responses.IDs.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Models.Responses.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Orders.Reports.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Rosters.Reports.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Controls.Requests.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Controls.Requests.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Combats.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Combats.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Engagements.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Engagements.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Maps.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Maps.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Orders.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Orders.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Rosters.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Rosters.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Scores.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Scores.Inters;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Impls
{
    /// <summary>
    /// Mvc Sortie Model Implementation
    /// </summary>
    public class MvcSortieModel
        : IMvcSortieModel
    {
        // Provides logging capability to the SORTIE logs
        private readonly IClassLogger _logger = LoggerManager.GetLogger(MvcType.Sortie, new StackFrame().GetMethod().DeclaringType);

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
        private IMvcResponseID _sortieResponseID;

        // Todo
        private IMvcModelResponse _mvcModelResponse;

        // Todo
        private IMvcSortieModelReport _report;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="sortieFrameConstruction"></param>
        public MvcSortieModel(IMvcControlConstruction sortieFrameConstruction)
        {
            _logger.Info("Instantiating");
            _sortieResponseID = new SortieResponseID(0, 0, 0);
            _rosterModel = new RosterModel(sortieFrameConstruction.GetRosterConstruction());
            _engagementModel = new EngagementModel(sortieFrameConstruction.GetFormationConstruction());
            _mapModel = new MapModel(sortieFrameConstruction.GetMapConstruction());
            _scoreModel = new ScoreModel(sortieFrameConstruction.GetScoreConstruction());
            _orderModel = new OrderModel();
            _combatModel = new CombatModel();
            _orderModel.Process(_rosterModel.GetReport());
            this.RefreshModels(null);
            this.BuildMvcModelResponse(null);
        }

        /// <inheritdoc/>
        ISet<IMvcRequest> IMvcModel.GetMvcRequests()
        {
            ISet<IMvcRequest> mvcControlRequests = new HashSet<IMvcRequest>();
            IOrderReport orderReport = _orderModel.GetReport();
            if (orderReport.GetCurrentCallSigns().Count > 0)
            {
                CombatantCallSign callSign = orderReport.GetCurrentCallSigns()[0];
                IRosterModelReport rosterReport = _rosterModel.GetReport();
                ICombatantReport combatantReport = rosterReport.GetCombatantReport(callSign).GetValue();
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
                    mvcControlRequests.Add(new SortieControlRequest.Builder()
                        .SetCombatantCallSign(callSign)
                        .SetPath(path)
                        .Build());
                }
                return mvcControlRequests;
            }
            else
            {
                _logger.Warn("Current {} is empty. Game should end.", typeof(CombatantCallSign));
                return new HashSet<IMvcRequest>();
            }
        }

        /// <inheritdoc/>
        bool IMvcSortieModel.IsProcessing()
        {
            return !_scoreModel.GetReport().IsScoreReached();
        }

        /// <inheritdoc/>
        void IMvcModel.Process(IMvcRequest mvcControlRequest)
        {
            _logger.Info("Processing {}", mvcControlRequest);
            this.RefreshModels((ISortieRequest)mvcControlRequest);
            this.IncrementSortieResponseID((ISortieRequest)mvcControlRequest);
            this.BuildMvcModelResponse(mvcControlRequest);
        }

        /// <inheritdoc/>
        IMvcModelResponse IMvcModel.GetMvcModelResponse()
        {
            return _mvcModelResponse;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="sortieControlRequest"></param>
        private void IncrementSortieResponseID(ISortieRequest sortieControlRequest)
        {
            CombatantCallSign currentCallSign = sortieControlRequest.GetCallSign();
            if (_orderModel.GetReport().GetUpcomingCallSigns().Count == 0 &&
                _rosterModel.GetReport().GetCombatantReport(currentCallSign).GetValue().GetCurrentAttributes().GetMovableAttributes().GetActions() <= 0)
            {
                _rosterModel.ResetForNewPhase();
                _orderModel.Process(_rosterModel.GetReport());
                _sortieResponseID = _sortieResponseID.IncrementPhase();
            }
            else if (_previousCallSign != currentCallSign)
            {
                _previousCallSign = currentCallSign;
                _sortieResponseID = _sortieResponseID.IncrementTurn();
            }
            else
            {
                _sortieResponseID = _sortieResponseID.IncrementAction();
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void BuildMvcModelResponse(IMvcRequest mvcControlRequest)
        {
            _mvcModelResponse = new SortieModelResponse.Builder()
                .SetSortieResponseID(_sortieResponseID)
                .SetMvcControlRequest(mvcControlRequest)
                .SetMvcControlRequests(((IMvcSortieModel)this).GetMvcRequests())
                .SetMvcSortieModelReport(_report)
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="sortieControlRequest"></param>
        private void RefreshModels(ISortieRequest sortieControlRequest)
        {
            _combatModel.Process(sortieControlRequest, _rosterModel.GetReport(), _mapModel.GetReport());
            _rosterModel.Process(sortieControlRequest, _combatModel.GetReport());
            _orderModel.Process(_rosterModel.GetReport());
            _engagementModel.Process(_rosterModel.GetReport());
            _mapModel.Process(sortieControlRequest, _rosterModel.GetReport());
            _scoreModel.Process(sortieControlRequest, _mapModel.GetReport(), _rosterModel.GetReport(), _engagementModel.GetReport());

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
}*/