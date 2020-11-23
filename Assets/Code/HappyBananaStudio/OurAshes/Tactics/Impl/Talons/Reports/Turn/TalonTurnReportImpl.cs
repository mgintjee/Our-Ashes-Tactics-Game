namespace HappyBananaStudio.OurAshes.Tactics.Impl.Talons.Reports.Turn
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Actions.Orders;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Information;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Turn;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Exceptions;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct TalonTurnReportImpl
        : ITalonTurnReport
    {
        // Todo
        private readonly ISet<ITalonActionOrderReport> talonActionOrderReportSet;

        // Todo
        private readonly ITalonInformationReport talonInformationReport;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonActionOrderReportSet">
        /// </param>
        /// <param name="talonInformationReport">
        /// </param>
        private TalonTurnReportImpl(ISet<ITalonActionOrderReport> talonActionOrderReportSet,
            ITalonInformationReport talonInformationReport)
        {
            this.talonActionOrderReportSet = talonActionOrderReportSet;
            this.talonInformationReport = talonInformationReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return this.GetType().Name + ":" +
                "\n\t>" + this.talonInformationReport +
                "\n\t>Set: " + typeof(ITalonActionOrderReport).Name + "=[\n\t\t>" +
                string.Join("\n\t\t>", this.talonActionOrderReportSet) +
                "\n]";
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ISet<ITalonActionOrderReport> ITalonTurnReport.GetPossibleTalonActionOrderReportSet()
        {
            return new HashSet<ITalonActionOrderReport>(this.talonActionOrderReportSet);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ITalonInformationReport ITalonTurnReport.GetTalonInformationReport()
        {
            return this.talonInformationReport;
        }

        /// <summary>
        /// Builder class for this report
        /// </summary>
        public class Builder
        {
            // Todo
            private ISet<ITalonActionOrderReport> talonActionOrderReportSet = null;

            // Todo
            private ITalonInformationReport talonInformationReport = null;

            /// <summary>
            /// Build the report with the set parameters
            /// </summary>
            /// <returns>
            /// The report interface
            /// </returns>
            public ITalonTurnReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new TalonTurnReportImpl(this.talonActionOrderReportSet, this.talonInformationReport);
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Set the value of the Set: ITalonActionOrderReport
            /// </summary>
            /// <param name="talonActionOrderReportSet">
            /// The Set: ITalonActionOrderReport to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetTalonActionOrderReportSet(ISet<ITalonActionOrderReport> talonActionOrderReportSet)
            {
                this.talonActionOrderReportSet = talonActionOrderReportSet;
                return this;
            }

            /// <summary>
            /// Set the value of the ITalonInformationReport
            /// </summary>
            /// <param name="talonInformationReport">
            /// The ITalonInformationReport to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetTalonInformationReport(ITalonInformationReport talonInformationReport)
            {
                this.talonInformationReport = talonInformationReport;
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
                // Check that talonActionOrderReportSet has been set
                if (this.talonActionOrderReportSet == null)
                {
                    argumentExceptionSet.Add("Set: " + typeof(ITalonActionOrderReport).Name + " has not been set");
                }
                // Check that talonInformationReport has been set
                if (this.talonInformationReport == null)
                {
                    argumentExceptionSet.Add(typeof(ITalonInformationReport).Name + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}