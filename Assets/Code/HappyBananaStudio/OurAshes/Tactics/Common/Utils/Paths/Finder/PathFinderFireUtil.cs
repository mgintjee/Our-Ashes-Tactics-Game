
namespace HappyBananaStudio.OurAshes.Tactics.Common.Utils.Paths.Finder
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Coordinates.Objects.Cube;
    using HappyBananaStudio.OurAshes.Tactics.Api.Loggers;
    using HappyBananaStudio.OurAshes.Tactics.Api.Paths.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Loggers;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Paths.Finders.Fire;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Todo
    /// </summary>
    public static class PathFinderFireUtil
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLoggerImpl(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private static PathFinderFireImpl pathFinderFire;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="tileCoordinatesStart">
        /// </param>
        /// <returns>
        /// </returns>
        public static IDictionary<ICubeCoordinates, IPathObject> BeginPathfindingFor(ICubeCoordinates tileCoordinatesStart, int maxRange)
        {
            logger.Debug("BeginPathFinding for Fire: Start=?", tileCoordinatesStart);
            pathFinderFire = new PathFinderFireImpl(tileCoordinatesStart, maxRange);
            pathFinderFire.BeginPathFinding();
            return pathFinderFire.GetPathObjectDictionary();
        }
    }
}
