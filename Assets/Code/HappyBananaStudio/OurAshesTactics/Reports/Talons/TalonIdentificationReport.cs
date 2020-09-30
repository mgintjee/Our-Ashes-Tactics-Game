/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Exceptions;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Reports.Talons
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct TalonIdentificationReport
        : ITalonIdentificationReport
    {
        // Todo
        private readonly CallSignEnum callSign;

        // Todo
        private readonly FactionIdEnum factionId;

        // Todo
        private readonly PhalanxIdEnum phalanxId;

        // Todo
        private readonly TalonIdEnum talonId;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonId">
        /// </param>
        /// <param name="phalanxId">
        /// </param>
        /// <param name="callSign">
        /// </param>
        private TalonIdentificationReport(TalonIdEnum talonId, FactionIdEnum factionId, PhalanxIdEnum phalanxId, CallSignEnum callSign)
        {
            this.talonId = talonId;
            this.phalanxId = phalanxId;
            this.callSign = callSign;
            this.factionId = factionId;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public CallSignEnum GetCallSign()
        {
            return this.callSign;
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
        public PhalanxIdEnum GetPhalanxId()
        {
            return this.phalanxId;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public TalonIdEnum GetTalonId()
        {
            return this.talonId;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return this.GetType().Name + ":" +
                "\n\t>" + typeof(TalonIdEnum).Name + "=" + this.GetTalonId() +
                "\n\t>" + typeof(FactionIdEnum).Name + "=" + this.GetFactionId() +
                "\n\t>" + typeof(PhalanxIdEnum).Name + "=" + this.GetPhalanxId() +
                "\n\t>" + typeof(CallSignEnum).Name + "=" + this.GetCallSign();
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
            private TalonIdEnum talonId = TalonIdEnum.None;

            /// <summary>
            /// Build the report with the set parameters
            /// </summary>
            /// <returns>
            /// The report interface
            /// </returns>
            public ITalonIdentificationReport Build()
            {
                HashSet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new TalonIdentificationReport(this.talonId, this.factionId, this.phalanxId, this.callSign);
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
            public Builder SetFactionid(FactionIdEnum factionId)
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
            public Builder SetTalonId(TalonIdEnum talonId)
            {
                this.talonId = talonId;
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
                // Check that talonId has been set
                if (this.talonId == TalonIdEnum.None)
                {
                    argumentExceptionSet.Add(typeof(TalonIdEnum).Name + " has not been set");
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