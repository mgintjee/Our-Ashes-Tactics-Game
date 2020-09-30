/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Unity;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Talons.Scripts
{
    /// <summary>
    /// Talon Weapon Mounts Script Impl
    /// </summary>
    public class TalonMountsScriptImpl
    : UnityScript, ITalonMountsScript
    {
        // Todo
        [SerializeField] private List<GameObject> utilityMountGameObjectsList = new List<GameObject>();

        // Todo
        [SerializeField] private List<GameObject> weaponMountGameObjectsList = new List<GameObject>();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public int GetUtilityMountCount()
        {
            return this.utilityMountGameObjectsList.Count;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="index">
        /// </param>
        /// <returns>
        /// </returns>
        public GameObject GetUtilityMountGameObject(int index)
        {
            return this.utilityMountGameObjectsList[index];
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public int GetWeaponMountCount()
        {
            return this.weaponMountGameObjectsList.Count;
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
            return this.weaponMountGameObjectsList[index];
        }
    }
}