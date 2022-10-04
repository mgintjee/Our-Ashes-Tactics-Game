using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Apis.Loggers.Classes.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Managers.Loggers;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Models.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Models.Abstrs
{
    /// <summary>
    /// Abstract Mvc Model
    /// </summary>
    public abstract class AbstractMvcModel
        : IMvcModel
    {
        // Todo
        protected readonly IClassLogger logger;

        // Todo
        protected readonly IMvcModelState mvcModelState;

        // Todo
        protected bool isProcessing = true;

        // Todo
        protected IMvcFrameConstruction _mvcFrameConstruction;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public AbstractMvcModel(IMvcFrameConstruction mvcFrameConstruction)
        {
            logger = LoggerManager.GetLogger(mvcFrameConstruction.GetMvcType())
                .GetClassLogger(this.GetType());
            logger.Info("Constructing {}", this.GetType().Name);
            _mvcFrameConstruction = mvcFrameConstruction;
            this.mvcModelState = this.BuildInitialMvcModelState();
            isProcessing = true;
        }

        /// <inheritdoc/>
        bool IMvcModel.IsProcessing()
        {
            return this.isProcessing;
        }

        /// <inheritdoc/>
        void IMvcModel.Process(IMvcRequest mvcModelRequest)
        {
            ((DefaultMvcModelStateImpl)this.mvcModelState)
                .SetPrevMvcRequest(mvcModelRequest);
            if (mvcModelRequest != null)
            {
                logger.Info("Processing {}...", mvcModelRequest);
                this.ProcessMvcModelRequest(mvcModelRequest);
            }
            else
            {
                logger.Info("Processing initial request...");
                this.ProcessInitialMvcModelRequest();
            }
        }

        IMvcModelState IMvcModel.GetState()
        {
            return this.mvcModelState;
        }

        protected virtual IMvcModelState BuildInitialMvcModelState()
        {
            return new DefaultMvcModelStateImpl();
        }

        protected abstract IMvcModelState ProcessMvcModelRequest(IMvcRequest mvcModelRequest);

        protected virtual IMvcModelState ProcessInitialMvcModelRequest()
        {
            return this.mvcModelState;
        }
    }
}