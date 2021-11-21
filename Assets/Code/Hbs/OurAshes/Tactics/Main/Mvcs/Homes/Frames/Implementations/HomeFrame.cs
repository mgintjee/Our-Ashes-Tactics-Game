using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constructions.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Implementations.Abstracts;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Reports.Frames.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Homes.Controllers.Implementations;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Homes.Frames.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Homes.Models.Implementations;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Homes.Views.Implementations;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Homes.Frames.Implementations
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