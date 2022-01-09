using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Classes.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Convertors.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Convertors.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Scripts.Canvases.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Scripts.Canvases.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Utils;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
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

        /// <inheritdoc/>
        void IMvcViewCanvas.Build()
        {
            logger.Info("Building associated widgets within gridSize: {}",
                this.canvasGridConvertor.GetGridSize());
            ((IMvcViewCanvas)this).Clear();
            foreach (ICanvasWidget canvasWidget in this.InternalBuild())
            {
                this.AddWidget(canvasWidget);
            }
        }

        /// <inheritdoc/>
        void IMvcViewCanvas.Clear()
        {
            foreach (int canvasLevel in this.canvasLevelWidgets.Keys)
            {
                foreach (ICanvasWidget canvasWidget in this.canvasLevelWidgets[canvasLevel])
                {
                    canvasWidget.Destroy();
                }
            }
            this.canvasLevelWidgets.Clear();
        }

        /// <inheritdoc/>
        void IMvcViewCanvas.Process(IMvcModelState mvcModelState)
        {
        }

        /// <inheritdoc/>
        Optional<ICanvasWidget> IMvcViewCanvas.GetWidget(IMvcControlInput mvcControlInput)
        {
            Optional<ICanvasWidget> canvasWidget = CanvasWidgetUtils.GetWidgetFromInput(this.canvasGridConvertor,
                this.canvasLevelWidgets, mvcControlInput);
            canvasWidget.IfPresent(widget => this.ProcessSelectedWidget(widget));
            return canvasWidget;
        }

        /// <inheritdoc/>
        Vector2 IMvcViewCanvas.GetWorldSize()
        {
            return this.canvasGridConvertor.GetWorldSize();
        }

        protected virtual void ProcessSelectedWidget(ICanvasWidget canvasWidget)
        {
        }

        protected void AddWidget(ICanvasWidget widget)
        {
            logger.Info("Adding {}:{}", widget.GetType(), widget.GetName());
            CanvasWidgetUtils.AddWidget(this.canvasGridConvertor, this.canvasLevelWidgets, widget);
        }

        protected abstract ISet<ICanvasWidget> InternalBuild();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcControlInput"></param>
        /// <param name="canvasWidget">   </param>
        /// <returns></returns>
        private bool IsInputOnWidget(IMvcControlInput mvcControlInput, ICanvasWidget canvasWidget)
        {
            switch (mvcControlInput.GetMvcControlInputType())
            {
                case MvcControlInputType.Click:
                    Vector2 clickPixelCoords = ((IMvcControlInputClick)mvcControlInput).GetWorldCoords();
                    Vector2 canvasWorldSize = this.canvasGridConvertor.GetWorldSize();
                    Vector2 clickWorldCoords = new Vector2(clickPixelCoords.X - canvasWorldSize.X / 2,
                        clickPixelCoords.Y - canvasWorldSize.Y / 2);
                    Vector2 widgetWorldCoords = canvasWidget.GetWidgetWorldSpec().GetWorldCoords();
                    Vector2 widgetWorldSize = canvasWidget.GetWidgetWorldSpec().GetWorldSize();
                    logger.Debug("Checking Input location on {} : " +
                        "\nC-PixelCoords: {}, C-WorldCoords: {}, " +
                        "\nW-WorldCoords: {}, W-WorldSize: {}",
                        canvasWidget.GetName(), clickPixelCoords, clickWorldCoords,
                        widgetWorldCoords, widgetWorldSize);
                    return clickWorldCoords.X >= widgetWorldCoords.X - widgetWorldSize.X / 2 &&
                        clickWorldCoords.X <= widgetWorldCoords.X + widgetWorldSize.X / 2 &&
                        clickWorldCoords.Y >= widgetWorldCoords.Y - widgetWorldSize.Y / 2 &&
                        clickWorldCoords.Y <= widgetWorldCoords.Y + widgetWorldSize.Y / 2;

                default:
                    return false;
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