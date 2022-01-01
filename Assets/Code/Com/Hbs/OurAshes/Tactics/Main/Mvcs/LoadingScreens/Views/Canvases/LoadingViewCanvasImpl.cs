using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Fonts.Aligns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Fonts.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Sprites.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Specs.Grids.Impls;
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
        protected override void InternalBuild()
        {
            this.BuildSplashImages();
            this.BuildSplashTexts();
        }

        private void BuildSplashImages()
        {
            this.AddWidget(ImageWidgetImpl.Builder.Get()
                .SetSpriteID(SpriteID.SquareBorderless)
                .SetColorID(ColorID.Blue)
                .SetCanvasLevel(0)
                .SetInteractable(false)
                .SetMvcViewCanvas(this)
                .SetWidgetGridSpec(new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(Vector2.Zero)
                    .SetCanvasGridSize(this.gridConvertor.GetGridSize()))
                .SetParent(this)
                .SetName(typeof(ImageWidgetImpl).Name + ":Back")
                .Build());
        }

        private void BuildSplashTexts()
        {
            this.AddWidget(TextWidgetImpl.Builder.Get()
                .SetText("Loading...")
                .SetFont(FontID.Arial)
                .SetAlign(AlignType.MiddleCenter)
                .SetBestFit(true, 10, 200)
                .SetCanvasLevel(1)
                .SetInteractable(false)
                .SetMvcViewCanvas(this)
                .SetWidgetGridSpec(new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(Vector2.Zero)
                    .SetCanvasGridSize(this.gridConvertor.GetGridSize()))
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