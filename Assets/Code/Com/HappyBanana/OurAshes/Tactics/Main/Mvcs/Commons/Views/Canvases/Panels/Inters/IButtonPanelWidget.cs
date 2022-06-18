using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters
{
    /// <summary>
    /// Button Widget Interface
    /// </summary>
    public interface IButtonPanelWidget
        : IPanelWidget
    {
        IImageWidget GetImageWidget();

        ITextWidget GetTextWidget();
    }
}