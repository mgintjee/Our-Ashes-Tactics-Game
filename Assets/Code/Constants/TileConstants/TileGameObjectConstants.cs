/// <summary>
/// Todo
/// </summary>
public static class TileGameObjectConstants
{
    #region Private Fields

    // The West/East offset from the camera's perspective
    private static readonly float OFFSET_X = 7.8f;

    // Lowers the tile for the unit to stand on top of
    private static readonly float OFFSET_Y = -1f;

    // The North/South offset from the camera's perspective
    private static readonly float OFFSET_Z = 9f;

    #endregion Private Fields

    #region Public Methods

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public static float GetOffsetX()
    {
        return OFFSET_X;
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public static float GetOffsetY()
    {
        return OFFSET_Y;
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public static float GetOffsetZ()
    {
        return OFFSET_Z;
    }

    #endregion Public Methods
}