using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Frames.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Classes.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Randoms.Managers;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.States.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Scripts.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Scripts.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Simulations.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.States.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Requests.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Impls.BlackBoxes;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.States.Inters;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Abstrs
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
        protected readonly IMvcModel mvcModel;

        // Todo
        protected readonly IMvcView mvcView;

        // Todo
        protected readonly IMvcControl mvcControl;

        // Todo
        protected readonly IClassLogger _logger;

        // Todo
        protected readonly IMvcFrameConstruction mvcFrameConstruction;

        // Todo
        protected readonly IMvcFrameConstruction _returnMvcFrameConstruction;

        // Todo
        protected readonly MvcType _mvcType;

        // Todo
        protected IMvcFrameConstruction nextMvcFrameConstruction;

        // Todo
        private bool initialRequestProcessed = false;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public AbstractMvcFrame(IMvcFrameConstruction mvcFrameConstruction,
            IMvcFrameConstruction returnMvcFrameConstruction)
        {
            _returnMvcFrameConstruction = returnMvcFrameConstruction;
            nextMvcFrameConstruction = null;
            _mvcType = mvcFrameConstruction.GetMvcType();
            _mvcFrameScript = MvcFrameScriptImpl.Builder.Get()
                .SetMvcFrameConstruction(mvcFrameConstruction)
                .Build();
            this.mvcFrameConstruction = MvcFrameConstruction.Builder.Get()
                .SetSimulationType(mvcFrameConstruction.GetSimulationType())
                .SetMvcType(mvcFrameConstruction.GetMvcType())
                // Set the new values
                .SetRandom(RandomManager.GetRandom(_mvcType, mvcFrameConstruction.GetRandom().Next()))
                .SetUnityScript(_mvcFrameScript)
                .Build();
            mvcModel = this.BuildMvcModel(this.mvcFrameConstruction);
            mvcControl = this.BuildMvcControl(this.mvcFrameConstruction);
            mvcView = (mvcFrameConstruction.GetSimulationType() != SimulationType.BlackBox)
                ? this.BuildMvcView(this.mvcFrameConstruction)
                : new MvcViewBlackBoxImpl(this.mvcFrameConstruction);
            _logger = this.GetClassLogger();
            _logger.Info("Built {}...", this.GetType());
        }

        /// <inheritdoc/>
        void IMvcFrame.Continue()
        {
            if (this.mvcControl.IsProcessing() || this.mvcView.IsProcessing())
            {
                _logger.Info("Cannot have {} continue yet. {} isProcessing: {}, {} isProcessing: {}.",
                    this.GetType(), this.mvcControl.GetType(), this.mvcControl.IsProcessing(),
                    this.mvcView.GetType(), this.mvcView.IsProcessing());
            }
            else
            {
                if (this.initialRequestProcessed)
                {
                    IMvcControlState mvcControlState = this.mvcControl.GetMvcControlState();
                    Optional<IMvcControlInput> mvcControlInput = mvcControlState.GetMvcControlInput();
                    Optional<IMvcModelRequest> mvcModelRequest = mvcControlState.GetMvcModelRequest();
                    if (mvcModelRequest.IsPresent())
                    {
                        IMvcModelState mvcModelState = this.mvcModel.Process(mvcModelRequest.GetValue());
                        this.mvcControl.Process(mvcModelState);
                        this.mvcView.Process(mvcModelState);
                    }
                    else if (mvcControlInput.IsPresent())
                    {
                        IMvcViewState mvcViewState = this.mvcView.Process(mvcControlInput.GetValue());
                        this.mvcControl.Process(mvcViewState);
                    }
                }
                else
                {
                    _logger.Info("Processing initial request...");
                    IMvcModelState mvcModelState = this.mvcModel.Process(null);
                    this.mvcControl.Process(mvcModelState);
                    this.mvcView.Process(mvcModelState);
                    this.initialRequestProcessed = true;
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
            return mvcControl.IsProcessing() ||
                mvcModel.IsProcessing() ||
                mvcView.IsProcessing();
        }

        /// <inheritdoc/>
        IMvcFrameConstruction IMvcFrame.GetCurrentMvcFrameConstruction()
        {
            return this.mvcFrameConstruction;
        }

        /// <inheritdoc/>
        IMvcFrameConstruction IMvcFrame.GetUpcomingMvcFrameConstruction()
        {
            return nextMvcFrameConstruction ?? _returnMvcFrameConstruction;
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
        protected abstract IClassLogger GetClassLogger();
    }
}