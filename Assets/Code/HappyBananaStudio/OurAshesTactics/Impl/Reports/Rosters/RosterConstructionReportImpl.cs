/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Rosters;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Reports.Rosters
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct RosterConstructionReportImpl
        : IRosterConstructionReport
    {
        // Todo
        private readonly Dictionary<FactionIdEnum, HashSet<PhalanxIdEnum>> factionIdPhalanxIdSetDictionary;

        // Todo
        private readonly Dictionary<PhalanxIdEnum, HashSet<ITalonConstructionReport>> phalanxIdTalonConstructionReportDictionary;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="phalanxIdTalonConstructionReportDictionary">
        /// </param>
        /// <param name="factionIdPhalanxIdSetDictionary">
        /// </param>
        public RosterConstructionReportImpl(
            Dictionary<PhalanxIdEnum, HashSet<ITalonConstructionReport>> phalanxIdTalonConstructionReportDictionary,
            Dictionary<FactionIdEnum, HashSet<PhalanxIdEnum>> factionIdPhalanxIdSetDictionary)
        {
            this.phalanxIdTalonConstructionReportDictionary = phalanxIdTalonConstructionReportDictionary;
            this.factionIdPhalanxIdSetDictionary = factionIdPhalanxIdSetDictionary;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public Dictionary<FactionIdEnum, HashSet<PhalanxIdEnum>> GetFactionIdPhalanxIdSetDictionary()
        {
            return new Dictionary<FactionIdEnum, HashSet<PhalanxIdEnum>>(this.factionIdPhalanxIdSetDictionary);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public Dictionary<PhalanxIdEnum, HashSet<ITalonConstructionReport>> GetPhalanxIdTalonConstructionReportDictionary()
        {
            return new Dictionary<PhalanxIdEnum, HashSet<ITalonConstructionReport>>(this.phalanxIdTalonConstructionReportDictionary);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            string factionIdPhalanxIdSetDictionaryString = "Dictionary(" + typeof(FactionIdEnum).Name + ", Set: " + typeof(PhalanxIdEnum).Name + "):";

            string phalanxIdTalonConstructionReportDictionaryString = "Dictionary(" + typeof(PhalanxIdEnum).Name + ", Set: " + typeof(ITalonConstructionReport).Name + "): [";

            foreach (FactionIdEnum factionId in this.factionIdPhalanxIdSetDictionary.Keys)
            {
                factionIdPhalanxIdSetDictionaryString += "\n\t\t>" + typeof(FactionIdEnum).Name + "=" + factionId +
                    ", Set: " + typeof(PhalanxIdEnum).Name + "=[" +
                    "\n\t\t>" + string.Join("\n\t\t\t>", this.factionIdPhalanxIdSetDictionary[factionId]) + "" +
                    "\n\t]";
            }
            foreach (PhalanxIdEnum phalanxId in this.phalanxIdTalonConstructionReportDictionary.Keys)
            {
                phalanxIdTalonConstructionReportDictionaryString += "\n\t\t>" + typeof(PhalanxIdEnum).Name + "=" + phalanxId +
                    ", Set: " + typeof(ITalonConstructionReport).Name + "=[" +
                    "\n\t\t>" + string.Join("\n\t\t\t>", this.phalanxIdTalonConstructionReportDictionary[phalanxId]) + "" +
                    "\n\t]";
            }

            return this.GetType().Name + ":" +
                "\n\t>" + factionIdPhalanxIdSetDictionaryString + "" +
                "\n]" +
                "\n\t>" + phalanxIdTalonConstructionReportDictionaryString + "" +
                "\n]";
        }

        /// <summary>
        /// Builder class for this report
        /// </summary>
        public class Builder
        {
            // Todo
            private Dictionary<FactionIdEnum, HashSet<PhalanxIdEnum>> factionIdPhalanxIdSetDictionary = null;

            // Todo
            private Dictionary<PhalanxIdEnum, HashSet<ITalonConstructionReport>> phalanxIdTalonConstructionReportDictionary = null;

            /// <summary>
            /// Build the RosterConstructionReport with the set parameters
            /// </summary>
            /// <returns>
            /// The IRosterConstructionReport
            /// </returns>
            public IRosterConstructionReport Build()
            {
                HashSet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new RosterConstructionReportImpl(this.phalanxIdTalonConstructionReportDictionary, this.factionIdPhalanxIdSetDictionary);
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Set the value of the Dictionary: FactionId, Set: PhalanxId
            /// </summary>
            /// <param name="factionIdPhalanxIdSetDictionary">
            /// The Dictionary: FactionId, Set: PhalanxId to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetFactionIdPhalanxIdSetDictionary(Dictionary<FactionIdEnum, HashSet<PhalanxIdEnum>> factionIdPhalanxIdSetDictionary)
            {
                this.factionIdPhalanxIdSetDictionary = new Dictionary<FactionIdEnum, HashSet<PhalanxIdEnum>>(factionIdPhalanxIdSetDictionary);
                return this;
            }

            /// <summary>
            /// Set the value of the Dictionary: PhalanxId, Set: TalonConstructionReport
            /// </summary>
            /// <param name="phalanxIdTalonConstructionReportDictionary">
            /// The Dictionary: PhalanxId, Set: TalonConstructionReport to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetPhalanxIdTalonConstructionReportDictionary(Dictionary<PhalanxIdEnum, HashSet<ITalonConstructionReport>> phalanxIdTalonConstructionReportDictionary)
            {
                this.phalanxIdTalonConstructionReportDictionary = new Dictionary<PhalanxIdEnum, HashSet<ITalonConstructionReport>>(phalanxIdTalonConstructionReportDictionary);
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
                // Check that phalanxIdTalonConstructionReportDictionary has been set
                if (this.phalanxIdTalonConstructionReportDictionary == null)
                {
                    argumentExceptionSet.Add("Dictionary(" + typeof(PhalanxIdEnum).Name + ", Set: " + typeof(ITalonConstructionReport) + ") has not been set");
                }
                // Check that factionIdPhalanxIdSetDictionary has been set
                if (this.factionIdPhalanxIdSetDictionary == null)
                {
                    argumentExceptionSet.Add("Dictionary(" + typeof(FactionIdEnum).Name + ", Set: " + typeof(PhalanxIdEnum) + ") has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}