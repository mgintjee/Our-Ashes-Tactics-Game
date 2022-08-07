using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Randoms.Managers;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Results.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Sims.Types;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.SplashScreens.Views.Impls;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.SplashScreens.Frames.Impls
{
    /// <summary>
    /// Splash Frame Impl
    /// </summary>
    public class SplashScreenFrameImpl
        : AbstractMvcFrame
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public SplashScreenFrameImpl(IMvcFrameConstruction mvcFrameConstruction, IMvcFrameResult prevMvcFrameResult)
            : base(mvcFrameConstruction, prevMvcFrameResult)
        {
            this.nextMvcFrameConstruction = MvcFrameConstruction.Builder.Get()
                .SetUnityScript(mvcFrameConstruction.GetUnityScript())
                .SetSimulationType(SimsType.Interactive)
                .SetMvcType(MvcType.HomeMenu)
                .SetRandom(RandomManager.GetRandom(MvcType.HomeMenu))
                .Build();
        }

        /// <inheritdoc/>
        protected override IMvcView BuildMvcView(IMvcFrameConstruction mvcFrameConstruction)
        {
            return new MvcViewImpl(mvcFrameConstruction);
        }
        protected override IMvcRequest GetInitialRequest()
        {
            return null;
        }
    }
}