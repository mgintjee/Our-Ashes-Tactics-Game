/// <summary>
/// Map Script Api
/// </summary>
public abstract class MapScript
    : AbstractUnityScript
{
    #region Public Methods

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public abstract MapInformationReport GetMapInfoReport();

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public abstract MapObject GetMapObject();

    /// <summary>
    /// Todo
    /// </summary>
    /// <param name="mcvModelScript">       </param>
    /// <param name="mapConstructionReport"></param>
    public abstract void Initialize(MvcModelScript mcvModelScript, MapInformationReport mapConstructionReport);

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public abstract bool IsInitialized();

    #endregion Public Methods
}