/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Paints;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Exceptions;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Reports.Paint
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct PaintSchemeReportImpl
        : IPaintSchemeReport
    {
        // Todo
        private readonly PaintColorIdEnum primaryPaintColorId;

        // Todo
        private readonly PaintColorIdEnum secondaryPaintColorId;

        // Todo
        private readonly PaintColorIdEnum tertiaryPaintColorId;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="primaryPaintColorId">
        /// </param>
        /// <param name="secondaryPaintColorId">
        /// </param>
        /// <param name="tertiaryPaintColorId">
        /// </param>
        private PaintSchemeReportImpl(PaintColorIdEnum primaryPaintColorId,
            PaintColorIdEnum secondaryPaintColorId, PaintColorIdEnum tertiaryPaintColorId)
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
        public PaintColorIdEnum GetPrimaryPaintColorId()
        {
            return this.primaryPaintColorId;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public PaintColorIdEnum GetSecondaryPaintColorId()
        {
            return this.secondaryPaintColorId;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public PaintColorIdEnum GetTertiaryPaintColorId()
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
                "\n\t>Primary " + typeof(PaintColorIdEnum).Name + "=" + this.GetPrimaryPaintColorId() +
                "\n\t>Secondary " + typeof(PaintColorIdEnum).Name + "=" + this.GetSecondaryPaintColorId() +
                "\n\t>Tertiary " + typeof(PaintColorIdEnum).Name + "=" + this.GetTertiaryPaintColorId();
        }

        /// <summary>
        /// Builder class for this report
        /// </summary>
        public class Builder
        {
            // The primary PaintColorId
            private PaintColorIdEnum primaryPaintColorId = PaintColorIdEnum.None;

            // The secondary PaintColorId
            private PaintColorIdEnum secondaryPaintColorId = PaintColorIdEnum.None;

            // The tertiary PaintColorId
            private PaintColorIdEnum tertiaryPaintColorId = PaintColorIdEnum.None;

            /// <summary>
            /// Build the PaintSchemeReport with the set parameters
            /// </summary>
            /// <returns>
            /// The IPaintSchemeReport
            /// </returns>
            public IPaintSchemeReport Build()
            {
                HashSet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new PaintSchemeReportImpl(this.primaryPaintColorId, this.secondaryPaintColorId, this.tertiaryPaintColorId);
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
            public Builder SetPrimaryPaintColorId(PaintColorIdEnum primaryPaintColorId)
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
            public Builder SetSecondaryPaintColorId(PaintColorIdEnum secondaryPaintColorId)
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
            public Builder SetTertiaryPaintColorId(PaintColorIdEnum tertiaryPaintColorId)
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
                if (this.primaryPaintColorId == PaintColorIdEnum.None)
                {
                    argumentExceptionSet.Add("Primary " + typeof(PaintColorIdEnum).Name + " has not been set");
                }
                // Check that secondaryPaintColorId has been set
                if (this.secondaryPaintColorId == PaintColorIdEnum.None)
                {
                    argumentExceptionSet.Add("Secondary " + typeof(PaintColorIdEnum).Name + " has not been set");
                }
                // Check that tertiaryPaintColorId has been set
                if (this.tertiaryPaintColorId == PaintColorIdEnum.None)
                {
                    argumentExceptionSet.Add("Tertiary " + typeof(PaintColorIdEnum).Name + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}