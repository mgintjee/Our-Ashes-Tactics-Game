/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Coordinates;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.HexTiles;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Maps.Game;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Builders;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Constants.HexTiles;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Coordinates;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Exceptions;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.RandomNumberGenerators;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Common.HexTiles
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class HexTileConstructionReportGeneratorUtil
    {
        // Todo
        private static bool mapMirrored;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinatesSet">
        /// </param>
        /// <param name="isMapMirrored">
        /// </param>
        /// <param name="mapRadius">
        /// </param>
        /// <returns>
        /// </returns>
        public static HashSet<IHexTileConstructionReport> GenerateHexTileInformationReportSet(
            IGameMapConstructionReport gameMapConstructionReport)
        {
            // Set if the mapIsMirrored
            mapMirrored = gameMapConstructionReport.GetIsGameMapMirrored();
            // Default an empty Dictionary: CubeCoordinates, HexTileConstructionReport
            Dictionary<ICubeCoordinates, IHexTileConstructionReport> cubeCoordindatesHexTileConstructionReportDictionary =
                new Dictionary<ICubeCoordinates, IHexTileConstructionReport>();

            foreach (ICubeCoordinates cubeCoordinates in gameMapConstructionReport.GetCubeCoordinatesSet())
            {
                // Set the TileInfoReport for the CubeCoordinates
                cubeCoordindatesHexTileConstructionReportDictionary[cubeCoordinates] = GenerateHexTileConstructionReport(
                    cubeCoordinates, cubeCoordindatesHexTileConstructionReportDictionary);
            }

            return new HashSet<IHexTileConstructionReport>(cubeCoordindatesHexTileConstructionReportDictionary.Values);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates">
        /// </param>
        /// <param name="cubeCoordinatesHexTileConstructionReportDictionary">
        /// </param>
        /// <returns>
        /// </returns>
        private static IHexTileConstructionReport GenerateHexTileConstructionReport(ICubeCoordinates cubeCoordinates,
            Dictionary<ICubeCoordinates, IHexTileConstructionReport> cubeCoordinatesHexTileConstructionReportDictionary)
        {
            if (cubeCoordinates != null &&
                cubeCoordinatesHexTileConstructionReportDictionary != null)
            {
                ICubeCoordinates negatedTileCoordinates = CubeCoordinatesCommonUtil.GetNegatedCubeCoordinates(cubeCoordinates);
                HexTileTypeEnum hexTileType = HexTileTypeEnum.None;
                // Check if the gameMapIsMirrored and the mirrored HexTileConstructionReport has
                // been generated already
                if (mapMirrored &&
                    cubeCoordinatesHexTileConstructionReportDictionary.ContainsKey(negatedTileCoordinates))
                {
                    // Determine the HexTileType from this
                    hexTileType = cubeCoordinatesHexTileConstructionReportDictionary[negatedTileCoordinates].GetHexTileType();
                }
                // Otherwise generate the HexTileType from the neighbors
                else
                {
                    HashSet<IHexTileConstructionReport> neighboringHexTileConstructionReportSet = new HashSet<IHexTileConstructionReport>();
                    foreach (ICubeCoordinates neighborTileCoordinates in CubeCoordinatesCommonUtil.GetPossibleNeighborCubeCoordinatesSet(cubeCoordinates))
                    {
                        if (cubeCoordinatesHexTileConstructionReportDictionary.ContainsKey(neighborTileCoordinates))
                        {
                            neighboringHexTileConstructionReportSet.Add(cubeCoordinatesHexTileConstructionReportDictionary[neighborTileCoordinates]);
                        }
                    }
                    // Determine the HexTileType from the Neighbors
                    hexTileType = GenerateTileObjectTypeFromNeighbors(neighboringHexTileConstructionReportSet);
                }

                return ReportBuilder.HexTile.Construction.GetBuilder()
                    .SetCubeCoordinates(cubeCoordinates)
                    .SetHexTileType(hexTileType)
                    .Build();
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. " +
                    "\n\t> ? is null: ?" +
                    "\n\t> ? is null: ?",
                    new StackFrame().GetMethod().Name,
                    typeof(ICubeCoordinates), (cubeCoordinates == null),
                    typeof(Dictionary<ICubeCoordinates, IHexTileConstructionReport>), (cubeCoordinatesHexTileConstructionReportDictionary == null));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="neighboringTileInfoReportSet">
        /// </param>
        /// <returns>
        /// </returns>
        private static HexTileTypeEnum GenerateTileObjectTypeFromNeighbors(HashSet<IHexTileConstructionReport> neighboringTileInfoReportSet)
        {
            float randomProbability = RandomNumberGeneratorUtil.GetNextInt(100) / 100f;
            Dictionary<HexTileTypeEnum, float> tileTypeProbabilities = HexTileTypeProbabilities.GetHexTileObjectTypeProbabilities();
            Dictionary<HexTileTypeEnum, int> tileTypeCountDictionary = HexTileTypeProbabilities.GetHexTileObjectTypeDefaultCounts();

            if (neighboringTileInfoReportSet.Count != 0)
            {
                foreach (IHexTileConstructionReport neighborTileInfoReport in neighboringTileInfoReportSet)
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
        /// Todo
        /// </summary>
        /// <param name="tileTypeCountDictionary">
        /// </param>
        /// <returns>
        /// </returns>
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
    }
}