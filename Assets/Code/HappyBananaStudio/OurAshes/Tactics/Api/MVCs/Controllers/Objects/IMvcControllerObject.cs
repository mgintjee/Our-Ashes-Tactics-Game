namespace HappyBananaStudio.OurAshes.Tactics.Api.MVCs.Controllers.Objects
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Actions.Orders;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Turn;

    /// <summary>
    /// MvcController Object Api
    /// </summary>
    public interface IMvcControllerObject
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonTurnInformationReport">
        /// </param>
        void BeginDecisionProcess(ITalonTurnReport talonTurnInformationReport);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        bool IsDeterminingActionReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        bool IsInitialized();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        bool IsReadyToOutputActionReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ITalonActionOrderReport OutputActionReport();
    }
}