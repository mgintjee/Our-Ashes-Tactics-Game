using System.Collections.Generic;
using UnityEngine;

public static class CubeCoordinatesCommonUtil
{
    #region Public Methods

    public static HashSet<CubeCoordinates> GenerateNeighborCubeCoordinates(CubeCoordinates cubeCoordinates)
    {
        return new HashSet<CubeCoordinates>
        {
            new CubeCoordinates(cubeCoordinates.GetX(), cubeCoordinates.GetY() + 1, cubeCoordinates.GetZ() - 1),
            new CubeCoordinates(cubeCoordinates.GetX() + 1, cubeCoordinates.GetY(), cubeCoordinates.GetZ() - 1),
            new CubeCoordinates(cubeCoordinates.GetX() + 1, cubeCoordinates.GetY() - 1, cubeCoordinates.GetZ()),
            new CubeCoordinates(cubeCoordinates.GetX(), cubeCoordinates.GetY() - 1, cubeCoordinates.GetZ() + 1),
            new CubeCoordinates(cubeCoordinates.GetX() - 1, cubeCoordinates.GetY(), cubeCoordinates.GetZ() + 1),
            new CubeCoordinates(cubeCoordinates.GetX() - 1, cubeCoordinates.GetY() + 1, cubeCoordinates.GetZ())
        }; ;
    }

    public static int GetCubeCoordinatesDistanceFrom(CubeCoordinates cubeCoordinatesStart, CubeCoordinates cubeCoordinatesEnd)
    {
        return Mathf.Max(Mathf.Abs(cubeCoordinatesStart.GetX() - cubeCoordinatesEnd.GetX()),
            Mathf.Abs(cubeCoordinatesStart.GetY() - cubeCoordinatesEnd.GetY()),
            Mathf.Abs(cubeCoordinatesStart.GetZ() - cubeCoordinatesEnd.GetZ()));
    }

    public static int GetCubeCoordinatesDistanceFromCenter(CubeCoordinates cubeCoordinates)
    {
        return GetCubeCoordinatesDistanceFrom(cubeCoordinates, new CubeCoordinates(0, 0, 0));
    }

    #endregion Public Methods
}