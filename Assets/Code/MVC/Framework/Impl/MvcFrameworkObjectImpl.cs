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

    private readonly MvcFrameworkScript mvcFrameworkScript;
    private readonly MvcInitializationReport mvcInitializationReport;
    private bool continueGame = false;
    private bool isGameActive = false;
    private MvcControllerObject mvcControllerObject;
    private MvcModelObject mvcModelObject;
    private MvcViewObject mvcViewObject;
    private List<TalonTurnReport> talonTurnReportList;

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
                "\n\t>" + typeof(MvcFrameworkScript) + " is null: " + (mvcFrameworkScript == null) +
                "\n\t>" + typeof(MvcInitializationReport) + " is null: " + (mvcInitializationReport == null));
        }
    }

    #endregion Public Constructors

    #region Public Methods

    public override bool ContinueGame()
    {
        if (this.mvcModelObject.IsInitialized())
        {
            if (!this.mvcModelObject.IsProcessingActionReport())
            {
                this.continueGame = this.mvcModelObject.ContinueGame();

                if (this.continueGame)
                {
                    TalonInformationReport talonInformationReport = this.mvcModelObject.GetCurrentTalonInformationReport();
                    if (talonInformationReport != null)
                    {
                        logger.Debug("Deciding action for ?", talonInformationReport);
                        if (this.mvcControllerObject.IsReadyToOutputActionReport())
                        {
                            TalonActionOrderReport actionReport = this.mvcControllerObject.OutputActionReport();
                            TalonTurnReport talonTurnReport = this.mvcModelObject.InputTalonActionOrderReport(actionReport);
                            this.talonTurnReportList.Add(talonTurnReport);
                            logger.Debug("Outputting ?=?", typeof(TalonActionOrderReport), actionReport);
                        }
                        else
                        {
                            if (this.mvcControllerObject.IsDeterminingActionReport())
                            {
                                logger.Debug("Waiting for ? to finish IsDeterminingActionReport", this.mvcControllerObject);
                            }
                            else
                            {
                                if (this.mvcControllerObject.IsReadyToOutputActionReport())
                                {
                                    TalonActionOrderReport talonActionOrderReport = this.mvcControllerObject.OutputActionReport();
                                    this.mvcModelObject.InputTalonActionOrderReport(talonActionOrderReport);
                                    // TODO: ACTUALLY HAVE THE TALON MOVE!!!
                                }
                                else
                                {
                                    this.mvcControllerObject.BeginDecisionProcess(talonInformationReport);
                                }
                            }
                        }
                    }
                    else
                    {
                        logger.Error("No current ? available.", typeof(TalonInformationReport));
                        // End the game
                        this.isGameActive = false;
                        this.continueGame = false;
                    }
                }
                else
                {
                    logger.Info("Game is over. TODO: Generate GameSummaryReport");
                    // End the game
                    this.isGameActive = false;
                }
            }
            else
            {
                logger.Debug("Waiting for ? to finish IsProcessingActionReport", this.mvcModelObject);
            }
        }
        else
        {
            logger.Debug("Waiting for ? to initialize", this.mvcModelObject);
        }

        if (!this.continueGame)
        {
            this.PrintTalonTurnReportList();
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
                this.mvcControllerObject.Initialize(this, this.mvcInitializationReport);

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
                "\n\t>" + typeof(MvcInitializationReport) + " is null: " + (this.mvcInitializationReport == null));
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
            this.talonTurnReportList = new List<TalonTurnReport>();
            this.mvcModelObject.StartGame();
            this.isGameActive = true;
            this.continueGame = true;
        }
    }

    #endregion Public Methods

    #region Private Methods

    private void PrintTalonTurnReportList()
    {
        foreach (TalonTurnReport talonTurnReport in this.talonTurnReportList)
        {
            logger.Info("?=?", typeof(TalonTurnReport), talonTurnReport);
        }
    }

    #endregion Private Methods
}