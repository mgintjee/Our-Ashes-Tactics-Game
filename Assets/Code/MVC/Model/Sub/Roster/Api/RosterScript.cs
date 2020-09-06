/// <summary>
/// Roster Script Api
/// </summary>
public abstract class RosterScript
    : AbstractUnityScript
{
    #region Public Methods

    public abstract RosterObject GetRosterObject();

    public abstract void Initialize(MvcModelScript mcvModelScript, RosterConstructionReport rosterConstructionReport);

    public abstract bool IsInitialized();

    #endregion Public Methods
}