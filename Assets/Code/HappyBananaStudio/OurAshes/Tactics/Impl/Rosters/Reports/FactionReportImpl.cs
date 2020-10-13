/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>

namespace HappyBananaStudio.OurAshesTactics.Impl.Reports.Faction
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Rosters.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Factions.Enums;
    using HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct FactionReportImpl
        : IRosterFactionReport
    {
        // Todo
        private readonly FactionIdEnum factionId;

        // Todo
        private readonly ISet<IRosterPhalanxReport> rosterPhalanxReportSet;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="factionIdenum">
        /// </param>
        /// <param name="rosterPhalanxReportSet">
        /// </param>
        private FactionReportImpl(FactionIdEnum factionIdenum, ISet<IRosterPhalanxReport> rosterPhalanxReportSet)
        {
            this.factionId = factionIdenum;
            this.rosterPhalanxReportSet = rosterPhalanxReportSet;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return this.GetType().Name + ":" +
                "\n\t>" + typeof(FactionIdEnum).Name + "=" + this.factionId +
                "\n\t>Set: " + typeof(IRosterPhalanxReport).Name + "=[" + string.Join("\n\t\t>", this.rosterPhalanxReportSet)
                + "\n]";
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        FactionIdEnum IRosterFactionReport.GetFactionId()
        {
            return this.factionId;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ISet<IRosterPhalanxReport> IRosterFactionReport.GetPhalanxReportSet()
        {
            return new HashSet<IRosterPhalanxReport>(this.rosterPhalanxReportSet);
        }

        /// <summary>
        /// Builder class for this report
        /// </summary>
        public class Builder
        {
            // Todo
            private FactionIdEnum factionId = FactionIdEnum.None;

            // Todo
            private ISet<IRosterPhalanxReport> rosterFactionReportSet = null;

            /// <summary>
            /// Build the FactionReport with the set parameters
            /// </summary>
            /// <returns>
            /// The IFactionReport
            /// </returns>
            public IRosterFactionReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new FactionReportImpl(this.factionId, this.rosterFactionReportSet);
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Set the value of the FactionIdEnum
            /// </summary>
            /// <param name="factionId">
            /// The FactionIdEnum to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetFactionId(FactionIdEnum factionId)
            {
                this.factionId = factionId;
                return this;
            }

            /// <summary>
            /// Set the value of the Set: IPhalanxReport
            /// </summary>
            /// <param name="rosterFactionReportSet">
            /// The Set: IPhalanxReport to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetRosterPhalanxReportSet(ISet<IRosterPhalanxReport> rosterFactionReportSet)
            {
                this.rosterFactionReportSet = rosterFactionReportSet;
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
                // Check that factionId has been set
                if (this.factionId == FactionIdEnum.None)
                {
                    argumentExceptionSet.Add(typeof(FactionIdEnum).Name + " has not been set");
                }
                // Check that phalanxReportSet has been set
                if (this.rosterFactionReportSet == null)
                {
                    argumentExceptionSet.Add("Set:" + typeof(IRosterPhalanxReport).Name + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}
