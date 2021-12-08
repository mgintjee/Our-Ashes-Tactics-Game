using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Frames.Simulations.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Frames.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Randoms.Managers;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Reports.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Splashes.Controls.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Splashes.Frames.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Splashes.Models.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Splashes.Views.Impls;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Splashes.Frames.Impls
{
    /// <summary>
    /// Splash Frame Implementation
    /// </summary>
    public class SplashFrame : AbstractMvcFrame, ISplashFrame
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public SplashFrame(IMvcFrameConstruction mvcFrameConstruction, IMvcFrameConstruction returnMvcFrameConstruction)
            : base(mvcFrameConstruction, returnMvcFrameConstruction)
        {
        }

        /// <inheritdoc/>
        protected override IMvcControl BuildMvcControl(IMvcFrameConstruction mvcFrameConstruction)
        {
            return new SplashControl(mvcFrameConstruction);
        }

        /// <inheritdoc/>
        protected override IMvcModel BuildMvcModel(IMvcFrameConstruction mvcFrameConstruction)
        {
            return new SplashModel(mvcFrameConstruction);
        }

        /// <inheritdoc/>
        protected override IMvcView BuildMvcView(IMvcFrameConstruction mvcFrameConstruction)
        {
            return new SplashMvcView(mvcFrameConstruction);
        }

        /// <inheritdoc/>
        protected override IMvcFrameConstruction BuildUpcomingMvcFrameConstruction(IMvcFrameReport mvcFrameReport)
        {
            return MvcFrameConstruction.Builder.Get()
                .SetMvcType(MvcType.Home)
                .SetRandom(RandomManager.GetRandom(MvcType.Home))
                .SetSimulationType(SimulationType.Interactive)
                .SetUnityScript(_mvcFrameConstruction.GetUnityScript())
                .Build();
        }
    }
}