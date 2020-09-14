/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Common.Logging;
using HappyBananaStudio.OurAshesTactics.Mvc.Coordinates.Cube;
using HappyBananaStudio.OurAshesTactics.Mvc.Coordinates.Util;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Util;
using HappyBananaStudio.OurAshesTactics.Pathing.Object.Api;
using HappyBananaStudio.OurAshesTactics.Pathing.Object.Impl;
using System.Collections.Generic;
using System.Diagnostics;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Pathing.Finder.Impl
{
    /// <summary>
    /// Todo
    /// </summary>
    public class PathFinderMove
    : PathFinderAbstract
    {
        #region Private Fields

        // Provide logging capability
        private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly int pathCostThreshold = int.MaxValue;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="tileCoordinatesStart"></param>
        /// <param name="pathCostThreshold">   </param>
        public PathFinderMove(CubeCoordinates tileCoordinatesStart, int pathCostThreshold)
            : base(tileCoordinatesStart)
        {
            this.pathCostThreshold = pathCostThreshold;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        public override void BeginPathFinding()
        {
            this.GatherAllTileCoordinatesEnds();
            this.GatherAllPathObjects();
            this.CleanUpPathObjectDictionary();
        }

        /// <summary>
        /// Path finder move method, to determine which tile is the closest
        /// </summary>
        /// <param name="unvisitedCubeCoordinatesSet">
        /// The set of tiles to iterate over to find the closest tile
        /// </param>
        /// <returns>The closest tile in the unvisitedTileSet</returns>
        public CubeCoordinates GetClosestTileCoordinates(HashSet<CubeCoordinates> unvisitedCubeCoordinatesSet)
        {
            // Default a null TileScript
            CubeCoordinates closestCubeCoordinates = null;
            int smallestPathObjectCost = int.MaxValue;

            foreach (CubeCoordinates cubeCoordinates in unvisitedCubeCoordinatesSet)
            {
                bool cubeCoordinatesIsValidEnd = this.pathObjectDictionary.ContainsKey(cubeCoordinates);
                bool cubeCoordinatesPathIsValid = this.pathObjectDictionary[cubeCoordinates].IsValid();
                bool cubeCoordinatesPathIsShorter = this.pathObjectDictionary[cubeCoordinates].GetPathObjectCost() <= smallestPathObjectCost &&
                    this.pathObjectDictionary[cubeCoordinates].GetPathObjectCost() <= this.pathCostThreshold;
                if (cubeCoordinatesIsValidEnd &&
                    cubeCoordinatesPathIsValid &&
                    cubeCoordinatesPathIsShorter)
                {
                    smallestPathObjectCost = this.pathObjectDictionary[cubeCoordinates].GetPathObjectCost();
                    closestCubeCoordinates = cubeCoordinates;
                }
            }

            return closestCubeCoordinates;
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Todo
        /// </summary>
        private void CleanUpPathObjectDictionary()
        {
            // Todo: Store in some other method Remove all that are too expensive?
            HashSet<CubeCoordinates> invalidPathObjectSet = new HashSet<CubeCoordinates>();
            foreach (CubeCoordinates cubeCoordinates in this.pathObjectDictionary.Keys)
            {
                if (!this.pathObjectDictionary[cubeCoordinates].IsValid())
                {
                    invalidPathObjectSet.Add(cubeCoordinates);
                }
            }

            foreach (CubeCoordinates cubeCoordinates in invalidPathObjectSet)
            {
                this.pathObjectDictionary.Remove(cubeCoordinates);
            }
            this.pathObjectDictionary.Remove(this.cubeCoordinatesStart);
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void GatherAllPathObjects()
        {
            HashSet<CubeCoordinates> visitedCubeCoordinatesSet = new HashSet<CubeCoordinates>();
            HashSet<CubeCoordinates> unvisitedCubeCoordinatesSet = new HashSet<CubeCoordinates> { this.cubeCoordinatesStart };
            this.pathObjectDictionary[this.cubeCoordinatesStart] = new PathObjectMove(new List<CubeCoordinates>() { this.cubeCoordinatesStart });

            while (unvisitedCubeCoordinatesSet.Count > 0)
            {
                // Collect the closestTileCoordinates to the tileCoordinatesStart
                CubeCoordinates closestCubeCoordinates = this.GetClosestTileCoordinates(unvisitedCubeCoordinatesSet);
                // Check if the Selected TileCoordinates is null and there are remaining
                // TileCoordinates to visit
                if (closestCubeCoordinates != null ||
                    unvisitedCubeCoordinatesSet.Count <= 0)
                {
                    // Collect the neighbors of the closestTileCoordinates
                    HashSet<CubeCoordinates> closestCubeCoordinatesNeighborSet = HexTileObjectFinderUtil.GetNeighborCubeCoordinates(closestCubeCoordinates);
                    // Add the closestTileCoordinates to the vistied Set: TileCoordinates
                    visitedCubeCoordinatesSet.Add(closestCubeCoordinates);
                    // Remove the closestTileCoordinates to the unvistied Set: TileCoordinates
                    unvisitedCubeCoordinatesSet.Remove(closestCubeCoordinates);
                    // Iterate over the TileClosest's Neigbor Set: TileScript
                    foreach (CubeCoordinates neighborCubeCoordinates in closestCubeCoordinatesNeighborSet)
                    {
                        IPathObject neighborPathObject = this.PathFindForNeighbor(
                            closestCubeCoordinates, neighborCubeCoordinates, visitedCubeCoordinatesSet, unvisitedCubeCoordinatesSet);
                        if (neighborPathObject != null)
                        {
                            this.pathObjectDictionary[neighborCubeCoordinates] = neighborPathObject;
                        }
                    }
                }
                else
                {
                    // Unable to continue pathFinding. No available unvisited CubeCoordinates
                    break;
                }
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void GatherAllTileCoordinatesEnds()
        {
            this.pathObjectDictionary = new Dictionary<CubeCoordinates, IPathObject>();
            foreach (CubeCoordinates cubeCoordinates in HexTileObjectFinderUtil.GetTileCoordinatesSet())
            {
                IHexTileObject tileObject = HexTileObjectFinderUtil.FindHexTileObjectFrom(cubeCoordinates);
                if (tileObject.GetHexTileInformationReport().GetTalonIdentificationReport() == null)
                {
                    int pathObjectLength = CubeCoordinatesCommonUtil.GetCubeCoordinatesDistanceFrom(this.cubeCoordinatesStart, cubeCoordinates);
                    PathObjectMove pathMove = new PathObjectMove(this.cubeCoordinatesStart, cubeCoordinates, pathObjectLength);
                    this.pathObjectDictionary.Add(cubeCoordinates, pathMove);
                }
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="currentCubeCoordinates">     </param>
        /// <param name="neighborCubeCoordinates">    </param>
        /// <param name="visitedCubeCoordinatesSet">  </param>
        /// <param name="unvisitedCubeCoordinatesSet"></param>
        /// <returns></returns>
        private IPathObject PathFindForNeighbor(CubeCoordinates currentCubeCoordinates, CubeCoordinates neighborCubeCoordinates,
            HashSet<CubeCoordinates> visitedCubeCoordinatesSet, HashSet<CubeCoordinates> unvisitedCubeCoordinatesSet)
        {
            IPathObject oldNeighborPathObject = null;
            IHexTileObject neighborTileObject = HexTileObjectFinderUtil.FindHexTileObjectFrom(neighborCubeCoordinates);
            if (neighborTileObject != null &&
                this.pathObjectDictionary.ContainsKey(neighborCubeCoordinates))
            {
                // Check if the Dictionary contains this neighbor or if the TileNeighbor contains a object
                if (neighborTileObject.GetHexTileInformationReport().GetTalonIdentificationReport() == null &&
                    !visitedCubeCoordinatesSet.Contains(neighborCubeCoordinates))
                {
                    oldNeighborPathObject = this.pathObjectDictionary[neighborCubeCoordinates];
                    // Check if the visited Set: TileScript does not contain the TileNeighbor
                    if (!visitedCubeCoordinatesSet.Contains(neighborCubeCoordinates))
                    {
                        // Add the TileNeighbor to the unvisited Set: TileScript
                        unvisitedCubeCoordinatesSet.Add(neighborCubeCoordinates);
                    }

                    IPathObject currentPathObject = this.pathObjectDictionary[currentCubeCoordinates];
                    List<CubeCoordinates> currentPathObjectCubeCoordaintesStepList = currentPathObject.GetCubeCoordinatesStepList();
                    currentPathObjectCubeCoordaintesStepList.Add(neighborCubeCoordinates);
                    IPathObject newNeighborPathObject = new PathObjectMove(currentPathObjectCubeCoordaintesStepList);

                    if (!oldNeighborPathObject.IsValid() ||
                        oldNeighborPathObject.GetPathObjectCost() > newNeighborPathObject.GetPathObjectCost())
                    {
                        return newNeighborPathObject;
                    }
                }
            }
            return oldNeighborPathObject;
        }

        #endregion Private Methods
    }
}