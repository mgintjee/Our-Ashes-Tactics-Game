using System.Diagnostics;

/// <summary>
/// Implementation for TileVisual
/// </summary>
public class TileVisualImpl
    : TileVisualAbstract
{
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
}