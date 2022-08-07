using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Fonts.Aligns;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Fonts.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Sprites.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Utils;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Types;
using System.Numerics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Impls
{
    /// <summary>
    /// Button Panel Impl
    /// </summary>
    public class ButtonWidgetImpl
        : AbstractPanelWidget, IButtonWidget
    {
        private string buttonText;
        private IImageWidget imageWidget;
        private ITextWidget textWidget;

        IImageWidget IButtonWidget.GetImageWidget()
        {
            return this.imageWidget;
        }

        ITextWidget IButtonWidget.GetTextWidget()
        {
            return this.textWidget;
        }

        protected override void InitialBuild()
        {
            this.InternalAddWidget(this.BuildAndSetImage());
            this.InternalAddWidget(this.BuildAndSetText());
        }

        private IImageWidget BuildAndSetImage()
        {
            this.imageWidget = ImageWidgetImpl.Builder.Get()
                .SetAlpha(1f)
                .SetSpriteID(SpriteID.RoundSquareBordered)
                .SetColorID(ColorID.Gray)
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(1)
                .SetInteractable(true)
                .SetEnabled(true)
                .SetWidgetGridSpec(new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(Vector2.Zero)
                    .SetCanvasGridSize(this.canvasGridConvertor.GetGridSize()))
                .SetParent(this)
                .SetName(this.name + ":" + CanvasWidgetType.Image.ToString())
                .Build();
            return this.imageWidget;
        }

        private ITextWidget BuildAndSetText()
        {
            this.textWidget = TextWidgetImpl.Builder.Get()
                .SetText(this.buttonText)
                .SetFont(FontID.Arial)
                .SetColor(ColorID.White)
                .SetAlign(AlignType.MiddleCenter)
                .SetBestFit(true, 25, 100)
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(1)
                .SetInteractable(false)
                .SetEnabled(true)
                .SetWidgetGridSpec(new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(Vector2.Zero)
                    .SetCanvasGridSize(this.canvasGridConvertor.GetGridSize()))
                .SetParent(this)
                .SetName(this.name + ":" + CanvasWidgetType.Text.ToString())
                .Build();
            return textWidget;
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
                IInternalBuilder SetButtonText(string text);
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
                private string buttonText;

                IInternalBuilder IInternalBuilder.SetButtonText(string text)
                {
                    this.buttonText = text;
                    return this;
                }

                protected override IPanelWidget BuildScript(UnityEngine.GameObject gameObject)
                {
                    ButtonWidgetImpl widget = gameObject.AddComponent<ButtonWidgetImpl>();
                    widget.buttonText = buttonText;
                    this.ApplyPanelValues(widget);
                    CanvasWidgetUtils.SetButtonInteractable(widget, widget.isInteractable);
                    return widget;
                }
            }
        }
    }
}