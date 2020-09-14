/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Mvc.Coordinates.Cube;
using HappyBananaStudio.OurAshesTactics.Pathing.Object.Api;
using System.Collections.Generic;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Pathing.Finder.Api
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IPathFinder
    {
        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        void BeginPathFinding();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        HashSet<CubeCoordinates> GetCubeCoordiantesEndSet();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        Dictionary<CubeCoordinates, IPathObject> GetPathObjectDictionary();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinatesEnd"></param>
        /// <returns></returns>

        IPathObject GetPathObjectForCubeCoordinatesEnd(CubeCoordinates cubeCoordinatesEnd);

        #endregion Public Methods
    }
}