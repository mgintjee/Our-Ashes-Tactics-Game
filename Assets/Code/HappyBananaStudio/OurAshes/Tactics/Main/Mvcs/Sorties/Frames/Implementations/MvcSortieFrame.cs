using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Randoms.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Simulations.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Requests.Interfaces;
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
        private static readonly ILogger _sortieLogger = LoggerManager.GetSortieLogger(new StackFrame().GetMethod().DeclaringType);

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
            _sortieLogger.Info("Constructing {} with {}", this.GetType(), sortieFrameConstruction);
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
            _sortieLogger.Info("Continue");
            _sortieLogger.Info(":{}", !_mvcSortieModel.IsProcessing());
            if (!_mvcSortieModel.IsProcessing())
            {
                ISet<IMvcControllerRequest> mvcControllerRequests = _mvcSortieModel.GetControllerRequests();
                _sortieLogger.Info(":{}", string.Join(", ", mvcControllerRequests));
                if (mvcControllerRequests.Count != 0)
                {
                    ISet<ISortieControllerRequest> sortieControllerRequests = new HashSet<ISortieControllerRequest>();
                    foreach (IMvcControllerRequest mvcControllerRequest in mvcControllerRequests)
                    {
                        sortieControllerRequests.Add((ISortieControllerRequest)mvcControllerRequest);
                    }
                    _mvcSortieController.Process(sortieControllerRequests);
                }
            }
            else
            {
                if (this._mvcSortieView == null || !_mvcSortieView.IsProcessing())
                {
                    if (!_mvcSortieController.IsProcessing())
                    {
                        ISortieControllerRequest selectedRequest = _mvcSortieController.GetSelectedControllerRequest();
                        if (selectedRequest != null)
                        {
                            _mvcSortieView.Process(selectedRequest);
                            ISortieControllerRequest confirmedRequest = _mvcSortieController.GetConfirmedControllerRequest();
                            if (confirmedRequest != null)
                            {
                                _mvcSortieModel.Process(confirmedRequest);
                                IMvcModelResponse modelResponse = _mvcSortieModel.GetMvcModelResponse();
                                mvcModelResponses.Add(modelResponse);
                                _mvcSortieView.Process((ISortieModelResponse)modelResponse);
                                _controllerRequests.Clear();
                                _controllerRequests.UnionWith((ISet<ISortieControllerRequest>)_mvcSortieModel.GetControllerRequests());
                                _mvcSortieController.Process(_controllerRequests);
                            }
                            else
                            {
                                _sortieLogger.Debug("Waiting for confirmed request");
                            }
                        }
                        else
                        {
                            _sortieLogger.Debug("Waiting for selected request");
                            _mvcSortieView.Process(_controllerRequests);
                        }
                    }
                    else
                    {
                        _sortieLogger.Debug("Waiting for {} to finish processing.", typeof(IMvcSortieController));
                    }
                }
                else
                {
                    _sortieLogger.Debug("Waiting for {} to finish processing.", typeof(IMvcSortieView));
                }
            }
        }

        /// <inheritdoc/>
        bool IMvcFrame.IsComplete()
        {
            return !_mvcSortieView.IsProcessing() &&
                !_mvcSortieController.IsProcessing() &&
                !_mvcSortieModel.IsProcessing();
        }
    }
}