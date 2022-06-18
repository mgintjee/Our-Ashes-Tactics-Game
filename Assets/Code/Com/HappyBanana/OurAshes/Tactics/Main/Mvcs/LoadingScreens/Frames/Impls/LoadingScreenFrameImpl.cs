using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Randoms.Managers;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Results.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Sims.Types;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Models.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.LoadingScreens.Models.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.LoadingScreens.Views.Impls;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.LoadingScreens.Frames.Impls
{
    /// <summary>
    /// Loading Frame Impl
    /// </summary>
    public class LoadingScreenFrameImpl
        : AbstractMvcFrame
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public LoadingScreenFrameImpl(IMvcFrameConstruction mvcFrameConstruction, IMvcFrameResult prevMvcFrameResult)
            : base(mvcFrameConstruction, prevMvcFrameResult)
        {
            if (prevMvcFrameResult != null)
            {
                logger.Info("Setting next {}:{}", typeof(IMvcFrameConstruction),
                    prevMvcFrameResult.GetPrevMvcFrameConstruction().GetMvcType());
                this.nextMvcFrameConstruction = prevMvcFrameResult.GetNextMvcFrameConstruction();
            }
            else
            {
                this.nextMvcFrameConstruction = MvcFrameConstruction.Builder.Get()
                    .SetUnityScript(mvcFrameConstruction.GetUnityScript())
                    .SetSimulationType(SimsType.Interactive)
                    .SetMvcType(MvcType.SplashScreen)
                    .SetRandom(RandomManager.GetRandom(MvcType.SplashScreen))
                    .Build();
            }
            // Todo: Maybe have this as a thread or something?
            this.Process(nextMvcFrameConstruction);
        }

        /// <inheritdoc/>
        protected override IMvcView BuildMvcView(IMvcFrameConstruction mvcFrameConstruction)
        {
            return new MvcViewImpl(mvcFrameConstruction);
        }

        /// <inheritdoc/>
        protected override IMvcModel BuildMvcModel(IMvcFrameConstruction mvcFrameConstruction)
        {
            return new MvcModelImpl(mvcFrameConstruction);
        }

        private void Process(IMvcFrameConstruction mvcFrameConstruction)
        {
            MvcType mvcType = mvcFrameConstruction.GetMvcType();
            logger.Info("Loading resources for MvcType: {}", mvcType);
        }
    }
}