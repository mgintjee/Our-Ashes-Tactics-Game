/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Coordinates;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Paths.Object;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Loggers;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Objects.Paths.Finders.Move;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Utils.Paths.Finder
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class PathFinderMoveUtil
    {
        // Provide logging capability
        private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private static PathFinderMoveImpl pathFinderMove;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="tileCoordinatesStart">
        /// </param>
        /// <param name="pathObjectCostThreshold">
        /// </param>
        /// <returns>
        /// </returns>
        public static Dictionary<ICubeCoordinates, IPathObject> BeginPathfindingFor(ICubeCoordinates tileCoordinatesStart, int pathObjectCostThreshold)
        {
            logger.Debug("BeginPathFinding for Move: Start=? with MaxCost=", tileCoordinatesStart, pathObjectCostThreshold);
            pathFinderMove = new PathFinderMoveImpl(tileCoordinatesStart, pathObjectCostThreshold);
            pathFinderMove.BeginPathFinding();
            Dictionary<ICubeCoordinates, IPathObject> pathObjectDictionary = pathFinderMove.GetPathObjectDictionary();
            return pathObjectDictionary;
        }
    }
}