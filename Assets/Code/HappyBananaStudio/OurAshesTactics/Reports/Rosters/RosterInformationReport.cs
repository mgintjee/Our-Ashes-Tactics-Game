/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Faction;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Rosters;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Exceptions;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Reports.Rosters

{
    /// <summary>
    /// Todo
    /// </summary>
    public struct RosterInformationReport
        : IRosterInformationReport
    {
        // Todo
        private readonly HashSet<ITalonIdentificationReport> activeTalonIdentificationReportSet;

        // Todo
        private readonly HashSet<IFactionReport> factionReportSet;

        // Todo
        private readonly HashSet<ITalonIdentificationReport> totalTalonIdentificationReportSet;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="activeTalonIdentificationReportSet">
        /// </param>
        /// <param name="totalTalonIdentificationReportSet">
        /// </param>
        /// <param name="factionReportSet">
        /// </param>
        private RosterInformationReport(HashSet<ITalonIdentificationReport> activeTalonIdentificationReportSet,
            HashSet<ITalonIdentificationReport> totalTalonIdentificationReportSet,
            HashSet<IFactionReport> factionReportSet)
        {
            this.activeTalonIdentificationReportSet = activeTalonIdentificationReportSet;
            this.totalTalonIdentificationReportSet = totalTalonIdentificationReportSet;
            this.factionReportSet = factionReportSet;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public HashSet<ITalonIdentificationReport> GetActiveTalonIdentificationReportSet()
        {
            return new HashSet<ITalonIdentificationReport>(this.activeTalonIdentificationReportSet);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public HashSet<IFactionReport> GetFactionReportSet()
        {
            return new HashSet<IFactionReport>(this.factionReportSet);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public HashSet<ITalonIdentificationReport> GetTotalTalonIdentificationReportSet()
        {
            return new HashSet<ITalonIdentificationReport>(this.totalTalonIdentificationReportSet);
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
                "\n\t>Set: " + typeof(IFactionReport).Name + "=[" +
                string.Join("\n\t\t>", this.factionReportSet) +
                "\n]";
        }

        /// <summary>
        /// Builder class for this report
        /// </summary>
        public class Builder
        {
            // Todo
            private HashSet<ITalonIdentificationReport> activeTalonIdentificationReportSet = null;

            // Todo
            private HashSet<IFactionReport> factionReportSet = null;

            // Todo
            private HashSet<ITalonIdentificationReport> totalTalonIdentificationReportSet = null;

            /// <summary>
            /// Build the RosterInformationReport with the set parameters
            /// </summary>
            /// <returns>
            /// The IRosterInformationReport
            /// </returns>
            public IRosterInformationReport Build()
            {
                HashSet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new RosterInformationReport(this.activeTalonIdentificationReportSet,
                        this.totalTalonIdentificationReportSet, this.factionReportSet);
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
            public Builder SetActiveTalonIdentificationReportSet(HashSet<ITalonIdentificationReport> activeTalonIdentificationReportSet)
            {
                this.activeTalonIdentificationReportSet = activeTalonIdentificationReportSet;
                return this;
            }

            /// <summary>
            /// Set the value of the Set: IFactionReport
            /// </summary>
            /// <param name="factionReportSet">
            /// The Set: IFactionReport to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetFactionReportSet(HashSet<IFactionReport> factionReportSet)
            {
                this.factionReportSet = factionReportSet;
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
            public Builder SetTotalTalonIdentificationReportSet(HashSet<ITalonIdentificationReport> totalTalonIdentificationReportSet)
            {
                this.totalTalonIdentificationReportSet = totalTalonIdentificationReportSet;
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
                // Check that factionReportSet has been set
                if (this.factionReportSet == null)
                {
                    argumentExceptionSet.Add("Set: " + typeof(IFactionReport).Name + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}