using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

/// <summary>
/// Todo
/// </summary>
public class TileObjectFinderUtil
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    private static MapObject mapObject;

    #endregion Private Fields

    #region Public Methods

    public static int FindTileObjectFireCostFrom(CubeCoordinates cubeCoordinates)
    {
        TileObject tileObject = FindTileObjectFrom(cubeCoordinates);
        int tileObjectFireCost = (tileObject != null)
            ? tileObject.GetTileObjectFireCost()
            : int.MinValue;
        return tileObjectFireCost;
    }

    public static TileObject FindTileObjectFrom(CubeCoordinates cubeCoordinates)
    {
        if (cubeCoordinates != null)
        {
            if (mapObject == null)
            {
                CollectMapModelObject();
            }
            Dictionary<CubeCoordinates, TileObject> tileCoordinatesTileObjectDictionary = mapObject.GetCubeCoordinatesTileObjectDictionary();
            if (tileCoordinatesTileObjectDictionary.ContainsKey(cubeCoordinates))
            {
                return tileCoordinatesTileObjectDictionary[cubeCoordinates];
            }
        }

        return null;
    }

    public static HashSet<CubeCoordinates> GetNeighborCubeCoordinates(CubeCoordinates tileCoordinates)
    {
        if (tileCoordinates != null)
        {
            TileObject tileObject = FindTileObjectFrom(tileCoordinates);
            if (tileObject != null)
            {
                return tileObject.GetNeighborCubeCoordinates();
            }
        }
        return new HashSet<CubeCoordinates>();
    }

    public static HashSet<CubeCoordinates> GetTileCoordinatesSet()
    {
        if (mapObject == null)
        {
            CollectMapModelObject();
        }
        return mapObject.GetCubeCoordinatesSet();
    }

    public static void SetMapObject(MapObject newMapObject)
    {
        mapObject = newMapObject;
    }

    #endregion Public Methods

    #region Private Methods

    private static void CollectMapModelObject()
    {
        GameObject gameObject = FinderUtil.FindGameObjectType(typeof(MapScript));
        if (gameObject.GetComponent<MapScript>())
        {
            MapObject newMapObject = gameObject.GetComponent<MapScript>().GetMapObject();
            if (newMapObject != null)
            {
                mapObject = newMapObject;
            }
        }
    }

    #endregion Private Methods
}