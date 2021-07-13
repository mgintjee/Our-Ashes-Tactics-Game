using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Maps.Coordinates.Cube.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Sorties.Maps.Paths.Types;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Interfaces
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface ISortieMapPath
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ICubeCoordinates GetEnd();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ICubeCoordinates GetStart();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IList<ICubeCoordinates> GetCubeCoordinatesList();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        float GetPathCost();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        int GetLength();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        PathType GetPathType();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        bool IsValid();
    }
}