using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Cube.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Offset.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Offset.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.HexTiles.Views.Constants;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.HexTiles.Views.Utils
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class HexTileViewWorldPositionUtil
    {
        // Todo
        private static readonly float PositionOffsetX = HexTileViewConstants.GetOffsetX();

        // Todo
        private static readonly float PositionOffsetY = HexTileViewConstants.GetOffsetY();

        // Todo
        private static readonly float PositionOffsetZ = HexTileViewConstants.GetOffsetZ();

        /// <summary>
        /// Todo
        /// Returns to make the following shape:
        ///
        ///           ( 0,-1, 1)
        ///     (-1, 0, 1)  ( 1,-1, 0)
        ///           ( 0, 0, 0)
        ///     (-1, 1, 0)  ( 1,0, -1)
        ///           ( 0, 1,-1)
        ///     I want
        ///     * * *
        ///   * * * * *
        ///     * * *
        ///           ( 0,-1, 1)  ( 1,-1, 0)
        ///     (-1, 0, 1)  ( 0, 0, 0)  ( 1, 0,-1)
        ///           (-1, 1, 0)  ( 0, 1,-1)
        /// </summary>
        /// <param name="cubeCoordinates">
        /// </param>
        /// <returns>
        /// </returns>
        public static Vector3 CubeCoordinatesToWorldVector(ICubeCoordinates cubeCoordinates)
        {
            IOffsetCoordinates offsetCoordinates = CoordinatesConvertorUtil.CubeToOffset(
                cubeCoordinates, OffsetCoordinateType.EVEN_R);
            float xWorldPosition = (offsetCoordinates.GetCol() * PositionOffsetX) +
                ((offsetCoordinates.GetRow() & 1) * -PositionOffsetX / 2);
            float yWorldPosition = PositionOffsetY;
            float zWorldPosition = (offsetCoordinates.GetRow() * PositionOffsetZ);
            return new Vector3(xWorldPosition, yWorldPosition, zWorldPosition);
        }
    }
}