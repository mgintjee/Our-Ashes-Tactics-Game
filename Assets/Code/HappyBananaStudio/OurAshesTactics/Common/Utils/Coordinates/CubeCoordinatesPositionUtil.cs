/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Coordinates;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Constants.HexTiles;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Utils.Coordinates
{
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
            IOffsetCoordinates offsetCoordinates = CoordinatesConvertorUtil.CubeToOffset(cubeCoordinates, OffsetCoordinateTypeEnum.EVEN_Q);
            float xWorldPosition = offsetCoordinates.GetCol() * PositionOffsetX;
            float yWorldPosition = PositionOffsetY;
            float zWorldPosition = offsetCoordinates.GetRow() * PositionOffsetZ + (offsetCoordinates.GetCol() & 1) * -PositionOffsetZ / 2;
            return new Vector3(xWorldPosition, yWorldPosition, zWorldPosition);
        }
    }
}