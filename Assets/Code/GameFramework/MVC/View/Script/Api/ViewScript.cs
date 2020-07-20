/// <summary>
/// View Script Api
/// </summary>
public abstract class ViewScript
    : AbstractUnityScript
{
    #region Public Methods

    public abstract GameFrameworkScript GetGameFrameworkScript();

    public abstract ViewObject GetMapModelObject();

    public abstract void Initialize(GameFrameworkScript gameFrameworkScript);

    #endregion Public Methods
}