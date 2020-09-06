using System.Collections.Generic;

/// <summary>
/// MvcModel Object Api
/// </summary>
public abstract class MvcModelObject
{
    #region Public Methods

    public abstract bool ContinueGame();

    public abstract HashSet<TalonIdentificationReport> GetActiveTalonIdentificationReportSet();

    public abstract TalonIdentificationReport GetCurrentTalonIdentificationReport();

    public abstract MvcModelInformationReport GetMvcModelInformationReport();

    public abstract MvcModelScript GetMvcModelScript();

    public abstract List<TalonIdentificationReport> GetOrderedTalonIdentificationReportList();

    public abstract TalonInformationReport GetTalonInformationReport(TalonIdentificationReport talonIdentificationReport);

    public abstract void Initialize(MvcFrameworkObject mvcFrameworkObject, MvcInitializationReport mvcInitializationReport);

    public abstract TalonTurnReport InputTalonActionOrderReport(TalonActionOrderReport actionReport);

    public abstract bool IsInitialized();

    public abstract bool IsProcessingActionReport();

    public abstract void StartGame();

    #endregion Public Methods
}