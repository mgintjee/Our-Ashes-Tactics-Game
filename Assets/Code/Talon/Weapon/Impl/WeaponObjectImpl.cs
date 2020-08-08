/// <summary>
/// </summary>
public class WeaponObjectImpl
    : WeaponObject
{
    #region Private Fields

    // Todo
    private readonly WeaponBehavior weaponBehavior;

    // Todo
    private readonly WeaponIdEnum weaponId;

    // Todo
    private readonly WeaponScript weaponScript;

    // Todo
    private readonly WeaponVisual weaponVisual;

    #endregion Private Fields

    #region Public Constructors

    public WeaponObjectImpl(WeaponScript weaponScript, WeaponConstructionReport weaponConstructionReport)
    {
        this.weaponId = weaponConstructionReport.GetWeaponId();
        this.weaponScript = weaponScript;
        this.weaponBehavior = new WeaponBehaviorImpl(this.GetWeaponId());
        this.weaponVisual = new WeaponVisualImpl(this.weaponScript, weaponConstructionReport);
    }

    #endregion Public Constructors

    #region Public Methods

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public override WeaponBehavior GetWeaponBehavior()
    {
        return this.weaponBehavior;
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public override WeaponIdEnum GetWeaponId()
    {
        return this.weaponId;
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public override WeaponScript GetWeaponScript()
    {
        return this.weaponScript;
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public override WeaponVisual GetWeaponVisual()
    {
        return this.weaponVisual;
    }

    #endregion Public Methods
}