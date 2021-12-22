using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Specs.Inters
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface ICanvasWidgetSpec
    {
        int GetLevel();

        bool GetInteractable();

        Vector2 GetGridCoords();

        Vector2 GetGridSize();

        Vector2 GetWorldSize();

        Vector2 GetWorldCoords();
    }
}