using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Utils.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Maps.Coordinates.Cube.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Constants.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Randoms;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Maps.Tiles.Tiles.Types.Utils
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class TileTypeUtil
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates"></param>
        /// <param name="mirroredBoard">  </param>
        /// <returns></returns>
        public static IDictionary<ICubeCoordinates, TileType> GetCubeCoordinatesTileTypes(ISet<ICubeCoordinates> cubeCoordinates, bool mirroredBoard)
        {
            // Default an empty dictionary
            IDictionary<ICubeCoordinates, TileType> cubeCoordinatesTileTypes = new Dictionary<ICubeCoordinates, TileType>();

            // Iterate over all of the cubeCoordinates
            foreach (ICubeCoordinates coordinates in cubeCoordinates)
            {
                cubeCoordinatesTileTypes.Add(coordinates,
                    DetermineTileType(mirroredBoard, coordinates, cubeCoordinatesTileTypes));
            }

            return cubeCoordinatesTileTypes;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mirroredBoard">           </param>
        /// <param name="cubeCoordinatesTileTypes"></param>
        /// <returns></returns>
        private static TileType DetermineTileType(bool mirroredBoard, ICubeCoordinates cubeCoordinates,
            IDictionary<ICubeCoordinates, TileType> cubeCoordinatesTileTypes)
        {
            // Default the TileType to None
            TileType tileType = TileType.None;
            if (mirroredBoard)
            {
                // Get the negated CubeCoordinates
                ICubeCoordinates negatedCubeCoordinates = cubeCoordinates.GetNegatedCoordinates();
                // Check if the negated CubeCoordinates is in the dictionary
                if (cubeCoordinatesTileTypes.ContainsKey(negatedCubeCoordinates))
                {
                    // Get the negated CubeCoordinates' tileType
                    tileType = cubeCoordinatesTileTypes[negatedCubeCoordinates];
                }
            }
            // Check if the the TileType has been set
            if (tileType.Equals(TileType.None))
            {
                // Determine the TileType based off of the neighbors
                tileType = DetermineTileTypeFromNeighbors(cubeCoordinates, cubeCoordinatesTileTypes);
            }
            return tileType;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates">         </param>
        /// <param name="cubeCoordinatesTileTypes"></param>
        /// <returns></returns>
        private static TileType DetermineTileTypeFromNeighbors(ICubeCoordinates cubeCoordinates,
            IDictionary<ICubeCoordinates, TileType> cubeCoordinatesTileTypes)
        {
            // Default the TileType to none
            TileType tileType = TileType.None;
            ISet<ICubeCoordinates> validNeighbors = new HashSet<ICubeCoordinates>();
            foreach (ICubeCoordinates neighbor in cubeCoordinates.GetNeighbors())
            {
                if (cubeCoordinatesTileTypes.ContainsKey(neighbor))
                {
                    validNeighbors.Add(neighbor);
                }
            }

            double probability = SortieRandom.GetInstance().NextDouble();
            IDictionary<TileType, float> tileTypeProbabilities = GetTileTypeProbabilities();
            IDictionary<TileType, int> tileTypeCounts = GetTileTypeDefaultCounts();

            if (validNeighbors.Count != 0)
            {
                foreach (ICubeCoordinates neighbor in validNeighbors)
                {
                    TileType neighborTileType = cubeCoordinatesTileTypes[neighbor];
                    if (!neighborTileType.Equals(TileType.None))
                    {
                        tileTypeCounts[neighborTileType] += 1;
                    }
                }
            }

            foreach (TileType hexTileTypeEntry in tileTypeCounts.Keys)
            {
                tileTypeProbabilities[hexTileTypeEntry] *= (tileTypeCounts[hexTileTypeEntry] / SumNeighborCountUp(tileTypeCounts));
            }

            float bound = 0;

            foreach (TileType type in tileTypeProbabilities.Keys)
            {
                bound += tileTypeProbabilities[type];
                if (probability < bound)
                {
                    return type;
                }
            }

            return tileType;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private static IDictionary<TileType, int> GetTileTypeDefaultCounts()
        {
            IDictionary<TileType, int> hexTileTypeProbabilityCounts = new Dictionary<TileType, int>();

            foreach (TileType tileType in EnumUtils.GetEnumList<TileType>())
            {
                if (tileType != TileType.None)
                {
                    hexTileTypeProbabilityCounts[tileType] =
                        TileConstantsManager.GetTileConstants(tileType).GetInitialCount();
                }
            }

            return hexTileTypeProbabilityCounts;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private static IDictionary<TileType, float> GetTileTypeProbabilities()
        {
            IDictionary<TileType, float> tileTypeProbabilities = new Dictionary<TileType, float>();

            foreach (TileType hexTileType in EnumUtils.GetEnumList<TileType>())
            {
                if (hexTileType != TileType.None)
                {
                    tileTypeProbabilities[hexTileType] = 1.0f;
                }
            }

            return tileTypeProbabilities;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="hexTileTypeCountDictionary"></param>
        /// <returns></returns>
        private static float SumNeighborCountUp(IDictionary<TileType, int> hexTileTypeCountDictionary)
        {
            float sum = 0;
            foreach (TileType hexTileType in hexTileTypeCountDictionary.Keys)
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