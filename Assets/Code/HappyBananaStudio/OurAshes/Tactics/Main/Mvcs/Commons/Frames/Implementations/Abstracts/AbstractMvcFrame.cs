using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Mvcs.Simulations.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Mvcs.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Randoms.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constructions.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Scripts.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Scripts.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Models.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Reports.Controllers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Reports.Frames.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Reports.Frames.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Reports.Models.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Reports.Views.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Implementations.BlackBoxes;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Implementations.Abstracts
{
    /// <summary>
    /// Abstact Mvc Frame Interface
    /// </summary>
    public abstract class AbstractMvcFrame : IMvcFrame
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
        protected readonly IMvcFrameConstruction _mvcFrameConstruction;

        // Todo
        private readonly IList<IMvcFrameReport> _mvcReports = new List<IMvcFrameReport>();

        // Todo
        private readonly MvcType _mvcType;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public AbstractMvcFrame(IMvcFrameConstruction mvcFrameConstruction)
        {
            _logger.Info("Building {} {}", mvcFrameConstruction.GetMvcType(), typeof(IMvcFrame));
            _mvcType = mvcFrameConstruction.GetMvcType();
            _logger = LoggerManager.GetLogger(_mvcType, this.GetType());
            _mvcFrameScript = MvcFrameScript.Builder.Get()
                .SetMvcFrameConstruction(mvcFrameConstruction)
                .Build();
            _mvcFrameConstruction = MvcFrameConstruction.Builder.Get()
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
            _mvcModel = this.BuildMvcModel(_mvcFrameConstruction);
            _mvcController = this.BuildMvcController(_mvcFrameConstruction);
            _mvcView = (mvcFrameConstruction.GetSimulationType() != SimulationType.BlackBox)
                ? this.BuildMvcView(_mvcFrameConstruction)
                : new BlackBoxMvcView(_mvcFrameConstruction);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        /// <returns></returns>
        public abstract IMvcFrameConstruction GetReturnMvcFrameConstruction();

        /// <inheritdoc/>
        void IMvcFrame.Continue()
        {
            IMvcControllerReport mvcControllerReport = _mvcController.GetReport();
            IMvcViewReport mvcViewReport = _mvcView.GetReport();
            IMvcModelReport mvcModelReport = _mvcModel.GetReport();
            _logger.Info("Controller: {}.", mvcControllerReport);
            _logger.Info("View: {}.", mvcViewReport);
            _logger.Info("Model: {}.", mvcModelReport);
            // Check if the MvcView is either null or no longer processing
            if (!mvcViewReport.IsProcessing())
            {
                // Check if the MvcController is no longer processing
                if (!mvcControllerReport.IsProcessing())
                {
                    // Check if the MvcController has any requests
                    if (!mvcControllerReport.HasRequests())
                    {
                        // Pass in the Model's available MvcRequests
                        _mvcController.Process(mvcModelReport);
                    }
                    else
                    {
                        _logger.Debug("{} is still processing.", _mvcController.GetType());
                    }
                }
                else
                {
                    _mvcView.Process(mvcControllerReport);
                    _mvcModel.Process(mvcControllerReport);
                    IMvcModelReport newMvcModelReport = _mvcModel.GetReport();
                    _logger.Info("Outputted {}.", newMvcModelReport);
                    if (mvcModelReport != newMvcModelReport)
                    {
                        _mvcView.Process(newMvcModelReport);
                        _mvcController.Process(newMvcModelReport);
                        // Build the new response
                        _mvcReports.Add(MvcFrameReport.Builder.Get()
                            .SetMvcControllerReport(mvcControllerReport)
                            .SetMvcViewReport(mvcViewReport)
                            .SetMvcModelReport(mvcModelReport)
                            .Build());
                    }
                }
            }
            else
            {
                _logger.Debug("{} is still processing.", _mvcView.GetType());
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
            return !_mvcController.GetReport().IsProcessing() &&
                !_mvcModel.GetReport().IsProcessing() &&
                !_mvcView.GetReport().IsProcessing();
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