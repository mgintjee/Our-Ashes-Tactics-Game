using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Classes.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Abstrs
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
        protected bool _isProcessing = true;

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
            logger.Info("Constructing {} for MvcType: {}",
                typeof(IMvcModel), mvcFrameConstruction.GetMvcType());
            _mvcFrameConstruction = mvcFrameConstruction;
            this.mvcModelState = this.BuildInitialMvcModelState();
            _isProcessing = true;
        }

        /// <inheritdoc/>
        bool IMvcModel.IsProcessing()
        {
            return this._isProcessing;
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
                logger.Info("Processing initial {}...", typeof(IMvcRequest));
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