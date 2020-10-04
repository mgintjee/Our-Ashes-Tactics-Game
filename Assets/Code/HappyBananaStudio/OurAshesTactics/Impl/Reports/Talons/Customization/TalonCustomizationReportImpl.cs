/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Customization;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Reports.Talons.Customization
{
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
            this.phalanxEmblemSchemeReport = phalanxEmblemSchemeReport;
            this.factionColorSchemeReport = factionColorSchemeReport;
            this.phalanxColorSchemeReport = phalanxColorSchemeReport;
        }

        public IColorSchemeReport GetFactionColorSchemeReport()
        {
            return this.factionColorSchemeReport;
        }

        public IEmblemSchemeReport GetFactionEmblemSchemeReport()
        {
            return this.factionEmblemSchemeReport;
        }

        public IColorSchemeReport GetPhalanxColorSchemeReport()
        {
            return this.phalanxColorSchemeReport;
        }

        public IEmblemSchemeReport GetPhalanxEmblemSchemeReport()
        {
            return this.phalanxEmblemSchemeReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return this.GetType().Name + ":" +
                "\n" + typeof(IColorSchemeReport).Name + "=" + this.GetFactionColorSchemeReport() +
                ", " + typeof(IEmblemSchemeReport).Name + "=" + this.GetFactionEmblemSchemeReport() +
                "\n" + typeof(IColorSchemeReport).Name + "=" + this.GetPhalanxColorSchemeReport() +
                ", " + typeof(IEmblemSchemeReport).Name + "=" + this.GetPhalanxEmblemSchemeReport();
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
            /// The ITalonCustomizationReport
            /// </returns>
            public ITalonCustomizationReport Build()
            {
                HashSet<string> invalidReasons = this.IsInvalid();
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
            private HashSet<string> IsInvalid()
            {
                // Default an empty Set: String
                HashSet<string> argumentExceptionSet = new HashSet<string>();
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