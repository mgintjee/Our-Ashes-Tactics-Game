using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Constructions.Views.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Constructions.Views.Interfaces
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
        ISet<ISortieTileViewConstruction> GetSortieTileViewConstructions();
    }
}