using System.Diagnostics;

/// <summary>
/// File to store all of the constants for the MvcController
/// </summary>
public static class MvcControllerConstants
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    #endregion Private Fields

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

        private static readonly string MVC_CONTROLLER_GAME_OBJECT_NAME = "mvcControllerGameObject";

        #endregion Private Fields

        #region Public Methods

        public static string GetMvcControllerGameObjectName()
        {
            return MVC_CONTROLLER_GAME_OBJECT_NAME;
        }

        #endregion Public Methods
    }

    #endregion Public Classes
}