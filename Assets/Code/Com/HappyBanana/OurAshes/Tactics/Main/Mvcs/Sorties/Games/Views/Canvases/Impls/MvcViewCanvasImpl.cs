using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Types;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Games.Views.Canvases.Panels.Buttons;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Games.Views.Canvases.Panels.Buttons.Constants;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Games.Views.Canvases.Panels.Details;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Games.Views.Canvases.Panels.Details.Constants;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Games.Views.Canvases.Panels.Fields;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Games.Views.Canvases.Panels.Scrollers;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Games.Views.Canvases.Panels.Scrollers.Constants;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Games.Views.Canvases.Impls
{
    /// <summary>
    /// Sortie Game View Canvas Implementation
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
                this.BuildBanner(),
                this.BuildFieldPanel(),
                this.BuildScrollerPanel(),
                this.BuildButtonPanel(),
                this.BuildDetailsPanel()
            };
            this.AddWidgets(canvasWidgets);
            this.AddWidget(this.popUpWidget);
            this.popUpWidget.GetTransform().SetSiblingIndex(this.GetTransform().childCount - 1);
        }

        /// <inheritdoc/>
        protected override void ProcessSelectedWidget(ICanvasWidget canvasWidget)
        {
        }

        private IPanelWidget BuildFieldPanel()
        {
            return FieldPanelImpl.Builder.Get()
                    .SetPanelGridSize(FieldPanelConstants.PANEL_SIZE)
                    .SetWidgetGridSpec(FieldPanelConstants.WIDGET_GRID_SPEC)
                    .SetMvcType(this.mvcType)
                    .SetCanvasLevel(0)
                    .SetInteractable(false)
                    .SetEnabled(true)
                    .SetName("Field:" + CanvasWidgetType.Panel)
                    .SetParent(this)
                    .Build();
        }

        private IPanelWidget BuildScrollerPanel()
        {
            return ScrollerPanelImpl.Builder.Get()
                    .SetPanelGridSize(ScrollerPanelConstants.PANEL_SIZE)
                    .SetWidgetGridSpec(ScrollerPanelConstants.WIDGET_GRID_SPEC)
                    .SetMvcType(this.mvcType)
                    .SetCanvasLevel(0)
                    .SetInteractable(false)
                    .SetEnabled(true)
                    .SetName("Scroller:" + CanvasWidgetType.Panel)
                    .SetParent(this)
                    .Build();
        }

        private IPanelWidget BuildButtonPanel()
        {
            return ButtonsPanelImpl.Builder.Get()
                    .SetPanelGridSize(ButtonPanelConstants.PANEL_SIZE)
                    .SetWidgetGridSpec(ButtonPanelConstants.WIDGET_GRID_SPEC)
                    .SetMvcType(this.mvcType)
                    .SetCanvasLevel(0)
                    .SetInteractable(false)
                    .SetEnabled(true)
                    .SetName("Button:" + CanvasWidgetType.Panel)
                    .SetParent(this)
                    .Build();
        }

        private IPanelWidget BuildDetailsPanel()
        {
            return DetailsPanelImpl.Builder.Get()
                    .SetPanelGridSize(DetailsPanelConstants.PANEL_SIZE)
                    .SetWidgetGridSpec(DetailsPanelConstants.WIDGET_GRID_SPEC)
                    .SetMvcType(this.mvcType)
                    .SetCanvasLevel(0)
                    .SetInteractable(false)
                    .SetEnabled(true)
                    .SetName("Details:" + CanvasWidgetType.Panel)
                    .SetParent(this)
                    .Build();
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