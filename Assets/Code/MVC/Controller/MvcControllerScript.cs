using System.Diagnostics;

/// <summary>
/// MvcController Script Api
/// </summary>
public abstract class MvcControllerScript
    : AbstractUnityScript
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    #endregion Private Fields

    #region Public Methods

    public abstract void Initialize(MvcFrameworkScript gameFrameworkScript);

    public abstract bool IsInitialized();

    public abstract MvcControllerObject GetMvcControllerObject();

    #endregion Public Methods
}