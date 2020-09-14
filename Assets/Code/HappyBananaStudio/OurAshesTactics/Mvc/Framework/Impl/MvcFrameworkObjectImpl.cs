/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Common.Logging;
using HappyBananaStudio.OurAshesTactics.Mvc.Controller.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Framework.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Initializer.Reports;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Reports;
using HappyBananaStudio.OurAshesTactics.Mvc.View.Api;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Framework.Impl
{
    /// <summary>
    /// MvcFramework Object Impl
    /// </summary>
    public class MvcFrameworkObjectImpl
    : IMvcFrameworkObject
    {
        #region Private Fields

        // Provide logging capability
        private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly MvcFrameworkScript mvcFrameworkScript;

        // Todo
        private readonly MvcInitializationReport mvcInitializationReport;

        // Todo
        private bool continueGame = false;

        // Todo
        private bool isGameActive = false;

        // Todo
        private IMvcControllerObject mvcControllerObject;

        // Todo
        private IMvcModelObject mvcModelObject;

        // Todo
        private IMvcViewObject mvcViewObject;

        // Todo
        private bool processingAction = false;

        // Todo
        private List<TalonTurnResultReport> talonTurnReportList;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameworkScript">     </param>
        /// <param name="mvcInitializationReport"></param>
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

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public bool ContinueGame()
        {
            if (this.mvcModelObject.IsInitialized() &&
                this.mvcControllerObject.IsInitialized() &&
                this.mvcViewObject.IsInitialized())
            {
                logger.Debug("Waiting for ? to initialize", this.mvcModelObject);
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
                                logger.Info("?=?", typeof(TalonActionOrderReport), actionReport);
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

            if (!this.continueGame)
            {
                this.PrintTalonTurnReportList();
            }

            return this.continueGame;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public IMvcControllerObject GetMvcControllerObject()
        {
            return this.mvcControllerObject;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public MvcFrameworkScript GetMvcFrameworkScript()
        {
            logger.Debug("Getting ?=?", typeof(MvcModelScript), this.mvcFrameworkScript);
            return this.mvcFrameworkScript;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public IMvcModelObject GetMvcModelObject()
        {
            return this.mvcModelObject;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
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
                    logger.Info("Setting: ?=?", typeof(IMvcControllerObject), mvcFrameworkScript.GetMvcControllerScript().GetMvcControllerObject());
                    this.mvcControllerObject = mvcFrameworkScript.GetMvcControllerScript().GetMvcControllerObject();
                    this.mvcControllerObject.Initialize(this, this.mvcInitializationReport);

                    logger.Info("Setting: ?=?", typeof(IMvcModelObject), mvcFrameworkScript.GetMvcModelScript().GetMvcModelObject());
                    this.mvcModelObject = mvcFrameworkScript.GetMvcModelScript().GetMvcModelObject();
                    this.mvcModelObject.Initialize(this, this.mvcInitializationReport);

                    logger.Info("Setting: ?=?", typeof(IMvcViewObject), mvcFrameworkScript.GetMvcViewScript().GetMvcViewObject());
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

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public bool IsInitialized()
        {
            return this.mvcFrameworkScript != null &&
                this.mvcControllerObject != null &&
                this.mvcModelObject != null &&
                this.mvcViewObject != null;
        }

        public bool StartGame()
        {
            if (this.mvcModelObject.IsInitialized() &&
                this.mvcControllerObject.IsInitialized() &&
                this.mvcViewObject.IsInitialized())
            {
                this.isGameActive = this.ContinueGame();
            }
            else
            {
                logger.Info("Unable to StartGame. " +
                    "\n\t>? isInitialized = ?" +
                    "\n\t>? isInitialized = ?" +
                    "\n\t>? isInitialized = ?",
                    typeof(IMvcModelObject), mvcModelObject.IsInitialized(),
                    typeof(IMvcControllerObject), mvcControllerObject.IsInitialized(),
                    typeof(IMvcViewObject), mvcViewObject.IsInitialized());
            }
            return this.isGameActive;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public void StartNewGame()
        {
            if (!this.isGameActive)
            {
                this.talonTurnReportList = new List<TalonTurnResultReport>();
                this.mvcModelObject.StartGame();
                this.isGameActive = true;
                this.continueGame = true;
            }
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Todo
        /// </summary>
        private void PrintTalonTurnReportList()
        {
            foreach (TalonTurnResultReport talonTurnReport in this.talonTurnReportList)
            {
                logger.Info("?=?", typeof(TalonTurnResultReport), talonTurnReport);
            }
        }

        #endregion Private Methods
    }
}