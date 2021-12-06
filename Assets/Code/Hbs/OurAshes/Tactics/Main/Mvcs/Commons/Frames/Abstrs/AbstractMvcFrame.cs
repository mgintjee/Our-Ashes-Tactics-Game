using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Frames.Simulations.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Frames.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Classes.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Randoms.Managers;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Scripts.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Scripts.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Reports.Controllers.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Reports.Frames.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Reports.Frames.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Reports.Models.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Reports.Views.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Impls.BlackBoxes;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Inters;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Abstrs
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
        protected readonly IClassLogger _logger;

        // Todo
        protected readonly IMvcFrameConstruction _mvcFrameConstruction;

        // Todo
        private readonly IMvcFrameConstruction _returnMvcFrameConstruction;

        // Todo
        private IMvcFrameConstruction _nextMvcFrameConstruction;

        // Todo
        private readonly IList<IMvcFrameReport> _mvcReports = new List<IMvcFrameReport>();

        // Todo
        private readonly MvcType _mvcType;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public AbstractMvcFrame(IMvcFrameConstruction mvcFrameConstruction,
            IMvcFrameConstruction returnMvcFrameConstruction)
        {
            _logger = LoggerManager.GetLogger(mvcFrameConstruction.GetMvcType())
                .GetClassLogger(new StackFrame().GetMethod().DeclaringType);
            _logger.Info("Building {} {}", mvcFrameConstruction.GetMvcType(), typeof(IMvcFrame));
            _returnMvcFrameConstruction = returnMvcFrameConstruction;
            _nextMvcFrameConstruction = null;
            _mvcType = mvcFrameConstruction.GetMvcType();
            _mvcFrameScript = MvcFrameScript.Builder.Get()
                .SetMvcFrameConstruction(mvcFrameConstruction)
                .Build();
            _mvcFrameConstruction = MvcFrameConstruction.Builder.Get()
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

        /// <inheritdoc/>
        void IMvcFrame.Continue()
        {
            IMvcControllerReport mvcControllerReport = _mvcController.GetReport();
            IMvcViewReport mvcViewReport = _mvcView.GetReport();
            IMvcModelReport mvcModelReport = _mvcModel.GetReport();
            _logger.Info("Controller: {}, View: {}, Model: {}.", mvcControllerReport, mvcViewReport, mvcModelReport);
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
                    if (((IMvcFrame)this).IsComplete())
                    {
                        _nextMvcFrameConstruction = this.BuildUpcomingMvcFrameConstruction(
                            _mvcReports[_mvcReports.Count - 1]);
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

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        protected abstract IMvcFrameConstruction BuildUpcomingMvcFrameConstruction(IMvcFrameReport mvcFrameReport);

        /// <inheritdoc/>
        IMvcFrameConstruction IMvcFrame.GetCurrentMvcFrameConstruction()
        {
            return this._mvcFrameConstruction;
        }

        /// <inheritdoc/>
        IMvcFrameConstruction IMvcFrame.GetUpcomingMvcFrameConstruction()
        {
            return _nextMvcFrameConstruction ?? _returnMvcFrameConstruction;
        }
    }
}