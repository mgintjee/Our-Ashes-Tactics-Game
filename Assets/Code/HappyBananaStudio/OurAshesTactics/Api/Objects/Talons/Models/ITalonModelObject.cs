/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Talons.Models
{
    /// <summary>
    /// Talon Model Api
    /// </summary>
    public interface ITalonModelObject
    {
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
        /// <param name="index">
        /// </param>
        /// <returns>
        /// </returns>
        GameObject GetWeaponMountGameObject(int index);
    }
}