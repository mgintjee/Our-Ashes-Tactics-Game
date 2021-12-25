using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Convertors.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Scripts.Canvases.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Specs.Grids.Inters;
using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Convertors.Utils
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class CanvasGridConvertorUtil
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="canvasWidget">       </param>
        /// <param name="canvasGridConvertor"></param>
        /// <param name="gridSize">           </param>
        /// <param name="gridCoords">         </param>
        public static void ApplyCanvasGridMeasurements(ICanvasWidget canvasWidget,
            ICanvasGridConvertor canvasGridConvertor, Vector2 gridSize, Vector2 gridCoords)
        {
            /*
            ICanvasWidgetSpec canvasWidgetSpec = canvasWidget.GetCanvasWidgetSpec();
            CanvasWidgetSpecImpl newCanvasWidgetSpec = new CanvasWidgetSpecImpl();
            newCanvasWidgetSpec.SetCanvasGridCoords(gridCoords);
            newCanvasWidgetSpec.SetCanvasGridSize(gridSize);
            newCanvasWidgetSpec.SetCanvasLevel(canvasWidgetSpec.GetLevel());
            newCanvasWidgetSpec.SetInteractable(canvasWidgetSpec.GetInteractable());
            newCanvasWidgetSpec.SetCanvasWorldCoords(canvasGridConvertor.GetWorldCoords(gridCoords, gridSize));
            newCanvasWidgetSpec.SetCanvasWorldSize(canvasGridConvertor.GetWorldSize(gridSize));
            canvasWidget.SetCanvasWidgetSpec(newCanvasWidgetSpec);
            */
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="canvasScript">  </param>
        /// <param name="gridConvertor"> </param>
        /// <param name="widgetGridSpec"></param>
        private static void ApplyCanvasGridMeasurements(ICanvasScript canvasScript,
            ICanvasGridConvertor gridConvertor, IWidgetGridSpec widgetGridSpec)
        {
            /*
            // Find the WorldDimensions for this canvasScript
            Vector2 worldDimensions = gridConvertor.GetWorldSize(
                canvasWidgetSpec.GetCanvasGridCoords());
            UnityEngine.RectTransform rectTransform = canvasScript.GetRectTransform();
            float maxDimension = Math.Max(gridConvertor.GetWorldSize().X, gridConvertor.GetWorldSize().Y);
            // Apply some offsets
            worldDimensions.X -= maxDimension * 0.005f;
            worldDimensions.Y -= maxDimension * 0.005f;
            // Set the WorldDimensions for this canvasScript
            rectTransform.sizeDelta = new UnityEngine.Vector2(worldDimensions.X, worldDimensions.Y);
            // Set the WorldPosition of this canvasScript
            rectTransform.anchoredPosition = gridConvertor.GetWorldCoords(
                    canvasWidgetSpec.GetCanvasGridCoords(), canvasWidgetSpec.GetCanvasGridSize());
            */
        }
    }
}