using System.Diagnostics;

/// <summary>
/// View Script Impl
/// </summary>
public class ViewScriptImpl
    : ViewScript
{
    #region Protected Fields

    protected GameFrameworkScript gameFrameworkScript;

    // Todo
    protected ViewObject mapModelObject;

    #endregion Protected Fields

    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    #endregion Private Fields

    #region Public Methods

    public override GameFrameworkScript GetGameFrameworkScript()
    {
        return this.gameFrameworkScript;
    }

    public override ViewObject GetMapModelObject()
    {
        return this.mapModelObject;
    }

    public override void Initialize(GameFrameworkScript gameFrameworkScript)
    {
        logger.Debug("Initializing Script=?", this.GetType().ToString());
        this.gameFrameworkScript = gameFrameworkScript;
        this.mapModelObject = new ViewObjectImpl(this.gameFrameworkScript.GetGameFrameworkObject());
        logger.Debug("Initialized Script=?", this.GetType().ToString());
    }

    #endregion Public Methods
}