/// <summary>
/// Weapon Object Api
/// </summary>
public abstract class WeaponObject
{
    #region Public Methods

    public abstract WeaponCombatOrderReport GenerateWeaponCombatOrderReport(int accuracyPenalty, int targetRange);

    public abstract WeaponBehavior GetWeaponBehavior();

    public abstract WeaponIdEnum GetWeaponId();

    public abstract WeaponScript GetWeaponScript();

    public abstract void Initialize();

    public abstract bool IsInitialized();

    #endregion Public Methods
}