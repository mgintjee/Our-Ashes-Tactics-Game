
namespace HappyBananaStudio.OurAshes.Tactics.Impl.Unity.Scripts
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
