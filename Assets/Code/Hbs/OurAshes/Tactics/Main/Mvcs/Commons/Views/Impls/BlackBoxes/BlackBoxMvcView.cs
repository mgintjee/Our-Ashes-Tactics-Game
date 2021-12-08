using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Reports.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Reports.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Inters;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Impls.BlackBoxes
{
    /// <summary>
    /// Black Box Mvc View Implementation
    /// </summary>
    public class BlackBoxMvcView : AbstractMvcView, IMvcView
    {
        /// <summary>
        /// Todo
        /// </summary>
        public BlackBoxMvcView(IMvcFrameConstruction mvcFrameConstruction)
            : base(mvcFrameConstruction)
        {
            _isProcessing = false;
        }

        public override void Process(IMvcModelReport mvcModelReport)
        {
            // Do nothing
        }

        public override void Process(IMvcControlReport mvcControlReport)
        {
            // Do nothing
        }

        protected override void BuildCanvas()
        {
            // Do nothing
        }
    }
}