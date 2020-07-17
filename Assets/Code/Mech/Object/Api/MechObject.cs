using System.Collections.Generic;

/// <summary>
/// Todo
/// </summary>
public abstract class MechObject
{
    #region Public Methods

    public abstract HashSet<MechActionReport> GetMechActionReportSet();

    public abstract MechBehavior GetMechBehavior();

    public abstract MechIdEnum GetMechId();

    public abstract MechInfoReport GetMechInfoReport();

    public abstract string GetMechName();

    public abstract MechScript GetMechScript();

    public abstract int GetMechTeam();

    public abstract MechVisual GetMechVisual();

    public abstract HashSet<WeaponCombatReport> GetWeaponCombatReportSet(PathObjectFire pathObject);

    public abstract void SetCubeCoordinates(CubeCoordinates tileCoordinates);

    #endregion Public Methods
}