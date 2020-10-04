/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Attributes.HexTiles;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Builders;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Constants.Attributes.HexTiles
{
    /// <summary>
    /// Todo
    /// </summary>
    public class HexTileAttributesConstants
    {
        // Todo
        private static readonly Dictionary<HexTileTypeEnum, IHexTileAttributes> HEXTILE_TYPE_ATTRIBUTES_DICTIONARY =
                new Dictionary<HexTileTypeEnum, IHexTileAttributes>()
                {
                    {
                        HexTileTypeEnum.Road,
                        AttributesBuilder.HexTile.GetBuilder()
                            .SetFireCost(0)
                            .SetMoveCost(1)
                            .Build()
                    },
                    {
                        HexTileTypeEnum.Plains,
                        AttributesBuilder.HexTile.GetBuilder()
                            .SetFireCost(5)
                            .SetMoveCost(2)
                            .Build()
                    },
                    {
                        HexTileTypeEnum.Forest,
                        AttributesBuilder.HexTile.GetBuilder()
                            .SetFireCost(20)
                            .SetMoveCost(3)
                            .Build()
                    },
                    {
                        HexTileTypeEnum.Mountain,
                        AttributesBuilder.HexTile.GetBuilder()
                            .SetFireCost(35)
                            .SetMoveCost(4)
                            .Build()
                    },
                    {
                        HexTileTypeEnum.Water,
                        AttributesBuilder.HexTile.GetBuilder()
                            .SetFireCost(5)
                            .SetMoveCost(3)
                            .Build()
                    },
                };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="hexTileType">
        /// </param>
        /// <returns>
        /// </returns>
        public static IHexTileAttributes GetAttributes(HexTileTypeEnum hexTileType)
        {
            if (HEXTILE_TYPE_ATTRIBUTES_DICTIONARY.ContainsKey(hexTileType))
            {
                return HEXTILE_TYPE_ATTRIBUTES_DICTIONARY[hexTileType];
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                    new StackFrame().GetMethod().Name, hexTileType);
            }
        }
    }
}