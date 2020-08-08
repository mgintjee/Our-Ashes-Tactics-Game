/// <summary>
/// MvcFramework Object Api
/// </summary>
public abstract class MvcFrameworkObject
{
    #region Public Methods

    public abstract bool ContinueGame();

    public abstract MvcControllerObject GetMvcControllerObject();

    public abstract MvcFrameworkScript GetMvcFrameworkScript();

    public abstract MvcModelObject GetMvcModelObject();

    public abstract MvcViewObject GetMvcViewObject();

    public abstract void Initialize();

    public abstract bool IsInitialized();

    public abstract void StartNewGame();

    #endregion Public Methods
}