using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Implementaions.Moves;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Maps.PathFinders.Implementaions.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Maps.PathFinders.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Maps.Interfaces;
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
        private readonly ILogger _logger = LoggerManager.GetLogger(MvcType.Sortie, new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly float _movements;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates"></param>
        /// <param name="movements">      </param>
        /// <param name="mapReport">      </param>
        private MovePathFinder(ICubeCoordinates cubeCoordinates, float movements, ISortieMapReport mapReport)
        {
            _cubeCoordinates = cubeCoordinates;
            _mapReport = mapReport;
            _movements = movements;
            PathFind();
        }

        /// <summary>
        /// Todo
        /// </summary>
        protected override void PathFind()
        {
            _logger.Debug("PathFind @ {} for movements={}", _cubeCoordinates, _movements);
            DijkstraAlgorithm();
            CleanUpCubeCoordinatesPaths();
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void CleanUpCubeCoordinatesPaths()
        {
            ISet<ICubeCoordinates> invalidCubeCoordinates = new HashSet<ICubeCoordinates>();
            foreach (ICubeCoordinates cubeCoordinates in _cubeCoordinatesPaths.Keys)
            {
                ISortieMapPath path = _cubeCoordinatesPaths[cubeCoordinates];
                if (path == null || !path.IsValid() || path.GetPathCost() > _movements)
                {
                    invalidCubeCoordinates.Add(cubeCoordinates);
                }
            }

            foreach (ICubeCoordinates cubeCoordinates in invalidCubeCoordinates)
            {
                _cubeCoordinatesPaths.Remove(cubeCoordinates);
            }

            _cubeCoordinatesPaths.Remove(_cubeCoordinates);
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void DijkstraAlgorithm()
        {
            // Default an empty set
            ISet<ICubeCoordinates> visitedCubeCoordinatesSet = new HashSet<ICubeCoordinates>();
            // Default the unvisited set with the starting cubeCoordinates
            ISet<ICubeCoordinates> unvisitedCubeCoordinatesSet = new HashSet<ICubeCoordinates> { _cubeCoordinates };
            _cubeCoordinatesPaths[_cubeCoordinates] = new SortieMapMovePath(
                new List<ICubeCoordinates>() { _cubeCoordinates }, _mapReport);
            // Continue iterating until all CubeCoordinates have been visited
            while (unvisitedCubeCoordinatesSet.Count > 0)
            {
                // Collect the closest CubeCoordinates from the unvisited set
                ICubeCoordinates closestCubeCoordinates = GetClosestCubeCoordinate(unvisitedCubeCoordinatesSet);
                // Check if the closest CubeCoordinates is non-null
                if (closestCubeCoordinates != null)
                {
                    // Collect the neighbors of the closest CubeCoordinates
                    ISet<ICubeCoordinates> closestCubeCoordinatesNeighborSet = closestCubeCoordinates.GetNeighbors();
                    // Remove all that are not tracked in the mapReport
                    closestCubeCoordinatesNeighborSet.IntersectWith(_mapReport.GetCubeCoordinates());
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
                        ISortieMapPath closestPath = _cubeCoordinatesPaths[closestCubeCoordinates];
                        // Collect the List: CubeCoordinates from the Closest Path
                        IList<ICubeCoordinates> closestPathCubeCoordinatesStepList = closestPath.GetCubeCoordinatesList();
                        // Add the neighbor CubeCoordiantes
                        closestPathCubeCoordinatesStepList.Add(neighborCubeCoordinates);
                        // Build the new Path using the Closest Path and the neighbor CubeCoordinates
                        ISortieMapPath newNeighborPath = new SortieMapMovePath(closestPathCubeCoordinatesStepList, _mapReport);
                        if (_cubeCoordinatesPaths.ContainsKey(neighborCubeCoordinates))
                        {
                            // Collect the Path for the neighbor CubeCoordinates
                            ISortieMapPath oldNeighborPath = _cubeCoordinatesPaths[neighborCubeCoordinates];
                            // Check that the oldNeighborPath is non-null and is further than the newNeighborPath
                            if ((oldNeighborPath == null || oldNeighborPath.GetPathCost() > newNeighborPath.GetPathCost()) &&
                                newNeighborPath.GetPathCost() < _movements)
                            {
                                // Set the neighbor's new path
                                _cubeCoordinatesPaths[neighborCubeCoordinates] = newNeighborPath;
                            }
                        }
                        else
                        {
                            // Set the neighbor's new path
                            _cubeCoordinatesPaths[neighborCubeCoordinates] = newNeighborPath;
                        }
                    }
                }
                else
                {
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
                if (_cubeCoordinatesPaths.ContainsKey(coordinates))
                {
                    // Collect the Path
                    ISortieMapPath path = _cubeCoordinatesPaths[coordinates];
                    // Check if the path is non-null and closest
                    if (path != null && path.GetPathCost() < minimumDistance && path.GetPathCost() <= _movements)
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
            private ISortieMapReport _mapReport = null;

            // Todo
            private float _movements = float.MinValue;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IPathFinder Build()
            {
                ISet<string> invalidReasons = IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Object
                    return new MovePathFinder(_cubeCoordinates, _movements, _mapReport);
                }
                throw ExceptionUtil.Arguments.Build("Unable to construct {}. Invalid Parameters. {}",
                    GetType(), string.Join("\n", invalidReasons));
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
            public Builder SetMapReport(ISortieMapReport mapReport)
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
                _movements = movements;
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
                // Check that _movements has been set
                if (_movements == float.MinValue)
                {
                    argumentExceptionSet.Add("_movements cannot be float.MinValue.");
                }
                // Check that _mapReport has been set
                if (_mapReport == null)
                {
                    argumentExceptionSet.Add(typeof(ISortieMapReport).Name + " cannot be null.");
                }
                return argumentExceptionSet;
            }
        }
    }
}