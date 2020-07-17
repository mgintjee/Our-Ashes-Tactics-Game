using System.Collections.Generic;

/// <summary>
/// </summary>
public static class MechPaintConstants
{
    #region Private Fields

    private static readonly string MECH_MODEL_NAME_COCKPIT = "MechCockpitModel";
    private static readonly string MECH_MODEL_NAME_LEGS = "MechLegsModel";
    private static readonly int MECH_MODEL_PAINT_INDEX_COCKPIT = 1;
    private static readonly int MECH_MODEL_PAINT_INDEX_LEGS = 2;
    private static readonly int MECH_MODEL_TILE_TOP_PAINT_INDEX_LEGS = 0;

    private static readonly Dictionary<string, int> MECH_NAME_PAINT_INDEX_DICTIONARY = new Dictionary<string, int>()
    {
        { MECH_MODEL_NAME_COCKPIT, MECH_MODEL_PAINT_INDEX_COCKPIT },
        { MECH_MODEL_NAME_LEGS, MECH_MODEL_PAINT_INDEX_LEGS },
    };

    private static readonly Dictionary<string, int> MECH_NAME_TILE_TOP_PAINT_INDEX_DICTIONARY = new Dictionary<string, int>()
    {
        { MECH_MODEL_NAME_LEGS, MECH_MODEL_TILE_TOP_PAINT_INDEX_LEGS },
    };

    #endregion Private Fields

    #region Public Methods

    /// <summary>
    /// </summary>
    /// <param name="mechPartName"></param>
    /// <returns></returns>
    public static int GetMechPaintIndexForMechName(string mechPartName)
    {
        return (MECH_NAME_PAINT_INDEX_DICTIONARY.ContainsKey(mechPartName))
            ? MECH_NAME_PAINT_INDEX_DICTIONARY[mechPartName]
            : -1;
    }

    /// <summary>
    /// </summary>
    /// <param name="mechPartName"></param>
    /// <returns></returns>
    public static int GetTilePaintIndexForMechName(string mechPartName)
    {
        return (MECH_NAME_TILE_TOP_PAINT_INDEX_DICTIONARY.ContainsKey(mechPartName))
            ? MECH_NAME_TILE_TOP_PAINT_INDEX_DICTIONARY[mechPartName]
            : -1;
    }

    #endregion Public Methods
}