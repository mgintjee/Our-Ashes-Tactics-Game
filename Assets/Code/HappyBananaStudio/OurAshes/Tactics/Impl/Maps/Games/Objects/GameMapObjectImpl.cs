/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>
/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

namespace HappyBananaStudio.OurAshesTactics.Impl.Objects.Maps.Game
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Coordinates.Objects.Cube;
    using HappyBananaStudio.OurAshes.Tactics.Api.HexTiles.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Api.HexTiles.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.HexTiles.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Api.Loggers;
    using HappyBananaStudio.OurAshes.Tactics.Api.Maps.Games.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.Maps.Games.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Common.Constants.HexTiles.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Common.Managers.CodeObjects;
    using HappyBananaStudio.OurAshes.Tactics.Common.Managers.GameObjects;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Loggers;
    using HappyBananaStudio.OurAshesTactics.Common.Utils.Coordinates;
    using HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions;
    using HappyBananaStudio.OurAshesTactics.Common.Utils.HexTiles;
    using HappyBananaStudio.OurAshesTactics.Impl.Objects.HexTiles;
    using HappyBananaStudio.OurAshesTactics.Impl.Reports.Maps.Game;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Map Object Impl
    /// </summary>
    public class GameMapObjectImpl
    : IGameMapObject
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLoggerImpl(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly IDictionary<ICubeCoordinates, IHexTileObject> cubeCoordinatesHexTileObjectDictionary;

        // Todo
        private readonly IGameMapConstructionReport gameMapConstructionReport;

        // Todo
        private readonly int maxDistanceFromCenter = int.MinValue;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="gameMapConstructionReport">
        /// </param>
        public GameMapObjectImpl(IGameMapConstructionReport gameMapConstructionReport)
        {
            if (gameMapConstructionReport != null)
            {
                logger.Info("Constructing Object: ?", this.GetType());
                this.gameMapConstructionReport = gameMapConstructionReport;

                ISet<IHexTileConstructionReport> HexTileConstructionReportSet = HexTileConstructionReportGeneratorUtil
                    .GenerateHexTileInformationReportSet(this.gameMapConstructionReport);
                this.cubeCoordinatesHexTileObjectDictionary = new Dictionary<ICubeCoordinates, IHexTileObject>();
                foreach (IHexTileConstructionReport hexTileConstructionReport in HexTileConstructionReportSet)
                {
                    ICubeCoordinates hexTileObjectCubeCoordinates = hexTileConstructionReport.GetCubeCoordinates();
                    this.cubeCoordinatesHexTileObjectDictionary.Add(hexTileObjectCubeCoordinates,
                        new HexTileObjectImpl(hexTileConstructionReport));
                    HexTileGameObjectManager.BuildHexTileGameObject(hexTileConstructionReport);
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
                    "\n\t>" + typeof(IGameMapConstructionReport) + " is null: " + (gameMapConstructionReport == null));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IDictionary<ICubeCoordinates, IHexTileObject> IGameMapObject.GetCubeCoordinatesHexTileObjectDictionary()
        {
            return new Dictionary<ICubeCoordinates, IHexTileObject>(this.cubeCoordinatesHexTileObjectDictionary);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ISet<ICubeCoordinates> IGameMapObject.GetCubeCoordinatesSet()
        {
            return new HashSet<ICubeCoordinates>(this.cubeCoordinatesHexTileObjectDictionary.Keys);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IGameMapConstructionReport IGameMapObject.GetGameMapConstructionReport()
        {
            return this.gameMapConstructionReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IGameMapInformationReport IGameMapObject.GetGameMapInformationReport()
        {
            ISet<IHexTileInformationReport> hexTileInformationReportSet = new HashSet<IHexTileInformationReport>();

            foreach (IHexTileObject hexTileObject in this.cubeCoordinatesHexTileObjectDictionary.Values)
            {
                hexTileInformationReportSet.Add(hexTileObject.GetHexTileInformationReport());
            }

            return new GameMapInformationReportImpl.Builder()
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
        int IGameMapObject.GetHexTileObjectFireCostFrom(ICubeCoordinates cubeCoordinates)
        {
            // TODO: Move into a static class that will handle all of this by just querying the attributes struct in the constants
            if (cubeCoordinates != null)
            {
                IHexTileInformationReport hexTileInformationReport = this.cubeCoordinatesHexTileObjectDictionary[cubeCoordinates]
                    .GetHexTileInformationReport();
                if (hexTileInformationReport != null)
                {
                    IHexTileAttributes hexTileAttributes = HexTileAttributesConstants.GetAttributes(hexTileInformationReport.GetHexTileType());
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
        IHexTileObject IGameMapObject.GetHexTileObjectFrom(ICubeCoordinates cubeCoordinates)
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
        int IGameMapObject.GetMaxDistanceFromCenter()
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
        ISet<ICubeCoordinates> IGameMapObject.GetNeighborCubeCoordinates(ICubeCoordinates cubeCoordinates)
        {
            if (cubeCoordinates != null)
            {
                ISet<ICubeCoordinates> neighborCubeCoordinatesSet = CubeCoordinatesCommonUtil
                    .GetPossibleNeighborCubeCoordinatesSet(cubeCoordinates);
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
                    /*
                    IHexTileConstructionReport hexTileConstructionReport = hexTileInformationReport.GetHexTileConstructionReport();
                    if (hexTileConstructionReport != null)
                    {
                        ICubeCoordinates hexTileObjectCubeCoordinates = hexTileConstructionReport.GetCubeCoordinates();
                        this.CubeCoordinatesHexTileObjectDictionary.Add(hexTileObjectCubeCoordinates, hexTileObject);

                        int layerLevel = CubeCoordinatesCommonUtil.GetCubeCoordinatesDistanceFromCenter(hexTileObjectCubeCoordinates);
                        Transform mapTransform = ((UnityScriptImpl)this.gameMapScript).GetTransform();
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
                    */
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
        private ISet<IHexTileConstructionReport> BuildTileInfoReportSet()
        {
            return HexTileConstructionReportGeneratorUtil.GenerateHexTileInformationReportSet(
                this.gameMapConstructionReport);
        }
    }
}
