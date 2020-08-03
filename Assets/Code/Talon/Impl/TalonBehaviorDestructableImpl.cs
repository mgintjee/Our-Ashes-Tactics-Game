using System.Collections.Generic;

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
    }

    #endregion Public Constructors

    #region Public Methods

    public override int CalculateDamageDealt(WeaponCombatReport weaponReport)
    {
        //throw new System.NotImplementedException();
        return 0;
    }

    public override bool ConsumeWeaponReportSet(HashSet<WeaponCombatReport> weaponReportSet)
    {
        //throw new System.NotImplementedException();
        return false;
    }

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

    #endregion Public Methods
}