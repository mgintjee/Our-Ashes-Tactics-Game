using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Frames.Simulations.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Frames.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Classes.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Randoms.Managers;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Reports.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Reports.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Reports.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Scripts.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Scripts.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Reports.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Impls.BlackBoxes;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Reports.Inters;
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
        protected readonly IMvcControl _mvcControl;

        // Todo
        protected readonly IClassLogger _logger;

        // Todo
        protected readonly IMvcFrameConstruction _mvcFrameConstruction;

        // Todo
        private readonly IMvcFrameConstruction _returnMvcFrameConstruction;

        // Todo
        private readonly IList<IMvcFrameReport> _mvcReports = new List<IMvcFrameReport>();

        // Todo
        private readonly MvcType _mvcType;

        // Todo
        private IMvcFrameConstruction _nextMvcFrameConstruction;

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
            _mvcControl = this.BuildMvcControl(_mvcFrameConstruction);
            _mvcView = (mvcFrameConstruction.GetSimulationType() != SimulationType.BlackBox)
                ? this.BuildMvcView(_mvcFrameConstruction)
                : new BlackBoxMvcView(_mvcFrameConstruction);
        }

        /// <inheritdoc/>
        void IMvcFrame.Continue()
        {
            IMvcControlReport mvcControlReport = _mvcControl.GetReport();
            IMvcViewReport mvcViewReport = _mvcView.GetReport();
            IMvcModelReport mvcModelReport = _mvcModel.GetReport();
            _logger.Info("Control: {}, View: {}, Model: {}.", mvcControlReport, mvcViewReport, mvcModelReport);
            // Check if the MvcView is either null or no longer processing
            if (!mvcViewReport.IsProcessing())
            {
                // Check if the MvcControl is no longer processing
                if (!mvcControlReport.IsProcessing())
                {
                    // Check if the MvcControl has any requests
                    if (!mvcControlReport.HasRequests())
                    {
                        // Pass in the Model's available MvcRequests
                        _mvcControl.Process(mvcModelReport);
                    }
                    else
                    {
                        _logger.Debug("{} is still processing.", _mvcControl.GetType());
                    }
                }
                else
                {
                    _mvcView.Process(mvcControlReport);
                    _mvcModel.Process(mvcControlReport);
                    IMvcModelReport newMvcModelReport = _mvcModel.GetReport();
                    _logger.Info("Outputted {}.", newMvcModelReport);
                    if (mvcModelReport != newMvcModelReport)
                    {
                        _mvcView.Process(newMvcModelReport);
                        _mvcControl.Process(newMvcModelReport);
                        // Build the new response
                        _mvcReports.Add(MvcFrameReport.Builder.Get()
                            .SetMvcControlReport(mvcControlReport)
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
            return !_mvcControl.GetReport().IsProcessing() &&
                !_mvcModel.GetReport().IsProcessing() &&
                !_mvcView.GetReport().IsProcessing();
        }

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
        protected abstract IMvcControl BuildMvcControl(IMvcFrameConstruction mvcFrameConstruction);

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
    }
}