using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scripts.Canvases.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scripts.Unity.Abstract;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scripts.Canvases.Abstract
{
    /// <summary>
    /// Todo
    /// </summary>
    public class AbstractCanvasScript
        : AbstractUnityScript, ICanvasScript
    {
        /// <inheritdoc/>
        RectTransform ICanvasScript.GetRectTransform()
        {
            return this.GetComponent<RectTransform>();
        }
    }
}