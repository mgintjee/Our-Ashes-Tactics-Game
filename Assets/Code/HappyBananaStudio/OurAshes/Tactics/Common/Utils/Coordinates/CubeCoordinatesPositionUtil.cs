

namespace HappyBananaStudio.OurAshesTactics.Common.Utils.Coordinates
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Coordinates.Objects.Cube;
    using HappyBananaStudio.OurAshes.Tactics.Api.Coordinates.Objects.Offset;
    using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Coordinates.Enums;
    using HappyBananaStudio.OurAshes.Tactics.Common.Constants.HexTiles;
    using UnityEngine;

    /// <summary>
    /// Todo
    /// </summary>
    public static class CubeCoordinatesPositionUtil
    {
        // Todo
        private static readonly float PositionOffsetX = HexTileGameObjectConstants.GetOffsetX();

        // Todo
        private static readonly float PositionOffsetY = HexTileGameObjectConstants.GetOffsetY();

        // Todo
        private static readonly float PositionOffsetZ = HexTileGameObjectConstants.GetOffsetZ();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates">
        /// </param>
        /// <returns>
        /// </returns>
        public static Vector3 CubeCoordinatesToWorldVector(ICubeCoordinates cubeCoordinates)
        {
            IOffsetCoordinates offsetCoordinates = CoordinatesConvertorUtil.CubeToOffset(
                cubeCoordinates, OffsetCoordinateTypeEnum.EVEN_Q);
            float xWorldPosition = offsetCoordinates.GetCol() * PositionOffsetX;
            float yWorldPosition = PositionOffsetY;
            float zWorldPosition = (offsetCoordinates.GetRow() * PositionOffsetZ) + ((offsetCoordinates.GetCol() & 1) * -PositionOffsetZ / 2);
            return new Vector3(xWorldPosition, yWorldPosition, zWorldPosition);
        }
    }
}
