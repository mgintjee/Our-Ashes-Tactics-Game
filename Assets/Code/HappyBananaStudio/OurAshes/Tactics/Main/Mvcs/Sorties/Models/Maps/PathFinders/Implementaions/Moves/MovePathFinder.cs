using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Maps.Coordinates.Cube.Interfaces;
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
        // Provides logging capability to the SORTIE logs
        private static readonly ILogger _logger = LoggerManager.GetSortieLogger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly float _movements;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates"></param>
        /// <param name="movements">       </param>
        /// <param name="mapReport">      </param>
        private MovePathFinder(ICubeCoordinates cubeCoordinates, float movements, IMapReport mapReport)
        {
            this._cubeCoordinates = cubeCoordinates;
            this._mapReport = mapReport;
            _movements = movements;
            this.PathFind();
        }

        /// <summary>
        /// Todo
        /// </summary>
        protected override void PathFind()
        {
            _logger.Debug("PathFind @ {} for movements={}", this._cubeCoordinates, _movements);
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
                if (path == null || !path.IsValid())
                {
                    _logger.Info(" {} has invalid {}", cubeCoordinates, path);
                    invalidCubeCoordinates.Add(cubeCoordinates);
                }
            }

            foreach (ICubeCoordinates cubeCoordinates in invalidCubeCoordinates)
            {
                this.cubeCoordinatesPaths.Remove(cubeCoordinates);
            }

            this.cubeCoordinatesPaths.Remove(this._cubeCoordinates);
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void CollectCubeCoordinatesPaths()
        {
            foreach (ICubeCoordinates cubeCoordinates in this._mapReport.GetCubeCoordinates())
            {
                this._mapReport.GetTileReport(cubeCoordinates).IfPresent((tileReport) =>
                {
                    if (tileReport.GetCombatantCallSign() == CombatantCallSign.None ||
                        cubeCoordinates != this._cubeCoordinates)
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
            _logger.Info("Dijsktra on {}", _mapReport);
            // Default an empty set
            ISet<ICubeCoordinates> visitedCubeCoordinatesSet = new HashSet<ICubeCoordinates>();
            // Default the unvisited set with the starting cubeCoordinates
            ISet<ICubeCoordinates> unvisitedCubeCoordinatesSet = new HashSet<ICubeCoordinates> { this._cubeCoordinates };
            this.cubeCoordinatesPaths[this._cubeCoordinates] = new MovePath(
                new List<ICubeCoordinates>() { this._cubeCoordinates }, this._mapReport);
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
                    closestCubeCoordinatesNeighborSet.IntersectWith(this._mapReport.GetCubeCoordinates());
                    // Add the closest CubeCoordinates to the visited set
                    visitedCubeCoordinatesSet.Add(closestCubeCoordinates);
                    // Remove the closest CubeCoordinates to the unvisited set
                    unvisitedCubeCoordinatesSet.Remove(closestCubeCoordinates);
                    // Iterate over the closest CubeCoordinates's Neighbors
                    foreach (ICubeCoordinates neighborCubeCoordinates in closestCubeCoordinatesNeighborSet)
                    {
                        // Check if the neighbor CubeCoordinates has not been visited yet
                        if (!visitedCubeCoordinatesSet.Contains(neighborCubeCoordinates))
                        {
                            // Add the neighbor CubeCoordinates to the unvisited set
                            unvisitedCubeCoordinatesSet.Add(neighborCubeCoordinates);
                        }
                        // Collect the Path for the closest CubeCoordinates
                        IPath closestPath = this.cubeCoordinatesPaths[closestCubeCoordinates];
                        // Collect the List: CubeCoordinates from the Closest Path
                        IList<ICubeCoordinates> closestPathCubeCoordinatesStepList = closestPath.GetCubeCoordinatesList();
                        // Add the neighbor CubeCoordiantes
                        closestPathCubeCoordinatesStepList.Add(neighborCubeCoordinates);
                        // Build the new Path using the Closest Path and the neighbor CubeCoordinates
                        IPath newNeighborPath = new MovePath(closestPathCubeCoordinatesStepList, this._mapReport);
                        if (this.cubeCoordinatesPaths.ContainsKey(neighborCubeCoordinates))
                        {
                            // Collect the Path for the neighbor CubeCoordinates
                            IPath oldNeighborPath = this.cubeCoordinatesPaths[neighborCubeCoordinates];
                            // Check that the oldNeighborPath is non-null and is further than the newNeighborPath
                            if ((oldNeighborPath == null || oldNeighborPath.GetPathCost() > newNeighborPath.GetPathCost()) &&
                                newNeighborPath.GetPathCost() < _movements)
                            {
                                // Set the neighbor's new path
                                this.cubeCoordinatesPaths[neighborCubeCoordinates] = newNeighborPath;
                            }
                        }
                        else
                        {
                            // Set the neighbor's new path
                            this.cubeCoordinatesPaths[neighborCubeCoordinates] = newNeighborPath;
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
                    // Check if the path is non-null and closest
                    if (path != null && path.GetPathCost() < minimumDistance)
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
            private float _movements = float.MinValue;

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
                    return new MovePathFinder(_cubeCoordinates, _movements, _mapReport);
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
            /// <param name="movements"></param>
            /// <returns></returns>
            public Builder SetMovements(float movements)
            {
                this._movements = movements;
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
                // Check that _cubeCoordinates has been set
                if (_cubeCoordinates == null)
                {
                    argumentExceptionSet.Add("Starting " + typeof(ICubeCoordinates).Name + " cannot be null.");
                }
                // Check that _MPs has been set
                if (_movements == float.MinValue)
                {
                    argumentExceptionSet.Add("pathCostThreshold cannot be null.");
                }
                // Check that _mapReport has been set
                if (_mapReport == null)
                {
                    argumentExceptionSet.Add(typeof(IMapReport).Name + " cannot be null.");
                }
                return argumentExceptionSet;
            }
        }
    }
}