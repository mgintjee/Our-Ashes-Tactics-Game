/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Mvc.Controller;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Mvc.Frameworks;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Hoplites;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Mvc.Initializers;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Action;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Turn;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Mvc.Controllers;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Exceptions;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Loggers;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Objects.AIs;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Objects.Mvc.Controllers
{
    /// <summary>
    /// MvcController Object Impl
    /// </summary>
    public class MvcControllerObjectImpl
    : IMvcControllerObject
    {
        // Provide logging capability
        private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly IMvcControllerScript mvcControllerScript;

        // Todo
        private ITalonActionOrderReport actionReportToOutput = null;

        // Todo
        private bool determiningActionReport = false;

        // Todo
        private IMvcFrameworkObject mvcFrameworkObject;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcControllerScript">
        /// </param>
        public MvcControllerObjectImpl(IMvcControllerScript mvcControllerScript)
        {
            if (mvcControllerScript != null)
            {
                logger.Info("Constructing: ?", this.GetType());

                logger.Info("Setting: ?=?", typeof(IMvcControllerScript), mvcControllerScript);
                this.mvcControllerScript = mvcControllerScript;
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. " +
                    "\n\t>? is null.", this.GetType(), typeof(IMvcControllerScript));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonTurnInformationReport">
        /// </param>
        public void BeginDecisionProcess(ITalonTurnInformationReport talonTurnInformationReport)
        {
            if (talonTurnInformationReport != null)
            {
                IHopliteReport hopliteReport = talonTurnInformationReport.GetTalonInformationReport().GetHopliteReport();
                this.determiningActionReport = true;
                logger.Debug("Using ? to determine action!", hopliteReport);
                switch (hopliteReport.GetControllerId())
                {
                    //Todo: Have a map of TalonControllerId to ArtificalIntelligenceImpl if AI controlled, Null if human? Maybe leave the best action to a pilot that is local to the Talon?
                    case ControllerIdEnum.Human:
                    case ControllerIdEnum.Poacher:
                    case ControllerIdEnum.Sniper:
                    case ControllerIdEnum.Random:
                    case ControllerIdEnum.Tank:
                    case ControllerIdEnum.Survivor:
                        this.actionReportToOutput = ArtificialIntelligenceRandomImpl.DetermineBestAction(talonTurnInformationReport.GetPossibleTalonActionOrderReportSet());
                        this.determiningActionReport = false;
                        break;

                    default:
                        logger.Error("Unable to DetermineActionReport. ? is not supported", typeof(ControllerIdEnum), hopliteReport.GetControllerId());
                        break;
                }
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. " +
                    "\n\t>? is null.", new StackFrame().GetMethod().Name, typeof(ITalonTurnInformationReport));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public IMvcControllerScript GetMvcControllerScript()
        {
            return this.mvcControllerScript;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameworkObject">
        /// </param>
        /// <param name="mvcInitializationReport">
        /// </param>
        public void Initialize(IMvcFrameworkObject mvcFrameworkObject, IMvcInitializationReport mvcInitializationReport)
        {
            if (mvcFrameworkObject != null &&
                mvcInitializationReport != null)
            {
                logger.Info("Initializing: ?", this.GetType());
                if (!this.IsInitialized())
                {
                    logger.Info("Setting: ?", typeof(IMvcFrameworkObject));
                    this.mvcFrameworkObject = mvcFrameworkObject;
                }
                else
                {
                    logger.Warn("Unable to Initialize: ?. Already initialized.", this.GetType());
                }
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. " +
                    "\n\t>? is null: ?" +
                    "\n\t>? is null: ?", new StackFrame().GetMethod().Name,
                    typeof(ITalonTurnInformationReport), (mvcFrameworkObject == null),
                    typeof(IMvcInitializationReport), (mvcInitializationReport == null));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public bool IsDeterminingActionReport()
        {
            return this.determiningActionReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public bool IsInitialized()
        {
            return this.mvcFrameworkObject != null;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public bool IsReadyToOutputActionReport()
        {
            return this.actionReportToOutput != null;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public ITalonActionOrderReport OutputActionReport()
        {
            ITalonActionOrderReport actionReport = this.actionReportToOutput;
            this.actionReportToOutput = null;
            return actionReport;
        }
    }
}