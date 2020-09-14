/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Mvc.Coordinates.Cube;
using HappyBananaStudio.OurAshesTactics.Mvc.Coordinates.Util;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Constants;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Enums;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Reports;
using HappyBananaStudio.OurAshesTactics.Mvc.Util.RandomNumberGenerator;
using System.Collections.Generic;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Util
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class HexTileConstructionReportGeneratorUtil
    {
        #region Private Fields

        // Todo
        private static bool mapMirrored;

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinatesSet"></param>
        /// <param name="isMapMirrored">     </param>
        /// <returns></returns>
        public static HashSet<HexTileConstructionReport> GenerateHexTileInformationReportSet(
            HashSet<CubeCoordinates> cubeCoordinatesSet, bool isMapMirrored)
        {
            // Set if the mapIsMirrored
            mapMirrored = isMapMirrored;
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

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates">                   </param>
        /// <param name="neighboringTileCoordinates">        </param>
        /// <param name="tileCoordsTileInfoReportDictionary"></param>
        /// <returns></returns>
        private static HexTileConstructionReport GenerateHexTileConstructionReport(CubeCoordinates cubeCoordinates,
            HashSet<CubeCoordinates> neighboringTileCoordinates,
            Dictionary<CubeCoordinates, HexTileConstructionReport> tileCoordsTileInfoReportDictionary)
        {
            CubeCoordinates negatedTileCoordinates = cubeCoordinates.GetNegatedCubeCoordinates();
            HexTileTypeEnum hexTileType = HexTileTypeEnum.NULL;
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

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="neighboringTileInfoReportSet"></param>
        /// <returns></returns>
        private static HexTileTypeEnum GenerateTileObjectTypeFromNeighbors(HashSet<HexTileConstructionReport> neighboringTileInfoReportSet)
        {
            float randomProbability = RandomNumberGeneratorUtil.GetNextFloat();
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
}