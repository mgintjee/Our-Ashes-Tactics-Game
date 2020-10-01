/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Attributes.Weapons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Weapons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Exceptions;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Reports.Weapons
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct WeaponInformationReportImpl
        : IWeaponInformationReport
    {
        // Todo
        private readonly IWeaponAttributes weaponAttributes;

        // Todo
        private readonly WeaponModelIdEnum weaponId;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="weaponAttributes">
        /// </param>
        private WeaponInformationReportImpl(WeaponModelIdEnum weaponId, IWeaponAttributes weaponAttributes)
        {
            this.weaponId = weaponId;
            this.weaponAttributes = weaponAttributes;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public IWeaponAttributes GetWeaponAttributes()
        {
            return this.weaponAttributes;
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
                "\n\t>" + typeof(WeaponModelIdEnum).Name + "=" + this.GetWeaponId() +
                "\n\t>" + typeof(IWeaponAttributes).Name + "=" + this.GetWeaponAttributes();
        }

        /// <summary>
        /// Builder class for this report
        /// </summary>
        public class Builder
        {
            // Todo
            private IWeaponAttributes weaponAttributes = null;

            // Todo
            private WeaponModelIdEnum weaponId = WeaponModelIdEnum.None;

            /// <summary>
            /// Build the report with the set parameters
            /// </summary>
            /// <returns>
            /// The report interface
            /// </returns>
            public IWeaponInformationReport Build()
            {
                HashSet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new WeaponInformationReportImpl(this.weaponId, this.weaponAttributes);
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Set the value of the IWeaponAttributes
            /// </summary>
            /// <param name="weaponAttributes">
            /// The IWeaponAttributes to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetWeaponAttributes(IWeaponAttributes weaponAttributes)
            {
                this.weaponAttributes = weaponAttributes;
                return this;
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
                // Check that weaponAttributes has been set
                if (this.weaponAttributes == null)
                {
                    argumentExceptionSet.Add(typeof(IWeaponAttributes).Name + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}