using System.Collections.Generic;

/// <summary>
/// Todo
/// </summary>
public abstract class TalonBehaviorFireable
{
    #region Public Methods

    public abstract void AddWeapon(WeaponBehavior weaponBehavior);

    public abstract void BeginPathFinding();

    public abstract HashSet<WeaponCombatReport> GenerateWeaponReportSet(PathObjectFire pathObjectFire);

    public abstract HashSet<PathObject> GetPathObjectFireSet();

    public abstract List<WeaponIdEnum> GetWeaponIdList();

    public abstract void SetCubeCoodinates(CubeCoordinates cubeCoordinates);

    #endregion Public Methods
}