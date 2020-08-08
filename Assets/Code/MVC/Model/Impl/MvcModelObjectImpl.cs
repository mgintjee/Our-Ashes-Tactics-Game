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
    private Dictionary<TalonIdentificationReport, TalonObject> talonIdentificationReportObjectDictionary;

    // Determines the order of the talons
    private List<TalonObject> talonObjectOrderList;

    // Todo
    private Dictionary<TalonPhalanxIdEnum, HashSet<TalonIdentificationReport>> talonPhalanxIdTalonIdentificationReportDictionary;

    #endregion Private Fields

    #region Public Constructors

    public MvcModelObjectImpl(MvcModelScript mvcModelScript)
    {
        if (mvcModelScript != null)
        {
            logger.Info("Contructing: ?", this.GetType());

            logger.Info("Setting: ?=?", typeof(MvcModelScript), mvcModelScript);
            this.mvcModelScript = mvcModelScript;
        }
        else
        {
            throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                "\n>" + typeof(MvcModelScript) + " is null: " + (mvcModelScript == null));
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
        if (this.talonObjectOrderList == null)
        {
            return null;
        }
        if (this.talonObjectOrderList.Count < 1)
        {
            this.talonObjectOrderList = this.GenerateTalonObjectTurnList();
        }
        return (this.talonObjectOrderList.Count > 0)
            ? this.talonObjectOrderList[0].GetCurrentTalonInformationReport()
            : null;
    }

    public override MvcModelScript GetMvcModelScript()
    {
        return this.mvcModelScript;
    }

    public override TalonInformationReport GetTalonInformationReport(TalonIdentificationReport talonIdentificationReport)
    {
        TalonInformationReport talonInformationReport = null;
        if (this.talonIdentificationReportObjectDictionary.ContainsKey(talonIdentificationReport))
        {
            talonInformationReport = this.talonIdentificationReportObjectDictionary[talonIdentificationReport].GetCurrentTalonInformationReport();
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

                this.Initialize();
            }
            else
            {
                throw new ArgumentException("Unable to initialize ?" + this.GetType() + ". Invalid Parameters." +
                    "\n>" + typeof(MvcFrameworkObject) + " is null: " + (mvcFrameworkObject == null) +
                    "\n>" + typeof(MvcInitializationReport) + " is null: " + (mvcInitializationReport == null));
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
                        TalonIdentificationReport targetTalonIdentificationReport = talonActionOrderReport.GetTargetTalonIdentificationReport();
                        if (targetTalonIdentificationReport != null &&
                                this.talonIdentificationReportObjectDictionary.ContainsKey(targetTalonIdentificationReport))
                        {
                            TalonObject targetTalonObject = this.talonIdentificationReportObjectDictionary[targetTalonIdentificationReport];
                            if (targetTalonObject != null)
                            {
                                talonCombatResultReport = targetTalonObject.InputTalonCombatOrderReport(talonCombatOrderReport);
                                if (talonCombatResultReport.GetIsTargetDestroyed())
                                {
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

                    this.processingActionReport = false;
                    this.counterAction++;

                    return new TalonTurnReport.Builder()
                        .SetPhaseCounter(this.counterPhase)
                        .SetActionCounter(this.counterAction)
                        .SetTalonActionResultReport(talonActionResultReport)
                        .SetTalonCombatResultReport(talonCombatResultReport)
                        .Build();
                }
                else
                {
                    throw new ArgumentException("Unable to InputTalonActionOrderReport. Invalid Parameters." +
                        "\n>" + typeof(TalonObject) + " is null");
                }
            }
            else
            {
                throw new ArgumentException("Unable to InputTalonActionOrderReport. Invalid Parameters." +
                    "\n>" + typeof(TalonIdentificationReport) + " is null");
            }
        }
        else
        {
            throw new ArgumentException("Unable to InputTalonActionOrderReport. Invalid Parameters." +
                "\n>" + typeof(TalonActionOrderReport) + " is null");
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
            TalonInformationReport talonInformationReport = talonObject.GetCurrentTalonInformationReport();
            if (talonInformationReport != null)
            {
                TalonIdentificationReport talonIdentificationReport = talonInformationReport.GetTalonIdentificationReport();
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
                logger.Error("Unable to add ?. ? is null.", typeof(TalonObject), typeof(TalonInformationReport));
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
                "\n>" + typeof(TalonFactionIdEnum) + " is not valid");
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
                HexTileObject hexTileObject = HexTileObjectFinderUtil.FindHexTileObjectFrom(talonObject.GetCubeCoordinates());
                hexTileObject.SetOccupyingTalonIdentificationReport(null);
                GameObject.Destroy(talonObject.GetTalonScript().GetGameObject());
            }
        }
        /*
        logger.Debug("? is being destroyed!", mechObject);
        if (mechObject != null &&
            mechObject.GetMechScript() != null)
        {
            GameObject mechGameObject = mechObject.GetMechScript().GetGameObject();

            TileObject occupiedTileObject = HexTileObjectFinderUtil.FindHexTileObjectFrom(mechObject.GetMechBehavior().GetCubeCoordinates());
            occupiedTileObject.SetOccupyingMechObject(null);

            this.mechObjectTurnList.Remove(mechObject);
            this.teamIdMechObjectSetDictionary[mechObject.GetTeamId()].Remove(mechObject);

            if (this.teamIdMechObjectSetDictionary[mechObject.GetTeamId()].Count == 0)
            {
                this.teamIdMechObjectSetDictionary.Remove(mechObject.GetTeamId());
            }
        }
        */
    }

    private List<TalonObject> GenerateTalonObjectTurnList()
    {
        this.counterPhase++;
        List<TalonObject> talonObjectOrderList = (this.talonIdentificationReportObjectDictionary != null)
            ? new List<TalonObject>(this.talonIdentificationReportObjectDictionary.Values)
            : new List<TalonObject>();

        talonObjectOrderList.Sort(new OrderPointComparer());

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