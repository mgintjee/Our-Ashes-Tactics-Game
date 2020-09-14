/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using UnityEngine;

namespace HappyBananaStudio.OurAshesTactics.Common.UnityScript
{
    /// <summary>
    /// Todo
    /// </summary>
    public class AbstractUnityScript
    : MonoBehaviour
    {
        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        public void Destroy()
        {
            GameObject.Destroy(this.GetGameObject());
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public GameObject GetGameObject()
        {
            return this.gameObject;
        }

        #endregion Public Methods
    }
}