using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Fonts.Aligns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Fonts.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Sprites.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Types;
using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Impls
{
    /// <summary>
    /// DualText Panel Impl
    /// </summary>
    public class DualTextPanelImpl
        : AbstractPanelWidget, IDualTextPanelWidget
    {
        private string leftText;
        private string rightText;
        private IImageWidget backImageWidget;
        private IImageWidget leftImageWidget;
        private IImageWidget rightImageWidget;
        private ITextWidget leftTextWidget;
        private ITextWidget rightTextWidget;

        IImageWidget IDualTextPanelWidget.GetBackImageWidget()
        {
            return this.backImageWidget;
        }

        IImageWidget IDualTextPanelWidget.GetLeftImageWidget()
        {
            return this.leftImageWidget;
        }

        IImageWidget IDualTextPanelWidget.GetRightImageWidget()
        {
            return this.rightImageWidget;
        }

        ITextWidget IDualTextPanelWidget.GetLeftTextWidget()
        {
            return this.leftTextWidget;
        }

        ITextWidget IDualTextPanelWidget.GetRightTextWidget()
        {
            return this.rightTextWidget;
        }

        protected override void InitialBuild()
        {
            this.backImageWidget = this.BuildBackImage();
            this.leftImageWidget = this.BuildLeftImage();
            this.rightImageWidget = this.BuildRightImage();
            this.leftTextWidget = this.BuildLeftText();
            this.rightTextWidget = this.BuildRightText();

            this.InternalAddWidget(this.backImageWidget);
            this.InternalAddWidget(this.leftImageWidget);
            this.InternalAddWidget(this.rightImageWidget);
            this.InternalAddWidget(this.leftTextWidget);
            this.InternalAddWidget(this.rightTextWidget);
        }

        private IImageWidget BuildBackImage()
        {
            return ImageWidgetImpl.Builder.Get()
                .SetSpriteID(SpriteID.SquareBordered)
                .SetColorID(ColorID.Gray)
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(1)
                .SetInteractable(true)
                .SetEnabled(true)
                .SetWidgetGridSpec(new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(Vector2.Zero)
                    .SetCanvasGridSize(this.canvasGridConvertor.GetGridSize()))
                .SetParent(this)
                .SetName(this.mvcType + ":DualText:Back:" + CanvasWidgetType.Image)
                .Build();
        }

        private IImageWidget BuildLeftImage()
        {
            return ImageWidgetImpl.Builder.Get()
                .SetSpriteID(SpriteID.RoundSquareBordered)
                .SetColorID(ColorID.Gray)
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(1)
                .SetInteractable(true)
                .SetEnabled(true)
                .SetWidgetGridSpec(new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(Vector2.Zero)
                    .SetCanvasGridSize(new Vector2(this.canvasGridConvertor.GetGridSize().X / 2,
                        this.canvasGridConvertor.GetGridSize().Y)))
                .SetParent(this)
                .SetName(this.mvcType + ":DualText:Left:" + CanvasWidgetType.Image)
                .Build();
        }

        private IImageWidget BuildRightImage()
        {
            return ImageWidgetImpl.Builder.Get()
                .SetSpriteID(SpriteID.RoundSquareBordered)
                .SetColorID(ColorID.Gray)
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(1)
                .SetInteractable(true)
                .SetEnabled(true)
                .SetWidgetGridSpec(new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(this.canvasGridConvertor.GetGridSize().X / 2, 0))
                    .SetCanvasGridSize(new Vector2(this.canvasGridConvertor.GetGridSize().X / 2,
                        this.canvasGridConvertor.GetGridSize().Y)))
                .SetParent(this)
                .SetName(this.mvcType + ":DualText:Right:" + CanvasWidgetType.Image)
                .Build();
        }

        private ITextWidget BuildLeftText()
        {
            return TextWidgetImpl.Builder.Get()
                .SetText(this.leftText)
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
                    .SetCanvasGridSize(new Vector2(this.canvasGridConvertor.GetGridSize().X / 2,
                        this.canvasGridConvertor.GetGridSize().Y)))
                .SetParent(this)
                .SetName(this.mvcType + ":DualText:Left:" + CanvasWidgetType.Text)
                .Build();
        }

        private ITextWidget BuildRightText()
        {
            return TextWidgetImpl.Builder.Get()
                .SetText(this.rightText)
                .SetFont(FontID.Arial)
                .SetColor(ColorID.White)
                .SetAlign(AlignType.MiddleCenter)
                .SetBestFit(true, 25, 100)
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(1)
                .SetInteractable(false)
                .SetEnabled(true)
                .SetWidgetGridSpec(new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(this.canvasGridConvertor.GetGridSize().X / 2, 0))
                    .SetCanvasGridSize(new Vector2(this.canvasGridConvertor.GetGridSize().X / 2,
                        this.canvasGridConvertor.GetGridSize().Y)))
                .SetParent(this)
                .SetName(this.mvcType + ":DualText:Right:" + CanvasWidgetType.Text)
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
                IInternalBuilder SetLeftText(string text);

                IInternalBuilder SetRightText(string text);
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
                private string leftText;
                private string rightText;

                IInternalBuilder IInternalBuilder.SetLeftText(string text)
                {
                    this.leftText = text;
                    return this;
                }

                IInternalBuilder IInternalBuilder.SetRightText(string text)
                {
                    this.rightText = text;
                    return this;
                }

                protected override IPanelWidget BuildScript(UnityEngine.GameObject gameObject)
                {
                    IPanelWidget widget = gameObject.AddComponent<DualTextPanelImpl>();
                    ((DualTextPanelImpl)widget).leftText = leftText;
                    ((DualTextPanelImpl)widget).rightText = rightText;
                    this.ApplyPanelValues(widget);
                    return widget;
                }
            }
        }
    }
}