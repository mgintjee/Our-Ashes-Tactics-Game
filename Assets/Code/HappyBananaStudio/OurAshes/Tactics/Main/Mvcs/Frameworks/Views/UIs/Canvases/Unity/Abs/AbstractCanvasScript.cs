namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Unity.Abs
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Unity.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Scripts.Unity.Abs;
    using UnityEngine;

    /// <summary>
    /// Todo
    /// </summary>
    public class AbstractCanvasScript
        : AbstractUnityScript, ICanvasScript
    {
        RectTransform ICanvasScript.GetRectTransform()
        {
            return this.GetComponent<RectTransform>();
        }
    }
}