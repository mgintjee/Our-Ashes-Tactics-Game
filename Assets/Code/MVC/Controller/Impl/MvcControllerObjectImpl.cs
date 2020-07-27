using System;
using System.Diagnostics;

/// <summary>
/// MvcController Object Impl
/// </summary>
public class MvcControllerObjectImpl
    : MvcControllerObject
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    private readonly MvcControllerScript mvcControllerScript;
    private MvcFrameworkObject mvcFrameworkObject;
    private ActionReport actionReportToOutput = null;
    private bool determiningActionReport = false;

    #endregion Private Fields

    #region Public Constructors

    public MvcControllerObjectImpl(MvcControllerScript mvcControllerScript)
    {
        if (mvcControllerScript != null)
        {
            logger.Info("Contructing: ?", this.GetType());

            logger.Info("Setting: ?=?", typeof(MvcControllerScript), mvcControllerScript);
            this.mvcControllerScript = mvcControllerScript;
        }
        else
        {
            throw new ArgumentException("Unable to construct " +
                this.GetType() + ". Invalid Parameters." +
                "\n>mvcControllerScript is null: " + (mvcControllerScript == null));
        }
    }

    #endregion Public Constructors

    #region Public Methods

    public override MvcControllerScript GetMvcControllerScript()
    {
        return this.mvcControllerScript;
    }

    public override void Initialize(MvcFrameworkObject mvcFrameworkObject)
    {
        if (mvcFrameworkObject != null)
        {
            logger.Info("Initializing: ?", this.GetType());
            if (!this.IsInitialized())
            {
                logger.Info("Setting: ?", typeof(MvcFrameworkObject));
                this.mvcFrameworkObject = mvcFrameworkObject;
            }
            else
            {
                logger.Warn("Unable to Initialize: ?. Already initialized.", this.GetType());
            }
        }
        else
        {
            logger.Error("Unable to Initialize: ?. Invalid Parameters", this.GetType());
        }
    }

    public override bool IsInitialized()
    {
        return this.mvcFrameworkObject != null;
    }

    public override bool IsReadyToOutputActionReport()
    {
        return this.actionReportToOutput != null;
    }

    public override ActionReport OutputActionReport()
    {
        ActionReport actionReport = this.actionReportToOutput;
        this.actionReportToOutput = null;
        return actionReport;
    }

    public override void DetermineActionReport(ControllerTypeEnum controllerType, MechObject mechObject)
    {
        this.determiningActionReport = true;

        switch (controllerType)
        {
            case ControllerTypeEnum.Human:
                logger.Debug("Waiting on HUMAN!!!");
                break;

            case ControllerTypeEnum.Robot:
                this.actionReportToOutput = ArtificialIntelligence.DetermineBestAction(mechObject.GetMechActionReportSet());
                this.determiningActionReport = false;
                break;

            default:
                logger.Error("Unable to DetermineActionReport. Invalid ?=?", typeof(ControllerTypeEnum), controllerType);
                break;
        }
    }

    public override bool IsDeterminingActionReport()
    {
        return this.determiningActionReport;
    }

    #endregion Public Methods
}