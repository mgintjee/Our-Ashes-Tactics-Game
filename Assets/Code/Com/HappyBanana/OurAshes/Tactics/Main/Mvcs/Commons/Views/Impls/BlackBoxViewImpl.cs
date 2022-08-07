using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Inters;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Impls
{
    /// <summary>
    /// Black Box Mvc View Impl
    /// </summary>
    public class BlackBoxViewImpl
        : AbstractMvcView, IMvcView
    {
        /// <summary>
        /// Todo
        /// </summary>
        public BlackBoxViewImpl(IMvcFrameConstruction mvcFrameConstruction)
            : base(mvcFrameConstruction)
        {
            isProcessing = false;
        }

        protected override IMvcViewCanvas BuildInitialMvcViewCanvas()
        {
            // Do nothing
            return null;
        }
    }
}