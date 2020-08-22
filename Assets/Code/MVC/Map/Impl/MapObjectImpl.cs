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

    private readonly MapConstructionReport mapInformationReport;
    private readonly MapScript mapScript;
    private Dictionary<CubeCoordinates, HexTileObject> cubeCoordinatesHexTileObjectDictionary;
    private System.Random random;

    #endregion Private Fields

    #region Public Constructors

    public MapObjectImpl(MapScript mapScript, MapConstructionReport mapConstructionReport)
    {
        if (mapScript != null &&
            mapConstructionReport != null)
        {
            logger.Info("Contructing Object: ?", this.GetType());

            this.mapScript = mapScript;
            this.mapInformationReport = mapConstructionReport;

            this.Initialize();
        }
        else
        {
            throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                "\n\t>" + typeof(MapScript) + " is null: " + (mapScript == null) +
                "\n\t>" + typeof(MapConstructionReport) + " is null: " + (mapConstructionReport == null));
        }
    }

    #endregion Public Constructors

    #region Public Methods

    public override Dictionary<CubeCoordinates, HexTileObject> GetCubeCoordinatesHexTileObjectDictionary()
    {
        return new Dictionary<CubeCoordinates, HexTileObject>(this.cubeCoordinatesHexTileObjectDictionary);
    }

    public override HashSet<CubeCoordinates> GetCubeCoordinatesSet()
    {
        return new HashSet<CubeCoordinates>(this.cubeCoordinatesHexTileObjectDictionary.Keys);
    }

    public override MapConstructionReport GetMapConstructionReport()
    {
        return this.mapInformationReport;
    }

    public override MapInformationReport GetMapInformationReport()
    {
        HashSet<HexTileInformationReport> hexTileInformationReportSet = new HashSet<HexTileInformationReport>();

        foreach (HexTileObject hexTileObject in this.cubeCoordinatesHexTileObjectDictionary.Values)
        {
            hexTileInformationReportSet.Add(hexTileObject.GetHexTileInformationReport());
        }

        return new MapInformationReport.Builder()
            .SetHexTileInformationReportSet(hexTileInformationReportSet)
            .Build();
    }

    public override MapScript GetMapScript()
    {
        return this.mapScript;
    }

    #endregion Public Methods

    #region Private Methods

    private void AddTileObject(HexTileObject hexTileObject)
    {
        if (hexTileObject != null)
        {
            HexTileInformationReport hexTileInformationReport = hexTileObject.GetHexTileInformationReport();
            if (hexTileInformationReport != null)
            {
                HexTileConstructionReport hexTileConstructionReport = hexTileInformationReport.GetHexTileConstructionReport();
                if (hexTileConstructionReport != null)
                {
                    CubeCoordinates hexTileObjectCubeCoordinates = hexTileConstructionReport.GetCubeCoordinates();
                    this.cubeCoordinatesHexTileObjectDictionary.Add(hexTileObjectCubeCoordinates, hexTileObject);

                    int layerLevel = CubeCoordinatesCommonUtil.GetCubeCoordinatesDistanceFromCenter(hexTileObjectCubeCoordinates);
                    Transform mapTransform = this.mapScript.GetGameObject().transform;
                    Transform layerLevelTransform = mapTransform.Find(MapConstants.Script.GetMapLayerLevelGameObjectPrefix() + layerLevel);

                    if (layerLevelTransform == null)
                    {
                        logger.Error("Unable to find " + MapConstants.Script.GetMapLayerLevelGameObjectPrefix() + layerLevel);
                    }
                    else
                    {
                        hexTileObject.GetHexTileScript().GetGameObject().transform.SetParent(layerLevelTransform);
                    }
                }
                else
                {
                    logger.Error("Unable to add ?. {} is null.", typeof(HexTileObject), typeof(HexTileConstructionReport));
                }
            }
            else
            {
                logger.Error("Unable to add ?. {} is null.", typeof(HexTileObject), typeof(HexTileInformationReport));
            }
        }
        else
        {
            logger.Error("Unable to add ?. {} is null.", typeof(HexTileObject), typeof(HexTileObject));
        }
    }

    private HashSet<HexTileConstructionReport> BuildTileInfoReportSet()
    {
        HashSet<CubeCoordinates> cubeCoordinatesSet = CubeCoordinatesGeneratorUtil.GenerateCubeCoordinatesSet(this.mapInformationReport.GetMapRadius());
        HashSet<HexTileConstructionReport> hexTileInformationReportSet = HexTileConstructionReportGeneratorUtil
            .GenerateHexTileInformationReportSet(cubeCoordinatesSet, this.mapInformationReport.GetMapMirrored(), this.random);
        return hexTileInformationReportSet;
    }

    private void Initialize()
    {
        this.random = new System.Random(this.mapInformationReport.GetMapSeed());
        HexTileObjectFinderUtil.SetMapObject(this);
        HashSet<HexTileConstructionReport> HexTileConstructionReportSet = this.BuildTileInfoReportSet();
        this.cubeCoordinatesHexTileObjectDictionary = new Dictionary<CubeCoordinates, HexTileObject>();
        foreach (HexTileConstructionReport hexTileConstructionReport in HexTileConstructionReportSet)
        {
            HexTileObject hexTileObject = HexTileObjectBuilderUtil.BuildHexTileObject(hexTileConstructionReport);
            if (hexTileObject != null)
            {
                this.AddTileObject(hexTileObject);
            }
            else
            {
                logger.Error("Unable to add ?. {} is null.", typeof(HexTileObject), typeof(HexTileObject));
            }
        }
    }

    #endregion Private Methods
}