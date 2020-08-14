using System;

/// <summary>
/// Weapon Behvaior Impl
/// </summary>
public class WeaponBehaviorImpl
    : WeaponBehavior
{
    #region Private Fields

    private readonly WeaponAttributes weaponAttributes = null;
    private readonly WeaponIdEnum weaponId = WeaponIdEnum.NULL;

    #endregion Private Fields

    #region Public Constructors

    public WeaponBehaviorImpl(WeaponIdEnum weaponId)
    {
        if (weaponId != WeaponIdEnum.NULL)
        {
            this.weaponId = weaponId;
            this.weaponAttributes = WeaponAttributeConstants.GetImplementedWeaponAttributes(weaponId);
        }
        else
        {
            throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                "\n\t>" + typeof(WeaponIdEnum) + " is null");
        }
    }

    #endregion Public Constructors

    #region Public Methods

    public override WeaponCombatOrderReport GenerateWeaponReport(int accuracyPenalty, int targetRange)
    {
        return null;
    }

    public override WeaponAttributes GetWeaponAttributes()
    {
        return this.weaponAttributes;
    }

    public override WeaponIdEnum GetWeaponId()
    {
        return this.weaponId;
    }

    #endregion Public Methods
}