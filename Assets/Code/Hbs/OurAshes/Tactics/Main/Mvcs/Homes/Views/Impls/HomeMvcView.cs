using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Reports.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Reports.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Inters;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Homes.Views.Impls
{
    /// <summary>
    /// Home View Implementation
    /// </summary>
    public class HomeMvcView : AbstractMvcView, IMvcView
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public HomeMvcView(IMvcFrameConstruction mvcFrameConstruction) : base(mvcFrameConstruction)
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

        /// <inheritdoc/>
        protected override void BuildCanvas()
        {
            // this.mvcViewBackCanvas = new HomeViewBackCanvas(this.unityScript);
            this.mvcViewBackCanvas.Build();

            //this.mvcViewForeCanvas = new HomeViewForeCanvas(this.unityScript);
            this.mvcViewBackCanvas.Build();
        }
    }
}