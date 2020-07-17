using System.Diagnostics;

/// <summary>
/// Todo
/// </summary>
public class MechScriptImpl
    : MechScript
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    private MechObject mechObject;
    private MechConstructionReport weaponConstructionReport;

    #endregion Private Fields

    #region Public Methods

    public override void AddWeapon(WeaponScript weaponScript)
    {
        logger.Debug("Mech: Name=?, Attempting to Add Weapon", this.GetMechBehavior().GetMechName());
        if (weaponScript != null)
        {
            this.GetMechBehavior().AddWeapon(weaponScript.GetWeaponBehavior());
            this.GetMechVisual().AddWeapon(weaponScript.GetWeaponVisual());
        }
        else
        {
            logger.Warn("Unable to add WeaponScript. WeaponScript is null");
        }
    }

    public override MechBehavior GetMechBehavior()
    {
        return this.GetMechObject().GetMechBehavior();
    }

    public override MechInfoReport GetMechInfoReport()
    {
        return this.GetMechBehavior().GetMechInfoReport();
    }

    public override string GetMechName()
    {
        if (this.GetMechObject() != null)
        {
            return this.GetMechObject().GetMechName();
        }
        else
        {
            logger.Warn("Unable to get MechName. MechObject is null.");
            return "null";
        }
    }

    public override MechObject GetMechObject()
    {
        return this.mechObject;
    }

    public override int GetMechTeam()
    {
        return this.mechObject.GetMechTeam();
    }

    public override MechVisual GetMechVisual()
    {
        return this.GetMechObject().GetMechVisual();
    }

    public override void Initialize(MechConstructionReport mechConstructionReport)
    {
        logger.Debug("Initializing Script=?", this.GetType().ToString());
        this.mechObject = new MechObjectImpl(this, mechConstructionReport);
        this.weaponConstructionReport = mechConstructionReport;
        this.name = mechConstructionReport.GetMechName();
        this.GetMechVisual().PaintMech();
        logger.Info("Constructing Mech: ?", this.weaponConstructionReport);
        logger.Debug("Initialized Script=?", this.GetType().ToString());
    }

    #endregion Public Methods
}