using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Sprites.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Types;
using System.Numerics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class PopUpPanelImpl
        : AbstractPanelWidget, IPopUpPanelWidget
    {
        private IPanelWidget popupEntryWidget;

        void IPopUpPanelWidget.UpdatePopup(IPanelWidget panelWidget)
        {
            if (this.popupEntryWidget != null)
            {
                this.popupEntryWidget.Destroy();
            }
            this.popupEntryWidget = panelWidget;
            this.InternalAddWidget(this.popupEntryWidget);
        }

        protected override void InitialBuild()
        {
            this.InternalAddWidget(this.BuildBackgroundWidget());
        }

        private IImageWidget BuildBackgroundWidget()
        {
            IImageWidget imageWidget = ImageWidgetImpl.Builder.Get()
                .SetAlpha(0.5f)
                .SetSpriteID(SpriteID.SquareBorderless)
                .SetColorID(ColorID.White)
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(5)
                .SetInteractable(true)
                .SetEnabled(true)
                .SetWidgetGridSpec(new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(Vector2.Zero)
                    .SetCanvasGridSize(this.canvasGridConvertor.GetGridSize()))
                .SetParent(this)
                .SetName(this.mvcType + ":PopUp:Background:" + CanvasWidgetType.Image)
                .Build();
            return imageWidget;
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
                : PanelWidgetBuilders.IPanelWidgetBuilder
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
                : PanelWidgetBuilders.InternalPanelWidgetBuilder, IInternalBuilder
            {
                protected override IPanelWidget BuildScript(UnityEngine.GameObject gameObject)
                {
                    IPanelWidget widget = gameObject.AddComponent<PopUpPanelImpl>();
                    this.ApplyPanelValues(widget);
                    return widget;
                }
            }
        }
    }
}