using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Randoms.Managers;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Results.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Sims.Types;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Models.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Inters;
using System;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Homes.Menus.Frames.Impls
{
    /// <summary>
    /// HomeMenu Frame Impl
    /// </summary>
    public class HomeMenuFrameImpl
        : AbstractMvcFrame, IMvcFrame
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        /// <param name="prevMvcFrameResult">  </param>
        public HomeMenuFrameImpl(IMvcFrameConstruction mvcFrameConstruction, IMvcFrameResult prevMvcFrameResult)
            : base(mvcFrameConstruction, prevMvcFrameResult)
        {
        }

        /// <inheritdoc/>
        protected override IMvcModel BuildMvcModel(IMvcFrameConstruction mvcFrameConstruction)
        {
            return new MvcModelImpl(mvcFrameConstruction);
        }

        /// <inheritdoc/>
        protected override IMvcView BuildMvcView(IMvcFrameConstruction mvcFrameConstruction)
        {
            return new MvcViewImpl(mvcFrameConstruction);
        }

        /// <inheritdoc/>
        protected override void BuildNextMvcFrameConstruction()
        {
            this.mvcM.GetState().GetPrevMvcRequest().IfPresent(request =>
                {
                    IHomeMenuRequest homeMenuRequest = (IHomeMenuRequest)request;
                    logger.Info("Building next {} for {}",
                        typeof(IMvcFrameConstruction).Name, homeMenuRequest.GetRequestType());
                    switch (homeMenuRequest.GetRequestType())
                    {
                        case RequestType.QSortie:
                            Random random = RandomManager.GetRandom(MvcType.QSortieMenu);
                            IUnityScript unityScript = this.currMvcFConstr.GetUnityScript().GetParent().GetValue();
                            this.nextMvcFConstr = new MvcFrameConstructionImpl(MvcType.QSortieMenu, SimType.Interactive,
                                unityScript, random);
                            break;
                    }
                });
        }

        protected override IMvcRequest GetInitialRequest()
        {
            return null;
        }
    }
}