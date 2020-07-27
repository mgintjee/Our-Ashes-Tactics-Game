using System.Diagnostics;
using UnityEngine;

/// <summary>
/// Todo
/// </summary>
public static class TileObjectBuilderUtil
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    #endregion Private Fields

    #region Public Methods

    public static TileObject BuildTileObject(TileInfoReport tileInfoReport)
    {
        // Check that the tileInfoReport is non-null
        if (tileInfoReport != null)
        {
            logger.Debug("Building ? from ?", typeof(TileInfoReport), tileInfoReport);
            // Spawn the tileGameObject
            GameObject tileGameObject = SpawnerUtil.SpawnTile();
            // Add the tileScript to the GameObject
            TileScript tileScript = tileGameObject.AddComponent<TileScriptImpl>();
            // Initialize the tileScript with the tileInfoReport
            tileScript.Initialize(tileInfoReport);
            // Return the TileObject
            return tileScript.GetTileObject();
        }
        else
        {
            logger.Error("Unable to build ?. Invalid Parameters.", typeof(TileObject));
            return null;
        }
    }

    #endregion Public Methods
}