using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters
{
    /// <summary>
    /// Icon Widget Interface
    /// </summary>
    public interface IIconWidget : IPanelWidget
    {
        IImageWidget GetPrimaryImage();

        IImageWidget GetSecondaryImage();

        IImageWidget GetTertiaryImage();
    }
}