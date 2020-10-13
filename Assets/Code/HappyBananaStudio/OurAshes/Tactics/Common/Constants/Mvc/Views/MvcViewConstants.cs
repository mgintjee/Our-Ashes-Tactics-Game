/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>
/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

namespace HappyBananaStudio.OurAshes.Tactics.Common.Constants.Mvc.Views
{
    /// <summary>
    /// File to store all of the constants for the MvcView
    /// </summary>
    public static class MvcViewConstants
    {
        /// <summary>
        /// Store all of the constants related to the MvcView Object
        /// </summary>
        public static class Object
        {
        }

        /// <summary>
        /// Store all of the constants related to the MvcView Script
        /// </summary>
        public static class Script
        {
            // Todo
            private static readonly string MVC_CANVAS_GAME_OBJECT = "mvcCanvasGameObject";

            // Todo
            private static readonly string MVC_VIEW_GAME_OBJECT_NAME = "mvcViewGameObject";

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            public static string GetMvcCanvasGameObjectName()
            {
                return MVC_CANVAS_GAME_OBJECT;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            public static string GetMvcViewGameObjectName()
            {
                return MVC_VIEW_GAME_OBJECT_NAME;
            }
        }
    }
}
