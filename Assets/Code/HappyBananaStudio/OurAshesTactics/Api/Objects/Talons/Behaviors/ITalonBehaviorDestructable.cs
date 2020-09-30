/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Attributes;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Combat;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Talons.Behaviors
{
    /// <summary>
    /// Talon Behavior Destructible Api
    /// </summary>
    public interface ITalonBehaviorDestructible
    {
        /// <summary>
        /// /Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IDestructibleReport GetDestructibleAttributesReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ITalonCombatResultReport InputTalonCombatOrderReport(ITalonCombatOrderReport talonCombatOrderReport);
    }
}