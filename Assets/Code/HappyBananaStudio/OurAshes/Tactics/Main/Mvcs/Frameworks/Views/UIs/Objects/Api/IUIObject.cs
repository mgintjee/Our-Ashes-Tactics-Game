namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Objects.Api
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Orders.Reports.Api;

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