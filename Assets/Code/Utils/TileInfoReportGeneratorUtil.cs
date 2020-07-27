using System;
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

    private static Random random;
    private static bool mapMirrored;

    #endregion Private Fields

    #region Public Methods

    public static HashSet<TileInfoReport> GenerateTileInfoReportSet(HashSet<CubeCoordinates> cubeCoordinatesSet, bool isMapMirrored, Random randomToUse)
    {
        logger.Debug("Generating HashSet: ? for ? ?", typeof(TileInfoReport), cubeCoordinatesSet.Count, typeof(CubeCoordinates));
        // Set if the mapIsMirrored
        mapMirrored = isMapMirrored;
        // Set the Random to use
        random = randomToUse;

        // Default an empty Dictioanry: CubeCoordinates, TileInfoReport
        Dictionary<CubeCoordinates, TileInfoReport> cubeCoordindatesTileInfoReportDictionary = new Dictionary<CubeCoordinates, TileInfoReport>();
        // Default an empty Set: CubeCoordinates
        HashSet<CubeCoordinates> visitedCubeCoordinatesSet = new HashSet<CubeCoordinates>();
        // Default a List: CubeCoordinates containing the starting Coordinate
        List<CubeCoordinates> unvisitedCubeCoordinatesList = new List<CubeCoordinates>()
        { new CubeCoordinates(0, 0, 0) };
        // Continue until all CubeCoordinates have been visited
        while (unvisitedCubeCoordinatesList.Count != 0)
        {
            // Collect the next TileCoordinates
            CubeCoordinates cubeCoordinates = unvisitedCubeCoordinatesList[0];
            // Collect the Neighboring Set: CubeCoordinates
            HashSet<CubeCoordinates> neighboringCubeCoordinatesSet = CubeCoordinatesCommonUtil.GenerateNeighborCubeCoordinates(cubeCoordinates);
            // Iterate over the Neighbors
            foreach (CubeCoordinates neighborCubeCoordinates in neighboringCubeCoordinatesSet)
            {
                if (!visitedCubeCoordinatesSet.Contains(neighborCubeCoordinates) &&
                    !unvisitedCubeCoordinatesList.Contains(neighborCubeCoordinates) &&
                    cubeCoordinatesSet.Contains(neighborCubeCoordinates))
                {
                    unvisitedCubeCoordinatesList.Add(neighborCubeCoordinates);
                }
            }
            // Remove the CubeCoordinates from the unvisited List: CubeCoordinates
            unvisitedCubeCoordinatesList.Remove(cubeCoordinates);
            // Add the CubeCoordinates to the visited Set: CubeCoordinates
            visitedCubeCoordinatesSet.Add(cubeCoordinates);
            // Set the TileInfoReport for the CubeCoordinates
            cubeCoordindatesTileInfoReportDictionary[cubeCoordinates] = GenerateTileInfoReport(
                cubeCoordinates, neighboringCubeCoordinatesSet, cubeCoordindatesTileInfoReportDictionary);
        }

        return new HashSet<TileInfoReport>(cubeCoordindatesTileInfoReportDictionary.Values);
    }

    #endregion Public Methods

    #region Private Methods

    private static TileInfoReport GenerateTileInfoReport(CubeCoordinates cubeCoordinates,
        HashSet<CubeCoordinates> neighboringTileCoordinates,
        Dictionary<CubeCoordinates, TileInfoReport> tileCoordsTileInfoReportDictionary)
    {
        TileTypeEnum tileObjectType;
        CubeCoordinates negatedTileCoordinates = cubeCoordinates.GetNegatedCubeCoordinates();
        if (mapMirrored &&
            tileCoordsTileInfoReportDictionary.ContainsKey(negatedTileCoordinates))
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
        float randomProbability = random.Next(100) / 100f;
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