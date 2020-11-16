namespace HappyBananaStudio.OurAshes.Tactics.Impl.Talons.Attributes
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Exceptions;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct MountableAttributesImpl
        : IMountableAttributes
    {
        // Todo
        private readonly int utilityMountPoints;

        // Todo
        private readonly int weaponMountPoints;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="weaponMountPoints">
        /// </param>
        private MountableAttributesImpl(int weaponMountPoints, int utilityMountPoints)
        {
            this.weaponMountPoints = weaponMountPoints;
            this.utilityMountPoints = utilityMountPoints;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        int IMountableAttributes.GetUtilityMountPoints()
        {
            return this.utilityMountPoints;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        int IMountableAttributes.GetWeaponMountPoints()
        {
            return this.weaponMountPoints;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private bool setUtilityMountPoints = false;

            // Todo
            private bool setWeaponMountPoints = false;

            // Todo
            private int utilityMountPoints;

            // Todo
            private int weaponMountPoints;

            /// <summary>
            /// Build the FireableAttributes with the set parameters
            /// </summary>
            /// <returns>
            /// The IFireableAttributes
            /// </returns>
            public IMountableAttributes Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new MountableAttributesImpl(this.weaponMountPoints, this.utilityMountPoints);
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Set the value of the utilityMountPoints
            /// </summary>
            /// <param name="utilityMountPoints">
            /// The utilityMountPoints to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetUtilityPoints(int utilityMountPoints)
            {
                this.utilityMountPoints = utilityMountPoints;
                this.setUtilityMountPoints = true;
                return this;
            }

            /// <summary>
            /// Set the value of the weaponMountPoints
            /// </summary>
            /// <param name="weaponMountPoints">
            /// The weaponMountPoints to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetWeaponPoints(int weaponMountPoints)
            {
                this.weaponMountPoints = weaponMountPoints;
                this.setWeaponMountPoints = true;
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
                // Check that weaponMountPoints has been set
                if (!this.setWeaponMountPoints)
                {
                    argumentExceptionSet.Add("weaponMountPoints has not been set");
                }
                // Check that utilityMountPoints has been set
                if (!this.setUtilityMountPoints)
                {
                    argumentExceptionSet.Add("utilityMountPoints has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}
