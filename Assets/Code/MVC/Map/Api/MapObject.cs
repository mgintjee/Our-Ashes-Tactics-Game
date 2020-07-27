using System.Collections.Generic;

/// <summary>
/// Map Object Api
/// </summary>
public abstract class MapObject
{
    #region Public Methods

    public abstract MapScript GetMapScript();

    public abstract Dictionary<CubeCoordinates, TileObject> GetCubeCoordinatesTileObjectDictionary();

    public abstract HashSet<CubeCoordinates> GetCubeCoordinatesSet();

    public abstract MapInfoReport GetMapInfoReport();

    #endregion Public Methods
}