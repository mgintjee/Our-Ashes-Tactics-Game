/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Common.Exceptions;
using HappyBananaStudio.OurAshesTactics.Talon.Object.Api;
using HappyBananaStudio.OurAshesTactics.Talon.Visual.Api;
using System;
using System.Diagnostics;
using UnityEngine;

namespace HappyBananaStudio.OurAshesTactics.Talon.Visual.Impl
{
    /// <summary>
    /// Talon Model Impl
    /// </summary>
    public class TalonModelImpl
    : ITalonModel
    {
        #region Private Fields

        // Provide logging capability
        private static readonly Common.Logging.Logger logger = new Common.Logging.Logger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly GameObject talonModelGameObject = null;
        // Todo
        private readonly TalonWeaponMountsScript talonWeaponMountsScript;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonObject"></param>
        public TalonModelImpl(ITalonObject talonObject)
        {
            if (talonObject != null)
            {
                this.talonModelGameObject = talonObject.GetTalonScript().GetGameObject();
                this.talonWeaponMountsScript = this.talonModelGameObject.transform.GetChild(0).GetComponent<TalonWeaponMountsScript>();
            }
            else
            {
                throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                    "\n\t>" + typeof(ITalonObject) + " is null");
            }
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public GameObject GetWeaponMountGameObject(int index)
        {
            logger.Debug("Get WeaponMount[?]", index);
            if(index >= 0 &&
                index < this.talonWeaponMountsScript.GetWeaponMountCount())
            {
                logger.Debug("Mount=?", this.talonWeaponMountsScript.GetWeaponMountGameObject(index).name);
                return this.talonWeaponMountsScript.GetWeaponMountGameObject(index);
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid parameters." +
                    "\n\t> Index=? must be in range=[0,?]", new StackFrame().GetMethod().Name,
                    index, this.talonWeaponMountsScript.GetWeaponMountCount());
            }
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="gameObject"></param>
        /// <returns></returns>
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
}