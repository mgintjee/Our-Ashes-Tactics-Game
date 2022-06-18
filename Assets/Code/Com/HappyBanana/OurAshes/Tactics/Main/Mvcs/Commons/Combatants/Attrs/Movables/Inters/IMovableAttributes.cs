namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attrs.Movables.Inters
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