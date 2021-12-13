using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.States.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Homes.Controls.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Homes.Frames.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Homes.Models.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Homes.Views.Impls;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Homes.Frames.Impls
{
    /// <summary>
    /// Home Frame Implementation
    /// </summary>
    public class MvcFrameHomeImpl : AbstractMvcFrame, IHomeFrame
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public MvcFrameHomeImpl(IMvcFrameConstruction mvcFrameConstruction, IMvcFrameConstruction returnMvcFrameConstruction)
            : base(mvcFrameConstruction, returnMvcFrameConstruction)
        {
        }

        /// <inheritdoc/>
        protected override IMvcControl BuildMvcControl(IMvcFrameConstruction mvcFrameConstruction)
        {
            return new MvcControlHomeImpl(mvcFrameConstruction);
        }

        /// <inheritdoc/>
        protected override IMvcModel BuildMvcModel(IMvcFrameConstruction mvcFrameConstruction)
        {
            return new HomeModel(mvcFrameConstruction);
        }

        /// <inheritdoc/>
        protected override IMvcView BuildMvcView(IMvcFrameConstruction mvcFrameConstruction)
        {
            return new HomeMvcView(mvcFrameConstruction);
        }

        protected override IMvcFrameConstruction BuildUpcomingMvcFrameConstruction(IMvcFrameState mvcFrameState)
        {
            throw new System.NotImplementedException();
        }
    }
}