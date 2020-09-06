using System.Collections.Generic;

/// <summary>
/// Roster Object Api
/// </summary>
public abstract class RosterObject
{
    #region Public Methods

    /// <summary>
    /// Todo
    /// </summary>
    /// <param name="talonIdentificationReport"></param>
    public abstract void DeactivateTalonIdentificationReport(TalonIdentificationReport talonIdentificationReport);

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public abstract HashSet<TalonIdentificationReport> GetActiveTalonIdentificationReportSet();

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public abstract HashSet<TalonObject> GetAllTalonObjectSet();

    /// <summary>
    /// Todo
    /// </summary>
    /// <param name="talonPhalanxId"></param>
    /// <returns></returns>
    public abstract HashSet<TalonObject> GetAllTalonObjectSet(TalonPhalanxIdEnum talonPhalanxId);

    /// <summary>
    /// Todo
    /// </summary>
    /// <param name="talonFactionId"></param>
    /// <returns></returns>
    public abstract HashSet<TalonObject> GetAllTalonObjectSet(TalonFactionIdEnum talonFactionId);

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public abstract List<TalonIdentificationReport> GetOrderedTalonIdentificationReportList();

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public abstract RosterInformationReport GetRosterInformationReport();

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public abstract TalonControllerIdEnum GetTalonControllerId(TalonIdentificationReport talonIdentificationReport);

    /// <summary>
    /// Todo
    /// </summary>
    /// <param name="talonIdentificationReport"></param>
    /// <returns></returns>
    public abstract TalonObject GetTalonObject(TalonIdentificationReport talonIdentificationReport);

    #endregion Public Methods
}