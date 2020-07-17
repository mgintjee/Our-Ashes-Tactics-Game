using System.Diagnostics;

/// <summary>
/// Implementation for TileBehavior
/// </summary>
public class TileBehaviorImpl
    : TileBehaviorAbstract
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    #endregion Private Fields

    #region Public Constructors

    /// <summary>
    /// Constructor Method, to construct the TileObject from Coordinates
    /// </summary>
    /// <param name="coordinates">The Coordinates to construct the TileObject with</param>
    public TileBehaviorImpl(TileObject tileObject)
    {
        logger.Debug("Constructing Object=?: ?",
            this.GetType().ToString(), tileObject.GetTileInfoReport());

        this.tileObject = tileObject;

        logger.Debug("Constructed Object=?: ?",
            this.GetType().ToString(), tileObject.GetTileInfoReport());
    }

    #endregion Public Constructors
}