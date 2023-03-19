using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Managers.Randoms;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Results.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Sims.Types;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Models.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Loadings.Screens.Models.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Loadings.Screens.Views.Impls;
using System;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Loadings.Screens.Frames.Impls
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
                logger.Info("Setting next {}:{}", typeof(IMvcFrameConstruction).Name,
                    prevMvcFrameResult.GetPrevMvcFrameConstruction().GetMvcType());
                this.nextMvcFConstr = prevMvcFrameResult.GetNextMvcFrameConstruction();
            }
            else
            {
                Random random = RandomManager.GetRandom(MvcType.SplashScreen);
                this.nextMvcFConstr = new MvcFrameConstructionImpl(MvcType.SplashScreen, SimType.Interactive,
                    mvcFrameConstruction.GetUnityScript(), random);
            }
            // Todo: Maybe have this as a thread or something?
            this.Process(nextMvcFConstr);
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

        protected override IMvcRequest GetInitialRequest()
        {
            return null;
        }

        private void Process(IMvcFrameConstruction mvcFrameConstruction)
        {
            MvcType mvcType = mvcFrameConstruction.GetMvcType();
            logger.Info("Loading resources for MvcType: {}", mvcType);
        }
    }
}