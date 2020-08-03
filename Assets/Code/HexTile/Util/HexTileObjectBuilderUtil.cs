using System.Diagnostics;
using UnityEngine;

/// <summary>
/// Todo
/// </summary>
public static class HexTileObjectBuilderUtil
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    #endregion Private Fields

    #region Public Methods

    public static HexTileObject BuildHexTileObject(HexTileConstructionReport hexTileConstructionReport)
    {
        logger.Debug("Building: ?", hexTileConstructionReport);
        // Check that the HexTileConstructionReport is non-null
        if (hexTileConstructionReport != null)
        {
            // Spawn the GameObject
            GameObject hexTileGameObject = SpawnerUtil.SpawnHexTile();
            // Add the HexTileScript to the GameObject
            HexTileScript hexTileScript = hexTileGameObject.AddComponent<HexTileScriptImpl>();
            // Initialize the HexTileScript with the HexTileConstructionReport
            hexTileScript.Initialize(hexTileConstructionReport);
            // Return the HexTileObject
            return hexTileScript.GetHexTileObject();
        }
        else
        {
            logger.Error("Unable to build ?. Invalid Parameters.", typeof(HexTileObject));
            return null;
        }
    }

    #endregion Public Methods
}