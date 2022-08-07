using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Structs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Sprites.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Constants;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Types;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class CarouselPanelImpl
        : AbstractPanelWidget, ICarouselPanelWidget
    {
        private IMultiTextPanelWidget header;
        private IMultiTextPanelWidget spinner;
        private IMultiTextPanelWidget buttons;
        private IList<TextImageWidgetStruct> headerTextImageWidgetStructs = new List<TextImageWidgetStruct>();
        private IList<TextImageWidgetStruct> spinnerTextImageWidgetStructs = new List<TextImageWidgetStruct>();
        private IList<TextImageWidgetStruct> buttonTextImageWidgetStructs = new List<TextImageWidgetStruct>();
        private ColorID backgroundColorID;
        private IImageWidget backImageWidget;

        IMultiTextPanelWidget ICarouselPanelWidget.GetHeader()
        {
            return this.header;
        }

        IMultiTextPanelWidget ICarouselPanelWidget.GetSpinner()
        {
            return this.spinner;
        }

        IMultiTextPanelWidget ICarouselPanelWidget.GetButtons()
        {
            return this.buttons;
        }

        void ICarouselPanelWidget.UpdateSpinnerText(int index, IList<string> strings)
        {
            int leftIndex = (index > 0) ? index - 1 : strings.Count - 1;
            int rightIndex = (index < strings.Count - 1) ? index + 1 : 0;
            this.logger.Debug("Setting L:{},C:{},R:{} of {}", leftIndex, index, rightIndex, strings);
            this.spinner.GetTextWidget(0).IfPresent(widget => widget.SetText(strings[leftIndex]));
            this.spinner.GetTextWidget(1).IfPresent(widget => widget.SetText(strings[index]));
            this.spinner.GetTextWidget(2).IfPresent(widget => widget.SetText(strings[rightIndex]));
        }

        protected override void InitialBuild()
        {
            Vector2 overallSize = this.canvasGridConvertor.GetGridSize();
            IWidgetGridSpec headerWidgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(0, 0))
                    .SetCanvasGridSize(new Vector2(1 / 6f, 1) * overallSize);
            IWidgetGridSpec spinnerWidgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(1, 0))
                    .SetCanvasGridSize(new Vector2(3 / 6f, 1) * overallSize);
            IWidgetGridSpec buttonsWidgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(4, 0))
                    .SetCanvasGridSize(new Vector2(2 / 6f, 1) * overallSize);
            this.buttonTextImageWidgetStructs = new List<TextImageWidgetStruct>
            {
                new TextImageWidgetStruct("<",
                    WidgetConstants.BUTTON_INTERACTABLE_ENABLED_TEXT_COLOR,
                    WidgetConstants.BUTTON_INTERACTABLE_ENABLED_IMAGE_COLOR),
                new TextImageWidgetStruct(">",
                    WidgetConstants.BUTTON_INTERACTABLE_ENABLED_TEXT_COLOR,
                    WidgetConstants.BUTTON_INTERACTABLE_ENABLED_IMAGE_COLOR)
            };
            this.spinnerTextImageWidgetStructs = new List<TextImageWidgetStruct>
            {
                new TextImageWidgetStruct("null",
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_TEXT_COLOR,
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_IMAGE_COLOR),
                new TextImageWidgetStruct("null",
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_TEXT_COLOR,
                    WidgetConstants.SECONDARY_COLOR_ID),
                new TextImageWidgetStruct("null",
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_TEXT_COLOR,
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_IMAGE_COLOR)
            };
            this.backImageWidget = this.BuildBackImage();
            this.header = this.BuildMultiText(this.widgetName + ":Header", headerWidgetGridSpec, this.headerTextImageWidgetStructs, false);
            this.spinner = this.BuildMultiText(this.widgetName + ":Spinner", spinnerWidgetGridSpec, this.spinnerTextImageWidgetStructs, false);
            this.buttons = this.BuildMultiText(this.widgetName + ":Buttons", buttonsWidgetGridSpec, this.buttonTextImageWidgetStructs, true);
            this.InternalAddWidget(this.backImageWidget);
            this.InternalAddWidget(this.header);
            this.InternalAddWidget(this.spinner);
            this.InternalAddWidget(this.buttons);
        }

        private IImageWidget BuildBackImage()
        {
            return ImageWidgetImpl.Builder.Get()
                .SetAlpha(1f)
                .SetSpriteID(SpriteID.SquareBordered)
                .SetColorID(this.backgroundColorID)
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(1)
                .SetInteractable(false)
                .SetEnabled(true)
                .SetWidgetGridSpec(new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(Vector2.Zero)
                    .SetCanvasGridSize(this.canvasGridConvertor.GetGridSize()))
                .SetParent(this)
                .SetName("Back:" + CanvasWidgetType.Image)
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
                IInternalBuilder SetHeaderTextImageWidgetStructs(IList<TextImageWidgetStruct> textImageWidgetStructs);

                IInternalBuilder SetBackgroundColor(ColorID colorID);
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
                private IList<TextImageWidgetStruct> headerTextImageWidgetStructs = new List<TextImageWidgetStruct>();
                private ColorID backgroundColorID = ColorID.Gray;

                IInternalBuilder IInternalBuilder.SetBackgroundColor(ColorID colorID)
                {
                    this.backgroundColorID = colorID;
                    return this;
                }

                IInternalBuilder IInternalBuilder.SetHeaderTextImageWidgetStructs(IList<TextImageWidgetStruct> textImageWidgetStructs)
                {
                    this.headerTextImageWidgetStructs = textImageWidgetStructs;
                    return this;
                }

                protected override IPanelWidget BuildScript(UnityEngine.GameObject gameObject)
                {
                    IPanelWidget widget = gameObject.AddComponent<CarouselPanelImpl>();
                    ((CarouselPanelImpl)widget).headerTextImageWidgetStructs = this.headerTextImageWidgetStructs;
                    ((CarouselPanelImpl)widget).backgroundColorID = this.backgroundColorID;
                    this.ApplyPanelValues(widget);
                    return widget;
                }
            }
        }
    }
}