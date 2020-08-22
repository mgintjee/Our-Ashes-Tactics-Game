using System;
using System.Collections.Generic;

public static class HexTileConstructionReportGeneratorUtil
{
    #region Private Fields

    private static bool mapMirrored;
    private static Random random;

    #endregion Private Fields

    #region Public Methods

    public static HashSet<HexTileConstructionReport> GenerateHexTileInformationReportSet(
        HashSet<CubeCoordinates> cubeCoordinatesSet, bool isMapMirrored, Random randomToUse)
    {
        // Set if the mapIsMirrored
        mapMirrored = isMapMirrored;
        // Set the Random to use
        random = randomToUse;
        // Default an empty Dictioanry: CubeCoordinates, HexTileConstructionReport
        Dictionary<CubeCoordinates, HexTileConstructionReport> cubeCoordindatesHexTileConstructionReportDictionary = new Dictionary<CubeCoordinates, HexTileConstructionReport>();
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
            cubeCoordindatesHexTileConstructionReportDictionary[cubeCoordinates] = GenerateHexTileConstructionReport(
                cubeCoordinates, neighboringCubeCoordinatesSet, cubeCoordindatesHexTileConstructionReportDictionary);
        }

        return new HashSet<HexTileConstructionReport>(cubeCoordindatesHexTileConstructionReportDictionary.Values);
    }

    #endregion Public Methods

    #region Private Methods

    private static HexTileConstructionReport GenerateHexTileConstructionReport(CubeCoordinates cubeCoordinates,
        HashSet<CubeCoordinates> neighboringTileCoordinates,
        Dictionary<CubeCoordinates, HexTileConstructionReport> tileCoordsTileInfoReportDictionary)
    {
        CubeCoordinates negatedTileCoordinates = cubeCoordinates.GetNegatedCubeCoordinates();
        HexTileTypeEnum hexTileType;
        if (mapMirrored &&
            tileCoordsTileInfoReportDictionary.ContainsKey(negatedTileCoordinates))
        {
            // Determine the HexTileType from this
            hexTileType = tileCoordsTileInfoReportDictionary[negatedTileCoordinates].GetHexTileType();
        }
        else
        {
            HashSet<HexTileConstructionReport> neighboringHexTileConstructionReportSet = new HashSet<HexTileConstructionReport>();
            foreach (CubeCoordinates neighborTileCoordinates in neighboringTileCoordinates)
            {
                if (tileCoordsTileInfoReportDictionary.ContainsKey(neighborTileCoordinates))
                {
                    neighboringHexTileConstructionReportSet.Add(tileCoordsTileInfoReportDictionary[neighborTileCoordinates]);
                }
            }
            // Determine the HexTileType from the Neighbors
            hexTileType = GenerateTileObjectTypeFromNeighbors(neighboringHexTileConstructionReportSet);
        }

        return new HexTileConstructionReport.Builder()
            .SetCubeCoordinates(cubeCoordinates)
            .SetNeighborCubeCoordinatesSet(neighboringTileCoordinates)
            .SetTileType(hexTileType)
            .Build();
    }

    private static HexTileTypeEnum GenerateTileObjectTypeFromNeighbors(HashSet<HexTileConstructionReport> neighboringTileInfoReportSet)
    {
        float randomProbability = random.Next(100) / 100f;
        Dictionary<HexTileTypeEnum, float> tileTypeProbabilities = HexTileTypeProbabilities.GetHexTileObjectTypeProbabilities();
        Dictionary<HexTileTypeEnum, int> tileTypeCountDictionary = HexTileTypeProbabilities.GetHexTileObjectTypeDefaultCounts();

        if (neighboringTileInfoReportSet.Count != 0)
        {
            foreach (HexTileConstructionReport neighborTileInfoReport in neighboringTileInfoReportSet)
            {
                HexTileTypeEnum NeighborTileType = neighborTileInfoReport.GetHexTileType();
                if (NeighborTileType > 0)
                {
                    tileTypeCountDictionary[NeighborTileType] += 1;
                }
            }
        }

        foreach (HexTileTypeEnum TileTypeIndex in tileTypeCountDictionary.Keys)
        {
            tileTypeProbabilities[TileTypeIndex] *= (tileTypeCountDictionary[TileTypeIndex] / SumNeighborCountUp(tileTypeCountDictionary));
        }

        float bound = 0;

        foreach (HexTileTypeEnum tileType in tileTypeProbabilities.Keys)
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
    private static float SumNeighborCountUp(Dictionary<HexTileTypeEnum, int> tileTypeCountDictionary)
    {
        float sum = 0;
        foreach (HexTileTypeEnum tileTypeKey in tileTypeCountDictionary.Keys)
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