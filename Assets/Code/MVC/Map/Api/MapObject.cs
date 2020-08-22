using System.Collections.Generic;

/// <summary>
/// Map Object Api
/// </summary>
public abstract class MapObject
{
    #region Public Methods

    public abstract Dictionary<CubeCoordinates, HexTileObject> GetCubeCoordinatesHexTileObjectDictionary();

    public abstract HashSet<CubeCoordinates> GetCubeCoordinatesSet();

    public abstract MapConstructionReport GetMapConstructionReport();

    public abstract MapInformationReport GetMapInformationReport();

    public abstract MapScript GetMapScript();

    #endregion Public Methods
}