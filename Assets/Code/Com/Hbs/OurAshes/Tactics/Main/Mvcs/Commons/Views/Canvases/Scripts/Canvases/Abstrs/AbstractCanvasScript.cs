using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Scripts.Canvases.Inters;
using UnityEngine;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Scripts.Canvases.Abstrs
{
    /// <summary>
    /// Abstract Canvas Script
    /// </summary>
    public abstract class AbstractCanvasScript
        : AbstractUnityScript, ICanvasScript
    {
        /// <inheritdoc/>
        RectTransform ICanvasScript.GetRectTransform()
        {
            return this.GetComponent<RectTransform>();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        protected RectTransform GetRectTransform()
        {
            if (this.GetComponent<RectTransform>() == null)
            {
                this.GetGameObject().AddComponent<RectTransform>();
            }
            return this.GetComponent<RectTransform>();
        }
    }
}