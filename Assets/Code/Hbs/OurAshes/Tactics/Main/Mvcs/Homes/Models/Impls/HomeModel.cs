﻿using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Requests.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;

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
        public override IMvcModelState Process(IMvcControlRequest mvcControlRequest)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc/>
        protected override IMvcModelState BuildInitialMvcModelState()
        {
            throw new System.NotImplementedException();
        }
    }
}