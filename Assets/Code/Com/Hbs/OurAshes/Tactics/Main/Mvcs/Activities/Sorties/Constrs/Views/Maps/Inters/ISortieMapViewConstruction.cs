﻿using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Constrs.Views.Maps.Tiles.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Constrs.Views.Maps.Inters
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface ISortieMapViewConstruction
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ISet<ISortieTileViewConstruction> GetSortieTileViewConstrs();
    }
}