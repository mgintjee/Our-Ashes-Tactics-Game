using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
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

        public override void Process(IMvcModelState mvcModelState)
        {
            throw new System.NotImplementedException();
        }

        public override void InitialBuild()
        {
            List<ICanvasWidget> canvasWidgets = new List<ICanvasWidget>()
            {
                this.BuildBackground()
            };
            canvasWidgets.AddRange(this.BuildHeader());
            canvasWidgets.AddRange(this.BuildExitButton());
            canvasWidgets.AddRange(this.BuildQSortieButton());


                this.AddWidgets(canvasWidgets);

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
                    mvcViewCanvas.InitialBuild();
                    return mvcViewCanvas;
                }
            }
        }
    }
}