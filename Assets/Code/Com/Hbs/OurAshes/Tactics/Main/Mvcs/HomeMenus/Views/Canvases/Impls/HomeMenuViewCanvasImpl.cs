using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Fonts.Aligns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Fonts.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Sprites.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Specs.Grids.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Specs.Grids.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.HomeMenus.Models.Requests.Types;
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
        protected override void InternalBuild()
        {
            this.BuildBack();
            this.BuildTitle();
            this.BuildExitButton();
            this.BuildQSortieButton();
        }

        private void BuildBack()
        {
            this.AddWidget(ImageWidgetImpl.Builder.Get()
                .SetSpriteID(SpriteID.SquareBorderless)
                .SetColorID(ColorID.Blue)
                .SetCanvasLevel(1)
                .SetInteractable(false)
                .SetMvcViewCanvas(this)
                .SetWidgetGridSpec(new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(Vector2.Zero)
                    .SetCanvasGridSize(this.gridConvertor.GetGridSize()))
                .SetParent(this)
                .SetName(this.mvcType + ":BackImage")
                .Build());
        }

        private void BuildTitle()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(0, 4))
                    .SetCanvasGridSize(new Vector2(this.gridConvertor.GetGridSize().X / 4, 1));
            this.AddWidget(ImageWidgetImpl.Builder.Get()
                .SetSpriteID(SpriteID.RoundSquareBorderless)
                .SetColorID(ColorID.Red)
                .SetCanvasLevel(1)
                .SetInteractable(false)
                .SetMvcViewCanvas(this)
                .SetWidgetGridSpec(widgetGridSpec)
                .SetParent(this)
                .SetName(this.mvcType + ":TitleImage")
                .Build());
            this.AddWidget(TextWidgetImpl.Builder.Get()
                .SetText(this.mvcType.ToString())
                .SetFont(FontID.Arial)
                .SetColor(ColorID.White)
                .SetAlign(AlignType.MiddleCenter)
                .SetBestFit(true, 25, 100)
                .SetCanvasLevel(1)
                .SetInteractable(false)
                .SetMvcViewCanvas(this)
                .SetWidgetGridSpec(widgetGridSpec)
                .SetParent(this)
                .SetName(typeof(TextWidgetImpl).Name + ":Title")
                .Build());
        }

        private void BuildExitButton()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(1, 1))
                    .SetCanvasGridSize(new Vector2(2, 1));
            this.AddWidget(ImageWidgetImpl.Builder.Get()
                .SetSpriteID(SpriteID.RoundSquareBordered)
                .SetColorID(ColorID.Red)
                .SetCanvasLevel(1)
                .SetInteractable(false)
                .SetMvcViewCanvas(this)
                .SetWidgetGridSpec(widgetGridSpec)
                .SetParent(this)
                .SetName(this.mvcType + ":" + HomeRequestType.Exit + "Image")
                .Build());
            this.AddWidget(TextWidgetImpl.Builder.Get()
                .SetText(HomeRequestType.Exit)
                .SetFont(FontID.Arial)
                .SetColor(ColorID.White)
                .SetAlign(AlignType.MiddleCenter)
                .SetBestFit(true, 13, 60)
                .SetCanvasLevel(0)
                .SetInteractable(true)
                .SetMvcViewCanvas(this)
                .SetWidgetGridSpec(widgetGridSpec)
                .SetParent(this)
                .SetName(this.mvcType + ":" + HomeRequestType.Exit + "Text")
                .Build());
        }

        private void BuildQSortieButton()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(6, 1))
                    .SetCanvasGridSize(new Vector2(2, 1));
            this.AddWidget(ImageWidgetImpl.Builder.Get()
                .SetSpriteID(SpriteID.RoundSquareBordered)
                .SetColorID(ColorID.Red)
                .SetCanvasLevel(1)
                .SetInteractable(false)
                .SetMvcViewCanvas(this)
                .SetWidgetGridSpec(widgetGridSpec)
                .SetParent(this)
                .SetName(this.mvcType + ":" + HomeRequestType.QSortie + "Image")
                .Build());
            this.AddWidget(TextWidgetImpl.Builder.Get()
                .SetText(HomeRequestType.QSortie)
                .SetFont(FontID.Arial)
                .SetColor(ColorID.White)
                .SetAlign(AlignType.MiddleCenter)
                .SetBestFit(true, 13, 60)
                .SetCanvasLevel(0)
                .SetInteractable(true)
                .SetMvcViewCanvas(this)
                .SetWidgetGridSpec(widgetGridSpec)
                .SetParent(this)
                .SetName(this.mvcType + ":" + HomeRequestType.QSortie + "Text")
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
                    IMvcViewCanvas mvcViewCanvas = gameObject.AddComponent<HomeMenuViewCanvasImpl>();
                    this.ApplyMvcViewValues((AbstractMvcViewCanvas)mvcViewCanvas);
                    mvcViewCanvas.Build();
                    return mvcViewCanvas;
                }
            }
        }
    }
}