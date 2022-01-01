using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Constrs.Models.Maps.Tiles.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Constrs.Models.Maps.Inters
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface ISortieMapModelConstruction
    {
        ISet<ISortieTileModelConstruction> GetSortieTileModelConstrs();
    }
}