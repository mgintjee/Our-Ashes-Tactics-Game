/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Common.UnityScript;
using HappyBananaStudio.OurAshesTactics.Talon.Object.Api;
using System.Collections.Generic;
using UnityEngine;

namespace HappyBananaStudio.OurAshesTactics.Talon.Visual.Api
{
    /// <summary>
    /// Talon Weapon Mounts Script Impl
    /// </summary>
    public class TalonWeaponMountsScriptImpl
    : TalonWeaponMountsScript
    {
        // Todo
        public List<GameObject> weaponMountGameObjectsList = new List<GameObject>();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public override int GetWeaponMountCount()
        {
            return this.weaponMountGameObjectsList.Count;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public override GameObject GetWeaponMountGameObject(int index)
        {
                return this.weaponMountGameObjectsList[index];
        }
    }
}