namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Inters.Basics
{
    /// <summary>
    /// Button Widget Interface
    /// </summary>
    public interface IButtonWidget : IWidget
    {
        void SetOnPress(System.Action onPressAction);
    }
}