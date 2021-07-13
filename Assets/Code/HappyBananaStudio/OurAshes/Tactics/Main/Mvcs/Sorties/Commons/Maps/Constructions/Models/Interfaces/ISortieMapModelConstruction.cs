using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Constructions.Models.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Constructions.Models.Interfaces
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface ISortieMapModelConstruction
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ISet<ISortieTileModelConstruction> GetSortieTileModelConstructions();
    }
}