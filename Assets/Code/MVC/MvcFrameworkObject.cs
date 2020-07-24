using System.Collections.Generic;

/// <summary>
/// MvcFramework Object Api
/// </summary>
public abstract class MvcFrameworkObject
{
    #region Public Methods

    public abstract MapConstructionReport GetMapConstructionReport();

    public abstract Dictionary<TeamIdEnum, ControllerTypeEnum> GetTeamIdControllerTypeDictionary();

    public abstract Dictionary<TeamIdEnum, HashSet<MechConstructionReport>> GetTeamIdMechContructionReportDictionary();

    public abstract MvcFrameworkScript GetMvcFrameworkScript();

    public abstract MvcModelObject GetMvcModelObject();

    public abstract MvcViewObject GetMvcViewObject();

    public abstract MvcControllerObject GetMvcControllerObject();

    public abstract void Initialize(MvcInitializationReport mvcInitializationReport);

    public abstract bool IsInitialized();

    #endregion Public Methods
}