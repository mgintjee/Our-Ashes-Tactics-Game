using System.Collections.Generic;
using System.Diagnostics;

/// <summary>
/// Todo
/// </summary>
public static class TileInfoReportGeneratorUtil
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    #endregion Private Fields

    #region Public Methods

    public static HashSet<TileInfoReport> GenerateTileInfoReportSet(HashSet<CubeCoordinates> tileCoordinatesSet, bool mapMirrored)
    {
        logger.Debug("Generating HashSet: TileInfoReport for ? TileCoordinates", tileCoordinatesSet.Count);
        Dictionary<CubeCoordinates, TileInfoReport> tileCoordsTileInfoReportDictionary = new Dictionary<CubeCoordinates, TileInfoReport>();
        List<CubeCoordinates> unvisitedTileCoordinatesList = new List<CubeCoordinates>()
        {
            new CubeCoordinates(0, 0, 0)
        };
        HashSet<CubeCoordinates> visitedTileCoordinatesSet = new HashSet<CubeCoordinates>();
        while (unvisitedTileCoordinatesList.Count != 0)
        {
            CubeCoordinates tileCoordinates = unvisitedTileCoordinatesList[0];
            HashSet<CubeCoordinates> neighboringTileCoordinatesSet = CubeCoordinatesCommonUtil.GenerateNeighborCubeCoordinates(tileCoordinates);
            foreach (CubeCoordinates neighborTileCoordinates in neighboringTileCoordinatesSet)
            {
                if (!visitedTileCoordinatesSet.Contains(neighborTileCoordinates) &&
                    !unvisitedTileCoordinatesList.Contains(neighborTileCoordinates) &&
                    tileCoordinatesSet.Contains(neighborTileCoordinates))
                {
                    unvisitedTileCoordinatesList.Add(neighborTileCoordinates);
                }
            }
            unvisitedTileCoordinatesList.Remove(tileCoordinates);
            visitedTileCoordinatesSet.Add(tileCoordinates);
            tileCoordsTileInfoReportDictionary[tileCoordinates] = GenerateTileInfoReport(
                tileCoordinates, neighboringTileCoordinatesSet, tileCoordsTileInfoReportDictionary);
        }

        return new HashSet<TileInfoReport>(tileCoordsTileInfoReportDictionary.Values);
    }

    #endregion Public Methods

    #region Private Methods

    private static TileInfoReport GenerateTileInfoReport(CubeCoordinates cubeCoordinates,
        HashSet<CubeCoordinates> neighboringTileCoordinates,
        Dictionary<CubeCoordinates, TileInfoReport> tileCoordsTileInfoReportDictionary)
    {
        TileTypeEnum tileObjectType;
        CubeCoordinates negatedTileCoordinates = CubeCoordinatesCommonUtil.GetNegatedCubeCoordinates(cubeCoordinates);
        if (tileCoordsTileInfoReportDictionary.ContainsKey(negatedTileCoordinates))
        {
            // Determine the TileInfoType from this
            tileObjectType = tileCoordsTileInfoReportDictionary[negatedTileCoordinates].GetTileObjectType();
        }
        else
        {
            HashSet<TileInfoReport> neighboringTileInfoReportSet = new HashSet<TileInfoReport>();
            foreach (CubeCoordinates neighborTileCoordinates in neighboringTileCoordinates)
            {
                if (tileCoordsTileInfoReportDictionary.ContainsKey(neighborTileCoordinates))
                {
                    neighboringTileInfoReportSet.Add(tileCoordsTileInfoReportDictionary[neighborTileCoordinates]);
                }
            }
            // Determine the TileInfoType from the Neighbors
            tileObjectType = GenerateTileObjectTypeFromNeighbors(neighboringTileInfoReportSet);
        }

        return new TileInfoReport.Builder()
            .SetCubeCoordinates(cubeCoordinates)
            .SetTileObjectType(tileObjectType)
            .SetOccupyinMechObject(null)
            .SetNeighborTileCoordinates(neighboringTileCoordinates)
            .Build();
    }

    private static TileTypeEnum GenerateTileObjectTypeFromNeighbors(HashSet<TileInfoReport> neighboringTileInfoReportSet)
    {
        float randomProbability = UnityEngine.Random.Range(0, 1f);
        // TOdo store the following dictionaries in a Const file
        Dictionary<TileTypeEnum, float> tileTypeProbabilities = TileObjectTypeConstants.GetTileObjectTypeProbabilities();
        Dictionary<TileTypeEnum, int> tileTypeCounts = TileObjectTypeConstants.GetTileObjectTypeDefaultCounts();

        if (neighboringTileInfoReportSet.Count != 0)
        {
            foreach (TileInfoReport neighborTileInfoReport in neighboringTileInfoReportSet)
            {
                TileTypeEnum NeighborTileType = neighborTileInfoReport.GetTileObjectType();
                if (NeighborTileType > 0)
                {
                    tileTypeCounts[NeighborTileType] += 1;
                }
            }
        }

        foreach (TileTypeEnum TileTypeIndex in tileTypeCounts.Keys)
        {
            tileTypeProbabilities[TileTypeIndex] *= (tileTypeCounts[TileTypeIndex] / SumNeighborCountUp(tileTypeCounts));
        }

        float bound = 0;

        foreach (TileTypeEnum tileType in tileTypeProbabilities.Keys)
        {
            bound += tileTypeProbabilities[tileType];
            if (randomProbability < bound)
            {
                return tileType;
            }
        }
        return 0;
    }

    //////////////////
    // Util Methods
    //////////////////

    /// <summary>
    /// Util method, to sum up the neighbors in a given dictionary of tile Type counts
    /// </summary>
    /// <param name="tileTypeCountDictionary">
    /// The dictionary representation of the neighboring tile types
    /// </param>
    /// <returns>The total sum of the neighboring tile types</returns>
    private static float SumNeighborCountUp(Dictionary<TileTypeEnum, int> tileTypeCountDictionary)
    {
        float sum = 0;
        foreach (TileTypeEnum tileTypeKey in tileTypeCountDictionary.Keys)
        {
            if (tileTypeCountDictionary.ContainsKey(tileTypeKey))
            {
                sum += tileTypeCountDictionary[tileTypeKey];
            }
        }
        return sum;
    }

    #endregion Private Methods
}