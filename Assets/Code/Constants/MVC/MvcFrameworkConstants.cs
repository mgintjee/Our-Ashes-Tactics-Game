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

    #region Public Classes

    /// <summary>
    /// Store all of the constants related to the MvcFramework Object
    /// </summary>
    public static class Object
    {
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