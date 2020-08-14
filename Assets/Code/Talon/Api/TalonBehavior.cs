using System.Collections.Generic;

/// <summary>
/// Talon Behavior Api
/// </summary>
public abstract class TalonBehavior
{
    #region Public Methods

    public abstract void AddWeaponBehavior(WeaponBehavior weaponBehavior);

    public abstract CubeCoordinates GetCubeCoordinates();

    public abstract TalonAttributesReport GetCurrentTalonAttributesReport();

    public abstract TalonAttributesReport GetMaximumTalonAttributesReport();

    public abstract HashSet<TalonActionOrderReport> GetPossibleTalonActionOrderReportSet();

    public abstract TalonCombatOrderReport GetTalonCombatOrderReport(PathObjectFire pathObjectFire);

    public abstract TalonActionResultReport InputTalonActionOrderReport(TalonActionOrderReport talonActionOrderReport);

    public abstract TalonCombatResultReport InputTalonCombatOrderReport(TalonCombatOrderReport talonCombatOrderReport);

    public abstract void SetCubeCoordinates(CubeCoordinates cubeCoordinates);

    #endregion Public Methods
}