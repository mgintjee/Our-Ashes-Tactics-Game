using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scripts.Unity.Interfaces;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scripts.Canvases.Interfaces
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface ICanvasScript
        : IUnityScript
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        RectTransform GetRectTransform();
    }
}