using System.Diagnostics;

/// <summary>
/// Implementation for TileVisualCanvas
/// </summary>
public class TileVisualCanvasImpl
    : TileVisualCanvas
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    #endregion Private Fields

    #region Public Constructors

    public TileVisualCanvasImpl()
    {
    }

    #endregion Public Constructors
}