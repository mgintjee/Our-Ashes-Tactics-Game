

namespace HappyBananaStudio.OurAshes.Tactics.Impl.MVCs.Models.Reports
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Maps.Games.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Api.MVCs.Models.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Api.Rosters.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Exceptions;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct MvcModelInformationReportImpl
        : IMvcModelInformationReport
    {
        // Todo
        private readonly IGameMapInformationReport gameMapInformationReport;

        // Todo
        private readonly IRosterInformationReport rosterInformationReport;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="gameMapInformationReport">
        /// </param>
        /// <param name="rosterInformationReport">
        /// </param>
        private MvcModelInformationReportImpl(IGameMapInformationReport gameMapInformationReport, IRosterInformationReport rosterInformationReport)
        {
            this.gameMapInformationReport = gameMapInformationReport;
            this.rosterInformationReport = rosterInformationReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return this.GetType().Name + ":" +
                "\n\t>" + this.gameMapInformationReport +
                "\n\t>" + this.rosterInformationReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IGameMapInformationReport IMvcModelInformationReport.GetGameMapInformationReport()
        {
            return this.gameMapInformationReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IRosterInformationReport IMvcModelInformationReport.GetRosterInformationReport()
        {
            return this.rosterInformationReport;
        }

        /// <summary>
        /// Builder class for this report
        /// </summary>
        public class Builder
        {
            // Todo
            private IGameMapInformationReport gameMapInformationReport = null;

            // Todo
            private IRosterInformationReport rosterInformationReport = null;

            /// <summary>
            /// Build the report with the set parameters
            /// </summary>
            /// <returns>
            /// The interface report
            /// </returns>
            public IMvcModelInformationReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new MvcModelInformationReportImpl(this.gameMapInformationReport, this.rosterInformationReport);
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Set the value of IGameMapInformationReport
            /// </summary>
            /// <param name="gameMapInformationReport">
            /// The IGameMapInformationReport to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetGameMapInformationReports(IGameMapInformationReport gameMapInformationReport)
            {
                this.gameMapInformationReport = gameMapInformationReport;
                return this;
            }

            /// <summary>
            /// Set the value of IRosterInformationReport
            /// </summary>
            /// <param name="rosterInformationReport">
            /// The IRosterInformationReport to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetRosterInformationReport(IRosterInformationReport rosterInformationReport)
            {
                this.rosterInformationReport = rosterInformationReport;
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
                // Check that gameMapInformationReport has been set
                if (this.gameMapInformationReport == null)
                {
                    argumentExceptionSet.Add(typeof(IGameMapInformationReport).Name + " has not been set");
                }
                // Check that rosterInformationReport has been set
                if (this.rosterInformationReport == null)
                {
                    argumentExceptionSet.Add(typeof(IRosterInformationReport).Name + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}
