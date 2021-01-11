namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.HexTiles.Constants
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.HexTiles.Enums;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public class HexTileTypeProbabilities
    {
        // Todo
        private static readonly IDictionary<HexTileType, int> HEX_TILE_TYPE_DEFAULT_COUNTS =
            new Dictionary<HexTileType, int>
            {
                { HexTileType.Road, 2},
                { HexTileType.Plains, 3},
                { HexTileType.Forest, 2},
                { HexTileType.Mountain, 1},
                { HexTileType.Water, 1}
            };

        // Todo
        private static readonly IDictionary<HexTileType, float> HEX_TILE_TYPE_DEFAULT_PROBABILITIES =
            new Dictionary<HexTileType, float>
            {
                { HexTileType.Road, 1f},
                { HexTileType.Plains, 1f},
                { HexTileType.Forest, 1f},
                { HexTileType.Mountain, 1f},
                { HexTileType.Water, 1f}
            };

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public static IDictionary<HexTileType, int> GetHexTileObjectTypeDefaultCounts()
        {
            return new Dictionary<HexTileType, int>(HEX_TILE_TYPE_DEFAULT_COUNTS);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public static IDictionary<HexTileType, float> GetHexTileObjectTypeProbabilities()
        {
            return new Dictionary<HexTileType, float>(HEX_TILE_TYPE_DEFAULT_PROBABILITIES);
        }
    }
}