/*
 * namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Objects
{
    using HappyBananaStudio.OurAshes.Tactics.Main.Api.Loggers;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// MvcFramework Object Impl
    /// </summary>
    public class MvcFrameworkObjectImpl
    : IMvcFrameworkObject
    {
        // Provide logging capability
        private static readonly ICodeLogger Logger = new CodeLoggerImpl(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly IMvcFrameworkScript mvcFrameworkScript;

        // Todo
        private readonly IMvcInitializationReport mvcInitializationReport;

        // Todo
        private IList<IGameActionReport> gameActionReportList;

        // Todo
        private bool isGameActive = false;

        // Todo
        private IMvcControllerObject mvcControllerObject;

        // Todo
        private IMvcModelObject mvcModelObject;

        // Todo
        private IMvcViewObject mvcViewObject;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameworkScript">
        /// </param>
        /// <param name="mvcInitializationReport">
        /// </param>
        public MvcFrameworkObjectImpl(IMvcFrameworkScript mvcFrameworkScript, IMvcInitializationReport mvcInitializationReport)
        {
            if (mvcFrameworkScript != null &&
                mvcInitializationReport != null)
            {
                Logger.Info("Constructing: ?", this.GetType());
                this.mvcFrameworkScript = mvcFrameworkScript;
                this.mvcInitializationReport = mvcInitializationReport;
                this.gameActionReportList = new List<IGameActionReport>();
            }
            else
            {
                throw ExceptionUtil.Argument.Build("Unable to construct ?. Invalid Parameters." +
                    "\n\t> ? is null: ?" +
                    "\n\t> ? is null: ?", this.GetType(),
                    typeof(IMvcFrameworkScript), (mvcFrameworkScript == null),
                    typeof(IMvcInitializationReport), (mvcInitializationReport == null));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public bool ContinueGame()
        {
            // Check if the Game is currently active
            if (this.isGameActive)
            {
                this.mvcViewObject.UpdateCanvas();
                // Check the win conditions from the model
                bool isGameComplete = this.mvcModelObject.CheckWinConditions();
                // Check if the Game is complete
                if (!isGameComplete)
                {
                    ITalonIdentificationReport talonIdentificationReport = this.mvcModelObject.GetActingTalonIdentificationReport();
                    if (talonIdentificationReport != null)
                    {
                        Logger.Debug("Determine Action for ?", talonIdentificationReport);
                        // Check if the Controller is ready to output an action
                        if (this.mvcControllerObject.IsReadyToOutputActionReport())
                        {
                            Logger.Debug("Ready to output ?", typeof(ITalonActionOrderReport));
                            // Output the Action from the Controller
                            ITalonActionOrderReport talonActionOrderReport = this.mvcControllerObject.OutputActionReport();
                            // Animate and update the View based off of the actionReport
                            this.mvcViewObject.AnimateActionOrderReport(talonActionOrderReport);
                            // Input the Action to the Model
                            IGameActionReport gameActionReport = this.mvcModelObject
                                .InputTalonActionOrderReport(talonActionOrderReport);

                            if (talonActionOrderReport is ITalonActionOrderFireReport)
                            {
                                this.mvcViewObject.DisplayCombatReportPopUp(gameActionReport);
                            }
                            // Cycle the next random value
                            RandomNumberGeneratorUtil.GetNextInt();
                            Logger.Info("?", gameActionReport);
                            // Cache the IGameActionReport
                            this.gameActionReportList.Add(gameActionReport);
                            Logger.Info("?", GameMapObjectManager.GetGameMapInformationReport());
                        }
                        else
                        {
                            // Check if the Controller is determining an Action
                            if (this.mvcControllerObject.IsDeterminingActionReport())
                            {
                                Logger.Debug("Waiting for ? IsDeterminingActionReport", typeof(IMvcControllerObject));
                            }
                            else
                            {
                                ITalonTurnReport talonActionInformationReport = this.mvcModelObject
                                    .GetTalonTurnInformationReport(talonIdentificationReport);
                                Logger.Debug("BeginDecisionProcess for ?", talonActionInformationReport);
                                this.mvcControllerObject.BeginDecisionProcess(talonActionInformationReport);
                            }
                        }
                    }
                    else
                    {
                        Logger.Debug("Unable to ContinueGame. ?'s ? is null", typeof(IMvcModelObject), typeof(ITalonIdentificationReport));
                    }
                }
                else
                {
                    Logger.Debug("Unable to ContinueGame. ?'s ContinueGame is false", typeof(IMvcModelObject));
                    this.isGameActive = false;
                }
            }
            /*
            {
                this.processingAction = this.mvcModelObject.IsProcessingActionReport();
                if (!this.processingAction)
                {
                    this.continueGame = this.mvcModelObject.ContinueGame();

                    if (this.continueGame)
                    {
                        TalonIdentificationReport talonIdentificationReport = this.mvcModelObject.GetCurrentTalonIdentificationReport();
                        if (talonIdentificationReport != null)
                        {
                            logger.Info("Deciding action for ?", talonIdentificationReport);
                            if (this.mvcControllerObject.IsReadyToOutputActionReport())
                            {
                                TalonActionOrderReport actionReport = this.mvcControllerObject.OutputActionReport();
                                logger.Info("?=?", typeof(ITalonActionOrderReport), actionReport);
                                TalonTurnResultReport talonTurnReport = this.mvcModelObject.InputTalonActionOrderReport(actionReport);
                                logger.Info("?=?", typeof(TalonTurnResultReport), talonTurnReport);
                                logger.Info("?=?", typeof(MvcModelInformationReport), this.mvcModelObject.GetMvcModelInformationReport());
                                this.talonTurnReportList.Add(talonTurnReport);
                            }
                            else
                            {
                                if (this.mvcControllerObject.IsDeterminingActionReport())
                                {
                                    logger.Debug("Waiting for ? to finish IsDeterminingActionReport", this.mvcControllerObject);
                                }
                                else
                                {
                                    //this.mvcControllerObject.BeginDecisionProcess(talonIdentificationReport);
                                }
                            }
                        }
                        else
                        {
                            Time.timeScale = 0;
                            throw new ArgumentException("No current " + typeof(TalonInformationReport) + " available.");
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

            if (!this.isGameActive)
            {
                LineRendererUtil.ErasePath();
            }

            return this.isGameActive;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public IMvcControllerObject GetMvcControllerObject()
        {
            return this.mvcControllerObject;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public IMvcFrameworkScript GetMvcFrameworkScript()
        {
            return this.mvcFrameworkScript;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public IMvcModelObject GetMvcModelObject()
        {
            return this.mvcModelObject;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public IMvcViewObject GetMvcViewObject()
        {
            return this.mvcViewObject;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public void Initialize()
        {
            if (this.mvcInitializationReport != null)
            {
                Logger.Info("Initializing: ?", this.GetType());
                if (!this.IsInitialized())
                {
                    this.mvcControllerObject = new MvcControllerObjectImpl(this, this.mvcInitializationReport);
                    this.mvcModelObject = new MvcModelObjectImpl(this, this.mvcInitializationReport);
                    this.mvcViewObject = new MvcViewObjectImpl(this, this.mvcInitializationReport);
                }
                else
                {
                    Logger.Warn("Unable to Initialize: ?. Already initialized.", this.GetType());
                }
            }
            else
            {
                throw ExceptionUtil.Argument.Build("Unable to ?. Invalid Parameters." +
                    "\n\t> ? is null", this.GetType(), typeof(IMvcInitializationReport));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public bool IsAnimating()
        {
            return this.mvcViewObject.IsAnimating();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public bool IsInitialized()
        {
            return this.mvcFrameworkScript != null &&
                this.mvcControllerObject != null &&
                this.mvcModelObject != null &&
                this.mvcViewObject != null;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public void StartNewGame()
        {
            if (this.mvcModelObject.IsInitialized() &&
                this.mvcControllerObject.IsInitialized() &&
                this.mvcViewObject.IsInitialized())
            {
                if (!this.isGameActive)
                {
                    this.gameActionReportList = new List<IGameActionReport>();
                    this.mvcModelObject.StartNewGame();
                    this.isGameActive = true;
                }
                else
                {
                    Logger.Warn("Unable to StartGame. Game is currently active.");
                }
            }
            else
            {
                Logger.Warn("Unable to StartGame. " +
                    "\n\t>? isInitialized = ?" +
                    "\n\t>? isInitialized = ?" +
                    "\n\t>? isInitialized = ?",
                    typeof(IMvcModelObject), mvcModelObject.IsInitialized(),
                    typeof(IMvcControllerObject), mvcControllerObject.IsInitialized(),
                    typeof(IMvcViewObject), mvcViewObject.IsInitialized());
            }
        }
    }
}
*/