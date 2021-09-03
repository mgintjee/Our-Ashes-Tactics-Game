using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Unity.Scripts.Implementations.Abstract;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Canvases.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Canvases.Scripts.Implementations.Abstract
{
    /// <summary>
    /// Todo
    /// </summary>
    public class AbstractCanvasScript : AbstractUnityScript, ICanvasScript
    {
        /// <inheritdoc/>
        RectTransform ICanvasScript.GetRectTransform()
        {
            return this.GetComponent<RectTransform>();
        }
    }
}