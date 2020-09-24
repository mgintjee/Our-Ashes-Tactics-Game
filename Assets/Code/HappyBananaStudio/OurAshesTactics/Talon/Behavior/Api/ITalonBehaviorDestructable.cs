/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Reports;
using HappyBananaStudio.OurAshesTactics.Talon.Attributes.Reports;

namespace HappyBananaStudio.OurAshesTactics.Talon.Behavior.Api
{
    /// <summary>
    /// Talon Behavior Destructable Api
    /// </summary>
    public interface ITalonBehaviorDestructible
    {
        #region Public Methods

        /// <summary>
        /// /Todo
        /// </summary>
        /// <returns></returns>
        DestructibleAttributesReport GetDestructibleAttributesReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        TalonCombatResultReport InputTalonCombatOrderReport(TalonCombatOrderReport talonCombatOrderReport);

        #endregion Public Methods
    }
}