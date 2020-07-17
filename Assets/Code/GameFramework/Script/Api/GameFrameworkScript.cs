using System.Collections.Generic;
using System.Diagnostics;

/// <summary>
/// GameFrameworkScript Api
/// </summary>
public abstract class GameFrameworkScript
    : AbstractUnityScript
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    #endregion Private Fields

    #region Public Methods

    public abstract GameFrameworkObject GetGameFrameworkObject();

    public abstract bool GetGameIsActive();

    public abstract MapControllerScript GetMapControllerScript();

    public abstract MapModelScript GetMapModelScript();

    /// <summary>
    /// GameFrameworkScript Method, to initialize the GameFrameworkScript
    /// </summary>
    public abstract void Initialize();

    public abstract void InputMechRoster(List<MechConstructionReport> mechCreationReportList);

    /// <summary>
    /// GameObject Method, to call some methods on this Script start
    /// </summary>
    public void Start()
    {
        logger.Debug("Starting Script=?", this.GetType().ToString());
        this.Initialize();
        logger.Debug("Started Script=?", this.GetType().ToString());
    }

    #endregion Public Methods
}