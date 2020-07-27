using System;
using System.Collections.Generic;
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

    private readonly MvcInitializationReport mvcInitializationReport;
    private readonly MvcFrameworkScript mvcFrameworkScript;
    private MvcControllerObject mvcControllerObject;
    private MvcViewObject mvcViewObject;
    private MvcModelObject mvcModelObject;
    private bool isGameActive = false;
    private bool continueGame = true;

    #endregion Private Fields

    #region Public Constructors

    public MvcFrameworkObjectImpl(MvcFrameworkScript mvcFrameworkScript, MvcInitializationReport mvcInitializationReport)
    {
        if (mvcFrameworkScript != null &&
            mvcInitializationReport != null)
        {
            logger.Info("Contructing: ?", this.GetType());

            logger.Info("Setting: ?=?", typeof(MvcFrameworkScript), mvcFrameworkScript);
            this.mvcFrameworkScript = mvcFrameworkScript;

            logger.Info("Setting: ?=?", typeof(MvcInitializationReport), mvcInitializationReport);
            this.mvcInitializationReport = mvcInitializationReport;
        }
        else
        {
            throw new ArgumentException("Unable to construct " +
                this.GetType() + ". Invalid Parameters." +
                "\n>mvcFrameworkScript is null: " + (mvcFrameworkScript == null));
        }
    }

    #endregion Public Constructors

    #region Public Methods

    public override MvcFrameworkScript GetMvcFrameworkScript()
    {
        logger.Debug("Getting ?=?", typeof(MvcModelScript), this.mvcFrameworkScript);
        return this.mvcFrameworkScript;
    }

    public override MvcControllerObject GetMvcControllerObject()
    {
        return this.mvcControllerObject;
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
        if (mvcInitializationReport != null)
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
            logger.Error("Unable to Initialize: ?. Missing Attributes", this.GetType());
        }
    }

    public override bool IsInitialized()
    {
        return this.mvcFrameworkScript != null &&
            this.mvcControllerObject != null &&
            this.mvcModelObject != null &&
            this.mvcViewObject != null;
    }

    public override Dictionary<TeamIdEnum, ControllerTypeEnum> GetTeamIdControllerTypeDictionary()
    {
        return (this.mvcInitializationReport != null)
            ? this.mvcInitializationReport.GetTeamIdControllerTypeDictionary()
            : new Dictionary<TeamIdEnum, ControllerTypeEnum>();
    }

    public override HashSet<MechConstructionReport> GetMechContructionReportSet()
    {
        return (this.mvcInitializationReport != null)
            ? this.mvcInitializationReport.GetMechConstructionReportSet()
            : new HashSet<MechConstructionReport>();
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

    public override bool ContinueGame()
    {
        if (!this.mvcModelObject.IsProcessingActionReport())
        {
            MechObject nextMechObject = this.mvcModelObject.GetNextMechObject();
            this.continueGame = this.mvcModelObject.ContinueGame();
            if (nextMechObject != null)
            {
                if (this.continueGame)
                {
                    if (this.mvcControllerObject.IsReadyToOutputActionReport())
                    {
                        ActionReport actionReport = this.mvcControllerObject.OutputActionReport();
                        this.mvcModelObject.InputActionReport(actionReport);
                        logger.Debug("Outputting ?=?", typeof(ActionReport), actionReport);
                    }
                    else
                    {
                        if (this.mvcControllerObject.IsDeterminingActionReport())
                        {
                            logger.Debug("Waiting for ? to finish IsDeterminingActionReport", this.mvcControllerObject);
                        }
                        else
                        {
                            ControllerTypeEnum controllerType = this.mvcInitializationReport.GetTeamIdControllerTypeDictionary()[nextMechObject.GetTeamId()];
                            this.mvcControllerObject.DetermineActionReport(controllerType, nextMechObject);
                        }
                    }
                }
                else
                {
                    logger.Info("Game Over! Winning ?=?", typeof(TeamIdEnum), nextMechObject.GetTeamId());
                    // End the game
                    this.continueGame = false;
                    this.isGameActive = false;
                }
            }
            else
            {
                logger.Error("No next ? available.", typeof(MechObject));
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

    #endregion Public Methods
}