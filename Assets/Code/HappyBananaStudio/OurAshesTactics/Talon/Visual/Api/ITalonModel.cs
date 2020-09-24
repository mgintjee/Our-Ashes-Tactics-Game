/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using UnityEngine;

namespace HappyBananaStudio.OurAshesTactics.Talon.Visual.Api
{
    /// <summary>
    /// Talon Model Api
    /// </summary>
    public interface ITalonModel
    {
        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        GameObject GetWeaponMountGameObject(int index);

        #endregion Public Methods
    }
}