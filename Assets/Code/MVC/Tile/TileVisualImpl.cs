using System.Diagnostics;

/// <summary>
/// Implementation for TileVisual
/// </summary>
public class TileVisualImpl
    : TileVisual
{
    #region Protected Fields

    protected TileObject tileObject;

    protected TileVisualCanvas tileVisualCanvas;
    protected TileVisualModel tileVisualModel;

    #endregion Protected Fields

    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    #endregion Private Fields

    #region Public Constructors

    public TileVisualImpl(TileObject tileObject)
    {
        logger.Debug("Constructing Object=?: ?",
            this.GetType().ToString(), tileObject.GetTileInfoReport());

        this.tileObject = tileObject;
        this.tileVisualModel = new TileVisualModelImpl(this.tileObject);
        this.tileVisualCanvas = new TileVisualCanvasImpl();

        logger.Debug("Constructed Object=?: ?",
            this.GetType().ToString(), this.tileObject.GetTileInfoReport());
    }

    #endregion Public Constructors

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