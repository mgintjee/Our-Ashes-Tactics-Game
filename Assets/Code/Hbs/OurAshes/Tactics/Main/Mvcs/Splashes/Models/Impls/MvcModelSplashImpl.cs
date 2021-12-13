using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Requests.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Splashes.Models.States.Impls;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Splashes.Models.Impls
{
    /// <summary>
    /// Mvc Model Splash Implementation
    /// </summary>
    public class MvcModelSplashImpl : AbstractMvcModel, IMvcModel
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public MvcModelSplashImpl(IMvcFrameConstruction mvcFrameConstruction) : base(mvcFrameConstruction)
        {
        }

        public override IMvcModelState Process(IMvcControlRequest mvcControlRequest)
        {
            throw new System.NotImplementedException();
        }

        protected override IMvcModelState BuildInitialMvcModelState()
        {
            return new MvcModelStateSplashImpl();
        }
    }
}