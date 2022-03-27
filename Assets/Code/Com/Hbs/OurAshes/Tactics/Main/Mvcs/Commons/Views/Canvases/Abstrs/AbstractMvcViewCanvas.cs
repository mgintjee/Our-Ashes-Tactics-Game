using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Classes.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Convertors.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Convertors.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Constants;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Scripts.Canvases.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Scripts.Canvases.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Sprites.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Utils;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Types;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Abstrs
{
    /// <summary>
    /// Mvc View Canvas Interface
    /// </summary>
    public abstract class AbstractMvcViewCanvas
        : AbstractCanvasScript, IMvcViewCanvas
    {
        // Todo
        protected ICanvasScript mvcViewCanvasScript;

        // Todo
        protected IDictionary<int, ISet<ICanvasWidget>> canvasLevelWidgets = new Dictionary<int, ISet<ICanvasWidget>>();

        // Todo
        protected ICanvasGridConvertor canvasGridConvertor;

        // Todo
        protected Vector2 worldGridSize;

        // Todo
        protected IClassLogger logger;

        // Todo
        protected MvcType mvcType;

        public void SetGridSize(Vector2 gridSize)
        {
            this.worldGridSize = gridSize;
            Vector2 worldSize = new Vector2(this.GetRectTransform().sizeDelta.x,
                this.GetRectTransform().sizeDelta.y);
            this.canvasGridConvertor = new CanvasGridConvertorImpl(gridSize, worldSize);
        }

        public void Process(IMvcModelState mvcModelState)
        {
            foreach (ICollection<ICanvasWidget> canvasWidgets in this.canvasLevelWidgets.Values)
            {
                foreach (ICanvasWidget canvasWidget in canvasWidgets)
                {
                    canvasWidget.Process(mvcModelState);
                }
            }
        }

        public abstract void InitialBuild();

        /// <inheritdoc/>
        Optional<ICanvasWidget> IMvcViewCanvas.GetWidget(IMvcControlInput mvcControlInput)
        {
            List<int> canvasLevels = new List<int>(canvasLevelWidgets.Keys);
            canvasLevels.Sort();
            foreach (int canvasLevel in canvasLevels)
            {
                foreach (ICanvasWidget canvasWidget in canvasLevelWidgets[canvasLevel])
                {
                    logger.Debug("Checking if input is on W: {}", canvasWidget.GetName());
                    if (canvasWidget is IPanelWidget panelWidget)
                    {
                        Optional<ICanvasWidget> returnedWidget = panelWidget.GetWidgetFromInput(
                            this.canvasGridConvertor, mvcControlInput);
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
                    logger.Debug("Input is not on W: {}", canvasWidget.GetName());
                }
            }
            return Optional<ICanvasWidget>.Empty();
        }

        /// <inheritdoc/>
        Vector2 IMvcViewCanvas.GetWorldSize()
        {
            return this.canvasGridConvertor.GetWorldSize();
        }

        protected ICanvasWidget BuildBackground()
        {
            return ImageWidgetImpl.Builder.Get()
                .SetSpriteID(SpriteID.SquareBordered)
                .SetColorID(ColorID.DodgerBlue)
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(0)
                .SetMvcType(this.mvcType)
                .SetInteractable(false)
                .SetEnabled(true)
                .SetWidgetGridSpec(new WidgetGridSpecImpl()
                    .SetCanvasGridSize(new Vector2(
                        this.canvasGridConvertor.GetGridSize().X,
                        this.canvasGridConvertor.GetGridSize().Y * (1 - PanelWidgetConstants.GetBannerPanelRatio())))
                    .SetCanvasGridCoords(Vector2.Zero))
                .SetParent(this)
                .SetName(this.mvcType + ":Background:" + CanvasWidgetType.Image)
                .Build();
        }

        protected IPanelWidget BuildBanner()
        {
            return BannerPanelImpl.Builder.Get()
                .SetText(this.mvcType.ToString())
                .SetPanelGridSize(new Vector2(2, 1))
                .SetWidgetGridSpec(new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(0, this.canvasGridConvertor.GetGridSize().Y * (1 - PanelWidgetConstants.GetBannerPanelRatio())))
                    .SetCanvasGridSize(new Vector2(this.canvasGridConvertor.GetGridSize().X,
                        this.canvasGridConvertor.GetGridSize().Y * PanelWidgetConstants.GetBannerPanelRatio())))
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(0)
                .SetInteractable(false)
                .SetEnabled(true)
                .SetName(this.mvcType + ":Header:" + CanvasWidgetType.Panel)
                .SetParent(this)
                .Build();
        }

        protected virtual void ProcessSelectedWidget(ICanvasWidget canvasWidget)
        {
        }

        protected void AddWidget(ICanvasWidget canvasWidget)
        {
            logger.Info("Adding {}:{}", canvasWidget.GetType(), canvasWidget.GetName());
            canvasWidget.SetParent(this);
            CanvasWidgetUtils.AddWidget(this.canvasGridConvertor, this.canvasLevelWidgets, canvasWidget);
        }

        protected void AddWidgets(ICollection<ICanvasWidget> widgets)
        {
            foreach (ICanvasWidget canvasWidget in widgets)
            {
                this.AddWidget(canvasWidget);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class AbstractViewCanvasBuilders
        {
            /// <summary>
            /// Todo
            /// </summary>
            public interface IViewCanvasBuilder
                : AbstractCanvasBuilders.ICanvasBuilder<IMvcViewCanvas>
            {
                IViewCanvasBuilder SetMvcType(MvcType mvcType);
            }

            /// <summary>
            /// Todo
            /// </summary>
            public abstract class AbstractViewCanvasBuilder
                : AbstractCanvasBuilders.AbstractCanvasBuilder<IMvcViewCanvas>, IViewCanvasBuilder
            {
                private MvcType mvcType;

                /// <inheritdoc/>
                IViewCanvasBuilder IViewCanvasBuilder.SetMvcType(MvcType mvcType)
                {
                    this.mvcType = mvcType;
                    return this;
                }

                protected void ApplyMvcViewValues(IMvcViewCanvas mvcViewCanvas)
                {
                    ((AbstractMvcViewCanvas)mvcViewCanvas).mvcType = this.mvcType;
                    ((AbstractMvcViewCanvas)mvcViewCanvas).logger = LoggerManager.GetLogger(this.mvcType)
                        .GetClassLogger(mvcViewCanvas.GetType());
                    this.ApplyCanvasValues((AbstractMvcViewCanvas)mvcViewCanvas);
                }
            }
        }
    }
}