/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>
/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshes.Tactics.Api.Maps.Games.Reports;

namespace HappyBananaStudio.OurAshes.Tactics.Api.MVCs.Turns
{
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
        IGameTurnResultReport GetTalonTurnResultReport();
    }
}
