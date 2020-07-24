/// <summary>
/// MvcController Object Api
/// </summary>
public abstract class MvcControllerObject
{
    #region Public Methods

    public abstract MvcControllerScript GetMvcControllerScript();

    public abstract void Initialize(MvcFrameworkObject mvcFrameworkObject);

    public abstract bool IsInitialized();

    #endregion Public Methods
}