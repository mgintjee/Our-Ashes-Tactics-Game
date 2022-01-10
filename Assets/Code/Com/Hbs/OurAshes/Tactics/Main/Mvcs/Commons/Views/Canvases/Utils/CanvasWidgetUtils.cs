using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Convertors.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Utils
{
    /// <summary>
    /// Todo
    /// </summary>
    public class CanvasWidgetUtils
    {
        public static void AddWidget(ICanvasGridConvertor canvasGridConvertor,
            IDictionary<int, ISet<ICanvasWidget>> canvasLevelWidgets, ICanvasWidget widget)
        {
            if (!canvasLevelWidgets.ContainsKey(widget.GetCanvasLevel()))
            {
                canvasLevelWidgets[widget.GetCanvasLevel()] = new HashSet<ICanvasWidget>();
            }
            canvasLevelWidgets[widget.GetCanvasLevel()].Add(widget);
            widget.ApplyGridConvertor(canvasGridConvertor);
        }

        public static bool IsInputOnWidget(ICanvasGridConvertor canvasGridConvertor,
            IMvcControlInput mvcControlInput, ICanvasWidget canvasWidget)
        {
            switch (mvcControlInput.GetMvcControlInputType())
            {
                case MvcControlInputType.Click:
                    Vector2 clickPixelCoords = ((IMvcControlInputClick)mvcControlInput).GetWorldCoords();
                    Vector2 canvasWorldSize = canvasGridConvertor.GetWorldSize();
                    Vector2 clickWorldCoords = new Vector2(clickPixelCoords.X - canvasWorldSize.X / 2,
                        clickPixelCoords.Y - canvasWorldSize.Y / 2);
                    Vector2 widgetWorldCoords = canvasWidget.GetWidgetWorldSpec().GetWorldCoords();
                    Vector2 widgetWorldSize = canvasWidget.GetWidgetWorldSpec().GetWorldSize();
                    return clickWorldCoords.X >= widgetWorldCoords.X - widgetWorldSize.X / 2 &&
                        clickWorldCoords.X <= widgetWorldCoords.X + widgetWorldSize.X / 2 &&
                        clickWorldCoords.Y >= widgetWorldCoords.Y - widgetWorldSize.Y / 2 &&
                        clickWorldCoords.Y <= widgetWorldCoords.Y + widgetWorldSize.Y / 2;

                default:
                    return false;
            }
        }

        public static Optional<ICanvasWidget> GetWidgetFromInput(ICanvasGridConvertor canvasGridConvertor,
            IDictionary<int, ISet<ICanvasWidget>> canvasLevelWidgets, IMvcControlInput mvcControlInput)
        {
            List<int> canvasLevels = new List<int>(canvasLevelWidgets.Keys);
            canvasLevels.Sort();
            foreach (int canvasLevel in canvasLevels)
            {
                foreach (ICanvasWidget canvasWidget in canvasLevelWidgets[canvasLevel])
                {
                    if (canvasWidget.GetEnabled() && canvasWidget.GetInteractable() &&
                        IsInputOnWidget(canvasGridConvertor, mvcControlInput, canvasWidget))
                    {
                        return Optional<ICanvasWidget>.Of(canvasWidget);
                    }
                }
            }
            return Optional<ICanvasWidget>.Empty();
        }

        public static void EnableWidgets(ICollection<ICanvasWidget> canvasWidgets, bool enable)
        {
            foreach(ICanvasWidget canvasWidget in canvasWidgets)
            {
                canvasWidget.SetEnabled(enable);
            }
        }

        public static void SetButtonInteractable(IImageWidget imageWidget, bool interactable)
        {
            imageWidget.SetInteractable(interactable);
            if (interactable)
            {
                imageWidget.SetColorID(ColorID.Red);
            }
            else
            {
                imageWidget.SetColorID(ColorID.Gray);
            }
        }
    }
}