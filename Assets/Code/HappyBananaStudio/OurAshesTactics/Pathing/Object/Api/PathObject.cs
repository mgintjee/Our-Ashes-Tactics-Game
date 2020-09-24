/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Mvc.Coordinates.Cube;
using System.Collections.Generic;

namespace HappyBananaStudio.OurAshesTactics.Pathing.Object.Api
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IPathObject
    {
        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        CubeCoordinates GetCubeCoordinatesEnd();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        CubeCoordinates GetCubeCoordinatesStart();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        List<CubeCoordinates> GetCubeCoordinatesStepList();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        int GetPathObjectCost();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        int GetPathObjectLength();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        bool IsValid();

        #endregion Public Methods
    }
}