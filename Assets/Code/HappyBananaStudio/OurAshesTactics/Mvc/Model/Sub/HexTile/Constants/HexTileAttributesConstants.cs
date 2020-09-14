/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Enums;
using System.Collections.Generic;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Constants
{
    /// <summary>
    /// Object to store the constant numerical attributes of supported HexTiles
    /// </summary>
    public class HexTileAttributesConstants
    {
        #region Private Fields

        private static readonly Dictionary<HexTileTypeEnum, HexTileAttributes> HEX_TILE_TYPE_ATTRIBUTES_DICTIONARY = new Dictionary<HexTileTypeEnum, HexTileAttributes>()
    {
        {
            HexTileTypeEnum.Road,
            new HexTileAttributes.Builder()
            .SetFireCost(0)
            .SetMoveCost(1)
            .Build()
        },
        {
            HexTileTypeEnum.Plains,
            new HexTileAttributes.Builder()
            .SetFireCost(5)
            .SetMoveCost(2)
            .Build()
        },
        {
            HexTileTypeEnum.Forest,
            new HexTileAttributes.Builder()
            .SetFireCost(20)
            .SetMoveCost(3)
            .Build()
        },
        {
            HexTileTypeEnum.Mountain,
            new HexTileAttributes.Builder()
            .SetFireCost(35)
            .SetMoveCost(4)
            .Build()
        },
        {
            HexTileTypeEnum.Water,
            new HexTileAttributes.Builder()
            .SetFireCost(5)
            .SetMoveCost(3)
            .Build()
        },
    };

        #endregion Private Fields

        #region Public Methods

        public static HexTileAttributes GetAttributes(HexTileTypeEnum hexTileType)
        {
            if (HEX_TILE_TYPE_ATTRIBUTES_DICTIONARY.ContainsKey(hexTileType))
            {
                return HEX_TILE_TYPE_ATTRIBUTES_DICTIONARY[hexTileType];
            }
            return null;
        }

        #endregion Public Methods
    }
}