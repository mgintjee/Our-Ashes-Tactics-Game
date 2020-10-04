/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Action;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Combat;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Turn
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface ITalonTurnResultReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ITalonActionResultReport GetTalonActionResultReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ITalonCombatResultReport GetTalonCombatResultReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ITalonTurnInformationReport GetTalonTurnInformationReport();
    }
}