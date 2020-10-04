/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Action;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Attributes;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Reports.Talons.Action
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct TalonActionResultReportImpl
        : ITalonActionResultReport
    {
        // Todo
        private readonly ITalonActionOrderReport talonActionOrderReport;

        // Todo
        private readonly ITalonAttributesReport talonAttributesReport;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonActionOrderReport">
        /// </param>
        /// <param name="talonAttributesReport">
        /// </param>
        private TalonActionResultReportImpl(ITalonActionOrderReport talonActionOrderReport,
            ITalonAttributesReport talonAttributesReport)
        {
            this.talonActionOrderReport = talonActionOrderReport;
            this.talonAttributesReport = talonAttributesReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public ITalonActionOrderReport GetTalonActionOrder()
        {
            return this.talonActionOrderReport;
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
        public override string ToString()
        {
            return this.GetType().Name + ":" +
                "\n\t>" + this.GetTalonActionOrder() +
                "\n\t>" + this.GetTalonAttributesReport();
        }

        /// <summary>
        /// Builder class for this report
        /// </summary>
        public class Builder
        {
            // Todo
            private ITalonActionOrderReport talonActionOrderReport = null;

            // Todo
            private ITalonAttributesReport talonAttributesReport = null;

            /// <summary>
            /// Build the TalonActionResultReport with the set parameters
            /// </summary>
            /// <returns>
            /// The ITalonActionResultReport
            /// </returns>
            public ITalonActionResultReport Build()
            {
                HashSet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new TalonActionResultReportImpl(this.talonActionOrderReport, this.talonAttributesReport);
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Set the value of the ITalonActionOrderReport
            /// </summary>
            /// <param name="talonActionOrderReport">
            /// The ITalonActionOrderReport to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetTalonActionOrderReport(ITalonActionOrderReport talonActionOrderReport)
            {
                this.talonActionOrderReport = talonActionOrderReport;
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
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            private HashSet<string> IsInvalid()
            {
                // Default an empty Set: String
                HashSet<string> argumentExceptionSet = new HashSet<string>();
                // Check that talonActionOrderReport has been set
                if (this.talonActionOrderReport == null)
                {
                    argumentExceptionSet.Add(typeof(ITalonActionOrderReport).Name + " has not been set");
                }
                // Check that talonAttributesReport has been set
                if (this.talonAttributesReport == null)
                {
                    argumentExceptionSet.Add(typeof(ITalonAttributesReport).Name + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}