/// <summary>
/// Abstract Implementation for TileVisual
/// </summary>
public abstract class TileVisualAbstract
    : TileVisual
{
    #region Protected Fields

    protected TileObject tileObject;

    protected TileVisualCanvas tileVisualCanvas;
    protected TileVisualModel tileVisualModel;

    #endregion Protected Fields

    #region Public Methods

    public override TileVisualCanvas GetTileVisualCanvas()
    {
        return this.tileVisualCanvas;
    }

    public override TileVisualModel GetTileVisualModel()
    {
        return this.tileVisualModel;
    }

    #endregion Public Methods
}