namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Controllers.Objects.Api
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Orders.Reports.Api;

    /// <summary>
    /// MvcController Object Api
    /// </summary>
    public interface IMvcControllerObject
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonCallSign"></param>
        /// <returns></returns>
        ITalonOrderReport DetermineTalonOrderReport(TalonCallSign talonCallSign);

        /*
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
        */
    }
}