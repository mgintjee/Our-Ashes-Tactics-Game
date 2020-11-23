namespace HappyBananaStudio.OurAshes.Tactics.Api.MVCs.Models.Objects
{
    using HappyBananaStudio.OurAshes.Tactics.Api.MVCs.GameActions.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Api.MVCs.Models.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Actions.Orders;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Information;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Turn;

    /// <summary>
    /// MvcModel Object Api
    /// </summary>
    public interface IMvcModelObject
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        bool CheckWinConditions();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ITalonIdentificationReport GetActingTalonIdentificationReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IMvcModelInformationReport GetMvcModelInformationReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonIdentificationReport">
        /// </param>
        /// <returns>
        /// </returns>
        ITalonTurnReport GetTalonTurnInformationReport(ITalonIdentificationReport talonIdentificationReport);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="actionReport">
        /// </param>
        /// <returns>
        /// </returns>
        IGameActionReport InputTalonActionOrderReport(ITalonActionOrderReport actionReport);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        bool IsInitialized();

        /// <summary>
        /// Todo
        /// </summary>
        void StartNewGame();
    }
}