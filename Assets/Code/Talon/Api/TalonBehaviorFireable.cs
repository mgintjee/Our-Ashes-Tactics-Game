using System.Collections.Generic;

/// <summary>
/// Todo
/// </summary>
public abstract class TalonBehaviorFireable
{
    #region Public Methods

    public abstract void AddWeapon(WeaponBehavior weaponBehavior);

    public abstract void BeginPathFinding();

    public abstract int GetMaxAccuracyPenalty(int targetRange);

    public abstract HashSet<PathObject> GetPathObjectFireSet();

    public abstract TalonCombatOrderReport GetTalonCombatOrderReport(PathObjectFire pathObjectFire);

    public abstract List<WeaponIdEnum> GetWeaponIdList();

    public abstract void SetCubeCoodinates(CubeCoordinates cubeCoordinates);

    #endregion Public Methods
}