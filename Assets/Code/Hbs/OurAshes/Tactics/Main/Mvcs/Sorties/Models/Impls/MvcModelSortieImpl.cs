using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Requests.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Impls
{
    /// <summary>
    /// Sortie Model Impl
    /// </summary>
    public class MvcModelSortieImpl : AbstractMvcModel, IMvcModel
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public MvcModelSortieImpl(IMvcFrameConstruction mvcFrameConstruction) : base(mvcFrameConstruction)
        {
        }

        public override IMvcModelState Process(IMvcModelRequest mvcModelRequest)
        {
            throw new System.NotImplementedException();
        }

        protected override IMvcModelState BuildInitialMvcModelState()
        {
            throw new System.NotImplementedException();
        }
    }
}