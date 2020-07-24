/// <summary>
/// Todo
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
    public abstract WeaponCombatReport GenerateWeaponReport(int accuracyPenalty, int targetRange);

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public abstract int GetAccuracyPoints();

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public abstract int GetDamagePoints();

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public abstract int GetPenetrationPoints();

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public abstract int GetRangePoints();

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public abstract int GetRangeProximityPoints();

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public abstract int GetShotCountPoints();

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public abstract WeaponIdEnum GetWeaponId();

    #endregion Public Methods
}