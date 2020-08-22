using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

/// <summary>
/// MvcModel Object Impl
/// </summary>
public class MvcModelObjectImpl
    : MvcModelObject
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    private readonly MapObject mapObject = null;

    // Todo
    private readonly MvcModelScript mvcModelScript;

    // Todo
    private int counterAction = 0;

    // Todo
    private int counterPhase = 0;

    // Todo
    private MvcFrameworkObject mvcFrameworkObject;

    // Todo
    private MvcInitializationReport mvcInitializationReport;

    // Todo
    private bool processingActionReport = false;

    // Todo
    private Dictionary<TalonFactionIdEnum, HashSet<TalonPhalanxIdEnum>> talonFactionIdPhalanxIdDictionary;

    // Todo
    private Dictionary<TalonIdentificationReport, TalonInformationReport> talonIdentificationInformationDictionary;

    // Todo
    private Dictionary<TalonIdentificationReport, TalonObject> talonIdentificationReportObjectDictionary;

    // Determines the order of the talons
    private List<TalonObject> talonObjectOrderList;

    // Todo
    private Dictionary<TalonPhalanxIdEnum, HashSet<TalonIdentificationReport>> talonPhalanxIdTalonIdentificationReportDictionary;

    #endregion Private Fields

    #region Public Constructors

    public MvcModelObjectImpl(MvcModelScript mvcModelScript, MapScript mapScript)
    {
        if (mvcModelScript != null &&
            mapScript != null)
        {
            logger.Info("Contructing: ?", this.GetType());

            logger.Info("Setting: ?=?", typeof(MvcModelScript), mvcModelScript);
            this.mvcModelScript = mvcModelScript;

            this.mapObject = mapScript.GetMapObject();
        }
        else
        {
            throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                "\n\t>" + typeof(MvcModelScript) + " is null: " + (mvcModelScript == null) +
                "\n\t>" + typeof(MapScript) + " is null: " + (mapScript == null));
        }
    }

    #endregion Public Constructors

    #region Public Methods

    public override bool ContinueGame()
    {
        return this.CheckWinConditions();
    }

    public override TalonInformationReport GetCurrentTalonInformationReport()
    {
        logger.Debug("GetCurrentTalonInformationReport");

        TalonInformationReport talonInformationReport = null;
        if (this.talonObjectOrderList == null ||
                this.talonObjectOrderList.Count < 1)
        {
            this.talonObjectOrderList = this.GenerateTalonObjectTurnList();
        }

        logger.Debug("talonObjectOrderList=?", string.Join(",\n", this.talonObjectOrderList));

        if (this.talonObjectOrderList.Count > 0)
        {
            TalonObject talonObject = this.talonObjectOrderList[0];
            TalonIdentificationReport talonIdentificationReport = talonObject.GetTalonIdentificationReport();
            talonInformationReport = this.GetTalonInformationReport(talonIdentificationReport);
        }

        logger.Debug("Found ?=?", typeof(TalonInformationReport), talonInformationReport);
        return talonInformationReport;
    }

    public override MvcModelInformationReport GetMvcModelInformationReport()
    {
        Dictionary<TalonIdentificationReport, TalonInformationReport> talonIdentificationInformationReportDictionary = new Dictionary<TalonIdentificationReport, TalonInformationReport>();

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

    public override MvcModelScript GetMvcModelScript()
    {
        return this.mvcModelScript;
    }

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

    public override void Initialize(MvcFrameworkObject mvcFrameworkObject, MvcInitializationReport mvcInitializationReport)
    {
        logger.Info("Initializing: ?", this.GetType());
        if (!this.IsInitialized())
        {
            if (mvcFrameworkObject != null &&
            mvcInitializationReport != null)
            {
                this.mvcFrameworkObject = mvcFrameworkObject;
                this.mvcInitializationReport = mvcInitializationReport;
                this.talonPhalanxIdTalonIdentificationReportDictionary = new Dictionary<TalonPhalanxIdEnum, HashSet<TalonIdentificationReport>>();
                this.talonIdentificationReportObjectDictionary = new Dictionary<TalonIdentificationReport, TalonObject>();
                this.talonFactionIdPhalanxIdDictionary = new Dictionary<TalonFactionIdEnum, HashSet<TalonPhalanxIdEnum>>();
                this.talonIdentificationInformationDictionary = new Dictionary<TalonIdentificationReport, TalonInformationReport>();

                this.Initialize();
            }
            else
            {
                throw new ArgumentException("Unable to initialize ?" + this.GetType() + ". Invalid Parameters." +
                    "\n\t>" + typeof(MvcFrameworkObject) + " is null: " + (mvcFrameworkObject == null) +
                    "\n\t>" + typeof(MvcInitializationReport) + " is null: " + (mvcInitializationReport == null));
            }
        }
        else
        {
            logger.Warn("Unable to Initialize: ?. Already initialized.", this.GetType());
        }
    }

    public override TalonTurnReport InputTalonActionOrderReport(TalonActionOrderReport talonActionOrderReport)
    {
        if (talonActionOrderReport != null)
        {
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
        }
        else
        {
            throw new ArgumentException("Unable to InputTalonActionOrderReport. Invalid Parameters." +
                "\n\t>" + typeof(TalonActionOrderReport) + " is null");
        }
    }

    public override bool IsInitialized()
    {
        return this.mvcFrameworkObject != null &&
            this.mvcInitializationReport != null;
    }

    public override bool IsProcessingActionReport()
    {
        return this.processingActionReport;
    }

    public override void StartGame()
    {
        //this.mechObjectTurnList = this.GenerateTalonObjectTurnList();
    }

    #endregion Public Methods

    #region Private Methods

    private void AddTalonObject(TalonObject talonObject)
    {
        // Check that parameters are non-null
        if (talonObject != null)
        {
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
                TalonFactionIdEnum talonFactionId = talonIdentificationReport.GetFactionId();
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
                        MvcModelConstants.Script.GetFactionIdPhalanxIdCollectionGameObjectPrefix() + talonIdentificationReport.GetFactionId());

                    if (factionIdPhalanxIdCollectionTransform == null)
                    {
                        GameObject factionidPhalanxIdCollectionGameObject = new GameObject(
                            MvcModelConstants.Script.GetFactionIdPhalanxIdCollectionGameObjectPrefix() + talonIdentificationReport.GetFactionId());
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
        }
        else
        {
            logger.Error("Unable to add ?. ? is null.", typeof(TalonObject), typeof(TalonObject));
        }
    }

    private bool CheckWinConditions()
    {
        bool multipleTalonFactionsRemaining = true;
        foreach (TalonFactionIdEnum talonFactionId in this.talonFactionIdPhalanxIdDictionary.Keys)
        {
            int talonFactionIdTalonCount = this.CollectFactionIdTalonCount(talonFactionId);
            multipleTalonFactionsRemaining = multipleTalonFactionsRemaining && talonFactionIdTalonCount > 0;
        }
        return multipleTalonFactionsRemaining;
    }

    private int CollectFactionIdTalonCount(TalonFactionIdEnum talonFactionId)
    {
        if (this.talonFactionIdPhalanxIdDictionary.ContainsKey(talonFactionId))
        {
            int talonFactionIdTalonCount = 0;
            foreach (TalonPhalanxIdEnum talonPhalanxId in this.talonFactionIdPhalanxIdDictionary[talonFactionId])
            {
                if (this.talonPhalanxIdTalonIdentificationReportDictionary.ContainsKey(talonPhalanxId))
                {
                    talonFactionIdTalonCount += this.talonPhalanxIdTalonIdentificationReportDictionary[talonPhalanxId].Count;
                }
                else
                {
                    logger.Error("Invalid ?=?", typeof(TalonPhalanxIdEnum), talonPhalanxId);
                }
            }
            return talonFactionIdTalonCount;
        }
        else
        {
            throw new ArgumentException("Unable to CollectFactionIdTalonCount. Invalid Parameters." +
                "\n\t>" + typeof(TalonFactionIdEnum) + " is not valid");
        }
    }

    /// <summary>
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
                this.talonObjectOrderList.Remove(talonObject);
                HexTileObject hexTileObject = HexTileObjectFinderUtil.FindHexTileObjectFrom(talonObject.GetCubeCoordinates());
                hexTileObject.SetOccupyingTalonIdentificationReport(null);
                GameObject.Destroy(talonObject.GetTalonScript().GetGameObject());
            }
        }
    }

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

    private void Initialize()
    {
        if (this.mvcFrameworkObject != null &&
            this.mvcInitializationReport != null)
        {
            foreach (TalonConstructionReport talonConstructionReport in this.mvcInitializationReport.GetTalonConstructionReportSet())
            {
                TalonObject talonObject = TalonObjectBuilderUtil.BuildTalonObject(talonConstructionReport);
                if (talonObject != null)
                {
                    this.AddTalonObject(talonObject);
                }
                else
                {
                    logger.Error("Failed to add: ?. Failed to build.", typeof(TalonObject));
                }
            }

            int mapRadius = this.mvcInitializationReport.GetMapConstructionReport().GetMapRadius();
            foreach (TalonPhalanxIdEnum talonPhalanxId in this.talonPhalanxIdTalonIdentificationReportDictionary.Keys)
            {
                logger.Debug("?=?", typeof(TalonPhalanxIdEnum), talonPhalanxId);
                int talonPhalanxCount = this.talonPhalanxIdTalonIdentificationReportDictionary[talonPhalanxId].Count;
                foreach (TalonIdentificationReport talonIdentificationReport in this.talonPhalanxIdTalonIdentificationReportDictionary[talonPhalanxId])
                {
                    if (this.talonIdentificationReportObjectDictionary.ContainsKey(talonIdentificationReport))
                    {
                        logger.Debug("?=?. Setting ?", typeof(TalonIdentificationReport), talonIdentificationReport, typeof(CubeCoordinates));
                        TalonObject talonObject = this.talonIdentificationReportObjectDictionary[talonIdentificationReport];
                        CubeCoordinates spawnCubeCoordinates = TalonSpawnCubeCoordinatesUtil.GetSpawningCubeCoordinatesFor(talonPhalanxId, talonPhalanxCount, talonIdentificationReport.GetTalonPhalanxIndex(), mapRadius);
                        HexTileObject hexTileObject = HexTileObjectFinderUtil.FindHexTileObjectFrom(spawnCubeCoordinates);
                        if (hexTileObject != null)
                        {
                            talonObject.SetCubeCoordinates(spawnCubeCoordinates);
                            hexTileObject.SetOccupyingTalonIdentificationReport(talonIdentificationReport);
                        }
                        else
                        {
                            logger.Debug("?=? is not valid", typeof(CubeCoordinates), spawnCubeCoordinates);
                        }
                    }
                    else
                    {
                        logger.Debug("?=? is not currently tracked", typeof(TalonIdentificationReport), talonIdentificationReport);
                    }
                }
            }
        }
        else
        {
            logger.Error("Unable to Initialize: ?. Missing Attributes.", this.GetType());
        }
    }

    #endregion Private Methods
}