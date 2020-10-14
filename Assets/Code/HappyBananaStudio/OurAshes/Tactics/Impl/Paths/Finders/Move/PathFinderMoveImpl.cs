/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>

namespace HappyBananaStudio.OurAshesTactics.Impl.Objects.Paths.Finders.Move
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Coordinates.Objects.Cube;
    using HappyBananaStudio.OurAshes.Tactics.Api.HexTiles.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.Loggers;
    using HappyBananaStudio.OurAshes.Tactics.Api.Paths.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Common.Managers.CodeObjects;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Loggers;
    using HappyBananaStudio.OurAshesTactics.Impl.Objects.Paths.Finders.Abs;
    using HappyBananaStudio.OurAshesTactics.Impl.Objects.Paths.Objects.Move;
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

        private readonly int pathCostThreshold;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="tileCoordinatesStart">
        /// </param>
        /// <param name="pathCostThreshold">
        /// </param>
        public PathFinderMoveImpl(ICubeCoordinates tileCoordinatesStart, int pathCostThreshold)
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
            this.CleanUpPathObjectIDictionary();
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void CleanUpPathObjectIDictionary()
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
            logger.Debug("?/? Valid CubeCoordiantes", this.pathObjectDictionary.Count,
                initialCount);
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
            logger.Info("MaxDistance = ?", this.pathCostThreshold);
            // Continue iterating until all CubeCoordinates have been visited
            while (unvisitedCubeCoordinatesSet.Count > 0)
            {
                // Collect the closest CubeCoordinates from the unvisited set
                ICubeCoordinates closestCubeCoordinates = this.GetMinimumDistanceCoordinate(unvisitedCubeCoordinatesSet);
                // Check if the closest CubeCoordinates is non-null
                if (closestCubeCoordinates != null)
                {
                    // Collect the neighbors of the closest CubeCoordinates
                    ISet<ICubeCoordinates> closestCubeCoordinatesNeighborSet = GameMapObjectManager
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
                            IHexTileObject neighborHexTileObject = GameMapObjectManager.GetHexTileObjectFrom(neighborCubeCoordinates);
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
            foreach (ICubeCoordinates cubeCoordinates in GameMapObjectManager.GetAllCubeCoordinatesSet())
            {
                IHexTileObject tileObject = GameMapObjectManager.GetHexTileObjectFrom(cubeCoordinates);
                if (tileObject.GetHexTileInformationReport().GetTalonIdentificationReport() == null ||
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
            int minimumDistance = int.MaxValue;
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
    }
}
