using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scripts.Canvases.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scripts.Unity.Implementations.Abstract;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scripts.Canvases.Implementations.Abstract
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