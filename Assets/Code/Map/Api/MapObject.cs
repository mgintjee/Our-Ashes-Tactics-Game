using System.Collections.Generic;

/// <summary>
/// Map Object Api
/// </summary>
public abstract class MapObject
{
    #region Public Methods

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public abstract Dictionary<CubeCoordinates, HexTileObject> GetCubeCoordinatesHexTileObjectDictionary();

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public abstract HashSet<CubeCoordinates> GetCubeCoordinatesSet();

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public abstract MapInformationReport GetMapInformationReport();

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public abstract MapScript GetMapScript();

    #endregion Public Methods
}