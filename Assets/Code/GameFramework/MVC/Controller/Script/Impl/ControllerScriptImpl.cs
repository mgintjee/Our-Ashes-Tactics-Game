using System.Diagnostics;

/// <summary>
/// Controller Script Impl
/// </summary>
public class ControllerScriptImpl
    : ControllerScript
{
    #region Protected Fields

    // Todo
    protected ControllerObject mapControllerObject;

    #endregion Protected Fields

    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    // Todo
    private ActionReport actionReport;

    // Todo
    private GameFrameworkScript gameFrameworkScript;

    private MechObject mechObject;

    private bool processingInput = false;

    // Todo
    private ControllerTypeEnum teamControllerType;

    #endregion Private Fields

    #region Public Methods

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public override bool ActionReportIsAvailable()
    {
        return this.actionReport != null;
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public override ActionReport CollectActionReport()
    {
        ActionReport mechActionReport = this.actionReport;
        if (this.actionReport != null)
        {
            this.actionReport = null;
        }
        return mechActionReport;
    }

    /// <summary>
    /// Todo
    /// </summary>
    public override void DetermineNextActionReport()
    {
        this.processingInput = true;
    }

    /// <summary>
    /// Todo
    /// </summary>
    public void FixedUpdate()
    {
        if (this.gameFrameworkScript != null &&
                   this.gameFrameworkScript.GameIsActive())
        {
            if (this.processingInput)
            {
                logger.Info("Processing input");
                if (this.actionReport == null)
                {
                    if (this.mechObject == null)
                    {
                        this.mechObject = this.gameFrameworkScript.GetGameFrameworkObject().GetNextMechObject();

                        if (this.mechObject.GetMechTeam() == 1)
                        {
                            this.teamControllerType = this.gameFrameworkScript.GetGameFrameworkObject().GetTeam1Controller();
                        }
                        else if (mechObject.GetMechTeam() == 2)
                        {
                            this.teamControllerType = this.gameFrameworkScript.GetGameFrameworkObject().GetTeam2Controller();
                        }
                    }
                    switch (this.teamControllerType)
                    {
                        case ControllerTypeEnum.HUMAN:
                            logger.Info("Waiting for HUMAN input");
                            break;

                        case ControllerTypeEnum.ROBOT:
                            if (mechObject != null)
                            {
                                this.actionReport = this.mapControllerObject.CollectMechActionReport(mechObject);
                                this.mechObject = null;
                                this.processingInput = false;
                            }
                            else
                            {
                                logger.Warn("Unable to determine ?. ? is null.",
                                    typeof(ActionReport), typeof(MechObject));
                            }
                            break;

                        default:
                            logger.Error("Invalid ?. Value=?", typeof(ControllerTypeEnum), this.teamControllerType);
                            break;
                    }
                }
                else
                {
                    logger.Warn("Unable to determine ?. ? is currently available.",
                        typeof(ActionReport), typeof(ActionReport));
                }
            }
            else
            {
                logger.Debug("Unable to determine ?. ? is not currently processing an input.",
                    typeof(ActionReport), typeof(ControllerScript));
            }
        }
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public override ControllerObject GetMapControllerObject()
    {
        return this.mapControllerObject;
    }

    /// <summary>
    /// MapControllerScript Method, to initialize the MapControllerScript
    /// </summary>
    /// <param name="gameFrameworkScript"></param>
    public override void Initialize(GameFrameworkScript gameFrameworkScript)
    {
        logger.Debug("Initializing Script=?", this.GetType().ToString());
        if (this.gameFrameworkScript == null)
        {
            this.gameFrameworkScript = gameFrameworkScript;
            this.mapControllerObject = new ControllerObjectImpl(this.gameFrameworkScript.GetGameFrameworkObject());
        }
        else
        {
            logger.Warn("Unable to Set ?. Script has already been set.", typeof(GameFrameworkScript));
        }
        logger.Debug("Initialized Script=?", this.GetType().ToString());
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public override bool ProcessingInput()
    {
        return this.processingInput;
    }

    #endregion Public Methods
}