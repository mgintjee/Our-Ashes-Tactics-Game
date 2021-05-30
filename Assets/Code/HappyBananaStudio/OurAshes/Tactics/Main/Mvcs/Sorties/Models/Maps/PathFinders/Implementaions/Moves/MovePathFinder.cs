using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Maps.Coordinates.Cube.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Loggers.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Implementaions.Moves;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Maps.PathFinders.Implementaions.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Maps.PathFinders.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Maps.PathFinders.Implementaions.Moves
{
    /// <summary>
    /// Todo
    /// </summary>
    public class MovePathFinder
        : AbstractPathFinder
    {
        // Provide logging capability
        private static readonly ILogger _logger = new SortieLogger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly float _MPs;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates"></param>
        /// <param name="movement">       </param>
        /// <param name="mapReport">      </param>
        private MovePathFinder(ICubeCoordinates cubeCoordinates, float movement, IMapReport mapReport)
            : base(cubeCoordinates, mapReport)
        {
            _MPs = movement;
        }

        /// <summary>
        /// Todo
        /// </summary>
        protected override void PathFind()
        {
            _logger.Debug("PathFind for movement={}", _MPs);
            this.CollectCubeCoordinatesPaths();
            this.DijkstraAlgorithm();
            this.CleanUpCubeCoordinatesPaths();
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void CleanUpCubeCoordinatesPaths()
        {
            ISet<ICubeCoordinates> invalidCubeCoordinates = new HashSet<ICubeCoordinates>();
            foreach (ICubeCoordinates cubeCoordinates in this.cubeCoordinatesPaths.Keys)
            {
                IPath path = this.cubeCoordinatesPaths[cubeCoordinates];
                if (path == null ||
                    !path.IsValid())
                {
                    invalidCubeCoordinates.Add(cubeCoordinates);
                }
            }

            foreach (ICubeCoordinates cubeCoordinates in invalidCubeCoordinates)
            {
                this.cubeCoordinatesPaths.Remove(cubeCoordinates);
            }

            this.cubeCoordinatesPaths.Remove(this.cubeCoordinates);
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void CollectCubeCoordinatesPaths()
        {
            foreach (ICubeCoordinates cubeCoordinates in this.mapReport.GetCubeCoordinates())
            {
                this.mapReport.GetTileReport(cubeCoordinates).IfPresent((tileReport) =>
                {
                    if (tileReport.GetCombatantCallSign() == CombatantCallSign.None ||
                        cubeCoordinates != this.cubeCoordinates)
                    {
                        this.cubeCoordinatesPaths.Add(cubeCoordinates, null);
                    }
                });
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void DijkstraAlgorithm()
        {
            // Default an empty set
            ISet<ICubeCoordinates> visitedCubeCoordinatesSet = new HashSet<ICubeCoordinates>();
            // Default the unvisited set with the starting cubeCoordinates
            ISet<ICubeCoordinates> unvisitedCubeCoordinatesSet = new HashSet<ICubeCoordinates> { this.cubeCoordinates };
            this.cubeCoordinatesPaths[this.cubeCoordinates] = new MovePath(
                new List<ICubeCoordinates>() { this.cubeCoordinates }, this.mapReport);
            // Continue iterating until all CubeCoordinates have been visited
            while (unvisitedCubeCoordinatesSet.Count > 0)
            {
                // Collect the closest CubeCoordinates from the unvisited set
                ICubeCoordinates closestCubeCoordinates = this.GetClosestCubeCoordinate(unvisitedCubeCoordinatesSet);
                // Check if the closest CubeCoordinates is non-null
                if (closestCubeCoordinates != null)
                {
                    // Collect the neighbors of the closest CubeCoordinates
                    ISet<ICubeCoordinates> closestCubeCoordinatesNeighborSet = closestCubeCoordinates.GetNeighbors();
                    // Remove all that are not tracked in the mapReport
                    closestCubeCoordinatesNeighborSet.IntersectWith(this.mapReport.GetCubeCoordinates());
                    // Add the closest CubeCoordinates to the visited set
                    visitedCubeCoordinatesSet.Add(closestCubeCoordinates);
                    // Remove the closest CubeCoordinates to the unvisited set
                    unvisitedCubeCoordinatesSet.Remove(closestCubeCoordinates);
                    // Iterate over the closest CubeCoordinates's Neighbors
                    foreach (ICubeCoordinates neighborCubeCoordinates in closestCubeCoordinatesNeighborSet)
                    {
                        // Check that the CubeCoordinates is a possible end
                        if (this.cubeCoordinatesPaths.ContainsKey(neighborCubeCoordinates))
                        {
                            // Check if the neighbor CubeCoordinates has not been visited yet
                            if (!visitedCubeCoordinatesSet.Contains(neighborCubeCoordinates))
                            {
                                // Add the neighbor CubeCoordinates to the unvisited set
                                unvisitedCubeCoordinatesSet.Add(neighborCubeCoordinates);
                            }
                            // Collect the Path for the neighbor CubeCoordinates
                            IPath oldNeighborPath = this.cubeCoordinatesPaths[neighborCubeCoordinates];
                            // Collect the Path for the closest CubeCoordinates
                            IPath closestPath = this.cubeCoordinatesPaths[closestCubeCoordinates];
                            // Collect the List: CubeCoordinates from the Closest Path
                            IList<ICubeCoordinates> closestPathCubeCoordinatesStepList = closestPath.GetCubeCoordinatesList();
                            // Add the neighbor CubeCoordiantes
                            closestPathCubeCoordinatesStepList.Add(neighborCubeCoordinates);
                            // Build the new Path using the Closest Path and the neighbor CubeCoordinates
                            IPath newNeighborPath = new MovePath(closestPathCubeCoordinatesStepList, this.mapReport);
                            if ((oldNeighborPath == null ||
                                oldNeighborPath.GetPathCost() > newNeighborPath.GetPathCost()) &&
                                newNeighborPath.GetPathCost() < _MPs)
                            {
                                this.cubeCoordinatesPaths[neighborCubeCoordinates] = newNeighborPath;
                            }
                        }
                    }
                }
                else
                {
                    // End the iteration
                    _logger.Debug("Unable to get the closest CubeCoordinates in {}",
                        string.Join(", ", unvisitedCubeCoordinatesSet));
                    break;
                }
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates"></param>
        /// <returns></returns>
        private ICubeCoordinates GetClosestCubeCoordinate(ISet<ICubeCoordinates> cubeCoordinates)
        {
            // Default the CubeCoordinates to null
            ICubeCoordinates closestCubeCoordinate = null;
            // Default the minimum distance to the MaxValue
            float minimumDistance = float.MaxValue;
            // Iterate over the Set: CubeCoordiantes
            foreach (ICubeCoordinates coordinates in cubeCoordinates)
            {
                // Check if the Path IDictionary contains the CubeCoordinates
                if (this.cubeCoordinatesPaths.ContainsKey(coordinates))
                {
                    // Collect the Path
                    IPath path = this.cubeCoordinatesPaths[coordinates];
                    // Check if the
                    if (path != null &&
                        path.GetPathCost() < minimumDistance)
                    {
                        minimumDistance = path.GetPathCost();
                        closestCubeCoordinate = coordinates;
                    }
                }
            }
            // Return the CubeCoordinates
            return closestCubeCoordinate;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private ICubeCoordinates _cubeCoordinates = null;

            // Todo
            private IMapReport _mapReport = null;

            // Todo
            private float _MPs = float.MinValue;

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
                    return new MovePathFinder(_cubeCoordinates, _MPs, _mapReport);
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
                _cubeCoordinates = cubeCoordinates;
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
            /// <param name="movement"></param>
            /// <returns></returns>
            public Builder SetMPs(float movement)
            {
                _MPs = movement;
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
                if (_cubeCoordinates == null)
                {
                    argumentExceptionSet.Add("Starting " + typeof(ICubeCoordinates) + " cannot be null.");
                }
                // Check that pathCostThreshold has been set
                if (_MPs == float.MinValue)
                {
                    argumentExceptionSet.Add("pathCostThreshold cannot be null.");
                }
                return argumentExceptionSet;
            }
        }
    }
}