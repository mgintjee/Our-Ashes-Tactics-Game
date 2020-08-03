/// <summary>
/// Talon Object Api
/// </summary>
public abstract class TalonObject
{
    #region Public Methods

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public abstract TalonInformationReport GetCurrentTalonInformationReport();

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public abstract TalonInformationReport GetMaximumTalonInformationReport();

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public abstract TalonScript GetTalonScript();

    public abstract void Initialize();

    public abstract bool IsInitialized();
    public abstract void SetCubeCoordinates(CubeCoordinates cubeCoordinates);

    #endregion Public Methods
}