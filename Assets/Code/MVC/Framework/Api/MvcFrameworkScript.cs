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

    public abstract bool IsGameActive();

    public abstract void ResetMvcFramework();

    public void FixedUpdate()
    {
        this.OnUpdate();
    }

    #endregion Public Methods

    #region Protected Methods

    protected abstract void OnUpdate();

    #endregion Protected Methods
}