using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

/// <summary>
/// GameFrameworkObject Impl
/// </summary>
public class GameFrameworkObjectImpl
    : GameFrameworkObject
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    // Todo
    private readonly GameFrameworkScript gameFrameworkScript;

    // Todo
    private readonly bool mapModelIsMirrored;

    // Todo
    private readonly int mapModelRadius;

    // Todo
    private readonly int mapModelSeed;

    // Todo
    private readonly int maxMechPerTeam;

    // Todo
    private readonly ControllerTypeEnum team1Controller;

    // Todo
    private readonly HashSet<MechObject> team1MechObjectSet = new HashSet<MechObject>();

    // Todo
    private readonly ControllerTypeEnum team2Controller;

    // Todo
    private readonly HashSet<MechObject> team2MechObjectSet = new HashSet<MechObject>();

    // Todo
    private List<MechObject> currentTurnMechObjectOrderList = new List<MechObject>();

    // Todo
    private bool gameIsActive = false;

    // Todo
    private ControllerObject mapControllerObject;

    // Todo
    private ViewObject mapModelObject;

    // Todo
    private List<MechObject> nextTurnMechObjectOrderList = new List<MechObject>();

    private bool processingActionReport = false;

    // Todo
    private int turnCounter;

    #endregion Private Fields

    #region Private Constructors

    /// <summary>
    /// </summary>
    /// <param name="mapModelSeed">       </param>
    /// <param name="mapModelRadius">     </param>
    /// <param name="mapMirrored">        </param>
    /// <param name="maxMechPerTeam">     </param>
    /// <param name="gameFrameworkScript"></param>
    /// <param name="team1Controller">    </param>
    /// <param name="team2Controller">    </param>
    private GameFrameworkObjectImpl(int mapModelSeed, int mapModelRadius, bool mapMirrored,
        int maxMechPerTeam, GameFrameworkScript gameFrameworkScript, ControllerTypeEnum team1Controller,
        ControllerTypeEnum team2Controller)
    {
        this.mapModelSeed = mapModelSeed;
        this.mapModelRadius = mapModelRadius;
        this.mapModelIsMirrored = mapMirrored;
        this.maxMechPerTeam = maxMechPerTeam;
        this.gameFrameworkScript = gameFrameworkScript;
        this.team1Controller = team1Controller;
        this.team2Controller = team2Controller;
    }

    #endregion Private Constructors

    #region Public Methods

    /// <summary>
    /// </summary>
    /// <param name="mechInfoReport"></param>
    public override void CreateNewMechFrom(MechConstructionReport mechCreationReport)
    {
        logger.Debug("Attempting to create New MechObject from: ?", mechCreationReport);
        if (MechConstructionReportValidatorUtil.ValidMechConstructionReport(mechCreationReport) &&
            this.ValidMechCount(mechCreationReport.GetTeamId()))
        {
            MechScript mechScript = MechScriptGenerationUtil.GenerateMechScript(mechCreationReport);
            MechObject mechObject = mechScript.GetMechObject();
            int mechPosition = -1;
            int mechTeam = mechCreationReport.GetTeamId();
            if (mechTeam == 1)
            {
                mechPosition = this.team1MechObjectSet.Count;
                this.team1MechObjectSet.Add(mechObject);
            }
            else if (mechTeam == 2)
            {
                mechPosition = this.team2MechObjectSet.Count;
                this.team2MechObjectSet.Add(mechObject);
            }
            this.mapModelObject.AddNewMechObject(mechScript.GetMechObject(), mechTeam, mechPosition);
            Transform mapModelGameObjectTransform = this.GetMapModelObject().GetMapModelScript().transform;
            logger.Debug("mapModelTransformChildren: ?", mapModelGameObjectTransform.childCount);
            Transform mapModelMechCollectionTransform = mapModelGameObjectTransform.Find("MechCollection");
            if (mapModelMechCollectionTransform == null)
            {
                GameObject mapModelMechCollectionGameObject = new GameObject("MechCollection");
                mapModelMechCollectionGameObject.transform.parent = mapModelGameObjectTransform;
                mapModelMechCollectionTransform = mapModelMechCollectionGameObject.transform;
            }
            Transform mapModelMechTeamCollectionTransform = mapModelMechCollectionTransform.Find("Team: " + mechTeam);
            if (mapModelMechTeamCollectionTransform == null)
            {
                GameObject mapModelMechTeamCollectionGameObject = new GameObject("Team: " + mechTeam);
                mapModelMechTeamCollectionGameObject.transform.parent = mapModelMechCollectionTransform;
                mapModelMechTeamCollectionTransform = mapModelMechTeamCollectionGameObject.transform;
            }
            mechScript.GetGameObject().transform.parent = mapModelMechTeamCollectionTransform;
        }
        else
        {
            logger.Warn("Unable to add a new MechInfoReport.");
        }
    }

    public override bool GameIsActive()
    {
        return this.gameIsActive;
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public override GameFrameworkScript GetGameFrameworkScript()
    {
        return this.gameFrameworkScript;
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public override ControllerObject GetMapControllerObject()
    {
        return this.mapControllerObject;
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public override bool GetMapModelIsMirrored()
    {
        return this.mapModelIsMirrored;
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public override ViewObject GetMapModelObject()
    {
        return this.mapModelObject;
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public override int GetMapModelRadius()
    {
        return this.mapModelRadius;
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public override int GetMapModelSeed()
    {
        return this.mapModelSeed;
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public override int GetMaxMechPerTeam()
    {
        return this.maxMechPerTeam;
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public override MechObject GetNextMechObject()
    {
        return this.currentTurnMechObjectOrderList[0];
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public override ControllerTypeEnum GetTeam1Controller()
    {
        return this.team1Controller;
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public override ControllerTypeEnum GetTeam2Controller()
    {
        return this.team2Controller;
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public override int GetTurnCounter()
    {
        return this.turnCounter;
    }

    /// <summary>
    /// </summary>
    public override void InitializeNewGame()
    {
        logger.Info("Initializing New Game");
        this.turnCounter = 1;
        HashSet<MechObject> randomMechObjectSet = new HashSet<MechObject>(this.team1MechObjectSet);
        randomMechObjectSet.UnionWith(this.team2MechObjectSet);
        this.nextTurnMechObjectOrderList = new List<MechObject>(randomMechObjectSet);
        this.InitializeNewTurn();
        this.gameIsActive = true;
    }

    /// <summary>
    /// </summary>
    public override void InitializeNewTurn()
    {
        logger.Info("Initializing New Turn=?", this.turnCounter);
        this.turnCounter++;
        //foreach (MechObject mechObject in this.nextTurnMechObjectOrderList)
        //{
        //   logger.Info("Mech=?, OrderPoints=?", mechObject, mechObject.GetMechBehavior().GetCurrentOrderPoints());
        //}
        this.nextTurnMechObjectOrderList.Sort(new MechObjectOrderComparer());
        //foreach (MechObject mechObject in this.nextTurnMechObjectOrderList)
        //{
        //   logger.Info("Mech=?, OrderPoints=?", mechObject, mechObject.GetMechBehavior().GetCurrentOrderPoints());
        //}

        this.currentTurnMechObjectOrderList = new List<MechObject>();
        foreach (MechObject mechObject in this.nextTurnMechObjectOrderList)
        {
            this.currentTurnMechObjectOrderList.Add(mechObject);
            mechObject.GetMechBehavior().ResetValuesForNewTurn();
        }
        this.nextTurnMechObjectOrderList = new List<MechObject>();
    }

    /// <summary>
    /// </summary>
    /// <param name="mechActionReport"></param>
    public override void InputMechActionReport(ActionReport mechActionReport)
    {
        logger.Debug("Attempting to input MechActionReport: ?", mechActionReport);
        this.processingActionReport = true;
        MechObject mechObject = mechActionReport.GetMechObject();
        // Todo: Clean this up once I update mech tracking
        if (this.team1MechObjectSet.Contains(mechObject) ||
            this.team2MechObjectSet.Contains(mechObject))
        {
            LineRendererUtil.DrawPath(mechActionReport.GetPathObject());
            switch (mechActionReport.GetMechActionType())
            {
                case ActionTypeEnum.Wait:
                    this.InputMechActionReportWait(mechActionReport);
                    break;

                case ActionTypeEnum.Move:
                    this.InputMechActionReportMove(mechActionReport);
                    break;

                case ActionTypeEnum.Fire:
                    this.InputMechActionReportFire(mechActionReport);
                    break;
            }
            if (mechObject != null &&
                mechObject.GetMechBehavior().InputMechActionReport(mechActionReport))
            {
                logger.Debug("Removing MechObject: ?", mechObject);
                this.currentTurnMechObjectOrderList.Remove(mechObject);

                this.nextTurnMechObjectOrderList.Add(mechObject);
                if (this.currentTurnMechObjectOrderList.Count == 0)
                {
                    this.InitializeNewTurn();
                }
            }
            this.processingActionReport = false;
        }
        else
        {
            logger.Warn("Attempted to input non-existent mechObject's ActionReport");
        }
    }

    public override bool ProcessingActionReport()
    {
        return this.processingActionReport;
    }

    /// <summary>
    /// </summary>
    /// <param name="mapControllerObject"></param>
    public override void SetMapControllerObject(ControllerObject mapControllerObject)
    {
        if (this.mapControllerObject == null)
        {
            logger.Debug("Setting ?", typeof(ControllerObject).Name);
            this.mapControllerObject = mapControllerObject;
        }
    }

    /// <summary>
    /// </summary>
    /// <param name="mapModelObject"></param>
    public override void SetMapModelObject(ViewObject mapModelObject)
    {
        if (this.mapModelObject == null)
        {
            logger.Debug("Setting ?", typeof(ViewObject).Name);
            this.mapModelObject = mapModelObject;
        }
    }

    #endregion Public Methods

    #region Private Methods

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
            this.currentTurnMechObjectOrderList.Remove(mechObject);

            this.team1MechObjectSet.Remove(mechObject);
            this.team2MechObjectSet.Remove(mechObject);
            GameObject.Destroy(mechGameObject);
            logger.Debug("? has been destroyed!", mechObject);
            // Update when transition to better mech tracking
            if (this.team1MechObjectSet.Count == 0 ||
                this.team2MechObjectSet.Count == 0)
            {
                this.gameIsActive = false;
            }

            if (this.currentTurnMechObjectOrderList.Count == 0)
            {
                this.InitializeNewTurn();
            }
        }
        //GameObject.Destroy(targetMechObject.GetMechScript().GetGameObject());
        //this.currentTurnMechObjectOrderList.Remove(mechObject);
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
    /// <param name="teamId"></param>
    /// <returns></returns>
    private bool ValidMechCount(TeamIdEnum teamId)
    {
        // Default a case that will fail
        int currentMechForTeam = GameFrameworkObjectConstants.GetMaxMechPerTeam() + 1;
        /*
         * Todo: Clean this up
        // Check if the mechReport is for Team 0
        if (teamId == 1)
        {
            currentMechForTeam = this.team1MechObjectSet.Count + 1;
        }
        // Check if the mechReport is for Team 1
        else if (teamId == 2)
        {
            currentMechForTeam = this.team2MechObjectSet.Count + 1;
        }
        else
        {
            logger.Warn("Invalid MechReport: TeamId is invalid. TeamId=?", teamId);
        }
        if (currentMechForTeam > GameFrameworkObjectConstants.GetMaxMechPerTeam())
        {
            logger.Warn("Invalid MechReport: There are already max amount of mechs for Team=?", teamId);
        }
        */
        return currentMechForTeam <= GameFrameworkObjectConstants.GetMaxMechPerTeam();
    }

    #endregion Private Methods

    #region Public Classes

    /// <summary>
    /// </summary>
    public class Builder
    {
        #region Private Fields

        // Todo
        private GameFrameworkScript gameFrameworkScript;

        // Todo
        private bool mapModelMirrored;

        // Todo
        private int mapModelRadius;

        // Todo
        private int mapModelSeed;

        // Todo
        private int maxMechPerTeam;

        // Todo
        private ControllerTypeEnum team1Controller;

        // Todo
        private ControllerTypeEnum team2Controller;

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public GameFrameworkObjectImpl Build()
        {
            /*
            if (this.mechId.Equals(MechIdEnum.NULL) ||
                this.teamId.Equals(TeamIdEnum.NULL) ||
                this.mechTeamIndex < 0 ||
                this.paintSchemeReport == null ||
                this.weaponIdList.Count == 0)
            {
                throw new ArgumentException("Unable to construct ?" + this.GetType().ToString() + ". Invalid Parameters." +
                    "\nmechId=" + this.mechId +
                    "\nteamId=" + this.teamId +
                    "\nmechTeamIndex=" + this.mechTeamIndex +
                    "\npaintSchemeReport=" + this.paintSchemeReport +
                    "\nweaponIdList.Count=" + this.weaponIdList.Count);
            }
            */
            return new GameFrameworkObjectImpl(this.mapModelSeed, this.mapModelRadius,
                this.mapModelMirrored, this.maxMechPerTeam, this.gameFrameworkScript,
                this.team1Controller, this.team2Controller);
        }

        /// <summary>
        /// </summary>
        /// <param name="gameFrameworkScript"></param>
        /// <returns></returns>
        public Builder SetGameFrameworkScript(GameFrameworkScript gameFrameworkScript)
        {
            this.gameFrameworkScript = gameFrameworkScript;
            return this;
        }

        /// <summary>
        /// </summary>
        /// <param name="mapModelMirrored"></param>
        /// <returns></returns>
        public Builder SetMapModelMirrored(bool mapModelMirrored)
        {
            this.mapModelMirrored = mapModelMirrored;
            return this;
        }

        /// <summary>
        /// </summary>
        /// <param name="mapModelRadius"></param>
        /// <returns></returns>
        public Builder SetMapModelRadius(int mapModelRadius)
        {
            this.mapModelRadius = mapModelRadius;
            return this;
        }

        /// <summary>
        /// </summary>
        /// <param name="mapModelSeed"></param>
        /// <returns></returns>
        public Builder SetMapModelSeed(int mapModelSeed)
        {
            this.mapModelSeed = mapModelSeed;
            return this;
        }

        /// <summary>
        /// </summary>
        /// <param name="maxMechPerTeam"></param>
        /// <returns></returns>
        public Builder SetMaxMechPerTeam(int maxMechPerTeam)
        {
            this.maxMechPerTeam = maxMechPerTeam;
            return this;
        }

        /// <summary>
        /// </summary>
        /// <param name="team1Controller"></param>
        /// <returns></returns>
        public Builder SetTeam1Controller(ControllerTypeEnum team1Controller)
        {
            this.team1Controller = team1Controller;
            return this;
        }

        /// <summary>
        /// </summary>
        /// <param name="team2Controller"></param>
        /// <returns></returns>
        public Builder SetTeam2Controller(ControllerTypeEnum team2Controller)
        {
            this.team2Controller = team2Controller;
            return this;
        }

        #endregion Public Methods
    }

    /// <summary>
    /// Todo
    /// </summary>
    public class MechObjectOrderComparer
        : Comparer<MechObject>
    {
        #region Public Methods

        /// <summary>
        /// </summary>
        /// <param name="mechObjectA"></param>
        /// <param name="mechObjectB"></param>
        /// <returns></returns>
        public override int Compare(MechObject mechObjectA, MechObject mechObjectB)
        {
            int xOrderPoints = mechObjectA.GetMechBehavior().GetCurrentOrderPoints();
            int yOrderPoints = mechObjectB.GetMechBehavior().GetCurrentOrderPoints();

            if (xOrderPoints < yOrderPoints)
            {
                return 1;
            }
            else if (xOrderPoints > yOrderPoints)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        #endregion Public Methods
    }

    #endregion Public Classes
}