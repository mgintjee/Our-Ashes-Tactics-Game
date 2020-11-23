namespace HappyBananaStudio.OurAshes.Tactics.Api.Talons.Attributes
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IMovableAttributes
    {
        /// <summary>
        /// Get the TurnPoints
        /// </summary>
        /// <returns>
        /// The int TurnPoints
        /// </returns>
        int GetActionPoints();

        /// <summary>
        /// Get the MovePoints
        /// </summary>
        /// <returns>
        /// The int MovePoints
        /// </returns>
        int GetMovePoints();
    }
}