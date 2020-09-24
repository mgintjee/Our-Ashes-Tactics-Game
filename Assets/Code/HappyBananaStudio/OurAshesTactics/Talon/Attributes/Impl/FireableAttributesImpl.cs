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
    public class FireableAttributesImpl
        : IFireableAttributes
    {
        #region Private Fields

        // Todo
        private readonly int weaponPoints;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="weaponPoints"></param>
        public FireableAttributesImpl(int weaponPoints)
        {
            this.weaponPoints = weaponPoints;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public int GetWeaponPoints()
        {
            return this.weaponPoints;
        }

        #endregion Public Methods
    }
}