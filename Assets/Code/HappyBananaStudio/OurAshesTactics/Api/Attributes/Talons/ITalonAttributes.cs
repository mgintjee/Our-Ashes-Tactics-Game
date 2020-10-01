/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Attributes.Talons
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface ITalonAttributes
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IDestructibleAttributes GetDestructibleAttributes();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IFireableAttributes GetFireableAttributes();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IMovableAttributes GetMovableAttributes();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IUtilityAttributes GetUtilityAttributes();
    }
}