using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Builders.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Builders.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Scripts.Canvases.Inters;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Scripts.Canvases.Abstrs
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

        /// <summary>
        /// Todo
        /// </summary>
        public class AbstractCanvasBuilders
        {
            /// <summary>
            /// Canvas Builder class Interface
            /// </summary>
            public interface ICanvasBuilder<T>
                : IScriptBuilder<T>
            {
                /// <summary>
                /// Todo
                /// </summary>
                /// <returns></returns>
                ICanvasBuilder<T> SetGridSize(System.Numerics.Vector2 gridSize);
            }

            /// <summary>
            /// Abstract Canvas Builder Impl
            /// </summary>
            public abstract class AbstractCanvasBuilder<T>
                : AbstractScriptBuilder<T>, ICanvasBuilder<T>
            {
                // Todo
                protected System.Numerics.Vector2 gridSize;

                /// <inheritdoc/>
                ICanvasBuilder<T> ICanvasBuilder<T>.SetGridSize(System.Numerics.Vector2 gridSize)
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
    }
}