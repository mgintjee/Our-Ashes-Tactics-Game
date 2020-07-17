using System;

/// <summary>
/// </summary>
public static class GameFrameworkObjectConstants
{
    #region Private Fields

    // Todo
    private static readonly bool MAP_MIRRORED = true;

    // Todo
    private static readonly int MAP_MODEL_OBJECT_RADIUS = 3;

    // Todo
    private static readonly int MAP_MODEL_OBJECT_SEED = new Random().Next();

    // Todo
    private static readonly int MAX_MECH_PER_TEAM = 3;

    // Todo
    private static readonly TeamControllerTypeEnum TEAM_1_CONTORLLER = TeamControllerTypeEnum.ROBOT;

    // Todo
    private static readonly TeamControllerTypeEnum TEAM_2_CONTORLLER = TeamControllerTypeEnum.ROBOT;

    #endregion Private Fields

    #region Public Methods

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public static bool GetMapMirrored()
    {
        return MAP_MIRRORED;
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public static int GetMapModelObjectRadius()
    {
        return MAP_MODEL_OBJECT_RADIUS;
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public static int GetMapModelObjectSeed()
    {
        return MAP_MODEL_OBJECT_SEED;
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public static int GetMaxMechPerTeam()
    {
        return MAX_MECH_PER_TEAM;
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public static TeamControllerTypeEnum GetTeam1Controller()
    {
        return TEAM_1_CONTORLLER;
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public static TeamControllerTypeEnum GetTeam2Controller()
    {
        return TEAM_2_CONTORLLER;
    }

    #endregion Public Methods
}