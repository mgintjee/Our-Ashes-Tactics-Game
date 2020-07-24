using UnityEngine;

/// <summary>
/// WeaponVisual Api
/// </summary>
public abstract class WeaponVisual
{
    #region Public Methods

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public abstract GameObject GetWeaponGameObject();

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public abstract WeaponIdEnum GetWeaponId();

    /// <summary>
    /// Todo
    /// </summary>
    public abstract void PaintWeapon();

    #endregion Public Methods
}