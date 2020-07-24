using System.Collections.Generic;

/// <summary>
/// Todo
/// </summary>
public abstract class MechBehavior
{
    #region Public Methods

    /// <summary>
    /// Todo
    /// </summary>
    /// <param name="weaponBehavior"></param>
    public abstract void AddWeapon(WeaponBehavior weaponBehavior);

    /// <summary>
    /// Todo
    /// </summary>
    public abstract void BeginPathFinding();

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public abstract CubeCoordinates GetCubeCoordinates();

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public abstract int GetCurrentArmourPoints();

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public abstract int GetCurrentHealthPoints();

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public abstract int GetCurrentOrderPoints();

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public abstract MechIdEnum GetMechId();

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public abstract MechInfoReport GetMechInfoReport();

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public abstract string GetMechName();

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public abstract TeamIdEnum GetTeamId();

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public abstract int GetMechTeamIndex();

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public abstract HashSet<PathObject> GetPathObjectFireSet();

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public abstract HashSet<PathObject> GetPathObjectMoveSet();

    /// <summary>
    /// Todo
    /// </summary>
    /// <param name="pathObject"></param>
    /// <returns></returns>
    public abstract HashSet<WeaponCombatReport> GetWeaponCombatReportSet(PathObjectFire pathObject);

    /// <summary>
    /// Todo
    /// </summary>
    /// <param name="mechActionReport"></param>
    /// <returns></returns>
    public abstract bool InputMechActionReport(ActionReport mechActionReport);

    /// <summary>
    /// Todo
    /// </summary>
    /// <param name="weaponCombatReportSet"></param>
    /// <returns></returns>
    public abstract bool InputWeaponCombatReportSet(HashSet<WeaponCombatReport> weaponCombatReportSet);

    /// <summary>
    /// Todo
    /// </summary>
    public abstract void ResetValuesForNewTurn();

    /// <summary>
    /// Todo
    /// </summary>
    /// <param name="tileCoordinates"></param>
    public abstract void SetCubeCoordinates(CubeCoordinates tileCoordinates);

    #endregion Public Methods
}