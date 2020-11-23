namespace HappyBananaStudio.OurAshes.Tactics.Abs.Unity.Scripts
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Unity.Scripts;
    using UnityEngine;

    /// <summary>
    /// Todo
    /// </summary>
    public abstract class AbstractUnityScriptImpl
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