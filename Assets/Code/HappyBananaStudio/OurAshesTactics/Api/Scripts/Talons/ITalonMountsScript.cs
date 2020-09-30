/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Unity;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Talons
{
    /// <summary>
    /// Talon Weapon Mounts Script Api
    /// </summary>
    public interface ITalonMountsScript
        : IUnityScript
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        int GetUtilityMountCount();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="index">
        /// </param>
        /// <returns>
        /// </returns>
        GameObject GetUtilityMountGameObject(int index);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        int GetWeaponMountCount();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="index">
        /// </param>
        /// <returns>
        /// </returns>
        GameObject GetWeaponMountGameObject(int index);
    }
}