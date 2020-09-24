/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Roster.Constants
{
    /// <summary>
    /// File to store all of the constants for the Roster
    /// </summary>
    public static class RosterConstants
    {
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
            private static readonly string FACTION_ID_GAME_OBJECT_PREFIX = "FactionId: ";

            // Todo
            private static readonly string PHALANX_ID_GAME_OBJECT_PREFIX = "PhalanxId: ";

            // Todo
            private static readonly string ROSTER_GAME_OBJECT_NAME = "rosterGameObject";

            #endregion Private Fields

            #region Public Methods

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public static string GetFactionIdGameObjectPrefix()
            {
                return FACTION_ID_GAME_OBJECT_PREFIX;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public static string GetPhalanxIdGameObjectPrefix()
            {
                return PHALANX_ID_GAME_OBJECT_PREFIX;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public static string GetRosterGameObjectName()
            {
                return ROSTER_GAME_OBJECT_NAME;
            }

            #endregion Public Methods
        }

        #endregion Public Classes
    }
}