/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Constants
{
    public static class HexTileGameObjectConstants
    {
        #region Private Fields

        // The X Offset
        private static readonly float OFFSET_X = 3.47f;

        // The Y Offset
        private static readonly float OFFSET_Y = -0.44f;

        // The Z Offset
        private static readonly float OFFSET_Z = 4f;

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static float GetOffsetX()
        {
            return OFFSET_X;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static float GetOffsetY()
        {
            return OFFSET_Y;
        }

        public static float GetOffsetZ()
        {
            return OFFSET_Z;
        }

        #endregion Public Methods
    }
}