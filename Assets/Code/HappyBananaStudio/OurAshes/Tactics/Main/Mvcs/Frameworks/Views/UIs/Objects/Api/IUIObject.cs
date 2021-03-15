using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Common.Orders.Reports.Api;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Objects.Api
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IUIObject
    {
        /// <summary>
        /// Todo
        /// </summary>
        void UpdateCanvas();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonOrderReport"></param>
        void DisplayTalonOrderReport(ITalonOrderReport talonOrderReport);
    }
}