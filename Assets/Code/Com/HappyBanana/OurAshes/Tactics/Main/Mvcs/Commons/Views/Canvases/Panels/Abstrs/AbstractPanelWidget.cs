using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Convertors.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Convertors.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Structs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Sprites.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Utils;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Constants;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Abstrs
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
        }

        /// <inheritdoc/>
        void ICanvasWidget.SetEnabled(bool enabled)
        {
            this.isEnabled = enabled;
            this.gameObject.SetActive(enabled);
            foreach (ISet<ICanvasWidget> canvasWidgets in this.canvasLevelWidgets.Values)
            {
                foreach (ICanvasWidget canvasWidget in canvasWidgets)
                {
                    canvasWidget.SetEnabled(enabled);
                }
            }
        }

        void IPanelWidget.AddWidget(ICanvasWidget canvasWidget)
        {
            this.InternalAddWidget(canvasWidget);
        }

        void IPanelWidget.AddWidgets(ICollection<ICanvasWidget> canvasWidgets)
        {
            this.InternalAddWidgets(canvasWidgets);
        }

        /// <inheritdoc/>
        void ICanvasWidget.ApplyGridConvertor(ICanvasGridConvertor canvasGridConvertor)
        {
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
            canvasLevels.Reverse();

            foreach (int canvasLevel in canvasLevels)
            {
                logger.Debug("Checking level:{}, {} available widgets", canvasLevel, canvasLevelWidgets[canvasLevel].Count);
                foreach (ICanvasWidget canvasWidget in canvasLevelWidgets[canvasLevel])
                {
                    logger.Debug("Checking if input is on {}...", canvasWidget.GetName());
                    if (canvasWidget is IPanelWidget panelWidget)
                    {
                        Optional<ICanvasWidget> returnedWidget = panelWidget.GetWidgetFromInput(
                            this.canvasGridConvertor, mvcControlInput);
                        if (returnedWidget.IsPresent())
                        {
                            logger.Debug("Input is on {}!", returnedWidget.GetValue().GetName());
                            return returnedWidget;
                        }
                    }
                    else if (canvasWidget.GetEnabled() && canvasWidget.GetInteractable() &&
                        CanvasWidgetUtils.IsInputOnWidget(mvcControlInput, canvasWidget))
                    {
                        logger.Debug("Input is on {}!", canvasWidget.GetName());
                        return Optional<ICanvasWidget>.Of(canvasWidget);
                    }
                }
            }
            return Optional<ICanvasWidget>.Empty();
        }

        void IPanelWidget.RemoveWidget(ICanvasWidget canvasWidget)
        {
            this.InternalRemoveWidget(canvasWidget);
        }

        void IPanelWidget.RemoveWidgets(ICollection<ICanvasWidget> canvasWidgets)
        {
            foreach (ICanvasWidget canvasWidget in canvasWidgets)
            {
                this.InternalRemoveWidget(canvasWidget);
            }
        }

        protected ICanvasWidget BuildBackground()
        {
            return ImageWidgetImpl.Builder.Get()
                .SetAlpha(1f)
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
                .SetName(this.GetType().Name + ":Background")
                .Build();
        }

        protected abstract void InitialBuild();

        protected void InternalAddWidget(ICanvasWidget canvasWidget)
        {
            logger.Info("Adding {}...", canvasWidget.GetName());
            canvasWidget.SetParent(this);
            CanvasWidgetUtils.AddWidget(this.canvasGridConvertor, this.canvasLevelWidgets, canvasWidget);
        }

        protected void InternalAddWidgets(ICollection<ICanvasWidget> canvasWidgets)
        {
            logger.Info("Adding {} {}s...", canvasWidgets.Count, typeof(ICanvasWidget).Name);
            foreach (ICanvasWidget canvasWidget in canvasWidgets)
            {
                this.InternalAddWidget(canvasWidget);
            }
        }

        protected IButtonPanelWidget BuildButton(string widgetName, IWidgetGridSpec widgetGridSpec, string buttonText, int canvasLevel)
        {
            IButtonPanelWidget buttonPanelWidget = (IButtonPanelWidget)ButtonPanelImpl.Builder.Get()
                .SetButtonText(buttonText)
                .SetPanelGridSize(Vector2.One)
                .SetWidgetGridSpec(widgetGridSpec)
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(canvasLevel)
                .SetInteractable(true)
                .SetEnabled(true)
                .SetName(widgetName)
                .SetParent(this)
                .Build();
            return buttonPanelWidget;
        }

        protected IButtonPanelWidget BuildButton(string widgetName, IWidgetGridSpec widgetGridSpec, string buttonText)
        {
            return this.BuildButton(widgetName, widgetGridSpec, buttonText, 0);
        }

        protected IMultiTextPanelWidget BuildMultiText(string widgetName, IWidgetGridSpec widgetGridSpec,
            IList<TextImageWidgetStruct> textImageWidgetStructs, bool interactable)
        {
            Vector2 panelGridSize = new Vector2(textImageWidgetStructs.Count, 1);
            IDictionary<int, TextImageWidgetStruct> indexTextImageWidgetStructs = new Dictionary<int, TextImageWidgetStruct>();
            for (int i = 0; i < textImageWidgetStructs.Count; ++i)
            {
                indexTextImageWidgetStructs.Add(i, textImageWidgetStructs[i]);
            }
            return (IMultiTextPanelWidget)MultiTextPanelImpl.Builder.Get()
                .SetTextImageWidgetStructs(indexTextImageWidgetStructs)
                .SetBackgroundColor(WidgetConstants.PRIMARY_COLOR_ID)
                .SetPanelGridSize(panelGridSize)
                .SetWidgetGridSpec(widgetGridSpec)
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(1)
                .SetInteractable(interactable)
                .SetEnabled(true)
                .SetName(widgetName)
                .SetParent(this)
                .Build();
        }

        protected void InternalRemoveWidget(ICanvasWidget canvasWidget)
        {
            logger.Info("Removing {}...", canvasWidget.GetName());
            canvasWidget.SetParent(this);
            CanvasWidgetUtils.RemoveWidget(this.canvasLevelWidgets, canvasWidget);
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