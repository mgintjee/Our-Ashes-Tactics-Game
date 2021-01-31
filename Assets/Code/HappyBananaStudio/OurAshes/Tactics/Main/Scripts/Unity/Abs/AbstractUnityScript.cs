namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Scripts.Unity.Abs
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Scripts.Unity.Api;
    using UnityEngine;

    /// <summary>
    /// Todo
    /// </summary>
    public abstract class AbstractUnityScript
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