namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Interfaces.Basics
{
    /// <summary>
    /// Button Widget Interface
    /// </summary>
    public interface IButtonWidget : IWidget
    {
        void SetOnPress(System.Action onPressAction);
    }
}