/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Common.Logging;
using System.Diagnostics;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Initializer.Constants
{
    /// <summary>
    /// File to store all of the constants for the MvcInitialization
    /// </summary>
    public static class MvcInitializationConstants
    {
        #region Private Fields

        // Todo
        private static readonly bool DEFAULT_MAP_MIRRORED = true;

        // Todo
        private static readonly int DEFAULT_MAP_RADIUS = 3;

        // Todo
        private static readonly int DEFAULT_MAP_SEED = 22;

        // Provide logging capability
        private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private static bool setMapMirrored = DEFAULT_MAP_MIRRORED;

        // Todo
        private static int setMapRadius = DEFAULT_MAP_RADIUS;

        // Todo
        private static int setMapSeed = DEFAULT_MAP_SEED;

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static bool GetMapMirrored()
        {
            return setMapMirrored;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static int GetMapRadius()
        {
            return setMapRadius;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static int GetMapSeed()
        {
            return setMapSeed;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="toSetMapMirrored"></param>

        public static void SetMapMirrored(bool toSetMapMirrored)
        {
            logger.Info("Setting MapMirrored=?", toSetMapMirrored);
            setMapMirrored = toSetMapMirrored;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="toSetMapRadius"></param>
        public static void SetMapRadius(int toSetMapRadius)
        {
            logger.Info("Setting MapRadius=?", toSetMapRadius);
            setMapRadius = toSetMapRadius;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="toSetMapSeed"></param>
        public static void SetMapSeed(int toSetMapSeed)
        {
            logger.Info("Setting MapSeed=?", toSetMapSeed);
            setMapSeed = toSetMapSeed;
        }

        #endregion Public Methods
    }
}