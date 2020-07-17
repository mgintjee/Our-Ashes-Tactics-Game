/// <summary>
/// Todo
/// </summary>
public abstract class WeaponScript
    : AbstractUnityScript
{
    #region Public Methods

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public abstract WeaponBehavior GetWeaponBehavior();

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public abstract string GetWeaponName();

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public abstract WeaponObject GetWeaponObject();

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public abstract WeaponVisual GetWeaponVisual();

    /// <summary>
    /// Todo
    /// </summary>
    public abstract void Initialize(WeaponConstructionReport weaponConstructionReport);

    #endregion Public Methods
}