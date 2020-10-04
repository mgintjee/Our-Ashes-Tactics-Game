/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Hoplites;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Attributes;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Reports.Talons
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct TalonInformationReportImpl
        : ITalonInformationReport
    {
        // Todo
        private readonly IHopliteReport hopliteReport;

        // Todo
        private readonly ITalonAttributesReport talonAttributesReport;

        // Todo
        private readonly ITalonIdentificationReport talonIdentificationReport;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonAttributesReport">
        /// </param>
        /// <param name="talonIdentificationReport">
        /// </param>
        private TalonInformationReportImpl(IHopliteReport hopliteReport,
            ITalonAttributesReport talonAttributesReport,
            ITalonIdentificationReport talonIdentificationReport)
        {
            this.hopliteReport = hopliteReport;
            this.talonAttributesReport = talonAttributesReport;
            this.talonIdentificationReport = talonIdentificationReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public IHopliteReport GetHopliteReport()
        {
            return this.hopliteReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public ITalonAttributesReport GetTalonAttributesReport()
        {
            return this.talonAttributesReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public ITalonIdentificationReport GetTalonIdentificationReport()
        {
            return this.talonIdentificationReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return this.GetType().Name + ":" +
                "\n\t>" + this.GetTalonIdentificationReport() +
                "\n\t>" + this.GetTalonAttributesReport();
        }

        /// <summary>
        /// Builder class for this report
        /// </summary>
        public class Builder
        {
            // Todo
            private IHopliteReport hopliteReport = null;

            // Todo
            private ITalonAttributesReport talonAttributesReport = null;

            // Todo
            private ITalonIdentificationReport talonIdentificationReport = null;

            /// <summary>
            /// Build the report with the set parameters
            /// </summary>
            /// <returns>
            /// The report interface
            /// </returns>
            public ITalonInformationReport Build()
            {
                HashSet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new TalonInformationReportImpl(this.hopliteReport,
                        this.talonAttributesReport, this.talonIdentificationReport);
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Set the value of the IHopliteReport
            /// </summary>
            /// <param name="hopliteReport">
            /// The IHopliteReport to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetHopliteReport(IHopliteReport hopliteReport)
            {
                this.hopliteReport = hopliteReport;
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
            /// Set the value of the ITalonIdentificationReport
            /// </summary>
            /// <param name="talonIdentificationReport">
            /// The ITalonIdentificationReport to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetTalonIdentificationReport(ITalonIdentificationReport talonIdentificationReport)
            {
                this.talonIdentificationReport = talonIdentificationReport;
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
                // Check that talonAttributesReport has been set
                if (this.talonAttributesReport == null)
                {
                    argumentExceptionSet.Add(typeof(ITalonAttributesReport).Name + " has not been set");
                }
                // Check that talonIdentificationReport has been set
                if (this.talonIdentificationReport == null)
                {
                    argumentExceptionSet.Add(typeof(ITalonIdentificationReport).Name + " has not been set");
                }
                // Check that hopliteReport has been set
                if (this.hopliteReport == null)
                {
                    argumentExceptionSet.Add(typeof(IHopliteReport).Name + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}