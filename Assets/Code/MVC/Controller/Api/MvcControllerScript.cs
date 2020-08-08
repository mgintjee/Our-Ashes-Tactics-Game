/// <summary>
/// MvcController Script Api
/// </summary>
public abstract class MvcControllerScript
    : AbstractUnityScript
{
    #region Public Methods

    public abstract MvcControllerObject GetMvcControllerObject();

    public abstract void Initialize(MvcFrameworkScript gameFrameworkScript);

    public abstract bool IsInitialized();

    #endregion Public Methods
}