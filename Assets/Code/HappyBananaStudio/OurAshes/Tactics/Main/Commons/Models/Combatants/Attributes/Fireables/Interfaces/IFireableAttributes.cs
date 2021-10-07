namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Fireables.Interfaces
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