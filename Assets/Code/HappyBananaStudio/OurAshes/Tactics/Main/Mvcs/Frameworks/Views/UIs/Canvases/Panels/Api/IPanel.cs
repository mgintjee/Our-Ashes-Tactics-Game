namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Panels.Api
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Scripts.Unity.Api;

    /// <summary>
    /// CanvasUI Api
    /// </summary>
    public interface IPanel
        : IUnityScript
    {
        /// <summary>
        /// Todo
        /// </summary>
        void UpdatePanelEntries();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ICanvasConfigurationReport GetCanvasConfigurationReport();
    }
}