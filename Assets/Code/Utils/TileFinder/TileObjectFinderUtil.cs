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

    private static MapModelObject mapModelObject;

    #endregion Private Fields

    #region Public Methods

    public static int FindTileObjectFireCostFrom(CubeCoordinates cubeCoordinates)
    {
        TileObject tileObject = FindTileObjectFrom(cubeCoordinates);
        int tileObjectFireCost = (tileObject != null)
            ? tileObject.GetTileObjectFireCost()
            : int.MinValue;
        logger.Debug("CubeCoordinates: ?, Cost=?", cubeCoordinates, tileObjectFireCost);
        return tileObjectFireCost;
    }

    public static TileObject FindTileObjectFrom(CubeCoordinates cubeCoordinates)
    {
        if (cubeCoordinates != null)
        {
            if (mapModelObject == null)
            {
                CollectMapModelObject();
            }
            Dictionary<CubeCoordinates, TileObject> tileCoordinatesTileObjectDictionary = mapModelObject.GetTileCoordsTileObjectDictionary();
            if (tileCoordinatesTileObjectDictionary.ContainsKey(cubeCoordinates))
            {
                return tileCoordinatesTileObjectDictionary[cubeCoordinates];
            }
            else
            {
                logger.Debug("Unable to Find TileObject from CubeCoordinates=?. MapModelObject does not contain the TileCoordinates.", cubeCoordinates);
            }
        }
        else
        {
            logger.Debug("Unable to Find TileObject from CubeCoordinates. Parameterized TileCoordinates is null.");
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
            else
            {
                logger.Debug("Unable to Find Neighbor Set: TileCoordinates from TileCoordinates. TileObject is null.");
            }
        }
        else
        {
            logger.Debug("Unable to Find Neighbor Set: TileCoordinates  from TileCoordinates. Parameterized TileCoordinates is null.");
        }
        return new HashSet<CubeCoordinates>();
    }

    public static HashSet<CubeCoordinates> GetTileCoordinatesSet()
    {
        if (mapModelObject == null)
        {
            CollectMapModelObject();
        }
        return mapModelObject.GetValidTileCoordinatesSet();
    }

    public static void SetMapModelObject(MapModelObject newMapModelObject)
    {
        mapModelObject = newMapModelObject;
    }

    #endregion Public Methods

    #region Private Methods

    private static void CollectMapModelObject()
    {
        GameObject gameObject = FinderUtil.FindGameObjectType(typeof(MapModelScript));
        if (gameObject.GetComponent<MapModelScript>())
        {
            MapModelObject newMapModelObject = gameObject.GetComponent<MapModelScript>().GetMapModelObject();
            if (newMapModelObject != null)
            {
                mapModelObject = newMapModelObject;
            }
            else
            {
                logger.Error("Error collecting MapModelObject. GameObject: Name=?, does not have an available MapModelObject.", gameObject.name);
            }
        }
        else
        {
            logger.Error("Error collecting MapModelObject. GameObject: Name=?, does not have a MapModelScript.", gameObject.name);
        }
    }

    #endregion Private Methods
}