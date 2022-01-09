namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Combatants.Attrs.Fireables.Inters
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