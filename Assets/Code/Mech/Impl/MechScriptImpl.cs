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

    private MechConstructionReport mechConstructionReport;
    private MechObject mechObject;

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
        if (this.GetMechObject() != null)
        {
            return this.GetMechObject().GetMechBehavior();
        }
        else
        {
            logger.Warn("Unable to get ?. ? is null.",
                typeof(MechBehavior), typeof(MechObject));
            return null;
        }
    }

    public override MechInfoReport GetMechInfoReport()
    {
        if (this.GetMechBehavior() != null)
        {
            return this.GetMechBehavior().GetMechInfoReport();
        }
        else
        {
            logger.Warn("Unable to get ?. ? is null.",
                typeof(MechInfoReport), typeof(MechBehavior));
            return null;
        }
    }

    public override string GetMechName()
    {
        if (this.GetMechObject() != null)
        {
            return this.GetMechObject().GetMechName();
        }
        else
        {
            logger.Warn("Unable to get MechName. ? is null.",
                typeof(MechObject));
            return "";
        }
    }

    public override MechObject GetMechObject()
    {
        return this.mechObject;
    }

    public override TeamIdEnum GetTeamId()
    {
        return this.mechObject.GetTeamId();
    }

    public override MechVisual GetMechVisual()
    {
        return this.GetMechObject().GetMechVisual();
    }

    public override void Initialize(MechConstructionReport mechConstructionReport)
    {
        logger.Info("Constructing Mech: ?", mechConstructionReport);
        logger.Debug("Initializing=?", this.GetType());
        this.mechObject = new MechObjectImpl(this, mechConstructionReport);
        this.mechConstructionReport = mechConstructionReport;
        this.name = mechConstructionReport.GetMechName();
        this.GetMechVisual().PaintMech();
        logger.Debug("Initialized=?", this.GetType());
    }

    #endregion Public Methods
}