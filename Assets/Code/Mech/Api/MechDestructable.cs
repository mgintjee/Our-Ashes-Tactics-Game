using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

/// <summary>
/// Todo
/// </summary>
public class MechBehaviorDestructable
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    // The int representation for the maximum amount of Armour points this Mech has
    private readonly int armourPointsMaximum = 0;

    // The int representation for the maximum amount of Health points this Mech has
    private readonly int healthPointsMaximum = 0;

    // The int representation for the current amount of Armour points this Mech has
    private int armourPointsCurrent = 0;

    // The int representation for the current amount of Health points this Mech has
    private int healthPointsCurrent = 0;

    #endregion Private Fields

    #region Public Constructors

    public MechBehaviorDestructable(int armourPoints, int healthPoints)
    {
        logger.Debug("Constructing Object=?", this.GetType().ToString());
        this.armourPointsCurrent = armourPoints;
        this.armourPointsMaximum = armourPoints;
        this.healthPointsCurrent = healthPoints;
        this.healthPointsMaximum = healthPoints;
        logger.Debug("Constructed Object=?", this.GetType().ToString());
    }

    #endregion Public Constructors

    #region Public Methods

    public int CalculateDamageDealt(WeaponCombatReport weaponReport)
    {
        // Collect the number of shots that hit
        int numberOfShots = weaponReport.GetNumberOfShots();
        // Collect the damage per shots
        int damagePerShot = weaponReport.GetDamagePerShot();
        // Calculate the remaining armor after penetration
        int armorRemaining = this.armourPointsCurrent - weaponReport.GetPenetration();
        // Check that the armorRemaining is not less than 0
        if (armorRemaining < 0)
        {
            // Set the armorRemaining to 0
            armorRemaining = 0;
        }

        // Initiatlize return value
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

        return damageDealt;
    }

    public bool ConsumeWeaponReportSet(HashSet<WeaponCombatReport> weaponReportSet)
    {
        // Default False
        bool destructableIsDestroyed = false;

        // Check that the parameter is non-null
        if (weaponReportSet != null)
        {
            // Iterate over the weaponDamageReportSet
            foreach (WeaponCombatReport weaponReport in weaponReportSet)
            {
                // Calculate the damage dealt from the WeaponReport
                int damageDealt = this.CalculateDamageDealt(weaponReport);
                // Consume the damage
                destructableIsDestroyed = this.ConsumeDamage(damageDealt);

                // Check if the MechDestructable has been destroyed
                if (destructableIsDestroyed)
                {
                    // Break the loop since it is no longer needed
                    break;
                }
            }
        }

        return destructableIsDestroyed;
    }

    public int GetArmourCurrentPoints()
    {
        return this.armourPointsCurrent;
    }

    public int GetArmourMaximumPoints()
    {
        return this.armourPointsMaximum;
    }

    public int GetHealthCurrentPoints()
    {
        return this.healthPointsCurrent;
    }

    public int GetHealthMaximumPoints()
    {
        return this.healthPointsMaximum;
    }

    public void ResetPoints()
    {
        this.healthPointsCurrent = this.healthPointsMaximum;
        this.armourPointsCurrent = this.armourPointsMaximum;
    }

    #endregion Public Methods

    #region Private Methods

    private bool ConsumeDamage(int damage)
    {
        logger.Debug("Consuming ? Damage", damage);
        // Check if this damage will destroy this MechDestructable
        if (damage >= this.healthPointsCurrent)
        {
            return true;
        }
        // Otherwise deduct the damage from the HealthPoints
        else
        {
            // Deduct damage from the HealthPoints
            this.healthPointsCurrent -= damage;
            return false;
        }
    }

    #endregion Private Methods
}