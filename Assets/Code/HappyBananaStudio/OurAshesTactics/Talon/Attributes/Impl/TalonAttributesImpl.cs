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
    public class TalonAttributesImpl
        : ITalonAttributes
    {
        #region Private Fields

        // Todo
        private readonly IDestructibleAttributes destructableAttributes;

        // Todo
        private readonly IFireableAttributes fireableAttributes;

        // Todo
        private readonly IMoveableAttributes moveableAttributes;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="destructableAttributes"></param>
        /// <param name="fireableAttributes">    </param>
        /// <param name="moveableAttributes">    </param>
        public TalonAttributesImpl(IDestructibleAttributes destructableAttributes,
            IFireableAttributes fireableAttributes,
            IMoveableAttributes moveableAttributes)
        {
            this.destructableAttributes = destructableAttributes;
            this.fireableAttributes = fireableAttributes;
            this.moveableAttributes = moveableAttributes;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public IDestructibleAttributes GetDestructibleAttributes()
        {
            return this.destructableAttributes;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public IFireableAttributes GetFireableAttributes()
        {
            return this.fireableAttributes;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public IMoveableAttributes GetMoveableAttributes()
        {
            return this.moveableAttributes;
        }

        #endregion Public Methods
    }
}