using UnityEngine;

/// <summary>
/// MapControllerScript Api
/// </summary>
[SerializeField]
public abstract class MapControllerScript
    : AbstractUnityScript
{
    #region Public Methods

    public abstract MechActionReport CollectMechActionReport();

    public abstract void DetermineNextMechActionReport(GameFrameworkObject gameFrameworkObject);

    public abstract MapControllerObject GetMapControllerObject();

    public abstract void Initialize(MapControllerObject mapControllerObject);

    public abstract bool MechActionReportIsAvailable();

    public abstract bool WaitingForMechActionReport();

    #endregion Public Methods
}