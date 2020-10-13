/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>
/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Script;
using System.Collections.Generic;
using UnityEngine;

namespace HappyBananaStudio.OurAshesTactics.Impl.Scripts.Talons
{
    /// <summary>
    /// TalonMounts Script Impl
    /// </summary>
    public class TalonMountsScriptImpl
    : MonoBehaviour, ITalonMountsScript
    {
        // Todo
        [SerializeField] private IList<GameObject> utilityMountGameObjectsList = new List<GameObject>();

        // Todo
        [SerializeField] private IList<GameObject> weaponMountGameObjectsList = new List<GameObject>();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        int ITalonMountsScript.GetUtilityMountCount()
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
        GameObject ITalonMountsScript.GetUtilityMountGameObject(int index)
        {
            return this.utilityMountGameObjectsList[index];
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        int ITalonMountsScript.GetWeaponMountCount()
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
        GameObject ITalonMountsScript.GetWeaponMountGameObject(int index)
        {
            return this.weaponMountGameObjectsList[index];
        }
    }
}
