namespace HappyBananaStudio.OurAshes.Tactics.Impl.Talons.Reports.Customization
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Customization;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Exceptions;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct CustomizationReportImpl
        : ICustomizationReport
    {
        // Todo
        private readonly IColorSchemeReport colorSchemeReport;

        // Todo
        private readonly IEmblemSchemeReport emblemSchemeReport;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="colorSchemeReport">
        /// </param>
        /// <param name="emblemSchemeReport">
        /// </param>
        private CustomizationReportImpl(IColorSchemeReport colorSchemeReport, IEmblemSchemeReport emblemSchemeReport)
        {
            this.colorSchemeReport = colorSchemeReport;
            this.emblemSchemeReport = emblemSchemeReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return this.GetType().Name + ": " +
                "\n" + this.colorSchemeReport +
                "\n" + this.emblemSchemeReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IColorSchemeReport ICustomizationReport.GetColorSchemeReport()
        {
            return this.colorSchemeReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IEmblemSchemeReport ICustomizationReport.GetEmblemSchemeReport()
        {
            return this.emblemSchemeReport;
        }

        /// <summary>
        /// Builder class for this report
        /// </summary>
        public class Builder
        {
            // Todo
            private IColorSchemeReport colorSchemeReport = null;

            // Todo
            private IEmblemSchemeReport emblemSchemeReport = null;

            /// <summary>
            /// Build the report implementation with the set parameters
            /// </summary>
            /// <returns>
            /// The report interface
            /// </returns>
            public ICustomizationReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new CustomizationReportImpl(this.colorSchemeReport, this.emblemSchemeReport);
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Set the value of the colorSchemeReport
            /// </summary>
            /// <param name="colorSchemeReport">
            /// The IColorSchemeReport to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetColorSchemeReport(IColorSchemeReport colorSchemeReport)
            {
                this.colorSchemeReport = colorSchemeReport;
                return this;
            }

            /// <summary>
            /// Set the value of the emblemSchemeReport
            /// </summary>
            /// <param name="emblemSchemeReport">
            /// The IEmblemSchemeReport to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetEmblemSchemeReport(IEmblemSchemeReport emblemSchemeReport)
            {
                this.emblemSchemeReport = emblemSchemeReport;
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
                // Check that colorSchemeReport has been set
                if (this.colorSchemeReport == null)
                {
                    argumentExceptionSet.Add(typeof(IColorSchemeReport).Name + " has not been set");
                }
                // Check that emblemSchemeReport has been set
                if (this.emblemSchemeReport == null)
                {
                    argumentExceptionSet.Add(typeof(IEmblemSchemeReport).Name + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}
