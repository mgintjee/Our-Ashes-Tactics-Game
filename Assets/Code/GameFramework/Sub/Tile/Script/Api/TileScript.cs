/// <summary>
/// TileScript Api
/// </summary>
public abstract class TileScript
    : AbstractUnityScript
{
    #region Public Methods

    public abstract CubeCoordinates GetCubeCoordinates();

    public abstract TileBehavior GetTileBehavior();

    public abstract TileInfoReport GetTileInfoReport();

    public abstract TileObject GetTileObject();

    public abstract TileObjectTypeEnum GetTileObjectType();

    public abstract TileVisual GetTileVisual();

    public abstract void Initialize(TileInfoReport tileInfoReport);

    #endregion Public Methods
}