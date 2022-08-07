namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters
{
    /// <summary>
    /// PopUp Widget Interface
    /// </summary>
    public interface IPopUpPanelWidget
        : IPanelWidget
    {
        void UpdatePopupEntry(IPanelWidget panelWidget);
    }
}