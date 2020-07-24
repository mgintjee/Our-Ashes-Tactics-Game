/// <summary>
/// Implementation for TileObject
/// </summary>
public class TileObjectImpl
    : TileObjectAbstract
{
    #region Public Constructors

    public TileObjectImpl(TileScript tileScript, TileInfoReport initialTileInfoReport)
    {
        this.tileScript = tileScript;
        this.tileInfoReport = initialTileInfoReport;
        this.tileBehavior = new TileBehaviorImpl(this);
        this.tileVisual = new TileVisualImpl(this);
    }

    #endregion Public Constructors
}