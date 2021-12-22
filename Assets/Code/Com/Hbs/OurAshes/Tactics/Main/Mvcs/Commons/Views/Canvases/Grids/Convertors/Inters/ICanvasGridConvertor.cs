using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Convertors.Inters
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface ICanvasGridConvertor
    {
        Vector2 GetGridSize();

        Vector2 GetWorldSize();

        Vector2 GetWorldSize(Vector2 gridDimensions);

        Vector2 GetWorldCoords(Vector2 gridCoords, Vector2 gridSize);
    }
}