/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Constants.HexTiles
{
    public class HexTileTypeProbabilities
    {
        private static readonly Dictionary<HexTileTypeEnum, int> HEX_TILE_TYPE_DEFAULT_COUNTS =
            new Dictionary<HexTileTypeEnum, int>
            {
            { HexTileTypeEnum.Road, 2},
            { HexTileTypeEnum.Plains, 3},
            { HexTileTypeEnum.Forest, 2},
            { HexTileTypeEnum.Mountain, 1},
            { HexTileTypeEnum.Water, 1}
            };

        private static readonly Dictionary<HexTileTypeEnum, float> HEX_TILE_TYPE_DEFAULT_PROBABILITIES =
            new Dictionary<HexTileTypeEnum, float>
            {
            { HexTileTypeEnum.Road, 1f},
            { HexTileTypeEnum.Plains, 1f},
            { HexTileTypeEnum.Forest, 1f},
            { HexTileTypeEnum.Mountain, 1f},
            { HexTileTypeEnum.Water, 1f}
            };

        public static Dictionary<HexTileTypeEnum, int> GetHexTileObjectTypeDefaultCounts()
        {
            return new Dictionary<HexTileTypeEnum, int>(HEX_TILE_TYPE_DEFAULT_COUNTS);
        }

        public static Dictionary<HexTileTypeEnum, float> GetHexTileObjectTypeProbabilities()
        {
            return new Dictionary<HexTileTypeEnum, float>(HEX_TILE_TYPE_DEFAULT_PROBABILITIES);
        }
    }
}