/// <summary>
/// </summary>
public static class SpawnerUtilConstants
{
    #region Private Fields

    // Todo
    private static readonly string MODELS_FOLDER_PATH = "Models/";

    // Todo
    private static readonly string MODELS_MECH_PREFIX = "Mech";

    // Todo
    private static readonly string MODELS_MECHS_FOLDER_PATH = MODELS_FOLDER_PATH + "Mechs/";

    // Todo
    private static readonly string MODELS_TILE_FOLDER_PATH = MODELS_FOLDER_PATH + "Tiles/TileModel";

    // Todo
    private static readonly string MODELS_WEAPON_PREFIX = "Weapon";

    // Todo
    private static readonly string MODELS_WEAPONS_FOLDER_PATH = MODELS_FOLDER_PATH + "Weapons/";

    #endregion Private Fields

    #region Public Methods

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public static string GetMechModelsFolderPath()
    {
        return MODELS_MECHS_FOLDER_PATH + MODELS_MECH_PREFIX;
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public static string GetTileModelFolderPath()
    {
        return MODELS_TILE_FOLDER_PATH;
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public static string GetWeaponModelsFolderPath()
    {
        return MODELS_WEAPONS_FOLDER_PATH + MODELS_WEAPON_PREFIX;
    }

    #endregion Public Methods
}