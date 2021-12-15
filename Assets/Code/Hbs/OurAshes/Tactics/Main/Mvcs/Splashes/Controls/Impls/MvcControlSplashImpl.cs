using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.States.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.States.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.States.Inters;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Splashes.Controls.Impls
{
    /// <summary>
    /// Mvc Control Splash Impl
    /// </summary>
    public class SplashControlImpl
        : AbstractMvcControl, IMvcControl
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public SplashControlImpl(IMvcFrameConstruction mvcFrameConstruction)
            : base(mvcFrameConstruction)
        {
        }

        public override void Process(IMvcModelState mvcModelState)
        {
            _logger.Info("Processing {}...", mvcModelState);
            ((MvcControlStateImpl)this.mvcControlState).SetMvcControlInput(null);
            ((MvcControlStateImpl)this.mvcControlState).SetMvcModelRequest(null);
        }

        public override void Process(IMvcViewState mvcViewState)
        {
            _logger.Info("Processing {}...", mvcViewState);
            ((MvcControlStateImpl)this.mvcControlState).SetMvcControlInput(null);
            mvcViewState.GetMvcModelRequest().IfPresent(mvcModelRequest =>
            {
                ((MvcControlStateImpl)this.mvcControlState).SetMvcModelRequest(mvcModelRequest);
            });
        }

        public override void Process(IMvcControlInput mvcControlInput)
        {
            _logger.Info("Processing {}...", mvcControlInput);
            ((MvcControlStateImpl)this.mvcControlState).SetMvcControlInput(mvcControlInput);
        }

        protected override IMvcControlState BuildInitialMvcControlState()
        {
            return new MvcControlStateImpl();
        }
    }
}