using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Loggers.Classes.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Randoms.Managers;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Controls.States.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Results.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Results.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Scripts.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Scripts.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Sims.Types;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.States.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Models.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Models.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.States.Inters;
using System.Diagnostics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Abstrs
{
    /// <summary>
    /// Abstact Mvc Frame Implementation
    /// </summary>
    public abstract class AbstractMvcFrame
        : IMvcFrame
    {
        // Todo
        protected readonly IMvcFrameScript mvcFrameScript;

        // Todo
        protected readonly IMvcModel mvcModel;

        // Todo
        protected readonly IMvcView mvcView;

        // Todo
        protected readonly IMvcControl mvcControl;

        // Todo
        protected readonly IClassLogger logger;

        // Todo
        protected readonly IMvcFrameConstruction prevMvcFrameConstruction;

        // Todo
        protected readonly MvcType mvcType;

        // Todo
        protected IMvcFrameConstruction currMvcFrameConstruction;

        // Todo
        protected IMvcFrameConstruction nextMvcFrameConstruction;

        // Todo
        private readonly MvcFrameStateImpl mvcFrameState;

        // Todo
        private bool initialRequestProcessed = false;

        // Todo
        private IMvcFrameResult mvcFrameResult;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        /// <param name="prevMvcFrameResult">  </param>
        public AbstractMvcFrame(IMvcFrameConstruction mvcFrameConstruction,
            IMvcFrameResult prevMvcFrameResult)
        {
            this.mvcFrameState = new MvcFrameStateImpl(mvcFrameConstruction.GetMvcType());
            this.currMvcFrameConstruction = mvcFrameConstruction;
            this.prevMvcFrameConstruction = (prevMvcFrameResult != null)
                ? prevMvcFrameResult.GetCurrMvcFrameConstruction()
                : null;
            this.nextMvcFrameConstruction = null;
            this.mvcType = currMvcFrameConstruction.GetMvcType();
            this.mvcFrameScript = MvcFrameScriptImpl.Builder.Get()
                .SetName(currMvcFrameConstruction.GetMvcType() + "FrameScript")
                .SetParent(currMvcFrameConstruction.GetUnityScript())
                .Build();
            this.currMvcFrameConstruction = MvcFrameConstruction.Builder.Get()
                .SetSimulationType(currMvcFrameConstruction.GetSimulationType())
                .SetMvcType(currMvcFrameConstruction.GetMvcType())
                .SetMvcControlConstruction(mvcFrameConstruction.GetMvcControlConstruction())
                .SetMvcModelConstruction(mvcFrameConstruction.GetMvcModelConstruction())
                .SetMvcViewConstruction(mvcFrameConstruction.GetMvcViewConstruction())
                // Set the new values
                .SetRandom(RandomManager.GetRandom(mvcType, currMvcFrameConstruction.GetRandom().Next()))
                .SetUnityScript(mvcFrameScript)
                .Build();
            mvcModel = this.BuildMvcModel(this.currMvcFrameConstruction);
            mvcControl = this.BuildMvcControl(this.currMvcFrameConstruction);
            mvcView = (currMvcFrameConstruction.GetSimulationType() != SimsType.BlackBox)
                ? this.BuildMvcView(this.currMvcFrameConstruction)
                : new BlackBoxViewImpl(this.currMvcFrameConstruction);
            logger = this.GetClassLogger();
            logger.Info("Built {}...", this.GetType().Name);
        }

        /// <inheritdoc/>
        void IMvcFrame.Continue()
        {
            if (this.mvcControl.IsProcessing() || this.mvcView.IsProcessing())
            {
                logger.Info("Cannot have {} continue yet. {} isProcessing: {}, {} isProcessing: {}.",
                    this.GetType().Name, this.mvcControl.GetType().Name, this.mvcControl.IsProcessing(),
                    this.mvcView.GetType().Name, this.mvcView.IsProcessing());
            }
            else
            {
                if (this.initialRequestProcessed)
                {
                    IMvcControlState mvcControlState = this.mvcControl.GetState();
                    mvcFrameState.SetMvcControlState(mvcControlState);
                    Optional<IMvcControlInput> mvcControlInput = mvcControlState.GetMvcControlInput();
                    Optional<IMvcRequest> mvcModelRequest = mvcControlState.GetMvcModelRequest();
                    if (mvcModelRequest.IsPresent())
                    {
                        this.mvcModel.Process(mvcModelRequest.GetValue());
                        IMvcModelState mvcModelState = this.mvcModel.GetState();
                        mvcFrameState.SetMvcModelState(mvcModelState);
                        this.mvcControl.Process(mvcModelState);
                        this.mvcView.Process(mvcModelState);
                    }
                    else if (mvcControlInput.IsPresent())
                    {
                        this.mvcView.Process(mvcControlInput.GetValue());
                        IMvcViewState mvcViewState = this.mvcView.GetState();
                        mvcFrameState.SetMvcViewState(mvcViewState);
                        this.mvcControl.Process(mvcViewState);
                    }
                }
                else
                {
                    logger.Info("Processing initial request...");
                    this.mvcModel.Process(null);
                    IMvcModelState mvcModelState = this.mvcModel.GetState();
                    this.mvcControl.Process(mvcModelState);
                    this.mvcView.Process(mvcModelState);
                    this.initialRequestProcessed = true;
                }
            }
        }

        /// <inheritdoc/>
        void IMvcFrame.Destroy()
        {
            this.mvcFrameScript.Destroy();
            LoggerManager.EndLoggingFile(mvcType);
            RandomManager.RemoveRandom(mvcType);
        }

        /// <inheritdoc/>
        bool IMvcFrame.IsProcessing()
        {
            bool isProcessing = mvcControl.IsProcessing() ||
                mvcModel.IsProcessing() || mvcView.IsProcessing();
            if (!isProcessing)
            {
                this.BuildNextMvcFrameConstruction();
                this.mvcFrameResult = MvcFrameResultImpl.Builder.Get()
                    .SetCurrMvcFrameConstruction(this.currMvcFrameConstruction)
                    .SetNextMvcFrameConstruction(this.nextMvcFrameConstruction)
                    .SetPrevMvcFrameConstruction(this.prevMvcFrameConstruction)
                    .SetMvcFrameState(this.mvcFrameState)
                    .Build();
            }
            return isProcessing;
        }

        IMvcFrameResult IMvcFrame.GetMvcFrameResult()
        {
            return this.mvcFrameResult;
        }

        protected virtual void BuildNextMvcFrameConstruction()
        {
        }

        protected virtual IMvcControl BuildMvcControl(IMvcFrameConstruction mvcFrameConstruction)
        {
            return new DefaultMvcControlImpl(mvcFrameConstruction);
        }

        protected virtual IMvcModel BuildMvcModel(IMvcFrameConstruction mvcFrameConstruction)
        {
            return new DefaultMvcModelImpl(mvcFrameConstruction);
        }

        protected virtual IMvcView BuildMvcView(IMvcFrameConstruction mvcFrameConstruction)
        {
            return new DefaultMvcViewImpl(mvcFrameConstruction);
        }

        private IClassLogger GetClassLogger()
        {
            return LoggerManager.GetLogger(this.currMvcFrameConstruction.GetMvcType())
                .GetClassLogger(new StackFrame().GetMethod().DeclaringType);
        }
    }
}