using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Reports.Inters;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Homes.Controls.Impls
{
    /// <summary>
    /// Home Control Implementation
    /// </summary>
    public class HomeControl : AbstractMvcControl, IMvcControl
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public HomeControl(IMvcFrameConstruction mvcFrameConstruction) : base(mvcFrameConstruction)
        {
        }

        /// <inheritdoc/>
        public override void Process(IMvcModelReport mvcModelReport)
        {
            throw new System.NotImplementedException();
        }
    }
}