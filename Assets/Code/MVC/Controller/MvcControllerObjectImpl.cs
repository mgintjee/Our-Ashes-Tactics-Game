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
    private TalonActionReport actionReportToOutput = null;
    private bool determiningActionReport = false;
    private MvcFrameworkObject mvcFrameworkObject;

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

    public override void DetermineActionReport(TalonControllerTypeEnum controllerType, TalonObject talonObject)
    {
        this.determiningActionReport = true;

        switch (controllerType)
        {
            case TalonControllerTypeEnum.Human:
                logger.Debug("Waiting on HUMAN!!!");
                break;

            case TalonControllerTypeEnum.Robot:
                //this.actionReportToOutput = ArtificialIntelligence.DetermineBestAction(talonObject.GetMechActionReportSet());
                this.determiningActionReport = false;
                break;

            default:
                logger.Error("Unable to DetermineActionReport. Invalid ?=?", typeof(TalonControllerTypeEnum), controllerType);
                break;
        }
    }

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

    public override bool IsDeterminingActionReport()
    {
        return this.determiningActionReport;
    }

    public override bool IsInitialized()
    {
        return this.mvcFrameworkObject != null;
    }

    public override bool IsReadyToOutputActionReport()
    {
        return this.actionReportToOutput != null;
    }

    public override TalonActionReport OutputActionReport()
    {
        TalonActionReport actionReport = this.actionReportToOutput;
        this.actionReportToOutput = null;
        return actionReport;
    }

    #endregion Public Methods
}