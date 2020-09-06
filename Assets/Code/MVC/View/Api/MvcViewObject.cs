using System.Collections.Generic;

/// <summary>
/// MvcView Object Api
/// </summary>
public abstract class MvcViewObject
{
    #region Public Methods

    public abstract void DestroyTalonCanvas(TalonIdentificationReport talonIdentificationReport);

    public abstract MvcViewScript GetMvcViewScript();

    public abstract void Initialize(MvcFrameworkObject mvcFrameworkObject);

    public abstract bool IsInitialized();

    public abstract void UpdateTalonCanvas(TalonIdentificationReport talonIdentificationReport);

    public abstract void UpdateTalonOrderList(List<TalonObject> talonObjectOrderList);

    #endregion Public Methods
}