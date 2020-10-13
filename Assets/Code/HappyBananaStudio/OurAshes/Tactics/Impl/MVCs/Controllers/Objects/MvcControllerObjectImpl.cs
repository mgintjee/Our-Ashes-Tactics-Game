/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>

namespace HappyBananaStudio.OurAshesTactics.Impl.Objects.Mvc.Controllers
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Hoplites.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Api.Loggers;
    using HappyBananaStudio.OurAshes.Tactics.Api.MVCs.Controllers.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.MVCs.Frameworks.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.MVCs.Initializers.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Actions.Orders;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Turn;
    using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Talons.Enums;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Loggers;
    using HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions;
    using HappyBananaStudio.OurAshesTactics.Impl.Objects.AIs;
    using System.Diagnostics;

    /// <summary>
    /// MvcController Object Impl
    /// </summary>
    public class MvcControllerObjectImpl
    : IMvcControllerObject
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLoggerImpl(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly IMvcFrameworkObject mvcFrameworkObject;

        // Todo
        private readonly IMvcInitializationReport mvcInitializationReport;

        // Todo
        private ITalonActionOrderReport actionReportToOutput = null;

        // Todo
        private bool determiningActionReport = false;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcControllerScript">
        /// </param>
        public MvcControllerObjectImpl(IMvcFrameworkObject mvcFrameworkObject, IMvcInitializationReport mvcInitializationReport)
        {
            if (mvcFrameworkObject != null &&
                mvcInitializationReport != null)
            {
                logger.Info("Constructing: ?", this.GetType());
                this.mvcFrameworkObject = mvcFrameworkObject;
                this.mvcInitializationReport = mvcInitializationReport;
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. " +
                    "\n\t> ? is null: ?" +
                    "\n\t> ? is null: ?", this.GetType(),
                    typeof(IMvcFrameworkObject), (mvcFrameworkObject == null),
                    typeof(IMvcInitializationReport), (mvcInitializationReport == null));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonTurnInformationReport">
        /// </param>
        public void BeginDecisionProcess(ITalonTurnReport talonTurnInformationReport)
        {
            if (talonTurnInformationReport != null)
            {
                IHopliteInformationReport hopliteInformationReport = talonTurnInformationReport
                    .GetTalonInformationReport().GetHopliteInformationReport();
                this.determiningActionReport = true;
                logger.Debug("Using ? to determine action!", hopliteInformationReport);
                switch (hopliteInformationReport.GetControllerId())
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
                        logger.Error("Unable to DetermineActionReport. ? is not supported", typeof(ControllerIdEnum), hopliteInformationReport.GetControllerId());
                        break;
                }
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. " +
                    "\n\t>? is null.", new StackFrame().GetMethod().Name, typeof(ITalonTurnReport));
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
