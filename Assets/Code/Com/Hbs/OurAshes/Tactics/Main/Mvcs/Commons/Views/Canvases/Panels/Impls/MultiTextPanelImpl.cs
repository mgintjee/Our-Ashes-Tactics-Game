using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Fonts.Aligns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Fonts.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Sprites.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Types;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class MultiTextPanelImpl
        : AbstractPanelWidget, IMultiTextPanelWidget
    {
        private readonly IDictionary<int, IImageWidget> indexImages = new Dictionary<int, IImageWidget>();
        private readonly IDictionary<int, ITextWidget> indexTexts = new Dictionary<int, ITextWidget>();
        private IDictionary<int, TextImageWidgetStruct> indexTextImageWidgetStructs = new Dictionary<int, TextImageWidgetStruct>();
        private ColorID backgroundColorID;
        private IImageWidget backImageWidget;

        IImageWidget IMultiTextPanelWidget.GetBackImageWidget()
        {
            return this.backImageWidget;
        }

        int IMultiTextPanelWidget.GetMaxIndex()
        {
            return this.indexTextImageWidgetStructs.Count;
        }

        Optional<ITextWidget> IMultiTextPanelWidget.GetTextWidget(int index)
        {
            if (this.indexTexts.ContainsKey(index))
            {
                return Optional<ITextWidget>.Of(this.indexTexts[index]);
            }
            return Optional<ITextWidget>.Empty();
        }

        Optional<IImageWidget> IMultiTextPanelWidget.GetImageWidget(int index)
        {
            if (this.indexImages.ContainsKey(index))
            {
                return Optional<IImageWidget>.Of(this.indexImages[index]);
            }
            return Optional<IImageWidget>.Empty();
        }

        protected override void InitialBuild()
        {
            this.backImageWidget = this.BuildBackImage();
            foreach (KeyValuePair<int, TextImageWidgetStruct> indexTextImageWidgetStruct in this.indexTextImageWidgetStructs)
            {
                this.BuildTextAndImageWidgets(indexTextImageWidgetStruct.Key, indexTextImageWidgetStruct.Value);
            }
            this.InternalAddWidget(this.backImageWidget);
            foreach (IImageWidget widget in this.indexImages.Values)
            {
                this.InternalAddWidget(widget);
            }
            foreach (ITextWidget widget in this.indexTexts.Values)
            {
                this.InternalAddWidget(widget);
            }
        }

        private IImageWidget BuildBackImage()
        {
            return ImageWidgetImpl.Builder.Get()
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
                .SetName(this.mvcType + ":" + this.GetType().Name + ":Back:" + CanvasWidgetType.Image)
                .Build();
        }

        private void BuildTextAndImageWidgets(int index, TextImageWidgetStruct textImageWidgetStruct)
        {
            this.indexImages[index] = this.BuildImage(index, textImageWidgetStruct);
            this.indexTexts[index] = this.BuildText(index, textImageWidgetStruct);
        }

        private IImageWidget BuildImage(int index, TextImageWidgetStruct textImageWidgetStruct)
        {
            float gridCoordsX = index * this.canvasGridConvertor.GetGridSize().X / this.indexTextImageWidgetStructs.Count;
            float gridCoordsY = 0;
            float gridSizeX = this.canvasGridConvertor.GetGridSize().X / this.indexTextImageWidgetStructs.Count;
            float gridSizeY = this.canvasGridConvertor.GetGridSize().Y;
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(gridCoordsX, gridCoordsY))
                    .SetCanvasGridSize(new Vector2(gridSizeX, gridSizeY));
            return ImageWidgetImpl.Builder.Get()
                .SetSpriteID(SpriteID.RoundSquareBordered)
                .SetColorID(textImageWidgetStruct.GetImageColorID())
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(1)
                .SetInteractable(((ICanvasWidget)this).GetInteractable())
                .SetEnabled(true)
                .SetWidgetGridSpec(widgetGridSpec)
                .SetParent(this)
                .SetName(this.mvcType + ":" + this.GetType().Name + ":" + index + ":" + CanvasWidgetType.Image)
                .Build();
        }

        private ITextWidget BuildText(int index, TextImageWidgetStruct textImageWidgetStruct)
        {
            float gridCoordsX = index * this.canvasGridConvertor.GetGridSize().X / this.indexTextImageWidgetStructs.Count;
            float gridCoordsY = 0;
            float gridSizeX = this.canvasGridConvertor.GetGridSize().X / this.indexTextImageWidgetStructs.Count;
            float gridSizeY = this.canvasGridConvertor.GetGridSize().Y;
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(gridCoordsX, gridCoordsY))
                    .SetCanvasGridSize(new Vector2(gridSizeX, gridSizeY));
            return TextWidgetImpl.Builder.Get()
                .SetText(textImageWidgetStruct.GetTextString())
                .SetFont(FontID.Arial)
                .SetColor(textImageWidgetStruct.GetTextColorID())
                .SetAlign(AlignType.MiddleCenter)
                .SetBestFit(true, 25, 100)
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(1)
                .SetInteractable(false)
                .SetEnabled(true)
                .SetWidgetGridSpec(widgetGridSpec)
                .SetParent(this)
                .SetName(this.mvcType + ":" + this.GetType().Name + ":" + index + ":" + CanvasWidgetType.Text)
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
                IInternalBuilder SetTextImageWidgetStruct(int index, TextImageWidgetStruct textImageWidgetStruct);

                IInternalBuilder SetTextImageWidgetStructs(IDictionary<int, TextImageWidgetStruct> indexTextImageWidgetStructs);

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
                private IDictionary<int, TextImageWidgetStruct> indexTextImageWidgetStructs = new Dictionary<int, TextImageWidgetStruct>();
                private ColorID backgroundColorID = ColorID.Gray;

                IInternalBuilder IInternalBuilder.SetBackgroundColor(ColorID colorID)
                {
                    this.backgroundColorID = colorID;
                    return this;
                }

                IInternalBuilder IInternalBuilder.SetTextImageWidgetStruct(int index, TextImageWidgetStruct textImageWidgetStruct)
                {
                    this.indexTextImageWidgetStructs.Add(index, textImageWidgetStruct);
                    return this;
                }

                IInternalBuilder IInternalBuilder.SetTextImageWidgetStructs(IDictionary<int, TextImageWidgetStruct> indexTextImageWidgetStructs)
                {
                    this.indexTextImageWidgetStructs = indexTextImageWidgetStructs;
                    return this;
                }

                protected override IPanelWidget BuildScript(UnityEngine.GameObject gameObject)
                {
                    IPanelWidget widget = gameObject.AddComponent<MultiTextPanelImpl>();
                    ((MultiTextPanelImpl)widget).indexTextImageWidgetStructs = this.indexTextImageWidgetStructs;
                    ((MultiTextPanelImpl)widget).backgroundColorID = this.backgroundColorID;
                    this.ApplyPanelValues(widget);
                    return widget;
                }
            }
        }
    }
}