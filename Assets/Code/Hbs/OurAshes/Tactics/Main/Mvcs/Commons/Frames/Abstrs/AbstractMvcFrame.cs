using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Frames.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Classes.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Randoms.Managers;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Requests.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.States.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Scripts.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Scripts.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Simulations.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.States.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Impls.BlackBoxes;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.States.Inters;
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
            _mvcFrameScript = MvcFrameScriptImpl.Builder.Get()
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
                : new MvcViewBlackBoxImpl(_mvcFrameConstruction);
        }

        /// <inheritdoc/>
        void IMvcFrame.Continue()
        {
            if (this._mvcControl.IsProcessing() || this._mvcView.IsProcessing())
            {
                _logger.Info("Cannot have {} continue yet. {} isProcessing: {}, {} isProcessing: {}.",
                    this.GetType(), this._mvcControl.GetType(), this._mvcControl.IsProcessing(),
                    this._mvcView.GetType(), this._mvcView.IsProcessing());
            }
            else
            {
                IMvcControlState mvcControlState = this._mvcControl.GetMvcControlState();
                Optional<IMvcControlInput> mvcControlInput = mvcControlState.GetMvcControlInput();
                Optional<IMvcControlRequest> mvcControlRequest = mvcControlState.GetMvcControlRequest();
                if (mvcControlRequest.IsPresent())
                {
                    IMvcModelState mvcModelState = this._mvcModel.Process(mvcControlRequest.GetValue());
                    this._mvcControl.Process(mvcModelState);
                    this._mvcView.Process(mvcModelState);
                }
                else if (mvcControlInput.IsPresent())
                {
                    IMvcViewState mvcViewResponse = this._mvcView.Process(mvcControlInput.GetValue());
                    this._mvcControl.Process(mvcViewResponse);
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
        bool IMvcFrame.IsProcessing()
        {
            return _mvcControl.IsProcessing() ||
                _mvcModel.IsProcessing() ||
                _mvcView.IsProcessing();
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
        protected abstract IMvcFrameConstruction BuildUpcomingMvcFrameConstruction(IMvcFrameState mvcFrameState);
    }
}