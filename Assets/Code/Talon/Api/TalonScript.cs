/// <summary>
/// Talon Script Api
/// </summary>
public abstract class TalonScript
    : AbstractUnityScript
{
    #region Public Methods

    public abstract TalonObject GetTalonObject();

    public abstract void Initialize(TalonConstructionReport talonConstructionReport);

    #endregion Public Methods
}