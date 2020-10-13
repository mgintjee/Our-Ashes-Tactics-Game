/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>
/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

namespace HappyBananaStudio.OurAshesTactics.Impl.Reports.Weapons
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Weapons.Reports;
    using HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions;
    using System.Collections.Generic;

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
        public override string ToString()
        {
            return this.GetType().Name + ":" +
                "\n\t>Damage Caused= " + this.damageCaused +
                "\n\t>Damage Mitigated= " + this.damageMitigated +
                "\n\t>" + this.weaponOrderReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        int IWeaponResultReport.GetDamageCaused()
        {
            return this.damageCaused;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        int IWeaponResultReport.GetDamageMitigated()
        {
            return this.damageMitigated;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IWeaponOrderReport IWeaponResultReport.GetWeaponOrderReport()
        {
            return this.weaponOrderReport;
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
                ISet<string> invalidReasons = this.IsInvalid();
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
            private ISet<string> IsInvalid()
            {
                // Default an empty Set: String
                ISet<string> argumentExceptionSet = new HashSet<string>();
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
