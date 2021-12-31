using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Frames.Sorties.Maps.Paths.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Maps.Coordinates.Cube.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Inters
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