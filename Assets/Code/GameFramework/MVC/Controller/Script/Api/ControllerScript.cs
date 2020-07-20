/// <summary>
/// Controller Script Api
/// </summary>
public abstract class ControllerScript
    : AbstractUnityScript
{
    #region Public Methods

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public abstract bool ActionReportIsAvailable();

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public abstract ActionReport CollectActionReport();

    /// <summary>
    /// Todo
    /// </summary>
    public abstract void DetermineNextActionReport();

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public abstract ControllerObject GetMapControllerObject();

    /// <summary>
    /// Todo
    /// </summary>
    /// <param name="gameFrameworkScript"></param>
    public abstract void Initialize(GameFrameworkScript gameFrameworkScript);

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public abstract bool ProcessingInput();

    #endregion Public Methods
}