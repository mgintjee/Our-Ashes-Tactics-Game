namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Customizations.Emblems.Reports.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Customizations.Emblems.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Sprites.Enums;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct EmblemSchemeReport
        : IEmblemSchemeReport
    {
        // Todo
        private readonly SpriteId backgroundEmblemId;

        // Todo
        private readonly SpriteId foregroundEmblemId;

        // Todo
        private readonly SpriteId iconEmblemId;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="backgroundEmblemId"></param>
        /// <param name="foregroundEmblemId"></param>
        /// <param name="iconEmblemId"></param>
        private EmblemSchemeReport(SpriteId backgroundEmblemId, SpriteId foregroundEmblemId, SpriteId iconEmblemId)
        {
            this.backgroundEmblemId = backgroundEmblemId;
            this.foregroundEmblemId = foregroundEmblemId;
            this.iconEmblemId = iconEmblemId;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        SpriteId IEmblemSchemeReport.GetBackgroundId()
        {
            return this.backgroundEmblemId;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        SpriteId IEmblemSchemeReport.GetForegroundId()
        {
            return this.foregroundEmblemId;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        SpriteId IEmblemSchemeReport.GetIconId()
        {
            return this.iconEmblemId;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: Background {1}={2}, Foreground {3}={4}, Icon {5}={6}",
                this.GetType().Name, typeof(SpriteId).Name, this.backgroundEmblemId, typeof(SpriteId).Name,
                this.foregroundEmblemId, typeof(SpriteId).Name, this.iconEmblemId);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private SpriteId backgroundEmblemId = SpriteId.None;

            // Todo
            private SpriteId foregroundEmblemId = SpriteId.None;

            // Todo
            private SpriteId iconEmblemId = SpriteId.None;

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
                    throw ExceptionUtil.Arguments.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="backgroundEmblemId"></param>
            /// <returns></returns>
            public Builder SetBackgroundEmblemId(SpriteId backgroundEmblemId)
            {
                this.backgroundEmblemId = backgroundEmblemId;
                return this;
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="foregroundEmblemId"></param>
            /// <returns></returns>
            public Builder SetForegroundEmblemId(SpriteId foregroundEmblemId)
            {
                this.foregroundEmblemId = foregroundEmblemId;
                return this;
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="iconEmblemId"></param>
            /// <returns></returns>
            public Builder SetIconEmblemId(SpriteId iconEmblemId)
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
                if (this.backgroundEmblemId == SpriteId.None)
                {
                    argumentExceptionSet.Add("Background " + typeof(SpriteId).Name + " has not been set");
                }
                // Check that foregroundEmblemId has been set
                if (this.foregroundEmblemId == SpriteId.None)
                {
                    argumentExceptionSet.Add("Foreground " + typeof(SpriteId).Name + " has not been set");
                }
                // Check that iconEmblemId has been set
                if (this.iconEmblemId == SpriteId.None)
                {
                    argumentExceptionSet.Add("Icon " + typeof(SpriteId).Name + " has not been set");
                }

                return argumentExceptionSet;
            }
        }
    }
}