
namespace HappyBananaStudio.OurAshes.Tactics.Common.Constants.Maps.Game
{
    /// <summary>
    /// File to store all of the constants for the Map
    /// </summary>
    public static class GameMapConstants
    {
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
            // Todo
            private static readonly string MAP_GAME_OBJECT_NAME = "gameMapGameObject";

            // Todo
            private static readonly string MAP_LAYER_LEVEL_GAME_OBJECT_PREFIX = "layerLevel: ";

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            public static string GetGameMapGameObjectName()
            {
                return MAP_GAME_OBJECT_NAME;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            public static string GetGameMapLayerLevelGameObjectPrefix()
            {
                return MAP_LAYER_LEVEL_GAME_OBJECT_PREFIX;
            }
        }
    }
}
