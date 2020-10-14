

namespace HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Attributes
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
        IDestructibleAttributesReport GetDestructibleAttributesReport();

        /// <summary>
        /// Get the IMountableReport
        /// </summary>
        /// <returns>
        /// The IMountableReport
        /// </returns>
        IMountableAttributesReport GetMountableAttributesReport();

        /// <summary>
        /// Get the IMovableReport
        /// </summary>
        /// <returns>
        /// The IMovableReport
        /// </returns>
        IMovableAttributesReport GetMovableAttributesReport();
    }
}
