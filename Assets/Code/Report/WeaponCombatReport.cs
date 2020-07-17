/// <summary>
/// Todo
/// </summary>
public class WeaponCombatReport
{
    #region Private Fields

    // Class Attributes
    private readonly int damagePerShot;

    private readonly int numberOfShots;

    private readonly int penetration;

    #endregion Private Fields

    #region Public Constructors

    /// <summary>
    /// Constructor method, to initialize this WeaponCombatReport
    /// </summary>
    /// <param name="numberOfShots">     The amount of shots from a weapon that hit</param>
    /// <param name="damagePerShot">     The amount of damage per shot</param>
    /// <param name="penetrationPerShot">The amount of armour ignored per shot</param>
    public WeaponCombatReport(int numberOfShots, int damagePerShot, int penetrationPerShot)
    {
        this.numberOfShots = numberOfShots;
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
        return this.numberOfShots;
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
            "\n DamagePerShot =" + this.GetDamagePerShot() +
            ",\n NumberOfShots=" + this.GetNumberOfShots() +
            ",\n Penetration=" + this.GetPenetration();
    }

    #endregion Public Methods
}