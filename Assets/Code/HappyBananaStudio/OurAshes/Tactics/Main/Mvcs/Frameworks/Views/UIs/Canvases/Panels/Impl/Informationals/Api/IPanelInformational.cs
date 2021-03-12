namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Panels.Impl.Informationals.Api
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Orders.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Panels.Api;

    /// <summary>
    /// Todo
    /// </summary>
    public interface IPanelInformational
        : IPanel
    {
        /// <summary>
        /// Todo
        /// </summary>
        void BuildInformationalWidget(ITalonOrderReport talonOrderReport);

        /// <summary>
        /// Todo
        /// </summary>
        void LoadDefaultPanelEntry();
    }
}