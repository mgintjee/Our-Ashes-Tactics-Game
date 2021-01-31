namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Reports.Api
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.GameBoards.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Phalanxes.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Talons.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.WinConditions.Reports.Api;

    /// <summary>
    /// MvcModel Report Api
    /// Todo: Should be a snapshot of the MvcModelObject
    /// </summary>
    public interface IMvcModelReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ITalonRosterReport GetTalonRosterReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IGameBoardReport GetGameBoardReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IPhalanxRosterReport GetPhalanxRosterReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IWinConditionReport GetWinConditionReport();
    }
}