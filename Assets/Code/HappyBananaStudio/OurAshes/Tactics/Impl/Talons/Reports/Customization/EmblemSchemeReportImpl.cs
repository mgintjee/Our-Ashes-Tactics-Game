

namespace HappyBananaStudio.OurAshes.Tactics.Impl.Talons.Reports.Customization
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Customization;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Schemes.Emblem;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Exceptions;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct EmblemSchemeReportImpl
        : IEmblemSchemeReport
    {
        // Todo
        private readonly EmblemForegroundIdEnum emblemBackgroundId;

        // Todo
        private readonly EmblemIconIdEnum emblemIconId;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="emblemBackgroundId">
        /// </param>
        /// <param name="emblemIconId">
        /// </param>
        private EmblemSchemeReportImpl(EmblemForegroundIdEnum emblemBackgroundId, EmblemIconIdEnum emblemIconId)
        {
            this.emblemBackgroundId = emblemBackgroundId;
            this.emblemIconId = emblemIconId;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return this.GetType().Name + ": " + typeof(EmblemForegroundIdEnum).Name + "=" + this.emblemBackgroundId +
                ", " + typeof(EmblemIconIdEnum).Name + "=" + this.emblemIconId;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        EmblemForegroundIdEnum IEmblemSchemeReport.GetEmblemBackgroundId()
        {
            return this.emblemBackgroundId;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        EmblemIconIdEnum IEmblemSchemeReport.GetEmblemIconId()
        {
            return this.emblemIconId;
        }

        /// <summary>
        /// Builder class for this report
        /// </summary>
        public class Builder
        {
            // Todo
            private EmblemForegroundIdEnum emblemBackgroundId = EmblemForegroundIdEnum.None;

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
                ISet<string> invalidReasons = this.IsInvalid();
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
            public Builder SetEmblemBackgroundId(EmblemForegroundIdEnum emblemBackgroundId)
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
            private ISet<string> IsInvalid()
            {
                // Default an empty Set: String
                ISet<string> argumentExceptionSet = new HashSet<string>();
                // Check that emblemIconId has been set
                if (this.emblemIconId == EmblemIconIdEnum.None)
                {
                    argumentExceptionSet.Add(typeof(EmblemIconIdEnum).Name + " has not been set");
                }
                // Check that emblemBackgroundId has been set
                if (this.emblemBackgroundId == EmblemForegroundIdEnum.None)
                {
                    argumentExceptionSet.Add(typeof(EmblemForegroundIdEnum).Name + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}
