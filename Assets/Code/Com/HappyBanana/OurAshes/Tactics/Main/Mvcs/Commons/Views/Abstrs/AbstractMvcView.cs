using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Apis.Loggers.Classes.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Managers.Loggers;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.States.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.States.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Abstrs
{
    /// <summary>
    /// Abstract Mvc View
    /// </summary>
    public abstract class AbstractMvcView
        : IMvcView
    {
        // Todo
        protected readonly IClassLogger logger;

        // Todo
        protected readonly IMvcViewState mvcViewState;

        // Todo
        protected IMvcModelState mvcModelState;

        // Todo
        protected bool isProcessing = false;

        // Todo
        protected IMvcViewCanvas mvcViewCanvas;

        // Todo
        protected IMvcFrameConstruction mvcFrameConstruction;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public AbstractMvcView(IMvcFrameConstruction mvcFrameConstruction)
        {
            logger = LoggerManager.GetLogger(mvcFrameConstruction.GetMvcType())
                .GetClassLogger(this.GetType());
            logger.Info("Constructing {}...", this.GetType().Name);
            this.mvcFrameConstruction = mvcFrameConstruction;
            this.mvcViewState = this.BuildInitialMvcViewState();
            this.mvcViewCanvas = this.BuildInitialMvcViewCanvas();
        }

        /// <inheritdoc/>
        bool IMvcView.IsProcessing()
        {
            return isProcessing;
        }

        /// <inheritdoc/>
        void IMvcView.Process(IMvcModelState mvcModelState)
        {
            ((DefaultMvcViewStateImpl)this.mvcViewState).Reset();
            logger.Info("Processing {}...", mvcModelState);
            this.InternalProcess(mvcModelState);
        }

        /// <inheritdoc/>
        void IMvcView.Process(IMvcControlInput mvcControlInput)
        {
            ((DefaultMvcViewStateImpl)this.mvcViewState).Reset();
            logger.Info("Processing {}...", mvcControlInput);
            this.InternalProcess(mvcControlInput);
        }

        IMvcViewState IMvcView.GetState()
        {
            return this.mvcViewState;
        }

        /// <summary>
        /// Todo
        /// </summary>
        protected abstract IMvcViewCanvas BuildInitialMvcViewCanvas();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        protected virtual IMvcViewState BuildInitialMvcViewState()
        {
            return new DefaultMvcViewStateImpl();
        }

        protected virtual IList<IMvcRequest> GetMvcRequests()
        {
            return new List<IMvcRequest>() { new MvcRequestImpl() };
        }

        /// <summary>
        /// /Todo
        /// </summary>
        /// <param name="mvcModelState"></param>
        protected virtual void InternalProcess(IMvcModelState mvcModelState)
        {
            this.mvcModelState = mvcModelState;
            this.mvcViewCanvas.Process(mvcModelState);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcControlInput"></param>
        protected virtual void InternalProcess(IMvcControlInput mvcControlInput)
        {
            // Todo
        }
    }
}