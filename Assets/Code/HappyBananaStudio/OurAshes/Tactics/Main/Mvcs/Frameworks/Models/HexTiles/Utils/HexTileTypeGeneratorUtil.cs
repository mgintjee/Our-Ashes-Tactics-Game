namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.HexTiles.Utils
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Coordinates.Cube.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Coordinates.Cube.Utils;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.HexTiles.Constants;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.HexTiles.Enums;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public static class HexTileTypeGeneratorUtil
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinatesSet"></param>
        /// <param name="mirroredBoard"></param>
        /// <returns></returns>
        public static IDictionary<ICubeCoordinates, HexTileType> BuildCubeCoordinatesHexTileTypeDictionary(
            ISet<ICubeCoordinates> cubeCoordinatesSet, bool mirroredBoard)
        {
            // Default an empty Dictionary
            IDictionary<ICubeCoordinates, HexTileType> cubeCoordinatesHexTileTypeDictionary =
                new Dictionary<ICubeCoordinates, HexTileType>();

            foreach (ICubeCoordinates cubeCoordinates in cubeCoordinatesSet)
            {
                cubeCoordinatesHexTileTypeDictionary.Add(cubeCoordinates,
                    DetermineHexTileType(mirroredBoard, cubeCoordinates, cubeCoordinatesHexTileTypeDictionary));
            }

            return cubeCoordinatesHexTileTypeDictionary;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mirroredBoard"></param>
        /// <param name="cubeCoordinatesHexTileTypeDictionary"></param>
        /// <returns></returns>
        private static HexTileType DetermineHexTileType(bool mirroredBoard, ICubeCoordinates cubeCoordinates,
            IDictionary<ICubeCoordinates, HexTileType> cubeCoordinatesHexTileTypeDictionary)
        {
            // Default the HexTileType to None
            HexTileType hexTileType = HexTileType.None;
            if (mirroredBoard)
            {
                ICubeCoordinates negatedCubeCoordinates = CubeCoordinatesCommonUtil.GetNegatedCubeCoordinates(cubeCoordinates);
                if (cubeCoordinatesHexTileTypeDictionary.ContainsKey(negatedCubeCoordinates))
                {
                    hexTileType = cubeCoordinatesHexTileTypeDictionary[negatedCubeCoordinates];
                }
            }
            // Check if the the HexTileType has been set
            if (hexTileType.Equals(HexTileType.None))
            {
                // Determine the HexTileType based off of the neighbors
                hexTileType = DetermineHexTileTypeFromNeighbors(cubeCoordinates, cubeCoordinatesHexTileTypeDictionary);
            }
            return hexTileType;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates"></param>
        /// <param name="cubeCoordinatesHexTileTypeDictionary"></param>
        /// <returns></returns>
        private static HexTileType DetermineHexTileTypeFromNeighbors(ICubeCoordinates cubeCoordinates,
            IDictionary<ICubeCoordinates, HexTileType> cubeCoordinatesHexTileTypeDictionary)
        {
            // Default the HexTileType to none
            HexTileType hexTileType = HexTileType.None;
            ISet<ICubeCoordinates> neighborCubeCoordinatesSet = new HashSet<ICubeCoordinates>();
            foreach (ICubeCoordinates neighborCubeCoordinates in CubeCoordinatesCommonUtil.GetPossibleNeighborCubeCoordinatesSet(cubeCoordinates))
            {
                if (cubeCoordinatesHexTileTypeDictionary.ContainsKey(neighborCubeCoordinates))
                {
                    neighborCubeCoordinatesSet.Add(neighborCubeCoordinates);
                }
            }

            double randomProbability = RandomNumberGeneratorUtil.GetNextDouble();
            IDictionary<HexTileType, float> hexTileTypeProbabilityDictionary = HexTileTypeProbabilities
                .GetHexTileObjectTypeProbabilities();
            IDictionary<HexTileType, int> hexTileTypeCountDictionary = HexTileTypeProbabilities
                .GetHexTileObjectTypeDefaultCounts();

            if (neighborCubeCoordinatesSet.Count != 0)
            {
                foreach (ICubeCoordinates neighborCubeCoordinates in neighborCubeCoordinatesSet)
                {
                    HexTileType neighborCubeCoordinatesHexTileType = cubeCoordinatesHexTileTypeDictionary[neighborCubeCoordinates];
                    if (!neighborCubeCoordinatesHexTileType.Equals(HexTileType.None))
                    {
                        hexTileTypeCountDictionary[neighborCubeCoordinatesHexTileType] += 1;
                    }
                }
            }

            foreach (HexTileType hexTileTypeEntry in hexTileTypeCountDictionary.Keys)
            {
                hexTileTypeProbabilityDictionary[hexTileTypeEntry] *= (hexTileTypeCountDictionary[hexTileTypeEntry] / SumNeighborCountUp(hexTileTypeCountDictionary));
            }

            float bound = 0;

            foreach (HexTileType tileType in hexTileTypeProbabilityDictionary.Keys)
            {
                bound += hexTileTypeProbabilityDictionary[tileType];
                if (randomProbability < bound)
                {
                    return tileType;
                }
            }

            return hexTileType;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="hexTileTypeCountDictionary">
        /// </param>
        /// <returns>
        /// </returns>
        private static float SumNeighborCountUp(IDictionary<HexTileType, int> hexTileTypeCountDictionary)
        {
            float sum = 0;
            foreach (HexTileType hexTileType in hexTileTypeCountDictionary.Keys)
            {
                if (hexTileTypeCountDictionary.ContainsKey(hexTileType))
                {
                    sum += hexTileTypeCountDictionary[hexTileType];
                }
            }
            return sum;
        }
    }
}