/// <summary>
/// MvcView Object Api
/// </summary>
public abstract class MvcViewObject
{
    #region Public Methods

    public abstract MvcViewScript GetMvcViewScript();

    public abstract void Initialize(MvcFrameworkObject mvcFrameworkObject);

    public abstract bool IsInitialized();

    #endregion Public Methods
}