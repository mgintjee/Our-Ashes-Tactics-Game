using UnityEngine;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Inters
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
        string GetName();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IUnityScript GetParent();

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