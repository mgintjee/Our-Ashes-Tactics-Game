using System.Collections.Generic;

/// <summary>
/// Todo
/// </summary>
public abstract class PathObject
{
    #region Public Methods

    public abstract CubeCoordinates GetCubeCoordinatesEnd();

    public abstract CubeCoordinates GetCubeCoordinatesStart();

    public abstract List<CubeCoordinates> GetCubeCoordinatesStepList();

    public abstract int GetPathObjectCost();

    public abstract int GetPathObjectLength();

    public abstract bool IsValid();

    #endregion Public Methods
}