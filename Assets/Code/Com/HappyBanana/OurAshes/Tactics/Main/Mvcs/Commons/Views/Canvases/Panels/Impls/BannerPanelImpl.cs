using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Fonts.Aligns;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Fonts.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Sprites.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using System.Numerics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Impls
{
    /// <summary>
    /// Banner Panel Impl
    /// </summary>
    public class BannerPanelImpl
        : AbstractPanelWidget
    {
        protected ITextWidget textWidget;

        protected override void InitialBuild()
        {
            Vector2 widgetGridSize = new Vector2(this.canvasGridConvertor.GetGridSize().X / 2,
                this.canvasGridConvertor.GetGridSize().Y);
            this.InternalAddWidget(ImageWidgetImpl.Builder.Get()
                .SetAlpha(1f)
                .SetSpriteID(SpriteID.SquareBordered)
                .SetColorID(ColorID.GoldenRod)
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(1)
                .SetInteractable(false)
                .SetEnabled(true)
                .SetWidgetGridSpec(new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(Vector2.Zero)
                    .SetCanvasGridSize(widgetGridSize))
                .SetParent(this)
                .SetName("Banner:Left")
                .Build());
            this.InternalAddWidget(ImageWidgetImpl.Builder.Get()
                .SetAlpha(1f)
                .SetSpriteID(SpriteID.SquareBordered)
                .SetColorID(ColorID.DodgerBlue)
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(1)
                .SetInteractable(false)
                .SetEnabled(true)
                .SetWidgetGridSpec(new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(widgetGridSize.X, 0))
                    .SetCanvasGridSize(widgetGridSize))
                .SetParent(this)
                .SetName("Banner:Right")
                .Build());
            this.textWidget = TextWidgetImpl.Builder.Get()
                .SetText("null")
                .SetFont(FontID.Arial)
                .SetColor(ColorID.Black)
                .SetAlign(AlignType.MiddleCenter)
                .SetBestFit(true, 25, 100)
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(1)
                .SetInteractable(false)
                .SetEnabled(true)
                .SetWidgetGridSpec(new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(Vector2.Zero)
                    .SetCanvasGridSize(widgetGridSize))
                .SetParent(this)
                .SetName("Banner")
                .Build();
            this.InternalAddWidget(this.textWidget);
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
                IInternalBuilder SetText(string text);
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
                private string text = "null";

                IInternalBuilder IInternalBuilder.SetText(string text)
                {
                    this.text = text;
                    return this;
                }

                protected override IPanelWidget BuildScript(UnityEngine.GameObject gameObject)
                {
                    IPanelWidget widget = gameObject.AddComponent<BannerPanelImpl>();
                    this.ApplyPanelValues(widget);
                    ((BannerPanelImpl)widget).textWidget.SetText(text);
                    return widget;
                }
            }
        }
    }
}