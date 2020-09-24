/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Common.Exceptions;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Reports;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Weapon.Reports;
using HappyBananaStudio.OurAshesTactics.Talon.Attributes.Api;
using HappyBananaStudio.OurAshesTactics.Talon.Attributes.Reports;
using HappyBananaStudio.OurAshesTactics.Talon.Behavior.Api;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace HappyBananaStudio.OurAshesTactics.Talon.Behavior.Impl
{
    /// <summary>
    /// Talon Behavior Destructible Impl
    /// </summary>
    public class TalonBehaviorDestructibleImpl
    : ITalonBehaviorDestructible
    {
        #region Private Fields

        // TODO
        private readonly IDestructibleAttributes destructibleAttributes = null;

        // TODO
        private int currentArmorPoints = int.MinValue;

        // TODO
        private int currentHealthPoints = int.MinValue;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="destructibleAttributes"></param>
        public TalonBehaviorDestructibleImpl(IDestructibleAttributes destructibleAttributes)
        {
            if (destructibleAttributes != null)
            {
                this.destructibleAttributes = destructibleAttributes;
                this.currentArmorPoints = this.destructibleAttributes.GetArmorPoints();
                this.currentHealthPoints = this.destructibleAttributes.GetHealthPoints();
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. " +
                    "\n\t> ? is null", this.GetType(), typeof(IDestructibleAttributes));
            }
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        public DestructibleAttributesReport GetDestructibleAttributesReport()
        {
            return new DestructibleAttributesReport.Builder()
                .SetCurrentArmourPoints(this.currentArmorPoints)
                .SetCurrentHealthPoints(this.currentHealthPoints)
                .SetMaximumArmourPoints(this.destructibleAttributes.GetArmorPoints())
                .SetMaximumHealthPoints(this.destructibleAttributes.GetHealthPoints())
                .Build();
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="talonCombatOrderReport"></param>
        /// <returns></returns>
        public TalonCombatResultReport InputTalonCombatOrderReport(TalonCombatOrderReport talonCombatOrderReport)
        {
            if (talonCombatOrderReport != null)
            {
                List<WeaponCombatResultReport> weaponCombatResultReportList = new List<WeaponCombatResultReport>();
                foreach (WeaponCombatOrderReport weaponCombatOrderReport in talonCombatOrderReport.GetWeaponCombatOrderReportList())
                {
                    weaponCombatResultReportList.Add(this.InputWeaponCombatOrderReport(weaponCombatOrderReport));
                }
                return new TalonCombatResultReport.Builder()
                    .SetIsTargetDestroyed(this.currentHealthPoints <= 0)
                    .SetTalonCombatOrderReport(talonCombatOrderReport)
                    .SetWeaponCombatResultReportList(weaponCombatResultReportList)
                    .Build();
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. " +
                    "\n\t> ? is null", new StackFrame().GetMethod().Name, typeof(TalonCombatOrderReport));
            }
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="weaponCombatOrderReport"></param>
        /// <returns></returns>
        private WeaponCombatResultReport InputWeaponCombatOrderReport(WeaponCombatOrderReport weaponCombatOrderReport)
        {
            if (weaponCombatOrderReport != null)
            {
                // Collect the number of shots that hit
                int numberOfShots = weaponCombatOrderReport.GetNumberOfShots();
                // Collect the damage per shots
                int damagePerShot = weaponCombatOrderReport.GetDamagePerShot();
                // Calculate the remaining armor after penetration
                int armorRemaining = this.currentArmorPoints - weaponCombatOrderReport.GetPenetration();
                // Check that the armorRemaining is not less than 0
                if (armorRemaining < 0)
                {
                    // Set the armorRemaining to 0
                    armorRemaining = 0;
                }

                // Initialize damageDealt
                int damageDealt;

                // Calculate minimum damage
                if (armorRemaining >= damagePerShot)
                {
                    // Multiply the NumberOfShots by the minimum damage ratio
                    float minimumDamageDealt = numberOfShots / 2;
                    // Get the ceiling to ensure at least 1 damage would be dealt
                    damageDealt = Mathf.CeilToInt(minimumDamageDealt);
                }
                // Calculate the damage after armor
                else
                {
                    // Multiply the Number of shots by the damage dealt after armor
                    damageDealt = numberOfShots * (damagePerShot - armorRemaining);
                }

                int potentialDamage = numberOfShots * damagePerShot;
                int damageMitigated = potentialDamage - damageDealt;

                this.currentHealthPoints -= damageDealt;
                return new WeaponCombatResultReport.Builder()
                    .SetDamageDealt(damageDealt)
                    .SetDamageMitigated(damageMitigated)
                    .Build();
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. " +
                    "\n\t> ? is null", new StackFrame().GetMethod().Name, typeof(WeaponCombatOrderReport));
            }
        }

        #endregion Private Methods
    }
}