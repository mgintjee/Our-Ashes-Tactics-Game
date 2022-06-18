using System.Numerics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters
{
    public interface IFieldTilePanelWidget
        : IPanelWidget
    {
        Vector2 GetCoords();
    }
}