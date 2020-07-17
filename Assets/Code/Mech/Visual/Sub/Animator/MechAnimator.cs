using System.Diagnostics;

/// <summary>
/// Todo
/// </summary>
public class MechAnimator
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    #endregion Private Fields

    #region Public Constructors

    public MechAnimator()

    {
        logger.Debug("Constructing Object=?", this.GetType().ToString());

        logger.Debug("Constructed Object=?", this.GetType().ToString());
    }

    #endregion Public Constructors
}