using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

/// <summary>
/// Map Object Impl
/// </summary>
public class MapObjectImpl
    : MapObject
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    private readonly MapScript mapScript;
    private readonly MapConstructionReport mapConstructionReport;
    private Dictionary<CubeCoordinates, TileObject> cubeCoordinatesTileObjectDictionary;
    private System.Random random;

    #endregion Private Fields

    #region Public Constructors

    public MapObjectImpl(MapScript mapScript, MapConstructionReport mapConstructionReport)
    {
        if (mapScript != null)
        {
            logger.Info("Contructing Object: ?", this.GetType());

            logger.Info("Setting: ?=?", typeof(MapScript), mapScript);
            this.mapScript = mapScript;

            logger.Info("Setting: ?=?", typeof(MapConstructionReport), mapConstructionReport);
            this.mapConstructionReport = mapConstructionReport;

            this.Initialize();
        }
        else
        {
            throw new ArgumentException("Unable to construct " +
                this.GetType() + ". Invalid Parameters." +
                "\n>mapScript is null: " + (mapScript == null));
        }
    }

    #endregion Public Constructors

    #region Public Methods

    public override MapScript GetMapScript()
    {
        return this.mapScript;
    }

    public override Dictionary<CubeCoordinates, TileObject> GetCubeCoordinatesTileObjectDictionary()
    {
        return new Dictionary<CubeCoordinates, TileObject>(this.cubeCoordinatesTileObjectDictionary);
    }

    public override HashSet<CubeCoordinates> GetCubeCoordinatesSet()
    {
        return new HashSet<CubeCoordinates>(this.cubeCoordinatesTileObjectDictionary.Keys);
    }

    public override MapInfoReport GetMapInfoReport()
    {
        if (this.mapConstructionReport != null)
        {
            return this.mapConstructionReport.GetMapInfoReport();
        }
        return null;
    }

    #endregion Public Methods

    #region Private Methods

    private void Initialize()
    {
        this.random = new System.Random(this.mapConstructionReport.GetMapSeed());
        TileObjectFinderUtil.SetMapObject(this);
        HashSet<TileInfoReport> tileInfoReportSet = this.BuildTileInfoReportSet();
        this.cubeCoordinatesTileObjectDictionary = new Dictionary<CubeCoordinates, TileObject>();
        foreach (TileInfoReport tileInfoReport in tileInfoReportSet)
        {
            TileObject tileObject = TileObjectBuilderUtil.BuildTileObject(tileInfoReport);
            if (tileObject != null)
            {
                this.AddTileObject(tileObject);
            }
        }
    }

    private HashSet<TileInfoReport> BuildTileInfoReportSet()
    {
        logger.Debug("Building Set: ?", typeof(TileInfoReport));
        HashSet<CubeCoordinates> cubeCoordinatesSet = CubeCoordinatesGeneratorUtil.GenerateCubeCoordinatesSet(this.mapConstructionReport.GetMapRadius());
        HashSet<TileInfoReport> tileInfoReportSet = TileInfoReportGeneratorUtil.GenerateTileInfoReportSet(
            cubeCoordinatesSet, this.mapConstructionReport.GetMapMirrored(), this.random);
        return tileInfoReportSet;
    }

    private void AddTileObject(TileObject tileObject)
    {
        if (tileObject != null &&
            !this.cubeCoordinatesTileObjectDictionary.ContainsKey(tileObject.GetCubeCoordinates()))
        {
            this.cubeCoordinatesTileObjectDictionary.Add(tileObject.GetCubeCoordinates(), tileObject);

            int layerLevel = CubeCoordinatesCommonUtil.GetCubeCoordinatesDistanceFromCenter(tileObject.GetCubeCoordinates());
            Transform mapTransform = this.mapScript.GetGameObject().transform;
            Transform layerLevelTransform = mapTransform.Find(MapConstants.Script.GetMapLayerLevelGameObjectPrefix() + layerLevel);

            if (layerLevelTransform == null)
            {
                logger.Error("Unable to find " + MapConstants.Script.GetMapLayerLevelGameObjectPrefix() + layerLevel);
            }
            else
            {
                tileObject.GetTileScript().GetGameObject().transform.SetParent(layerLevelTransform);
            }
        }
        else
        {
            logger.Error("Unable to add ?. Invalid Parameters.", typeof(TileObject));
        }
    }

    #endregion Private Methods
}