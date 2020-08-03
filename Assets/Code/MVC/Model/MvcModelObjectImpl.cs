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

    private readonly MvcModelScript mvcModelScript;
    private MvcFrameworkObject mvcFrameworkObject;
    private MvcInitializationReport mvcInitializationReport;
    private bool processingActionReport = false;
    private Dictionary<TalonIdentificationReport, TalonObject> talonIdentificationReportObjectDictionary;

    // Determines the order of the talons
    private List<TalonObject> talonObjectOrderList;

    private Dictionary<TalonPhalanxIdEnum, HashSet<TalonIdentificationReport>> talonPhalanxIdTalonIdentificationReportDictionary;
    private int turnCounter = 0;

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
        return true;
    }

    public override MvcModelScript GetMvcModelScript()
    {
        return this.mvcModelScript;
    }

    public override TalonObject GetNextTalonObject()
    {
        if (this.talonObjectOrderList == null)
        {
            return null;
        }
        if (this.talonObjectOrderList.Count < 1)
        {
            // this.mechObjectTurnList = this.GenerateTalonObjectTurnList();
        }
        return (this.talonObjectOrderList.Count > 0)
            ? this.talonObjectOrderList[0]
            : null;
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

    public override void InputActionReport(TalonActionReport actionReport)
    {
        if (actionReport != null)
        {
            /*
            TalonObject mechObject = actionReport.GetMechObject();
            if (mechObject != null)
            {
                this.processingActionReport = true;
                logger.Debug("Turn: ?) Inputting ?=?", this.turnCounter, typeof(ActionReport), actionReport);
                ActionTypeEnum actionType = actionReport.GetMechActionType();
                LineRendererUtil.DrawPath(actionReport.GetPathObject());
                switch (actionType)
                {
                    case ActionTypeEnum.Wait:
                        this.InputMechActionReportWait(actionReport);
                        break;

                    case ActionTypeEnum.Move:
                        this.InputMechActionReportMove(actionReport);
                        break;

                    case ActionTypeEnum.Fire:
                        this.InputMechActionReportFire(actionReport);
                        break;

                    default:
                        logger.Error("Unable to input ?. Invalid ?=?.", typeof(ActionReport), typeof(ActionTypeEnum), actionType);
                        break;
                }

                if (mechObject.GetMechBehavior().InputMechActionReport(actionReport))
                {
                    logger.Debug("? is completed with their turn.", mechObject.GetMechName());
                    this.mechObjectTurnList.Remove(mechObject);
                }

                this.processingActionReport = false;
            }
            else
            {
                logger.Error("Unable to input ?. ? is null.", typeof(ActionReport), typeof(MechObject));
            }
            */
        }
        else
        {
            logger.Error("Unable to input ?. ? is null.", typeof(TalonActionReport), typeof(TalonActionReport));
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

    /// <summary>
    /// </summary>
    /// <param name="mechObject"></param>
    private void DestroyMechObject(TalonObject mechObject)
    {
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
            GameObject.Destroy(mechGameObject);
        }
        */
    }

    private List<TalonObject> GenerateTalonObjectTurnList()
    {
        this.turnCounter++;
        HashSet<TalonObject> talonObjectSet = new HashSet<TalonObject>();
        List<TalonObject> talonObjectOrderList = new List<TalonObject>();
        /*
        foreach (TeamIdEnum teamId in this.teamIdMechObjectSetDictionary.Keys)
        {
            mechObjectSet.UnionWith(this.teamIdMechObjectSetDictionary[teamId]);
        }

        mechObjectTurnList = new List<MechObject>(mechObjectSet);
        mechObjectTurnList.Sort(new OrderPointComparer());

        int counter = 0;
        foreach (MechObject mechObject in mechObjectTurnList)
        {
            logger.Debug("?) ?", counter, mechObject.GetMechName());
            counter++;
        }
        */
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

            /*
            this.teamIdMechObjectSetDictionary = new Dictionary<TeamIdEnum, HashSet<TalonObject>>();
            foreach (MechConstructionReport mechConstructionReport in this.mvcInitializationReport.GetTalonConstructionReportSet())
            {
            }

            foreach (TeamIdEnum teamId in this.teamIdMechObjectSetDictionary.Keys)
            {
                logger.Debug("TeamId: ?, MechObjectCount: ?", teamId, this.teamIdMechObjectSetDictionary[teamId].Count);
                foreach (MechObject mechObject in this.teamIdMechObjectSetDictionary[teamId])
                {
                    logger.Debug("MechObject: ?", mechObject.GetMechInfoReport());
                    CubeCoordinates startingCubeCoordinates = MechSpawnCubeCoordinatesUtil.GetSpawningCubeCoordinatesFor(teamId,
                        this.teamIdMechObjectSetDictionary[teamId].Count, mechObject.GetMechInfoReport().GetMechTeamId(),
                        this.mvcInitializationReport.GetMapConstructionReport().GetMapRadius());
                    mechObject.SetCubeCoordinates(startingCubeCoordinates);
                    HexTileObjectFinderUtil.FindHexTileObjectFrom(startingCubeCoordinates).SetOccupyingMechObject(mechObject);
                }
            }
            */
        }
        else
        {
            logger.Error("Unable to Initialize: ?. Missing Attributes.", this.GetType());
        }
    }

    /// <summary>
    /// </summary>
    /// <param name="mechActionReport"></param>
    private void InputMechActionReportFire(TalonActionReport mechActionReport)
    {
        /*
        MechObject mechObject = mechActionReport.GetMechObject();
        CubeCoordinates fireTargetCubeCoordinates = mechActionReport.GetPathObject().GetCubeCoordinatesEnd();
        TileObject fireTileObject = HexTileObjectFinderUtil.FindHexTileObjectFrom(fireTargetCubeCoordinates);
        MechObject targetMechObject = fireTileObject.GetTileInfoReport().GetOccupyingMechObject();
        logger.Info("? is firing at ?", mechObject.GetMechName(), targetMechObject.GetMechName());
        HashSet<WeaponCombatReport> weaponCombatReportSet = mechObject.GetMechBehavior().GetWeaponCombatReportSet((PathObjectFire)mechActionReport.GetPathObject());
        bool targetMechIsDestroyed = targetMechObject.GetMechBehavior().InputWeaponCombatReportSet(weaponCombatReportSet);
        targetMechObject.GetMechVisual().UpdateMechCanvas();
        if (targetMechIsDestroyed)
        {
            logger.Info("Target Mech: ? is destroyed!", targetMechObject.GetMechName());
            this.DestroyMechObject(targetMechObject);
        }
        // Get Weapon Reports and apply to the target
        */
    }

    /// <summary>
    /// </summary>
    /// <param name="mechActionReport"></param>
    private void InputMechActionReportMove(TalonActionReport mechActionReport)
    {
        /*
        CubeCoordinates moveTargetCubeCoordinates = mechActionReport.GetPathObject().GetCubeCoordinatesEnd();
        MechObject mechObject = mechActionReport.GetMechObject();
        TileObject moveTileObject = HexTileObjectFinderUtil.FindHexTileObjectFrom(moveTargetCubeCoordinates);
        mechObject.SetCubeCoordinates(moveTargetCubeCoordinates);
        moveTileObject.SetOccupyingMechObject(mechObject);
        logger.Info("? is moving to ?", mechObject.GetMechName(), moveTargetCubeCoordinates);
        */
    }

    /// <summary>
    /// </summary>
    /// <param name="mechActionReport"></param>
    private void InputMechActionReportWait(TalonActionReport mechActionReport)
    {
        //MechObject mechObject = mechActionReport.GetMechObject();
        //logger.Info("? is waiting", mechObject.GetMechName());
    }

    #endregion Private Methods
}