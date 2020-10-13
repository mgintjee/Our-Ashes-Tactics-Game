/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>

namespace HappyBananaStudio.OurAshesTactics.Impl.Reports.Rosters
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Rosters.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Construction;
    using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Factions.Enums;
    using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Phalanxes.Enums;
    using HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct RosterConstructionReportImpl
        : IRosterConstructionReport
    {
        // Todo
        private readonly IDictionary<FactionIdEnum, ISet<PhalanxIdEnum>> factionIdPhalanxIdSetIDictionary;

        // Todo
        private readonly IDictionary<PhalanxIdEnum, ISet<ITalonConstructionReport>> phalanxIdTalonConstructionReportIDictionary;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="phalanxIdTalonConstructionReportIDictionary">
        /// </param>
        /// <param name="factionIdPhalanxIdSetIDictionary">
        /// </param>
        public RosterConstructionReportImpl(
            IDictionary<PhalanxIdEnum, ISet<ITalonConstructionReport>> phalanxIdTalonConstructionReportIDictionary,
            IDictionary<FactionIdEnum, ISet<PhalanxIdEnum>> factionIdPhalanxIdSetIDictionary)
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
            string factionIdPhalanxIdSetIDictionaryString = "IDictionary(" + typeof(FactionIdEnum).Name + ", Set: " + typeof(PhalanxIdEnum).Name + "):";

            string phalanxIdTalonConstructionReportIDictionaryString = "IDictionary(" + typeof(PhalanxIdEnum).Name + ", Set: " + typeof(ITalonConstructionReport).Name + "): [";

            foreach (FactionIdEnum factionId in this.factionIdPhalanxIdSetIDictionary.Keys)
            {
                factionIdPhalanxIdSetIDictionaryString += "\n\t\t>" + typeof(FactionIdEnum).Name + "=" + factionId +
                    ", Set: " + typeof(PhalanxIdEnum).Name + "=[" +
                    "\n\t\t>" + string.Join("\n\t\t\t>", this.factionIdPhalanxIdSetIDictionary[factionId]) + "" +
                    "\n\t]";
            }
            foreach (PhalanxIdEnum phalanxId in this.phalanxIdTalonConstructionReportIDictionary.Keys)
            {
                phalanxIdTalonConstructionReportIDictionaryString += "\n\t\t>" + typeof(PhalanxIdEnum).Name + "=" + phalanxId +
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
        IDictionary<FactionIdEnum, ISet<PhalanxIdEnum>> IRosterConstructionReport.GetFactionIdPhalanxIdSetIDictionary()
        {
            return new Dictionary<FactionIdEnum, ISet<PhalanxIdEnum>>(this.factionIdPhalanxIdSetIDictionary);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IDictionary<PhalanxIdEnum, ISet<ITalonConstructionReport>> IRosterConstructionReport.GetPhalanxIdTalonConstructionReportIDictionary()
        {
            return new Dictionary<PhalanxIdEnum, ISet<ITalonConstructionReport>>(this.phalanxIdTalonConstructionReportIDictionary);
        }

        /// <summary>
        /// Builder class for this report
        /// </summary>
        public class Builder
        {
            // Todo
            private IDictionary<FactionIdEnum, ISet<PhalanxIdEnum>> factionIdPhalanxIdSetIDictionary = null;

            // Todo
            private IDictionary<PhalanxIdEnum, ISet<ITalonConstructionReport>> phalanxIdTalonConstructionReportIDictionary = null;

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
            public Builder SetFactionIdPhalanxIdSetIDictionary(
                IDictionary<FactionIdEnum, ISet<PhalanxIdEnum>> factionIdPhalanxIdSetIDictionary)
            {
                this.factionIdPhalanxIdSetIDictionary =
                    new Dictionary<FactionIdEnum, ISet<PhalanxIdEnum>>(factionIdPhalanxIdSetIDictionary);
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
            public Builder SetPhalanxIdTalonConstructionReportIDictionary(
                IDictionary<PhalanxIdEnum, ISet<ITalonConstructionReport>> phalanxIdTalonConstructionReportIDictionary)
            {
                this.phalanxIdTalonConstructionReportIDictionary =
                    new Dictionary<PhalanxIdEnum, ISet<ITalonConstructionReport>>(phalanxIdTalonConstructionReportIDictionary);
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
                    argumentExceptionSet.Add("IDictionary(" + typeof(PhalanxIdEnum).Name +
                        ", Set: " + typeof(ITalonConstructionReport) + ") has not been set");
                }
                // Check that factionIdPhalanxIdSetIDictionary has been set
                if (this.factionIdPhalanxIdSetIDictionary == null)
                {
                    argumentExceptionSet.Add("IDictionary(" + typeof(FactionIdEnum).Name +
                        ", Set: " + typeof(PhalanxIdEnum) + ") has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}
