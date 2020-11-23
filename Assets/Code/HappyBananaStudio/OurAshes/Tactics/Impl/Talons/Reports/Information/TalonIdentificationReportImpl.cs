namespace HappyBananaStudio.OurAshes.Tactics.Impl.Talons.Reports.Information
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Information;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Factions;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Phalanxes;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Talons;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Exceptions;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct TalonIdentificationReportImpl
        : ITalonIdentificationReport
    {
        // Todo
        private readonly CallSign callSign;

        // Todo
        private readonly FactionId factionId;

        // Todo
        private readonly PhalanxId phalanxId;

        // Todo
        private readonly TalonModelId talonModelId;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonId">
        /// </param>
        /// <param name="phalanxId">
        /// </param>
        /// <param name="callSign">
        /// </param>
        private TalonIdentificationReportImpl(TalonModelId talonId, FactionId factionId,
            PhalanxId phalanxId, CallSign callSign)
        {
            this.talonModelId = talonId;
            this.phalanxId = phalanxId;
            this.callSign = callSign;
            this.factionId = factionId;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return this.GetType().Name + ": " + this.factionId + ", " + this.phalanxId + ", " + this.callSign + ", " + this.talonModelId;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        CallSign ITalonIdentificationReport.GetCallSign()
        {
            return this.callSign;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        FactionId ITalonIdentificationReport.GetFactionId()
        {
            return this.factionId;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        PhalanxId ITalonIdentificationReport.GetPhalanxId()
        {
            return this.phalanxId;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        TalonModelId ITalonIdentificationReport.GetTalonModelId()
        {
            return this.talonModelId;
        }

        /// <summary>
        /// Builder class for this report
        /// </summary>
        public class Builder
        {
            // Todo
            private CallSign callSign = CallSign.None;

            // Todo
            private FactionId factionId = FactionId.None;

            // Todo
            private PhalanxId phalanxId = PhalanxId.None;

            // Todo
            private TalonModelId talonId = TalonModelId.None;

            /// <summary>
            /// Build the report with the set parameters
            /// </summary>
            /// <returns>
            /// The report interface
            /// </returns>
            public ITalonIdentificationReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new TalonIdentificationReportImpl(this.talonId, this.factionId, this.phalanxId, this.callSign);
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Set the value of the CallSignEnum
            /// </summary>
            /// <param name="callSign">
            /// The CallSignEnum to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetCallSign(CallSign callSign)
            {
                this.callSign = callSign;
                return this;
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
            public Builder SetFactionId(FactionId factionId)
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
            public Builder SetPhalanxId(PhalanxId phalanxId)
            {
                this.phalanxId = phalanxId;
                return this;
            }

            /// <summary>
            /// Set the value of the TalonIdEnum
            /// </summary>
            /// <param name="talonId">
            /// The TalonIdEnum to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetTalonModelId(TalonModelId talonId)
            {
                this.talonId = talonId;
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
                if (this.factionId == FactionId.None)
                {
                    argumentExceptionSet.Add(typeof(FactionId).Name + " has not been set");
                }
                // Check that talonId has been set
                if (this.talonId == TalonModelId.None)
                {
                    argumentExceptionSet.Add(typeof(TalonModelId).Name + " has not been set");
                }
                // Check that phalanxId has been set
                if (this.phalanxId == PhalanxId.None)
                {
                    argumentExceptionSet.Add(typeof(PhalanxId).Name + " has not been set");
                }
                // Check that callSign has been set
                if (this.callSign == CallSign.None)
                {
                    argumentExceptionSet.Add(typeof(CallSign).Name + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}