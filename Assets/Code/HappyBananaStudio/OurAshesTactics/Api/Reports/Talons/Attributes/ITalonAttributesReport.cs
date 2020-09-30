/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Attributes
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface ITalonAttributesReport
    {
        /// <summary>
        /// Get the IDestructibleReport
        /// </summary>
        /// <returns>
        /// The IDestructibleReport
        /// </returns>
        IDestructibleReport GetDestructibleReport();

        /// <summary>
        /// Get the IFireableReport
        /// </summary>
        /// <returns>
        /// The IFireableReport
        /// </returns>
        IFireableReport GetFireableReport();

        /// <summary>
        /// Get the IMovableReport
        /// </summary>
        /// <returns>
        /// The IMovableReport
        /// </returns>
        IMovableReport GetMovableReport();
    }
}