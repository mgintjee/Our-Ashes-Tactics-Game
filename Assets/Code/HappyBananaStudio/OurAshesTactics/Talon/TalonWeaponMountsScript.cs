/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Common.UnityScript;
using HappyBananaStudio.OurAshesTactics.Talon.Object.Api;
using UnityEngine;

namespace HappyBananaStudio.OurAshesTactics.Talon.Visual.Api
{
    /// <summary>
    /// Talon Weapon Mounts Script Api
    /// </summary>
    public abstract class TalonWeaponMountsScript
    : AbstractUnityScript
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public abstract GameObject GetWeaponMountGameObject(int index);
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public abstract int GetWeaponMountCount();
    }
}