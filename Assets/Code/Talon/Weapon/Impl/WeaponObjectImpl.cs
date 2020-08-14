using System;
using System.Diagnostics;

/// <summary>
/// Weapon Object Impl
/// </summary>
public class WeaponObjectImpl
    : WeaponObject
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    private readonly WeaponIdEnum weaponId = WeaponIdEnum.NULL;
    private readonly WeaponScript weaponScript = null;
    private WeaponBehavior weaponBehavior = null;
    private WeaponBehavior weaponVisual = null;

    #endregion Private Fields

    #region Public Constructors

    public WeaponObjectImpl(WeaponScript weaponScript, WeaponIdEnum weaponId)
    {
        if (weaponScript != null &&
            weaponId != WeaponIdEnum.NULL)
        {
            logger.Info("Constructing: ?.", this.GetType());
            this.weaponScript = weaponScript;
            this.weaponId = weaponId;
        }
        else
        {
            throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                "\n\t>" + typeof(WeaponScript) + " is null: " + (weaponScript == null) +
                "\n\t>" + typeof(WeaponIdEnum) + " is null: " + (weaponId == WeaponIdEnum.NULL));
        }
    }

    #endregion Public Constructors

    #region Public Methods

    public override WeaponCombatOrderReport GenerateWeaponCombatOrderReport(int accuracyPenalty, int targetRange)
    {
        return this.weaponBehavior.GenerateWeaponReport(accuracyPenalty, targetRange);
    }

    public override WeaponIdEnum GetWeaponId()
    {
        return this.weaponId;
    }

    public override WeaponScript GetWeaponScript()
    {
        return this.weaponScript;
    }

    public override void Initialize()
    {
        if (!this.IsInitialized())
        {
            this.weaponBehavior = new WeaponBehaviorImpl(this.weaponId);
            //this.talonVisual = new TalonVisualImpl(this, this.talonConstructionReport);
        }
        else
        {
            logger.Warn("Unable to Initialize: ?. Already initialized.", this.GetType());
        }
    }

    public override bool IsInitialized()
    {
        return this.weaponBehavior != null &&
            this.weaponVisual != null;
    }

    #endregion Public Methods
}