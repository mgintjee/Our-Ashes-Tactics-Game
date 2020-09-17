/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Constants
{
    /// <summary>
    /// Todo
    /// </summary>
    public class TalonCanvasConstants
    {
        #region Private Fields

        // Todo
        private static readonly string ARMOUR_BACKGROUND_NAME = "ArmourBackground";

        // Todo
        private static readonly string ARMOUR_TEXT_NAME = "ArmourText";

        // Todo
        private static readonly string CANVAS_BACKGROUND_NAME = "CanvasBackground";

        // Todo
        private static readonly string HEALTH_BACKGROUND_NAME = "HealthBackground";

        // Todo
        private static readonly string HEALTH_TEXT_NAME = "HealthText";

        // Todo
        private static readonly string TEAMID_BACKGROUND_NAME = "TeamIdBackground";

        // Todo
        private static readonly string TEAMID_TEXT_NAME = "TeamIdText";

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static string GetArmourBackgroundGameObjectName()
        {
            return ARMOUR_BACKGROUND_NAME;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static string GetArmourTextGameObjectName()
        {
            return ARMOUR_TEXT_NAME;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static string GetCanvasBackgroundGameObjectName()
        {
            return CANVAS_BACKGROUND_NAME;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static string GetHealthBackgroundGameObjectName()
        {
            return HEALTH_BACKGROUND_NAME;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static string GetHealthTextGameObjectName()
        {
            return HEALTH_TEXT_NAME;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static string GetTeamIdBackgroundGameObjectName()
        {
            return TEAMID_BACKGROUND_NAME;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static string GetTeamIdTextGameObjectName()
        {
            return TEAMID_TEXT_NAME;
        }

        #endregion Public Methods
    }
}