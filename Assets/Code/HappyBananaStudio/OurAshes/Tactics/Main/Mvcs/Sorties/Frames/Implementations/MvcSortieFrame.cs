using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Mvcs.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Randoms.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Requests.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Simulations.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Models.Responses.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Models.Responses.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Controllers.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Controllers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Controllers.Requests.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Frames.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Frames.Scripts.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Frames.Scripts.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Frames.Implementations
{
    /// <summary>
    /// Mvc Sortie Frame Implementation
    /// </summary>
    public class MvcSortieFrame
        : IMvcSortieFrame
    {
        // Todo
        private readonly ILogger _logger = LoggerManager.GetLogger(MvcType.Sortie, new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly ISet<ISortieControllerRequest> _controllerRequests = new HashSet<ISortieControllerRequest>();

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
        public MvcSortieFrame(IMvcSortieFrameConstruction sortieFrameConstruction)
        {
            _logger.Info("Constructing {} with {}", this.GetType(), sortieFrameConstruction);
            RandomManager.GetSortieRandom();
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
                if (this._mvcSortieView == null || !_mvcSortieView.IsProcessing())
                {
                    _logger.Info("View is not processing");
                    if (!_mvcSortieController.IsProcessing())
                    {
                        _logger.Info("Controller is not processing");
                        if (_mvcSortieController.GetControllerRequests().Count == 0)
                        {
                            ISet<IRequest> mvcControllerRequests = _mvcSortieModel.GetControllerRequests();
                            if (mvcControllerRequests.Count != 0)
                            {
                                ISet<ISortieControllerRequest> sortieControllerRequests = new HashSet<ISortieControllerRequest>();
                                foreach (IRequest mvcControllerRequest in mvcControllerRequests)
                                {
                                    sortieControllerRequests.Add((ISortieControllerRequest)mvcControllerRequest);
                                }
                                _mvcSortieController.Process(sortieControllerRequests);
                            }
                            else
                            {
                                _logger.Error("No available {}s. END THE GAME.", typeof(ISortieControllerRequest));
                            }
                        }
                        else
                        {
                            ISortieControllerRequest selectedRequest = _mvcSortieController.GetSelectedControllerRequest();
                            if (selectedRequest != null)
                            {
                                _logger.Info("Selected {}", selectedRequest);
                                if (_mvcSortieView != null)
                                {
                                    _mvcSortieView.Process(selectedRequest);
                                }
                                ISortieControllerRequest confirmedRequest = _mvcSortieController.GetConfirmedControllerRequest();
                                if (confirmedRequest != null)
                                {
                                    _logger.Info("Confirmed {}", confirmedRequest);
                                    _mvcSortieModel.Process(confirmedRequest);
                                    IMvcModelResponse modelResponse = _mvcSortieModel.GetMvcModelResponse();
                                    mvcModelResponses.Add(modelResponse);
                                    if (_mvcSortieView != null)
                                    {
                                        _mvcSortieView.Process((ISortieModelResponse)modelResponse);
                                    }
                                    _mvcSortieController.Clear();
                                    //_controllerRequests.Clear();
                                    //_controllerRequests.UnionWith((ISet<ISortieControllerRequest>)_mvcSortieModel.GetControllerRequests());
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
}