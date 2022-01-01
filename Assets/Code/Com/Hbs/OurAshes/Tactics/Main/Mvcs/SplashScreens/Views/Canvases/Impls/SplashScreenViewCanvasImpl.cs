using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Fonts.Aligns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Fonts.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Sprites.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Specs.Grids.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Specs.Grids.Inters;
using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.SplashScreens.Views.Canvases
{
    /// <summary>
    /// Splash View Canvas Implementation
    /// </summary>
    public class SplashScreenViewCanvasImpl
        : AbstractMvcViewCanvas, IMvcViewCanvas
    {
        /// <inheritdoc/>
        protected override void InternalBuild()
        {
            this.BuildBack();
            this.BuildTitle();
            this.BuildSubtitle();
        }

        private void BuildBack()
        {
            this.AddWidget(ImageWidgetImpl.Builder.Get()
                .SetSpriteID(SpriteID.SquareBorderless)
                .SetColorID(ColorID.Blue)
                .SetCanvasLevel(1)
                .SetInteractable(true)
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
                    .SetCanvasGridCoords(new Vector2(0, 3))
                    .SetCanvasGridSize(new Vector2(this.gridConvertor.GetGridSize().X, 3));
            this.AddWidget(ImageWidgetImpl.Builder.Get()
                .SetSpriteID(SpriteID.SquareBorderless)
                .SetColorID(ColorID.Yellow)
                .SetCanvasLevel(1)
                .SetInteractable(false)
                .SetMvcViewCanvas(this)
                .SetWidgetGridSpec(widgetGridSpec)
                .SetParent(this)
                .SetName(this.mvcType + ":TitleImage")
                .Build());
            this.AddWidget(TextWidgetImpl.Builder.Get()
                .SetText("Our Ashes\n Tactics")
                .SetFont(FontID.Arial)
                .SetColor(ColorID.Black)
                .SetAlign(AlignType.MiddleCenter)
                .SetBestFit(true, 10, 200)
                .SetCanvasLevel(1)
                .SetInteractable(false)
                .SetMvcViewCanvas(this)
                .SetWidgetGridSpec(widgetGridSpec)
                .SetParent(this)
                .SetName(this.mvcType + ":TitleText")
                .Build());
        }

        private void BuildSubtitle()
        {
            this.AddWidget(TextWidgetImpl.Builder.Get()
                .SetText("Input anywhere/anything to continue...")
                .SetFont(FontID.Arial)
                .SetColor(ColorID.White)
                .SetAlign(AlignType.MiddleCenter)
                .SetBestFit(true, 13, 50)
                .SetCanvasLevel(1)
                .SetInteractable(false)
                .SetMvcViewCanvas(this)
                .SetWidgetGridSpec(new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(3, 1))
                    .SetCanvasGridSize(new Vector2(3, 1)))
                .SetParent(this)
                .SetName(this.mvcType + ":SubtitleText")
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
                    IMvcViewCanvas mvcViewCanvas = gameObject.AddComponent<SplashScreenViewCanvasImpl>();
                    this.ApplyMvcViewValues((AbstractMvcViewCanvas)mvcViewCanvas);
                    mvcViewCanvas.Build();
                    return mvcViewCanvas;
                }
            }
        }
    }
}