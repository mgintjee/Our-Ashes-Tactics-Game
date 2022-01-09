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
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.HomeMenus.Frames.Requests.Types;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.HomeMenus.Views.Canvases.Impls
{
    /// <summary>
    /// Home View Canvas Implementation
    /// </summary>
    public class HomeMenuViewCanvasImpl
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
            foreach (ICanvasWidget canvasWidget in this.BuildExitButton())
            {
                canvasWidgets.Add(canvasWidget);
            }
            foreach (ICanvasWidget canvasWidget in this.BuildQSortieButton())
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
                .SetInteractable(false)
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

        private ISet<ICanvasWidget> BuildExitButton()
        {
            IWidgetGridSpec widgetGridSpec = new CanvasGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(1, 1))
                    .SetCanvasGridSize(new Vector2(2, 1));
            return new HashSet<ICanvasWidget>
            {
                ImageWidgetImpl.Builder.Get()
                    .SetSpriteID(SpriteID.RoundSquareBordered)
                    .SetColorID(ColorID.Red)
                    .SetCanvasLevel(1)
                    .SetInteractable(false)
                    .SetEnabled(true)
                    .SetWidgetGridSpec(widgetGridSpec)
                    .SetParent(this)
                    .SetName(this.mvcType + ":" + HomeRequestType.Exit + "Image")
                    .Build(),
                TextWidgetImpl.Builder.Get()
                    .SetText(HomeRequestType.Exit)
                    .SetFont(FontID.Arial)
                    .SetColor(ColorID.White)
                    .SetAlign(AlignType.MiddleCenter)
                    .SetBestFit(true, 13, 60)
                    .SetCanvasLevel(0)
                    .SetInteractable(true)
                    .SetEnabled(true)
                    .SetWidgetGridSpec(widgetGridSpec)
                    .SetParent(this)
                    .SetName(this.mvcType + ":" + HomeRequestType.Exit + "Text")
                    .Build()
            };
        }

        private ISet<ICanvasWidget> BuildQSortieButton()
        {
            IWidgetGridSpec widgetGridSpec = new CanvasGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(6, 1))
                    .SetCanvasGridSize(new Vector2(2, 1));
            return new HashSet<ICanvasWidget>
            {
                ImageWidgetImpl.Builder.Get()
                    .SetSpriteID(SpriteID.RoundSquareBordered)
                    .SetColorID(ColorID.Red)
                    .SetCanvasLevel(1)
                    .SetInteractable(false)
                    .SetEnabled(true)
                    .SetWidgetGridSpec(widgetGridSpec)
                    .SetParent(this)
                    .SetName(this.mvcType + ":" + HomeRequestType.QSortie + "Image")
                    .Build(),
                TextWidgetImpl.Builder.Get()
                    .SetText(HomeRequestType.QSortie)
                    .SetFont(FontID.Arial)
                    .SetColor(ColorID.White)
                    .SetAlign(AlignType.MiddleCenter)
                    .SetBestFit(true, 13, 60)
                    .SetCanvasLevel(0)
                    .SetInteractable(true)
                    .SetEnabled(true)
                    .SetWidgetGridSpec(widgetGridSpec)
                    .SetParent(this)
                    .SetName(this.mvcType + ":" + HomeRequestType.QSortie + "Text")
                    .Build()
            };
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
                    IMvcViewCanvas mvcViewCanvas = gameObject.AddComponent<HomeMenuViewCanvasImpl>();
                    this.ApplyMvcViewValues((AbstractMvcViewCanvas)mvcViewCanvas);
                    mvcViewCanvas.Build();
                    return mvcViewCanvas;
                }
            }
        }
    }
}