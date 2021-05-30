using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Models.Responses.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Combats.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Formations.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Models.Responses.IDs.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Models.Rosters.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Orders.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Scores.Reports.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Models.Responses.Interfaces
{
    /// <summary>
    /// Model Response Interface
    /// </summary>
    public interface ISortieModelResponse
        : IMvcModelResponse
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IRosterReport GetRosterReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ICombatReport GetCombatReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IMapReport GetMapReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IOrderReport GetOrderReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IFormationReport GetFormationReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IScoreReport GetScoreReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ISortieResponseID SortieResponseID();
    }
}