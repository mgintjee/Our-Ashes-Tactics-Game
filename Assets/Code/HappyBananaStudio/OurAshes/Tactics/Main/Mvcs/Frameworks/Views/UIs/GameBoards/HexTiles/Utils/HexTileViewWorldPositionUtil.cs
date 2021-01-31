namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.GameBoards.HexTiles.Utils
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Coordinates.Cube.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Coordinates.Offset.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Coordinates.Offset.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Coordinates.Utils;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.GameBoards.HexTiles.Constants;
    using UnityEngine;

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
        /// </summary>
        /// <param name="cubeCoordinates">
        /// </param>
        /// <returns>
        /// </returns>
        public static Vector3 CubeCoordinatesToWorldVector(ICubeCoordinates cubeCoordinates)
        {
            IOffsetCoordinates offsetCoordinates = CoordinatesConvertorUtil.CubeToOffset(
                cubeCoordinates, OffsetCoordinateType.EVEN_Q);
            float xWorldPosition = offsetCoordinates.GetCol() * PositionOffsetX;
            float yWorldPosition = PositionOffsetY;
            float zWorldPosition = (offsetCoordinates.GetRow() * PositionOffsetZ) +
                ((offsetCoordinates.GetCol() & 1) * -PositionOffsetZ / 2);
            return new Vector3(xWorldPosition, yWorldPosition, zWorldPosition);
        }
    }
}