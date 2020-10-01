/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Attributes.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Exceptions;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Attributes.Talons
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct FireableAttributesImpl
        : IFireableAttributes
    {
        // Todo
        private readonly int weaponPoints;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="weaponPoints">
        /// </param>
        private FireableAttributesImpl(int weaponPoints)
        {
            this.weaponPoints = weaponPoints;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public int GetWeaponPoints()
        {
            return this.weaponPoints;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private bool setWeaponPoints = false;

            // Todo
            private int weaponPoints;

            /// <summary>
            /// Build the FireableAttributes with the set parameters
            /// </summary>
            /// <returns>
            /// The IFireableAttributes
            /// </returns>
            public IFireableAttributes Build()
            {
                HashSet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new FireableAttributesImpl(this.weaponPoints);
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Set the value of the weaponPoints
            /// </summary>
            /// <param name="weaponPoints">
            /// The weaponPoints to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetWeaponPoints(int weaponPoints)
            {
                this.weaponPoints = weaponPoints;
                this.setWeaponPoints = true;
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
                // Check that weaponPoints has been set
                if (!this.setWeaponPoints)
                {
                    argumentExceptionSet.Add("weaponPoints has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}