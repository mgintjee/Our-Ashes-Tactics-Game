namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Scripts.Unity.Api
{
    using UnityEngine;

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

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="transform"></param>
        void SetParentTransform(Transform transform);
    }
}