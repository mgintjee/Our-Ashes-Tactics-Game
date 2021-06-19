using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Maps.Coordinates.Cube.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Implementaions.Waits;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Maps.PathFinders.Implementaions.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Maps.PathFinders.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Maps.PathFinders.Implementaions.Waits
{
    /// <summary>
    /// Todo
    /// </summary>
    public class WaitPathFinder
        : AbstractPathFinder
    {
        // Provides logging capability to the SORTIE logs
        private static readonly ILogger _logger = LoggerManager.GetSortieLogger(new StackFrame().GetMethod().DeclaringType);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="tileCoordinatesStart"></param>
        /// <param name="mapReport">           </param>
        private WaitPathFinder(ICubeCoordinates tileCoordinatesStart, IMapReport mapReport)
            : base(tileCoordinatesStart, mapReport)
        {
        }

        /// <inheritdoc/>
        protected override void PathFind()
        {
            this.cubeCoordinatesPaths.Add(this.cubeCoordinates,
                new WaitPath(new List<ICubeCoordinates>() { this.cubeCoordinates }, this.mapReport));
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            private IMapReport _mapReport = null;

            // Todo
            private ICubeCoordinates cubeCoordinates = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IPathFinder Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Object
                    return new WaitPathFinder(this.cubeCoordinates, _mapReport);
                }
                throw ExceptionUtil.Arguments.Build("Unable to construct {}. Invalid Parameters. {}",
                    this.GetType(), string.Join("\n", invalidReasons));
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="cubeCoordinates"></param>
            /// <returns></returns>
            public Builder SetCubeCoordinates(ICubeCoordinates cubeCoordinates)
            {
                this.cubeCoordinates = cubeCoordinates;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="mapReport"></param>
            /// <returns></returns>
            public Builder SetMapReport(IMapReport mapReport)
            {
                _mapReport = mapReport;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            private ISet<string> IsInvalid()
            {
                // Default an empty Set: String
                ISet<string> argumentExceptionSet = new HashSet<string>();
                // Check that startingCubeCoordinates has been set
                if (this.cubeCoordinates == null)
                {
                    argumentExceptionSet.Add("Starting " + typeof(ICubeCoordinates) + " cannot be null.");
                }
                // Check that mapReport has been set
                if (_mapReport == null)
                {
                    argumentExceptionSet.Add(typeof(IMapReport) + " cannot be null.");
                }
                return argumentExceptionSet;
            }
        }
    }
}