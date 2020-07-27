/// <summary>
/// MvcController Object Api
/// </summary>
public abstract class MvcControllerObject
{
    #region Public Methods

    public abstract MvcControllerScript GetMvcControllerScript();

    public abstract void Initialize(MvcFrameworkObject mvcFrameworkObject);

    public abstract bool IsInitialized();

    public abstract bool IsReadyToOutputActionReport();

    public abstract bool IsDeterminingActionReport();

    public abstract ActionReport OutputActionReport();

    public abstract void DetermineActionReport(ControllerTypeEnum controllerType, MechObject mechObject);

    #endregion Public Methods
}