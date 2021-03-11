namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Controllers.Objects.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Controllers.AIs.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Controllers.AIs.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Controllers.AIs.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Controllers.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Talons.Managers;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Orders.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Orders.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Reports.Phalanxes.Api;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// MvcController Object Impl
    /// </summary>
    public class MvcControllerObject
        : IMvcControllerObject
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLogger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly SimulationType simulationType;

        // Todo
        private readonly ISet<IPhalanxReport> phalanxReports;

        // Todo
        private readonly IDictionary<AIType, IAIObject> aiObjectDictionary;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="simulationType"></param>
        private MvcControllerObject(SimulationType simulationType, ISet<IPhalanxReport> phalanxReports)
        {
            this.simulationType = simulationType;
            this.phalanxReports = phalanxReports;
            this.aiObjectDictionary = new Dictionary<AIType, IAIObject>()
            {
                { AIType.Random, new AIObjectRandom() }
            };
        }

        /// <inheritdoc/>
        ITalonOrderReport IMvcControllerObject.DetermineTalonOrderReport(TalonCallSign talonCallSign)
        {
            ITalonOrderReport talonOrderReport = null;
            ISet<ITalonOrderReport> talonOrderReportSet = TalonRosterManager.GetTalonOrderReportSet(talonCallSign);
            int fireCount = 0;
            int waitCount = 0;
            int moveCount = 0;
            foreach (ITalonOrderReport logTalonOrderReport in talonOrderReportSet)
            {
                switch (logTalonOrderReport.GetOrderType())
                {
                    case OrderType.Fire:
                        fireCount++;
                        break;

                    case OrderType.Move:
                        moveCount++;
                        break;

                    case OrderType.Wait:
                        waitCount++;
                        break;
                }
            }
            logger.Debug("Total=?. Fire=?, Move=?, Wait=?", talonOrderReportSet.Count, fireCount, moveCount, waitCount);
            switch (this.simulationType)
            {
                case SimulationType.BlackBox:
                case SimulationType.WhiteBox:
                    // Todo: Have some manager for each talons controller type and ai type
                    // Check the controller type (Human/AI)
                    // Then send it to the respective channel
                    talonOrderReport = this.aiObjectDictionary[AIType.Random]
                        .DetermineBestOrderReport(talonCallSign, talonOrderReportSet);
                    break;

                case SimulationType.Interactive:
                    // Todo: Check if the phalanx that this talon is associated with is an ai or not
                    break;

                default:
                    logger.Debug("Unable to ?. ? is not supported.",
                    new StackFrame().GetMethod().Name, this.simulationType);
                    break;
            }
            logger.Debug("Determined ?", talonOrderReport);
            return talonOrderReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private SimulationType simulationType = SimulationType.None;

            // Todo
            private ISet<IPhalanxReport> phalanxReports = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IMvcControllerObject Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Object
                    return new MvcControllerObject(this.simulationType, this.phalanxReports);
                }
                else
                {
                    throw ExceptionUtil.Arguments.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="simulationType"></param>
            /// <returns></returns>
            public Builder SetSimulationType(SimulationType simulationType)
            {
                this.simulationType = simulationType;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="phalanxReports"></param>
            /// <returns></returns>
            public Builder SetPhalanxReports(ISet<IPhalanxReport> phalanxReports)
            {
                if (phalanxReports != null)
                {
                    this.phalanxReports = new HashSet<IPhalanxReport>(phalanxReports);
                }
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            private ISet<string> IsInvalid()
            {
                // Default an empty Set: String
                ISet<string> argumentExceptionSet = new HashSet<string>();
                if (this.simulationType == SimulationType.None)
                {
                    argumentExceptionSet.Add(typeof(SimulationType).Name + " can not be none.");
                }
                if (this.phalanxReports == null)
                {
                    argumentExceptionSet.Add("Set: " + typeof(IPhalanxReport).Name + " cannot be null.");
                }
                return argumentExceptionSet;
            }
        }

        /*
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
                throw ExceptionUtil.Argument.Build("Unable to construct ?. Invalid Parameters. " +
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
                    case ControllerType.Human:
                    case ControllerType.Poacher:
                    case ControllerType.Sniper:
                    case ControllerType.Random:
                    case ControllerType.Tank:
                    case ControllerType.Survivor:
                        this.actionReportToOutput = ArtificialIntelligenceRandomImpl.DetermineBestAction(talonTurnInformationReport.GetPossibleTalonActionOrderReportSet());
                        this.determiningActionReport = false;
                        break;

                    default:
                        logger.Error("Unable to DetermineActionReport. ? is not supported", typeof(ControllerType), hopliteInformationReport.GetControllerId());
                        break;
                }
            }
            else
            {
                throw ExceptionUtil.Argument.Build("Unable to ?. Invalid Parameters. " +
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
        */
    }
}