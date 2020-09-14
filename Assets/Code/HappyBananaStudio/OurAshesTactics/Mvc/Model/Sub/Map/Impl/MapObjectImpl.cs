/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Mvc.Coordinates.Cube;
using HappyBananaStudio.OurAshesTactics.Mvc.Coordinates.Util;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Reports;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Util;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Map.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Map.Constants;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Map.Reports;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Map.Impl
{
    /// <summary>
    /// Map Object Impl
    /// </summary>
    public class MapObjectImpl
    : IMapObject
    {
        #region Private Fields

        // Provide logging capability
        private static readonly Common.Logging.Logger logger = new Common.Logging.Logger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly MapConstructionReport mapInformationReport;

        // Todo
        private readonly MapScript mapScript;

        // Todo
        private Dictionary<CubeCoordinates, IHexTileObject> cubeCoordinatesHexTileObjectDictionary;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mapScript">            </param>
        /// <param name="mapConstructionReport"></param>
        public MapObjectImpl(MapScript mapScript, MapConstructionReport mapConstructionReport)
        {
            if (mapScript != null &&
                mapConstructionReport != null)
            {
                logger.Info("Contructing Object: ?", this.GetType());

                this.mapScript = mapScript;
                this.mapInformationReport = mapConstructionReport;

                HashSet<HexTileConstructionReport> HexTileConstructionReportSet = this.BuildTileInfoReportSet();
                this.cubeCoordinatesHexTileObjectDictionary = new Dictionary<CubeCoordinates, IHexTileObject>();
                foreach (HexTileConstructionReport hexTileConstructionReport in HexTileConstructionReportSet)
                {
                    IHexTileObject hexTileObject = HexTileObjectBuilderUtil.BuildHexTileObject(hexTileConstructionReport);
                    if (hexTileObject != null)
                    {
                        this.AddTileObject(hexTileObject);
                    }
                    else
                    {
                        logger.Error("Unable to add ?. ? produced null.", typeof(IHexTileObject), hexTileConstructionReport);
                    }
                }

                HexTileObjectFinderUtil.SetMapObject(this);
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

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public Dictionary<CubeCoordinates, IHexTileObject> GetCubeCoordinatesHexTileObjectDictionary()
        {
            return new Dictionary<CubeCoordinates, IHexTileObject>(this.cubeCoordinatesHexTileObjectDictionary);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public HashSet<CubeCoordinates> GetCubeCoordinatesSet()
        {
            return new HashSet<CubeCoordinates>(this.cubeCoordinatesHexTileObjectDictionary.Keys);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public MapConstructionReport GetMapConstructionReport()
        {
            return this.mapInformationReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public MapInformationReport GetMapInformationReport()
        {
            HashSet<HexTileInformationReport> hexTileInformationReportSet = new HashSet<HexTileInformationReport>();

            foreach (IHexTileObject hexTileObject in this.cubeCoordinatesHexTileObjectDictionary.Values)
            {
                hexTileInformationReportSet.Add(hexTileObject.GetHexTileInformationReport());
            }

            return new MapInformationReport.Builder()
                .SetHexTileInformationReportSet(hexTileInformationReportSet)
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public MapScript GetMapScript()
        {
            return this.mapScript;
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="hexTileObject"></param>
        private void AddTileObject(IHexTileObject hexTileObject)
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

                        if (layerLevelTransform != null)
                        {
                            hexTileObject.GetHexTileScript().GetGameObject().transform.SetParent(layerLevelTransform);
                        }
                        else
                        {
                            logger.Error("Unable to find " + MapConstants.Script.GetMapLayerLevelGameObjectPrefix() + layerLevel);
                        }
                    }
                    else
                    {
                        logger.Error("Unable to add ?. {} is null.", typeof(IHexTileObject), typeof(HexTileConstructionReport));
                    }
                }
                else
                {
                    logger.Error("Unable to add ?. {} is null.", typeof(IHexTileObject), typeof(HexTileInformationReport));
                }
            }
            else
            {
                logger.Error("Unable to add ?. {} is null.", typeof(IHexTileObject), typeof(IHexTileObject));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private HashSet<HexTileConstructionReport> BuildTileInfoReportSet()
        {
            HashSet<CubeCoordinates> cubeCoordinatesSet = CubeCoordinatesGeneratorUtil.GenerateCubeCoordinatesSet(this.mapInformationReport.GetMapRadius());
            HashSet<HexTileConstructionReport> hexTileInformationReportSet = HexTileConstructionReportGeneratorUtil
                .GenerateHexTileInformationReportSet(cubeCoordinatesSet, this.mapInformationReport.GetMapMirrored());
            return hexTileInformationReportSet;
        }

        #endregion Private Methods
    }
}