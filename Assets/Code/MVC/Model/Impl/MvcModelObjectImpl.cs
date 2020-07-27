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
    private Dictionary<TeamIdEnum, HashSet<MechObject>> teamIdMechObjectSetDictionary;
    private List<MechObject> mechObjectTurnList;
    private bool processingActionReport = false;
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
            throw new ArgumentException("Unable to construct " +
                this.GetType() + ". Invalid Parameters." +
                "\n>mvcModelScript is null: " + (mvcModelScript == null));
        }
    }

    #endregion Public Constructors

    #region Public Methods

    public override MvcModelScript GetMvcModelScript()
    {
        return this.mvcModelScript;
    }

    public override void Initialize(MvcFrameworkObject mvcFrameworkObject, MvcInitializationReport mvcInitializationReport)
    {
        if (mvcFrameworkObject != null &&
            mvcInitializationReport != null)
        {
            logger.Info("Initializing: ?", this.GetType());
            if (!this.IsInitialized())
            {
                logger.Info("Setting: ?=?", typeof(MvcFrameworkObject), mvcFrameworkObject);
                this.mvcFrameworkObject = mvcFrameworkObject;

                logger.Info("Setting: ?=?", typeof(MvcFrameworkObject), mvcInitializationReport);
                this.mvcInitializationReport = mvcInitializationReport;

                this.Initialize();
            }
            else
            {
                logger.Warn("Unable to Initialize: ?. Already initialized.", this.GetType());
            }
        }
        else
        {
            logger.Error("Unable to Initialize: ?. Invalid Parameters.", this.GetType());
        }
    }

    public override bool IsInitialized()
    {
        return this.mvcFrameworkObject != null &&
            this.mvcInitializationReport != null &&
            this.teamIdMechObjectSetDictionary != null;
    }

    public override void StartGame()
    {
        this.mechObjectTurnList = this.GenerateMechObjectTurnList();
    }

    public override bool IsProcessingActionReport()
    {
        return this.processingActionReport;
    }

    public override MechObject GetNextMechObject()
    {
        if (this.mechObjectTurnList == null)
        {
            return null;
        }
        if (this.mechObjectTurnList.Count < 1)
        {
            this.mechObjectTurnList = this.GenerateMechObjectTurnList();
        }
        return (this.mechObjectTurnList.Count > 0)
            ? this.mechObjectTurnList[0]
            : null;
    }

    public override void InputActionReport(ActionReport actionReport)
    {
        if (actionReport != null)
        {
            MechObject mechObject = actionReport.GetMechObject();
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
        }
        else
        {
            logger.Error("Unable to input ?. ? is null.", typeof(ActionReport), typeof(ActionReport));
        }
    }

    public override bool ContinueGame()
    {
        return this.teamIdMechObjectSetDictionary != null &&
            this.teamIdMechObjectSetDictionary.Keys.Count > 1;
    }

    #endregion Public Methods

    #region Private Methods

    private void Initialize()
    {
        if (this.mvcFrameworkObject != null &&
            this.mvcInitializationReport != null)
        {
            this.teamIdMechObjectSetDictionary = new Dictionary<TeamIdEnum, HashSet<MechObject>>();
            foreach (MechConstructionReport mechConstructionReport in this.mvcInitializationReport.GetMechConstructionReportSet())
            {
                MechObject mechObject = MechObjectBuilderUtil.BuildMechObject(mechConstructionReport);
                if (mechObject != null)
                {
                    this.AddMechObject(mechObject);
                }
                else
                {
                    logger.Error("Failed to add: ?. Failed to build.", typeof(MechObject));
                }
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
                    TileObjectFinderUtil.FindTileObjectFrom(startingCubeCoordinates).SetOccupyingMechObject(mechObject);
                }
            }
        }
        else
        {
            logger.Error("Unable to Initialize: ?. Missing Attributes.", this.GetType());
        }
    }

    private void AddMechObject(MechObject mechObject)
    {
        // Check that parameters are non-null
        if (mechObject != null)
        {
            // Check that if the Dictionary does not have the TeamId key
            if (!this.teamIdMechObjectSetDictionary.ContainsKey(mechObject.GetTeamId()))
            {
                // Add the TeamdId key and an empty Set: MechObject
                this.teamIdMechObjectSetDictionary.Add(mechObject.GetTeamId(), new HashSet<MechObject>());
            }
            // Add the MechObject to the Dictionary: TeamId, Set: MechObject
            this.teamIdMechObjectSetDictionary[mechObject.GetTeamId()].Add(mechObject);

            Transform modelTransform = this.mvcModelScript.GetGameObject().transform;
            Transform mechCollectionTransform = modelTransform.Find(MvcModelConstants.Script.GetMechCollectionGameObjectName());

            if (mechCollectionTransform == null)
            {
                logger.Error("Unable to find " + MvcModelConstants.Script.GetMechCollectionGameObjectName());
            }
            else
            {
                Transform teamIdMechCollectionTransform = mechCollectionTransform.Find(MvcModelConstants.Script.GetTeamIdMechCollectionGameObjectPrefix() + mechObject.GetTeamId());

                if (teamIdMechCollectionTransform == null)
                {
                    GameObject teamIdMechCollectionGameObject = new GameObject(MvcModelConstants.Script.GetTeamIdMechCollectionGameObjectPrefix() + mechObject.GetTeamId());
                    teamIdMechCollectionTransform = teamIdMechCollectionGameObject.transform;
                    teamIdMechCollectionTransform.SetParent(mechCollectionTransform);
                }
                // Add the TeamdId key and an empty Set: MechObject
                mechObject.GetMechScript().GetGameObject().transform.SetParent(teamIdMechCollectionTransform);
            }
        }
        else
        {
            logger.Error("Unable to add ?. Invalid Parameters.", typeof(MechObject));
        }
    }

    private List<MechObject> GenerateMechObjectTurnList()
    {
        this.turnCounter++;
        HashSet<MechObject> mechObjectSet = new HashSet<MechObject>();
        List<MechObject> mechObjectTurnList = new List<MechObject>();
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
        return mechObjectTurnList;
    }

    /// <summary>
    /// </summary>
    /// <param name="mechActionReport"></param>
    private void InputMechActionReportFire(ActionReport mechActionReport)
    {
        MechObject mechObject = mechActionReport.GetMechObject();
        CubeCoordinates fireTargetCubeCoordinates = mechActionReport.GetPathObject().GetCubeCoordinatesEnd();
        TileObject fireTileObject = TileObjectFinderUtil.FindTileObjectFrom(fireTargetCubeCoordinates);
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
    }

    /// <summary>
    /// </summary>
    /// <param name="mechActionReport"></param>
    private void InputMechActionReportMove(ActionReport mechActionReport)
    {
        CubeCoordinates moveTargetCubeCoordinates = mechActionReport.GetPathObject().GetCubeCoordinatesEnd();
        MechObject mechObject = mechActionReport.GetMechObject();
        TileObject moveTileObject = TileObjectFinderUtil.FindTileObjectFrom(moveTargetCubeCoordinates);
        mechObject.SetCubeCoordinates(moveTargetCubeCoordinates);
        moveTileObject.SetOccupyingMechObject(mechObject);
        logger.Info("? is moving to ?", mechObject.GetMechName(), moveTargetCubeCoordinates);
    }

    /// <summary>
    /// </summary>
    /// <param name="mechActionReport"></param>
    private void InputMechActionReportWait(ActionReport mechActionReport)
    {
        MechObject mechObject = mechActionReport.GetMechObject();
        logger.Info("? is waiting", mechObject.GetMechName());
    }

    /// <summary>
    /// </summary>
    /// <param name="mechObject"></param>
    private void DestroyMechObject(MechObject mechObject)
    {
        logger.Debug("? is being destroyed!", mechObject);
        if (mechObject != null &&
            mechObject.GetMechScript() != null)
        {
            GameObject mechGameObject = mechObject.GetMechScript().GetGameObject();

            TileObject occupiedTileObject = TileObjectFinderUtil.FindTileObjectFrom(mechObject.GetMechBehavior().GetCubeCoordinates());
            occupiedTileObject.SetOccupyingMechObject(null);

            this.mechObjectTurnList.Remove(mechObject);
            this.teamIdMechObjectSetDictionary[mechObject.GetTeamId()].Remove(mechObject);

            if (this.teamIdMechObjectSetDictionary[mechObject.GetTeamId()].Count == 0)
            {
                this.teamIdMechObjectSetDictionary.Remove(mechObject.GetTeamId());
            }
            GameObject.Destroy(mechGameObject);
        }
    }

    #endregion Private Methods
}