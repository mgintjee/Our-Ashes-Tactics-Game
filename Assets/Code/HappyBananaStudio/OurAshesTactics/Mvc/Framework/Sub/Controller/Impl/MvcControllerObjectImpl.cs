/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.ArtificialIntelligence.Api;
using HappyBananaStudio.OurAshesTactics.Common.Logging;
using HappyBananaStudio.OurAshesTactics.Mvc.Controller.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Framework.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Initializer.Reports;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Roster.Reports;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Enums;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Reports;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Controller.Impl
{
    /// <summary>
    /// MvcController Object Impl
    /// </summary>
    public class MvcControllerObjectImpl
    : IMvcControllerObject
    {
        #region Private Fields

        // Provide logging capability
        private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly MvcControllerScript mvcControllerScript;

        // Todo
        private TalonActionOrderReport actionReportToOutput = null;

        // Todo
        private bool determiningActionReport = false;

        // Todo
        private IMvcFrameworkObject mvcFrameworkObject;

        // Todo
        private Dictionary<TalonPhalanxIdEnum, TalonControllerIdEnum> talonPhalanxIdControllerIdDictionary;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcControllerScript"></param>
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
                    "\n\t>mvcControllerScript is null: " + (mvcControllerScript == null));
            }
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonTurnInformationReport"></param>
        public void BeginDecisionProcess(TalonActionInformationReport talonTurnInformationReport)
        {
            if (talonTurnInformationReport != null)
            {
                this.determiningActionReport = true;
                TalonPhalanxIdEnum talonPhalanxId = talonTurnInformationReport.GetTalonInformationReport().GetTalonIdentificationReport().GetTalonPhalanxId();
                TalonControllerIdEnum talonControllerId = this.talonPhalanxIdControllerIdDictionary[talonPhalanxId];
                logger.Debug("Using ?=? to determine action!", typeof(TalonControllerIdEnum), talonControllerId);
                switch (talonControllerId)
                {
                    //Todo: Have a map of TalonControllerId to ArtificalIntelligenceImpl if AI controlled, Null if human? Maybe leave the best action to a pilot that is local to the Talon?
                    case TalonControllerIdEnum.Controller1:
                    case TalonControllerIdEnum.Controller2:
                    case TalonControllerIdEnum.Controller3:
                    case TalonControllerIdEnum.Controller4:
                    case TalonControllerIdEnum.Controller5:
                    case TalonControllerIdEnum.Controller6:
                        this.actionReportToOutput = RandomArtificialIntelligence.DetermineBestAction(talonTurnInformationReport.GetPossibleTalonActionOrderReportSet());
                        this.determiningActionReport = false;
                        break;

                    default:
                        logger.Error("Unable to DetermineActionReport. Invalid ?=?", typeof(TalonControllerIdEnum), talonControllerId);
                        break;
                }
            }
            else
            {
                throw new ArgumentException("Invalid Parameters. " + typeof(TalonActionInformationReport) + " cannot be null.");
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public MvcControllerScript GetMvcControllerScript()
        {
            return this.mvcControllerScript;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameworkObject">     </param>
        /// <param name="mvcInitializationReport"></param>
        public void Initialize(IMvcFrameworkObject mvcFrameworkObject, MvcInitializationReport mvcInitializationReport)
        {
            if (mvcFrameworkObject != null &&
                mvcInitializationReport != null)
            {
                logger.Info("Initializing: ?", this.GetType());
                if (!this.IsInitialized())
                {
                    logger.Info("Setting: ?", typeof(IMvcFrameworkObject));
                    this.mvcFrameworkObject = mvcFrameworkObject;

                    this.talonPhalanxIdControllerIdDictionary = this.BuildTalonPhalanxIdControllerDictionary(mvcInitializationReport);
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

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public bool IsDeterminingActionReport()
        {
            return this.determiningActionReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public bool IsInitialized()
        {
            return this.mvcFrameworkObject != null;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public bool IsReadyToOutputActionReport()
        {
            return this.actionReportToOutput != null;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public TalonActionOrderReport OutputActionReport()
        {
            TalonActionOrderReport actionReport = this.actionReportToOutput;
            this.actionReportToOutput = null;
            return actionReport;
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcInitializationReport"></param>
        /// <returns></returns>
        private Dictionary<TalonPhalanxIdEnum, TalonControllerIdEnum> BuildTalonPhalanxIdControllerDictionary(MvcInitializationReport mvcInitializationReport)
        {
            Dictionary<TalonPhalanxIdEnum, TalonControllerIdEnum> talonPhalanxIdControllerIdDictionary = new Dictionary<TalonPhalanxIdEnum, TalonControllerIdEnum>();

            if (mvcInitializationReport != null)
            {
                RosterConstructionReport rosterConstructionReport = mvcInitializationReport.GetRosterConstructionReport();
                Dictionary<TalonControllerIdEnum, HashSet<TalonPhalanxIdEnum>> talonControllerIdPhalanxIdSetDictionary =
                    rosterConstructionReport.GetTalonControllerPhalanxSetDictionary();
                foreach (TalonControllerIdEnum talonControllerId in talonControllerIdPhalanxIdSetDictionary.Keys)
                {
                    HashSet<TalonPhalanxIdEnum> talonPhalanxIdSet = talonControllerIdPhalanxIdSetDictionary[talonControllerId];
                    foreach (TalonPhalanxIdEnum talonPhalanxId in talonPhalanxIdSet)
                    {
                        talonPhalanxIdControllerIdDictionary.Add(talonPhalanxId, talonControllerId);
                    }
                }
            }
            else
            {
                throw new ArgumentException("Unable to build talonPhalanxIdControllerIdDictionary. Invalid Parameters." +
                    "\n\t>" + typeof(MvcInitializationReport) + " is null");
            }

            return talonPhalanxIdControllerIdDictionary;
        }

        #endregion Private Methods
    }
}