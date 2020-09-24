/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

namespace HappyBananaStudio.OurAshesTactics.Talon.Attributes.Api
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IMoveableAttributes
    {
        #region Public Methods

        /// <summary>
        /// Get the MovePoints
        /// </summary>
        /// <returns>The int MovePoints</returns>
        int GetMovePoints();

        /// <summary>
        /// Get the TurnPoints
        /// </summary>
        /// <returns>The int TurnPoints</returns>
        int GetTurnPoints();

        #endregion Public Methods
    }
}