namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Attrs.Fireables.Inters
{
    /// <summary>
    /// Fireable Attributes Interface
    /// </summary>
    public interface IFireableAttributes
    {
        /// <summary>
        /// Get the Accuracy Points
        /// </summary>
        /// <returns></returns>
        float GetAccuracy();

        /// <summary>
        /// Get the Range Points
        /// </summary>
        /// <returns></returns>
        float GetRange();
    }
}