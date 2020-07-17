using System.Collections.Generic;

/// <summary>
/// Todo
/// </summary>
public abstract class PathFinder
{
    #region Public Methods

    public abstract void BeginPathFinding();

    public abstract HashSet<CubeCoordinates> GetCubeCoordiantesEndSet();

    public abstract Dictionary<CubeCoordinates, PathObject> GetPathObjectDictionary();

    public abstract PathObject GetPathObjectForCubeCoordinatesEnd(CubeCoordinates cubeCoordinatesEnd);

    #endregion Public Methods
}