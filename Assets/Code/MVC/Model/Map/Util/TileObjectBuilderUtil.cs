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
        if (tileInfoReport != null)
        {
            logger.Debug("Building ? from ?", typeof(TileInfoReport), tileInfoReport);
            GameObject tileGameObject = SpawnerUtil.SpawnTile();
            TileScript tileScript = tileGameObject.AddComponent<TileScriptImpl>();
            tileScript.Initialize(tileInfoReport);
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