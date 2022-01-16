using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
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
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSortieMenus.Frames.Requests.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSortieMenus.Views.Canvases.Widgets.Impls;
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
        private readonly List<ICanvasWidget> phalanxDetailsPanelWidgets = new List<ICanvasWidget>();
        private readonly List<ICanvasWidget> mapDetailsPanelWidgets = new List<ICanvasWidget>();
        private readonly List<ICanvasWidget> sortieDetailsPanelWidgets = new List<ICanvasWidget>();

        private readonly IDictionary<QSortieMenuRequestType, List<ICanvasWidget>> typeCanvasWidgets =
            new Dictionary<QSortieMenuRequestType, List<ICanvasWidget>>()
        {
            { QSortieMenuRequestType.CombatantDetails, new List<ICanvasWidget>() },
            { QSortieMenuRequestType.PhalanxDetails, new List<ICanvasWidget>() },
            { QSortieMenuRequestType.MapDetails, new List<ICanvasWidget>() },
            { QSortieMenuRequestType.SortieDetails, new List<ICanvasWidget>() },
        };

        private readonly IDictionary<QSortieMenuRequestType, ICanvasWidget> qSortieMenuTypeButtons =
            new Dictionary<QSortieMenuRequestType, ICanvasWidget>();

        private IImageWidget combatantDetailsButton;
        private IImageWidget mapDetailsButton;
        private IImageWidget sortieDetailsButton;
        private IImageWidget phalanxDetailsButton;

        public override void InitialBuild()
        {
            List<ICanvasWidget> canvasWidgets = new List<ICanvasWidget>() { this.BuildBackground() };
            canvasWidgets.Add(QSortieMenuHeaderPanelImpl.Builder.Get()
                .SetPanelGridSize(new Vector2(2, 1))
                .SetWidgetGridSpec(new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(0, this.canvasGridConvertor.GetGridSize().Y * 6 / 7))
                    .SetCanvasGridSize(new Vector2(this.canvasGridConvertor.GetGridSize().X,
                        this.canvasGridConvertor.GetGridSize().Y / 7)))
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(0)
                .SetInteractable(false)
                .SetEnabled(true)
                .SetName(MvcType.QSortieMenu + ":Header:" + CanvasWidgetType.Panel)
                .SetParent(this)
                .Build());
            canvasWidgets.Add(QSortieMenuButtonsPanelImpl.Builder.Get()
                .SetPanelGridSize(new Vector2(1, 5))
                .SetWidgetGridSpec(new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(0, 0))
                    .SetCanvasGridSize(new Vector2(this.canvasGridConvertor.GetGridSize().X / 4,
                        this.canvasGridConvertor.GetGridSize().Y * 6 / 7)))
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(0)
                .SetInteractable(false)
                .SetEnabled(true)
                .SetName(MvcType.QSortieMenu + ":Button:" + CanvasWidgetType.Panel)
                .SetParent(this)
                .Build());
            /*

            this.qSortieMenuTypeButtons.Add(QSortieMenuRequestType.MapDetails,
                MapDetailsUtil.BuildButtonImage(this.canvasGridConvertor, this));
            canvasWidgets.Add(MapDetailsUtil.BuildButtonText(this.canvasGridConvertor, this));

            this.qSortieMenuTypeButtons.Add(QSortieMenuRequestType.SortieDetails,
                SortieDetailsUtil.BuildButtonImage(this.canvasGridConvertor, this));
            canvasWidgets.Add(SortieDetailsUtil.BuildButtonText(this.canvasGridConvertor, this));

            this.qSortieMenuTypeButtons.Add(QSortieMenuRequestType.CombatantDetails,
                CombatantDetailsUtil.BuildButtonImage(this.canvasGridConvertor, this));
            canvasWidgets.Add(CombatantDetailsUtil.BuildButtonText(this.canvasGridConvertor, this));

            this.qSortieMenuTypeButtons.Add(QSortieMenuRequestType.PhalanxDetails,
                PhalanxDetailsUtil.BuildButtonImage(this.canvasGridConvertor, this));
            canvasWidgets.Add(PhalanxDetailsUtil.BuildButtonText(this.canvasGridConvertor, this));

            canvasWidgets.AddRange(this.qSortieMenuTypeButtons.Values);

            this.typeCanvasWidgets[QSortieMenuRequestType.MapDetails].AddRange(
                MapDetailsUtil.BuildPanel(this.canvasGridConvertor, this));
            this.typeCanvasWidgets[QSortieMenuRequestType.SortieDetails].AddRange(
                SortieDetailsUtil.BuildPanel(this.canvasGridConvertor, this));
            this.typeCanvasWidgets[QSortieMenuRequestType.PhalanxDetails].AddRange(
                CombatantDetailsUtil.BuildPanel(this.canvasGridConvertor, this));
            this.typeCanvasWidgets[QSortieMenuRequestType.CombatantDetails].AddRange(
                PhalanxDetailsUtil.BuildPanel(this.canvasGridConvertor, this));

            foreach(ICollection<ICanvasWidget> widgets in this.typeCanvasWidgets.Values)
            {
                canvasWidgets.AddRange(widgets);
            }
            */
            this.AddWidgets(canvasWidgets);
        }

        /// <inheritdoc/>
        protected override void ProcessSelectedWidget(ICanvasWidget canvasWidget)
        {/*
            string widgetName = canvasWidget.GetName();
            if (canvasWidget.GetInteractable() && widgetName.Contains("Button") &&
                !widgetName.Contains(QSortieMenuRequestType.SortieStart.ToString()))
            {
                if (widgetName.Contains(QSortieMenuRequestType.CombatantDetails.ToString()))
                {
                    CanvasWidgetUtils.SetButtonInteractable(this.combatantDetailsButton, false);
                    CanvasWidgetUtils.EnableWidgets(this.combatantDetailsPanelWidgets, true);

                    CanvasWidgetUtils.SetButtonInteractable(this.mapDetailsButton, true);
                    CanvasWidgetUtils.EnableWidgets(this.mapDetailsPanelWidgets, false);

                    CanvasWidgetUtils.SetButtonInteractable(this.sortieDetailsButton, true);
                    CanvasWidgetUtils.EnableWidgets(this.sortieDetailsPanelWidgets, false);
                }
                else if (widgetName.Contains(QSortieMenuRequestType.MapDetails.ToString()))
                {
                    CanvasWidgetUtils.SetButtonInteractable(this.combatantDetailsButton, true);
                    CanvasWidgetUtils.EnableWidgets(this.combatantDetailsPanelWidgets, false);

                    CanvasWidgetUtils.SetButtonInteractable(this.mapDetailsButton, false);
                    CanvasWidgetUtils.EnableWidgets(this.mapDetailsPanelWidgets, true);

                    CanvasWidgetUtils.SetButtonInteractable(this.sortieDetailsButton, true);
                    CanvasWidgetUtils.EnableWidgets(this.sortieDetailsPanelWidgets, false);
                }
                else if (widgetName.Contains(QSortieMenuRequestType.SortieDetails.ToString()))
                {
                    CanvasWidgetUtils.SetButtonInteractable(this.combatantDetailsButton, true);
                    CanvasWidgetUtils.EnableWidgets(this.combatantDetailsPanelWidgets, false);

                    CanvasWidgetUtils.SetButtonInteractable(this.mapDetailsButton, true);
                    CanvasWidgetUtils.EnableWidgets(this.mapDetailsPanelWidgets, false);

                    CanvasWidgetUtils.SetButtonInteractable(this.sortieDetailsButton, false);
                    CanvasWidgetUtils.EnableWidgets(this.sortieDetailsPanelWidgets, true);
                }
            }
            */
        }

        private ISet<ICanvasWidget> BuildSubBackgrounds()
        {
            int widgetHeight = (int)(this.canvasGridConvertor.GetGridSize().Y - 1);
            float panelWidth = this.canvasGridConvertor.GetGridSize().X * 3 / 4;
            float buttonWidth = this.canvasGridConvertor.GetGridSize().X / 4;
            return new HashSet<ICanvasWidget>()
            {
                ImageWidgetImpl.Builder.Get()
                    .SetSpriteID(SpriteID.SquareBordered)
                    .SetColorID(ColorID.Blue)
                .SetMvcType(this.mvcType)
                    .SetCanvasLevel(0)
                    .SetInteractable(false)
                    .SetEnabled(true)
                    .SetWidgetGridSpec(new WidgetGridSpecImpl()
                        .SetCanvasGridCoords(new Vector2(0, 0))
                        .SetCanvasGridSize(new Vector2(buttonWidth, widgetHeight)))
                    .SetParent(this)
                    .SetName(this.mvcType + ":Background:Button:Image")
                    .Build(),
                ImageWidgetImpl.Builder.Get()
                    .SetSpriteID(SpriteID.SquareBordered)
                    .SetColorID(ColorID.Blue)
                .SetMvcType(this.mvcType)
                    .SetCanvasLevel(0)
                    .SetInteractable(false)
                    .SetEnabled(true)
                    .SetWidgetGridSpec(new WidgetGridSpecImpl()
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
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(0, this.canvasGridConvertor.GetGridSize().Y - widgetHeight - 2))
                    .SetCanvasGridSize(new Vector2(this.canvasGridConvertor.GetGridSize().X / 4, 1));
            this.combatantDetailsButton = ImageWidgetImpl.Builder.Get()
                    .SetSpriteID(SpriteID.SquareBordered)
                    .SetColorID(ColorID.Red)
                .SetMvcType(this.mvcType)
                    .SetCanvasLevel(1)
                    .SetInteractable(true)
                    .SetEnabled(true)
                    .SetWidgetGridSpec(widgetGridSpec)
                    .SetParent(this)
                    .SetName(this.mvcType + ":" + QSortieMenuRequestType.CombatantDetails + ":Button:Image")
                    .Build();
            return new HashSet<ICanvasWidget>
            {
                this.combatantDetailsButton,
                TextWidgetImpl.Builder.Get()
                    .SetText(QSortieMenuRequestType.CombatantDetails.ToString())
                    .SetFont(FontID.Arial)
                    .SetColor(ColorID.White)
                    .SetAlign(AlignType.MiddleCenter)
                    .SetBestFit(true, 25, 100)
                .SetMvcType(this.mvcType)
                    .SetCanvasLevel(1)
                    .SetInteractable(false)
                    .SetEnabled(true)
                    .SetWidgetGridSpec(widgetGridSpec)
                    .SetParent(this)
                    .SetName(this.mvcType + ":" + QSortieMenuRequestType.CombatantDetails + ":Button:Text")
                    .Build()
            };
        }

        private ISet<ICanvasWidget> BuildSortieDetailsButton()
        {
            int widgetHeight = 1;
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(0, this.canvasGridConvertor.GetGridSize().Y - widgetHeight - 3))
                    .SetCanvasGridSize(new Vector2(this.canvasGridConvertor.GetGridSize().X / 4, widgetHeight));
            this.sortieDetailsButton = ImageWidgetImpl.Builder.Get()
                    .SetSpriteID(SpriteID.SquareBordered)
                    .SetColorID(ColorID.Gray)
                .SetMvcType(this.mvcType)
                    .SetCanvasLevel(1)
                    .SetInteractable(false)
                    .SetEnabled(true)
                    .SetWidgetGridSpec(widgetGridSpec)
                    .SetParent(this)
                    .SetName(this.mvcType + ":" + QSortieMenuRequestType.SortieDetails + ":Button:Image")
                    .Build();
            return new HashSet<ICanvasWidget>
            {
                this.sortieDetailsButton,
                TextWidgetImpl.Builder.Get()
                    .SetText(QSortieMenuRequestType.SortieDetails.ToString())
                    .SetFont(FontID.Arial)
                    .SetColor(ColorID.White)
                    .SetAlign(AlignType.MiddleCenter)
                    .SetBestFit(true, 25, 100)
                .SetMvcType(this.mvcType)
                    .SetCanvasLevel(1)
                    .SetInteractable(false)
                    .SetEnabled(true)
                    .SetWidgetGridSpec(widgetGridSpec)
                    .SetParent(this)
                    .SetName(this.mvcType + ":" + QSortieMenuRequestType.SortieDetails + ":Button:Text")
                    .Build()
            };
        }

        private ISet<ICanvasWidget> BuildSortieStartButton()
        {
            int widgetHeight = 1;
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(0, 0))
                    .SetCanvasGridSize(new Vector2(this.canvasGridConvertor.GetGridSize().X / 4, widgetHeight));
            return new HashSet<ICanvasWidget>
            {
                ImageWidgetImpl.Builder.Get()
                    .SetSpriteID(SpriteID.SquareBordered)
                    .SetColorID(ColorID.Red)
                .SetMvcType(this.mvcType)
                    .SetCanvasLevel(1)
                    .SetInteractable(true)
                    .SetEnabled(true)
                    .SetWidgetGridSpec(widgetGridSpec)
                    .SetParent(this)
                    .SetName(this.mvcType + ":" + QSortieMenuRequestType.SortieStart + ":Button:Image")
                    .Build(),
                TextWidgetImpl.Builder.Get()
                    .SetText(QSortieMenuRequestType.SortieStart.ToString())
                    .SetFont(FontID.Arial)
                    .SetColor(ColorID.White)
                    .SetAlign(AlignType.MiddleCenter)
                    .SetBestFit(true, 25, 100)
                .SetMvcType(this.mvcType)
                    .SetCanvasLevel(1)
                    .SetInteractable(false)
                    .SetEnabled(true)
                    .SetWidgetGridSpec(widgetGridSpec)
                    .SetParent(this)
                    .SetName(this.mvcType + ":" + QSortieMenuRequestType.SortieStart + ":Button:Text")
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