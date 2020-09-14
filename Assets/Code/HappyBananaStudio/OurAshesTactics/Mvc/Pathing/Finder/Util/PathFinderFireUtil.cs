/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Mvc.Coordinates.Cube;
using HappyBananaStudio.OurAshesTactics.Mvc.Pathing.Finder.Impl;
using HappyBananaStudio.OurAshesTactics.Pathing.Object.Api;
using System.Collections.Generic;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Pathing.Finder.Util
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class PathFinderFireUtil
    {
        #region Private Fields

        private static PathFinderFire pathFinderFire;

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="tileCoordinatesStart"></param>
        /// <returns></returns>
        public static Dictionary<CubeCoordinates, IPathObject> BeginPathfindingFor(CubeCoordinates tileCoordinatesStart)
        {
            pathFinderFire = new PathFinderFire(tileCoordinatesStart);
            pathFinderFire.BeginPathFinding();
            Dictionary<CubeCoordinates, IPathObject> pathObjectDictionary = pathFinderFire.GetPathObjectDictionary();
            return pathObjectDictionary;
        }

        #endregion Public Methods
    }
}