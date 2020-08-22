/// <summary>
/// Weapon Behvaior Api
/// </summary>
public abstract class WeaponBehavior
{
    #region Public Methods

    /// <summary>
    /// Todo
    /// </summary>
    /// <param name="accuracyPenalty"></param>
    /// <param name="targetRange">    </param>
    /// <returns></returns>
    public abstract WeaponCombatOrderReport GenerateWeaponReport(int accuracyPenalty, int targetRange);

    public abstract int GetMaxAccuracyPenalty(int targetRange);

    public abstract WeaponAttributes GetWeaponAttributes();

    public abstract WeaponIdEnum GetWeaponId();

    #endregion Public Methods
}