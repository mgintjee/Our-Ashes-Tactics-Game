/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Unity;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Unity
{
    /// <summary>
    /// Todo
    /// </summary>
    public abstract class UnityScript
        : MonoBehaviour, IUnityScript
    {
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
        /// <returns>
        /// </returns>
        public GameObject GetGameObject()
        {
            return this.gameObject;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public Transform GetTransform()
        {
            return this.transform;
        }
    }
}