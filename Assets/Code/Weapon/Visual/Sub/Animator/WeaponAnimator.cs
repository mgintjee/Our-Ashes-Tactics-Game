using System.Diagnostics;

/// <summary>
/// Todo
/// </summary>
public class WeaponAnimator
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    #endregion Private Fields

    #region Public Constructors

    /// <summary>
    /// </summary>
    public WeaponAnimator()

    {
        logger.Debug("Constructing Object=?", this.GetType().ToString());

        logger.Debug("Constructed Object=?", this.GetType().ToString());
    }

    #endregion Public Constructors
}