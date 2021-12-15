using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Views.Maps.Tiles.Inters;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Views.Maps.Inters
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