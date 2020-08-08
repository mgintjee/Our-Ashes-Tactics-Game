using System;
using System.Collections.Generic;

/// <summary>
/// Todo
/// </summary>
public class WeaponCombatOrderReport
{
    #region Private Fields

    // Todo
    private readonly int damagePerShot = int.MinValue;

    // Todo
    private readonly int shotsHit = int.MinValue;

    // Todo
    private readonly int penetration = int.MinValue;

    #endregion Private Fields

    #region Public Constructors

    /// <summary>
    /// Constructor method, to initialize this WeaponCombatReport
    /// </summary>
    /// <param name="numberOfShots">     The amount of shots from a weapon that hit</param>
    /// <param name="damagePerShot">     The amount of damage per shot</param>
    /// <param name="penetrationPerShot">The amount of armour ignored per shot</param>
    private WeaponCombatOrderReport(int numberOfShots, int damagePerShot, int penetrationPerShot)
    {
        this.shotsHit = numberOfShots;
        this.damagePerShot = damagePerShot;
        this.penetration = penetrationPerShot;
    }

    #endregion Public Constructors

    /////////////
    // Getters
    /////////////

    #region Public Methods

    /// <summary>
    /// Getter method, return the DamagePerShot
    /// </summary>
    /// <returns>Integer DamagePerShot</returns>
    public int GetDamagePerShot()
    {
        return this.damagePerShot;
    }

    /// <summary>
    /// Getter method, return the NumberOfShots
    /// </summary>
    /// <returns>Integer NumberOfShots</returns>
    public int GetNumberOfShots()
    {
        return this.shotsHit;
    }

    /// <summary>
    /// Getter method, return the PenetrationPerShot
    /// </summary>
    /// <returns>Integer Penetration</returns>
    public int GetPenetration()
    {
        return this.penetration;
    }

    public override string ToString()
    {
        return this.GetType().ToString() + ":" +
            "\n damagePerShot =" + this.GetDamagePerShot() +
            "\n shotsHit=" + this.GetNumberOfShots() +
            "\n penetration=" + this.GetPenetration();
    }

    public class Builder
    {
        // Todo
        private int damagePerShot = int.MinValue;

        // Todo
        private int shotsHit = int.MinValue;

        // Todo
        private int penetration = int.MinValue;

        public WeaponCombatOrderReport Build()
        {
            HashSet<string> invalidReasons = this.IsValid();
            // Check that the set parameters are valid
            if (invalidReasons.Count == 0)
            {
                // Instantiate a new Report
                return new WeaponCombatOrderReport(this.damagePerShot, this.shotsHit, this.penetration);
            }
            else
            {
                throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                    string.Join("\n>", invalidReasons));
            }
        }

        public Builder SetDamagePerShot(int damagePerShot)
        {
            this.damagePerShot = damagePerShot;
            return this;
        }

        public Builder SetShotsHit(int shotsHit)
        {
            this.shotsHit = shotsHit;
            return this;
        }

        public Builder SetPenetration(int penetration)
        {
            this.penetration = penetration;
            return this;
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private HashSet<string> IsValid()
        {
            // Default an empty Set: String
            HashSet<string> argumentExceptionSet = new HashSet<string>();
            // Check that damagePerShot has been set
            if (this.damagePerShot < 1)
            {
                argumentExceptionSet.Add("damagePerShot=" + this.damagePerShot + " is not valid");
            }
            // Check that shotsHit has been set
            if (this.shotsHit < 0)
            {
                argumentExceptionSet.Add("shotsHit=" + this.shotsHit + " is not valid");
            }
            // Check that penetration has been set
            if (this.penetration < 0)
            {
                argumentExceptionSet.Add("penetration=" + this.penetration + " is not valid");
            }
            return argumentExceptionSet;
        }
    }

    #endregion Private Methods
}