/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Reports;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Api
{
    /// <summary>
    /// Talon Behavior Destructable Api
    /// </summary>
    public interface ITalonBehaviorDestructable
    {
        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        int GetCurrentArmourPoints();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>

        int GetCurrentHealthPoints();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>

        int GetMaximumArmourPoints();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>

        int GetMaximumHealthPoints();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        TalonCombatResultReport InputTalonCombatOrderReport(TalonCombatOrderReport talonCombatOrderReport);

        #endregion Public Methods
    }
}