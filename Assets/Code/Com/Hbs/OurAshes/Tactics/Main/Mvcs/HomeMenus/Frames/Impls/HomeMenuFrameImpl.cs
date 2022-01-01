using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Randoms.Managers;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Results.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Sims.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.HomeMenus.Models.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.HomeMenus.Models.Requests.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.HomeMenus.Models.Requests.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.HomeMenus.Views.Impls;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.HomeMenus.Frames.Impls
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
            return new HomeMenuModelImpl(mvcFrameConstruction);
        }

        /// <inheritdoc/>
        protected override IMvcView BuildMvcView(IMvcFrameConstruction mvcFrameConstruction)
        {
            return new HomeMenuViewImpl(mvcFrameConstruction);
        }

        /// <inheritdoc/>
        protected override void BuildNextMvcFrameConstruction()
        {
            this.mvcModel.GetState().GetPrevMvcRequest().IfPresent(request =>
                {
                    IHomeMenuRequest homeMenuRequest = (IHomeMenuRequest)request;
                    logger.Info("Building next {} for {}",
                        typeof(IMvcFrameConstruction), homeMenuRequest.GetHomeRequestType());
                    switch (homeMenuRequest.GetHomeRequestType())
                    {
                        case HomeRequestType.QSortie:
                            this.nextMvcFrameConstruction = MvcFrameConstruction.Builder.Get()
                                .SetUnityScript(this.currMvcFrameConstruction
                                    .GetUnityScript().GetParent())
                                .SetSimulationType(SimsType.Interactive)
                                .SetMvcType(MvcType.QSortieMenu)
                                .SetRandom(RandomManager.GetRandom(MvcType.QSortieMenu))
                                .Build();
                            break;
                    }
                });
        }
    }
}