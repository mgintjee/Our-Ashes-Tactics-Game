/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

namespace HappyBananaStudio.OurAshesTactics.Mvc.Controller.Constants
{
    /// <summary>
    /// File to store all of the constants for the MvcController
    /// </summary>
    public static class MvcControllerConstants
    {
        #region Public Classes

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
            #region Private Fields

            // Todo
            private static readonly string MVC_CONTROLLER_GAME_OBJECT_NAME = "mvcControllerGameObject";

            #endregion Private Fields

            #region Public Methods

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public static string GetMvcControllerGameObjectName()
            {
                return MVC_CONTROLLER_GAME_OBJECT_NAME;
            }

            #endregion Public Methods
        }

        #endregion Public Classes
    }
}