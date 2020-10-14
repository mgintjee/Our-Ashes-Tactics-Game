
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
        private readonly CallSignEnum callSign;

        // Todo
        private readonly FactionIdEnum factionId;

        // Todo
        private readonly PhalanxIdEnum phalanxId;

        // Todo
        private readonly TalonModelIdEnum talonModelId;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonId">
        /// </param>
        /// <param name="phalanxId">
        /// </param>
        /// <param name="callSign">
        /// </param>
        private TalonIdentificationReportImpl(TalonModelIdEnum talonId, FactionIdEnum factionId,
            PhalanxIdEnum phalanxId, CallSignEnum callSign)
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
            return this.GetType().Name + ":" +
                "\n\t>" + typeof(TalonModelIdEnum).Name + "=" + this.talonModelId +
                "\n\t>" + typeof(FactionIdEnum).Name + "=" + this.factionId +
                "\n\t>" + typeof(PhalanxIdEnum).Name + "=" + this.phalanxId +
                "\n\t>" + typeof(CallSignEnum).Name + "=" + this.callSign;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        CallSignEnum ITalonIdentificationReport.GetCallSign()
        {
            return this.callSign;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        FactionIdEnum ITalonIdentificationReport.GetFactionId()
        {
            return this.factionId;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        PhalanxIdEnum ITalonIdentificationReport.GetPhalanxId()
        {
            return this.phalanxId;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        TalonModelIdEnum ITalonIdentificationReport.GetTalonModelId()
        {
            return this.talonModelId;
        }

        /// <summary>
        /// Builder class for this report
        /// </summary>
        public class Builder
        {
            // Todo
            private CallSignEnum callSign = CallSignEnum.None;

            // Todo
            private FactionIdEnum factionId = FactionIdEnum.None;

            // Todo
            private PhalanxIdEnum phalanxId = PhalanxIdEnum.None;

            // Todo
            private TalonModelIdEnum talonId = TalonModelIdEnum.None;

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
            public Builder SetCallSign(CallSignEnum callSign)
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
            /// Set the value of the TalonIdEnum
            /// </summary>
            /// <param name="talonId">
            /// The TalonIdEnum to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetTalonModelId(TalonModelIdEnum talonId)
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
                if (this.factionId == FactionIdEnum.None)
                {
                    argumentExceptionSet.Add(typeof(FactionIdEnum).Name + " has not been set");
                }
                // Check that talonId has been set
                if (this.talonId == TalonModelIdEnum.None)
                {
                    argumentExceptionSet.Add(typeof(TalonModelIdEnum).Name + " has not been set");
                }
                // Check that phalanxId has been set
                if (this.phalanxId == PhalanxIdEnum.None)
                {
                    argumentExceptionSet.Add(typeof(PhalanxIdEnum).Name + " has not been set");
                }
                // Check that callSign has been set
                if (this.callSign == CallSignEnum.None)
                {
                    argumentExceptionSet.Add(typeof(CallSignEnum).Name + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}
