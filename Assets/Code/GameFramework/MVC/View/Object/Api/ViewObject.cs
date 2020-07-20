using System.Collections.Generic;

/// <summary>
/// View Object Api
/// </summary>
public abstract class ViewObject
{
    #region Public Methods

    public abstract void AddNewMechObject(MechObject mechObject, int team, int position);

    public abstract void GenerateTileObjectSet();

    public abstract ViewScript GetMapModelScript();

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public abstract Dictionary<CubeCoordinates, TileObject> GetTileCoordsTileObjectDictionary();

    public abstract HashSet<CubeCoordinates> GetValidTileCoordinatesSet();

    #endregion Public Methods
}