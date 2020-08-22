/// <summary>
/// HexTile Script Api
/// </summary>
public abstract class HexTileScript
    : AbstractUnityScript
{
    #region Public Methods

    public abstract HexTileObject GetHexTileObject();

    public abstract void Initialize(HexTileConstructionReport tileConstructionReport);

    public abstract bool IsInitialized();

    #endregion Public Methods
}