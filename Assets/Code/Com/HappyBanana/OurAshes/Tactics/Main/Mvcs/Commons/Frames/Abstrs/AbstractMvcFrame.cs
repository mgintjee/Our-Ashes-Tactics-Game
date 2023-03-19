using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Apis.Loggers.Classes.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Apis.Optionals;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Managers.Loggers;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Managers.Randoms;
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
using System;
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
        protected readonly IMvcFrameScript mvcFScript;

        // Todo
        protected readonly IMvcModel mvcM;

        // Todo
        protected readonly IMvcView mvcV;

        // Todo
        protected readonly IMvcControl mvcC;

        // Todo
        protected readonly IClassLogger logger;

        // Todo
        protected readonly IMvcFrameConstruction prevMvcFConstr;

        // Todo
        protected readonly MvcType mvcType;

        // Todo
        protected IMvcFrameConstruction currMvcFConstr;

        // Todo
        protected IMvcFrameConstruction nextMvcFConstr;

        // Todo
        private readonly MvcFrameStateImpl mvcFState;

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
            this.mvcFState = new MvcFrameStateImpl(mvcFrameConstruction.GetMvcType());
            this.currMvcFConstr = mvcFrameConstruction;
            this.prevMvcFConstr = (prevMvcFrameResult != null)
                ? prevMvcFrameResult.GetCurrMvcFrameConstruction()
                : null;
            this.nextMvcFConstr = null;
            this.mvcType = currMvcFConstr.GetMvcType();
            this.mvcFScript = MvcFrameScriptImpl.Builder.Get()
                .SetName(currMvcFConstr.GetMvcType() + "FrameScript")
                .SetParent(currMvcFConstr.GetUnityScript())
                .Build();
            Random random = RandomManager.GetRandom(mvcType, currMvcFConstr.GetRandom().Next());
            this.currMvcFConstr = new MvcFrameConstructionImpl(currMvcFConstr.GetMvcType(), currMvcFConstr.GetSimulationType(), mvcFScript, random);
            mvcM = this.BuildMvcModel(this.currMvcFConstr);
            mvcC = this.BuildMvcControl(this.currMvcFConstr);
            mvcV = (currMvcFConstr.GetSimulationType() != SimType.BlackBox)
                ? this.BuildMvcView(this.currMvcFConstr)
                : new BlackBoxViewImpl(this.currMvcFConstr);
            logger = this.GetClassLogger();
            logger.Info("Built {}...", this.GetType().Name);
        }

        /// <inheritdoc/>
        void IMvcFrame.Continue()
        {
            if (this.mvcC.IsProcessing() || this.mvcV.IsProcessing())
            {
                logger.Info("Cannot have {} continue yet. {} isProcessing: {}, {} isProcessing: {}.",
                    this.GetType().Name, this.mvcC.GetType().Name, this.mvcC.IsProcessing(),
                    this.mvcV.GetType().Name, this.mvcV.IsProcessing());
            }
            else
            {
                if (this.initialRequestProcessed)
                {
                    IMvcControlState mvcControlState = this.mvcC.GetState();
                    mvcFState.SetMvcControlState(mvcControlState);
                    IOptional<IMvcControlInput> mvcControlInput = mvcControlState.GetMvcControlInput();
                    IOptional<IMvcRequest> mvcModelRequest = mvcControlState.GetMvcModelRequest();
                    if (mvcModelRequest.IsPresent())
                    {
                        this.mvcM.Process(mvcModelRequest.GetValue());
                        IMvcModelState mvcModelState = this.mvcM.GetState();
                        mvcFState.SetMvcModelState(mvcModelState);
                        this.mvcC.Process(mvcModelState);
                        this.mvcV.Process(mvcModelState);
                    }
                    else if (mvcControlInput.IsPresent())
                    {
                        this.mvcV.Process(mvcControlInput.GetValue());
                        IMvcViewState mvcViewState = this.mvcV.GetState();
                        mvcFState.SetMvcViewState(mvcViewState);
                        this.mvcC.Process(mvcViewState);
                    }
                }
                else
                {
                    logger.Info("Processing initial request...");
                    this.mvcM.Process(GetInitialRequest());
                    IMvcModelState mvcModelState = this.mvcM.GetState();
                    this.mvcC.Process(mvcModelState);
                    this.mvcV.Process(mvcModelState);
                    this.initialRequestProcessed = true;
                }
            }
        }

        /// <inheritdoc/>
        void IMvcFrame.Destroy()
        {
            this.mvcFScript.Destroy();
            LoggerManager.EndLoggingFile(mvcType);
            RandomManager.RemoveRandom(mvcType);
        }

        /// <inheritdoc/>
        bool IMvcFrame.IsProcessing()
        {
            bool isProcessing = mvcC.IsProcessing() ||
                mvcM.IsProcessing() || mvcV.IsProcessing();
            if (!isProcessing)
            {
                this.BuildNextMvcFrameConstruction();
                this.mvcFrameResult = MvcFrameResultImpl.Builder.Get()
                    .SetCurrMvcFrameConstruction(this.currMvcFConstr)
                    .SetNextMvcFrameConstruction(this.nextMvcFConstr)
                    .SetPrevMvcFrameConstruction(this.prevMvcFConstr)
                    .SetMvcFrameState(this.mvcFState)
                    .Build();
            }
            return isProcessing;
        }

        IMvcFrameResult IMvcFrame.GetMvcFrameResult()
        {
            return this.mvcFrameResult;
        }

        protected abstract IMvcRequest GetInitialRequest();

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
            return LoggerManager.GetLogger(this.currMvcFConstr.GetMvcType())
                .GetClassLogger(new StackFrame().GetMethod().DeclaringType);
        }
    }
}