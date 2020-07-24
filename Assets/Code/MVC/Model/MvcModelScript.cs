using System.Diagnostics;

/// <summary>
/// MvcModel Script Api
/// </summary>
public abstract class MvcModelScript
    : AbstractUnityScript
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    #endregion Private Fields

    #region Public Methods

    public abstract void Initialize(MvcFrameworkScript mvcFrameworkScript);

    public abstract bool IsInitialized();

    public abstract MvcModelObject GetMvcModelObject();

    #endregion Public Methods
}