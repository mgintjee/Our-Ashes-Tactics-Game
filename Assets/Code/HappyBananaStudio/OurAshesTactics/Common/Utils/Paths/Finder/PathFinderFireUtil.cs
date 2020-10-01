/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Coordinates;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Paths.Object;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Loggers;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Objects.Paths.Finders.Fire;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Paths.Finder
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class PathFinderFireUtil
    {
        // Provide logging capability
        private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private static PathFinderFireImpl pathFinderFire;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="tileCoordinatesStart">
        /// </param>
        /// <returns>
        /// </returns>
        public static Dictionary<ICubeCoordinates, IPathObject> BeginPathfindingFor(ICubeCoordinates tileCoordinatesStart)
        {
            logger.Debug("BeginPathFinding for Fire: Start=?", tileCoordinatesStart);
            pathFinderFire = new PathFinderFireImpl(tileCoordinatesStart);
            pathFinderFire.BeginPathFinding();
            Dictionary<ICubeCoordinates, IPathObject> pathObjectDictionary = pathFinderFire.GetPathObjectDictionary();
            return pathObjectDictionary;
        }
    }
}