using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Mvcs.Simulations.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Mvcs.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Randoms.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constructions.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Responses.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Scripts.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Scripts.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Models.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Requests.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Implementations.BlackBoxes;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Implementations.Abstracts
{
    /// <summary>
    /// Abstact Mvc Frame Interface
    /// </summary>
    public abstract class AbstractMvcFrame
        : IMvcFrame
    {
        // Todo
        protected readonly IMvcFrameScript _mvcFrameScript;

        // Todo
        protected readonly IMvcModel _mvcModel;

        // Todo
        protected readonly IMvcView _mvcView;

        // Todo
        protected readonly IMvcController _mvcController;

        // Todo
        protected readonly ILogger _logger;

        // Todo
        private readonly IList<IMvcResponse> _mvcResponses = new List<IMvcResponse>();

        // Todo
        private readonly MvcType _mvcType;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public AbstractMvcFrame(IMvcFrameConstruction mvcFrameConstruction)
        {
            _mvcType = mvcFrameConstruction.GetMvcType();
            _logger = LoggerManager.GetLogger(_mvcType, this.GetType());
            _mvcFrameScript = new MvcFrameScriptImplementation.Builder()
                .SetMvcFrameConstruction(mvcFrameConstruction)
                .Build();
            IMvcFrameConstruction newMvcFrameConstruction = new MvcFrameConstruction.Builder()
                // Copy over the orginal values
                .SetMvcControllerConstruction(mvcFrameConstruction.GetMvcControllerConstruction())
                .SetMvcModelConstruction(mvcFrameConstruction.GetMvcModelConstruction())
                .SetMvcViewConstruction(mvcFrameConstruction.GetMvcViewConstruction())
                .SetSimulationType(mvcFrameConstruction.GetSimulationType())
                .SetMvcType(mvcFrameConstruction.GetMvcType())
                // Set the new values
                .SetRandom(RandomManager.GetRandom(_mvcType, mvcFrameConstruction.GetRandom().Next()))
                .SetUnityScript(_mvcFrameScript)
                .Build();
            _mvcModel = this.BuildMvcModel(newMvcFrameConstruction);
            _mvcController = this.BuildMvcController(newMvcFrameConstruction);
            _mvcView = (mvcFrameConstruction.GetSimulationType() != SimulationType.BlackBox)
                ? this.BuildMvcView(newMvcFrameConstruction) : new BlackBoxMvcView(newMvcFrameConstruction);
        }

        /// <inheritdoc/>
        void IMvcFrame.Continue()
        {
            // Check if this MvcFrame should still continue
            if (!((IMvcFrame)this).IsComplete())
            {
                // Check if the MvcView is either null or no longer processing
                if (!_mvcView.IsProcessing())
                {
                    // Check if the MvcController is no longer processing
                    if (!_mvcController.IsProcessing())
                    {
                        // Check if the MvcController has any requests
                        if (!_mvcController.HasRequests())
                        {
                            // Pass in the Model's available MvcRequests
                            _mvcController.Process(_mvcModel.GetMvcRequests());
                        }
                        else
                        {
                            _logger.Debug("{} is still processing.", _mvcController.GetType());
                        }
                    }
                    else
                    {
                        // Collect the selected MvcRequest
                        IMvcRequest selectedMvcRequest = _mvcController.OutputSelectedMvcRequest();
                        // Check that the selected MvcRequest is non-null
                        if (selectedMvcRequest != null)
                        {
                            _logger.Info("Selected {}.", selectedMvcRequest);
                            _mvcView.Process(selectedMvcRequest);
                            // Collect the confirmed MvcRequest
                            IMvcRequest confirmedMvcRequest = _mvcController.OutputConfirmedMvcRequest();
                            // Check that the selected MvcRequest is non-null
                            if (confirmedMvcRequest != null)
                            {
                                _logger.Info("Confirmed {}.", confirmedMvcRequest);
                                _mvcView.Process(confirmedMvcRequest);
                                _mvcModel.Process(confirmedMvcRequest);
                                IMvcResponse mvcResponse = _mvcModel.GetMvcResponse();
                                _logger.Info("Outputted {}.", mvcResponse);
                                _mvcView.Process(mvcResponse);
                                _mvcResponses.Add(mvcResponse);
                                _mvcController.Stop();
                            }
                            else
                            {
                                _logger.Debug("{} is still processing. No available Confirmed {}.",
                                    _mvcController.GetType(), typeof(IMvcRequest));
                            }
                        }
                        else
                        {
                            _logger.Debug("{} is still processing. No available Selected {}.",
                                _mvcController.GetType(), typeof(IMvcRequest));
                        }
                    }
                }
                else
                {
                    _logger.Debug("{} is still processing.", _mvcView.GetType());
                }
            }
        }

        /// <inheritdoc/>
        void IMvcFrame.Destroy()
        {
            this._mvcFrameScript.Destroy();
            LoggerManager.EndLoggingFile(_mvcType);
            RandomManager.RemoveRandom(_mvcType);
        }

        /// <inheritdoc/>
        bool IMvcFrame.IsComplete()
        {
            return !_mvcController.IsProcessing() &&
                !_mvcModel.IsProcessing() &&
                !_mvcView.IsProcessing();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        /// <returns></returns>
        protected abstract IMvcModel BuildMvcModel(IMvcFrameConstruction mvcFrameConstruction);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        /// <returns></returns>
        protected abstract IMvcController BuildMvcController(IMvcFrameConstruction mvcFrameConstruction);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        /// <returns></returns>
        protected abstract IMvcView BuildMvcView(IMvcFrameConstruction mvcFrameConstruction);
    }
}