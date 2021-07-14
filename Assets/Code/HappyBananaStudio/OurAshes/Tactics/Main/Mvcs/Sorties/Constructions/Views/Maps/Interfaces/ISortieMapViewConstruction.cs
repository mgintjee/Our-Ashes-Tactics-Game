using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Views.Maps.Interfaces
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