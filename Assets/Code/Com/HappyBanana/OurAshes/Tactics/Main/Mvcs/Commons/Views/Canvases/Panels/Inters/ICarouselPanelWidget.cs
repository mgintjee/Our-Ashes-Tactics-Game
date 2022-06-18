using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters
{
    public interface ICarouselPanelWidget
        : IPanelWidget
    {
        IMultiTextPanelWidget GetHeader();

        IMultiTextPanelWidget GetSpinner();

        IMultiTextPanelWidget GetButtons();

        void UpdateSpinnerText(int index, IList<string> strings);
    }
}