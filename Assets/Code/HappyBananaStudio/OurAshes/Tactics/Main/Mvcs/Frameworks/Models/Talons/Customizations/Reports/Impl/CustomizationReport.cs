namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Customizations.Reports.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Customizations.Colors.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Customizations.Emblems.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Customizations.Reports.Api;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct CustomizationReport
        : ICustomizationReport
    {
        // Todo
        private readonly IColorSchemeReport colorSchemeReport;

        // Todo
        private readonly IEmblemSchemeReport emblemSchemeReport;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="colorSchemeReport"></param>
        /// <param name="emblemSchemeReport"></param>
        private CustomizationReport(IColorSchemeReport colorSchemeReport, IEmblemSchemeReport emblemSchemeReport)
        {
            this.colorSchemeReport = colorSchemeReport;
            this.emblemSchemeReport = emblemSchemeReport;
        }

        /// <inheritdoc/>
        IColorSchemeReport ICustomizationReport.GetColorSchemeReport()
        {
            return this.colorSchemeReport;
        }

        /// <inheritdoc/>
        IEmblemSchemeReport ICustomizationReport.GetEmblemSchemeReport()
        {
            return this.emblemSchemeReport;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: \n\t>{1}, \n\t>{2}",
                this.GetType().Name, this.colorSchemeReport, this.emblemSchemeReport);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private IColorSchemeReport colorSchemeReport = null;

            // Todo
            private IEmblemSchemeReport emblemSchemeReport = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public ICustomizationReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Object
                    return new CustomizationReport(this.colorSchemeReport, this.emblemSchemeReport);
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
            public Builder SetColorSchemeReport(IColorSchemeReport colorSchemeReport)
            {
                this.colorSchemeReport = colorSchemeReport;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="emblemSchemeReport"></param>
            /// <returns></returns>
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