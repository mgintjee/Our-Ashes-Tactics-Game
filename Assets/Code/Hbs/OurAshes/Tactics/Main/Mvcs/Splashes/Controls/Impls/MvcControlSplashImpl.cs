using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Frames.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Managers.Impls;
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
    /// Mvc Control Splash Implementation
    /// </summary>
    public class MvcControlSplashImpl
        : AbstractMvcControl, IMvcControl
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public MvcControlSplashImpl(IMvcFrameConstruction mvcFrameConstruction)
            : base(mvcFrameConstruction)
        {
        }

        public override void Process(IMvcModelState mvcModelState)
        {
            throw new System.NotImplementedException();
        }

        public override void Process(IMvcViewState mvcViewState)
        {
            throw new System.NotImplementedException();
        }

        public override void Process(IMvcControlInput mvcControlInput)
        {
            ((MvcControlStateImpl)this.mvcControlState).SetMvcControlInput(mvcControlInput);
        }

        protected override IMvcControlState BuildInitialMvcControlState()
        {
            return new MvcControlStateImpl();
        }
    }
}