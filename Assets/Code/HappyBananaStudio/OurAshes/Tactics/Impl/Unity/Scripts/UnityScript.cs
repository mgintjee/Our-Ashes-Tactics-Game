/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>
/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

namespace HappyBananaStudio.OurAshesTactics.Common.Scripts.Unity
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Unity.Scripts;
    using UnityEngine;

    /// <summary>
    /// Todo
    /// </summary>
    public abstract class UnityScriptImpl
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
