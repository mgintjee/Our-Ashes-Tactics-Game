using System.Collections.Generic;

/// <summary>
/// Talon Script Api
/// </summary>
public abstract class TalonScript
    : AbstractUnityScript
{
    #region Public Methods

    public abstract TalonObject GetTalonObject();

    public abstract void Initialize(TalonConstructionReport talonConstructionReport, List<WeaponObject> weaponObjectList);

    public abstract bool IsInitialized();

    #endregion Public Methods
}