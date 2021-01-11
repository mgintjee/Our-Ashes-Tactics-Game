namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Pathing.Finders.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Loggers.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Loggers.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Coordinates.Cube.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.GameBoards.Managers;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.HexTiles.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Pathing.Finders.Abs;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Pathing.Finders.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Pathing.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Pathing.Objects.Impl;
    using HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Todo
    /// </summary>
    public class PathFinderMoveImpl
        : PathFinderAbstract
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLoggerImpl(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly float pathCostThreshold;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="tileCoordinatesStart">
        /// </param>
        /// <param name="pathCostThreshold">
        /// </param>
        private PathFinderMoveImpl(ICubeCoordinates tileCoordinatesStart, float pathCostThreshold)
            : base(tileCoordinatesStart)
        {
            this.pathCostThreshold = pathCostThreshold;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public override void BeginPathFinding()
        {
            this.GatherAllCubeCoordinatesEnds();
            this.DijkstraAlgorithm();
            this.CleanUpPathObjectDictionary();
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void CleanUpPathObjectDictionary()
        {
            // Todo: Store in some other method Remove all that are too expensive?
            ISet<ICubeCoordinates> invalidPathObjectSet = new HashSet<ICubeCoordinates>();
            int initialCount = this.pathObjectDictionary.Count;
            foreach (ICubeCoordinates cubeCoordinates in this.pathObjectDictionary.Keys)
            {
                IPathObject pathObject = this.pathObjectDictionary[cubeCoordinates];
                if (pathObject == null || !pathObject.IsValid())
                {
                    invalidPathObjectSet.Add(cubeCoordinates);
                }
            }

            foreach (ICubeCoordinates cubeCoordinates in invalidPathObjectSet)
            {
                this.pathObjectDictionary.Remove(cubeCoordinates);
            }

            this.pathObjectDictionary.Remove(this.cubeCoordinatesStart);
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void DijkstraAlgorithm()
        {
            ISet<ICubeCoordinates> visitedCubeCoordinatesSet = new HashSet<ICubeCoordinates>();
            ISet<ICubeCoordinates> unvisitedCubeCoordinatesSet = new HashSet<ICubeCoordinates> { this.cubeCoordinatesStart };
            this.pathObjectDictionary[this.cubeCoordinatesStart] = new PathObjectMoveImpl(new List<ICubeCoordinates>()
            { this.cubeCoordinatesStart });
            // Continue iterating until all CubeCoordinates have been visited
            while (unvisitedCubeCoordinatesSet.Count > 0)
            {
                // Collect the closest CubeCoordinates from the unvisited set
                ICubeCoordinates closestCubeCoordinates = this.GetMinimumDistanceCoordinate(unvisitedCubeCoordinatesSet);
                // Check if the closest CubeCoordinates is non-null
                if (closestCubeCoordinates != null)
                {
                    // Collect the neighbors of the closest CubeCoordinates
                    ISet<ICubeCoordinates> closestCubeCoordinatesNeighborSet = GameBoardObjectManager
                        .GetNeighborCubeCoordinates(closestCubeCoordinates);
                    // Add the closest CubeCoordinates to the visited set
                    visitedCubeCoordinatesSet.Add(closestCubeCoordinates);
                    // Remove the closest CubeCoordinates to the unvisited set
                    unvisitedCubeCoordinatesSet.Remove(closestCubeCoordinates);
                    // Iterate over the closest CubeCoordinates's Neighbor Set: CubeCoordinates
                    foreach (ICubeCoordinates neighborCubeCoordinates in closestCubeCoordinatesNeighborSet)
                    {
                        // Check that the CubeCoordinates is a possible end
                        if (this.pathObjectDictionary.ContainsKey(neighborCubeCoordinates))
                        {
                            // Check if the neighbor CubeCoordinates has not been visited yet
                            if (!visitedCubeCoordinatesSet.Contains(neighborCubeCoordinates))
                            {
                                // Add the neighbor CubeCoordinates to the unvisited set
                                unvisitedCubeCoordinatesSet.Add(neighborCubeCoordinates);
                            }
                            // Collect the neighbor HexTileObject
                            IHexTileObject neighborHexTileObject = GameBoardObjectManager
                                .GetHexTileObjectFrom(neighborCubeCoordinates);
                            // Check that the HexTileObject is non-null
                            if (neighborHexTileObject != null)
                            {
                                // Collect the PathObject for the neighbor CubeCoordinates
                                IPathObject oldNeighborPathObject = this.pathObjectDictionary[neighborCubeCoordinates];
                                // Collect the PathObject for the closest CubeCoordinates
                                IPathObject closestPathObject = this.pathObjectDictionary[closestCubeCoordinates];
                                // Collect the List: CubeCoordinates from the Closest PathObject
                                IList<ICubeCoordinates> closestPathObjectCubeCoordinatesStepList = closestPathObject.GetCubeCoordinatesStepList();
                                // Add the neighbor CubeCoordiantes
                                closestPathObjectCubeCoordinatesStepList.Add(neighborCubeCoordinates);
                                // Build the new PathObject using the Closest List: CubeCoordinates
                                // + neighbor CubeCoordinates
                                IPathObject newNeighborPathObject = new PathObjectMoveImpl(closestPathObjectCubeCoordinatesStepList);
                                if ((oldNeighborPathObject == null ||
                                    oldNeighborPathObject.GetPathObjectCost() > newNeighborPathObject.GetPathObjectCost()) &&
                                    newNeighborPathObject.GetPathObjectCost() < this.pathCostThreshold)
                                {
                                    this.pathObjectDictionary[neighborCubeCoordinates] = newNeighborPathObject;
                                }
                            }
                        }
                    }
                }
                else
                {
                    // End the iteration
                    logger.Debug("Unable to get the closest CubeCoordinates in ?",
                        string.Join(", ", unvisitedCubeCoordinatesSet));
                    break;
                }
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void GatherAllCubeCoordinatesEnds()
        {
            this.pathObjectDictionary = new Dictionary<ICubeCoordinates, IPathObject>();
            foreach (ICubeCoordinates cubeCoordinates in GameBoardObjectManager.GetAllCubeCoordinatesSet())
            {
                IHexTileObject tileObject = GameBoardObjectManager.GetHexTileObjectFrom(cubeCoordinates);
                if (tileObject.GetHexTileReport().GetTalonCallSign().Equals(TalonCallSign.None) ||
                    cubeCoordinates == this.cubeCoordinatesStart)
                {
                    this.pathObjectDictionary.Add(cubeCoordinates, null);
                }
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinatesSet">
        /// </param>
        /// <returns>
        /// </returns>
        private ICubeCoordinates GetMinimumDistanceCoordinate(ISet<ICubeCoordinates> cubeCoordinatesSet)
        {
            // Default the CubeCoordinates to null
            ICubeCoordinates minimumDistanceCubeCoordinate = null;
            // Default the minimum distance to the MaxValue
            float minimumDistance = float.MaxValue;
            // Iterate over the Set: CubeCoordiantes
            foreach (ICubeCoordinates cubeCoordinates in cubeCoordinatesSet)
            {
                // Check if the PathObject IDictionary contains the CubeCoordinates
                if (this.pathObjectDictionary.ContainsKey(cubeCoordinates))
                {
                    // Collect the PathObject
                    IPathObject pathObject = this.pathObjectDictionary[cubeCoordinates];
                    // Check if the
                    if (pathObject != null &&
                        pathObject.GetPathObjectCost() < minimumDistance)
                    {
                        minimumDistance = pathObject.GetPathObjectCost();
                        minimumDistanceCubeCoordinate = cubeCoordinates;
                    }
                }
            }
            // Return the CubeCoordinates
            return minimumDistanceCubeCoordinate;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private ICubeCoordinates startingCubeCoordinates = null;

            // Todo
            private float pathCostThreshold = float.MinValue;

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
                    return new PathFinderMoveImpl(this.startingCubeCoordinates, this.pathCostThreshold);
                }
                else
                {
                    throw ExceptionUtil.Argument.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="startingCubeCoordinates"></param>
            /// <returns></returns>
            public Builder SetStartingCubeCoordinates(ICubeCoordinates startingCubeCoordinates)
            {
                this.startingCubeCoordinates = startingCubeCoordinates;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="pathCostThreshold"></param>
            /// <returns></returns>
            public Builder SetPathCostThreshold(float pathCostThreshold)
            {
                this.pathCostThreshold = pathCostThreshold;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            private ISet<string> IsInvalid()
            {
                // Default an empty Set: String
                ISet<string> argumentExceptionSet = new HashSet<string>();
                // Check that startingCubeCoordinates has been set
                if (this.startingCubeCoordinates == null)
                {
                    argumentExceptionSet.Add("Starting " + typeof(ICubeCoordinates) + " has not been set");
                }
                // Check that pathCostThreshold has been set
                if (this.pathCostThreshold == float.MinValue)
                {
                    argumentExceptionSet.Add("pathCostThreshold has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}