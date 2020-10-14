

namespace HappyBananaStudio.OurAshes.Tactics.Impl.Talons.Reports.Customization
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Customization;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Schemes.Color;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Exceptions;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct ColorSchemeReportImpl
        : IColorSchemeReport
    {
        // Todo
        private readonly ColorIdEnum primaryPaintColorId;

        // Todo
        private readonly ColorIdEnum secondaryPaintColorId;

        // Todo
        private readonly ColorIdEnum tertiaryPaintColorId;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="primaryPaintColorId">
        /// </param>
        /// <param name="secondaryPaintColorId">
        /// </param>
        /// <param name="tertiaryPaintColorId">
        /// </param>
        private ColorSchemeReportImpl(ColorIdEnum primaryPaintColorId,
            ColorIdEnum secondaryPaintColorId, ColorIdEnum tertiaryPaintColorId)
        {
            this.primaryPaintColorId = primaryPaintColorId;
            this.secondaryPaintColorId = secondaryPaintColorId;
            this.tertiaryPaintColorId = tertiaryPaintColorId;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return this.GetType().Name + ": Primary " + typeof(ColorIdEnum).Name + "=" + this.primaryPaintColorId +
                ", Secondary " + typeof(ColorIdEnum).Name + "=" + this.secondaryPaintColorId +
                ", Tertiary " + typeof(ColorIdEnum).Name + "=" + this.tertiaryPaintColorId;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ColorIdEnum IColorSchemeReport.GetPrimaryPaintColorId()
        {
            return this.primaryPaintColorId;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ColorIdEnum IColorSchemeReport.GetSecondaryPaintColorId()
        {
            return this.secondaryPaintColorId;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ColorIdEnum IColorSchemeReport.GetTertiaryPaintColorId()
        {
            return this.tertiaryPaintColorId;
        }

        /// <summary>
        /// Builder class for this report
        /// </summary>
        public class Builder
        {
            // The primary PaintColorId
            private ColorIdEnum primaryPaintColorId = ColorIdEnum.None;

            // The secondary PaintColorId
            private ColorIdEnum secondaryPaintColorId = ColorIdEnum.None;

            // The tertiary PaintColorId
            private ColorIdEnum tertiaryPaintColorId = ColorIdEnum.None;

            /// <summary>
            /// Build the PaintSchemeReport with the set parameters
            /// </summary>
            /// <returns>
            /// The IPaintSchemeReport
            /// </returns>
            public IColorSchemeReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new ColorSchemeReportImpl(this.primaryPaintColorId, this.secondaryPaintColorId, this.tertiaryPaintColorId);
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Set the value of the primaryPaintColorId
            /// </summary>
            /// <param name="primaryPaintColorId">
            /// The PaintColorIdEnum to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetPrimaryColorId(ColorIdEnum primaryPaintColorId)
            {
                this.primaryPaintColorId = primaryPaintColorId;
                return this;
            }

            /// <summary>
            /// Set the value of the secondaryPaintColorId
            /// </summary>
            /// <param name="secondaryPaintColorId">
            /// The PaintColorIdEnum to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetSecondaryColorId(ColorIdEnum secondaryPaintColorId)
            {
                this.secondaryPaintColorId = secondaryPaintColorId;
                return this;
            }

            /// <summary>
            /// Set the value of the tertiaryPaintColorId
            /// </summary>
            /// <param name="tertiaryPaintColorId">
            /// The PaintColorIdEnum to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetTertiaryColorId(ColorIdEnum tertiaryPaintColorId)
            {
                this.tertiaryPaintColorId = tertiaryPaintColorId;
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
                // Check that primaryPaintColorId has been set
                if (this.primaryPaintColorId == ColorIdEnum.None)
                {
                    argumentExceptionSet.Add("Primary " + typeof(ColorIdEnum).Name + " has not been set");
                }
                // Check that secondaryPaintColorId has been set
                if (this.secondaryPaintColorId == ColorIdEnum.None)
                {
                    argumentExceptionSet.Add("Secondary " + typeof(ColorIdEnum).Name + " has not been set");
                }
                // Check that tertiaryPaintColorId has been set
                if (this.tertiaryPaintColorId == ColorIdEnum.None)
                {
                    argumentExceptionSet.Add("Tertiary " + typeof(ColorIdEnum).Name + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}
