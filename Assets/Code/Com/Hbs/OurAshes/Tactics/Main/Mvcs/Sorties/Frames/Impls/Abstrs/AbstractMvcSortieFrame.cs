/*using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Mvcs.Simulations.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Mvcs.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Randoms.Managers;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Responses.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constrs.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Models.Responses.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Controls.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Controls.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Requests.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Frames.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Frames.Scripts.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Frames.Scripts.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Inters;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Frames.Impls.Abstrs
{
    /// <summary>
    /// Abstract Mvc Sortie Frame Impl
    /// </summary>
    public abstract class AbstractMvcSortieFrame
        : IMvcSortieFrame
    {
        // Todo
        protected ISet<ISortieRequest> _ModelRequests = new HashSet<ISortieRequest>();

        // Todo
        protected IMvcSortieControl _mvcSortieControl;

        // Todo
        protected IMvcSortieModel _mvcSortieModel;

        // Todo
        protected IMvcSortieView _mvcSortieView;

        // Todo
        protected IMvcSortieFrameScript sortieFrameScript;

        // Todo
        private readonly IClassLogger logger = LoggerManager.GetLogger(MvcType.Sortie, new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly IList<IMvcModelResponse> mvcModelResponses = new List<IMvcModelResponse>();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="sortieFrameConstruction"></param>
        public MvcSortieFrame(IMvcControlConstruction sortieFrameConstruction)
        {
            logger.Info("Constructing {} with {}", this.GetType(), sortieFrameConstruction);
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
                logger.Info("Model is still processing");
                if (this.mvcSortieView == null || !_mvcSortieView.IsProcessing())
                {
                    logger.Info("View is not processing");
                    if (!_mvcSortieControl.IsProcessing())
                    {
                        logger.Info("Control is not processing");
                        if (_mvcSortieControl.GetModelRequests().Count == 0)
                        {
                            ISet<IMvcRequest> mvcModelRequests = _mvcSortieModel.GetMvcRequests();
                            if (mvcModelRequests.Count != 0)
                            {
                                ISet<ISortieRequest> sortieModelRequests = new HashSet<ISortieRequest>();
                                foreach (IMvcRequest mvcModelRequest in mvcModelRequests)
                                {
                                    sortieModelRequests.Add((ISortieRequest)mvcModelRequest);
                                }
                                _mvcSortieControl.Process(sortieModelRequests);
                            }
                            else
                            {
                                logger.Error("No available {}s. END THE GAME.", typeof(ISortieRequest));
                            }
                        }
                        else
                        {
                            ISortieRequest selectedRequest = _mvcSortieControl.GetSelectedModelRequest();
                            if (selectedRequest != null)
                            {
                                logger.Info("Selected {}", selectedRequest);
                                if (_mvcSortieView != null)
                                {
                                    _mvcSortieView.Process(selectedRequest);
                                }
                                ISortieRequest confirmedRequest = _mvcSortieControl.GetConfirmedModelRequest();
                                if (confirmedRequest != null)
                                {
                                    logger.Info("Confirmed {}", confirmedRequest);
                                    _mvcSortieModel.Process(confirmedRequest);
                                    IMvcModelResponse mvcResponse = _mvcSortieModel.GetMvcModelResponse();
                                    mvcModelResponses.Add(mvcResponse);
                                    if (_mvcSortieView != null)
                                    {
                                        _mvcSortieView.Process((IMvcResponse)mvcResponse);
                                    }
                                    _mvcSortieControl.Clear();
                                    //_ModelRequests.Clear();
                                    //_ModelRequests.UnionWith((ISet<ISortieRequest>)_mvcSortieModel.GetModelRequests());
                                    // _mvcSortieControl.Process(_ModelRequests);
                                    //logger.Info(":{}", ((ISortieModelResponse)_mvcSortieModel.GetMvcModelResponse()).GetSortieResponseID());
                                    logger.Info(":{}", _mvcSortieModel.GetMvcModelResponse());
                                }
                                else
                                {
                                    logger.Debug("Waiting for confirmed request");
                                }
                            }
                            else
                            {
                                logger.Debug("Waiting for selected request");
                                _mvcSortieView.Process(_ModelRequests);
                            }
                        }
                    }
                    else
                    {
                        logger.Info("Control is still processing");
                    }
                }
                else
                {
                    logger.Info("View is still processing");
                }
            }
            else
            {
                logger.Info("Model is not processing");
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
            logger.Info("Destroying this Mvc");
            this.sortieFrameScript.Destroy();
            LoggerManager.EndLoggingFile(MvcType.Sortie);
        }
    }
}*/