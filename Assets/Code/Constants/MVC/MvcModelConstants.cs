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

        private static readonly string MVC_MODEL_GAME_OBJECT_NAME = "mvcModelGameObject";
        private static readonly string MECH_COLLECTION_GAME_OBJECT_NAME = "mechCollectionGameObject";
        private static readonly string TEAM_ID_MECH_COLLECTION_GAME_OBJECT_PREFIX = "teamId: ";

        #endregion Private Fields

        #region Public Methods

        public static string GetMvcModelGameObjectName()
        {
            return MVC_MODEL_GAME_OBJECT_NAME;
        }

        public static string GetMechCollectionGameObjectName()
        {
            return MECH_COLLECTION_GAME_OBJECT_NAME;
        }

        public static string GetTeamIdMechCollectionGameObjectPrefix()
        {
            return TEAM_ID_MECH_COLLECTION_GAME_OBJECT_PREFIX;
        }

        #endregion Public Methods
    }

    #endregion Public Classes
}