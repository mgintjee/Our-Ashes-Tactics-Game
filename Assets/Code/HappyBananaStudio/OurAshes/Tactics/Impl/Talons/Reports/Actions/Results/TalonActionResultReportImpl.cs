
namespace HappyBananaStudio.OurAshes.Tactics.Impl.Talons.Reports.Actions.Results
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Actions.Orders;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Actions.Results;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Exceptions;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct TalonActionResultReportImpl
        : ITalonActionResultReport
    {
        // Todo
        private readonly ITalonAttributesReport actingTalonAttributesReport;

        // Todo
        private readonly ITalonActionOrderReport talonActionOrderReport;

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
            this.actingTalonAttributesReport = talonAttributesReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return this.GetType().Name + ":" +
                "\n\t>" + this.talonActionOrderReport +
                "\n\t>" + this.actingTalonAttributesReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ITalonAttributesReport ITalonActionResultReport.GetActingTalonAttributesReport()
        {
            return this.actingTalonAttributesReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ITalonActionOrderReport ITalonActionResultReport.GetTalonActionOrder()
        {
            return this.talonActionOrderReport;
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
            /// Build the report with the set parameters
            /// </summary>
            /// <returns>
            /// The report interface
            /// </returns>
            public ITalonActionResultReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
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
            private ISet<string> IsInvalid()
            {
                // Default an empty Set: String
                ISet<string> argumentExceptionSet = new HashSet<string>();
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
