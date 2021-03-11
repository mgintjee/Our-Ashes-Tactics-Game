namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Panels.Api
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Unity.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Scripts.Unity.Api;

    /// <summary>
    /// CanvasUI Api
    /// </summary>
    public interface IPanel
        : ICanvasScript
    {
        /// <summary>
        /// Todo
        /// </summary>
        void UpdatePanelEntries();
    }
}