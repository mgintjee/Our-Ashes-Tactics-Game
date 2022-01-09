using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Fonts.Aligns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Fonts.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Sprites.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.LoadingScreens.Views.Canvases
{
    /// <summary>
    /// Loading View Canvas Implementation
    /// </summary>
    public class LoadingViewCanvasImpl
        : AbstractMvcViewCanvas, IMvcViewCanvas
    {
        /// <inheritdoc/>
        protected override ISet<ICanvasWidget> InternalBuild()
        {
            ISet<ICanvasWidget> canvasWidgets = new HashSet<ICanvasWidget>()
            {
                this.BuildBackground()
            };
            foreach (ICanvasWidget canvasWidget in this.BuildHeader())
            {
                canvasWidgets.Add(canvasWidget);
            }
            return canvasWidgets;
        }

        private ICanvasWidget BuildBackground()
        {
            return ImageWidgetImpl.Builder.Get()
                .SetSpriteID(SpriteID.SquareBorderless)
                .SetColorID(ColorID.Blue)
                .SetCanvasLevel(1)
                .SetInteractable(true)
                .SetEnabled(true)
                .SetWidgetGridSpec(new CanvasGridSpecImpl()
                    .SetCanvasGridCoords(Vector2.Zero)
                    .SetCanvasGridSize(this.canvasGridConvertor.GetGridSize()))
                .SetParent(this)
                .SetName(this.mvcType + ":Background")
                .Build();
        }

        private ISet<ICanvasWidget> BuildHeader()
        {
            IWidgetGridSpec widgetGridSpec = new CanvasGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(0, 6))
                    .SetCanvasGridSize(new Vector2(this.canvasGridConvertor.GetGridSize().X / 4, 1));
            return new HashSet<ICanvasWidget>
            {
                ImageWidgetImpl.Builder.Get()
                    .SetSpriteID(SpriteID.SquareBordered)
                    .SetColorID(ColorID.Red)
                    .SetCanvasLevel(1)
                    .SetInteractable(false)
                    .SetEnabled(true)
                    .SetWidgetGridSpec(widgetGridSpec)
                    .SetParent(this)
                    .SetName(this.mvcType + ":HeaderImage")
                    .Build(),
                TextWidgetImpl.Builder.Get()
                    .SetText(this.mvcType.ToString())
                    .SetFont(FontID.Arial)
                    .SetColor(ColorID.White)
                    .SetAlign(AlignType.MiddleCenter)
                    .SetBestFit(true, 25, 100)
                    .SetCanvasLevel(1)
                    .SetInteractable(false)
                    .SetEnabled(true)
                    .SetWidgetGridSpec(widgetGridSpec)
                    .SetParent(this)
                    .SetName(this.mvcType + ":HeaderText")
                    .Build()
            };
        }

        private void BuildSplashImages()
        {
            this.AddWidget(ImageWidgetImpl.Builder.Get()
                .SetSpriteID(SpriteID.SquareBorderless)
                .SetColorID(ColorID.Blue)
                .SetCanvasLevel(0)
                .SetInteractable(false)
                .SetEnabled(true)
                .SetWidgetGridSpec(new CanvasGridSpecImpl()
                    .SetCanvasGridCoords(Vector2.Zero)
                    .SetCanvasGridSize(this.canvasGridConvertor.GetGridSize()))
                .SetParent(this)
                .SetName(typeof(ImageWidgetImpl).Name + ":Back")
                .Build());
        }

        private void BuildSplashTexts()
        {
            this.AddWidget(TextWidgetImpl.Builder.Get()
                .SetText("Loading...")
                .SetFont(FontID.Arial)
                .SetColor(ColorID.White)
                .SetAlign(AlignType.MiddleCenter)
                .SetBestFit(true, 10, 200)
                .SetCanvasLevel(1)
                .SetInteractable(false)
                .SetEnabled(true)
                .SetWidgetGridSpec(new CanvasGridSpecImpl()
                    .SetCanvasGridCoords(Vector2.Zero)
                    .SetCanvasGridSize(this.canvasGridConvertor.GetGridSize()))
                .SetParent(this)
                .SetName(typeof(TextWidgetImpl).Name + ":Title")
                .Build());
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
                    IMvcViewCanvas mvcViewCanvas = gameObject.AddComponent<LoadingViewCanvasImpl>();
                    this.ApplyMvcViewValues((AbstractMvcViewCanvas)mvcViewCanvas);
                    mvcViewCanvas.Build();
                    return mvcViewCanvas;
                }
            }
        }
    }
}