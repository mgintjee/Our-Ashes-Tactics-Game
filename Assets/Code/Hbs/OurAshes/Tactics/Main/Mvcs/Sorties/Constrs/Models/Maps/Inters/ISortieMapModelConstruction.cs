using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Models.Maps.Tiles.Inters;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Models.Maps.Inters
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface ISortieMapModelConstruction
    {
        ISet<ISortieTileModelConstruction> GetSortieTileModelConstrs();
    }
}