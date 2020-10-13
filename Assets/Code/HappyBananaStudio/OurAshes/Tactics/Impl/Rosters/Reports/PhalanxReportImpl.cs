/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>

namespace HappyBananaStudio.OurAshesTactics.Impl.Reports.Phalanx
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Rosters.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Information;
    using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Factions.Enums;
    using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Phalanxes.Enums;
    using HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct PhalanxReportImpl
        : IRosterPhalanxReport
    {
        // Todo
        private readonly FactionIdEnum factionId;

        // Todo
        private readonly PhalanxIdEnum phalanxId;

        // Todo
        private readonly ISet<ITalonIdentificationReport> talonIdentificationReportSet;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="factionId">
        /// </param>
        /// <param name="phalanxId">
        /// </param>
        /// <param name="talonIdentificationReportSet">
        /// </param>
        private PhalanxReportImpl(FactionIdEnum factionId, PhalanxIdEnum phalanxId,
            ISet<ITalonIdentificationReport> talonIdentificationReportSet)
        {
            this.factionId = factionId;
            this.phalanxId = phalanxId;
            this.talonIdentificationReportSet = talonIdentificationReportSet;
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
                "\n\t>" + typeof(PhalanxIdEnum).Name + "=" + this.phalanxId +
                "\n\t>Set: " + typeof(ITalonIdentificationReport).Name + "=[" +
                string.Join("\n\t\t>", this.talonIdentificationReportSet) +
                "\n]";
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        FactionIdEnum IRosterPhalanxReport.GetFactionId()
        {
            return this.factionId;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        PhalanxIdEnum IRosterPhalanxReport.GetPhalanxId()
        {
            return this.phalanxId;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ISet<ITalonIdentificationReport> IRosterPhalanxReport.GetTalonIdentificationReportSet()
        {
            return new HashSet<ITalonIdentificationReport>(this.talonIdentificationReportSet);
        }

        /// <summary>
        /// Builder class for this report
        /// </summary>
        public class Builder
        {
            // Todo
            private FactionIdEnum factionId = FactionIdEnum.None;

            // Todo
            private PhalanxIdEnum phalanxId = PhalanxIdEnum.None;

            // Todo
            private ISet<ITalonIdentificationReport> talonIdentificationReportSet = null;

            /// <summary>
            /// Build the PhalanxReport with the set parameters
            /// </summary>
            /// <returns>
            /// The report interface
            /// </returns>
            public IRosterPhalanxReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new PhalanxReportImpl(this.factionId, this.phalanxId, this.talonIdentificationReportSet);
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
            /// Set the value of the PhalanxIdEnum
            /// </summary>
            /// <param name="phalanxId">
            /// The PhalanxIdEnum to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetPhalanxId(PhalanxIdEnum phalanxId)
            {
                this.phalanxId = phalanxId;
                return this;
            }

            /// <summary>
            /// Set the value of the Set: ITalonIdentificationReport
            /// </summary>
            /// <param name="talonIdentificationReportSet">
            /// The Set: ITalonIdentificationReport to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetTalonIdentificationReport(ISet<ITalonIdentificationReport> talonIdentificationReportSet)
            {
                this.talonIdentificationReportSet = new HashSet<ITalonIdentificationReport>(talonIdentificationReportSet);
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
                // Check that phalanxId has been set
                if (this.phalanxId == PhalanxIdEnum.None)
                {
                    argumentExceptionSet.Add(typeof(PhalanxIdEnum).Name + " has not been set");
                }
                // Check that talonIdentificationReportSet has been set
                if (this.talonIdentificationReportSet == null)
                {
                    argumentExceptionSet.Add("Set: " + typeof(ITalonIdentificationReport).Name + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}
