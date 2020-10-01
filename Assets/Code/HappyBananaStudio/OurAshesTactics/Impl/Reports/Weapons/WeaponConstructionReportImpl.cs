/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Weapons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Exceptions;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Reports.Weapons
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct WeaponConstructionReportImpl
        : IWeaponConstructionReport
    {
        // Todo
        private readonly WeaponModelIdEnum weaponId;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="weaponId">
        /// </param>
        private WeaponConstructionReportImpl(WeaponModelIdEnum weaponId)
        {
            this.weaponId = weaponId;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public WeaponModelIdEnum GetWeaponId()
        {
            return this.weaponId;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return this.GetType().Name + ":" +
                "\n\t>" + typeof(WeaponModelIdEnum).Name + "=" + this.GetWeaponId();
        }

        /// <summary>
        /// Builder class for this report
        /// </summary>
        public class Builder
        {
            // Todo
            private WeaponModelIdEnum weaponId = WeaponModelIdEnum.None;

            /// <summary>
            /// Build the report with the set parameters
            /// </summary>
            /// <returns>
            /// The report interface
            /// </returns>
            public IWeaponConstructionReport Build()
            {
                HashSet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new WeaponConstructionReportImpl(this.weaponId);
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Set the value of the WeaponIdEnum
            /// </summary>
            /// <param name="weaponId">
            /// The WeaponIdEnum to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetWeaponId(WeaponModelIdEnum weaponId)
            {
                this.weaponId = weaponId;
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
                // Check that weaponId has been set
                if (this.weaponId == WeaponModelIdEnum.None)
                {
                    argumentExceptionSet.Add(typeof(WeaponModelIdEnum).Name + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}