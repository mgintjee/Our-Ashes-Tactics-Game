/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>
/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

namespace HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Attributes
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IMovableAttributesReport
    {
        /// <summary>
        /// Get the current MovePoints
        /// </summary>
        /// <returns>
        /// The int current MovePoints
        /// </returns>
        int GetCurrentMovePoints();

        /// <summary>
        /// Get the current TurnPoints
        /// </summary>
        /// <returns>
        /// The int current TurnPoints
        /// </returns>
        int GetCurrentActionPoints();

        /// <summary>
        /// Get the maximum MovePoints
        /// </summary>
        /// <returns>
        /// The int maximum MovePoints
        /// </returns>
        int GetMaximumMovePoints();

        /// <summary>
        /// Get the maximum TurnPoints
        /// </summary>
        /// <returns>
        /// The int maximum TurnPoints
        /// </returns>
        int GetMaximumActionPoints();
    }
}
