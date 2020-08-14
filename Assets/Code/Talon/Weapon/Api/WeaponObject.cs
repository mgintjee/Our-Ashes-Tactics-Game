/// <summary>
/// Weapon Object Api
/// </summary>
public abstract class WeaponObject
{
    #region Public Methods

    public abstract WeaponCombatOrderReport GenerateWeaponCombatOrderReport(int accuracyPenalty, int targetRange);

    public abstract WeaponIdEnum GetWeaponId();

    public abstract WeaponScript GetWeaponScript();

    public abstract void Initialize();

    public abstract bool IsInitialized();

    public abstract WeaponBehavior GetWeaponBehavior();

    #endregion Public Methods
}