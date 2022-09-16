using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Games.Views.Canvases.Impls
{
    /// <summary>
    /// QSortie View Canvas Implementation
    /// </summary>
    public class MvcViewCanvasImpl
        : AbstractMvcViewCanvas, IMvcViewCanvas
    {
        private IPopUpPanelWidget popUpWidget;

        public override void InitialBuild()
        {
            this.popUpWidget = this.BuildPopUpPanel();
            List<ICanvasWidget> canvasWidgets = new List<ICanvasWidget>()
            {
                this.BuildBackground(),
                this.BuildBanner()
            };
            this.AddWidgets(canvasWidgets);
            this.AddWidget(this.popUpWidget);
            this.popUpWidget.GetTransform().SetSiblingIndex(this.GetTransform().childCount - 1);
        }

        /// <inheritdoc/>
        protected override void ProcessSelectedWidget(ICanvasWidget canvasWidget)
        {
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