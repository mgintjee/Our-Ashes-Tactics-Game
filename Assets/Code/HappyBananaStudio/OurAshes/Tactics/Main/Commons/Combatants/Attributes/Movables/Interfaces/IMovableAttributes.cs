namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Attributes.Movables.Interfaces
{
    /// <summary>
    /// Movable Attributes Interface
    /// </summary>
    public interface IMovableAttributes
    {
        /// <summary>
        /// Get Action Points
        /// </summary>
        /// <returns>The float Action Points</returns>
        float GetActions();

        /// <summary>
        /// Get Movement Points
        /// </summary>
        /// <returns>The float Movement Points</returns>
        float GetMovement();
    }
}