using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Types;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.HomeMenus.Views.Canvases.Panels.Impls;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.HomeMenus.Views.Canvases.Impls
{
    /// <summary>
    /// Home View Canvas Implementation
    /// </summary>
    public class MvcViewCanvasImpl
        : AbstractMvcViewCanvas, IMvcViewCanvas
    {
        public override void InitialBuild()
        {
            this.AddWidgets(new List<ICanvasWidget>()
            {
                this.BuildBackground(),
                this.BuildBanner(),
                ButtonsPanelImpl.Builder.Get()
                    .SetPanelGridSize(new Vector2(1, 5))
                    .SetWidgetGridSpec(new WidgetGridSpecImpl()
                        .SetCanvasGridCoords(Vector2.Zero)
                        .SetCanvasGridSize(new Vector2(this.canvasGridConvertor.GetGridSize().X / 4,
                            this.canvasGridConvertor.GetGridSize().Y * 6 / 7)))
                    .SetMvcType(this.mvcType)
                    .SetCanvasLevel(0)
                    .SetInteractable(false)
                    .SetEnabled(true)
                    .SetName(":Button:" + CanvasWidgetType.Panel)
                    .SetParent(this)
                    .Build()
            });
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