using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Cube.Api;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Pathing.Objects.Api
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IPathObject
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ICubeCoordinates GetCubeCoordinatesEnd();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ICubeCoordinates GetCubeCoordinatesStart();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IList<ICubeCoordinates> GetCubeCoordinatesStepList();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        float GetPathObjectCost();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        int GetPathObjectLength();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        bool IsValid();
    }
}