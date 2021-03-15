using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Panels.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Common.Orders.Reports.Api;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Panels.Impl.Informationals.Api
{
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