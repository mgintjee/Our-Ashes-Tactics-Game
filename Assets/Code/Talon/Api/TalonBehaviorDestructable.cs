using System.Collections.Generic;

/// <summary>
/// Talon Behavior Destructable Api
/// </summary>
public abstract class TalonBehaviorDestructable
{
    #region Public Methods

    public abstract int CalculateDamageDealt(WeaponCombatReport weaponReport);

    public abstract bool ConsumeWeaponReportSet(HashSet<WeaponCombatReport> weaponReportSet);

    public abstract int GetCurrentArmourPoints();

    public abstract int GetCurrentHealthPoints();

    public abstract int GetMaximumArmourPoints();

    public abstract int GetMaximumHealthPoints();

    #endregion Public Methods
}