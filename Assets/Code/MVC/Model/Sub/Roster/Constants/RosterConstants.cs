using System.Diagnostics;

/// <summary>
/// File to store all of the constants for the Roster
/// </summary>
public static class RosterConstants
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    #endregion Private Fields

    #region Public Classes

    /// <summary>
    /// Store all of the constants related to the Roster Object
    /// </summary>
    public static class Object
    {
    }

    /// <summary>
    /// Store all of the constants related to the Roster Script
    /// </summary>
    public static class Script
    {
        #region Private Fields

        private static readonly string FACTION_ID_GAME_OBJECT_PREFIX = "FactionId: ";
        private static readonly string PHALANX_ID_GAME_OBJECT_PREFIX = "PhalanxId: ";
        private static readonly string ROSTER_GAME_OBJECT_NAME = "rosterGameObject";

        #endregion Private Fields

        #region Public Methods

        public static string GetFactionIdGameObjectPrefix()
        {
            return FACTION_ID_GAME_OBJECT_PREFIX;
        }

        public static string GetPhalanxIdGameObjectPrefix()
        {
            return PHALANX_ID_GAME_OBJECT_PREFIX;
        }

        public static string GetRosterGameObjectName()
        {
            return ROSTER_GAME_OBJECT_NAME;
        }

        #endregion Public Methods
    }

    #endregion Public Classes
}