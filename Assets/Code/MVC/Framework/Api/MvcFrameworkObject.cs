using System.Collections.Generic;

/// <summary>
/// MvcFramework Object Api
/// </summary>
public abstract class MvcFrameworkObject
{
    #region Public Methods

    public abstract Dictionary<TeamIdEnum, ControllerTypeEnum> GetTeamIdControllerTypeDictionary();

    public abstract HashSet<MechConstructionReport> GetMechContructionReportSet();

    public abstract MvcFrameworkScript GetMvcFrameworkScript();

    public abstract MvcModelObject GetMvcModelObject();

    public abstract MvcViewObject GetMvcViewObject();

    public abstract MvcControllerObject GetMvcControllerObject();

    public abstract void Initialize();

    public abstract bool IsInitialized();

    public abstract void StartNewGame();

    public abstract bool ContinueGame();

    #endregion Public Methods
}