/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Attributes.Api.Talons
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IDestructibleAttributes
    {
        /// <summary>
        /// Get the ArmourPoints
        /// </summary>
        /// <returns>
        /// The int ArmourPoints
        /// </returns>
        int GetArmorPoints();

        /// <summary>
        /// Get the HealthPoints
        /// </summary>
        /// <returns>
        /// The int HealthPoints
        /// </returns>
        int GetHealthPoints();
    }
}