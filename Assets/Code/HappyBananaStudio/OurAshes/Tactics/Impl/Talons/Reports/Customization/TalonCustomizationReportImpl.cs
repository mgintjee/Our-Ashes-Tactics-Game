/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>
/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

namespace HappyBananaStudio.OurAshesTactics.Impl.Reports.Talons.Customization
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Customization;
    using HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct TalonCustomizationReportImpl
        : ITalonCustomizationReport
    {
        // Todo
        private readonly IColorSchemeReport factionColorSchemeReport;

        // Todo
        private readonly IEmblemSchemeReport factionEmblemSchemeReport;

        // Todo
        private readonly IColorSchemeReport phalanxColorSchemeReport;

        // Todo
        private readonly IEmblemSchemeReport phalanxEmblemSchemeReport;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="factionEmblemSchemeReport">
        /// </param>
        /// <param name="phalanxEmblemSchemeReport">
        /// </param>
        /// <param name="factionColorSchemeReport">
        /// </param>
        /// <param name="phalanxColorSchemeReport">
        /// </param>
        private TalonCustomizationReportImpl(IEmblemSchemeReport factionEmblemSchemeReport,
            IEmblemSchemeReport phalanxEmblemSchemeReport,
            IColorSchemeReport factionColorSchemeReport,
            IColorSchemeReport phalanxColorSchemeReport)
        {
            this.factionEmblemSchemeReport = factionEmblemSchemeReport;
            this.factionColorSchemeReport = factionColorSchemeReport;
            this.phalanxEmblemSchemeReport = phalanxEmblemSchemeReport;
            this.phalanxColorSchemeReport = phalanxColorSchemeReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return this.GetType().Name + ":" +
                "\nFaction: " + typeof(IColorSchemeReport).Name + "=" + this.factionColorSchemeReport +
                ", " + typeof(IEmblemSchemeReport).Name + "=" + this.factionEmblemSchemeReport +
                "\nPhalanx: " + typeof(IColorSchemeReport).Name + "=" + this.phalanxColorSchemeReport +
                ", " + typeof(IEmblemSchemeReport).Name + "=" + this.phalanxEmblemSchemeReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IColorSchemeReport ITalonCustomizationReport.GetFactionColorSchemeReport()
        {
            return this.factionColorSchemeReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IEmblemSchemeReport ITalonCustomizationReport.GetFactionEmblemSchemeReport()
        {
            return this.factionEmblemSchemeReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IColorSchemeReport ITalonCustomizationReport.GetPhalanxColorSchemeReport()
        {
            return this.phalanxColorSchemeReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IEmblemSchemeReport ITalonCustomizationReport.GetPhalanxEmblemSchemeReport()
        {
            return this.phalanxEmblemSchemeReport;
        }

        /// <summary>
        /// Builder class for this report
        /// </summary>
        public class Builder
        {
            // Todo
            private IColorSchemeReport factionColorSchemeReport = null;

            // Todo
            private IEmblemSchemeReport factionEmblemSchemeReport = null;

            // Todo
            private IColorSchemeReport phalanxColorSchemeReport = null;

            // Todo
            private IEmblemSchemeReport phalanxEmblemSchemeReport = null;

            /// <summary>
            /// Build the TalonCustomizationReportImpl with the set parameters
            /// </summary>
            /// <returns>
            /// The report inteface
            /// </returns>
            public ITalonCustomizationReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new TalonCustomizationReportImpl(this.factionEmblemSchemeReport, this.phalanxEmblemSchemeReport,
                        this.factionColorSchemeReport, this.phalanxColorSchemeReport);
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Set the value of the factionColorSchemeReport
            /// </summary>
            /// <param name="factionColorSchemeReport">
            /// The IColorSchemeReport to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetFactionColorSchemeReport(IColorSchemeReport factionColorSchemeReport)
            {
                this.factionColorSchemeReport = factionColorSchemeReport;
                return this;
            }

            /// <summary>
            /// Set the value of the factionEmblemSchemeReport
            /// </summary>
            /// <param name="factionEmblemSchemeReport">
            /// The IEmblemSchemeReport to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetFactionEmblemSchemeReport(IEmblemSchemeReport factionEmblemSchemeReport)
            {
                this.factionEmblemSchemeReport = factionEmblemSchemeReport;
                return this;
            }

            /// <summary>
            /// Set the value of the phalanxColorSchemeReport
            /// </summary>
            /// <param name="phalanxColorSchemeReport">
            /// The IColorSchemeReport to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetPhalanxColorSchemeReport(IColorSchemeReport phalanxColorSchemeReport)
            {
                this.phalanxColorSchemeReport = phalanxColorSchemeReport;
                return this;
            }

            /// <summary>
            /// Set the value of the phalanxEmblemSchemeReport
            /// </summary>
            /// <param name="phalanxEmblemSchemeReport">
            /// The IEmblemSchemeReport to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetPhalanxEmblemSchemeReoprt(IEmblemSchemeReport phalanxEmblemSchemeReport)
            {
                this.phalanxEmblemSchemeReport = phalanxEmblemSchemeReport;
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
                // Check that factionColorSchemeReport has been set
                if (this.factionColorSchemeReport == null)
                {
                    argumentExceptionSet.Add("Faction " + typeof(IColorSchemeReport).Name + " has not been set");
                }
                // Check that phalanxColorSchemeReport has been set
                if (this.phalanxColorSchemeReport == null)
                {
                    argumentExceptionSet.Add("Phalanx " + typeof(IColorSchemeReport).Name + " has not been set");
                }
                // Check that factionEmblemSchemeReport has been set
                if (this.factionEmblemSchemeReport == null)
                {
                    argumentExceptionSet.Add("Faction " + typeof(IEmblemSchemeReport).Name + " has not been set");
                }
                // Check that phalanxEmblemSchemeReport has been set
                if (this.phalanxEmblemSchemeReport == null)
                {
                    argumentExceptionSet.Add("Phalanx " + typeof(IColorSchemeReport).Name + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}
