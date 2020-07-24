using System.Collections.Generic;
using System.Diagnostics;

/// <summary>
/// File to store all of the constants for the MvcFramework
/// </summary>
public static class MvcFrameworkConstants
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    #endregion Private Fields

    #region Public Methods

    public static void SetMapSeed(int toSetMapSeed)
    {
        logger.Info("Setting MapSeed=?", toSetMapSeed);
        setMapSeed = toSetMapSeed;
    }

    // Setter Methods
    public static void SetMapRadius(int toSetMapRadius)
    {
        logger.Info("Setting MapRadius=?", toSetMapRadius);
        setMapRadius = toSetMapRadius;
    }

    public static void SetMapMirrored(bool toSetMapMirrored)
    {
        logger.Info("Setting MapMirrored=?", toSetMapMirrored);
        setMapMirrored = toSetMapMirrored;
    }

    public static void SetTeamIdControllerTypeDictionary(Dictionary<TeamIdEnum, HashSet<MechInfoReport>> toSetTeamIdControllerTypeDictionary)
    {
        string teamIdControllerPairs = "";
        foreach (TeamIdEnum teamId in toSetTeamIdControllerTypeDictionary.Keys)
        {
            teamIdControllerPairs += "[" + typeof(TeamIdEnum) + "=" + teamId +
                ", " + typeof(ControllerTypeEnum) + "=" + toSetTeamIdControllerTypeDictionary[teamId] +
                "]\n";
        }
        logger.Info("Setting TeamIdControllerTypeDictionary=?", teamIdControllerPairs);
        setTeamIdControllerTypeDictionary = new Dictionary<TeamIdEnum, ControllerTypeEnum>(toSetTeamIdControllerTypeDictionary);
    }

    public static void SetTeamIdControllerTypeDictionary(Dictionary<TeamIdEnum, ControllerTypeEnum> toSetTeamIdControllerTypeDictionary)
    {
        string teamIdControllerPairs = "";
        foreach (TeamIdEnum teamId in toSetTeamIdControllerTypeDictionary.Keys)
        {
            teamIdControllerPairs += "[" + typeof(TeamIdEnum) + "=" + teamId +
                ", " + typeof(ControllerTypeEnum) + "=" + toSetTeamIdControllerTypeDictionary[teamId] +
                "]\n";
        }
        logger.Info("Setting TeamIdControllerTypeDictionary=?", teamIdControllerPairs);
        setTeamIdControllerTypeDictionary = new Dictionary<TeamIdEnum, ControllerTypeEnum>(toSetTeamIdControllerTypeDictionary);
    }

    #endregion Public Methods

    #region Public Classes

    /// <summary>
    /// Store all of the constants related to the MvcFramework Object
    /// </summary>
    public static class Object
    {
        #region Private Fields

        private static readonly int DEFAULT_MAP_SEED = 22;
        private static readonly int DEFAULT_MAP_RADIUS = 3;
        private static readonly bool DEFAULT_MAP_MIRRORED = true;
        private static readonly int MAX_MECH_PER_RADIUS_STEP = 2;

        private static int setMapSeed = DEFAULT_MAP_SEED;
        private static int setMapRadius = DEFAULT_MAP_RADIUS;
        private static bool setMapMirrored = DEFAULT_MAP_MIRRORED;
        private static Dictionary<TeamIdEnum, ControllerTypeEnum> setTeamIdControllerTypeDictionary = new Dictionary<TeamIdEnum, ControllerTypeEnum>();
        private static Dictionary<TeamIdEnum, HashSet<MechConstructionReport>> setTeamIdMechConstructionReportSetDictionary = new Dictionary<TeamIdEnum, HashSet<MechConstructionReport>>();

        #endregion Private Fields

        #region Public Methods

        // Getter Methods
        public static int GetMapSeed()
        {
            return setMapSeed;
        }

        public static int GetMapRadius()
        {
            return setMapRadius;
        }

        public static Dictionary<TeamIdEnum, ControllerTypeEnum> GetTeamIdControllerTypeDictionary()
        {
            return setTeamIdControllerTypeDictionary;
        }

        public static bool GetMapMirrored()
        {
            return setMapMirrored;
        }

        public static int GetMaxAmountOfMechs()
        {
            return MAX_MECH_PER_RADIUS_STEP * setMapRadius;
        }

        #endregion Public Methods
    }

    /// <summary>
    /// Store all of the constants related to the MvcFramework Script
    /// </summary>
    public static class Script
    {
        #region Private Fields

        private static readonly string MVC_FRAMEWORK_GAME_OBJECT_NAME = "mvcFrameworkGameObject";

        #endregion Private Fields

        #region Public Methods

        public static string GetMvcFrameworkGameObjectName()
        {
            return MVC_FRAMEWORK_GAME_OBJECT_NAME;
        }

        #endregion Public Methods
    }

    #endregion Public Classes
}