namespace HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Attributes
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IDestructibleAttributesReport
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