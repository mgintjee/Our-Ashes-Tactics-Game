/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>
/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

namespace HappyBananaStudio.OurAshes.Tactics.Common.Constants.Mvc.Initializers
{
    /// <summary>
    /// File to store all of the constants for the MvcInitialization
    /// </summary>
    public static class MvcInitializationConstants
    {
        // Todo
        private static readonly bool DEFAULT_MAP_MIRRORED = true;

        // Todo
        private static readonly int DEFAULT_MAP_RADIUS = 3;

        // Todo
        private static readonly int DEFAULT_MAP_SEED = 22;

        // Todo
        private static bool setMapMirrored = DEFAULT_MAP_MIRRORED;

        // Todo
        private static int setMapRadius = DEFAULT_MAP_RADIUS;

        // Todo
        private static int setMapSeed = DEFAULT_MAP_SEED;

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public static bool GetMapMirrored()
        {
            return setMapMirrored;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public static int GetMapRadius()
        {
            return setMapRadius;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public static int GetMapSeed()
        {
            return setMapSeed;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="toSetMapMirrored">
        /// </param>

        public static void SetMapMirrored(bool toSetMapMirrored)
        {
            setMapMirrored = toSetMapMirrored;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="toSetMapRadius">
        /// </param>
        public static void SetMapRadius(int toSetMapRadius)
        {
            setMapRadius = toSetMapRadius;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="toSetMapSeed">
        /// </param>
        public static void SetMapSeed(int toSetMapSeed)
        {
            setMapSeed = toSetMapSeed;
        }
    }
}
