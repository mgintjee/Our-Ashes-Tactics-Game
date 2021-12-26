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

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Screens.Splashes.Views.Canvases
{
    /// <summary>
    /// Splash View Canvas Interface
    /// </summary>
    public class SplashViewCanvasImpl
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
                .SetSpriteID(SpriteID.SquareBordered)
                .SetColorID(ColorID.DarkGreen)
                .SetCanvasLevel(0)
                .SetInteractable(true)
                .SetMvcViewCanvas(this)
                .SetWidgetGridSpec(new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(Vector2.Zero)
                    .SetCanvasGridSize(this.gridConvertor.GetGridSize()))
                .SetParent(this)
                .SetName(typeof(ImageWidgetImpl).Name + ":Back")
                .Build());
            this.AddWidget(ImageWidgetImpl.Builder.Get()
                .SetSpriteID(SpriteID.SquareBordered)
                .SetColorID(ColorID.Blue)
                .SetCanvasLevel(1)
                .SetInteractable(false)
                .SetMvcViewCanvas(this)
                .SetWidgetGridSpec(new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(0, 3))
                    .SetCanvasGridSize(new Vector2(this.gridConvertor.GetGridSize().X, 3)))
                .SetParent(this)
                .SetName(typeof(ImageWidgetImpl).Name + ":Stripe")
                .Build());
        }

        private void BuildSplashTexts()
        {
            this.AddWidget(TextWidgetImpl.Builder.Get()
                .SetText("Our Ashes\n Tactics")
                .SetFont(FontID.Arial)
                .SetAlign(AlignType.MiddleCenter)
                .SetBestFit(true, 10, 200)
                .SetCanvasLevel(1)
                .SetInteractable(false)
                .SetMvcViewCanvas(this)
                .SetWidgetGridSpec(new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(0, 3))
                    .SetCanvasGridSize(new Vector2(this.gridConvertor.GetGridSize().X, 3)))
                .SetParent(this)
                .SetName(typeof(TextWidgetImpl).Name + ":Title")
                .Build());
            this.AddWidget(TextWidgetImpl.Builder.Get()
                .SetText("Input anywhere to continue...")
                .SetFont(FontID.Arial)
                .SetAlign(AlignType.MiddleCenter)
                .SetBestFit(true, 13, 50)
                .SetCanvasLevel(1)
                .SetInteractable(false)
                .SetMvcViewCanvas(this)
                .SetWidgetGridSpec(new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(3, 1))
                    .SetCanvasGridSize(new Vector2(3, 1)))
                .SetParent(this)
                .SetName(typeof(TextWidgetImpl).Name + ":Info")
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
                : AbstractCanvasBuilders.ICanvasBuilder<IMvcViewCanvas>
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
                : AbstractCanvasBuilders.AbstractCanvasBuilder<IMvcViewCanvas>, IInternalBuilder
            {
                /// <inheritdoc/>
                protected override IMvcViewCanvas BuildScript(UnityEngine.GameObject gameObject)
                {
                    IMvcViewCanvas mvcViewCanvas = gameObject.AddComponent<SplashViewCanvasImpl>();
                    ((SplashViewCanvasImpl)mvcViewCanvas).logger = LoggerManager.GetLogger(MvcType.ScreenSplash)
                        .GetClassLogger(mvcViewCanvas.GetType());
                    this.ApplyCanvasValues((AbstractMvcViewCanvas)mvcViewCanvas);
                    mvcViewCanvas.Build();
                    return mvcViewCanvas;
                }
            }
        }
    }
}