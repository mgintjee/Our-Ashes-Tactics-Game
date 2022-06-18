using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Fonts.Aligns;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Fonts.IDs;
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
    /// Button Panel Impl
    /// </summary>
    public class ButtonPanelImpl
        : AbstractPanelWidget, IButtonPanelWidget
    {
        private string buttonText;
        private string buttonType;
        private IImageWidget imageWidget;
        private ITextWidget textWidget;

        IImageWidget IButtonPanelWidget.GetImageWidget()
        {
            return this.imageWidget;
        }

        ITextWidget IButtonPanelWidget.GetTextWidget()
        {
            return this.textWidget;
        }

        protected override void InitialBuild()
        {
            this.imageWidget = this.BuildImage();
            this.textWidget = this.BuildText();
            this.InternalAddWidget(this.imageWidget);
            this.InternalAddWidget(this.textWidget);
        }

        private IImageWidget BuildImage()
        {
            return ImageWidgetImpl.Builder.Get()
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
                .SetName(this.mvcType + ":" + this.buttonType + ":Button:" + CanvasWidgetType.Image)
                .Build();
        }

        private ITextWidget BuildText()
        {
            return TextWidgetImpl.Builder.Get()
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
                .SetName(this.mvcType + ":" + this.buttonType + ":Button:" + CanvasWidgetType.Text)
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
                : PanelWidgetBuilders.IPanelWidgetBuilder
            {
                IInternalBuilder SetButtonText(string text);

                IInternalBuilder SetButtonType(string text);
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
                private string buttonType;

                IInternalBuilder IInternalBuilder.SetButtonText(string text)
                {
                    this.buttonText = text;
                    return this;
                }

                IInternalBuilder IInternalBuilder.SetButtonType(string text)
                {
                    this.buttonType = text;
                    return this;
                }

                protected override IPanelWidget BuildScript(UnityEngine.GameObject gameObject)
                {
                    IPanelWidget widget = gameObject.AddComponent<ButtonPanelImpl>();
                    ((ButtonPanelImpl)widget).buttonText = buttonText;
                    ((ButtonPanelImpl)widget).buttonType = buttonType;
                    this.ApplyPanelValues(widget);
                    return widget;
                }
            }
        }
    }
}