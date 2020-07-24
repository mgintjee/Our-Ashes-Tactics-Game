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
        private static readonly string MAP_GAME_OBJECT_NAME = "mapGameObject";
        private static readonly string MAP_LAYER_LEVEL_GAME_OBJECT_PREFIX = "layerLevel: ";

        #endregion Private Fields

        #region Public Methods

        public static string GetMvcModelGameObjectName()
        {
            return MVC_MODEL_GAME_OBJECT_NAME;
        }

        public static string GetMapGameObjectName()
        {
            return MAP_GAME_OBJECT_NAME;
        }

        public static string GetMapLayerLevelGameObjectPrefix()
        {
            return MAP_LAYER_LEVEL_GAME_OBJECT_PREFIX;
        }

        #endregion Public Methods
    }

    #endregion Public Classes
}