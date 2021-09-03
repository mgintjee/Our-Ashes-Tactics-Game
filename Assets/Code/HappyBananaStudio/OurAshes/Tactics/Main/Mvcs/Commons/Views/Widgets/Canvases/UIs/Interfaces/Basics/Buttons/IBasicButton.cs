using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Canvases.UIs.Interfaces.Basics.Buttons
{
    /// <summary>
    /// Basic Widget Image Interface
    /// </summary>
    public interface IBasicButton : IWidget
    {
        void OnPress();

        void OnRelease();
    }
}