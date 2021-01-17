namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.HexTiles.Constants
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.HexTiles.Attributes.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.HexTiles.Attributes.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.HexTiles.Enums;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Todo
    /// </summary>
    public class HexTileAttributesConstants
    {
        // Todo
        private static readonly IDictionary<HexTileType, IHexTileAttributes> hexTileTypeAttributesDictionary =
                new Dictionary<HexTileType, IHexTileAttributes>()
                {
                    {
                        HexTileType.Forest,
                        new HexTileAttributesImpl.Builder()
                            .SetFireCost(20)
                            .SetMoveCost(3)
                            .Build()
                    },
                    {
                        HexTileType.Mountain,
                        new HexTileAttributesImpl.Builder()
                            .SetFireCost(35)
                            .SetMoveCost(4)
                            .Build()
                    },
                    {
                        HexTileType.Plains,
                        new HexTileAttributesImpl.Builder()
                            .SetFireCost(5)
                            .SetMoveCost(2)
                            .Build()
                    },
                    {
                        HexTileType.Road,
                        new HexTileAttributesImpl.Builder()
                            .SetFireCost(0)
                            .SetMoveCost(1)
                            .Build()
                    },
                    {
                        HexTileType.Water,
                        new HexTileAttributesImpl.Builder()
                            .SetFireCost(5)
                            .SetMoveCost(3)
                            .Build()
                    }
                };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="hexTileType">
        /// </param>
        /// <returns>
        /// </returns>
        public static IHexTileAttributes GetHexTileAttributes(HexTileType hexTileType)
        {
            // Check if the hexTileType is supported
            if (hexTileTypeAttributesDictionary.ContainsKey(hexTileType))
            {
                return hexTileTypeAttributesDictionary[hexTileType];
            }
            else
            {
                throw ExceptionUtil.Argument.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                    new StackFrame().GetMethod().Name, hexTileType);
            }
        }
    }
}