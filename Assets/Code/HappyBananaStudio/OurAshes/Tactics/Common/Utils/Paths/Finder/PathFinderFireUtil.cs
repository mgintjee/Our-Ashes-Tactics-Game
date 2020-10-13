/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>

namespace HappyBananaStudio.OurAshesTactics.Common.Utils.Paths.Finder
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Coordinates.Objects.Cube;
    using HappyBananaStudio.OurAshes.Tactics.Api.Loggers;
    using HappyBananaStudio.OurAshes.Tactics.Api.Paths.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Loggers;
    using HappyBananaStudio.OurAshesTactics.Impl.Objects.Paths.Finders.Fire;
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
        public static IDictionary<ICubeCoordinates, IPathObject> BeginPathfindingFor(ICubeCoordinates tileCoordinatesStart)
        {
            logger.Debug("BeginPathFinding for Fire: Start=?", tileCoordinatesStart);
            pathFinderFire = new PathFinderFireImpl(tileCoordinatesStart);
            pathFinderFire.BeginPathFinding();
            IDictionary<ICubeCoordinates, IPathObject> pathObjectIDictionary = pathFinderFire.GetPathObjectIDictionary();
            return pathObjectIDictionary;
        }
    }
}
