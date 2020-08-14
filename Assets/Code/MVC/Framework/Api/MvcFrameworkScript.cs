/// <summary>
/// MvcFramework Script Api
/// </summary>
public abstract class MvcFrameworkScript
    : AbstractUnityScript
{
    #region Public Methods

    public abstract MvcControllerScript GetMvcControllerScript();

    public abstract MvcFrameworkObject GetMvcFrameworkObject();

    public abstract MvcModelScript GetMvcModelScript();

    public abstract MvcViewScript GetMvcViewScript();

    public abstract void Initialize(MvcInitializationReport mvcInitializationReport);

    public abstract bool IsGameActive();

    public abstract bool IsInitialized();

    public abstract void ResetMvcFramework();

    #endregion Public Methods
}