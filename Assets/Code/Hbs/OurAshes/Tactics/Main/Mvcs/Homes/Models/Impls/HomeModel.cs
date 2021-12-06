using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Inters;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Homes.Models.Impls
{
    /// <summary>
    /// Home Model Implementation
    /// </summary>
    public class HomeModel : AbstractMvcModel, IMvcModel
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public HomeModel(IMvcFrameConstruction mvcFrameConstruction)
            : base(mvcFrameConstruction)
        {
        }

        /// <inheritdoc/>
        protected override void BuildInitialRequests()
        {
            // Todo
        }

        /// <inheritdoc/>
        protected override void ProcessConfirmedRequest(IMvcRequest mvcRequest)
        {
            throw new System.NotImplementedException();
        }
    }
}