namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Constructions.Reports.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Constructions.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Customizations.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Reports.Api;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct TalonConstructionReportImpl
        : ITalonConstructionReport
    {
        // Todo
        private readonly ICustomizationReport customizationReport;

        // Todo
        private readonly ITalonLoadoutReport talonLoadoutReport;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="customizationReport"></param>
        /// <param name="talonLoadoutReport"></param>
        private TalonConstructionReportImpl(ICustomizationReport customizationReport, ITalonLoadoutReport talonLoadoutReport)
        {
            this.customizationReport = customizationReport;
            this.talonLoadoutReport = talonLoadoutReport;
        }

        /// <inheritdoc/>
        ICustomizationReport ITalonConstructionReport.GetCustomizationReport()
        {
            return this.customizationReport;
        }

        /// <inheritdoc/>
        ITalonLoadoutReport ITalonConstructionReport.GetTalonLoadoutReport()
        {
            return this.talonLoadoutReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
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
                    return new TalonConstructionReportImpl(this.customizationReport, this.talonLoadoutReport);
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
                // Check that customizationReport has been set
                if (this.customizationReport == null)
                {
                    argumentExceptionSet.Add(typeof(ICustomizationReport).Name + " has not been set");
                }
                // Check that talonLoadoutReport has been set
                if (this.talonLoadoutReport == null)
                {
                    argumentExceptionSet.Add(typeof(ITalonLoadoutReport).Name + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}