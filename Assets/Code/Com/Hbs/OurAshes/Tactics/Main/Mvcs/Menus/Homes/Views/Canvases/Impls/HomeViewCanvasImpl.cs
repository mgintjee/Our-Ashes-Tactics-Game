using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Fonts.Aligns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Fonts.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Scripts.Builders.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Scripts.Builders.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Sprites.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Specs.Grids.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Menus.Homes.Models.Requests.Types;
using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Menus.Homes.Views.Canvases.Impls
{
    /// <summary>
    /// Home View Canvas Implementation
    /// </summary>
    public class HomeViewCanvasImpl
        : AbstractMvcViewCanvas, IMvcViewCanvas
    {
        /// <inheritdoc/>
        protected override void InternalBuild()
        {
            this.BuildSplashImages();
            this.BuildSplashTexts();
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void BuildSplashImages()
        {
            this.AddWidget(ImageWidgetImpl.Builder.Get()
                .SetSpriteID(SpriteID.SquareBordered)
                .SetColorID(ColorID.Blue)
                .SetCanvasLevel(1)
                .SetInteractable(false)
                .SetMvcViewCanvas(this)
                .SetWidgetGridSpec(new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(Vector2.Zero)
                    .SetCanvasGridSize(this.gridConvertor.GetGridSize()))
                .SetParent(this)
                .SetName(typeof(ImageWidgetImpl).Name + ":Back")
                .Build());
            this.AddWidget(ImageWidgetImpl.Builder.Get()
                .SetSpriteID(SpriteID.SquareBordered)
                .SetColorID(ColorID.Red)
                .SetCanvasLevel(1)
                .SetInteractable(false)
                .SetMvcViewCanvas(this)
                .SetWidgetGridSpec(new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(0, 4))
                    .SetCanvasGridSize(new Vector2(this.gridConvertor.GetGridSize().X, 2)))
                .SetParent(this)
                .SetName(typeof(ImageWidgetImpl).Name + ":Stripe")
                .Build());
            this.AddWidget(ImageWidgetImpl.Builder.Get()
                .SetSpriteID(SpriteID.RoundSquareBordered)
                .SetColorID(ColorID.Red)
                .SetCanvasLevel(1)
                .SetInteractable(false)
                .SetMvcViewCanvas(this)
                .SetWidgetGridSpec(new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(1, 1))
                    .SetCanvasGridSize(new Vector2(2, 1)))
                .SetParent(this)
                .SetName(typeof(ImageWidgetImpl).Name + ":" + HomeRequestType.Exit)
                .Build());
            this.AddWidget(ImageWidgetImpl.Builder.Get()
                .SetSpriteID(SpriteID.RoundSquareBordered)
                .SetColorID(ColorID.Red)
                .SetCanvasLevel(1)
                .SetInteractable(false)
                .SetMvcViewCanvas(this)
                .SetWidgetGridSpec(new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(6, 1))
                    .SetCanvasGridSize(new Vector2(2, 1)))
                .SetParent(this)
                .SetName(typeof(ImageWidgetImpl).Name + ":" + HomeRequestType.QSortie)
                .Build());
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void BuildSplashTexts()
        {
            this.AddWidget(TextWidgetImpl.Builder.Get()
                .SetText("Home")
                .SetFont(FontID.Arial)
                .SetAlign(AlignType.MiddleCenter)
                .SetBestFit(true, 25, 100)
                .SetCanvasLevel(1)
                .SetInteractable(false)
                .SetMvcViewCanvas(this)
                .SetWidgetGridSpec(new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(0, 4))
                    .SetCanvasGridSize(new Vector2(this.gridConvertor.GetGridSize().X, 2)))
                .SetParent(this)
                .SetName(typeof(TextWidgetImpl).Name + ":Title")
                .Build());
            this.AddWidget(TextWidgetImpl.Builder.Get()
                .SetText(HomeRequestType.Exit)
                .SetFont(FontID.Arial)
                .SetAlign(AlignType.MiddleCenter)
                .SetBestFit(true, 13, 60)
                .SetCanvasLevel(0)
                .SetInteractable(true)
                .SetMvcViewCanvas(this)
                .SetWidgetGridSpec(new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(1, 1))
                    .SetCanvasGridSize(new Vector2(2, 1)))
                .SetParent(this)
                .SetName(typeof(TextWidgetImpl).Name + ":" + HomeRequestType.Exit)
                .Build());
            this.AddWidget(TextWidgetImpl.Builder.Get()
                .SetText(HomeRequestType.QSortie)
                .SetFont(FontID.Arial)
                .SetAlign(AlignType.MiddleCenter)
                .SetBestFit(true, 13, 50)
                .SetCanvasLevel(0)
                .SetInteractable(true)
                .SetMvcViewCanvas(this)
                .SetWidgetGridSpec(new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(6, 1))
                    .SetCanvasGridSize(new Vector2(2, 1)))
                .SetParent(this)
                .SetName(typeof(TextWidgetImpl).Name + ":" + HomeRequestType.QSortie)
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
            public interface IBuilder
                : ICanvasBuilder<IMvcViewCanvas>
            {
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public static IBuilder Get()
            {
                return new InternalBuilder();
            }

            /// <summary>
            /// Todo
            /// </summary>
            private class InternalBuilder
                : AbstractCanvasBuilder<IMvcViewCanvas>, IBuilder
            {
                /// <inheritdoc/>
                protected override IMvcViewCanvas BuildScript(UnityEngine.GameObject gameObject)
                {
                    IMvcViewCanvas mvcViewCanvas = gameObject.AddComponent<HomeViewCanvasImpl>();
                    ((HomeViewCanvasImpl)mvcViewCanvas).logger = LoggerManager.GetLogger(MvcType.MenuHome)
                        .GetClassLogger(mvcViewCanvas.GetType());
                    this.ApplyCanvasValues((AbstractMvcViewCanvas)mvcViewCanvas);
                    mvcViewCanvas.Build();
                    return mvcViewCanvas;
                }
            }
        }
    }
}