

namespace HappyBananaStudio.OurAshes.Tactics.Common.Utils.Paths.Finder
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Coordinates.Objects.Cube;
    using HappyBananaStudio.OurAshes.Tactics.Api.Loggers;
    using HappyBananaStudio.OurAshes.Tactics.Api.Paths.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Loggers;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Paths.Finders.Move;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Todo
    /// </summary>
    public static class PathFinderMoveUtil
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLoggerImpl(new StackFrame().GetMethod().DeclaringType);

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
        public static IDictionary<ICubeCoordinates, IPathObject> BeginPathfindingFor(ICubeCoordinates tileCoordinatesStart, int pathObjectCostThreshold)
        {
            logger.Debug("BeginPathFinding for Move: Start=? with MaxCost=", tileCoordinatesStart, pathObjectCostThreshold);
            pathFinderMove = new PathFinderMoveImpl(tileCoordinatesStart, pathObjectCostThreshold);
            pathFinderMove.BeginPathFinding();
            return pathFinderMove.GetPathObjectDictionary();
        }
    }
}
