/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>
/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

namespace HappyBananaStudio.OurAshesTactics.Impl.Reports.Talons
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Hoplites.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Construction;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Customization;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Information;
    using HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct TalonInformationReportImpl
        : ITalonInformationReport
    {
        // Todo
        private readonly IHopliteInformationReport hopliteInformationReport;

        // Todo
        private readonly ITalonAttributesReport talonAttributesReport;

        // Todo
        private readonly ITalonConstructionReport talonConstructionReport;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="hopliteInformationReport">
        /// </param>
        /// <param name="talonAttributesReport">
        /// </param>
        /// <param name="talonIdentificationReport">
        /// </param>
        private TalonInformationReportImpl(IHopliteInformationReport hopliteInformationReport,
            ITalonAttributesReport talonAttributesReport,
            ITalonConstructionReport talonConstructionReport)
        {
            this.hopliteInformationReport = hopliteInformationReport;
            this.talonAttributesReport = talonAttributesReport;
            this.talonConstructionReport = talonConstructionReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return this.GetType().Name + ":" +
                "\n\t>" + this.talonConstructionReport.GetTalonIdentificationReport() +
                "\n\t>" + this.talonAttributesReport +
                "\n\t>" + this.hopliteInformationReport +
                "\n\t>" + this.talonConstructionReport.GetTalonCustomizationReport();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IHopliteInformationReport ITalonInformationReport.GetHopliteInformationReport()
        {
            return this.hopliteInformationReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ITalonAttributesReport ITalonInformationReport.GetTalonAttributesReport()
        {
            return this.talonAttributesReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ITalonCustomizationReport ITalonInformationReport.GetTalonCustomizationReport()
        {
            return this.talonConstructionReport.GetTalonCustomizationReport();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ITalonIdentificationReport ITalonInformationReport.GetTalonIdentificationReport()
        {
            return this.talonConstructionReport.GetTalonIdentificationReport();
        }

        /// <summary>
        /// Builder class for this report
        /// </summary>
        public class Builder
        {
            // Todo
            private IHopliteInformationReport hopliteInformationReport;

            // Todo
            private ITalonAttributesReport talonAttributesReport;

            // Todo
            private ITalonConstructionReport talonConstructionReport;

            /// <summary>
            /// Build the report with the set parameters
            /// </summary>
            /// <returns>
            /// The report interface
            /// </returns>
            public ITalonInformationReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new TalonInformationReportImpl(this.hopliteInformationReport,
                        this.talonAttributesReport, this.talonConstructionReport);
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Set the value of the IHopliteInformationReport
            /// </summary>
            /// <param name="hopliteInformationReport">
            /// The IHopliteInformationReport to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetHopliteInformationReport(IHopliteInformationReport hopliteInformationReport)
            {
                this.hopliteInformationReport = hopliteInformationReport;
                return this;
            }

            /// <summary>
            /// Set the value of the ITalonAttributesReport
            /// </summary>
            /// <param name="talonAttributesReport">
            /// The ITalonAttributesReport to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetTalonAttributesReport(ITalonAttributesReport talonAttributesReport)
            {
                this.talonAttributesReport = talonAttributesReport;
                return this;
            }

            /// <summary>
            /// Set the value of the ITalonConstructionReport
            /// </summary>
            /// <param name="talonConstructionReport">
            /// The ITalonConstructionReport to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetTalonConstructionReport(ITalonConstructionReport talonConstructionReport)
            {
                this.talonConstructionReport = talonConstructionReport;
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
                // Check that talonAttributesReport has been set
                if (this.talonAttributesReport == null)
                {
                    argumentExceptionSet.Add(typeof(ITalonAttributesReport).Name + " has not been set");
                }
                // Check that talonIdentificationReport has been set
                if (this.talonConstructionReport == null)
                {
                    argumentExceptionSet.Add(typeof(ITalonConstructionReport).Name + " has not been set");
                }
                // Check that hopliteInformationReport has been set
                if (this.hopliteInformationReport == null)
                {
                    argumentExceptionSet.Add(typeof(IHopliteInformationReport).Name + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}
