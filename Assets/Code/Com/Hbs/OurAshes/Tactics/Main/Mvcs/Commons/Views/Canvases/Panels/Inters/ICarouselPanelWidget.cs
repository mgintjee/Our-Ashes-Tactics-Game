using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters
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