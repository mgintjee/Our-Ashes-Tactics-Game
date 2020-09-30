/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Unity
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IUnityScript
    {
        /// <summary>
        /// Todo
        /// </summary>
        void Destroy();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        GameObject GetGameObject();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        Transform GetTransform();
    }
}