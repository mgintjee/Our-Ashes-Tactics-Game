/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Api;
using System;
using UnityEngine;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Impl
{
    /// <summary>
    /// Talon Model Impl
    /// </summary>
    public class TalonModelImpl
    : ITalonModel
    {
        #region Private Fields

        // Todo
        private readonly GameObject talonModelGameObject = null;

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
        /// <returns></returns>
        public GameObject GetNextEmptyWeaponMountGameObject()
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