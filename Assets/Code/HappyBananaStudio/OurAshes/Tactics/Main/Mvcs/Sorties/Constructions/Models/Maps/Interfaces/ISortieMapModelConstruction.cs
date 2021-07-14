using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Models.Maps.Interfaces
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