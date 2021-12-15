using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.States.Inters;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Impls
{
    /// <summary>
    /// Sortie Mvc View Impl
    /// </summary>
    public class MvcViewSortieImpl : AbstractMvcView, IMvcView
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public MvcViewSortieImpl(IMvcFrameConstruction mvcFrameConstruction)
            : base(mvcFrameConstruction)
        { }

        public override void Process(IMvcModelState mvcModelState)
        {
            throw new System.NotImplementedException();
        }

        public override IMvcViewState Process(IMvcControlInput mvcControlInput)
        {
            throw new System.NotImplementedException();
        }

        protected override void BuildCanvas()
        {
            throw new System.NotImplementedException();
        }

        protected override IMvcViewState BuildInitialMvcViewState()
        {
            throw new System.NotImplementedException();
        }
    }
}