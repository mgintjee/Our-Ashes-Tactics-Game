/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using UnityEngine;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Api
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
        /// <returns></returns>
        GameObject GetNextEmptyWeaponMountGameObject();

        #endregion Public Methods
    }
}