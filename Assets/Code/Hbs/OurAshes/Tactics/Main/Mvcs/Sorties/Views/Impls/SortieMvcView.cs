using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Reports.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Reports.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Inters;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Impls
{
    /// <summary>
    /// Sortie Mvc View Implementation
    /// </summary>
    public class SortieMvcView : AbstractMvcView, IMvcView
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public SortieMvcView(IMvcFrameConstruction mvcFrameConstruction)
            : base(mvcFrameConstruction)
        {
        }

        /// <inheritdoc/>
        public override void Process(IMvcModelReport mvcModelReport)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc/>
        public override void Process(IMvcControlReport mvcControlReport)
        {
            throw new System.NotImplementedException();
        }

        protected override void BuildCanvas()
        {
            throw new System.NotImplementedException();
        }
    }
}