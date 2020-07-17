using System.Diagnostics;

/// <summary>
/// Todo
/// </summary>
public class WeaponScriptImpl
    : WeaponScript
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    // Todo
    private WeaponConstructionReport weaponConstructionReport;

    // Todo
    private WeaponObject weaponObject;

    #endregion Private Fields

    #region Public Methods

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public override WeaponBehavior GetWeaponBehavior()
    {
        return this.GetWeaponObject().GetWeaponBehavior();
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public override string GetWeaponName()
    {
        return this.GetWeaponObject().GetWeaponId().ToString();
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public override WeaponObject GetWeaponObject()
    {
        return this.weaponObject;
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public override WeaponVisual GetWeaponVisual()
    {
        return this.GetWeaponObject().GetWeaponVisual();
    }

    public override void Initialize(WeaponConstructionReport weaponConstructionReport)
    {
        logger.Debug("Initializing Script=?", this.GetType().ToString());
        this.weaponObject = new WeaponObjectImpl(this, weaponConstructionReport);
        this.weaponConstructionReport = weaponConstructionReport;
        this.name = weaponConstructionReport.GetWeaponId().ToString();
        this.GetWeaponVisual().PaintWeapon();
        logger.Info("Constructing Weapon: ?", this.weaponConstructionReport);
        logger.Debug("Initialized Script=?", this.GetType().ToString());
    }

    #endregion Public Methods
}