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
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSortieMenus.Frames.Requests.Types;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSortieMenus.Views.Canvases.Impls
{
    /// <summary>
    /// QSortie View Canvas Implementation
    /// </summary>
    public class QSortieMenuViewCanvasImpl
        : AbstractMvcViewCanvas, IMvcViewCanvas
    {
        private IDictionary<QSortieRequestType, ISet<ICanvasWidget>> qSortieTypeWidgets = new Dictionary<QSortieRequestType, ISet<ICanvasWidget>>();

        /// <inheritdoc/>
        protected override ISet<ICanvasWidget> InternalBuild()
        {
            ISet<ICanvasWidget> canvasWidgets = new HashSet<ICanvasWidget>()
            {
                this.BuildBackground(),
                this.BuildDetailsBackground()
            };
            this.BuildHeader();
            this.BuildMapDetailsButton();
            this.BuildCombatantDetailsButton();
            this.BuildSortieDetailsButton();
            this.BuildSortieStartButton();
            return canvasWidgets;
        }

        protected override void ProcessSelectedWidget(ICanvasWidget canvasWidget)
        {
        }

        private ICanvasWidget BuildBackground()
        {
            return ImageWidgetImpl.Builder.Get()
                .SetSpriteID(SpriteID.SquareBordered)
                .SetColorID(ColorID.Blue)
                .SetCanvasLevel(0)
                .SetInteractable(false)
                .SetEnabled(true)
                .SetWidgetGridSpec(new CanvasGridSpecImpl()
                    .SetCanvasGridCoords(Vector2.Zero)
                    .SetCanvasGridSize(this.canvasGridConvertor.GetGridSize()))
                .SetParent(this)
                .SetName(this.mvcType + ":BackImage")
                .Build();
        }

        private ICanvasWidget BuildDetailsBackground()
        {
            return ImageWidgetImpl.Builder.Get()
                .SetSpriteID(SpriteID.SquareBordered)
                .SetColorID(ColorID.Blue)
                .SetCanvasLevel(0)
                .SetInteractable(false)
                .SetEnabled(true)
                .SetWidgetGridSpec(new CanvasGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(this.canvasGridConvertor.GetGridSize().X / 4, 0))
                    .SetCanvasGridSize(new Vector2(this.canvasGridConvertor.GetGridSize().X * 3 / 4,
                        this.canvasGridConvertor.GetGridSize().Y - 1)))
                .SetParent(this)
                .SetName(this.mvcType + ":DetailsBackImage")
                .Build();
        }

        private ISet<ICanvasWidget> BuildHeader()
        {
            int widgetHeight = 1;
            IWidgetGridSpec widgetGridSpec = new CanvasGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(0, this.canvasGridConvertor.GetGridSize().Y - widgetHeight))
                    .SetCanvasGridSize(new Vector2(this.canvasGridConvertor.GetGridSize().X / 2, widgetHeight));
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

        private ISet<ICanvasWidget> BuildMapDetailsButton()
        {
            int widgetHeight = 1;
            IWidgetGridSpec widgetGridSpec = new CanvasGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(0, this.canvasGridConvertor.GetGridSize().Y - widgetHeight - 1))
                    .SetCanvasGridSize(new Vector2(this.canvasGridConvertor.GetGridSize().X / 4, 1));
            return new HashSet<ICanvasWidget>
            {
                ImageWidgetImpl.Builder.Get()
                    .SetSpriteID(SpriteID.SquareBordered)
                    .SetColorID(ColorID.Red)
                    .SetCanvasLevel(1)
                    .SetInteractable(true)
                    .SetEnabled(true)
                    .SetWidgetGridSpec(widgetGridSpec)
                    .SetParent(this)
                    .SetName(this.mvcType + ":" + QSortieRequestType.MapDetails + "Image")
                    .Build(),
                TextWidgetImpl.Builder.Get()
                    .SetText(QSortieRequestType.MapDetails.ToString())
                    .SetFont(FontID.Arial)
                    .SetColor(ColorID.White)
                    .SetAlign(AlignType.MiddleCenter)
                    .SetBestFit(true, 25, 100)
                    .SetCanvasLevel(1)
                    .SetInteractable(false)
                    .SetEnabled(true)
                    .SetWidgetGridSpec(widgetGridSpec)
                    .SetParent(this)
                    .SetName(this.mvcType + ":" + QSortieRequestType.MapDetails + "Text")
                    .Build()
            };
        }

        private ISet<ICanvasWidget> BuildCombatantDetailsButton()
        {
            int widgetHeight = 1;
            IWidgetGridSpec widgetGridSpec = new CanvasGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(0, this.canvasGridConvertor.GetGridSize().Y - widgetHeight - 2))
                    .SetCanvasGridSize(new Vector2(this.canvasGridConvertor.GetGridSize().X / 4, 1));
            return new HashSet<ICanvasWidget>
            {
                ImageWidgetImpl.Builder.Get()
                .SetSpriteID(SpriteID.SquareBordered)
                .SetColorID(ColorID.Red)
                .SetCanvasLevel(1)
                .SetInteractable(true)
                .SetEnabled(true)
                .SetWidgetGridSpec(widgetGridSpec)
                .SetParent(this)
                .SetName(this.mvcType + ":" + QSortieRequestType.CombatantDetails + "Image")
                .Build(),
                TextWidgetImpl.Builder.Get()
                .SetText(QSortieRequestType.CombatantDetails.ToString())
                .SetFont(FontID.Arial)
                .SetColor(ColorID.White)
                .SetAlign(AlignType.MiddleCenter)
                .SetBestFit(true, 25, 100)
                .SetCanvasLevel(1)
                .SetInteractable(false)
                .SetEnabled(true)
                .SetWidgetGridSpec(widgetGridSpec)
                .SetParent(this)
                .SetName(this.mvcType + ":" + QSortieRequestType.CombatantDetails + "Text")
                .Build()
            };
        }

        private ISet<ICanvasWidget> BuildSortieDetailsButton()
        {
            int widgetHeight = 1;
            IWidgetGridSpec widgetGridSpec = new CanvasGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(0, 0))
                    .SetCanvasGridSize(new Vector2(this.canvasGridConvertor.GetGridSize().X / 4, widgetHeight));
            return new HashSet<ICanvasWidget>
            {
                ImageWidgetImpl.Builder.Get()
                    .SetSpriteID(SpriteID.SquareBordered)
                    .SetColorID(ColorID.Red)
                    .SetCanvasLevel(1)
                    .SetInteractable(true)
                    .SetEnabled(true)
                    .SetWidgetGridSpec(widgetGridSpec)
                    .SetParent(this)
                    .SetName(this.mvcType + ":" + QSortieRequestType.SortieDetails + "Image")
                    .Build(),
                TextWidgetImpl.Builder.Get()
                    .SetText(QSortieRequestType.SortieDetails.ToString())
                    .SetFont(FontID.Arial)
                    .SetColor(ColorID.White)
                    .SetAlign(AlignType.MiddleCenter)
                    .SetBestFit(true, 25, 100)
                    .SetCanvasLevel(1)
                    .SetInteractable(false)
                    .SetEnabled(true)
                    .SetWidgetGridSpec(widgetGridSpec)
                    .SetParent(this)
                    .SetName(this.mvcType + ":" + QSortieRequestType.SortieDetails + "Text")
                    .Build()
            };
        }

        private ISet<ICanvasWidget> BuildSortieDetailsPanel()
        {
            int widgetHeight = 1;
            IWidgetGridSpec widgetGridSpec = new CanvasGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(0, 0))
                    .SetCanvasGridSize(new Vector2(this.canvasGridConvertor.GetGridSize().X / 4, widgetHeight));
            return new HashSet<ICanvasWidget>
            {
                ImageWidgetImpl.Builder.Get()
                    .SetSpriteID(SpriteID.SquareBordered)
                    .SetColorID(ColorID.Red)
                    .SetCanvasLevel(1)
                    .SetInteractable(true)
                    .SetEnabled(true)
                    .SetWidgetGridSpec(widgetGridSpec)
                    .SetParent(this)
                    .SetName(this.mvcType + ":" + QSortieRequestType.SortieDetails + "Image")
                    .Build(),
                TextWidgetImpl.Builder.Get()
                    .SetText(QSortieRequestType.SortieDetails.ToString())
                    .SetFont(FontID.Arial)
                    .SetColor(ColorID.White)
                    .SetAlign(AlignType.MiddleCenter)
                    .SetBestFit(true, 25, 100)
                    .SetCanvasLevel(1)
                    .SetInteractable(false)
                    .SetEnabled(true)
                    .SetWidgetGridSpec(widgetGridSpec)
                    .SetParent(this)
                    .SetName(this.mvcType + ":" + QSortieRequestType.SortieDetails + "Text")
                    .Build()
            };
        }

        private ISet<ICanvasWidget> BuildSortieStartButton()
        {
            int widgetHeight = 1;
            IWidgetGridSpec widgetGridSpec = new CanvasGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(this.canvasGridConvertor.GetGridSize().X * 3 / 4, 0))
                    .SetCanvasGridSize(new Vector2(this.canvasGridConvertor.GetGridSize().X / 4, widgetHeight));
            return new HashSet<ICanvasWidget>
            {
                ImageWidgetImpl.Builder.Get()
                    .SetSpriteID(SpriteID.SquareBordered)
                    .SetColorID(ColorID.Red)
                    .SetCanvasLevel(1)
                    .SetInteractable(true)
                    .SetEnabled(true)
                    .SetWidgetGridSpec(widgetGridSpec)
                    .SetParent(this)
                    .SetName(this.mvcType + ":" + QSortieRequestType.SortieStart + "Image")
                    .Build(),
                TextWidgetImpl.Builder.Get()
                    .SetText(QSortieRequestType.SortieStart.ToString())
                    .SetFont(FontID.Arial)
                    .SetColor(ColorID.White)
                    .SetAlign(AlignType.MiddleCenter)
                    .SetBestFit(true, 25, 100)
                    .SetCanvasLevel(1)
                    .SetInteractable(false)
                    .SetEnabled(true)
                    .SetWidgetGridSpec(widgetGridSpec)
                    .SetParent(this)
                    .SetName(this.mvcType + ":" + QSortieRequestType.SortieStart + "Text")
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
                    IMvcViewCanvas mvcViewCanvas = gameObject.AddComponent<QSortieMenuViewCanvasImpl>();
                    this.ApplyMvcViewValues((AbstractMvcViewCanvas)mvcViewCanvas);
                    mvcViewCanvas.Build();
                    return mvcViewCanvas;
                }
            }
        }
    }
}