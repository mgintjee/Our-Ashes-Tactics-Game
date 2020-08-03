/// <summary>
/// HexTile Script Api
/// </summary>
public abstract class HexTileScript
    : AbstractUnityScript
{
    #region Public Methods

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public abstract HexTileObject GetHexTileObject();

    /// <summary>
    /// Todo
    /// </summary>
    /// <param name="tileConstructionReport"></param>
    public abstract void Initialize(HexTileConstructionReport tileConstructionReport);

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public abstract bool IsInitialized();

    #endregion Public Methods
}