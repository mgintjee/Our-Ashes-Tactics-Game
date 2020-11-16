namespace HappyBananaStudio.OurAshes.Tactics.Impl.Talons.Reports.Customization
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Customization;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Exceptions;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct TalonDualCustomizationReportImpl
        : ITalonDualCustomizationReport
    {
        // Todo
        private readonly ICustomizationReport primaryCustomizationReport;

        // Todo
        private readonly ICustomizationReport secondaryCustomizationReport;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="primaryCustomizationReport">
        /// </param>
        /// <param name="secondaryCustomizationReport">
        /// </param>
        private TalonDualCustomizationReportImpl(ICustomizationReport primaryCustomizationReport, ICustomizationReport secondaryCustomizationReport)
        {
            this.primaryCustomizationReport = primaryCustomizationReport;
            this.secondaryCustomizationReport = secondaryCustomizationReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ICustomizationReport ITalonCustomizationReport.GetPrimaryCustomizationReport()
        {
            return this.primaryCustomizationReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ICustomizationReport ITalonDualCustomizationReport.GetSecondaryCustomizationReport()
        {
            return this.secondaryCustomizationReport;
        }

        /// <summary>
        /// Builder class for this report
        /// </summary>
        public class Builder
        {
            // Todo
            private ICustomizationReport primaryCustomizationReport = null;

            // Todo
            private ICustomizationReport secondaryCustomizationReport = null;

            /// <summary>
            /// Build the report implementation with the set parameters
            /// </summary>
            /// <returns>
            /// The report interface
            /// </returns>
            public ITalonDualCustomizationReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new TalonDualCustomizationReportImpl(this.primaryCustomizationReport, this.secondaryCustomizationReport);
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Set the value of the primaryCustomizationReport
            /// </summary>
            /// <param name="primaryCustomizationReport">
            /// The ICustomizationReport to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetPrimaryCustomizationReport(ICustomizationReport primaryCustomizationReport)
            {
                this.primaryCustomizationReport = primaryCustomizationReport;
                return this;
            }

            /// <summary>
            /// Set the value of the secondaryCustomizationReport
            /// </summary>
            /// <param name="secondaryCustomizationReport">
            /// The ICustomizationReport to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetSecondaryCustomizationReport(ICustomizationReport secondaryCustomizationReport)
            {
                this.secondaryCustomizationReport = secondaryCustomizationReport;
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
                // Check that primaryCustomizationReport has been set
                if (this.primaryCustomizationReport == null)
                {
                    argumentExceptionSet.Add("Primary " + typeof(ICustomizationReport).Name + " has not been set");
                }
                // Check that secondaryCustomizationReport has been set
                if (this.secondaryCustomizationReport == null)
                {
                    argumentExceptionSet.Add("Secondary " + typeof(ICustomizationReport).Name + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}
