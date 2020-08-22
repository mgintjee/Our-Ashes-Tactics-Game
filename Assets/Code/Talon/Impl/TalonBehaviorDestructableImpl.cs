using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Talon Behavior Destructable Impl
/// </summary>
public class TalonBehaviorDestructableImpl
    : TalonBehaviorDestructable
{
    #region Private Fields

    private readonly TalonAttributes talonAttributes = null;
    private int currentArmourPoints = int.MinValue;
    private int currentHealthPoints = int.MinValue;

    #endregion Private Fields

    #region Public Constructors

    public TalonBehaviorDestructableImpl(TalonAttributes talonAttributes)
    {
        if (talonAttributes != null)
        {
            this.talonAttributes = talonAttributes;
            this.currentArmourPoints = this.talonAttributes.GetArmourPoints();
            this.currentHealthPoints = this.talonAttributes.GetHealthPoints();
        }
        else
        {
            throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                "\n\t>" + typeof(TalonAttributes) + " is null");
        }
    }

    #endregion Public Constructors

    #region Public Methods

    public override int GetCurrentArmourPoints()
    {
        return this.currentArmourPoints;
    }

    public override int GetCurrentHealthPoints()
    {
        return this.currentHealthPoints;
    }

    public override int GetMaximumArmourPoints()
    {
        return this.talonAttributes.GetArmourPoints();
    }

    public override int GetMaximumHealthPoints()
    {
        return this.talonAttributes.GetHealthPoints();
    }

    public override TalonCombatResultReport InputTalonCombatOrderReport(TalonCombatOrderReport talonCombatOrderReport)
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
            throw new ArgumentException("Unable to InputTalonCombatOrderReport. Invalid Parameters." +
                "\n\t>" + typeof(TalonCombatOrderReport) + " is null");
        }
    }

    #endregion Public Methods

    #region Private Methods

    private WeaponCombatResultReport InputWeaponCombatOrderReport(WeaponCombatOrderReport weaponCombatOrderReport)
    {
        if (weaponCombatOrderReport != null)
        {
            // Collect the number of shots that hit
            int numberOfShots = weaponCombatOrderReport.GetNumberOfShots();
            // Collect the damage per shots
            int damagePerShot = weaponCombatOrderReport.GetDamagePerShot();
            // Calculate the remaining armor after penetration
            int armorRemaining = this.currentArmourPoints - weaponCombatOrderReport.GetPenetration();
            // Check that the armorRemaining is not less than 0
            if (armorRemaining < 0)
            {
                // Set the armorRemaining to 0
                armorRemaining = 0;
            }

            // Initiatlize damageDealt
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
                // Multiply the Number of shots by the damage dealt after armour
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
            throw new ArgumentException("Unable to InputWeaponCombatOrderReport. Invalid Parameters." +
                "\n\t>" + typeof(WeaponCombatOrderReport) + " is null");
        }
    }

    #endregion Private Methods
}