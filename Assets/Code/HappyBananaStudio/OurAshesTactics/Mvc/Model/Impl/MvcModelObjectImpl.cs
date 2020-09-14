/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Common.Logging;
using HappyBananaStudio.OurAshesTactics.Mvc.Coordinates.Cube;
using HappyBananaStudio.OurAshesTactics.Mvc.Framework.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Initializer.Reports;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Reports;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Util;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Map.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Roster.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Enums;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Reports;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Impl
{
    /// <summary>
    /// MvcModel Object Impl
    /// </summary>
    public class MvcModelObjectImpl
    : IMvcModelObject
    {
        #region Private Fields

        // Provide logging capability
        private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly IMapObject mapObject = null;

        // Todo
        private readonly MvcModelScript mvcModelScript;

        // Todo
        private readonly IRosterObject rosterObject = null;

        // Todo
        private int counterAction = 0;

        // Todo
        private int counterPhase = 0;

        // Todo
        private IMvcFrameworkObject mvcFrameworkObject;

        // Todo
        private MvcInitializationReport mvcInitializationReport;

        // Todo
        private List<TalonIdentificationReport> orderedTalonIdentificationReportList =
            new List<TalonIdentificationReport>();

        // Todo
        private bool processingActionReport = false;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcModelScript"></param>
        /// <param name="mapScript">     </param>
        public MvcModelObjectImpl(MvcModelScript mvcModelScript, MapScript mapScript, RosterScript rosterScript)
        {
            if (mvcModelScript != null &&
                mapScript != null &&
                rosterScript != null)
            {
                logger.Info("Contructing: ?", this.GetType());
                this.mvcModelScript = mvcModelScript;
                this.mapObject = mapScript.GetMapObject();
                this.rosterObject = rosterScript.GetRosterObject();
            }
            else
            {
                throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                    "\n\t>" + typeof(MvcModelScript) + " is null: " + (mvcModelScript == null) +
                    "\n\t>" + typeof(MapScript) + " is null: " + (mapScript == null) +
                    "\n\t>" + typeof(RosterScript) + " is null: " + (rosterScript == null));
            }
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public bool ContinueGame()
        {
            return this.CheckWinConditions();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public HashSet<TalonIdentificationReport> GetActiveTalonIdentificationReportSet()
        {
            return this.rosterObject.GetActiveTalonIdentificationReportSet();
        }

        public TalonIdentificationReport GetCurrentTalonIdentificationReport()
        {
            if (this.orderedTalonIdentificationReportList.Count == 0)
            {
                this.orderedTalonIdentificationReportList = this.rosterObject.GetOrderedTalonIdentificationReportList();
                this.rosterObject.ResetAllTalonBehaviorMoveable();
            }
            return this.orderedTalonIdentificationReportList[0];
        }

        public MvcModelInformationReport GetMvcModelInformationReport()
        {
            return new MvcModelInformationReport.Builder()
                .SetMapInformationReport(this.mapObject.GetMapInformationReport())
                .SetRosterInformationReport(this.rosterObject.GetRosterInformationReport())
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public MvcModelScript GetMvcModelScript()
        {
            return this.mvcModelScript;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public List<TalonIdentificationReport> GetOrderedTalonIdentificationReportList()
        {
            return new List<TalonIdentificationReport>(this.orderedTalonIdentificationReportList);
        }

        public TalonInformationReport GetTalonInformationReport(TalonIdentificationReport talonIdentificationReport)
        {
            return this.rosterObject.GetTalonInformationReport(talonIdentificationReport);
        }

        /*
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public override TalonInformationReport GetCurrentTalonInformationReport()
        {
            logger.Debug("GetCurrentTalonInformationReport");

            TalonInformationReport talonInformationReport = null;
            if (this.orderedTalonIdentificationReportList == null ||
                    this.orderedTalonIdentificationReportList.Count < 1)
            {
                this.orderedTalonIdentificationReportList = this.GenerateTalonObjectTurnList();
            }

            logger.Debug("talonObjectOrderList=?", string.Join(",\n", this.orderedTalonIdentificationReportList));

            if (this.orderedTalonIdentificationReportList.Count > 0)
            {
                TalonObject talonObject = this.orderedTalonIdentificationReportList[0];
                TalonIdentificationReport talonIdentificationReport = talonObject.GetTalonIdentificationReport();
                talonInformationReport = this.GetTalonInformationReport(talonIdentificationReport);
            }

            logger.Debug("Found ?=?", typeof(TalonInformationReport), talonInformationReport);
            return talonInformationReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public override List<TalonObject> GetCurrentTalonObjectTurnList()
        {
            if (this.orderedTalonIdentificationReportList == null)
            {
                this.orderedTalonIdentificationReportList = this.GenerateTalonObjectTurnList();
            }
            return new List<TalonObject>(this.orderedTalonIdentificationReportList);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public override MvcModelInformationReport GetMvcModelInformationReport()
        {
            Dictionary<TalonIdentificationReport, TalonInformationReport> talonIdentificationInformationReportDictionary =
                new Dictionary<TalonIdentificationReport, TalonInformationReport>();

            foreach (TalonIdentificationReport talonIdentificationReport in this.talonIdentificationReportObjectDictionary.Keys)
            {
                talonIdentificationInformationReportDictionary.Add(talonIdentificationReport,
                    this.talonIdentificationReportObjectDictionary[talonIdentificationReport].GetTalonInformationReport());
            }

            return new MvcModelInformationReport.Builder()
                .SetMapInformationReport(this.mapObject.GetMapInformationReport())
                .SetTalonIdentificationInformationReportDictionary(talonIdentificationInformationReportDictionary)
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public override MvcModelScript GetMvcModelScript()
        {
            return this.mvcModelScript;
        }

        public override List<TalonIdentificationReport> GetOrderedTalonIdentificationReportList()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonIdentificationReport"></param>
        /// <returns></returns>
        public override TalonInformationReport GetTalonInformationReport(TalonIdentificationReport talonIdentificationReport)
        {
            logger.Debug("GetTalonInformationReport: ?=?", typeof(TalonIdentificationReport), talonIdentificationReport);
            TalonInformationReport talonInformationReport = null;
            if (this.talonIdentificationInformationDictionary.ContainsKey(talonIdentificationReport))
            {
                talonInformationReport = this.talonIdentificationInformationDictionary[talonIdentificationReport];
            }
            else
            {
                if (this.talonIdentificationReportObjectDictionary.ContainsKey(talonIdentificationReport))
                {
                    TalonObject talonObject = this.talonIdentificationReportObjectDictionary[talonIdentificationReport];
                    talonInformationReport = talonObject.GetTalonInformationReport();
                    this.talonIdentificationInformationDictionary.Add(talonIdentificationReport, talonInformationReport);
                    logger.Debug("Cache ? for ?", talonInformationReport, talonIdentificationReport);
                }
            }

            if (talonInformationReport == null)
            {
                logger.Warn("Unable to GetTalonInformationReport. ?=? is no longer tracked.", typeof(TalonIdentificationReport), talonIdentificationReport);
            }

            return talonInformationReport;
        }
        */

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameworkObject">     </param>
        /// <param name="mvcInitializationReport"></param>
        public void Initialize(IMvcFrameworkObject mvcFrameworkObject, MvcInitializationReport mvcInitializationReport)
        {
            logger.Info("Initializing: ?", this.GetType());
            if (!this.IsInitialized())
            {
                if (mvcFrameworkObject != null &&
                mvcInitializationReport != null)
                {
                    this.mvcFrameworkObject = mvcFrameworkObject;
                    this.mvcInitializationReport = mvcInitializationReport;
                    int mapRadius = this.mvcInitializationReport.GetMapConstructionReport().GetMapRadius();
                    Dictionary<TalonPhalanxIdEnum, int> talonPhalanxIdCountDictionary = new Dictionary<TalonPhalanxIdEnum, int>();

                    foreach (TalonIdentificationReport talonIdentificationReport in this.rosterObject.GetAllTalonIdentificationReportSet())
                    {
                        // TalonIdentificationReport talonIdentificationReport = talonIdentificationReport.GetTalonIdentificationReport();
                        if (!talonPhalanxIdCountDictionary.ContainsKey(talonIdentificationReport.GetTalonPhalanxId()))
                        {
                            talonPhalanxIdCountDictionary.Add(talonIdentificationReport.GetTalonPhalanxId(),
                                this.rosterObject.GetAllTalonIdentificationReportSet(talonIdentificationReport.GetTalonPhalanxId()).Count);
                        }
                        CubeCoordinates spawnCubeCoordinates = TalonSpawnCubeCoordinatesUtil.GetSpawningCubeCoordinatesFor(
                            talonIdentificationReport.GetTalonPhalanxId(),
                            talonPhalanxIdCountDictionary[talonIdentificationReport.GetTalonPhalanxId()],
                            talonIdentificationReport.GetTalonPhalanxIndex(),
                            mapRadius);
                        IHexTileObject hexTileObject = HexTileObjectFinderUtil.FindHexTileObjectFrom(spawnCubeCoordinates);
                        if (hexTileObject != null)
                        {
                            this.rosterObject.GetTalonObject(talonIdentificationReport).SetCubeCoordinates(spawnCubeCoordinates);
                            hexTileObject.SetOccupyingTalonIdentificationReport(talonIdentificationReport);
                        }
                        else
                        {
                            logger.Debug("?=? is not valid", typeof(CubeCoordinates), spawnCubeCoordinates);
                        }
                    }
                }
                else
                {
                    throw new ArgumentException("Unable to initialize ?" + this.GetType() + ". Invalid Parameters." +
                        "\n\t>" + typeof(IMvcFrameworkObject) + " is null: " + (mvcFrameworkObject == null) +
                        "\n\t>" + typeof(MvcInitializationReport) + " is null: " + (mvcInitializationReport == null));
                }
            }
            else
            {
                logger.Warn("Unable to Initialize: ?. Already initialized.", this.GetType());
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonActionOrderReport"></param>
        /// <returns></returns>
        public TalonTurnResultReport InputTalonActionOrderReport(TalonActionOrderReport talonActionOrderReport)
        {
            if (talonActionOrderReport != null)
            {
                /*
                TalonIdentificationReport actingTalonIdentificationReport = talonActionOrderReport.GetActingTalonIdentificationReport();
                if (actingTalonIdentificationReport != null &&
                        this.talonIdentificationReportObjectDictionary.ContainsKey(actingTalonIdentificationReport))
                {
                    TalonObject actingTalonObject = this.talonIdentificationReportObjectDictionary[actingTalonIdentificationReport];
                    if (actingTalonObject != null)
                    {
                        this.processingActionReport = true;
                        logger.Info("Phase: ? Action:?) Inputting ?=?", this.counterPhase, this.counterAction, typeof(TalonActionOrderReport), talonActionOrderReport);
                        LineRendererUtil.DrawPath(talonActionOrderReport.GetPathObject());
                        TalonCombatResultReport talonCombatResultReport = null;
                        TalonActionResultReport talonActionResultReport = actingTalonObject.InputTalonActionOrderReport(talonActionOrderReport);

                        if (talonActionOrderReport.GetTalonActionType().Equals(TalonActionTypeEnum.Fire))
                        {
                            TalonCombatOrderReport talonCombatOrderReport = actingTalonObject.GetTalonCombatOrderReport((PathObjectFire)talonActionOrderReport.GetPathObject());

                            logger.Info("?=?", typeof(TalonCombatOrderReport), talonCombatOrderReport);
                            TalonIdentificationReport targetTalonIdentificationReport = talonActionOrderReport.GetTargetTalonIdentificationReport();
                            if (targetTalonIdentificationReport != null &&
                                    this.talonIdentificationReportObjectDictionary.ContainsKey(targetTalonIdentificationReport))
                            {
                                TalonObject targetTalonObject = this.talonIdentificationReportObjectDictionary[targetTalonIdentificationReport];
                                if (targetTalonObject != null)
                                {
                                    talonCombatResultReport = targetTalonObject.InputTalonCombatOrderReport(talonCombatOrderReport);
                                    logger.Info("?=?", typeof(TalonCombatResultReport), talonCombatResultReport);
                                    if (talonCombatResultReport.GetIsTargetDestroyed())
                                    {
                                        logger.Info("Destroy ?=?", typeof(TalonIdentificationReport), targetTalonIdentificationReport);
                                        this.DestroyTalon(targetTalonIdentificationReport);
                                    }
                                }
                                else
                                {
                                    logger.Error("Unable to input ?. Target ? is null.", typeof(TalonActionOrderReport), typeof(TalonObject));
                                }
                            }
                            else
                            {
                                logger.Error("Unable to input ?. Target ? is null.", typeof(TalonActionOrderReport), typeof(TalonIdentificationReport));
                            }
                        }

                        TalonAttributesReport talonAttributesReport = talonActionResultReport.GetTalonAttributesReport();
                        if (talonAttributesReport.GetTurnPoints() < 1)
                        {
                            logger.Debug("? completed their turn.", actingTalonIdentificationReport);
                            this.talonObjectOrderList.Remove(actingTalonObject);
                        }

                        this.talonIdentificationInformationDictionary = new Dictionary<TalonIdentificationReport, TalonInformationReport>();
                        this.processingActionReport = false;
                        this.counterAction++;

                        return new TalonTurnReport.Builder()
                            .SetPhaseCounter(this.counterPhase)
                            .SetActionCounter(this.counterAction)
                            .SetTalonActionResultReport(talonActionResultReport)
                            .SetTalonCombatResultReport(talonCombatResultReport)
                            .SetMapInformationReport(this.mapObject.GetMapInformationReport())
                            .Build();
                    }
                    else
                    {
                        throw new ArgumentException("Unable to InputTalonActionOrderReport. Invalid Parameters." +
                            "\n\t>" + typeof(TalonObject) + " is null");
                    }
                }
                else
                {
                    throw new ArgumentException("Unable to InputTalonActionOrderReport. Invalid Parameters." +
                        "\n\t>" + typeof(TalonIdentificationReport) + " is null");
                }
                */
            }
            else
            {
                throw new ArgumentException("Unable to InputTalonActionOrderReport. Invalid Parameters." +
                    "\n\t>" + typeof(TalonActionOrderReport) + " is null");
            }
            return null;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public bool IsInitialized()
        {
            return this.mvcFrameworkObject != null &&
                this.mvcInitializationReport != null;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public bool IsProcessingActionReport()
        {
            return this.processingActionReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public void StartGame()
        {
            //this.mechObjectTurnList = this.GenerateTalonObjectTurnList();
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonObject"></param>
        private void AddTalonObject(ITalonObject talonObject)
        {
            // Check that parameters are non-null
            if (talonObject != null)
            {
                /*
                TalonIdentificationReport talonIdentificationReport = talonObject.GetTalonIdentificationReport();
                if (talonIdentificationReport != null)
                {
                    if (!this.talonIdentificationReportObjectDictionary.ContainsKey(talonIdentificationReport))
                    {
                        this.talonIdentificationReportObjectDictionary.Add(talonIdentificationReport, talonObject);
                    }
                    else
                    {
                        logger.Error("Unable to add ?. talonIdentificationReportObjectDictionary contains ?.", typeof(TalonObject), talonIdentificationReport);
                    }
                    TalonPhalanxIdEnum talonPhalanxId = talonIdentificationReport.GetTalonPhalanxId();
                    if (!this.talonPhalanxIdTalonIdentificationReportDictionary.ContainsKey(talonPhalanxId))
                    {
                        // Add the PhalanxId key and an empty Set: TalonIdentificationReport
                        this.talonPhalanxIdTalonIdentificationReportDictionary.Add(talonPhalanxId,
                            new HashSet<TalonIdentificationReport>());
                    }
                    this.talonPhalanxIdTalonIdentificationReportDictionary[talonPhalanxId].Add(talonIdentificationReport);
                    TalonFactionIdEnum talonFactionId = talonIdentificationReport.GetTalonFactionId();
                    if (!this.talonFactionIdPhalanxIdDictionary.ContainsKey(talonFactionId))
                    {
                        // Add the FactionId key and an empty Set: PhalanxId
                        this.talonFactionIdPhalanxIdDictionary.Add(talonFactionId,
                            new HashSet<TalonPhalanxIdEnum>());
                    }
                    this.talonFactionIdPhalanxIdDictionary[talonFactionId].Add(talonPhalanxId);

                    Transform modelTransform = this.mvcModelScript.GetGameObject().transform;
                    Transform talonCollectionTransform = modelTransform.Find(MvcModelConstants.Script.GetTalonCollectionGameObjectName());
                    if (talonCollectionTransform == null)
                    {
                        logger.Error("Unable to find " + MvcModelConstants.Script.GetTalonCollectionGameObjectName());
                    }
                    else
                    {
                        Transform factionIdPhalanxIdCollectionTransform = talonCollectionTransform.Find(
                            MvcModelConstants.Script.GetFactionIdPhalanxIdCollectionGameObjectPrefix() + talonIdentificationReport.GetTalonFactionId());

                        if (factionIdPhalanxIdCollectionTransform == null)
                        {
                            GameObject factionidPhalanxIdCollectionGameObject = new GameObject(
                                MvcModelConstants.Script.GetFactionIdPhalanxIdCollectionGameObjectPrefix() + talonIdentificationReport.GetTalonFactionId());
                            factionIdPhalanxIdCollectionTransform = factionidPhalanxIdCollectionGameObject.transform;
                            factionIdPhalanxIdCollectionTransform.SetParent(talonCollectionTransform);
                        }

                        Transform phalanxIdTalonCollectionTransform = factionIdPhalanxIdCollectionTransform.Find(
                            MvcModelConstants.Script.GetPhalanxIdTalonCollectionGameObjectPrefix() + talonIdentificationReport.GetTalonPhalanxId());

                        if (phalanxIdTalonCollectionTransform == null)
                        {
                            GameObject phalanxIdTalonCollectionGameObject = new GameObject(
                                MvcModelConstants.Script.GetPhalanxIdTalonCollectionGameObjectPrefix() + talonIdentificationReport.GetTalonPhalanxId());
                            phalanxIdTalonCollectionTransform = phalanxIdTalonCollectionGameObject.transform;
                            phalanxIdTalonCollectionTransform.SetParent(factionIdPhalanxIdCollectionTransform);
                        }

                        talonObject.GetTalonScript().GetGameObject().transform.SetParent(phalanxIdTalonCollectionTransform);
                    }
                }
                else
                {
                    logger.Error("Unable to add ?. ? is null.", typeof(TalonObject), typeof(TalonIdentificationReport)); ;
                }
                */
            }
            else
            {
                logger.Error("Unable to add ?. ? is null.", typeof(ITalonObject), typeof(ITalonObject));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private bool CheckWinConditions()
        {
            HashSet<TalonFactionIdEnum> remainingTalonFactionIdSet = new HashSet<TalonFactionIdEnum>();
            foreach (TalonIdentificationReport talonIdentificationReport in this.rosterObject.GetActiveTalonIdentificationReportSet())
            {
                remainingTalonFactionIdSet.Add(talonIdentificationReport.GetTalonFactionId());
            }
            return remainingTalonFactionIdSet.Count > 1;
        }

        #endregion Private Methods

        /*

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mechObject"></param>
        private void DestroyTalon(TalonIdentificationReport talonIdentificationReport)
        {
            if (talonIdentificationReport != null)
            {
                if (this.talonIdentificationReportObjectDictionary.ContainsKey(talonIdentificationReport))
                {
                    TalonObject talonObject = this.talonIdentificationReportObjectDictionary[talonIdentificationReport];
                    this.talonIdentificationReportObjectDictionary.Remove(talonIdentificationReport);
                    if (this.talonPhalanxIdTalonIdentificationReportDictionary.ContainsKey(talonIdentificationReport.GetTalonPhalanxId()))
                    {
                        this.talonPhalanxIdTalonIdentificationReportDictionary[talonIdentificationReport.GetTalonPhalanxId()].Remove(talonIdentificationReport);
                    }
                    this.orderedTalonIdentificationReportList.Remove(talonObject);
                    HexTileObject hexTileObject = HexTileObjectFinderUtil.FindHexTileObjectFrom(talonObject.GetCubeCoordinates());
                    hexTileObject.SetOccupyingTalonIdentificationReport(null);
                    GameObject.Destroy(talonObject.GetTalonScript().GetGameObject());
                }
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private List<TalonObject> GenerateTalonObjectTurnList()
        {
            List<TalonObject> talonObjectOrderList = (this.talonIdentificationReportObjectDictionary != null)
                ? new List<TalonObject>(this.talonIdentificationReportObjectDictionary.Values)
                : new List<TalonObject>();
            talonObjectOrderList.Sort(new OrderPointComparer());
            string talonObjectOrderListString = "[";
            foreach (TalonObject talonObject in talonObjectOrderList)
            {
                talonObjectOrderListString += "\n\t> Order Points: " + talonObject.GetTalonAttributesReport().GetOrderPoints() + ", " + talonObject.GetTalonIdentificationReport();
                talonObject.ResetTalonAttributeValues();
            }
            talonObjectOrderListString += "\n]";
            logger.Info("Order List: ?", talonObjectOrderListString);

            this.counterPhase++;
            return talonObjectOrderList;
        }
        */
    }
}