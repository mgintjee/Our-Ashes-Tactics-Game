/// <summary>
/// Todo
/// </summary>
public abstract class WeaponObject
{
    #region Public Methods

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public abstract WeaponBehavior GetWeaponBehavior();

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public abstract WeaponIdEnum GetWeaponId();

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public abstract WeaponScript GetWeaponScript();

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public abstract WeaponVisual GetWeaponVisual();

    #endregion Public Methods
}