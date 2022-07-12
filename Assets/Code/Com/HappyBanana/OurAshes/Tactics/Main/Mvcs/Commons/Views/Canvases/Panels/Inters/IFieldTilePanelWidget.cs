using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using System.Numerics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters
{
    public interface IFieldTilePanelWidget
        : IPanelWidget
    {
        Vector3 GetCoords();

        IImageWidget GetBackgroundImage();

        IImageWidget GetMidgroundImage();

        IImageWidget GetForegroundImage();
    }
}