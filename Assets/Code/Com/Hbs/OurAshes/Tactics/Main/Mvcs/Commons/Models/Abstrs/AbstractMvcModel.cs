﻿using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Classes.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Requests.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Abstrs
{
    /// <summary>
    /// Abstract Mvc Model
    /// </summary>
    public abstract class AbstractMvcModel : IMvcModel
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
        IMvcModelState IMvcModel.Process(IMvcModelRequest mvcModelRequest)
        {
            if (mvcModelRequest != null)
            {
                logger.Info("Processing {}...", mvcModelRequest);
                return this.ProcessMvcModelRequest(mvcModelRequest);
            }
            else
            {
                return this.ProcessInitialMvcModelRequest();
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        protected virtual IMvcModelState BuildInitialMvcModelState()
        {
            return new MvcModelStateImpl();
        }

        protected abstract IMvcModelState ProcessMvcModelRequest(IMvcModelRequest mvcModelRequest);

        protected abstract IMvcModelState ProcessInitialMvcModelRequest();
    }
}