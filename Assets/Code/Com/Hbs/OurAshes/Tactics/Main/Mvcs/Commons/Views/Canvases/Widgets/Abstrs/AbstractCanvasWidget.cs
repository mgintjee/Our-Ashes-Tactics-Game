using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Scripts.Canvases.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Specs.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Specs.Inters;
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
        protected ICanvasWidgetSpec canvasWidgetSpec = new CanvasWidgetSpecImpl();

        /// <inheritdoc/>
        bool ICanvasWidget.IsInputOnWidget(IMvcControlInput mvcControlInput)
        {
            switch (mvcControlInput.GetMvcControlInputType())
            {
                case MvcControlInputType.Click:
                    Vector2 widgetWorldCoords = this.canvasWidgetSpec.GetWorldCoords();
                    Vector2 widgetWorldSize = this.canvasWidgetSpec.GetWorldSize();
                    Vector2 clickWorldCoords = ((IMvcControlInputClick)mvcControlInput).GetWorldCoords();
                    return true;

                default:
                    return false;
            }
        }

        /// <inheritdoc/>
        ICanvasWidgetSpec ICanvasWidget.GetCanvasWidgetSpec()
        {
            return this.canvasWidgetSpec;
        }

        /// <inheritdoc/>
        void ICanvasWidget.SetCanvasWidgetSpec(ICanvasWidgetSpec canvasWidgetSpec)
        {
            ((CanvasWidgetSpecImpl)this.canvasWidgetSpec)
                .SetCanvasGridCoords(canvasWidgetSpec.GetGridCoords())
                .SetCanvasGridSize(canvasWidgetSpec.GetGridSize())
                .SetCanvasWorldCoords(canvasWidgetSpec.GetWorldCoords())
                .SetCanvasWorldSize(canvasWidgetSpec.GetWorldCoords())
                .SetCanvasLevel(canvasWidgetSpec.GetLevel())
                .SetInteractable(canvasWidgetSpec.GetInteractable());
            this.UpdateWorldSpec(canvasWidgetSpec);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="canvasWidgetSpec"></param>
        private void UpdateWorldSpec(ICanvasWidgetSpec canvasWidgetSpec)
        {
            this.GetRectTransform().sizeDelta = new UnityEngine.Vector2(
                canvasWidgetSpec.GetWorldSize().X, canvasWidgetSpec.GetWorldSize().Y);
            this.GetRectTransform().anchoredPosition = new UnityEngine.Vector2(
                canvasWidgetSpec.GetWorldCoords().X, canvasWidgetSpec.GetWorldCoords().Y);
        }
    }
}