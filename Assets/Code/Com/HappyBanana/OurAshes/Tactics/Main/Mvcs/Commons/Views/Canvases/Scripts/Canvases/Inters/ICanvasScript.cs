using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Inters;
using UnityEngine;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Scripts.Canvases.Inters
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