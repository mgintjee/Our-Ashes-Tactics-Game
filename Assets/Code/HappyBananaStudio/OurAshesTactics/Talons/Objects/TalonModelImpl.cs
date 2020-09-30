/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Talons.Models;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Talons.Objects;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Exceptions;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Talons.Scripts;
using System.Diagnostics;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Talons.Objects
{
    /// <summary>
    /// Talon Model Impl
    /// </summary>
    public class TalonModelImpl
    : ITalonModelObject
    {
        // Provide logging capability
        private static readonly Common.Loggers.Logger logger = new Common.Loggers.Logger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly GameObject talonModelGameObject = null;

        // Todo
        private readonly ITalonMountsScript talonWeaponMountsScript;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonObject">
        /// </param>
        public TalonModelImpl(ITalonObject talonObject)
        {
            if (talonObject != null)
            {
                this.talonModelGameObject = talonObject.GetTalonScript().GetGameObject();
                this.talonWeaponMountsScript = this.talonModelGameObject.transform.GetChild(0).GetComponent<TalonMountsScriptImpl>();
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. " +
                    "\n\t> ? is null", this.GetType().Name, typeof(ITalonObject));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="index">
        /// </param>
        /// <returns>
        /// </returns>
        public GameObject GetWeaponMountGameObject(int index)
        {
            if (index >= 0 &&
                index < this.talonWeaponMountsScript.GetWeaponMountCount())
            {
                return this.talonWeaponMountsScript.GetWeaponMountGameObject(index);
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid parameters." +
                    "\n\t> Index=? must be in range=[0,?]", new StackFrame().GetMethod().Name,
                    index, this.talonWeaponMountsScript.GetWeaponMountCount());
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="gameObject">
        /// </param>
        /// <returns>
        /// </returns>
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
    }
}