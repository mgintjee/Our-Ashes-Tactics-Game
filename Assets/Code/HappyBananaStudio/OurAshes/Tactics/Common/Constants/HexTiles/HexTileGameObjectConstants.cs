/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>
/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

namespace HappyBananaStudio.OurAshes.Tactics.Common.Constants.HexTiles
{
    public static class HexTileGameObjectConstants
    {
        // The X Offset
        private static readonly float OFFSET_X = 3.47f * 5;

        // The Y Offset
        private static readonly float OFFSET_Y = -0.6f * 5;

        // The Z Offset
        private static readonly float OFFSET_Z = 4f * 5;

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public static float GetOffsetX()
        {
            return OFFSET_X;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public static float GetOffsetY()
        {
            return OFFSET_Y;
        }

        public static float GetOffsetZ()
        {
            return OFFSET_Z;
        }
    }
}
