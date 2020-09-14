/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Common.Logging;
using System.Diagnostics;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Constants
{
    /// <summary>
    /// File to store all of the constants for the Talon
    /// </summary>
    public static class TalonConstants
    {
        #region Private Fields

        // Provide logging capability
        private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

        #endregion Private Fields

        #region Public Classes

        /// <summary>
        /// Store all of the constants related to the Roster Object
        /// </summary>
        public static class Object
        {
        }

        /// <summary>
        /// Store all of the constants related to the Roster Script
        /// </summary>
        public static class Script
        {
            #region Private Fields

            // Todo
            private static readonly string PHALANX_INDEX__GAME_OBJECT_PREFIX = "PhanlanxIndex: ";
            // Todo
            private static readonly string TALON_ID_GAME_OBJECT_PREFIX = "TalonId: ";

            #endregion Private Fields

            #region Public Methods
            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public static string GetPhalanxIndexGameObjectPrefix()
            {
                return PHALANX_INDEX__GAME_OBJECT_PREFIX;
            }
            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public static string GetTalonIdGameObjectPrefix()
            {
                return TALON_ID_GAME_OBJECT_PREFIX;
            }

            #endregion Public Methods
        }

        #endregion Public Classes
    }
}