/*using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Mvcs.Simulations.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Mvcs.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Randoms.Managers;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Responses.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constrs.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Models.Responses.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Controls.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Controls.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Controls.Requests.Inters;
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
    /// Abstract Mvc Sortie Frame Implementation
    /// </summary>
    public abstract class AbstractMvcSortieFrame
        : IMvcSortieFrame
    {
        // Todo
        protected ISet<ISortieRequest> _ControlRequests = new HashSet<ISortieRequest>();

        // Todo
        protected IMvcSortieControl _mvcSortieControl;

        // Todo
        protected IMvcSortieModel _mvcSortieModel;

        // Todo
        protected IMvcSortieView _mvcSortieView;

        // Todo
        protected IMvcSortieFrameScript sortieFrameScript;

        // Todo
        private readonly IClassLogger _logger = LoggerManager.GetLogger(MvcType.Sortie, new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly IList<IMvcModelResponse> mvcModelResponses = new List<IMvcModelResponse>();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="sortieFrameConstruction"></param>
        public MvcSortieFrame(IMvcControlConstruction sortieFrameConstruction)
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
            _mvcSortieControl = new MvcSortieControl.Builder()
                .SetMvcSortieFrameConstruction(sortieFrameConstruction)
                .SetUnityScript(sortieFrameScript)
                .Build();
        }

        /// <inheritdoc/>
        void IMvcFrame.Continue()
        {
            if (_mvcSortieModel == null ||
                _mvcSortieControl == null)
            {
                return;
            }
            if (_mvcSortieModel.IsProcessing())
            {
                _logger.Info("Model is still processing");
                if (this.mvcSortieView == null || !_mvcSortieView.IsProcessing())
                {
                    _logger.Info("View is not processing");
                    if (!_mvcSortieControl.IsProcessing())
                    {
                        _logger.Info("Control is not processing");
                        if (_mvcSortieControl.GetControlRequests().Count == 0)
                        {
                            ISet<IMvcRequest> mvcControlRequests = _mvcSortieModel.GetMvcRequests();
                            if (mvcControlRequests.Count != 0)
                            {
                                ISet<ISortieRequest> sortieControlRequests = new HashSet<ISortieRequest>();
                                foreach (IMvcRequest mvcControlRequest in mvcControlRequests)
                                {
                                    sortieControlRequests.Add((ISortieRequest)mvcControlRequest);
                                }
                                _mvcSortieControl.Process(sortieControlRequests);
                            }
                            else
                            {
                                _logger.Error("No available {}s. END THE GAME.", typeof(ISortieRequest));
                            }
                        }
                        else
                        {
                            ISortieRequest selectedRequest = _mvcSortieControl.GetSelectedControlRequest();
                            if (selectedRequest != null)
                            {
                                _logger.Info("Selected {}", selectedRequest);
                                if (_mvcSortieView != null)
                                {
                                    _mvcSortieView.Process(selectedRequest);
                                }
                                ISortieRequest confirmedRequest = _mvcSortieControl.GetConfirmedControlRequest();
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
                                    _mvcSortieControl.Clear();
                                    //_ControlRequests.Clear();
                                    //_ControlRequests.UnionWith((ISet<ISortieRequest>)_mvcSortieModel.GetControlRequests());
                                    // _mvcSortieControl.Process(_ControlRequests);
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
                                _mvcSortieView.Process(_ControlRequests);
                            }
                        }
                    }
                    else
                    {
                        _logger.Info("Control is still processing");
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
                !_mvcSortieControl.IsProcessing() &&
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