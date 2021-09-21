using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Interfaces
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
        /// <returns></returns>
        GameObject GetGameObject();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        Transform GetTransform();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="unityScript"></param>
        void SetParent(IUnityScript unityScript);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="transform"></param>
        void SetParent(Transform transform);
    }
}