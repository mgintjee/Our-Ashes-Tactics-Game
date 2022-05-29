using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Convertors.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Convertors.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Structs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Sprites.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Utils;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Constants;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Types;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Abstrs
{
    /// <summary>
    /// Panel Widget Impl
    /// </summary>
    public abstract class AbstractPanelWidget
        : AbstractCanvasWidget, IPanelWidget
    {
        protected ICanvasGridConvertor canvasGridConvertor;
        private readonly IDictionary<int, ISet<ICanvasWidget>> canvasLevelWidgets = new Dictionary<int, ISet<ICanvasWidget>>();

        public void SetPanelGridSize(Vector2 gridSize)
        {
            Vector2 worldSize = new Vector2(this.GetRectTransform().sizeDelta.x,
                this.GetRectTransform().sizeDelta.y);
            this.canvasGridConvertor = new CanvasGridConvertorImpl(gridSize, worldSize);
            this.logger.Debug("Updated: {}", this.canvasGridConvertor);
        }

        void IPanelWidget.AddWidget(ICanvasWidget canvasWidget)
        {
            this.InternalAddWidget(canvasWidget);
        }

        void IPanelWidget.AddWidgets(ICollection<ICanvasWidget> canvasWidgets)
        {
            foreach (ICanvasWidget canvasWidget in canvasWidgets)
            {
                this.InternalAddWidget(canvasWidget);
            }
        }

        /// <inheritdoc/>
        void ICanvasWidget.ApplyGridConvertor(ICanvasGridConvertor canvasGridConvertor)
        {
            this.logger.Debug("Applying {} to {}...", canvasGridConvertor, this.widgetName);
            CanvasWidgetUtils.ApplyGridConvertor(canvasGridConvertor, this);
            this.canvasGridConvertor = new CanvasGridConvertorImpl(this.canvasGridConvertor.GetGridSize(),
                new Vector2(this.GetRectTransform().sizeDelta.x, this.GetRectTransform().sizeDelta.y));
            foreach (ICollection<ICanvasWidget> canvasWidgets in this.canvasLevelWidgets.Values)
            {
                foreach (ICanvasWidget canvasWidget in canvasWidgets)
                {
                    canvasWidget.ApplyGridConvertor(this.canvasGridConvertor);
                }
            }
        }

        Optional<ICanvasWidget> IPanelWidget.GetWidgetFromInput(ICanvasGridConvertor canvasGridConvertor, IMvcControlInput mvcControlInput)
        {
            List<int> canvasLevels = new List<int>(canvasLevelWidgets.Keys);
            canvasLevels.Sort();
            foreach (int canvasLevel in canvasLevels)
            {
                foreach (ICanvasWidget canvasWidget in canvasLevelWidgets[canvasLevel])
                {
                    if (canvasWidget is IPanelWidget panelWidget)
                    {
                        Optional<ICanvasWidget> returnedWidget = panelWidget.GetWidgetFromInput(canvasGridConvertor, mvcControlInput);
                        if (returnedWidget.IsPresent())
                        {
                            return returnedWidget;
                        }
                    }
                    else if (canvasWidget.GetEnabled() && canvasWidget.GetInteractable() &&
                        CanvasWidgetUtils.IsInputOnWidget(mvcControlInput, canvasWidget))
                    {
                        return Optional<ICanvasWidget>.Of(canvasWidget);
                    }
                }
            }
            return Optional<ICanvasWidget>.Empty();
        }

        protected ICanvasWidget BuildBackground()
        {
            return ImageWidgetImpl.Builder.Get()
                .SetSpriteID(SpriteID.SquareBordered)
                .SetColorID(ColorID.DodgerBlue)
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(0)
                .SetInteractable(false)
                .SetEnabled(true)
                .SetWidgetGridSpec(new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(Vector2.Zero)
                    .SetCanvasGridSize(this.canvasGridConvertor.GetGridSize()))
                .SetParent(this)
                .SetName(this.mvcType + ":" + this.GetType().Name + ":Background:" + CanvasWidgetType.Image)
                .Build();
        }

        protected abstract void InitialBuild();

        protected void InternalAddWidget(ICanvasWidget canvasWidget)
        {
            logger.Info("Adding {}...", canvasWidget.GetName());
            canvasWidget.SetParent(this);
            CanvasWidgetUtils.AddWidget(this.canvasGridConvertor, this.canvasLevelWidgets, canvasWidget);
        }

        protected void InternalAddWidgets(ISet<ICanvasWidget> canvasWidgets)
        {
            logger.Info("Adding {} {}s...", canvasWidgets.Count, typeof(ICanvasWidget));
            foreach (ICanvasWidget canvasWidget in canvasWidgets)
            {
                this.InternalAddWidget(canvasWidget);
            }
        }

        protected ICarouselPanelWidget BuildCarousel(string name, IWidgetGridSpec widgetGridSpec)
        {
            IList<TextImageWidgetStruct> headerTextImageWidgetStructs = new List<TextImageWidgetStruct>
            {
                new TextImageWidgetStruct(name+":",
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_TEXT_COLOR,
                    WidgetConstants.SECONDARY_COLOR_ID)
            };
            Vector2 panelGridSize = new Vector2(6, 1);
            return (ICarouselPanelWidget)CarouselPanelImpl.Builder.Get()
                .SetHeaderTextImageWidgetStructs(headerTextImageWidgetStructs)
                .SetBackgroundColor(WidgetConstants.PRIMARY_COLOR_ID)
                .SetPanelGridSize(panelGridSize)
                .SetWidgetGridSpec(widgetGridSpec)
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(1)
                .SetInteractable(false)
                .SetEnabled(true)
                .SetName(this.mvcType + ":" + this.GetType().Name + ":" + CanvasWidgetType.Panel + ":Carousel:" + widgetName)
                .SetParent(this)
                .Build();
        }

        protected IMultiTextPanelWidget BuildMultiText(string widgetName, Vector2 canvasGridCoords,
            Vector2 canvasGridSize, IList<TextImageWidgetStruct> textImageWidgetStructs, bool interactable)
        {
            Vector2 panelGridSize = new Vector2(textImageWidgetStructs.Count, 1);
            IDictionary<int, TextImageWidgetStruct> indexTextImageWidgetStructs = new Dictionary<int, TextImageWidgetStruct>();
            for (int i = 0; i < textImageWidgetStructs.Count; ++i)
            {
                indexTextImageWidgetStructs.Add(i, textImageWidgetStructs[i]);
            }
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(canvasGridCoords)
                    .SetCanvasGridSize(canvasGridSize);
            return (IMultiTextPanelWidget)MultiTextPanelImpl.Builder.Get()
                .SetTextImageWidgetStructs(indexTextImageWidgetStructs)
                .SetBackgroundColor(WidgetConstants.PRIMARY_COLOR_ID)
                .SetPanelGridSize(panelGridSize)
                .SetWidgetGridSpec(widgetGridSpec)
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(1)
                .SetInteractable(interactable)
                .SetEnabled(true)
                .SetName(this.mvcType + ":" + this.GetType().Name + ":" + CanvasWidgetType.Panel + ":" + widgetName)
                .SetParent(this)
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class PanelWidgetBuilders
        {
            /// <summary>
            /// Todo
            /// </summary>
            public interface IPanelWidgetBuilder
                : AbstractWidgetBuilders.IWidgetBuilder<IPanelWidget>
            {
                /// <summary>
                /// Todo
                /// </summary>
                /// <returns></returns>
                IPanelWidgetBuilder SetPanelGridSize(Vector2 gridSize);
            }

            /// <summary>
            /// Todo
            /// </summary>
            public abstract class InternalPanelWidgetBuilder
                : AbstractWidgetBuilders.AbstractWidgetBuilder<IPanelWidget>, IPanelWidgetBuilder
            {
                private Vector2 panelGridSize;

                IPanelWidgetBuilder IPanelWidgetBuilder.SetPanelGridSize(Vector2 gridSize)
                {
                    this.panelGridSize = gridSize;
                    return this;
                }

                protected override void ValidateWidgetBuilder(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, this.panelGridSize);
                }

                protected void ApplyPanelValues(IPanelWidget panelWidget)
                {
                    this.ApplyCommonValues(panelWidget);
                    ((AbstractPanelWidget)panelWidget).SetPanelGridSize(this.panelGridSize);
                    ((AbstractPanelWidget)panelWidget).InitialBuild();
                }
            }
        }
    }
}