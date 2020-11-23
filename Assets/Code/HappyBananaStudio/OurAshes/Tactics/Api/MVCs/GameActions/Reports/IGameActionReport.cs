namespace HappyBananaStudio.OurAshes.Tactics.Api.MVCs.GameActions.Reports
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Maps.Games.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Actions.Results;

    /// <summary>
    /// Todo
    /// </summary>
    public interface IGameActionReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        int GetActionCounter();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IGameMapInformationReport GetGameMapInformationReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        int GetPhaseCounter();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ITalonActionResultReport GetTalonActionResultReport();
    }
}