using System.Diagnostics;

/// <summary>
/// Todo
/// </summary>
public class MechCanvas
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    private MechBehavior mechBehavior;

    #endregion Private Fields

    #region Public Constructors

    public MechCanvas(MechBehavior mechBehavior)

    {
        logger.Debug("Constructing Object=?", this.GetType().ToString());
        this.mechBehavior = mechBehavior;
        logger.Debug("Constructed Object=?", this.GetType().ToString());
    }

    #endregion Public Constructors

    #region Private Methods

    private void UpdateCanvas()
    {
    }

    #endregion Private Methods
}