/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Attributes
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IMovableReport
    {
        /// <summary>
        /// Get the current MovePoints
        /// </summary>
        /// <returns>
        /// The int current MovePoints
        /// </returns>
        int GetCurrentMovePoints();

        /// <summary>
        /// Get the current OrderPoints
        /// </summary>
        /// <returns>
        /// The int current OrderPoints
        /// </returns>
        int GetCurrentOrderPoints();

        /// <summary>
        /// Get the current TurnPoints
        /// </summary>
        /// <returns>
        /// The int current TurnPoints
        /// </returns>
        int GetCurrentTurnPoints();

        /// <summary>
        /// Get the maximum MovePoints
        /// </summary>
        /// <returns>
        /// The int maximum MovePoints
        /// </returns>
        int GetMaximumMovePoints();

        /// <summary>
        /// Get the maximum OrderPoints
        /// </summary>
        /// <returns>
        /// The int maximum OrderPoints
        /// </returns>
        int GetMaximumOrderPoints();

        /// <summary>
        /// Get the maximum TurnPoints
        /// </summary>
        /// <returns>
        /// The int maximum TurnPoints
        /// </returns>
        int GetMaximumTurnPoints();
    }
}