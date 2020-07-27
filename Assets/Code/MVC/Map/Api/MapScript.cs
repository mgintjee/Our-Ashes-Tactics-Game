/// <summary>
/// Map Script Api
/// </summary>
public abstract class MapScript
    : AbstractUnityScript
{
    #region Public Methods

    public abstract MapObject GetMapObject();

    public abstract MapInfoReport GetMapInfoReport();

    public abstract void Initialize(MvcModelScript mcvModelScript, MapConstructionReport mapConstructionReport);

    public abstract bool IsInitialized();

    #endregion Public Methods
}