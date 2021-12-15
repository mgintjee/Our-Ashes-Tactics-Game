using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Inters;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Collections.Inters
{
    /// <summary>
    /// Mvc View Canvas Widget Collection Interface
    /// </summary>
    public interface IWidgetCollection
    {
        void Clear();

        void AddWidget(IWidget widget);

        void RemoveWidget(IWidget widget);
    }
}