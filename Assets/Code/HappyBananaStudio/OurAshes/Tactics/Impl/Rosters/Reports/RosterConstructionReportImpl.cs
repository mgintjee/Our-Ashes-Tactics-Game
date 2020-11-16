namespace HappyBananaStudio.OurAshes.Tactics.Impl.Rosters.Reports
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Rosters.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Construction;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Factions;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Phalanxes;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Exceptions;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct RosterConstructionReportImpl
        : IRosterConstructionReport
    {
        // Todo
        private readonly IDictionary<FactionId, ISet<PhalanxId>> factionIdPhalanxIdSetIDictionary;

        // Todo
        private readonly IDictionary<PhalanxId, ISet<ITalonConstructionReport>> phalanxIdTalonConstructionReportIDictionary;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="phalanxIdTalonConstructionReportIDictionary">
        /// </param>
        /// <param name="factionIdPhalanxIdSetIDictionary">
        /// </param>
        public RosterConstructionReportImpl(
            IDictionary<PhalanxId, ISet<ITalonConstructionReport>> phalanxIdTalonConstructionReportIDictionary,
            IDictionary<FactionId, ISet<PhalanxId>> factionIdPhalanxIdSetIDictionary)
        {
            this.phalanxIdTalonConstructionReportIDictionary = phalanxIdTalonConstructionReportIDictionary;
            this.factionIdPhalanxIdSetIDictionary = factionIdPhalanxIdSetIDictionary;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            string factionIdPhalanxIdSetIDictionaryString = "IDictionary(" + typeof(FactionId).Name + ", Set: " + typeof(PhalanxId).Name + "):";

            string phalanxIdTalonConstructionReportIDictionaryString = "IDictionary(" + typeof(PhalanxId).Name + ", Set: " + typeof(ITalonConstructionReport).Name + "): [";

            foreach (FactionId factionId in this.factionIdPhalanxIdSetIDictionary.Keys)
            {
                factionIdPhalanxIdSetIDictionaryString += "\n\t\t>" + typeof(FactionId).Name + "=" + factionId +
                    ", Set: " + typeof(PhalanxId).Name + "=[" +
                    "\n\t\t>" + string.Join("\n\t\t\t>", this.factionIdPhalanxIdSetIDictionary[factionId]) + "" +
                    "\n\t]";
            }
            foreach (PhalanxId phalanxId in this.phalanxIdTalonConstructionReportIDictionary.Keys)
            {
                phalanxIdTalonConstructionReportIDictionaryString += "\n\t\t>" + typeof(PhalanxId).Name + "=" + phalanxId +
                    ", Set: " + typeof(ITalonConstructionReport).Name + "=[" +
                    "\n\t\t>" + string.Join("\n\t\t\t>", this.phalanxIdTalonConstructionReportIDictionary[phalanxId]) + "" +
                    "\n\t]";
            }

            return this.GetType().Name + ":" +
                "\n\t>" + factionIdPhalanxIdSetIDictionaryString + "" +
                "\n]" +
                "\n\t>" + phalanxIdTalonConstructionReportIDictionaryString + "" +
                "\n]";
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IDictionary<FactionId, ISet<PhalanxId>> IRosterConstructionReport.GetFactionIdPhalanxIdSetIDictionary()
        {
            return new Dictionary<FactionId, ISet<PhalanxId>>(this.factionIdPhalanxIdSetIDictionary);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IDictionary<PhalanxId, ISet<ITalonConstructionReport>> IRosterConstructionReport.GetPhalanxIdTalonConstructionReportIDictionary()
        {
            return new Dictionary<PhalanxId, ISet<ITalonConstructionReport>>(this.phalanxIdTalonConstructionReportIDictionary);
        }

        /// <summary>
        /// Builder class for this report
        /// </summary>
        public class Builder
        {
            // Todo
            private IDictionary<FactionId, ISet<PhalanxId>> factionIdPhalanxIdSetIDictionary = null;

            // Todo
            private IDictionary<PhalanxId, ISet<ITalonConstructionReport>> phalanxIdTalonConstructionReportIDictionary = null;

            /// <summary>
            /// Build the RosterConstructionReport with the set parameters
            /// </summary>
            /// <returns>
            /// The report interface
            /// </returns>
            public IRosterConstructionReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new RosterConstructionReportImpl(this.phalanxIdTalonConstructionReportIDictionary,
                        this.factionIdPhalanxIdSetIDictionary);
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Set the value of the IDictionary: FactionId, Set: PhalanxId
            /// </summary>
            /// <param name="factionIdPhalanxIdSetIDictionary">
            /// The IDictionary: FactionId, Set: PhalanxId to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetFactionIdPhalanxIdSetDictionary(
                IDictionary<FactionId, ISet<PhalanxId>> factionIdPhalanxIdSetIDictionary)
            {
                this.factionIdPhalanxIdSetIDictionary =
                    new Dictionary<FactionId, ISet<PhalanxId>>(factionIdPhalanxIdSetIDictionary);
                return this;
            }

            /// <summary>
            /// Set the value of the IDictionary: PhalanxId, Set: TalonConstructionReport
            /// </summary>
            /// <param name="phalanxIdTalonConstructionReportIDictionary">
            /// The IDictionary: PhalanxId, Set: TalonConstructionReport to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetPhalanxIdTalonConstructionReportDictionary(
                IDictionary<PhalanxId, ISet<ITalonConstructionReport>> phalanxIdTalonConstructionReportIDictionary)
            {
                this.phalanxIdTalonConstructionReportIDictionary =
                    new Dictionary<PhalanxId, ISet<ITalonConstructionReport>>(phalanxIdTalonConstructionReportIDictionary);
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
                // Check that phalanxIdTalonConstructionReportIDictionary has been set
                if (this.phalanxIdTalonConstructionReportIDictionary == null)
                {
                    argumentExceptionSet.Add("IDictionary(" + typeof(PhalanxId).Name +
                        ", Set: " + typeof(ITalonConstructionReport) + ") has not been set");
                }
                // Check that factionIdPhalanxIdSetIDictionary has been set
                if (this.factionIdPhalanxIdSetIDictionary == null)
                {
                    argumentExceptionSet.Add("IDictionary(" + typeof(FactionId).Name +
                        ", Set: " + typeof(PhalanxId) + ") has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}
