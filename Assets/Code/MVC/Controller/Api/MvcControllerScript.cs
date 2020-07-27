using System.Diagnostics;

/// <summary>
/// MvcController Script Api
/// </summary>
public abstract class MvcControllerScript
    : AbstractUnityScript
{

    #region Public Methods

    public abstract void Initialize(MvcFrameworkScript gameFrameworkScript);

    public abstract bool IsInitialized();

    public abstract MvcControllerObject GetMvcControllerObject();

    #endregion Public Methods
}