using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Classes.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Managers.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Managers.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.States.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.States.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
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
        protected readonly IClassLogger _logger;

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
            _logger = LoggerManager.GetLogger(mvcFrameConstruction.GetMvcType())
                .GetClassLogger(this.GetType());
            this.mvcControlState = this.BuildInitialMvcControlState();
            this.mvcControlInput = MvcControlInputManagerImpl.Builder.Get()
                .SetMvcType(mvcFrameConstruction.GetMvcType())
                .SetMvcControl(this)
                .SetName(typeof(MvcControlInputManagerImpl).Name)
                .SetParent(mvcFrameConstruction.GetUnityScript())
                .Build();
        }

        /// <inheritdoc/>
        public abstract void Process(IMvcModelState mvcModelState);

        /// <inheritdoc/>
        public abstract void Process(IMvcViewState mvcViewState);

        /// <inheritdoc/>
        public abstract void Process(IMvcControlInput mvcControlInput);

        /// <inheritdoc/>
        bool IMvcControl.IsProcessing()
        {
            return this.isProcessing;
        }

        /// <inheritdoc/>
        IMvcControlState IMvcControl.GetMvcControlState()
        {
            return this.mvcControlState;
        }

        /// <inheritdoc/>
        protected virtual IMvcControlState BuildInitialMvcControlState()
        {
            return new MvcControlStateImpl();
        }
    }
}