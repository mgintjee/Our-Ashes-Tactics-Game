namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Unity.Api
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Scripts.Unity.Api;
    using UnityEngine;

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