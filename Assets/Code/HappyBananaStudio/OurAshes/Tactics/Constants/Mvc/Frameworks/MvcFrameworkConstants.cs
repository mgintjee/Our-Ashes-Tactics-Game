namespace HappyBananaStudio.OurAshes.Tactics.Constants.Mvc.Frameworks
{
    /// <summary>
    /// File to store all of the constants for the MvcFramework
    /// </summary>
    public static class MvcFrameworkConstants
    {
        /// <summary>
        /// Store all of the constants related to the MvcFramework Object
        /// </summary>
        public static class Object
        {
        }

        /// <summary>
        /// Store all of the constants related to the MvcFramework Script
        /// </summary>
        public static class Script
        {
            private static readonly string MVC_FRAMEWORK_GAME_OBJECT_NAME = "mvcFrameworkGameObject";

            public static string GetMvcFrameworkGameObjectName()
            {
                return MVC_FRAMEWORK_GAME_OBJECT_NAME;
            }
        }
    }
}