/// <summary>
/// MvcController Object Api
/// </summary>
public abstract class MvcControllerObject
{
    #region Public Methods

    public abstract void DetermineActionReport(TalonControllerTypeEnum controllerType, TalonObject mechObject);

    public abstract MvcControllerScript GetMvcControllerScript();

    public abstract void Initialize(MvcFrameworkObject mvcFrameworkObject);

    public abstract bool IsDeterminingActionReport();

    public abstract bool IsInitialized();

    public abstract bool IsReadyToOutputActionReport();

    public abstract TalonActionOrderReport OutputActionReport();

    #endregion Public Methods
}