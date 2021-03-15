using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Views.Customizations.Colors.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Views.Customizations.Emblems.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Views.Customizations.Reports.Api;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Views.Customizations.Reports.Impl
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct TalonCustomizationReport
        : ITalonCustomizationReport
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
        private TalonCustomizationReport(IColorSchemeReport colorSchemeReport, IEmblemSchemeReport emblemSchemeReport)
        {
            this.colorSchemeReport = colorSchemeReport;
            this.emblemSchemeReport = emblemSchemeReport;
        }

        /// <inheritdoc/>
        IColorSchemeReport ITalonCustomizationReport.GetColorSchemeReport()
        {
            return this.colorSchemeReport;
        }

        /// <inheritdoc/>
        IEmblemSchemeReport ITalonCustomizationReport.GetEmblemSchemeReport()
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
            public ITalonCustomizationReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Object
                    return new TalonCustomizationReport(this.colorSchemeReport, this.emblemSchemeReport);
                }
                throw ExceptionUtil.Arguments.Build("Unable to construct ?. Invalid Parameters. ?",
                    this.GetType(), string.Join("\n", invalidReasons));
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