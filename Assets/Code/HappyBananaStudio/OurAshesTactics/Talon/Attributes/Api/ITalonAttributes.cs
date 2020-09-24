/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

namespace HappyBananaStudio.OurAshesTactics.Talon.Attributes.Api
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface ITalonAttributes
    {
        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IDestructibleAttributes GetDestructibleAttributes();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IFireableAttributes GetFireableAttributes();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IMoveableAttributes GetMoveableAttributes();

        #endregion Public Methods
    }
}