/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Talons;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Scripts.Talons
{
    /// <summary>
    /// Talon Weapon Mounts Script Impl
    /// </summary>
    public class TalonMountsScriptImpl
    : MonoBehaviour, ITalonMountsScript
    {
        // Todo
        [SerializeField] private List<GameObject> utilityMountGameObjectsList = new List<GameObject>();

        // Todo
        [SerializeField] private List<GameObject> weaponMountGameObjectsList = new List<GameObject>();

        public void Destroy()
        {
            Destroy(this.gameObject);
        }

        public GameObject GetGameObject()
        {
            return this.gameObject;
        }

        public Transform GetTransform()
        {
            return this.transform;
        }

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