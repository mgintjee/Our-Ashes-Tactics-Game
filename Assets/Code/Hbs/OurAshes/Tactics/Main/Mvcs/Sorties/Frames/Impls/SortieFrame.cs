﻿using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Reports.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Controls.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Frames.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Impls;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Frames.Impls
{
    /// <summary>
    /// Sortie Frame Implementation
    /// </summary>
    public class SortieFrame : AbstractMvcFrame, ISortieMvcFrame
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public SortieFrame(IMvcFrameConstruction mvcFrameConstruction, IMvcFrameConstruction returnMvcFrameConstruction)
            : base(mvcFrameConstruction, returnMvcFrameConstruction)
        {
        }

        /// <inheritdoc/>
        protected override IMvcControl BuildMvcControl(IMvcFrameConstruction mvcFrameConstruction)
        {
            return new SortieMvcControl(mvcFrameConstruction);
        }

        /// <inheritdoc/>
        protected override IMvcModel BuildMvcModel(IMvcFrameConstruction mvcFrameConstruction)
        {
            return new SortieModel(mvcFrameConstruction);
        }

        /// <inheritdoc/>
        protected override IMvcView BuildMvcView(IMvcFrameConstruction mvcFrameConstruction)
        {
            return new SortieMvcView(mvcFrameConstruction);
        }

        protected override IMvcFrameConstruction BuildUpcomingMvcFrameConstruction(IMvcFrameReport mvcFrameReport)
        {
            throw new System.NotImplementedException();
        }
    }
}