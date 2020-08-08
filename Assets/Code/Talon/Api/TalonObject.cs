using System.Collections.Generic;

/// <summary>
/// Talon Object Api
/// </summary>
public abstract class TalonObject
{
    #region Public Methods

    public abstract CubeCoordinates GetCubeCoordinates();

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public abstract TalonInformationReport GetCurrentTalonInformationReport();

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public abstract TalonInformationReport GetMaximumTalonInformationReport();

    public abstract HashSet<TalonActionOrderReport> GetPossibleTalonActionOrderReportSet();

    public abstract TalonCombatOrderReport GetTalonCombatOrderReport(PathObjectFire pathObjectFire);

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public abstract TalonScript GetTalonScript();

    public abstract void Initialize();

    public abstract TalonActionResultReport InputTalonActionOrderReport(TalonActionOrderReport talonActionOrderReport);

    public abstract TalonCombatResultReport InputTalonCombatOrderReport(TalonCombatOrderReport talonCombatOrderReport);

    public abstract bool IsInitialized();

    public abstract void SetCubeCoordinates(CubeCoordinates cubeCoordinates);

    #endregion Public Methods
}