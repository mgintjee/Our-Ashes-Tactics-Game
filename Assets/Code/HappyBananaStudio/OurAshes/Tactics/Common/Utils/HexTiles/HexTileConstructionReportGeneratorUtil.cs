

namespace HappyBananaStudio.OurAshes.Tactics.Common.Utils.HexTiles
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Coordinates.Objects.Cube;
    using HappyBananaStudio.OurAshes.Tactics.Api.HexTiles.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Api.Maps.Games.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Common.Constants.HexTiles;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.HexTiles;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Coordinates;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Exceptions;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.RandomNumberGenerators;
    using HappyBananaStudio.OurAshes.Tactics.Impl.HexTiles.Reports;
    using System.Collections.Generic;
    using System.Diagnostics;

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
        /// <param name="gameMapConstructionReport">
        /// </param>
        /// <returns>
        /// </returns>
        public static ISet<IHexTileConstructionReport> GenerateHexTileConstructionReportSet(
            IGameMapConstructionReport gameMapConstructionReport)
        {
            // Set if the mapIsMirrored
            mapMirrored = gameMapConstructionReport.GetIsGameMapMirrored();
            // Default an empty IDictionary: CubeCoordinates, HexTileConstructionReport
            IDictionary<ICubeCoordinates, IHexTileConstructionReport> cubeCoordindatesHexTileConstructionReportIDictionary =
                new Dictionary<ICubeCoordinates, IHexTileConstructionReport>();

            foreach (ICubeCoordinates cubeCoordinates in gameMapConstructionReport.GetCubeCoordinatesSet())
            {
                // Set the TileInfoReport for the CubeCoordinates
                cubeCoordindatesHexTileConstructionReportIDictionary[cubeCoordinates] = GenerateHexTileConstructionReport(
                    cubeCoordinates, cubeCoordindatesHexTileConstructionReportIDictionary);
            }

            return new HashSet<IHexTileConstructionReport>(cubeCoordindatesHexTileConstructionReportIDictionary.Values);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates">
        /// </param>
        /// <param name="cubeCoordinatesHexTileConstructionReportIDictionary">
        /// </param>
        /// <returns>
        /// </returns>
        private static IHexTileConstructionReport GenerateHexTileConstructionReport(ICubeCoordinates cubeCoordinates,
            IDictionary<ICubeCoordinates, IHexTileConstructionReport> cubeCoordinatesHexTileConstructionReportIDictionary)
        {
            if (cubeCoordinates != null &&
                cubeCoordinatesHexTileConstructionReportIDictionary != null)
            {
                ICubeCoordinates negatedTileCoordinates = CubeCoordinatesCommonUtil.GetNegatedCubeCoordinates(cubeCoordinates);
                HexTileTypeEnum hexTileType = HexTileTypeEnum.None;
                // Check if the gameMapIsMirrored and the mirrored HexTileConstructionReport has
                // been generated already
                if (mapMirrored &&
                    cubeCoordinatesHexTileConstructionReportIDictionary.ContainsKey(negatedTileCoordinates))
                {
                    // Determine the HexTileType from this
                    hexTileType = cubeCoordinatesHexTileConstructionReportIDictionary[negatedTileCoordinates].GetHexTileType();
                }
                // Otherwise generate the HexTileType from the neighbors
                else
                {
                    ISet<IHexTileConstructionReport> neighboringHexTileConstructionReportSet = new HashSet<IHexTileConstructionReport>();
                    foreach (ICubeCoordinates neighborTileCoordinates in CubeCoordinatesCommonUtil.GetPossibleNeighborCubeCoordinatesSet(cubeCoordinates))
                    {
                        if (cubeCoordinatesHexTileConstructionReportIDictionary.ContainsKey(neighborTileCoordinates))
                        {
                            neighboringHexTileConstructionReportSet.Add(cubeCoordinatesHexTileConstructionReportIDictionary[neighborTileCoordinates]);
                        }
                    }
                    // Determine the HexTileType from the Neighbors
                    hexTileType = GenerateTileObjectTypeFromNeighbors(neighboringHexTileConstructionReportSet);
                }

                return new HexTileConstructionReportImpl.Builder()
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
                    typeof(IDictionary<ICubeCoordinates, IHexTileConstructionReport>), (cubeCoordinatesHexTileConstructionReportIDictionary == null));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="neighboringTileInfoReportSet">
        /// </param>
        /// <returns>
        /// </returns>
        private static HexTileTypeEnum GenerateTileObjectTypeFromNeighbors(ISet<IHexTileConstructionReport> neighboringTileInfoReportSet)
        {
            float randomProbability = RandomNumberGeneratorUtil.GetNextInt(100) / 100f;
            IDictionary<HexTileTypeEnum, float> tileTypeProbabilities = HexTileTypeProbabilities.GetHexTileObjectTypeProbabilities();
            IDictionary<HexTileTypeEnum, int> tileTypeCountIDictionary = HexTileTypeProbabilities.GetHexTileObjectTypeDefaultCounts();

            if (neighboringTileInfoReportSet.Count != 0)
            {
                foreach (IHexTileConstructionReport neighborTileInfoReport in neighboringTileInfoReportSet)
                {
                    HexTileTypeEnum NeighborTileType = neighborTileInfoReport.GetHexTileType();
                    if (NeighborTileType > 0)
                    {
                        tileTypeCountIDictionary[NeighborTileType] += 1;
                    }
                }
            }

            foreach (HexTileTypeEnum TileTypeIndex in tileTypeCountIDictionary.Keys)
            {
                tileTypeProbabilities[TileTypeIndex] *= (tileTypeCountIDictionary[TileTypeIndex] / SumNeighborCountUp(tileTypeCountIDictionary));
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
        /// <param name="tileTypeCountIDictionary">
        /// </param>
        /// <returns>
        /// </returns>
        private static float SumNeighborCountUp(IDictionary<HexTileTypeEnum, int> tileTypeCountIDictionary)
        {
            float sum = 0;
            foreach (HexTileTypeEnum tileTypeKey in tileTypeCountIDictionary.Keys)
            {
                if (tileTypeCountIDictionary.ContainsKey(tileTypeKey))
                {
                    sum += tileTypeCountIDictionary[tileTypeKey];
                }
            }
            return sum;
        }
    }
}
