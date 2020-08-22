using System;
using System.Diagnostics;
using UnityEngine;

/// <summary>
/// Talon Model Impl
/// </summary>
public class TalonModelImpl
    : TalonModel
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    private readonly GameObject talonModelGameObject = null;

    #endregion Private Fields

    #region Public Constructors

    public TalonModelImpl(TalonObject talonObject)
    {
        if (talonObject != null)
        {
            this.talonModelGameObject = talonObject.GetTalonScript().GetGameObject();
        }
        else
        {
            throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                "\n\t>" + typeof(TalonObject) + " is null");
        }
    }

    #endregion Public Constructors

    #region Public Methods

    public override GameObject GetNextEmptyWeaponMountGameObject()
    {
        GameObject weaponSlotsGameObject = this.GetWeaponSlotsGameObject(this.talonModelGameObject);

        foreach (Transform childTransform in weaponSlotsGameObject.transform)
        {
            if (childTransform.childCount == 0)
            {
                return childTransform.gameObject;
            }
        }

        return null;
    }

    #endregion Public Methods

    #region Private Methods

    private GameObject GetWeaponSlotsGameObject(GameObject gameObject)
    {
        if (gameObject != null)
        {
            string weaponSlotsGameObjectName = "WeaponSlots";
            foreach (Transform childTransform in gameObject.transform)
            {
                if (weaponSlotsGameObjectName.Equals(childTransform.name))
                {
                    return childTransform.gameObject;
                }
                else if (childTransform.childCount > 0)
                {
                    return GetWeaponSlotsGameObject(childTransform.gameObject);
                }
            }
        }
        return null;
    }

    #endregion Private Methods
}