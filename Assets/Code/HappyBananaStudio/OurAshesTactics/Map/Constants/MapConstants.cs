/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Map.Constants
{
    /// <summary>
    /// File to store all of the constants for the Map
    /// </summary>
    public static class MapConstants
    {
        #region Public Classes

        /// <summary>
        /// Store all of the constants related to the MvcModel Object
        /// </summary>
        public static class Object
        {
        }

        /// <summary>
        /// Store all of the constants related to the MvcModel Script
        /// </summary>
        public static class Script
        {
            #region Private Fields

            // Todo
            private static readonly string MAP_GAME_OBJECT_NAME = "mapGameObject";

            // Todo
            private static readonly string MAP_LAYER_LEVEL_GAME_OBJECT_PREFIX = "layerLevel: ";

            #endregion Private Fields

            #region Public Methods

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public static string GetMapGameObjectName()
            {
                return MAP_GAME_OBJECT_NAME;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public static string GetMapLayerLevelGameObjectPrefix()
            {
                return MAP_LAYER_LEVEL_GAME_OBJECT_PREFIX;
            }

            #endregion Public Methods
        }

        #endregion Public Classes
    }
}