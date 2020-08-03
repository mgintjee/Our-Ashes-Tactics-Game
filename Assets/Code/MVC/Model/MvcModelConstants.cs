using System.Diagnostics;

/// <summary>
/// File to store all of the constants for the MvcModel
/// </summary>
public static class MvcModelConstants
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    #endregion Private Fields

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

        private static readonly string FACTION_ID_PHALANX_ID_COLLECTION_GAME_OBJECT_NAME = "factionId: ";
        private static readonly string MVC_MODEL_GAME_OBJECT_NAME = "mvcModelGameObject";
        private static readonly string PHALANX_ID_TALON_COLLECTION_GAME_OBJECT_NAME = "phalanxId: ";
        private static readonly string TALON_COLLECTION_GAME_OBJECT_NAME = "talonCollectionGameObject";

        #endregion Private Fields

        #region Public Methods

        public static string GetFactionIdPhalanxIdCollectionGameObjectPrefix()
        {
            return FACTION_ID_PHALANX_ID_COLLECTION_GAME_OBJECT_NAME;
        }

        public static string GetMvcModelGameObjectName()
        {
            return MVC_MODEL_GAME_OBJECT_NAME;
        }

        public static string GetPhalanxIdTalonCollectionGameObjectPrefix()
        {
            return PHALANX_ID_TALON_COLLECTION_GAME_OBJECT_NAME;
        }

        public static string GetTalonCollectionGameObjectName()
        {
            return TALON_COLLECTION_GAME_OBJECT_NAME;
        }

        #endregion Public Methods
    }

    #endregion Public Classes
}