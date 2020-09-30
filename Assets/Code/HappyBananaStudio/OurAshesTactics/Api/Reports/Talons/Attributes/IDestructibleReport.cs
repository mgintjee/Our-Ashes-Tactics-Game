/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Attributes
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IDestructibleReport
    {
        /// <summary>
        /// Get the current ArmourPoints
        /// </summary>
        /// <returns>
        /// The int current ArmourPoints
        /// </returns>
        int GetCurrentArmorPoints();

        /// <summary>
        /// Get the current HealthPoints
        /// </summary>
        /// <returns>
        /// The int current HealthPoints
        /// </returns>
        int GetCurrentHealthPoints();

        /// <summary>
        /// Get the maximum ArmourPoints
        /// </summary>
        /// <returns>
        /// The int maximum ArmourPoints
        /// </returns>
        int GetMaximumArmorPoints();

        /// <summary>
        /// Get the maximum HealthPoints
        /// </summary>
        /// <returns>
        /// The int maximum HealthPoints
        /// </returns>
        int GetMaximumHealthPoints();
    }
}