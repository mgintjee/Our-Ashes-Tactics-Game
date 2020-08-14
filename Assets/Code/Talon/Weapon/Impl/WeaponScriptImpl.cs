using System;
using System.Diagnostics;

/// <summary>
/// Weapon Script Impl
/// </summary>
public class WeaponScriptImpl
    : WeaponScript
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    private WeaponIdEnum weaponId = WeaponIdEnum.NULL;
    private WeaponObject weaponObject = null;

    #endregion Private Fields

    #region Public Methods

    public override WeaponIdEnum GetWeaponId()
    {
        return this.weaponId;
    }

    public override WeaponObject GetWeaponObject()
    {
        return this.weaponObject;
    }

    public override void Initialize(WeaponIdEnum weaponId)
    {
        // Check that this has not already been initialized
        if (!this.IsInitialized())
        {
            // Check that the parameters are non-null
            if (weaponId != WeaponIdEnum.NULL)
            {
                logger.Info("Initializing: ?.", this.GetType());
                this.weaponId = weaponId;
                this.weaponObject = new WeaponObjectImpl(this, this.weaponId);
                this.weaponObject.Initialize();
            }
            else
            {
                throw new ArgumentException("Unable to initialize " + this.GetType() + ". Invalid Parameters." +
                    "\n\t>" + typeof(WeaponIdEnum) + "=" + weaponId);
            }
        }
        else
        {
            logger.Warn("Unable to Initialize: ?. Already initialized.", this.GetType());
        }
    }

    public override bool IsInitialized()
    {
        return this.weaponObject != null &&
            this.weaponId != WeaponIdEnum.NULL;
    }

    #endregion Public Methods
}