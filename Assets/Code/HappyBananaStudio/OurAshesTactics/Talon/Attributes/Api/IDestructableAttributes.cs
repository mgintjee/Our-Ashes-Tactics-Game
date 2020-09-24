/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

namespace HappyBananaStudio.OurAshesTactics.Talon.Attributes.Api
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IDestructibleAttributes
    {
        #region Public Methods

        /// <summary>
        /// Get the ArmourPoints
        /// </summary>
        /// <returns>The int ArmourPoints</returns>
        int GetArmorPoints();

        /// <summary>
        /// Get the HealthPoints
        /// </summary>
        /// <returns>The int HealthPoints</returns>
        int GetHealthPoints();

        #endregion Public Methods
    }
}