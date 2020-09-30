/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Faction;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Phalanxs;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Exceptions;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Reports.Faction
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct FactionReport
        : IFactionReport
    {
        // Todo
        private readonly FactionIdEnum factionId;

        // Todo
        private readonly HashSet<IPhalanxReport> phalanxReportSet;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="factionIdenum">
        /// </param>
        /// <param name="phalanxReportSet">
        /// </param>
        private FactionReport(FactionIdEnum factionIdenum, HashSet<IPhalanxReport> phalanxReportSet)
        {
            this.factionId = factionIdenum;
            this.phalanxReportSet = new HashSet<IPhalanxReport>(phalanxReportSet);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public FactionIdEnum GetFactionId()
        {
            return this.factionId;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public HashSet<IPhalanxReport> GetPhalanxReportSet()
        {
            return new HashSet<IPhalanxReport>(this.phalanxReportSet);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return this.GetType().Name + ":" +
                "\n\t>" + typeof(FactionIdEnum).Name + "=" + this.GetFactionId() +
                "\n\t>Set: " + typeof(IPhalanxReport).Name + "=[" + string.Join("\n\t\t>", this.phalanxReportSet)
                + "\n]";
        }

        /// <summary>
        /// Builder class for this report
        /// </summary>
        public class Builder
        {
            // Todo
            private FactionIdEnum factionId = FactionIdEnum.None;

            // Todo
            private HashSet<IPhalanxReport> phalanxReportSet = null;

            /// <summary>
            /// Build the FactionReport with the set parameters
            /// </summary>
            /// <returns>
            /// The IFactionReport
            /// </returns>
            public IFactionReport Build()
            {
                HashSet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new FactionReport(this.factionId, this.phalanxReportSet);
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
            /// <param name="phalanxReportSet">
            /// The Set: IPhalanxReport to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetPhalanxId(HashSet<IPhalanxReport> phalanxReportSet)
            {
                this.phalanxReportSet = phalanxReportSet;
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
                // Check that factionId has been set
                if (this.factionId == FactionIdEnum.None)
                {
                    argumentExceptionSet.Add(typeof(FactionIdEnum).Name + " has not been set");
                }
                // Check that phalanxReportSet has been set
                if (this.phalanxReportSet == null)
                {
                    argumentExceptionSet.Add("Set:" + typeof(IPhalanxReport).Name + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}