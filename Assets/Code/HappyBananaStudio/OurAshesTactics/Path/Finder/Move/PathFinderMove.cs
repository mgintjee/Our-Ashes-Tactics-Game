/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Coordinates;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.HexTile;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Paths.Object;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Loggers;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Managers;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Path.Finder.Abs;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Path.Objects.Move;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Path.Finder.Move
{
    // TODO: BROKEN
    /// <summary>
    /// Todo
    /// </summary>
    public class PathFinderMove
    : PathFinderAbstract
    {
        // Provide logging capability
        private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly int pathCostThreshold = int.MaxValue;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="tileCoordinatesStart">
        /// </param>
        /// <param name="pathCostThreshold">
        /// </param>
        public PathFinderMove(ICubeCoordinates tileCoordinatesStart, int pathCostThreshold)
            : base(tileCoordinatesStart)
        {
            this.pathCostThreshold = pathCostThreshold;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public override void BeginPathFinding()
        {
            this.GatherAllTileCoordinatesEnds();
            this.DijkstraAlgorithm();
            this.CleanUpPathObjectDictionary();
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void CleanUpPathObjectDictionary()
        {
            // Todo: Store in some other method Remove all that are too expensive?
            HashSet<ICubeCoordinates> invalidPathObjectSet = new HashSet<ICubeCoordinates>();
            foreach (ICubeCoordinates cubeCoordinates in this.pathObjectDictionary.Keys)
            {
                IPathObject pathObject = this.pathObjectDictionary[cubeCoordinates];
                if (pathObject == null ||
                    !pathObject.IsValid())
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
            HashSet<ICubeCoordinates> visitedCubeCoordinatesSet = new HashSet<ICubeCoordinates>();
            HashSet<ICubeCoordinates> unvisitedCubeCoordinatesSet = new HashSet<ICubeCoordinates> { this.cubeCoordinatesStart };
            this.pathObjectDictionary[this.cubeCoordinatesStart] = new PathObjectMove(new List<ICubeCoordinates>()
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
                    HashSet<ICubeCoordinates> closestCubeCoordinatesNeighborSet = GameMapObjectManager
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
                            IHexTileObject neighborHexTileObject = GameMapObjectManager.FindHexTileObjectFrom(neighborCubeCoordinates);
                            // Check that the HexTileObject is non-null
                            if (neighborHexTileObject != null)
                            {
                                // Collect the PathObject for the neighbor CubeCoordinates
                                IPathObject oldNeighborPathObject = this.pathObjectDictionary[neighborCubeCoordinates];
                                // Collect the PathObject for the closest CubeCoordinates
                                IPathObject closestPathObject = this.pathObjectDictionary[closestCubeCoordinates];
                                // Collect the List: CubeCoordinates from the Closest PathObject
                                List<ICubeCoordinates> closestPathObjectCubeCoordinatesStepList = closestPathObject.GetCubeCoordinatesStepList();
                                // Add the neighbor CubeCoordiantes
                                closestPathObjectCubeCoordinatesStepList.Add(neighborCubeCoordinates);
                                // Build the new PathObject using the Closest List: CubeCoordinates
                                // + neighbor CubeCoordinates
                                IPathObject newNeighborPathObject = new PathObjectMove(closestPathObjectCubeCoordinatesStepList);
                                if (oldNeighborPathObject == null ||
                                    oldNeighborPathObject.GetPathObjectCost() > newNeighborPathObject.GetPathObjectCost())
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
                    break;
                }
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void GatherAllTileCoordinatesEnds()
        {
            this.pathObjectDictionary = new Dictionary<ICubeCoordinates, IPathObject>();
            foreach (ICubeCoordinates cubeCoordinates in GameMapObjectManager.GetAllCubeCoordinatesSet())
            {
                IHexTileObject tileObject = GameMapObjectManager.FindHexTileObjectFrom(cubeCoordinates);
                if (tileObject.GetHexTileInformationReport().GetTalonIdentificationReport() == null)
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
        private ICubeCoordinates GetMinimumDistanceCoordinate(HashSet<ICubeCoordinates> cubeCoordinatesSet)
        {
            // Default the CubeCoordinates to null
            ICubeCoordinates minimumDistanceCubeCoordinate = null;
            // Default the minimum distance to the MaxValue
            int minimumDistance = int.MaxValue;
            // Iterate over the Set: CubeCoordiantes
            foreach (ICubeCoordinates cubeCoordinates in cubeCoordinatesSet)
            {
                // Check if the PathObject Dictionary contains the CubeCoordinates
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