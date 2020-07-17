using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// MapModelObject Api
/// </summary>
[SerializeField]
public abstract class MapModelObject
{
    #region Public Methods

    public abstract void AddNewMechObject(MechObject mechObject, int team, int position);

    public abstract void GenerateTileObjectSet();

    public abstract MapModelScript GetMapModelScript();

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public abstract Dictionary<CubeCoordinates, TileObject> GetTileCoordsTileObjectDictionary();

    public abstract HashSet<CubeCoordinates> GetValidTileCoordinatesSet();

    #endregion Public Methods
}