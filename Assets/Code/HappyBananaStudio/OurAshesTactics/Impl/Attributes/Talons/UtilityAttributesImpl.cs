/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Attributes.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Attributes.Talons
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct UtilityAttributesImpl
        : IUtilityAttributes
    {
        // Todo
        private readonly int utilityPoints;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="utilityPoints">
        /// </param>
        private UtilityAttributesImpl(int utilityPoints)
        {
            this.utilityPoints = utilityPoints;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public int GetUtilityPoints()
        {
            return this.utilityPoints;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private bool setUtilityPoints = false;

            // Todo
            private int utilityPoints;

            /// <summary>
            /// Build the UtilityAttributes with the set parameters
            /// </summary>
            /// <returns>
            /// The IUtilityAttributes
            /// </returns>
            public IUtilityAttributes Build()
            {
                HashSet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new UtilityAttributesImpl(this.utilityPoints);
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Set the value of the utilityPoints
            /// </summary>
            /// <param name="weaponPoints">
            /// The utilityPoints to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetUtilityPoints(int utilityPoints)
            {
                this.utilityPoints = utilityPoints;
                this.setUtilityPoints = true;
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
                // Check that utilityPoints has been set
                if (!this.setUtilityPoints)
                {
                    argumentExceptionSet.Add("utilityPoints has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}