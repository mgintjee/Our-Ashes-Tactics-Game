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
        public ColorIdEnum GetPrimaryPaintColorId()
        {
            return this.primaryPaintColorId;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public ColorIdEnum GetSecondaryPaintColorId()
        {
            return this.secondaryPaintColorId;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public ColorIdEnum GetTertiaryPaintColorId()
        {
            return this.tertiaryPaintColorId;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return this.GetType().Name + ":" +
                "\n\t>Primary " + typeof(ColorIdEnum).Name + "=" + this.GetPrimaryPaintColorId() +
                "\n\t>Secondary " + typeof(ColorIdEnum).Name + "=" + this.GetSecondaryPaintColorId() +
                "\n\t>Tertiary " + typeof(ColorIdEnum).Name + "=" + this.GetTertiaryPaintColorId();
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
                HashSet<string> invalidReasons = this.IsInvalid();
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
            public Builder SetPrimaryPaintColorId(ColorIdEnum primaryPaintColorId)
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
            public Builder SetSecondaryPaintColorId(ColorIdEnum secondaryPaintColorId)
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
            public Builder SetTertiaryPaintColorId(ColorIdEnum tertiaryPaintColorId)
            {
                this.tertiaryPaintColorId = tertiaryPaintColorId;
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