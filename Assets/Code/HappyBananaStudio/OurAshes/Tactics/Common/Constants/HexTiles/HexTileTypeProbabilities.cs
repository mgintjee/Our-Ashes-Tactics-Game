
namespace HappyBananaStudio.OurAshes.Tactics.Common.Constants.HexTiles
{
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.HexTiles;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public class HexTileTypeProbabilities
    {
        // Todo
        private static readonly IDictionary<HexTileTypeEnum, int> HEX_TILE_TYPE_DEFAULT_COUNTS =
            new Dictionary<HexTileTypeEnum, int>
            {
            { HexTileTypeEnum.Road, 2},
            { HexTileTypeEnum.Plains, 3},
            { HexTileTypeEnum.Forest, 2},
            { HexTileTypeEnum.Mountain, 1},
            { HexTileTypeEnum.Water, 1}
            };

        // Todo
        private static readonly IDictionary<HexTileTypeEnum, float> HEX_TILE_TYPE_DEFAULT_PROBABILITIES =
            new Dictionary<HexTileTypeEnum, float>
            {
            { HexTileTypeEnum.Road, 1f},
            { HexTileTypeEnum.Plains, 1f},
            { HexTileTypeEnum.Forest, 1f},
            { HexTileTypeEnum.Mountain, 1f},
            { HexTileTypeEnum.Water, 1f}
            };

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public static IDictionary<HexTileTypeEnum, int> GetHexTileObjectTypeDefaultCounts()
        {
            return new Dictionary<HexTileTypeEnum, int>(HEX_TILE_TYPE_DEFAULT_COUNTS);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public static IDictionary<HexTileTypeEnum, float> GetHexTileObjectTypeProbabilities()
        {
            return new Dictionary<HexTileTypeEnum, float>(HEX_TILE_TYPE_DEFAULT_PROBABILITIES);
        }
    }
}
