namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Controllers.Objects.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Loggers.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Loggers.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Controllers.Objects.Api;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// MvcController Object Impl
    /// </summary>
    public class MvcControllerObjectImpl
        : IMvcControllerObject
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLoggerImpl(new StackFrame().GetMethod().DeclaringType);

        private MvcControllerObjectImpl()
        {
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
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
                    return new MvcControllerObjectImpl();
                }
                else
                {
                    throw ExceptionUtil.Argument.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
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