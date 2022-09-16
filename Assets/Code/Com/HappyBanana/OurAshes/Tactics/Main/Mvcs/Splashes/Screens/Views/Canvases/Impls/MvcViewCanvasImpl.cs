using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Types;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Splashes.Screens.Views.Canvases.Panels.Impls;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Splashes.Screens.Views.Canvases.Impls
{
    /// <summary>
    /// SplashScreen View Canvas Implementation
    /// </summary>
    public class MvcViewCanvasImpl
        : AbstractMvcViewCanvas, IMvcViewCanvas
    {
        public override void InitialBuild()
        {
            ICanvasWidget backgroundWidget = this.BuildBackground();
            backgroundWidget.SetInteractable(true);
            List<ICanvasWidget> canvasWidgets = new List<ICanvasWidget>
            {
                backgroundWidget,
                this.BuildBanner(),
                ContinuePanelImpl.Builder.Get()
                    .SetPanelGridSize(new Vector2(2, 1))
                    .SetWidgetGridSpec(new WidgetGridSpecImpl()
                        .SetCanvasGridCoords(new Vector2(0, this.canvasGridConvertor.GetGridSize().Y * 1 / 7))
                        .SetCanvasGridSize(new Vector2(this.canvasGridConvertor.GetGridSize().X,
                            this.canvasGridConvertor.GetGridSize().Y / 7)))
                    .SetMvcType(this.mvcType)
                    .SetCanvasLevel(0)
                    .SetInteractable(false)
                    .SetEnabled(true)
                    .SetName("Continue:" + CanvasWidgetType.Panel)
                    .SetParent(this)
                    .Build(),
            };
            this.AddWidgets(canvasWidgets);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Todo
            /// </summary>
            public interface IInternalBuilder
                : AbstractViewCanvasBuilders.IViewCanvasBuilder
            {
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public static IInternalBuilder Get()
            {
                return new InternalBuilder();
            }

            /// <summary>
            /// Todo
            /// </summary>
            private class InternalBuilder
                : AbstractViewCanvasBuilders.AbstractViewCanvasBuilder, IInternalBuilder
            {
                /// <inheritdoc/>
                protected override IMvcViewCanvas BuildScript(UnityEngine.GameObject gameObject)
                {
                    IMvcViewCanvas mvcViewCanvas = gameObject.AddComponent<MvcViewCanvasImpl>();
                    this.ApplyMvcViewValues((AbstractMvcViewCanvas)mvcViewCanvas);
                    mvcViewCanvas.InitialBuild();
                    return mvcViewCanvas;
                }
            }
        }
    }
}