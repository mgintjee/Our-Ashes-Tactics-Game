using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Reports.Frames.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Homes.Controllers.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Homes.Frames.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Homes.Models.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Homes.Views.Impls;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Homes.Frames.Impls
{
    /// <summary>
    /// Home Frame Implementation
    /// </summary>
    public class HomeFrame : AbstractMvcFrame, IHomeFrame
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public HomeFrame(IMvcFrameConstruction mvcFrameConstruction, IMvcFrameConstruction returnMvcFrameConstruction)
            : base(mvcFrameConstruction, returnMvcFrameConstruction)
        {
        }

        /// <inheritdoc/>
        protected override IMvcController BuildMvcController(IMvcFrameConstruction mvcFrameConstruction)
        {
            return new HomeController(mvcFrameConstruction);
        }

        /// <inheritdoc/>
        protected override IMvcModel BuildMvcModel(IMvcFrameConstruction mvcFrameConstruction)
        {
            return new HomeModel(mvcFrameConstruction);
        }

        /// <inheritdoc/>
        protected override IMvcView BuildMvcView(IMvcFrameConstruction mvcFrameConstruction)
        {
            return new HomeMvcView(mvcFrameConstruction);
        }

        protected override IMvcFrameConstruction BuildUpcomingMvcFrameConstruction(IMvcFrameReport mvcFrameReport)
        {
            throw new System.NotImplementedException();
        }
    }
}