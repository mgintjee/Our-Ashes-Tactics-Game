/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Customization;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Reports.Talons.Customization
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct EmblemSchemeReportImpl
        : IEmblemSchemeReport
    {
        // Todo
        private readonly EmblemBackgroundIdEnum emblemBackgroundId;

        // Todo
        private readonly EmblemIconIdEnum emblemIconId;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="emblemBackgroundId">
        /// </param>
        /// <param name="emblemIconId">
        /// </param>
        private EmblemSchemeReportImpl(EmblemBackgroundIdEnum emblemBackgroundId, EmblemIconIdEnum emblemIconId)
        {
            this.emblemBackgroundId = emblemBackgroundId;
            this.emblemIconId = emblemIconId;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public EmblemBackgroundIdEnum GetBackgroundId()
        {
            return this.emblemBackgroundId;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public EmblemIconIdEnum GetIconId()
        {
            return this.emblemIconId;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return this.GetType().Name + ": " + typeof(EmblemBackgroundIdEnum).Name + "=" + this.GetBackgroundId() +
                ", " + typeof(EmblemIconIdEnum).Name + "=" + this.GetIconId();
        }

        /// <summary>
        /// Builder class for this report
        /// </summary>
        public class Builder
        {
            // Todo
            private EmblemBackgroundIdEnum emblemBackgroundId = EmblemBackgroundIdEnum.None;

            // Todo
            private EmblemIconIdEnum emblemIconId = EmblemIconIdEnum.None;

            /// <summary>
            /// Build the EmblemSchemeReportImpl with the set parameters
            /// </summary>
            /// <returns>
            /// The IEmblemSchemeReport
            /// </returns>
            public IEmblemSchemeReport Build()
            {
                HashSet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new EmblemSchemeReportImpl(this.emblemBackgroundId, this.emblemIconId);
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Set the value of the emblemBackgroundId
            /// </summary>
            /// <param name="emblemBackgroundId">
            /// The EmblemBackgroundIdEnum to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetEmblemBackgroundId(EmblemBackgroundIdEnum emblemBackgroundId)
            {
                this.emblemBackgroundId = emblemBackgroundId;
                return this;
            }

            /// <summary>
            /// Set the value of the emblemIconId
            /// </summary>
            /// <param name="emblemIconId">
            /// The EmblemIconIdEnum to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetEmblemIconId(EmblemIconIdEnum emblemIconId)
            {
                this.emblemIconId = emblemIconId;
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
                // Check that emblemIconId has been set
                if (this.emblemIconId == EmblemIconIdEnum.None)
                {
                    argumentExceptionSet.Add(typeof(EmblemIconIdEnum).Name + " has not been set");
                }
                // Check that emblemBackgroundId has been set
                if (this.emblemBackgroundId == EmblemBackgroundIdEnum.None)
                {
                    argumentExceptionSet.Add(typeof(EmblemBackgroundIdEnum).Name + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}