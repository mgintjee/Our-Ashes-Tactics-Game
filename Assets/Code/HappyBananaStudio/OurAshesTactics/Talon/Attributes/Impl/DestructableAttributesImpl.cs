/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Talon.Attributes.Api;

namespace HappyBananaStudio.OurAshesTactics.Talon.Attributes.Impl
{
    /// <summary>
    /// Todo
    /// </summary>
    public class DestructableAttributesImpl
        : IDestructibleAttributes
    {
        #region Private Fields

        // Todo
        private readonly int armourPoints;

        // Todo
        private readonly int healthPoints;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="armourPoints"></param>
        /// <param name="healthPoints"></param>
        public DestructableAttributesImpl(int armourPoints, int healthPoints)
        {
            this.armourPoints = armourPoints;
            this.healthPoints = healthPoints;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public int GetArmorPoints()
        {
            return this.armourPoints;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public int GetHealthPoints()
        {
            return this.healthPoints;
        }

        #endregion Public Methods
    }
}