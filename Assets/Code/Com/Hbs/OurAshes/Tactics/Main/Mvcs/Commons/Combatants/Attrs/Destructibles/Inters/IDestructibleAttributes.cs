namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attrs.Destructibles.Inters
{
    /// <summary>
    /// Destructible Attributes Interface
    /// </summary>
    public interface IDestructibleAttributes
    {
        /// <summary>
        /// Get the Armor Points
        /// </summary>
        /// <returns>The float Armor Points</returns>
        float GetArmor();

        /// <summary>
        /// Get the Health Points
        /// </summary>
        /// <returns>The float Health Points</returns>
        float GetHealth();
    }
}