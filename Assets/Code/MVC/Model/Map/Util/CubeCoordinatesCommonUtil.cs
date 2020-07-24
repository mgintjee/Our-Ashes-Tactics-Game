using System.Collections.Generic;
using UnityEngine;

public static class CubeCoordinatesCommonUtil
{
    #region Public Methods

    public static HashSet<CubeCoordinates> GenerateNeighborCubeCoordinates(CubeCoordinates cubeCoordinates)
    {
        HashSet<CubeCoordinates> neighborCubeCoordinatesSet = new HashSet<CubeCoordinates>();
        int xCoordinate = cubeCoordinates.GetX();
        int yCoordinate = cubeCoordinates.GetY();
        int zCoordinate = cubeCoordinates.GetZ();
        neighborCubeCoordinatesSet.Add(new CubeCoordinates(xCoordinate, yCoordinate + 1, zCoordinate - 1));
        neighborCubeCoordinatesSet.Add(new CubeCoordinates(xCoordinate + 1, yCoordinate, zCoordinate - 1));
        neighborCubeCoordinatesSet.Add(new CubeCoordinates(xCoordinate + 1, yCoordinate - 1, zCoordinate));
        neighborCubeCoordinatesSet.Add(new CubeCoordinates(xCoordinate, yCoordinate - 1, zCoordinate + 1));
        neighborCubeCoordinatesSet.Add(new CubeCoordinates(xCoordinate - 1, yCoordinate, zCoordinate + 1));
        neighborCubeCoordinatesSet.Add(new CubeCoordinates(xCoordinate - 1, yCoordinate + 1, zCoordinate));
        return neighborCubeCoordinatesSet;
    }

    public static int GetCubeCoordinatesDistanceFrom(CubeCoordinates cubeCoordinatesStart, CubeCoordinates cubeCoordinatesEnd)
    {
        return Mathf.Max(
            Mathf.Abs(cubeCoordinatesStart.GetX() - cubeCoordinatesEnd.GetX()),
            Mathf.Abs(cubeCoordinatesStart.GetY() - cubeCoordinatesEnd.GetY()),
            Mathf.Abs(cubeCoordinatesStart.GetZ() - cubeCoordinatesEnd.GetZ())
            );
    }

    public static int GetCubeCoordinatesDistanceFromCenter(CubeCoordinates cubeCoordinates)
    {
        return GetCubeCoordinatesDistanceFrom(cubeCoordinates, new CubeCoordinates(0, 0, 0));
    }

    public static CubeCoordinates GetNegatedCubeCoordinates(CubeCoordinates cubeCoordinates)
    {
        int xCoordinate = cubeCoordinates.GetX();
        int yCoordinate = cubeCoordinates.GetY();
        int zCoordinate = cubeCoordinates.GetZ();
        return new CubeCoordinates(-xCoordinate, -yCoordinate, -zCoordinate);
    }

    #endregion Public Methods
}