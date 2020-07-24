/// <summary>
/// MvcFramework Script Api
/// </summary>
public abstract class MvcFrameworkScript
    : AbstractUnityScript
{
    #region Public Methods

    public abstract void Initialize(MvcInitializationReport mvcInitializationReport);

    public abstract bool IsInitialized();

    public abstract MvcFrameworkObject GetMvcFrameworkObject();

    public abstract MvcModelScript GetMvcModelScript();

    public abstract MvcViewScript GetMvcViewScript();

    public abstract MvcControllerScript GetMvcControllerScript();

    #endregion Public Methods
}