/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Attributes.HexTiles;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Coordinates;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.HexTile;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Maps.Game;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.HexTiles;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Maps.Game;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Maps.Game;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Builders;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Constants.Maps.Game;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Managers;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Scripts.Unity;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Utils.Coordinates;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Utils.HexTiles;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Objects.Maps.Game
{
    /// <summary>
    /// Map Object Impl
    /// </summary>
    public class GameMapObjectImpl
    : IGameMapObject
    {
        // Provide logging capability
        private static readonly Common.Loggers.Logger logger = new Common.Loggers.Logger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly Dictionary<ICubeCoordinates, IHexTileObject> cubeCoordinatesHexTileObjectDictionary;

        // Todo
        private readonly IGameMapConstructionReport gameMapConstructionReport;

        // Todo
        private readonly IGameMapScript gameMapScript;

        private readonly int maxDistanceFromCenter = int.MinValue;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mapScript">
        /// </param>
        /// <param name="gamMapConstructionReport">
        /// </param>
        public GameMapObjectImpl(IGameMapScript mapScript, IGameMapConstructionReport gamMapConstructionReport)
        {
            if (mapScript != null &&
                gamMapConstructionReport != null)
            {
                logger.Info("Constructing Object: ?", this.GetType());

                this.gameMapScript = mapScript;
                this.gameMapConstructionReport = gamMapConstructionReport;

                HashSet<IHexTileConstructionReport> HexTileConstructionReportSet = HexTileConstructionReportGeneratorUtil
                    .GenerateHexTileInformationReportSet(this.gameMapConstructionReport);
                this.cubeCoordinatesHexTileObjectDictionary = new Dictionary<ICubeCoordinates, IHexTileObject>();
                foreach (IHexTileConstructionReport hexTileConstructionReport in HexTileConstructionReportSet)
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
                    int distanceFromCenter = CubeCoordinatesCommonUtil.GetCubeCoordinatesDistanceFromCenter(
                        hexTileConstructionReport.GetCubeCoordinates());
                    if (distanceFromCenter > this.maxDistanceFromCenter)
                    {
                        this.maxDistanceFromCenter = distanceFromCenter;
                    }
                }

                GameMapObjectManager.SetMapObject(this);
            }
            else
            {
                throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                    "\n\t>" + typeof(IGameMapScript) + " is null: " + (mapScript == null) +
                    "\n\t>" + typeof(IGameMapConstructionReport) + " is null: " + (gamMapConstructionReport == null));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public Dictionary<ICubeCoordinates, IHexTileObject> GetCubeCoordinatesHexTileObjectDictionary()
        {
            return new Dictionary<ICubeCoordinates, IHexTileObject>(this.cubeCoordinatesHexTileObjectDictionary);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public HashSet<ICubeCoordinates> GetCubeCoordinatesSet()
        {
            return new HashSet<ICubeCoordinates>(this.cubeCoordinatesHexTileObjectDictionary.Keys);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public IGameMapInformationReport GetGameMapInformationReport()
        {
            HashSet<IHexTileInformationReport> hexTileInformationReportSet = new HashSet<IHexTileInformationReport>();

            foreach (IHexTileObject hexTileObject in this.cubeCoordinatesHexTileObjectDictionary.Values)
            {
                hexTileInformationReportSet.Add(hexTileObject.GetHexTileInformationReport());
            }

            return ReportBuilder.Maps.Game.Information.GetBuilder()
                .SetHexTileInformationReportSet(hexTileInformationReportSet)
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates">
        /// </param>
        /// <returns>
        /// </returns>
        public int GetHexTileObjectFireCostFrom(ICubeCoordinates cubeCoordinates)
        {
            if (cubeCoordinates != null)
            {
                IHexTileInformationReport hexTileInformationReport = this.GetHexTileObjectFrom(cubeCoordinates)
                    .GetHexTileInformationReport();
                if (hexTileInformationReport != null)
                {
                    IHexTileAttributes hexTileAttributes = hexTileInformationReport.GetHexTileAttributes();
                    if (hexTileAttributes != null)
                    {
                        int tileObjectFireCost = hexTileAttributes.GetFireCost();
                        if (hexTileInformationReport.GetTalonIdentificationReport() != null)
                        {
                            tileObjectFireCost += 15; // TODO: Store in a const file
                        }
                        return tileObjectFireCost;
                    }
                    else
                    {
                        throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ? is null.",
                            new StackFrame().GetMethod().Name, typeof(IHexTileAttributes));
                    }
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ? is null.",
                        new StackFrame().GetMethod().Name, typeof(IHexTileInformationReport));
                }
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ? is null.",
                    new StackFrame().GetMethod().Name, typeof(ICubeCoordinates));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates">
        /// </param>
        /// <returns>
        /// </returns>
        public IHexTileObject GetHexTileObjectFrom(ICubeCoordinates cubeCoordinates)
        {
            if (cubeCoordinates != null)
            {
                if (this.cubeCoordinatesHexTileObjectDictionary.ContainsKey(cubeCoordinates))
                {
                    return this.cubeCoordinatesHexTileObjectDictionary[cubeCoordinates];
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. " +
                        "cubeCoordinatesHexTileObjectDictionary does not track ?.",
                        new StackFrame().GetMethod().Name, cubeCoordinates);
                }
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ? is null.",
                    new StackFrame().GetMethod().Name, typeof(ICubeCoordinates));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public IGameMapConstructionReport GetMapConstructionReport()
        {
            return this.gameMapConstructionReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public IGameMapScript GetMapScript()
        {
            return this.gameMapScript;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public int GetMaxDistanceFromCenter()
        {
            return this.maxDistanceFromCenter;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates">
        /// </param>
        /// <returns>
        /// </returns>
        public HashSet<ICubeCoordinates> GetNeighborCubeCoordinates(ICubeCoordinates cubeCoordinates)
        {
            if (cubeCoordinates != null)
            {
                HashSet<ICubeCoordinates> neighborCubeCoordinatesSet = CubeCoordinatesCommonUtil.GetPossibleNeighborCubeCoordinatesSet(cubeCoordinates);
                neighborCubeCoordinatesSet.IntersectWith(this.cubeCoordinatesHexTileObjectDictionary.Keys);
                return neighborCubeCoordinatesSet;
            }
            else
            {
                throw new ArgumentException("Unable to GetNeighborCubeCoordinates. Invalid parameters.");
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="hexTileObject">
        /// </param>
        private void AddTileObject(IHexTileObject hexTileObject)
        {
            if (hexTileObject != null)
            {
                IHexTileInformationReport hexTileInformationReport = hexTileObject.GetHexTileInformationReport();
                if (hexTileInformationReport != null)
                {
                    IHexTileConstructionReport hexTileConstructionReport = hexTileInformationReport.GetHexTileConstructionReport();
                    if (hexTileConstructionReport != null)
                    {
                        ICubeCoordinates hexTileObjectCubeCoordinates = hexTileConstructionReport.GetCubeCoordinates();
                        this.cubeCoordinatesHexTileObjectDictionary.Add(hexTileObjectCubeCoordinates, hexTileObject);

                        int layerLevel = CubeCoordinatesCommonUtil.GetCubeCoordinatesDistanceFromCenter(hexTileObjectCubeCoordinates);
                        Transform mapTransform = ((UnityScript)this.gameMapScript).GetTransform();
                        Transform layerLevelTransform = mapTransform.Find(GameMapConstants.Script.GetGameMapLayerLevelGameObjectPrefix() + layerLevel);

                        if (layerLevelTransform != null)
                        {
                            hexTileObject.GetHexTileScript().GetGameObject().transform.SetParent(layerLevelTransform);
                        }
                        else
                        {
                            logger.Error("Unable to find " + GameMapConstants.Script.GetGameMapLayerLevelGameObjectPrefix() + layerLevel);
                        }
                    }
                    else
                    {
                        logger.Error("Unable to add ?. {} is null.", typeof(IHexTileObject), typeof(IHexTileConstructionReport));
                    }
                }
                else
                {
                    logger.Error("Unable to add ?. {} is null.", typeof(IHexTileObject), typeof(IHexTileInformationReport));
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
        /// <returns>
        /// </returns>
        private HashSet<IHexTileConstructionReport> BuildTileInfoReportSet()
        {
            return HexTileConstructionReportGeneratorUtil.GenerateHexTileInformationReportSet(this.gameMapConstructionReport);
        }
    }
}