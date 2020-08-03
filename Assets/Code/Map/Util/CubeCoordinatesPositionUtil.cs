using UnityEngine;

/// <summary>
/// Todo
/// </summary>
public static class CubeCoordinatesPositionUtil
{
    #region Private Fields

    // Todo
    private static readonly float PositionOffsetX = HexTileGameObjectConstants.GetOffsetX();

    // Todo
    private static readonly float PositionOffsetY = HexTileGameObjectConstants.GetOffsetY();

    // Todo
    private static readonly float PositionOffsetZ = HexTileGameObjectConstants.GetOffsetZ();

    #endregion Private Fields

    #region Public Methods

    /// <summary>
    /// Todo
    /// </summary>
    /// <param name="cubeCoordinates"></param>
    /// <returns></returns>
    public static Vector3 CubeCoordinatesToWorldVector(CubeCoordinates cubeCoordinates)
    {
        OffsetCoordinates offsetCoordinates = CoordinatesConvertorUtil.CubeToOffset(cubeCoordinates, OffsetCoordinateTypeEnum.EVEN_Q);

        float xWorldPosition = offsetCoordinates.GetCol() * PositionOffsetX;
        float yWorldPosition = PositionOffsetY;
        float zWorldPosition = offsetCoordinates.GetRow() * PositionOffsetZ + (offsetCoordinates.GetCol() & 1) * -PositionOffsetZ / 2;
        return new Vector3(xWorldPosition, yWorldPosition, zWorldPosition);
    }

    #endregion Public Methods
}