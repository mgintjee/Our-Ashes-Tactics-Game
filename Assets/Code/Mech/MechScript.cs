/// <summary>
/// Todo
/// </summary>
public abstract class MechScript
    : AbstractUnityScript
{
    #region Public Methods

    public abstract void AddWeapon(WeaponScript weaponScript);

    public abstract MechBehavior GetMechBehavior();

    public abstract MechInfoReport GetMechInfoReport();

    public abstract string GetMechName();

    public abstract MechObject GetMechObject();

    public abstract TeamIdEnum GetTeamId();

    public abstract MechVisual GetMechVisual();

    public abstract void Initialize(MechConstructionReport mechConstructionReport);

    #endregion Public Methods
}