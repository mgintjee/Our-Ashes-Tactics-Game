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

    public abstract MvcModelObject GetMvcModelObject();

    public abstract void Initialize(MvcFrameworkScript mvcFrameworkScript, MapInformationReport mapConstructionReport);

    public abstract bool IsInitialized();

    #endregion Public Methods
}