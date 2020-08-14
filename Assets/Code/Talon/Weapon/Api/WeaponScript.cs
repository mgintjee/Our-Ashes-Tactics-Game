/// <summary>
/// Weapon Script Api
/// </summary>
public abstract class WeaponScript
    : AbstractUnityScript
{
    #region Public Methods

    public abstract WeaponIdEnum GetWeaponId();

    public abstract WeaponObject GetWeaponObject();

    public abstract void Initialize(WeaponIdEnum weaponId);

    public abstract bool IsInitialized();

    #endregion Public Methods
}