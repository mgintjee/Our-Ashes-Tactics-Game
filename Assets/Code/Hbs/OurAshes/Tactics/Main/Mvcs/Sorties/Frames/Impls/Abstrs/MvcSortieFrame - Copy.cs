/*using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Mvcs.Simulations.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Mvcs.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Randoms.Managers;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Responses.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Requests.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constrs.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Models.Responses.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Controllers.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Controllers.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Controllers.Requests.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Frames.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Frames.Scripts.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Frames.Scripts.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Inters;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Frames.Impls.Abstrs
{
    /// <summary>
    /// Mvc Sortie Frame Implementation
    /// </summary>
    public class MvcSortieFrame
        : IMvcSortieFrame
    {
        // Todo
        private readonly IClassLogger _logger = LoggerManager.GetLogger(MvcType.Sortie, new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly ISet<ISortieRequest> _controllerRequests = new HashSet<ISortieRequest>();

        // Todo
        private readonly IMvcSortieController _mvcSortieController;

        // Todo
        private readonly IMvcSortieModel _mvcSortieModel;

        // Todo
        private readonly IMvcSortieView _mvcSortieView;

        // Todo
        private readonly IMvcSortieFrameScript sortieFrameScript;

        // Todo
        private readonly IList<IMvcModelResponse> mvcModelResponses = new List<IMvcModelResponse>();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="sortieFrameConstruction"></param>
        public MvcSortieFrame(IMvcControllerConstruction sortieFrameConstruction)
        {
            _logger.Info("Constructing {} with {}", this.GetType(), sortieFrameConstruction);
            RandomManager.GetRandom(MvcType.Sortie);
            this.sortieFrameScript = new MvcSortieFrameScript.Builder()
                .SetUnityScript(sortieFrameConstruction.GetUnityScript())
                .Build();
            _mvcSortieModel = new MvcSortieModel(sortieFrameConstruction);
            if (sortieFrameConstruction.GetSimulationType() != SimulationType.BlackBox)
            {
                _mvcSortieView = new MvcSortieView.Builder()
                    .SetMvcSortieFrameConstruction(sortieFrameConstruction)
                    .SetUnityScript(sortieFrameScript)
                    .Build();
            }
            _mvcSortieController = new MvcSortieController.Builder()
                .SetMvcSortieFrameConstruction(sortieFrameConstruction)
                .SetUnityScript(sortieFrameScript)
                .Build();
        }

        /// <inheritdoc/>
        void IMvcFrame.Continue()
        {
            if (_mvcSortieModel == null ||
                _mvcSortieController == null)
            {
                return;
            }
            if (_mvcSortieModel.IsProcessing())
            {
                _logger.Info("Model is still processing");
                if (this.mvcSortieView == null || !_mvcSortieView.IsProcessing())
                {
                    _logger.Info("View is not processing");
                    if (!_mvcSortieController.IsProcessing())
                    {
                        _logger.Info("Controller is not processing");
                        if (_mvcSortieController.GetControllerRequests().Count == 0)
                        {
                            ISet<IMvcRequest> mvcControllerRequests = _mvcSortieModel.GetMvcRequests();
                            if (mvcControllerRequests.Count != 0)
                            {
                                ISet<ISortieRequest> sortieControllerRequests = new HashSet<ISortieRequest>();
                                foreach (IMvcRequest mvcControllerRequest in mvcControllerRequests)
                                {
                                    sortieControllerRequests.Add((ISortieRequest)mvcControllerRequest);
                                }
                                _mvcSortieController.Process(sortieControllerRequests);
                            }
                            else
                            {
                                _logger.Error("No available {}s. END THE GAME.", typeof(ISortieRequest));
                            }
                        }
                        else
                        {
                            ISortieRequest selectedRequest = _mvcSortieController.GetSelectedControllerRequest();
                            if (selectedRequest != null)
                            {
                                _logger.Info("Selected {}", selectedRequest);
                                if (_mvcSortieView != null)
                                {
                                    _mvcSortieView.Process(selectedRequest);
                                }
                                ISortieRequest confirmedRequest = _mvcSortieController.GetConfirmedControllerRequest();
                                if (confirmedRequest != null)
                                {
                                    _logger.Info("Confirmed {}", confirmedRequest);
                                    _mvcSortieModel.Process(confirmedRequest);
                                    IMvcModelResponse mvcResponse = _mvcSortieModel.GetMvcModelResponse();
                                    mvcModelResponses.Add(mvcResponse);
                                    if (_mvcSortieView != null)
                                    {
                                        _mvcSortieView.Process((IMvcResponse)mvcResponse);
                                    }
                                    _mvcSortieController.Clear();
                                    //_controllerRequests.Clear();
                                    //_controllerRequests.UnionWith((ISet<ISortieRequest>)_mvcSortieModel.GetControllerRequests());
                                    // _mvcSortieController.Process(_controllerRequests);
                                    //_logger.Info(":{}", ((ISortieModelResponse)_mvcSortieModel.GetMvcModelResponse()).GetSortieResponseID());
                                    _logger.Info(":{}", _mvcSortieModel.GetMvcModelResponse());
                                }
                                else
                                {
                                    _logger.Debug("Waiting for confirmed request");
                                }
                            }
                            else
                            {
                                _logger.Debug("Waiting for selected request");
                                _mvcSortieView.Process(_controllerRequests);
                            }
                        }
                    }
                    else
                    {
                        _logger.Info("Controller is still processing");
                    }
                }
                else
                {
                    _logger.Info("View is still processing");
                }
            }
            else
            {
                _logger.Info("Model is not processing");
            }
        }

        /// <inheritdoc/>
        bool IMvcFrame.IsComplete()
        {
            return (_mvcSortieView == null || !_mvcSortieView.IsProcessing()) &&
                !_mvcSortieController.IsProcessing() &&
                !_mvcSortieModel.IsProcessing();
        }

        /// <inheritdoc/>
        void IMvcFrame.Destroy()
        {
            _logger.Info("Destroying this Mvc");
            this.sortieFrameScript.Destroy();
            LoggerManager.EndLoggingFile(MvcType.Sortie);
        }
    }
}*/