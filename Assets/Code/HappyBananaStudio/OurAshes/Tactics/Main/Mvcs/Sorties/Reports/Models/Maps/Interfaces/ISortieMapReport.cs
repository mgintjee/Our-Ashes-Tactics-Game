using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Tiles.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Maps.Interfaces
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface ISortieMapReport : IReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ISet<ICubeCoordinates> GetCubeCoordinates();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        bool IsMirrored();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        int GetRadius();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates"></param>
        /// <returns></returns>
        Optional<ISortieTileReport> GetTileReport(ICubeCoordinates cubeCoordinates);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="combatantCallSign"></param>
        /// <returns></returns>
        Optional<ISortieTileReport> GetTileReport(CombatantCallSign combatantCallSign);
    }
}