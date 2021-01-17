using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.GameBoards.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Roes.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Reports.Api
{
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
        TalonCallSign GetActingTalonCallSign();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IRosterReport GetRosterReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IGameBoardReport GetGameBoardReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IRoeReport GetRoeReport();
    }
}