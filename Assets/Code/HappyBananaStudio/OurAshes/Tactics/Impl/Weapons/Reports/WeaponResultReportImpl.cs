
namespace HappyBananaStudio.OurAshes.Tactics.Impl.Weapons.Reports
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Weapons.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Exceptions;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct WeaponResultReportImpl
        : IWeaponResultReport
    {
        // Todo
        private readonly int healthDamageCaused;

        // Todo
        private readonly int armorDamageCaused;

        // Todo
        private readonly IWeaponOrderReport weaponOrderReport;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="damageCaused">
        /// </param>
        /// <param name="armorDamageCaused">
        /// </param>
        /// <param name="weaponOrderReport">
        /// </param>
        private WeaponResultReportImpl(int damageCaused, int armorDamageCaused, IWeaponOrderReport weaponOrderReport)
        {
            this.healthDamageCaused = damageCaused;
            this.armorDamageCaused = armorDamageCaused;
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
                "\n\t>Health Damage Caused= " + this.healthDamageCaused +
                "\n\t>Armor Damage Caused= " + this.armorDamageCaused +
                "\n\t>" + this.weaponOrderReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        int IWeaponResultReport.GetHealthDamageCaused()
        {
            return this.healthDamageCaused;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        int IWeaponResultReport.GetArmorDamageCaused()
        {
            return this.armorDamageCaused;
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
            private int healthDamageCaused;

            // Todo
            private int armorDamageCaused;

            // Todo
            private bool setHealthDamageCaused = false;

            // Todo
            private bool setArmorDamageCaused = false;

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
                    return new WeaponResultReportImpl(this.healthDamageCaused, this.armorDamageCaused, this.weaponOrderReport);
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
            /// <param name="healthDamageCaused">
            /// The int damageCaused to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetHealthDamageCaused(int healthDamageCaused)
            {
                this.healthDamageCaused = healthDamageCaused;
                this.setHealthDamageCaused = true;
                return this;
            }

            /// <summary>
            /// Set the value of the int damageMitigated
            /// </summary>
            /// <param name="armorDamageCaused">
            /// The int damageMitigated to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetArmorDamageCaused(int armorDamageCaused)
            {
                this.armorDamageCaused = armorDamageCaused;
                this.setArmorDamageCaused = true;
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
                // Check that healthDamageCaused has been set
                if (!this.setHealthDamageCaused)
                {
                    argumentExceptionSet.Add("healthDamageCaused has not been set");
                }
                // Check that armorDamageCaused has been set
                if (!this.setArmorDamageCaused)
                {
                    argumentExceptionSet.Add("armorDamageCaused has not been set");
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
