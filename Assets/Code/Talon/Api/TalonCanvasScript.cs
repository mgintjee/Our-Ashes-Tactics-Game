/// <summary>
/// Talon Canvas Script Api
/// </summary>
public abstract class TalonCanvasScript
    : AbstractUnityScript
{
    #region Public Methods

    public abstract TalonCanvasObject GetTalonCanvasObject();

    public abstract void Initialize(TalonObject talonObject);

    #endregion Public Methods
}