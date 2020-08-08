using System.Diagnostics;

/// <summary>
/// MvcView Script Api
/// </summary>
public abstract class MvcViewScript
    : AbstractUnityScript
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    #endregion Private Fields

    #region Public Methods

    public abstract MvcViewObject GetMvcViewObject();

    public abstract void Initialize(MvcFrameworkScript mvcFrameworkScript);

    public abstract bool IsInitialized();

    #endregion Public Methods
}