using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Classes.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Randoms.Managers;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Reports.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Sims.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Menus.Homes.Controls.Constrs.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Menus.Homes.Models.Constrs.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Menus.Homes.Views.Constrs.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Screens.Splashes.Controls.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Screens.Splashes.Models.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Screens.Splashes.Views.Impls;
using System.Diagnostics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Screens.Splashes.Frames.Impls
{
    /// <summary>
    /// Splash Frame Impl
    /// </summary>
    public class SplashFrameImpl
        : AbstractMvcFrame
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public SplashFrameImpl(IMvcFrameConstruction mvcFrameConstruction, IMvcFrameResult prevMvcFrameResult)
            : base(mvcFrameConstruction, prevMvcFrameResult)
        {
            this.nextMvcFrameConstruction = MvcFrameConstruction.Builder.Get()
                .SetUnityScript(mvcFrameConstruction.GetUnityScript())
                .SetSimulationType(SimsType.Interactive)
                .SetMvcType(MvcType.MenuHome)
                .SetMvcControlConstruction(HomeControlConstruction.Builder.Get().Build())
                .SetMvcModelConstruction(HomeModelConstruction.Builder.Get().Build())
                .SetMvcViewConstruction(HomeViewConstruction.Builder.Get().Build())
                .SetRandom(RandomManager.GetRandom(MvcType.ScreenLoading))
                .Build();
        }

        /// <inheritdoc/>
        protected override IMvcControl BuildMvcControl(IMvcFrameConstruction mvcFrameConstruction)
        {
            return new SplashControlImpl(mvcFrameConstruction);
        }

        /// <inheritdoc/>
        protected override IMvcModel BuildMvcModel(IMvcFrameConstruction mvcFrameConstruction)
        {
            return new SplashModelImpl(mvcFrameConstruction);
        }

        /// <inheritdoc/>
        protected override IMvcView BuildMvcView(IMvcFrameConstruction mvcFrameConstruction)
        {
            return new SplashViewImpl(mvcFrameConstruction);
        }

        /// <inheritdoc/>
        protected override IClassLogger GetClassLogger()
        {
            return LoggerManager.GetLogger(this.currMvcFrameConstruction.GetMvcType())
                .GetClassLogger(new StackFrame().GetMethod().DeclaringType);
        }
    }
}