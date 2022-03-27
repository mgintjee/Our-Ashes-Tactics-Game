﻿using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Convertors.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Worlds.Impls;
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
        public static void ApplyGridConvertor(ICanvasGridConvertor canvasGridConvertor, ICanvasWidget canvasWidget)
        {
            IWidgetGridSpec widgetGridSpec = canvasWidget.GetWidgetGridSpec();
            Vector2 worldSize = canvasGridConvertor.GetWorldSize(widgetGridSpec.GetGridSize());
            Vector2 worldCoords = canvasGridConvertor.GetWorldCoords(
                widgetGridSpec.GetGridCoords(), widgetGridSpec.GetGridSize());
            ((WidgetWorldSpecImpl)canvasWidget.GetWidgetWorldSpec())
                .SetCanvasWorldCoords(worldCoords)
                .SetCanvasWorldSize(worldSize);
            canvasWidget.GetRectTransform().sizeDelta = new UnityEngine.Vector2(worldSize.X, worldSize.Y);
            canvasWidget.GetRectTransform().anchoredPosition = new UnityEngine.Vector2(worldCoords.X, worldCoords.Y);
        }

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

        public static bool IsInputOnWidget(IMvcControlInput mvcControlInput, ICanvasWidget canvasWidget)
        {
            switch (mvcControlInput.GetMvcControlInputType())
            {
                case MvcControlInputType.Click:
                    Vector2 clickPixelCoords = ((IMvcControlInputClick)mvcControlInput).GetWorldCoords();
                    Vector2 widgetWorldCoords = new Vector2(canvasWidget.GetRectTransform().transform.position.x,
                        canvasWidget.GetRectTransform().transform.position.y);//.GetWorldCoords();
                    Vector2 widgetWorldSize = canvasWidget.GetWidgetWorldSpec().GetWorldSize();
                    return clickPixelCoords.Y >= widgetWorldCoords.Y - widgetWorldSize.Y / 2 &&
                        clickPixelCoords.Y <= widgetWorldCoords.Y + widgetWorldSize.Y / 2 &&
                        clickPixelCoords.X >= widgetWorldCoords.X - widgetWorldSize.X / 2 &&
                        clickPixelCoords.X <= widgetWorldCoords.X + widgetWorldSize.X / 2;

                default:
                    return false;
            }
        }

        /*
        public static Optional<ICanvasWidget> GetWidgetFromInput(ICanvasGridConvertor canvasGridConvertor,
            IDictionary<int, ISet<ICanvasWidget>> canvasLevelWidgets, IMvcControlInput mvcControlInput)
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
                        IsInputOnWidget(canvasGridConvertor, mvcControlInput, canvasWidget))
                    {
                        return Optional<ICanvasWidget>.Of(canvasWidget);
                    }
                }
            }
            return Optional<ICanvasWidget>.Empty();
        }
        */

        public static void EnableWidgets(ICollection<ICanvasWidget> canvasWidgets, bool enable)
        {
            foreach (ICanvasWidget canvasWidget in canvasWidgets)
            {
                EnableWidget(canvasWidget, enable);
            }
        }

        public static void EnableWidget(ICanvasWidget canvasWidget, bool enable)
        {
            canvasWidget.SetEnabled(enable);
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