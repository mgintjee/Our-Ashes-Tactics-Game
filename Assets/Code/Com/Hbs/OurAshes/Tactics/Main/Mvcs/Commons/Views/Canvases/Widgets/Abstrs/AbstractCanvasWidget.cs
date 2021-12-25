using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Builders.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Convertors.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Scripts.Canvases.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Specs.Grids.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Specs.Grids.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Specs.Worlds.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Specs.Worlds.Inters;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Abstrs
{
    /// <summary>
    /// Abstract Canvas Widget
    /// </summary>
    public abstract class AbstractCanvasWidget
        : AbstractCanvasScript, ICanvasWidget
    {
        // Todo
        protected IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl();

        // Todo
        protected IWidgetWorldSpec widgetWorldSpec = new WidgetWorldSpecImpl();

        // Todo
        protected bool interactable;

        // Todo
        protected int canvasLevel;

        // Todo
        protected IMvcViewCanvas mvcViewCanvas;

        /// <inheritdoc/>
        bool ICanvasWidget.IsInputOnWidget(IMvcControlInput mvcControlInput)
        {
            switch (mvcControlInput.GetMvcControlInputType())
            {
                case MvcControlInputType.Click:
                    Vector2 clickPixelCoords = ((IMvcControlInputClick)mvcControlInput).GetWorldCoords();
                    Vector2 canvasWorldSize = this.mvcViewCanvas.GetWorldSize();
                    Vector2 clickWorldCoords = new Vector2(
                        clickPixelCoords.X - canvasWorldSize.X / 2,
                        clickPixelCoords.Y - canvasWorldSize.Y / 2);
                    Vector2 widgetWorldCoords = this.widgetWorldSpec.GetWorldCoords();
                    Vector2 widgetWorldSize = this.widgetWorldSpec.GetWorldSize();
                    Vector2 widgetWorldComps = new Vector2(widgetWorldCoords.X - widgetWorldSize.X / 2,
                        widgetWorldCoords.Y - widgetWorldSize.Y / 2);
                    return clickWorldCoords.X >= widgetWorldComps.X && clickWorldCoords.X <= widgetWorldComps.X &&
                        clickWorldCoords.Y >= widgetWorldComps.Y && clickWorldCoords.Y <= widgetWorldComps.Y;

                default:
                    return false;
            }
        }

        /// <inheritdoc/>
        IWidgetGridSpec ICanvasWidget.GetWidgetGridSpec()
        {
            return this.widgetGridSpec;
        }

        /// <inheritdoc/>
        IWidgetWorldSpec ICanvasWidget.GetWidgetWorldSpec()
        {
            return this.widgetWorldSpec;
        }

        /// <inheritdoc/>
        bool ICanvasWidget.GetInteractable()
        {
            return this.interactable;
        }

        /// <inheritdoc/>
        int ICanvasWidget.GetCanvasLevel()
        {
            return this.canvasLevel;
        }

        /// <inheritdoc/>
        void ICanvasWidget.SetWidgetGridSpec(IWidgetGridSpec widgetGridSpec)
        {
            this.widgetGridSpec = widgetGridSpec;
        }

        /// <inheritdoc/>
        void ICanvasWidget.SetInteractable(bool interactable)
        {
            this.interactable = interactable;
        }

        /// <inheritdoc/>
        void ICanvasWidget.SetCanvasLevel(int canvasLevel)
        {
            this.canvasLevel = canvasLevel;
        }

        /// <inheritdoc/>
        void ICanvasWidget.ApplyGridConvertor(ICanvasGridConvertor canvasGridConvertor)
        {
            Vector2 worldSize = canvasGridConvertor.GetWorldSize(this.widgetGridSpec.GetGridSize());
            Vector2 worldCoords = canvasGridConvertor.GetWorldCoords(
                this.widgetGridSpec.GetGridCoords(), this.widgetGridSpec.GetGridSize());
            ((WidgetWorldSpecImpl)this.widgetWorldSpec)
                .SetCanvasWorldCoords(worldCoords)
                .SetCanvasWorldSize(worldSize);
            this.GetRectTransform().sizeDelta = new UnityEngine.Vector2(worldSize.X, worldSize.Y);
            this.GetRectTransform().anchoredPosition = new UnityEngine.Vector2(worldCoords.X, worldCoords.Y);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class AbstractWidgetBuilders
        {
            /// <summary>
            /// Widget Builder class Interface
            /// </summary>
            public interface IWidgetBuilder<T>
                : IScriptBuilder<T>
            {
                IWidgetBuilder<T> SetWidgetGridSpec(IWidgetGridSpec widgetGridSpec);

                IWidgetBuilder<T> SetInteractable(bool interactable);

                IWidgetBuilder<T> SetCanvasLevel(int canvasLevel);

                IWidgetBuilder<T> SetMvcViewCanvas(IMvcViewCanvas mvcViewCanvas);
            }

            /// <summary>
            /// Abstract Widget Builder Impl
            /// </summary>
            public abstract class AbstractWidgetBuilder<T>
                : AbstractCanvasBuilders.AbstractCanvasBuilder<T>, IWidgetBuilder<T>
            {
                // Todo
                protected IWidgetGridSpec widgetGridSpec;

                // Todo
                protected bool interactable;

                // Todo
                protected int canvasLevel;

                // Todo
                protected IMvcViewCanvas mvcViewCanvas;

                IWidgetBuilder<T> IWidgetBuilder<T>.SetWidgetGridSpec(IWidgetGridSpec widgetGridSpec)
                {
                    this.widgetGridSpec = widgetGridSpec;
                    return this;
                }

                IWidgetBuilder<T> IWidgetBuilder<T>.SetInteractable(bool interactable)
                {
                    this.interactable = interactable;
                    return this;
                }

                IWidgetBuilder<T> IWidgetBuilder<T>.SetCanvasLevel(int canvasLevel)
                {
                    this.canvasLevel = canvasLevel;
                    return this;
                }

                IWidgetBuilder<T> IWidgetBuilder<T>.SetMvcViewCanvas(IMvcViewCanvas mvcViewCanvas)
                {
                    this.mvcViewCanvas = mvcViewCanvas;
                    return this;
                }

                protected override void ValidateScriptBuilder(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, this.widgetGridSpec);
                    if (this.widgetGridSpec != null)
                    {
                        this.Validate(invalidReasons, this.widgetGridSpec.GetGridCoords());
                        this.Validate(invalidReasons, this.widgetGridSpec.GetGridSize());
                    }
                    this.Validate(invalidReasons, this.interactable);
                    this.Validate(invalidReasons, this.canvasLevel);
                    this.Validate(invalidReasons, this.mvcViewCanvas);
                    this.ValidateWidgetBuilder(invalidReasons);
                }

                protected virtual void ValidateWidgetBuilder(ISet<string> invalidReasons)
                {
                }

                protected void ApplyCommonValues(ICanvasWidget canvasWidget)
                {
                    this.ApplyScriptValues(canvasWidget);
                    canvasWidget.SetWidgetGridSpec(this.widgetGridSpec);
                    canvasWidget.SetInteractable(this.interactable);
                    canvasWidget.SetCanvasLevel(this.canvasLevel);
                }
            }
        }
    }
}