using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class HexTileObjectFinderUtil
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    private static MapObject mapObject;

    #endregion Private Fields

    #region Public Methods

    public static int FindHexTileObjectFireCostFrom(CubeCoordinates cubeCoordinates)
    {
        HexTileObject tileObject = FindHexTileObjectFrom(cubeCoordinates);
        int tileObjectFireCost = int.MaxValue;

        if (tileObject != null)
        {
            HexTileInformationReport hexTileInformationReport = tileObject.GetHexTileInformationReport();
            if (hexTileInformationReport != null)
            {
                HexTileAttributes hexTileAttributes = hexTileInformationReport.GetHexTileAttributes();
                if (hexTileAttributes != null)
                {
                    tileObjectFireCost = hexTileAttributes.GetFireCost();
                    if (hexTileInformationReport.GetTalonIdentificationReport() != null)
                    {
                        tileObjectFireCost += 15; // TODO: Store in a const file
                    }
                }
            }
        }
        return tileObjectFireCost;
    }

    public static HexTileObject FindHexTileObjectFrom(CubeCoordinates cubeCoordinates)
    {
        if (cubeCoordinates != null)
        {
            if (mapObject == null)
            {
                CollectMapModelObject();
            }
            Dictionary<CubeCoordinates, HexTileObject> tileCoordinatesTileObjectDictionary = mapObject.GetCubeCoordinatesHexTileObjectDictionary();
            if (tileCoordinatesTileObjectDictionary.ContainsKey(cubeCoordinates))
            {
                return tileCoordinatesTileObjectDictionary[cubeCoordinates];
            }
        }

        return null;
    }

    public static HashSet<CubeCoordinates> GetNeighborCubeCoordinates(CubeCoordinates cubeCoordinates)
    {
        if (cubeCoordinates != null)
        {
            HexTileObject tileObject = FindHexTileObjectFrom(cubeCoordinates);
            if (tileObject != null)
            {
                HexTileInformationReport hexTileInformationReport = tileObject.GetHexTileInformationReport();
                if (hexTileInformationReport != null)
                {
                    HexTileConstructionReport hexTileConstructionReport = hexTileInformationReport.GetHexTileConstructionReport();
                    if (hexTileConstructionReport != null)
                    {
                        return hexTileConstructionReport.GetNeighborCubeCoordinatesSet();
                    }
                }
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