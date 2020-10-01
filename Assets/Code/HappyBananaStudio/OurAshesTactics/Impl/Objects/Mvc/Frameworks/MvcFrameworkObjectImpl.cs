/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Mvc.Controller;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Mvc.Frameworks;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Mvc.Models;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Mvc.Views;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Mvc.Initializers;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Action;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Turn;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Mvc.Frameworks;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Exceptions;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.LineRenderers;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Loggers;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Objects.Mvc.Frameworks
{
    /// <summary>
    /// MvcFramework Object Impl
    /// </summary>
    public class MvcFrameworkObjectImpl
    : IMvcFrameworkObject
    {
        // Provide logging capability
        private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly IMvcFrameworkScript mvcFrameworkScript;

        // Todo
        private readonly IMvcInitializationReport mvcInitializationReport;

        // Todo
        private bool isGameActive = false;

        // Todo
        private IMvcControllerObject mvcControllerObject;

        // Todo
        private IMvcModelObject mvcModelObject;

        // Todo
        private IMvcViewObject mvcViewObject;

        // Todo
        private List<ITalonTurnResultReport> talonTurnReportList;

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
                logger.Info("Constructing: ?", this.GetType());
                this.mvcFrameworkScript = mvcFrameworkScript;
                this.mvcInitializationReport = mvcInitializationReport;
                this.talonTurnReportList = new List<ITalonTurnResultReport>();
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters." +
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
                // Check the win conditions from the model
                bool isGameComplete = this.mvcModelObject.CheckWinConditions();
                // Check if the Game is complete
                if (!isGameComplete)
                {
                    // Check if the Model is processing an Action
                    if (this.mvcModelObject.IsProcessingAction())
                    {
                        logger.Debug("Waiting for ? IsProcessingActionReport", typeof(IMvcModelObject));
                    }
                    else
                    {
                        ITalonIdentificationReport talonIdentificationReport = this.mvcModelObject.GetActingTalonIdentificationReport();
                        if (talonIdentificationReport != null)
                        {
                            logger.Debug("Determine Action for ?", talonIdentificationReport);
                            // Check if the Controller is ready to output an action
                            if (this.mvcControllerObject.IsReadyToOutputActionReport())
                            {
                                logger.Debug("Ready to output ?", typeof(ITalonActionOrderReport));
                                // Output the Action from the Controller
                                ITalonActionOrderReport talonActionOrderReport = this.mvcControllerObject.OutputActionReport();
                                // Use the LineRenderer to draw the path
                                LineRendererUtil.DrawPath(talonActionOrderReport.GetPathObject());
                                // Input the Action to the Model
                                ITalonTurnResultReport talonTurnResultReport = this.mvcModelObject.InputTalonActionOrderReport( talonActionOrderReport);
                                logger.Debug("?", talonTurnResultReport);
                                // Cache the TalonTurnResult
                                this.talonTurnReportList.Add(talonTurnResultReport);
                            }
                            else
                            {
                                // Check if the Controller is determining an Action
                                if (this.mvcControllerObject.IsDeterminingActionReport())
                                {
                                    logger.Debug("Waiting for ? IsDeterminingActionReport", typeof(IMvcControllerObject));
                                }
                                else
                                {
                                    ITalonTurnInformationReport talonActionInformationReport = this.mvcModelObject
                                        .GetTalonTurnInformationReport(talonIdentificationReport);
                                    logger.Debug("BeginDecisionProcess for ?", talonActionInformationReport);
                                    this.mvcControllerObject.BeginDecisionProcess(talonActionInformationReport);
                                }
                            }
                        }
                        else
                        {
                            logger.Debug("Unable to ContinueGame. ?'s ? is null", typeof(IMvcModelObject), typeof(ITalonIdentificationReport));
                        }
                    }
                }
                else
                {
                    logger.Debug("Unable to ContinueGame. ?'s ContinueGame is false", typeof(IMvcModelObject));
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
            */

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
                logger.Info("Initializing: ?", this.GetType());
                if (!this.IsInitialized())
                {
                    this.mvcControllerObject = mvcFrameworkScript.GetMvcControllerScript().GetMvcControllerObject();
                    this.mvcControllerObject.Initialize(this, this.mvcInitializationReport);

                    this.mvcModelObject = mvcFrameworkScript.GetMvcModelScript().GetMvcModelObject();
                    this.mvcModelObject.Initialize(this, this.mvcInitializationReport);

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
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters." +
                    "\n\t> ? is null", this.GetType(), typeof(IMvcInitializationReport));
            }
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
                    this.talonTurnReportList = new List<ITalonTurnResultReport>();
                    this.mvcModelObject.StartNewGame();
                    this.isGameActive = true;
                }
                else
                {
                    logger.Warn("Unable to StartGame. Game is currently active.");
                }
            }
            else
            {
                logger.Warn("Unable to StartGame. " +
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