using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Results.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Models.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Types;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Models.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Impls;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Impls
{
    /// <summary>
    /// QSortie Frame Impl
    /// </summary>
    public class QSortieMenuFrameImpl
        : AbstractMvcFrame, IMvcFrame
    {
        public QSortieMenuFrameImpl(IMvcFrameConstruction mvcFrameConstruction, IMvcFrameResult prevMvcFrameResult)
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
        protected override IMvcRequest GetInitialRequest()
        {
            return new DefaultRequestImpl(RequestType.DetailsSortie);
        }
    }
}