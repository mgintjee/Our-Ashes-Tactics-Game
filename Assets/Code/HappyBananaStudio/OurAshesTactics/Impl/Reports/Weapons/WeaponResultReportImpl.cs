/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Weapons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Exceptions;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Reports.Weapons
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct WeaponResultReportImpl
        : IWeaponResultReport
    {
        // Todo
        private readonly int damageCaused;

        // Todo
        private readonly int damageMitigated;

        // Todo
        private readonly IWeaponOrderReport weaponOrderReport;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="damageCaused">
        /// </param>
        /// <param name="damageMitigated">
        /// </param>
        /// <param name="weaponOrderReport">
        /// </param>
        private WeaponResultReportImpl(int damageCaused, int damageMitigated, IWeaponOrderReport weaponOrderReport)
        {
            this.damageCaused = damageCaused;
            this.damageMitigated = damageMitigated;
            this.weaponOrderReport = weaponOrderReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public int GetDamageCaused()
        {
            return this.damageCaused;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public int GetDamageMitigated()
        {
            return this.damageMitigated;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public IWeaponOrderReport GetWeaponOrderReport()
        {
            return this.weaponOrderReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return this.GetType().Name + ":" +
                "\n\t>Damage Caused= " + this.GetDamageCaused() +
                "\n\t>Damage Mitigated= " + this.GetDamageMitigated() +
                "\n\t>" + typeof(IWeaponOrderReport).Name + "= " + this.GetWeaponOrderReport();
        }

        /// <summary>
        /// Builder class for this report
        /// </summary>
        public class Builder
        {
            // Todo
            private int damageCaused;

            // Todo
            private int damageMitigated;

            // Todo
            private bool setDamageCaused = false;

            // Todo
            private bool setDamageMitigated = false;

            // Todo
            private IWeaponOrderReport weaponOrderReport;

            /// <summary>
            /// Build the report with the set parameters
            /// </summary>
            /// <returns>
            /// The report interface
            /// </returns>
            public IWeaponResultReport Build()
            {
                HashSet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new WeaponResultReportImpl(this.damageCaused, this.damageMitigated, this.weaponOrderReport);
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Set the value of the int damageCaused
            /// </summary>
            /// <param name="damageCaused">
            /// The int damageCaused to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetDamageCaused(int damageCaused)
            {
                this.damageCaused = damageCaused;
                this.setDamageCaused = true;
                return this;
            }

            /// <summary>
            /// Set the value of the int damageMitigated
            /// </summary>
            /// <param name="damageMitigated">
            /// The int damageMitigated to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetDamageMitigated(int damageMitigated)
            {
                this.damageMitigated = damageMitigated;
                this.setDamageMitigated = true;
                return this;
            }

            /// <summary>
            /// Set the value of the WeaponOrderReport
            /// </summary>
            /// <param name="weaponOrderReport">
            /// The WeaponOrderReport to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetWeaponOrderReport(IWeaponOrderReport weaponOrderReport)
            {
                this.weaponOrderReport = weaponOrderReport;
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
                // Check that damageCaused has been set
                if (!this.setDamageCaused)
                {
                    argumentExceptionSet.Add("damageCaused has not been set");
                }
                // Check that damageMitigated has been set
                if (!this.setDamageMitigated)
                {
                    argumentExceptionSet.Add("damageMitigated has not been set");
                }
                // Check that weaponOrderReport has been set
                if (this.weaponOrderReport == null)
                {
                    argumentExceptionSet.Add(typeof(IWeaponOrderReport).Name + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}