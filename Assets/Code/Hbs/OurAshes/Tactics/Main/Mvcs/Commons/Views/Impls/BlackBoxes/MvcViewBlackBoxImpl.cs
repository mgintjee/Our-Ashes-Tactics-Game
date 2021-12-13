using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.States.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.States.Inters;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Impls.BlackBoxes
{
    /// <summary>
    /// Black Box Mvc View Implementation
    /// </summary>
    public class MvcViewBlackBoxImpl : AbstractMvcView, IMvcView
    {
        /// <summary>
        /// Todo
        /// </summary>
        public MvcViewBlackBoxImpl(IMvcFrameConstruction mvcFrameConstruction)
            : base(mvcFrameConstruction)
        {
            _isProcessing = false;
        }

        public override void Process(IMvcModelState mvcModelState)
        {
            // Do nothing
        }

        public override IMvcViewState Process(IMvcControlInput mvcControlInput)
        {
            // Do nothing
            return this.mvcViewState;
        }

        protected override void BuildCanvas()
        {
            // Do nothing
        }

        protected override IMvcViewState BuildInitialMvcViewState()
        {
            return new MvcViewStateBlackBoxImpl();
        }
    }
}