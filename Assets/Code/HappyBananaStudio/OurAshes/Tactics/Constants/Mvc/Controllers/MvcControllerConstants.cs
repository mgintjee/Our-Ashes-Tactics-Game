namespace HappyBananaStudio.OurAshes.Tactics.Constants.Mvc.Controllers
{
    /// <summary>
    /// File to store all of the constants for the MvcController
    /// </summary>
    public static class MvcControllerConstants
    {
        /// <summary>
        /// Store all of the constants related to the MvcController Object
        /// </summary>
        public static class Object
        {
        }

        /// <summary>
        /// Store all of the constants related to the MvcController Script
        /// </summary>
        public static class Script
        {
            // Todo
            private static readonly string MVC_CONTROLLER_GAME_OBJECT_NAME = "mvcControllerGameObject";

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            public static string GetMvcControllerGameObjectName()
            {
                return MVC_CONTROLLER_GAME_OBJECT_NAME;
            }
        }
    }
}