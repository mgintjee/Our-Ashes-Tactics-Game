namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Constructions.Reports.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Constructions.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Customizations.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Reports.Api;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct TalonConstructionReport
        : ITalonConstructionReport
    {
        // Todo
        private readonly TalonCallSign talonCallSign;

        // Todo
        private readonly ICustomizationReport customizationReport;

        // Todo
        private readonly ITalonLoadoutReport talonLoadoutReport;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="customizationReport"></param>
        /// <param name="talonLoadoutReport"></param>
        private TalonConstructionReport(TalonCallSign talonCallSign,
            ICustomizationReport customizationReport, ITalonLoadoutReport talonLoadoutReport)
        {
            this.talonCallSign = talonCallSign;
            this.customizationReport = customizationReport;
            this.talonLoadoutReport = talonLoadoutReport;
        }

        /// <inheritdoc/>
        ICustomizationReport ITalonConstructionReport.GetCustomizationReport()
        {
            return this.customizationReport;
        }

        /// <inheritdoc/>

        TalonCallSign ITalonConstructionReport.GetTalonCallSign()
        {
            return this.talonCallSign;
        }

        /// <inheritdoc/>
        ITalonLoadoutReport ITalonConstructionReport.GetTalonLoadoutReport()
        {
            return this.talonLoadoutReport;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: {1}={2}" +
                "\n\t>{3}" +
                "\n\t>{4}",
                this.GetType().Name, typeof(TalonCallSign).Name, this.talonCallSign,
                this.customizationReport, this.talonLoadoutReport); ;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private TalonCallSign talonCallSign = TalonCallSign.None;

            // Todo
            private ICustomizationReport customizationReport = null;

            // Todo
            private ITalonLoadoutReport talonLoadoutReport = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public ITalonConstructionReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Object
                    return new TalonConstructionReport(this.talonCallSign,
                        this.customizationReport, this.talonLoadoutReport);
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
            /// <param name="talonCallSign"></param>
            /// <returns></returns>
            public Builder SetTalonCallSign(TalonCallSign talonCallSign)
            {
                this.talonCallSign = talonCallSign;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="customizationReport"></param>
            /// <returns></returns>
            public Builder SetCustomizationReport(ICustomizationReport customizationReport)
            {
                this.customizationReport = customizationReport;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="talonLoadoutReport"></param>
            /// <returns></returns>
            public Builder SetTalonLoadoutReport(ITalonLoadoutReport talonLoadoutReport)
            {
                this.talonLoadoutReport = talonLoadoutReport;
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
                // Check that talonCallSign has been set
                if (this.talonCallSign == TalonCallSign.None)
                {
                    argumentExceptionSet.Add(typeof(TalonCallSign).Name + " cannot be none.");
                }
                // Check that customizationReport has been set
                if (this.customizationReport == null)
                {
                    argumentExceptionSet.Add(typeof(ICustomizationReport).Name + " cannot be null.");
                }
                // Check that talonLoadoutReport has been set
                if (this.talonLoadoutReport == null)
                {
                    argumentExceptionSet.Add(typeof(ICustomizationReport).Name + " cannot be null.");
                }
                return argumentExceptionSet;
            }
        }
    }
}