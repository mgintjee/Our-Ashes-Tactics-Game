using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Fonts.Aligns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Fonts.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Sprites.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Utils;
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
        private readonly List<ICanvasWidget> combatantDetailsPanelWidgets = new List<ICanvasWidget>();
        private readonly List<ICanvasWidget> mapDetailsPanelWidgets = new List<ICanvasWidget>();
        private readonly List<ICanvasWidget> sortieDetailsPanelWidgets = new List<ICanvasWidget>();
        private IImageWidget combatantDetailsButton;
        private IImageWidget mapDetailsButton;
        private IImageWidget sortieDetailsButton;

        public override void Process(IMvcModelState mvcModelState)
        {
            throw new System.NotImplementedException();
        }

        public override void InitialBuild()
        {
            List<ICanvasWidget> canvasWidgets = new List<ICanvasWidget>() { this.BuildBackground() };

            canvasWidgets.AddRange(this.BuildHeader());
            canvasWidgets.AddRange(this.BuildBackgrounds());

            this.mapDetailsButton = MapDetailsUtil.BuildButtonImage(this.canvasGridConvertor, this);
            this.sortieDetailsButton = SortieDetailsUtil.BuildButtonImage(this.canvasGridConvertor, this);

            canvasWidgets.Add(this.mapDetailsButton);
            canvasWidgets.Add(MapDetailsUtil.BuildButtonText(this.canvasGridConvertor, this));
            canvasWidgets.Add(this.sortieDetailsButton);
            canvasWidgets.Add(SortieDetailsUtil.BuildButtonText(this.canvasGridConvertor, this));

            canvasWidgets.AddRange(this.BuildCombatantDetailsButton());

            ICollection<ICanvasWidget> sortieDetailsPanelWidgets = SortieDetailsUtil
                .BuildPanel(this.canvasGridConvertor, this);
            canvasWidgets.AddRange(sortieDetailsPanelWidgets);
            this.sortieDetailsPanelWidgets.AddRange(sortieDetailsPanelWidgets);

            ICollection<ICanvasWidget> mapDetailsPanelWidgets = MapDetailsUtil
                .BuildPanel(this.canvasGridConvertor, this);
            canvasWidgets.AddRange(mapDetailsPanelWidgets);
            this.mapDetailsPanelWidgets.AddRange(mapDetailsPanelWidgets);

            canvasWidgets.AddRange(this.BuildSortieStartButton());
            this.AddWidgets(canvasWidgets);
        }

        /// <inheritdoc/>
        protected override void ProcessSelectedWidget(ICanvasWidget canvasWidget)
        {
            string widgetName = canvasWidget.GetName();
            if (canvasWidget.GetInteractable() && widgetName.Contains("Button") &&
                !widgetName.Contains(QSortieRequestType.SortieStart.ToString()))
            {
                if (widgetName.Contains(QSortieRequestType.CombatantDetails.ToString()))
                {
                    CanvasWidgetUtils.SetButtonInteractable(this.combatantDetailsButton, false);
                    CanvasWidgetUtils.EnableWidgets(this.combatantDetailsPanelWidgets, true);

                    CanvasWidgetUtils.SetButtonInteractable(this.mapDetailsButton, true);
                    CanvasWidgetUtils.EnableWidgets(this.mapDetailsPanelWidgets, false);

                    CanvasWidgetUtils.SetButtonInteractable(this.sortieDetailsButton, true);
                    CanvasWidgetUtils.EnableWidgets(this.sortieDetailsPanelWidgets, false);
                }
                else if (widgetName.Contains(QSortieRequestType.MapDetails.ToString()))
                {
                    CanvasWidgetUtils.SetButtonInteractable(this.combatantDetailsButton, true);
                    CanvasWidgetUtils.EnableWidgets(this.combatantDetailsPanelWidgets, false);

                    CanvasWidgetUtils.SetButtonInteractable(this.mapDetailsButton, false);
                    CanvasWidgetUtils.EnableWidgets(this.mapDetailsPanelWidgets, true);

                    CanvasWidgetUtils.SetButtonInteractable(this.sortieDetailsButton, true);
                    CanvasWidgetUtils.EnableWidgets(this.sortieDetailsPanelWidgets, false);
                }
                else if (widgetName.Contains(QSortieRequestType.SortieDetails.ToString()))
                {
                    CanvasWidgetUtils.SetButtonInteractable(this.combatantDetailsButton, true);
                    CanvasWidgetUtils.EnableWidgets(this.combatantDetailsPanelWidgets, false);

                    CanvasWidgetUtils.SetButtonInteractable(this.mapDetailsButton, true);
                    CanvasWidgetUtils.EnableWidgets(this.mapDetailsPanelWidgets, false);

                    CanvasWidgetUtils.SetButtonInteractable(this.sortieDetailsButton, false);
                    CanvasWidgetUtils.EnableWidgets(this.sortieDetailsPanelWidgets, true);
                }
            }
        }

        private ISet<ICanvasWidget> BuildBackgrounds()
        {
            int widgetHeight = (int)(this.canvasGridConvertor.GetGridSize().Y - 1);
            float panelWidth = this.canvasGridConvertor.GetGridSize().X * 3 / 4;
            float buttonWidth = this.canvasGridConvertor.GetGridSize().X / 4;
            return new HashSet<ICanvasWidget>()
            {
                ImageWidgetImpl.Builder.Get()
                    .SetSpriteID(SpriteID.SquareBordered)
                    .SetColorID(ColorID.Blue)
                    .SetCanvasLevel(0)
                    .SetInteractable(false)
                    .SetEnabled(true)
                    .SetWidgetGridSpec(new CanvasGridSpecImpl()
                        .SetCanvasGridCoords(new Vector2(0, 0))
                        .SetCanvasGridSize(new Vector2(buttonWidth, widgetHeight)))
                    .SetParent(this)
                    .SetName(this.mvcType + ":Background:Button:Image")
                    .Build(),
                ImageWidgetImpl.Builder.Get()
                    .SetSpriteID(SpriteID.SquareBordered)
                    .SetColorID(ColorID.Blue)
                    .SetCanvasLevel(0)
                    .SetInteractable(false)
                    .SetEnabled(true)
                    .SetWidgetGridSpec(new CanvasGridSpecImpl()
                        .SetCanvasGridCoords(new Vector2(buttonWidth, 0))
                        .SetCanvasGridSize(new Vector2(panelWidth, widgetHeight)))
                    .SetParent(this)
                    .SetName(this.mvcType + ":Background:Panel:Image")
                    .Build()
            };
        }

        private ISet<ICanvasWidget> BuildCombatantDetailsButton()
        {
            int widgetHeight = 1;
            IWidgetGridSpec widgetGridSpec = new CanvasGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(0, this.canvasGridConvertor.GetGridSize().Y - widgetHeight - 2))
                    .SetCanvasGridSize(new Vector2(this.canvasGridConvertor.GetGridSize().X / 4, 1));
            this.combatantDetailsButton = ImageWidgetImpl.Builder.Get()
                    .SetSpriteID(SpriteID.SquareBordered)
                    .SetColorID(ColorID.Red)
                    .SetCanvasLevel(1)
                    .SetInteractable(true)
                    .SetEnabled(true)
                    .SetWidgetGridSpec(widgetGridSpec)
                    .SetParent(this)
                    .SetName(this.mvcType + ":" + QSortieRequestType.CombatantDetails + ":Button:Image")
                    .Build();
            return new HashSet<ICanvasWidget>
            {
                this.combatantDetailsButton,
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
                    .SetName(this.mvcType + ":" + QSortieRequestType.CombatantDetails + ":Button:Text")
                    .Build()
            };
        }

        private ISet<ICanvasWidget> BuildSortieDetailsButton()
        {
            int widgetHeight = 1;
            IWidgetGridSpec widgetGridSpec = new CanvasGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(0, this.canvasGridConvertor.GetGridSize().Y - widgetHeight - 3))
                    .SetCanvasGridSize(new Vector2(this.canvasGridConvertor.GetGridSize().X / 4, widgetHeight));
            this.sortieDetailsButton = ImageWidgetImpl.Builder.Get()
                    .SetSpriteID(SpriteID.SquareBordered)
                    .SetColorID(ColorID.Gray)
                    .SetCanvasLevel(1)
                    .SetInteractable(false)
                    .SetEnabled(true)
                    .SetWidgetGridSpec(widgetGridSpec)
                    .SetParent(this)
                    .SetName(this.mvcType + ":" + QSortieRequestType.SortieDetails + ":Button:Image")
                    .Build();
            return new HashSet<ICanvasWidget>
            {
                this.sortieDetailsButton,
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
                    .SetName(this.mvcType + ":" + QSortieRequestType.SortieDetails + ":Button:Text")
                    .Build()
            };
        }

        private ISet<ICanvasWidget> BuildSortieStartButton()
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
                    .SetName(this.mvcType + ":" + QSortieRequestType.SortieStart + ":Button:Image")
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
                    .SetName(this.mvcType + ":" + QSortieRequestType.SortieStart + ":Button:Text")
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
                    mvcViewCanvas.InitialBuild();
                    return mvcViewCanvas;
                }
            }
        }
    }
}