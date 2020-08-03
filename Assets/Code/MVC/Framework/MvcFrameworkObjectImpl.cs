using System;
using System.Diagnostics;

/// <summary>
/// MvcFramework Object Impl
/// </summary>
public class MvcFrameworkObjectImpl
    : MvcFrameworkObject
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    private readonly MvcFrameworkScript mvcFrameworkScript;
    private readonly MvcInitializationReport mvcInitializationReport;
    private bool continueGame = true;
    private bool isGameActive = false;
    private MvcControllerObject mvcControllerObject;
    private MvcModelObject mvcModelObject;
    private MvcViewObject mvcViewObject;

    #endregion Private Fields

    #region Public Constructors

    public MvcFrameworkObjectImpl(MvcFrameworkScript mvcFrameworkScript, MvcInitializationReport mvcInitializationReport)
    {
        if (mvcFrameworkScript != null &&
            mvcInitializationReport != null)
        {
            logger.Info("Contructing: ?", this.GetType());
            this.mvcFrameworkScript = mvcFrameworkScript;
            this.mvcInitializationReport = mvcInitializationReport;
        }
        else
        {
            throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                "\n>" + typeof(MvcFrameworkScript) + " is null: " + (mvcFrameworkScript == null) +
                "\n>" + typeof(MvcInitializationReport) + " is null: " + (mvcInitializationReport == null));
        }
    }

    #endregion Public Constructors

    #region Public Methods

    public override bool ContinueGame()
    {
        if (!this.mvcModelObject.IsProcessingActionReport())
        {
            TalonObject nextTalonObject = null;
            //MechObject nextMechObject = this.mvcModelObject.GetNextTalonObject();
            this.continueGame = this.mvcModelObject.ContinueGame();
            if (nextTalonObject != null)
            {
                if (this.continueGame)
                {
                    if (this.mvcControllerObject.IsReadyToOutputActionReport())
                    {
                        TalonActionReport actionReport = this.mvcControllerObject.OutputActionReport();
                        this.mvcModelObject.InputActionReport(actionReport);
                        logger.Debug("Outputting ?=?", typeof(TalonActionReport), actionReport);
                    }
                    else
                    {
                        if (this.mvcControllerObject.IsDeterminingActionReport())
                        {
                            logger.Debug("Waiting for ? to finish IsDeterminingActionReport", this.mvcControllerObject);
                        }
                        else
                        {
                            //  ControllerTypeEnum controllerType = this.mvcInitializationReport.GetTeamIdControllerTypeDictionary()[nextTalonObject.GetTeamId()];
                            //this.mvcControllerObject.DetermineActionReport(controllerType, nextTalonObject);
                        }
                    }
                }
                else
                {
                    //logger.Info("Game Over! Winning ?=?", typeof(TeamIdEnum), nextTalonObject.GetTeamId());
                    // End the game
                    this.continueGame = false;
                    this.isGameActive = false;
                }
            }
            else
            {
                //logger.Error("No next ? available.", typeof(nextTalonObject));
                // End the game
                this.continueGame = false;
                this.isGameActive = false;
            }
        }
        else
        {
            logger.Debug("Waiting for ? to finish IsProcessingActionReport", this.mvcModelObject);
        }

        return this.continueGame;
    }

    public override MvcControllerObject GetMvcControllerObject()
    {
        return this.mvcControllerObject;
    }

    public override MvcFrameworkScript GetMvcFrameworkScript()
    {
        logger.Debug("Getting ?=?", typeof(MvcModelScript), this.mvcFrameworkScript);
        return this.mvcFrameworkScript;
    }

    public override MvcModelObject GetMvcModelObject()
    {
        return this.mvcModelObject;
    }

    public override MvcViewObject GetMvcViewObject()
    {
        return this.mvcViewObject;
    }

    public override void Initialize()
    {
        if (this.mvcInitializationReport != null)
        {
            logger.Info("Initializing: ?", this.GetType());
            if (!this.IsInitialized())
            {
                logger.Info("Setting: ?=?", typeof(MvcControllerObject), mvcFrameworkScript.GetMvcControllerScript().GetMvcControllerObject());
                this.mvcControllerObject = mvcFrameworkScript.GetMvcControllerScript().GetMvcControllerObject();
                this.mvcControllerObject.Initialize(this);

                logger.Info("Setting: ?=?", typeof(MvcModelObject), mvcFrameworkScript.GetMvcModelScript().GetMvcModelObject());
                this.mvcModelObject = mvcFrameworkScript.GetMvcModelScript().GetMvcModelObject();
                this.mvcModelObject.Initialize(this, this.mvcInitializationReport);

                logger.Info("Setting: ?=?", typeof(MvcViewObject), mvcFrameworkScript.GetMvcViewScript().GetMvcViewObject());
                this.mvcViewObject = mvcFrameworkScript.GetMvcViewScript().GetMvcViewObject();
                this.mvcViewObject.Initialize(this);
            }
            else
            {
                logger.Warn("Unable to Initialize: ?. Already initialized.", this.GetType());
            }
        }
        else
        {
            throw new ArgumentException("Unable to initialize " + this.GetType() + ". Invalid Parameters." +
                "\n>" + typeof(MvcInitializationReport) + " is null: " + (this.mvcInitializationReport == null));
        }
    }

    public override bool IsInitialized()
    {
        return this.mvcFrameworkScript != null &&
            this.mvcControllerObject != null &&
            this.mvcModelObject != null &&
            this.mvcViewObject != null;
    }

    public override void StartNewGame()
    {
        if (!this.isGameActive)
        {
            this.mvcModelObject.StartGame();
            this.isGameActive = true;
            this.continueGame = true;
        }
    }

    #endregion Public Methods
}