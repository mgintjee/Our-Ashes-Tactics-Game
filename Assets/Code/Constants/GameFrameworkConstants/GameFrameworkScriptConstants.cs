/// <summary>
/// </summary>
public static class GameFrameworkScriptConstants
{
    #region Private Fields

    // Todo
    private static readonly string MAP_CONTROLLER_GAME_OBJECT_NAME = "MapControllerGameObject";

    // Todo
    private static readonly string MAP_MODEL_GAME_OBJECT_NAME = "MapModelGameObject";

    // Todo
    private static readonly string MAP_VIEW_GAME_OBJECT_NAME = "MapViewGameObject";

    #endregion Private Fields

    #region Public Methods

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public static string GetMapControllerGameObjectName()
    {
        return MAP_CONTROLLER_GAME_OBJECT_NAME;
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public static string GetMapModelGameObjectName()
    {
        return MAP_MODEL_GAME_OBJECT_NAME;
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public static string GetMapViewGameObjectName()
    {
        return MAP_VIEW_GAME_OBJECT_NAME;
    }

    #endregion Public Methods
}