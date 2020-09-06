using System.Diagnostics;

/// <summary>
/// File to store all of the constants for the MvcView
/// </summary>
public static class MvcViewConstants
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    #endregion Private Fields

    #region Public Classes

    /// <summary>
    /// Store all of the constants related to the MvcView Object
    /// </summary>
    public static class Object
    {
    }

    /// <summary>
    /// Store all of the constants related to the MvcView Script
    /// </summary>
    public static class Script
    {
        #region Private Fields

        private static readonly string MVC_CANVAS_GAME_OBJECT = "mvcCanvasGameObject";
        private static readonly string MVC_VIEW_GAME_OBJECT_NAME = "mvcViewGameObject";

        #endregion Private Fields

        #region Public Methods

        public static string GetMvcCanvasGameObjectName()
        {
            return MVC_CANVAS_GAME_OBJECT;
        }

        public static string GetMvcViewGameObjectName()
        {
            return MVC_VIEW_GAME_OBJECT_NAME;
        }

        #endregion Public Methods
    }

    #endregion Public Classes
}