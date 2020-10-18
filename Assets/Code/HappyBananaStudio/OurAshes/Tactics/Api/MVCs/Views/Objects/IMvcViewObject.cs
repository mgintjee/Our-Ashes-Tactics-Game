
namespace HappyBananaStudio.OurAshes.Tactics.Api.MVCs.Views.Objects
{
    using HappyBananaStudio.OurAshes.Tactics.Api.MVCs.GameActions.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Actions.Orders;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Information;
    using System.Collections.Generic;

    /// <summary>
    /// MvcView Object Api
    /// </summary>
    public interface IMvcViewObject
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonIdentificationReport">
        /// </param>
        void DestroyTalonCanvas(ITalonIdentificationReport talonIdentificationReport);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        bool IsInitialized();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="pathObject">
        /// </param>
        void AnimateActionOrderReport(ITalonActionOrderReport talonActionOrderReport);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        bool IsAnimating();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="gameActionReport">
        /// </param>
        void DisplayCombatReportPopUp(IGameActionReport gameActionReport);
        /// <summary>
        /// Todo
        /// </summary>
        void UpdateCanvas();
    }
}
