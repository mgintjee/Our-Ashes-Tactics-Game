namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Customizations.Emblem.Reports.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Customizations.Emblem.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Customizations.Emblem.Reports.Api;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct EmblemSchemeReport
        : IEmblemSchemeReport
    {
        // Todo
        private readonly EmblemId backgroundEmblemId;

        // Todo
        private readonly EmblemId foregroundEmblemId;

        // Todo
        private readonly EmblemId iconEmblemId;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="backgroundEmblemId"></param>
        /// <param name="foregroundEmblemId"></param>
        /// <param name="iconEmblemId"></param>
        private EmblemSchemeReport(EmblemId backgroundEmblemId, EmblemId foregroundEmblemId, EmblemId iconEmblemId)
        {
            this.backgroundEmblemId = backgroundEmblemId;
            this.foregroundEmblemId = foregroundEmblemId;
            this.iconEmblemId = iconEmblemId;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        EmblemId IEmblemSchemeReport.GetBackgroundId()
        {
            return this.backgroundEmblemId;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        EmblemId IEmblemSchemeReport.GetForegroundId()
        {
            return this.foregroundEmblemId;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        EmblemId IEmblemSchemeReport.GetIconId()
        {
            return this.iconEmblemId;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: Background {1}={2}, Foreground {3}={4}, Icon {5}={6}",
                this.GetType().Name, typeof(EmblemId).Name, this.backgroundEmblemId, typeof(EmblemId).Name,
                this.foregroundEmblemId, typeof(EmblemId).Name, this.iconEmblemId);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private EmblemId backgroundEmblemId = EmblemId.None;

            // Todo
            private EmblemId foregroundEmblemId = EmblemId.None;

            // Todo
            private EmblemId iconEmblemId = EmblemId.None;

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
                    return new EmblemSchemeReport(this.backgroundEmblemId, this.foregroundEmblemId, this.iconEmblemId);
                }
                else
                {
                    throw ExceptionUtil.Argument.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="backgroundEmblemId"></param>
            /// <returns></returns>
            public Builder SetBackgroundEmblemId(EmblemId backgroundEmblemId)
            {
                this.backgroundEmblemId = backgroundEmblemId;
                return this;
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="foregroundEmblemId"></param>
            /// <returns></returns>
            public Builder SetForegroundEmblemId(EmblemId foregroundEmblemId)
            {
                this.foregroundEmblemId = foregroundEmblemId;
                return this;
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="iconEmblemId"></param>
            /// <returns></returns>
            public Builder SetIconEmblemId(EmblemId iconEmblemId)
            {
                this.iconEmblemId = iconEmblemId;
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
                // Check that backgroundEmblemId has been set
                if (this.backgroundEmblemId == EmblemId.None)
                {
                    argumentExceptionSet.Add("Background " + typeof(EmblemId).Name + " has not been set");
                }
                // Check that foregroundEmblemId has been set
                if (this.foregroundEmblemId == EmblemId.None)
                {
                    argumentExceptionSet.Add("Foreground " + typeof(EmblemId).Name + " has not been set");
                }
                // Check that iconEmblemId has been set
                if (this.iconEmblemId == EmblemId.None)
                {
                    argumentExceptionSet.Add("Icon " + typeof(EmblemId).Name + " has not been set");
                }

                return argumentExceptionSet;
            }
        }
    }
}