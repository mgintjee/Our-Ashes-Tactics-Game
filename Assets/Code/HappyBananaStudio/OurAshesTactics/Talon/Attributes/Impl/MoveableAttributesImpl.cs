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
    public class MoveableAttributesImpl
        : IMoveableAttributes
    {
        #region Private Fields

        // Todo
        private readonly int movePoints;

        // Todo
        private readonly int turnPoints;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="movePoints"></param>
        /// <param name="turnPoints"></param>
        public MoveableAttributesImpl(int movePoints, int turnPoints)
        {
            this.movePoints = movePoints;
            this.turnPoints = turnPoints;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public int GetMovePoints()
        {
            return this.movePoints;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public int GetTurnPoints()
        {
            return this.turnPoints;
        }

        #endregion Public Methods
    }
}