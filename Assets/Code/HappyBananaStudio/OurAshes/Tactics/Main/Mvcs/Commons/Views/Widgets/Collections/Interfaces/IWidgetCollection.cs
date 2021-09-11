namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Collections.Interfaces
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