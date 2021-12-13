using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.States.Inters;

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

        public override void Process(IMvcModelState mvcModelState)
        {
            throw new System.NotImplementedException();
        }

        public override IMvcViewState Process(IMvcControlInput mvcControlInput)
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

        protected override IMvcViewState BuildInitialMvcViewState()
        {
            throw new System.NotImplementedException();
        }
    }
}