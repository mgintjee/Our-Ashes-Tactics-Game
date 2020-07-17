using UnityEngine;

/// <summary>
/// MapController Api
/// </summary>
[SerializeField]
public abstract class MapControllerObject
{
    #region Public Methods

    public abstract MechActionReport CollectMechActionReport(GameFrameworkObject gameFrameworkObject);

    #endregion Public Methods
}