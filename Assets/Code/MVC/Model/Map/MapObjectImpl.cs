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
    #region Protected Fields

    protected Dictionary<CubeCoordinates, TileObject> cubeCoordinatesTileObjectDictionary;

    #endregion Protected Fields

    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    private readonly MapScript mapScript;
    private readonly MapConstructionReport mapConstructionReport;

    #endregion Private Fields

    #region Public Constructors

    public MapObjectImpl(MapScript mapScript, MapConstructionReport mapConstructionReport)
    {
        if (mapScript != null)
        {
            logger.Info("Contructing Object: ?", this.GetType());

            logger.Info("Setting Script: ?=?", typeof(MapScript), mapScript);
            this.mapScript = mapScript;

            logger.Info("Setting Report: ?=?", typeof(MapConstructionReport), mapConstructionReport);
            this.mapConstructionReport = mapConstructionReport;
        }
        else
        {
            throw new ArgumentException("Unable to construct ? " +
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

    public override bool IsInitialized()
    {
        return this.cubeCoordinatesTileObjectDictionary != null;
    }

    public override Dictionary<CubeCoordinates, TileObject> GetCubeCoordinatesTileObjectDictionary()
    {
        return new Dictionary<CubeCoordinates, TileObject>(this.cubeCoordinatesTileObjectDictionary);
    }

    public override HashSet<CubeCoordinates> GetCubeCoordinatesSet()
    {
        return new HashSet<CubeCoordinates>(this.cubeCoordinatesTileObjectDictionary.Keys);
    }

    public override void Initialize()
    {
        if (!this.IsInitialized())
        {
            UnityEngine.Random.InitState(this.mapConstructionReport.GetMapSeed());
            // Todo: Do this thing
            //TileObjectFinderUtil.SetMapModelObject(this)
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
        else
        {
        }
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

    private HashSet<TileInfoReport> BuildTileInfoReportSet()
    {
        logger.Debug("Building Set: ?", typeof(TileInfoReport));
        HashSet<CubeCoordinates> cubeCoordinatesSet = CubeCoordinatesGeneratorUtil.GenerateCubeCoordinatesSet(this.mapConstructionReport.GetMapRadius());
        HashSet<TileInfoReport> tileInfoReportSet = TileInfoReportGeneratorUtil.GenerateTileInfoReportSet(
            cubeCoordinatesSet, this.mapConstructionReport.GetMapMirrored());
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
            Transform layerLevelTransform = mapTransform.Find(MvcModelConstants.Script.GetMapLayerLevelGameObjectPrefix() + layerLevel);

            if (layerLevelTransform == null)
            {
                logger.Error("Unable to find " + MvcModelConstants.Script.GetMapLayerLevelGameObjectPrefix() + layerLevel);
            }

            tileObject.GetTileScript().GetGameObject().transform.SetParent(layerLevelTransform);
        }
        else
        {
            logger.Error("Unable to add ?. Invalid Parameters.", typeof(TileObject));
        }
    }

    #endregion Private Methods
}