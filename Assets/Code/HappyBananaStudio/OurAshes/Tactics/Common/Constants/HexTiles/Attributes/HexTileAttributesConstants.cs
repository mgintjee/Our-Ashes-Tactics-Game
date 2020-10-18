
namespace HappyBananaStudio.OurAshes.Tactics.Common.Constants.HexTiles.Attributes
{
    using HappyBananaStudio.OurAshes.Tactics.Api.HexTiles.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.HexTiles;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Exceptions;
    using HappyBananaStudio.OurAshes.Tactics.Impl.HexTiles.Attributes;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Todo
    /// </summary>
    public class HexTileAttributesConstants
    {
        // Todo
        private static readonly IDictionary<HexTileTypeEnum, IHexTileAttributes> hexTileTypeAttributesDictionary =
                new Dictionary<HexTileTypeEnum, IHexTileAttributes>();

        // Todo
        private static readonly ISet<HexTileTypeEnum> supportedHexTileTypeSet = new HashSet<HexTileTypeEnum>()
        {
            HexTileTypeEnum.Road,
            HexTileTypeEnum.Plains,
            HexTileTypeEnum.Forest,
            HexTileTypeEnum.Mountain,
            HexTileTypeEnum.Water
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
            if (supportedHexTileTypeSet.Contains(hexTileType))
            {
                if (!hexTileTypeAttributesDictionary.ContainsKey(hexTileType))
                {
                    hexTileTypeAttributesDictionary.Add(hexTileType, BuildAttributes(hexTileType));
                }
                return hexTileTypeAttributesDictionary[hexTileType];
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                    new StackFrame().GetMethod().Name, hexTileType);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="hexTileType">
        /// </param>
        /// <returns>
        /// </returns>
        private static IHexTileAttributes BuildAttributes(HexTileTypeEnum hexTileType)
        {
            switch (hexTileType)
            {
                case HexTileTypeEnum.Forest:
                    return new HexTileAttributesImpl.Builder()
                            .SetFireCost(20)
                            .SetMoveCost(3)
                            .Build();

                case HexTileTypeEnum.Mountain:
                    return new HexTileAttributesImpl.Builder()
                            .SetFireCost(35)
                            .SetMoveCost(4)
                            .Build();

                case HexTileTypeEnum.Plains:
                    return new HexTileAttributesImpl.Builder()
                            .SetFireCost(5)
                            .SetMoveCost(2)
                            .Build();

                case HexTileTypeEnum.Road:
                    return new HexTileAttributesImpl.Builder()
                            .SetFireCost(0)
                            .SetMoveCost(1)
                            .Build();

                case HexTileTypeEnum.Water:
                    return new HexTileAttributesImpl.Builder()
                            .SetFireCost(5)
                            .SetMoveCost(3)
                            .Build();

                default:
                    throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                        new StackFrame().GetMethod().Name, hexTileType);
            }
        }
    }
}
