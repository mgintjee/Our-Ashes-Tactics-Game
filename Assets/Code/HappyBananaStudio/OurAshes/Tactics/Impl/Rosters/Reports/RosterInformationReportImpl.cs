

namespace HappyBananaStudio.OurAshes.Tactics.Impl.Rosters.Reports
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Rosters.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Information;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Exceptions;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct RosterInformationReportImpl
        : IRosterInformationReport
    {
        // Todo
        private readonly ISet<ITalonIdentificationReport> activeTalonIdentificationReportSet;

        // Todo
        private readonly ISet<IRosterFactionReport> rosterFactionReportSet;

        // Todo
        private readonly ISet<ITalonIdentificationReport> totalTalonIdentificationReportSet;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="activeTalonIdentificationReportSet">
        /// </param>
        /// <param name="totalTalonIdentificationReportSet">
        /// </param>
        /// <param name="rosterFactionReportSet">
        /// </param>
        private RosterInformationReportImpl(ISet<ITalonIdentificationReport> activeTalonIdentificationReportSet,
            ISet<ITalonIdentificationReport> totalTalonIdentificationReportSet,
            ISet<IRosterFactionReport> rosterFactionReportSet)
        {
            this.activeTalonIdentificationReportSet = activeTalonIdentificationReportSet;
            this.totalTalonIdentificationReportSet = totalTalonIdentificationReportSet;
            this.rosterFactionReportSet = rosterFactionReportSet;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return this.GetType().Name + ":" +
                "\n\t>Active Set: " + typeof(ITalonIdentificationReport).Name + "=[" +
                string.Join("\n\t\t>", this.activeTalonIdentificationReportSet) +
                "\n]" +
                "\n\t>Total Set: " + typeof(ITalonIdentificationReport).Name + "=[" +
                string.Join("\n\t\t>", this.totalTalonIdentificationReportSet) +
                "\n]" +
                "\n\t>Set: " + typeof(IRosterFactionReport).Name + "=[" +
                string.Join("\n\t\t>", this.rosterFactionReportSet) +
                "\n]";
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ISet<ITalonIdentificationReport> IRosterInformationReport.GetActiveTalonIdentificationReportSet()
        {
            return new HashSet<ITalonIdentificationReport>(this.activeTalonIdentificationReportSet);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ISet<ITalonIdentificationReport> IRosterInformationReport.GetTotalTalonIdentificationReportSet()
        {
            return new HashSet<ITalonIdentificationReport>(this.totalTalonIdentificationReportSet);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ISet<IRosterFactionReport> IRosterInformationReport.GetRosterFactionReportSet()
        {
            return new HashSet<IRosterFactionReport>(this.rosterFactionReportSet);
        }

        /// <summary>
        /// Builder class for this report
        /// </summary>
        public class Builder
        {
            // Todo
            private ISet<ITalonIdentificationReport> activeTalonIdentificationReportSet = null;

            // Todo
            private ISet<IRosterFactionReport> rosterFactionReportSet = null;

            // Todo
            private ISet<ITalonIdentificationReport> totalTalonIdentificationReportSet = null;

            /// <summary>
            /// Build the report with the set parameters
            /// </summary>
            /// <returns>
            /// The report interface
            /// </returns>
            public IRosterInformationReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new RosterInformationReportImpl(this.activeTalonIdentificationReportSet,
                        this.totalTalonIdentificationReportSet, this.rosterFactionReportSet);
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Set the value of the active Set: ITalonIdentificationReport
            /// </summary>
            /// <param name="activeTalonIdentificationReportSet">
            /// The active Set: ITalonIdentificationReport to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetActiveTalonIdentificationReportSet(ISet<ITalonIdentificationReport> activeTalonIdentificationReportSet)
            {
                this.activeTalonIdentificationReportSet = activeTalonIdentificationReportSet;
                return this;
            }

            /// <summary>
            /// Set the value of the Set: IRosterFactionReport
            /// </summary>
            /// <param name="rosterFactionReportSet">
            /// The Set: IRosterFactionReport to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetFactionReportSet(ISet<IRosterFactionReport> rosterFactionReportSet)
            {
                this.rosterFactionReportSet = rosterFactionReportSet;
                return this;
            }

            /// <summary>
            /// Set the value of the total Set: ITalonIdentificationReport
            /// </summary>
            /// <param name="totalTalonIdentificationReportSet">
            /// The total Set: ITalonIdentificationReport to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetTotalTalonIdentificationReportSet(ISet<ITalonIdentificationReport> totalTalonIdentificationReportSet)
            {
                this.totalTalonIdentificationReportSet = totalTalonIdentificationReportSet;
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
                // Check that activeTalonIdentificationReportSet has been set
                if (this.activeTalonIdentificationReportSet == null)
                {
                    argumentExceptionSet.Add("Active Set: " + typeof(ITalonIdentificationReport).Name + " has not been set");
                }
                // Check that totalTalonIdentificationReportSet has been set
                if (this.totalTalonIdentificationReportSet == null)
                {
                    argumentExceptionSet.Add("Total Set: " + typeof(ITalonIdentificationReport).Name + " has not been set");
                }
                // Check that rosterFactionReportSet has been set
                if (this.rosterFactionReportSet == null)
                {
                    argumentExceptionSet.Add("Set: " + typeof(IRosterFactionReport).Name + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}
