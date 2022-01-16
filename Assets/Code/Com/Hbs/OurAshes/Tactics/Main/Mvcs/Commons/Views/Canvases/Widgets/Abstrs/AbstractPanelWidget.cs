using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Convertors.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Convertors.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Sprites.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Utils;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Types;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Abstrs
{
    /// <summary>
    /// Panel Widget Impl
    /// </summary>
    public abstract class AbstractPanelWidget
        : AbstractCanvasWidget, IPanelWidget
    {
        protected MvcType mvcType;
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

        Optional<ICanvasWidget> IPanelWidget.GetWidgetFromInput(IMvcControlInput mvcControlInput)
        {
            Optional<ICanvasWidget> canvasWidget = CanvasWidgetUtils.GetWidgetFromInput(this.canvasGridConvertor,
                this.canvasLevelWidgets, mvcControlInput);
            //canvasWidget.IfPresent(widget => this.ProcessSelectedWidget(widget));
            return canvasWidget;
        }

        protected ICanvasWidget BuildBackground()
        {
            return ImageWidgetImpl.Builder.Get()
                .SetSpriteID(SpriteID.SquareBordered)
                .SetColorID(ColorID.Blue)
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(0)
                .SetInteractable(false)
                .SetEnabled(true)
                .SetWidgetGridSpec(new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(Vector2.Zero)
                    .SetCanvasGridSize(this.canvasGridConvertor.GetGridSize()))
                .SetParent(this)
                .SetName(this.mvcType + ":Background:" + CanvasWidgetType.Image)
                .Build();
        }

        protected abstract void InitialBuild();

        protected void InternalAddWidget(ICanvasWidget canvasWidget)
        {
            canvasWidget.SetParent(this);
            CanvasWidgetUtils.AddWidget(this.canvasGridConvertor, this.canvasLevelWidgets, canvasWidget);
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