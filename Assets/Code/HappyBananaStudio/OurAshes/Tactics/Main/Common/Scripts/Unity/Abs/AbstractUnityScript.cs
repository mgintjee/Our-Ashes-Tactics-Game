namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Scripts.Unity.Abs
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Scripts.Unity.Api;
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

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="transform"></param>
        public void SetParentTransform(Transform transform)
        {
            this.transform.SetParent(transform);
            this.transform.localPosition = Vector3.zero;
            this.transform.localScale = Vector3.one;
        }
    }
}