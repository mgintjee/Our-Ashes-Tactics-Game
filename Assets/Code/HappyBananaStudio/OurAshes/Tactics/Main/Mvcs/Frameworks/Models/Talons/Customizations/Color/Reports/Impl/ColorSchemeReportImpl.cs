namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Customizations.Color.Reports.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Customizations.Color.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Customizations.Color.Reports.Api;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct ColorSchemeReportImpl
        : IColorSchemeReport
    {
        // Todo
        private readonly ColorId primaryColorId;

        // Todo
        private readonly ColorId secondaryColorId;

        // Todo
        private readonly ColorId tertiaryColorId;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="primaryColorId"></param>
        /// <param name="secondaryColorId"></param>
        /// <param name="tertiaryColorId"></param>
        private ColorSchemeReportImpl(ColorId primaryColorId, ColorId secondaryColorId, ColorId tertiaryColorId)
        {
            this.primaryColorId = primaryColorId;
            this.secondaryColorId = secondaryColorId;
            this.tertiaryColorId = tertiaryColorId;
        }

        /// <inheritdoc/>
        ColorId IColorSchemeReport.GetPrimaryColorId()
        {
            return this.primaryColorId;
        }

        /// <inheritdoc/>
        ColorId IColorSchemeReport.GetSecondaryColorId()
        {
            return this.secondaryColorId;
        }

        /// <inheritdoc/>
        ColorId IColorSchemeReport.GetTertiaryColorId()
        {
            return this.tertiaryColorId;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private ColorId primaryColorId = ColorId.None;

            // Todo
            private ColorId secondaryColorId = ColorId.None;

            // Todo
            private ColorId tertiaryColorId = ColorId.None;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IColorSchemeReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Object
                    return new ColorSchemeReportImpl(this.primaryColorId, this.secondaryColorId, this.tertiaryColorId);
                }
                else
                {
                    throw ExceptionUtil.Argument.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="primaryColorId"></param>
            /// <returns></returns>
            public Builder SetPrimaryColorId(ColorId primaryColorId)
            {
                this.primaryColorId = primaryColorId;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="secondaryColorId"></param>
            /// <returns></returns>
            public Builder SetSecondaryColorId(ColorId secondaryColorId)
            {
                this.secondaryColorId = secondaryColorId;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="tertiaryColorId"></param>
            /// <returns></returns>
            public Builder SetTertiaryColorId(ColorId tertiaryColorId)
            {
                this.tertiaryColorId = tertiaryColorId;
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
                // Check that primaryColorId has been set
                if (this.primaryColorId == ColorId.None)
                {
                    argumentExceptionSet.Add("Primary" + typeof(ColorId).Name + " has not been set");
                }
                // Check that secondaryColorId has been set
                if (this.secondaryColorId == ColorId.None)
                {
                    argumentExceptionSet.Add("Secondary " + typeof(ColorId).Name + " has not been set");
                }
                // Check that tertiaryColorId has been set
                if (this.tertiaryColorId == ColorId.None)
                {
                    argumentExceptionSet.Add("Tertiary " + typeof(ColorId).Name + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}