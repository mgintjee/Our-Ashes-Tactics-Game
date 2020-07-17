using System.Collections.Generic;
using System.Diagnostics;

/// <summary>
/// Todo
/// </summary>
public class PathFinderMove
    : PathFinderAbstract
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    private int pathCostThreshold = int.MaxValue;

    #endregion Private Fields

    #region Public Constructors

    public PathFinderMove(CubeCoordinates tileCoordinatesStart, int pathCostThreshold)
        : base(tileCoordinatesStart)
    {
        this.pathCostThreshold = pathCostThreshold;
    }

    #endregion Public Constructors

    #region Public Methods

    public override void BeginPathFinding()
    {
        logger.Debug("Beginning Path Finding for Moving starting at=?", this.cubeCoordinatesStart);
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
            else
            {
                logger.Debug("TileCoordinates: ? is not the closest. Path:? ContainsKey=?, Valid=?, PathIsShorter=?",
                    cubeCoordinates, this.pathObjectDictionary[cubeCoordinates], cubeCoordinatesIsValidEnd, cubeCoordinatesPathIsValid, cubeCoordinatesPathIsShorter);
            }
        }

        return closestCubeCoordinates;
    }

    #endregion Public Methods

    #region Private Methods

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

    private void GatherAllPathObjects()
    {
        HashSet<CubeCoordinates> visitedTileCoordinatesSet = new HashSet<CubeCoordinates>();
        HashSet<CubeCoordinates> unvisitedTileCoordinatesSet = new HashSet<CubeCoordinates> { this.cubeCoordinatesStart };
        this.pathObjectDictionary[this.cubeCoordinatesStart] = new PathObjectMove(new List<CubeCoordinates>() { this.cubeCoordinatesStart });

        logger.Debug("Gather All PathObjects");
        while (unvisitedTileCoordinatesSet.Count > 0)
        {
            // Collect the closestTileCoordinates to the tileCoordinatesStart
            CubeCoordinates closestTileCoordinates = this.GetClosestTileCoordinates(unvisitedTileCoordinatesSet);
            // Check if the Selected TileCoordinates is null and there are remaining TileCoordinates
            // to visit
            if (closestTileCoordinates != null ||
                unvisitedTileCoordinatesSet.Count <= 0)
            {
                // Collect the neighbors of the closestTileCoordinates
                HashSet<CubeCoordinates> closestTileCoordinatesNeighborSet = TileObjectFinderUtil.GetNeighborCubeCoordinates(closestTileCoordinates);
                // Add the closestTileCoordinates to the vistied Set: TileCoordinates
                visitedTileCoordinatesSet.Add(closestTileCoordinates);
                // Remove the closestTileCoordinates to the unvistied Set: TileCoordinates
                unvisitedTileCoordinatesSet.Remove(closestTileCoordinates);

                logger.Debug("PathFinding for TileCoordinates:?", closestTileCoordinates);
                logger.Debug("Size=?, Visited Tile Coordinates Set: ?", visitedTileCoordinatesSet.Count, string.Join(",", visitedTileCoordinatesSet));
                logger.Debug("Size=?, Unvisited Tile Coordinates Set: ?", unvisitedTileCoordinatesSet.Count, string.Join(",", unvisitedTileCoordinatesSet));
                logger.Debug("Size=?, Neighbor Tile Coordinates Set: ?", closestTileCoordinatesNeighborSet.Count, string.Join(",", closestTileCoordinatesNeighborSet));

                // Iterate over the TileClosest's Neigbor Set: TileScript
                foreach (CubeCoordinates neighborTileCoordinates in closestTileCoordinatesNeighborSet)
                {
                    PathObject neighborPathObject = this.PathFindForNeighbor(
                        closestTileCoordinates, neighborTileCoordinates, visitedTileCoordinatesSet, unvisitedTileCoordinatesSet);
                    if (neighborPathObject != null)
                    {
                        this.pathObjectDictionary[neighborTileCoordinates] = neighborPathObject;
                    }
                }
            }
            else
            {
                logger.Debug("Size=?, Visited Tile Coordinates Set: ?", visitedTileCoordinatesSet.Count, string.Join(",", visitedTileCoordinatesSet));
                logger.Debug("Size=?, Unvisited Tile Coordinates Set: ?", unvisitedTileCoordinatesSet.Count, string.Join(",", unvisitedTileCoordinatesSet));
                logger.Debug("Unable to continue pathFinding. Error getting the closest tileCoordinates.");
                break;
            }
        }
    }

    private void GatherAllTileCoordinatesEnds()
    {
        this.pathObjectDictionary = new Dictionary<CubeCoordinates, PathObject>();
        foreach (CubeCoordinates tileCoordinates in TileObjectFinderUtil.GetTileCoordinatesSet())
        {
            TileObject tileObject = TileObjectFinderUtil.FindTileObjectFrom(tileCoordinates);
            if (tileObject.GetTileInfoReport().GetOccupyingMechObject() == null)
            {
                int pathObjectLength = CubeCoordinatesCommonUtil.GetCubeCoordinatesDistanceFrom(this.cubeCoordinatesStart, tileCoordinates);
                PathObjectMove pathMove = new PathObjectMove(this.cubeCoordinatesStart, tileCoordinates, pathObjectLength);
                this.pathObjectDictionary.Add(tileCoordinates, pathMove);
            }
        }
    }

    private PathObject PathFindForNeighbor(CubeCoordinates currentTileCoordinates, CubeCoordinates neighborTileCoordinates,
        HashSet<CubeCoordinates> visitedTileCoordiantesSet, HashSet<CubeCoordinates> unvisitedTileCoordinatesSet)
    {
        logger.Debug("Generating PathObject for TileCoordinates: ?", neighborTileCoordinates);
        PathObject oldNeighborPathObject = null;
        TileObject neighborTileObject = TileObjectFinderUtil.FindTileObjectFrom(neighborTileCoordinates);
        if (neighborTileObject != null &&
            this.pathObjectDictionary.ContainsKey(neighborTileCoordinates))
        {
            // Check if the Dictionary contains this neighbor or if the TileNeighbor contains a object
            if (neighborTileObject.GetTileInfoReport().GetOccupyingMechObject() == null &&
                !visitedTileCoordiantesSet.Contains(neighborTileCoordinates))
            {
                oldNeighborPathObject = this.pathObjectDictionary[neighborTileCoordinates];
                // Check if the visited Set: TileScript does not contain the TileNeighbor
                if (!visitedTileCoordiantesSet.Contains(neighborTileCoordinates))
                {
                    // Add the TileNeighbor to the unvisited Set: TileScript
                    unvisitedTileCoordinatesSet.Add(neighborTileCoordinates);
                }

                PathObject currentPathObject = this.pathObjectDictionary[currentTileCoordinates];
                List<CubeCoordinates> currentPathObjectTileCoordaintesStepList = currentPathObject.GetCubeCoordinatesStepList();
                currentPathObjectTileCoordaintesStepList.Add(neighborTileCoordinates);
                PathObject newNeighborPathObject = new PathObjectMove(currentPathObjectTileCoordaintesStepList);

                logger.Debug("Old PathObject=?, Cost=?, for CubeCoordinates: ?", oldNeighborPathObject, oldNeighborPathObject.GetPathObjectCost(), neighborTileCoordinates);
                logger.Debug("New PathObject=?, Cost=?, for CubeCoordinates: ?", newNeighborPathObject, newNeighborPathObject.GetPathObjectCost(), neighborTileCoordinates);
                if (!oldNeighborPathObject.IsValid() ||
                    oldNeighborPathObject.GetPathObjectCost() > newNeighborPathObject.GetPathObjectCost())
                {
                    logger.Debug("Found new PathObject to CubeCoordinates:?. Path:?", neighborTileCoordinates, newNeighborPathObject);
                    return newNeighborPathObject;
                }
                else
                {
                    logger.Debug("Skip newPathObject due to not being cheaper than the oldPathObject.");
                }
            }
            else
            {
                // Skip this TileNeighbor
                logger.Debug("Skip visited or occupied Neighbor CubeCoordinates:?", neighborTileCoordinates);
            }
        }
        else
        {
            // Skip this TileNeighbor
            logger.Debug("Skip null or nonexistent Neighbor CubeCoordinates:?", neighborTileCoordinates);
        }
        return oldNeighborPathObject;
    }

    #endregion Private Methods
}