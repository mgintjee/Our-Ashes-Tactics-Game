using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Buttons;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Maps;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Impls
{
    /// <summary>
    /// QSortie View Canvas Implementation
    /// </summary>
    public class MvcViewCanvasImpl
        : AbstractMvcViewCanvas, IMvcViewCanvas
    {
        private readonly IDictionary<RequestType, IPanelWidget> typePanelWidgets =
            new Dictionary<RequestType, IPanelWidget>();

        public override void InitialBuild()
        {
            List<ICanvasWidget> canvasWidgets = new List<ICanvasWidget>()
            {
                this.BuildBackground(),
                this.BuildBanner(),
                ButtonsPanelImpl.Builder.Get()
                    .SetPanelGridSize(ButtonPanelConstants.BUTTON_PANEL_SIZE)
                    .SetWidgetGridSpec(new WidgetGridSpecImpl()
                        .SetCanvasGridCoords(Vector2.Zero)
                        .SetCanvasGridSize(new Vector2(this.canvasGridConvertor.GetGridSize().X / 4,
                            this.canvasGridConvertor.GetGridSize().Y * 6 / 7)))
                    .SetMvcType(this.mvcType)
                    .SetCanvasLevel(0)
                    .SetInteractable(false)
                    .SetEnabled(true)
                    .SetName(this.mvcType + ":Button:" + CanvasWidgetType.Panel)
                    .SetParent(this)
                    .Build(),
                DetailsPanelImpl.Builder.Get()
                    .SetPanelGridSize(new Vector2(4, 5))
                    .SetWidgetGridSpec(new WidgetGridSpecImpl()
                        .SetCanvasGridCoords(new Vector2(this.canvasGridConvertor.GetGridSize().X / 4, 0))
                        .SetCanvasGridSize(new Vector2(this.canvasGridConvertor.GetGridSize().X * 3 / 4,
                            this.canvasGridConvertor.GetGridSize().Y * 6 / 7)))
                    .SetMvcType(this.mvcType)
                    .SetCanvasLevel(0)
                    .SetInteractable(false)
                    .SetEnabled(true)
                    .SetName(this.mvcType + ":Details:" + CanvasWidgetType.Panel)
                    .SetParent(this)
                    .Build()
            };
            foreach (IPanelWidget panelWidget in this.typePanelWidgets.Values)
            {
                canvasWidgets.Add(panelWidget);
            }
            this.AddWidgets(canvasWidgets);
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