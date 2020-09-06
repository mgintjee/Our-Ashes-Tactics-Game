/// <summary>
/// MvcModel Script Api
/// </summary>
public abstract class MvcModelScript
    : AbstractUnityScript
{
    #region Public Methods

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public abstract MvcModelObject GetMvcModelObject();

    /// <summary>
    /// Todo
    /// </summary>
    /// <param name="mvcFrameworkScript">      </param>
    /// <param name="mapConstructionReport">   </param>
    /// <param name="rosterConstructionReport"></param>
    public abstract void Initialize(MvcFrameworkScript mvcFrameworkScript,
        MapConstructionReport mapConstructionReport,
        RosterConstructionReport rosterConstructionReport);

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public abstract bool IsInitialized();

    #endregion Public Methods
}