using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Apis.Optionals;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters
{
    public interface IMultiTextPanelWidget
        : IPanelWidget
    {
        int GetMaxIndex();

        IImageWidget GetBackImageWidget();

        IOptional<ITextWidget> GetTextWidget(int index);

        IOptional<IImageWidget> GetImageWidget(int index);
    }
}