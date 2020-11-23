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
        private readonly EmblemSpriteIdEnum backgroundId;

        // Todo
        private readonly EmblemSpriteIdEnum foregroundId;

        // Todo
        private readonly EmblemSpriteIdEnum iconId;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="backgroundId">
        /// </param>
        /// <param name="foregroundId">
        /// </param>
        /// <param name="iconId">
        /// </param>
        private EmblemSchemeReportImpl(EmblemSpriteIdEnum backgroundId, EmblemSpriteIdEnum foregroundId, EmblemSpriteIdEnum iconId)
        {
            this.backgroundId = backgroundId;
            this.foregroundId = foregroundId;
            this.iconId = iconId;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return this.GetType().Name + ": Background=" + this.backgroundId + ", Foreground=" + this.foregroundId + ", Icon=" + this.iconId;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        EmblemSpriteIdEnum IEmblemSchemeReport.GetBackgroundId()
        {
            return this.backgroundId;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        EmblemSpriteIdEnum IEmblemSchemeReport.GetForegroundId()
        {
            return this.foregroundId;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        EmblemSpriteIdEnum IEmblemSchemeReport.GetIconId()
        {
            return this.iconId;
        }

        /// <summary>
        /// Builder class for this report
        /// </summary>
        public class Builder
        {
            // Todo
            private EmblemSpriteIdEnum backgroundId = EmblemSpriteIdEnum.None;

            // Todo
            private EmblemSpriteIdEnum foregroundId = EmblemSpriteIdEnum.None;

            // Todo
            private EmblemSpriteIdEnum iconId = EmblemSpriteIdEnum.None;

            /// <summary>
            /// Build the report implementation with the set parameters
            /// </summary>
            /// <returns>
            /// The report interface
            /// </returns>
            public IEmblemSchemeReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new EmblemSchemeReportImpl(this.backgroundId, this.foregroundId, this.iconId);
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Set the value of the EmblemSpriteIdEnum
            /// </summary>
            /// <param name="backgroundId">
            /// The EmblemSpriteIdEnum to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetBackgroundId(EmblemSpriteIdEnum backgroundId)
            {
                this.backgroundId = backgroundId;
                return this;
            }

            /// <summary>
            /// Set the value of the EmblemSpriteIdEnum
            /// </summary>
            /// <param name="foregroundId">
            /// The EmblemSpriteIdEnum to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetForeground(EmblemSpriteIdEnum foregroundId)
            {
                this.foregroundId = foregroundId;
                return this;
            }

            /// <summary>
            /// Set the value of the EmblemSpriteIdEnum
            /// </summary>
            /// <param name="iconId">
            /// The EmblemSpriteIdEnum to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetIconId(EmblemSpriteIdEnum iconId)
            {
                this.iconId = iconId;
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
                // Check that backgroundId has been set
                if (this.backgroundId == EmblemSpriteIdEnum.None)
                {
                    argumentExceptionSet.Add("Background " + typeof(EmblemSpriteIdEnum).Name + " has not been set");
                }
                // Check that foregroundId has been set
                if (this.foregroundId == EmblemSpriteIdEnum.None)
                {
                    argumentExceptionSet.Add("Foreground " + typeof(EmblemSpriteIdEnum).Name + " has not been set");
                }
                // Check that iconId has been set
                if (this.iconId == EmblemSpriteIdEnum.None)
                {
                    argumentExceptionSet.Add("Icon " + typeof(EmblemSpriteIdEnum).Name + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}