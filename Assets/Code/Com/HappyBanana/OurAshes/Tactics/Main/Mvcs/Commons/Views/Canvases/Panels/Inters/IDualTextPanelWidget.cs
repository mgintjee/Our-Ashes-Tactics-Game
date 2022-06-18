using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters
{
    /// <summary>
    /// TextEntry Panel Widget Interface
    /// </summary>
    public interface IDualTextPanelWidget
        : IPanelWidget
    {
        IImageWidget GetBackImageWidget();

        IImageWidget GetLeftImageWidget();

        IImageWidget GetRightImageWidget();

        ITextWidget GetLeftTextWidget();

        ITextWidget GetRightTextWidget();
    }
}