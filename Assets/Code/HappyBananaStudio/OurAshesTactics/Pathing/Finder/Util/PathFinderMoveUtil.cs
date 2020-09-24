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
    public static class PathFinderMoveUtil
    {
        #region Private Fields

        // Todo
        private static PathFinderMove pathFinderMove;

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="tileCoordinatesStart">   </param>
        /// <param name="pathObjectCostThreshold"></param>
        /// <returns></returns>
        public static Dictionary<CubeCoordinates, IPathObject> BeginPathfindingFor(CubeCoordinates tileCoordinatesStart, int pathObjectCostThreshold)
        {
            pathFinderMove = new PathFinderMove(tileCoordinatesStart, pathObjectCostThreshold);
            pathFinderMove.BeginPathFinding();
            Dictionary<CubeCoordinates, IPathObject> pathObjectDictionary = pathFinderMove.GetPathObjectDictionary();
            return pathObjectDictionary;
        }

        #endregion Public Methods
    }
}