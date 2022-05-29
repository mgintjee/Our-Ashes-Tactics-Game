using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters
{
    public interface IMultiTextPanelWidget
        : IPanelWidget
    {
        int GetMaxIndex();

        IImageWidget GetBackImageWidget();

        Optional<ITextWidget> GetTextWidget(int index);

        Optional<IImageWidget> GetImageWidget(int index);
    }
}