using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Classes.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.States.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.States.Inters;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Abstrs
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
        protected bool _isProcessing = false;

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
            logger.Info("Constructing {} for MvcType: {}",
                typeof(IMvcView), mvcFrameConstruction.GetMvcType());
            this.mvcFrameConstruction = mvcFrameConstruction;
            this.mvcViewState = this.BuildInitialMvcViewState();
            this.mvcViewCanvas = this.BuildInitialMvcViewCanvas();
        }

        /// <inheritdoc/>
        bool IMvcView.IsProcessing()
        {
            return _isProcessing;
        }

        /// <inheritdoc/>
        void IMvcView.Process(IMvcModelState mvcModelState)
        {
            logger.Info("Processing {}...", mvcModelState);
            this.InternalProcess(mvcModelState);
        }

        /// <inheritdoc/>
        IMvcViewState IMvcView.Process(IMvcControlInput mvcControlInput)
        {
            logger.Info("Processing {}...", mvcControlInput);
            this.InternalProcess(mvcControlInput);
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
            return new MvcViewStateImpl();
        }

        /// <summary>
        /// /Todo
        /// </summary>
        /// <param name="mvcModelState"></param>
        protected virtual void InternalProcess(IMvcModelState mvcModelState)
        {
            this.mvcModelState = mvcModelState;
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