/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>
namespace HappyBananaStudio.OurAshes.Tactics.Common.Constants.Mvc.Models
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Loggers;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Loggers;
    using System.Diagnostics;

    /// <summary>
    /// File to store all of the constants for the MvcModel
    /// </summary>
    public static class MvcModelConstants
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLoggerImpl(new StackFrame().GetMethod().DeclaringType);

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
            private static readonly string FACTION_ID_PHALANX_ID_COLLECTION_GAME_OBJECT_NAME = "factionId: ";

            // Todo
            private static readonly string MVC_MODEL_GAME_OBJECT_NAME = "mvcModelGameObject";

            // Todo
            private static readonly string PHALANX_ID_TALON_COLLECTION_GAME_OBJECT_NAME = "phalanxId: ";

            // Todo
            private static readonly string TALON_COLLECTION_GAME_OBJECT_NAME = "talonCollectionGameObject";

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            public static string GetFactionIdPhalanxIdCollectionGameObjectPrefix()
            {
                return FACTION_ID_PHALANX_ID_COLLECTION_GAME_OBJECT_NAME;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            public static string GetMvcModelGameObjectName()
            {
                return MVC_MODEL_GAME_OBJECT_NAME;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            public static string GetPhalanxIdTalonCollectionGameObjectPrefix()
            {
                return PHALANX_ID_TALON_COLLECTION_GAME_OBJECT_NAME;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            public static string GetTalonCollectionGameObjectName()
            {
                return TALON_COLLECTION_GAME_OBJECT_NAME;
            }
        }
    }
}
