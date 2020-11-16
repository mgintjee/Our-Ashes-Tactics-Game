
namespace HappyBananaStudio.OurAshes.Tactics.Api.MVCs.Views.Objects
{
    using HappyBananaStudio.OurAshes.Tactics.Api.MVCs.GameActions.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Actions.Orders;

    /// <summary>
    /// MvcView Object Api
    /// </summary>
    public interface IMvcViewObject
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="pathObject">
        /// </param>
        void AnimateActionOrderReport(ITalonActionOrderReport talonActionOrderReport);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="gameActionReport">
        /// </param>
        void DisplayCombatReportPopUp(IGameActionReport gameActionReport);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        bool IsAnimating();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        bool IsInitialized();

        /// <summary>
        /// Todo
        /// </summary>
        void UpdateCanvas();
    }
}
