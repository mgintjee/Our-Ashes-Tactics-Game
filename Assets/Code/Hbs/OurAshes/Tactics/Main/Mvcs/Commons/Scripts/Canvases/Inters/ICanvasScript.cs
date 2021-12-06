using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Inters;
using UnityEngine;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Canvases.Inters
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface ICanvasScript : IUnityScript
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        RectTransform GetRectTransform();
    }
}