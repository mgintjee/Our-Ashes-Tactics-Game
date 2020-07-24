using System.Diagnostics;

/// <summary>
/// File to store all of the constants for the MvcInitialization
/// </summary>
public static class MvcInitializationConstants
{
    #region Private Fields

    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    private static readonly int DEFAULT_MAP_SEED = 22;
    private static readonly int DEFAULT_MAP_RADIUS = 3;
    private static readonly bool DEFAULT_MAP_MIRRORED = true;

    private static int setMapSeed = DEFAULT_MAP_SEED;
    private static int setMapRadius = DEFAULT_MAP_RADIUS;
    private static bool setMapMirrored = DEFAULT_MAP_MIRRORED;

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

    public static bool GetMapMirrored()
    {
        return setMapMirrored;
    }

    // Setter Methods

    public static void SetMapSeed(int toSetMapSeed)
    {
        logger.Info("Setting MapSeed=?", toSetMapSeed);
        setMapSeed = toSetMapSeed;
    }

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

    #endregion Public Methods
}