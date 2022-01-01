using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Classes.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Managers.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Managers.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.States.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.States.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Requests.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.States.Inters;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Abstrs
{
    /// <summary>
    /// Abstract Mvc Control Impl
    /// </summary>
    public abstract class AbstractMvcControl
        : IMvcControl
    {
        // Todo
        protected readonly IClassLogger logger;

        // Todo
        protected readonly IMvcControlState mvcControlState;

        // Todo
        protected IMvcModelState mvcModelState;

        // Todo
        protected IMvcControlInputManager mvcControlInput;

        protected bool isProcessing = false;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public AbstractMvcControl(IMvcFrameConstruction mvcFrameConstruction)
        {
            logger = LoggerManager.GetLogger(mvcFrameConstruction.GetMvcType())
                .GetClassLogger(this.GetType());
            logger.Info("Constructing {} for MvcType: {}", typeof(IMvcControl), mvcFrameConstruction.GetMvcType());
            this.mvcControlState = this.BuildInitialMvcControlState();
            this.mvcControlInput = MvcControlInputManagerImpl.Builder.Get()
                .SetMvcType(mvcFrameConstruction.GetMvcType())
                .SetMvcControl(this)
                .SetName(typeof(MvcControlInputManagerImpl).Name)
                .SetParent(mvcFrameConstruction.GetUnityScript())
                .Build();
        }

        /// <inheritdoc/>
        bool IMvcControl.IsProcessing()
        {
            return this.isProcessing;
        }

        /// <inheritdoc/>
        IMvcControlState IMvcControl.GetState()
        {
            return this.mvcControlState;
        }

        /// <inheritdoc/>
        void IMvcControl.Process(IMvcModelState mvcModelState)
        {
            this.InternalProcess(mvcModelState);
        }

        /// <inheritdoc/>
        void IMvcControl.Process(IMvcControlInput mvcControlInput)
        {
            this.InternalProcess(mvcControlInput);
        }

        /// <inheritdoc/>
        void IMvcControl.Process(IMvcViewState mvcViewState)
        {
            this.InternalProcess(mvcViewState);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcViewState"></param>
        protected virtual void InternalProcess(IMvcViewState mvcViewState)
        {
            logger.Info("Processing {}...", mvcViewState);
            ((MvcControlStateImpl)this.mvcControlState).SetMvcControlInput(null);
            mvcViewState.GetMvcModelRequest().IfPresent(mvcModelRequest =>
            {
                logger.Info("Setting {}...", typeof(IMvcRequest));
                ((MvcControlStateImpl)this.mvcControlState).SetMvcModelRequest(mvcModelRequest);
            });
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcControlInput"></param>
        protected virtual void InternalProcess(IMvcControlInput mvcControlInput)
        {
            logger.Info("Processing {}...", mvcControlInput);
            ((MvcControlStateImpl)this.mvcControlState)
                .SetMvcControlInput(mvcControlInput);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        protected virtual IMvcControlState BuildInitialMvcControlState()
        {
            return new MvcControlStateImpl();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcModelState"></param>
        protected virtual void InternalProcess(IMvcModelState mvcModelState)
        {
            logger.Info("Processing {}...", mvcModelState);
            ((MvcControlStateImpl)this.mvcControlState)
                .SetMvcControlInput(null)
                .SetMvcModelRequest(null);
        }
    }
}