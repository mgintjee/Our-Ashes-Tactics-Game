using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Reports.Models.Inters;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Homes.Controllers.Impls
{
    /// <summary>
    /// Home Controller Implementation
    /// </summary>
    public class HomeController : AbstractMvcController, IMvcController
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public HomeController(IMvcFrameConstruction mvcFrameConstruction) : base(mvcFrameConstruction)
        {
        }

        /// <inheritdoc/>
        public override void Process(IMvcModelReport mvcModelReport)
        {
            throw new System.NotImplementedException();
        }
    }
}