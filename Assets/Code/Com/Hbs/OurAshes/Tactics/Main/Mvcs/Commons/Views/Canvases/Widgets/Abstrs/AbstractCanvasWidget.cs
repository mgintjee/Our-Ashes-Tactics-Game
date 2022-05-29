using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Classes.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Builders.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Convertors.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Scripts.Canvases.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Worlds.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Worlds.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Utils;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
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
        protected IClassLogger logger;

        // Todo
        protected string widgetName;

        // Todo
        protected IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl();

        // Todo
        protected IWidgetWorldSpec widgetWorldSpec = new WidgetWorldSpecImpl();

        // Todo
        protected bool isInteractable;

        // Todo
        protected int canvasLevel;

        // Todo
        protected bool isEnabled;

        // Todo
        protected IMvcViewCanvas mvcViewCanvas;

        // Todo
        protected MvcType mvcType;

        public virtual void Process(IMvcModelState mvcModelState)
        {
            // Do nothing
        }

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
            return this.isInteractable;
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
        void ICanvasWidget.SetEnabled(bool enabled)
        {
            this.isEnabled = enabled;
            this.gameObject.SetActive(enabled);
        }

        /// <inheritdoc/>
        void ICanvasWidget.SetInteractable(bool interactable)
        {
            this.isInteractable = interactable;
        }

        /// <inheritdoc/>
        void ICanvasWidget.SetCanvasLevel(int canvasLevel)
        {
            this.canvasLevel = canvasLevel;
        }

        /// <inheritdoc/>
        void ICanvasWidget.ApplyGridConvertor(ICanvasGridConvertor canvasGridConvertor)
        {
            this.logger.Debug("Applying {} to {}: Grid:{}, World: {}", canvasGridConvertor, this.widgetName, this.widgetGridSpec, this.widgetWorldSpec);
            CanvasWidgetUtils.ApplyGridConvertor(canvasGridConvertor, this);
        }

        bool ICanvasWidget.GetEnabled()
        {
            return this.isEnabled;
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

                IWidgetBuilder<T> SetEnabled(bool enabled);

                IWidgetBuilder<T> SetCanvasLevel(int canvasLevel);

                IWidgetBuilder<T> SetMvcType(MvcType mvcType);
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
                protected bool isInteractable;

                // Todo
                protected bool isEnabled;

                // Todo
                protected int canvasLevel;

                private MvcType mvcType;

                IWidgetBuilder<T> IWidgetBuilder<T>.SetWidgetGridSpec(IWidgetGridSpec widgetGridSpec)
                {
                    this.widgetGridSpec = widgetGridSpec;
                    return this;
                }

                IWidgetBuilder<T> IWidgetBuilder<T>.SetInteractable(bool interactable)
                {
                    this.isInteractable = interactable;
                    return this;
                }

                IWidgetBuilder<T> IWidgetBuilder<T>.SetCanvasLevel(int canvasLevel)
                {
                    this.canvasLevel = canvasLevel;
                    return this;
                }

                IWidgetBuilder<T> IWidgetBuilder<T>.SetEnabled(bool enabled)
                {
                    this.isEnabled = enabled;
                    return this;
                }

                IWidgetBuilder<T> IWidgetBuilder<T>.SetMvcType(MvcType mvcType)
                {
                    this.mvcType = mvcType;
                    return this;
                }

                protected override void ValidateScriptBuilder(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, this.mvcType);
                    this.Validate(invalidReasons, this.widgetGridSpec);
                    if (this.widgetGridSpec != null)
                    {
                        this.Validate(invalidReasons, this.widgetGridSpec.GetGridCoords());
                        this.Validate(invalidReasons, this.widgetGridSpec.GetGridSize());
                    }
                    this.Validate(invalidReasons, this.isInteractable);
                    this.Validate(invalidReasons, this.isEnabled);
                    this.Validate(invalidReasons, this.canvasLevel);
                    this.ValidateWidgetBuilder(invalidReasons);
                }

                protected virtual void ValidateWidgetBuilder(ISet<string> invalidReasons)
                {
                }

                protected void ApplyCommonValues(ICanvasWidget canvasWidget)
                {
                    ((AbstractCanvasWidget)canvasWidget).widgetName = this.name;
                    ((AbstractCanvasWidget)canvasWidget).logger = LoggerManager.GetLogger(this.mvcType)
                        .GetClassLogger(canvasWidget.GetType());
                    ((AbstractCanvasWidget)canvasWidget).mvcType = this.mvcType;
                    canvasWidget.GetRectTransform().anchorMin = new UnityEngine.Vector2(0.5f, 0.5f);
                    canvasWidget.GetRectTransform().anchorMax = new UnityEngine.Vector2(0.5f, 0.5f);
                    this.ApplyScriptValues(canvasWidget);
                    canvasWidget.SetWidgetGridSpec(this.widgetGridSpec);
                    canvasWidget.SetInteractable(this.isInteractable);
                    canvasWidget.SetCanvasLevel(this.canvasLevel);
                    canvasWidget.SetEnabled(this.isEnabled);
                }
            }
        }
    }
}