/// <summary>
/// MvcModel Object Api
/// </summary>
public abstract class MvcModelObject
{
    #region Public Methods

    public abstract MvcModelScript GetMvcModelScript();

    public abstract void Initialize(MvcFrameworkObject mvcFrameworkObject);

    public abstract bool IsInitialized();

    #endregion Public Methods
}