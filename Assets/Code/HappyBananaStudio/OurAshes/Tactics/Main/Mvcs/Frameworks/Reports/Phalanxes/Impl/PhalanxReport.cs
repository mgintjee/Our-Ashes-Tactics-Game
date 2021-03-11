namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Reports.Phalanxes.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Controllers.AIs.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Controllers.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Customizations.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Reports.Phalanxes.Api;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct PhalanxReport
        : IPhalanxReport
    {
        // Todo
        private readonly PhalanxCallSign phalanxCallSign;

        // Todo
        private readonly ControllerType controllerType;

        // Todo
        private readonly ICustomizationReport customizationReport;

        // Todo
        private readonly AIType aiType;

        // Todo
        private readonly ISet<TalonCallSign> talonCallSigns;

        // Todo
        private readonly ISet<PhalanxCallSign> phalanxCallSigns;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="phalanxCallSign"></param>
        /// <param name="controllerType"></param>
        /// <param name="customizationReport"></param>
        /// <param name="aiType"></param>
        /// <param name="talonCallSigns"></param>
        private PhalanxReport(PhalanxCallSign phalanxCallSign, ControllerType controllerType,
            ICustomizationReport customizationReport, AIType aiType,
            ISet<TalonCallSign> talonCallSigns, ISet<PhalanxCallSign> phalanxCallSigns)
        {
            this.phalanxCallSign = phalanxCallSign;
            this.controllerType = controllerType;
            this.customizationReport = customizationReport;
            this.aiType = aiType;
            this.talonCallSigns = talonCallSigns;
            this.phalanxCallSigns = phalanxCallSigns;
        }

        /// <inheritdoc/>
        AIType IPhalanxReport.GetAIType()
        {
            return this.aiType;
        }

        /// <inheritdoc/>
        ControllerType IPhalanxReport.GetControllerType()
        {
            return this.controllerType;
        }

        /// <inheritdoc/>
        ICustomizationReport IPhalanxReport.GetCustomizationReport()
        {
            return this.customizationReport;
        }

        /// <inheritdoc/>
        PhalanxCallSign IPhalanxReport.GetPhalanxCallSign()
        {
            return this.phalanxCallSign;
        }

        /// <inheritdoc/>
        ISet<TalonCallSign> IPhalanxReport.GetTalonCallSigns()
        {
            return new HashSet<TalonCallSign>(this.talonCallSigns);
        }

        /// <inheritdoc/>
        ISet<PhalanxCallSign> IPhalanxReport.GetFriendlyPhalanxCallSigns()
        {
            return new HashSet<PhalanxCallSign>(this.phalanxCallSigns);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: {1}={2}, {3}={4}, {5}={6}" +
                "\n\t>phalanxCallSigns=[{7}]" +
                "\n\t>talonCallSigns=[{8}]" +
                "\n\t>{9}",
                this.GetType().Name, typeof(PhalanxCallSign).Name, this.phalanxCallSign,
                typeof(ControllerType).Name, this.controllerType, typeof(AIType).Name, this.aiType,
                string.Join(", ", this.phalanxCallSigns),
                string.Join(", ", this.talonCallSigns),
                this.customizationReport);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private PhalanxCallSign phalanxCallSign = PhalanxCallSign.None;

            // Todo
            private ControllerType controllerType = ControllerType.None;

            // Todo
            private ICustomizationReport customizationReport = null;

            // Todo
            private AIType aiType = AIType.None;

            // Todo
            private ISet<TalonCallSign> talonCallSigns = null;

            // Todo
            private ISet<PhalanxCallSign> phalanxCallSigns = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IPhalanxReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Object
                    return new PhalanxReport(this.phalanxCallSign, this.controllerType, this.customizationReport,
                        this.aiType, this.talonCallSigns, this.phalanxCallSigns);
                }
                else
                {
                    throw ExceptionUtil.Arguments.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="phalanxCallSign"></param>
            /// <returns></returns>
            public Builder SetPhalanxCallSign(PhalanxCallSign phalanxCallSign)
            {
                this.phalanxCallSign = phalanxCallSign;
                return this;
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="controllerType"></param>
            /// <returns></returns>
            public Builder SetControllerType(ControllerType controllerType)
            {
                this.controllerType = controllerType;
                return this;
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="customizationReport"></param>
            /// <returns></returns>
            public Builder SetCustomizationReport(ICustomizationReport customizationReport)
            {
                this.customizationReport = customizationReport;
                return this;
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="aiType"></param>
            /// <returns></returns>
            public Builder SetAIType(AIType aiType)
            {
                this.aiType = aiType;
                return this;
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="talonCallSigns"></param>
            /// <returns></returns>
            public Builder SetTalonCallSigns(ISet<TalonCallSign> talonCallSigns)
            {
                if (talonCallSigns != null)
                {
                    this.talonCallSigns = talonCallSigns;
                }
                return this;
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="phalanxCallSigns"></param>
            /// <returns></returns>
            public Builder SetPhalanxCallSigns(ISet<PhalanxCallSign> phalanxCallSigns)
            {
                if (phalanxCallSigns != null)
                {
                    this.phalanxCallSigns = phalanxCallSigns;
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
                // Check that phalanxCallSign has been set
                if (this.phalanxCallSign == PhalanxCallSign.None)
                {
                    argumentExceptionSet.Add(typeof(PhalanxCallSign) + " can not be none.");
                }
                // Check that controllerType has been set
                if (this.controllerType == ControllerType.None)
                {
                    argumentExceptionSet.Add(typeof(ControllerType) + " can not be none.");
                }
                else
                {
                    // Check that controllerType is for Human
                    if (this.controllerType == ControllerType.Human)
                    {
                        // Check that aiType has been set
                        if (this.aiType != AIType.None)
                        {
                            argumentExceptionSet.Add(typeof(AIType) + " can not be " +
                                this.aiType + " with " + this.controllerType);
                        }
                    }
                    // Check that controllerType is for Human
                    else if (this.controllerType == ControllerType.AI)
                    {
                        // Check that aiType has been set
                        if (this.aiType == AIType.None)
                        {
                            argumentExceptionSet.Add(typeof(AIType) + " can not be " +
                                this.aiType + " with " + this.controllerType);
                        }
                    }
                }
                // Check that customizationReport has been set
                if (this.customizationReport == null)
                {
                    argumentExceptionSet.Add(typeof(ICustomizationReport) + " can not be none.");
                }
                // Check that talonCallSignSet has been set
                if (this.talonCallSigns == null)
                {
                    argumentExceptionSet.Add("Set: " + typeof(TalonCallSign) + " can not be none.");
                }
                // Check that phalanxCallSignSet has been set
                if (this.phalanxCallSigns == null)
                {
                    argumentExceptionSet.Add("Set: " + typeof(PhalanxCallSign) + " can not be none.");
                }
                return argumentExceptionSet;
            }
        }
    }
}