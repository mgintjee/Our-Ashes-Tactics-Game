/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Attributes.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Talons.Behaviors;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Attributes;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Combat;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Weapons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Builders;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Objects.Talons
{
    /// <summary>
    /// Talon Behavior Destructible Impl
    /// </summary>
    public class TalonBehaviorDestructibleImpl
    : ITalonBehaviorDestructible
    {
        // TODO
        private readonly IDestructibleAttributes destructibleAttributes = null;

        // TODO
        private int currentArmorPoints = int.MinValue;

        // TODO
        private int currentHealthPoints = int.MinValue;

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="destructibleAttributes">
        /// </param>
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

        /// <summary>
        /// TODO
        /// </summary>
        /// <returns>
        /// </returns>
        public IDestructibleReport GetDestructibleAttributesReport()
        {
            return ReportBuilder.Talon.Attributes.Destructible.GetBuilder()
                .SetCurrentArmourPoints(this.currentArmorPoints)
                .SetCurrentHealthPoints(this.currentHealthPoints)
                .SetMaximumArmourPoints(this.destructibleAttributes.GetArmorPoints())
                .SetMaximumHealthPoints(this.destructibleAttributes.GetHealthPoints())
                .Build();
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="talonCombatOrderReport">
        /// </param>
        /// <returns>
        /// </returns>
        public ITalonCombatResultReport InputTalonCombatOrderReport(ITalonCombatOrderReport talonCombatOrderReport)
        {
            if (talonCombatOrderReport != null)
            {
                List<IWeaponResultReport> weaponResultReportList = new List<IWeaponResultReport>();
                foreach (IWeaponOrderReport weaponOrderReport in talonCombatOrderReport.GetWeaponOrderReportList())
                {
                    weaponResultReportList.Add(this.InputWeaponCombatOrderReport(weaponOrderReport));
                }
                return ReportBuilder.Talon.Combat.Result.GetBuilder()
                    .SetIsTargetDestroyed(this.currentHealthPoints <= 0)
                    .SetTalonCombatOrderReport(talonCombatOrderReport)
                    .SetWeaponResultReportList(weaponResultReportList)
                    .Build();
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. " +
                    "\n\t> ? is null", new StackFrame().GetMethod().Name, typeof(ITalonCombatOrderReport));
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="weaponOrderReport">
        /// </param>
        /// <returns>
        /// </returns>
        private IWeaponResultReport InputWeaponCombatOrderReport(IWeaponOrderReport weaponOrderReport)
        {
            if (weaponOrderReport != null)
            {
                // Collect the number of shots that hit
                int numberOfShots = weaponOrderReport.GetShotsThatHit();
                // Collect the weapon information
                IWeaponInformationReport weaponInformationReport = weaponOrderReport.GetWeaponInformationReport();
                // Collect the damage per shots
                int damagePerShot = weaponInformationReport.GetWeaponAttributes().GetDamagePoints();
                // Calculate the remaining armor after penetration
                int armorRemaining = this.currentArmorPoints - weaponInformationReport.GetWeaponAttributes().GetPenetrationPoints();
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
                return ReportBuilder.Weapon.Result.GetBuilder()
                    .SetDamageCaused(damageDealt)
                    .SetDamageMitigated(damageMitigated)
                    .SetWeaponOrderReport(weaponOrderReport)
                    .Build();
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. " +
                    "\n\t> ? is null", new StackFrame().GetMethod().Name, typeof(IWeaponOrderReport));
            }
        }
    }
}