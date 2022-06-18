using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Builders.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Scripts.Builders.Inters;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Scripts.Builders.Impls
{
    /// <summary>
    /// Abstract Canvas Builder Impl
    /// </summary>
    public abstract class AbstractCanvasBuilder<T>
        : AbstractScriptBuilder<T>, ICanvasBuilder<T>
    {
        // Todo
        protected Vector2 gridSize;

        /// <inheritdoc/>
        ICanvasBuilder<T> ICanvasBuilder<T>.SetGridSize(Vector2 gridSize)
        {
            this.gridSize = gridSize;
            return this;
        }

        /// <inheritdoc/>
        protected override T BuildObj()
        {
            UnityEngine.GameObject gameObject = new UnityEngine.GameObject(this.name);
            UnityEngine.Canvas canvas = gameObject.AddComponent<UnityEngine.Canvas>();
            canvas.renderMode = UnityEngine.RenderMode.ScreenSpaceOverlay;
            return this.BuildScript(gameObject);
        }

        /// <inheritdoc/>
        protected override void ValidateScriptBuilder(ISet<string> invalidReasons)
        {
            this.Validate(invalidReasons, this.gridSize);
            this.ValidateCanvasBuilder(invalidReasons);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcViewCanvas"></param>
        protected void ApplyCanvasValues(AbstractMvcViewCanvas mvcViewCanvas)
        {
            this.ApplyScriptValues(mvcViewCanvas);
            mvcViewCanvas.SetGridSize(this.gridSize);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="invalidReasons"></param>
        protected virtual void ValidateCanvasBuilder(ISet<string> invalidReasons)
        {
        }
    }
}