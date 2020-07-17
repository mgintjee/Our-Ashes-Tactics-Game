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
    private readonly TeamControllerTypeEnum team1Controller;

    // Todo
    private readonly HashSet<MechObject> team1MechObjectSet = new HashSet<MechObject>();

    // Todo
    private readonly TeamControllerTypeEnum team2Controller;

    // Todo
    private readonly HashSet<MechObject> team2MechObjectSet = new HashSet<MechObject>();

    // Todo
    private List<MechObject> currentTurnMechObjectOrderList = new List<MechObject>();

    // Todo
    private MapControllerObject mapControllerObject;

    // Todo
    private MapModelObject mapModelObject;

    // Todo
    private List<MechObject> nextTurnMechObjectOrderList = new List<MechObject>();

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
        int maxMechPerTeam, GameFrameworkScript gameFrameworkScript, TeamControllerTypeEnum team1Controller,
        TeamControllerTypeEnum team2Controller)
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
            this.ValidMechCount(mechCreationReport.GetMechTeam()))
        {
            MechScript mechScript = MechGameObjectGeneratorUtil.GenerateMechScript(mechCreationReport);
            MechObject mechObject = mechScript.GetMechObject();
            int mechPosition = -1;
            int mechTeam = mechCreationReport.GetMechTeam();
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
    public override MapControllerObject GetMapControllerObject()
    {
        return this.mapControllerObject;
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public override bool GetMapModelIsMirrored()
    {
        return this.mapModelIsMirrored;
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public override MapModelObject GetMapModelObject()
    {
        return this.mapModelObject;
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public override int GetMapModelRadius()
    {
        return this.mapModelRadius;
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public override int GetMapModelSeed()
    {
        return this.mapModelSeed;
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public override int GetMaxMechPerTeam()
    {
        return this.maxMechPerTeam;
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public override MechObject GetNextMechObject()
    {
        MechObject nextMechObject = this.currentTurnMechObjectOrderList[0];
        return nextMechObject;
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public override TeamControllerTypeEnum GetTeam1Controller()
    {
        return this.team1Controller;
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public override TeamControllerTypeEnum GetTeam2Controller()
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
        this.turnCounter = 1;
        this.nextTurnMechObjectOrderList = new List<MechObject>();
        foreach (MechObject mechObject in this.team1MechObjectSet)
        {
            this.nextTurnMechObjectOrderList.Add(mechObject);
        }
        foreach (MechObject mechObject in this.team2MechObjectSet)
        {
            this.nextTurnMechObjectOrderList.Add(mechObject);
        }
        this.InitializeNewTurn();
    }

    /// <summary>
    /// </summary>
    public override void InitializeNewTurn()
    {
        this.turnCounter++;
        foreach (MechObject mechObject in this.nextTurnMechObjectOrderList)
        {
            logger.Debug("Mech=?, OrderPoints=?", mechObject, mechObject.GetMechBehavior().GetCurrentOrderPoints());
        }
        this.nextTurnMechObjectOrderList.Sort(new MechObjectOrderComparer());
        foreach (MechObject mechObject in this.nextTurnMechObjectOrderList)
        {
            logger.Debug("Mech=?, OrderPoints=?", mechObject, mechObject.GetMechBehavior().GetCurrentOrderPoints());
        }

        this.currentTurnMechObjectOrderList = new List<MechObject>();
        foreach (MechObject mechObjec in this.nextTurnMechObjectOrderList)
        {
            this.currentTurnMechObjectOrderList.Add(mechObjec);
            mechObjec.GetMechBehavior().ResetValuesForNewTurn();
        }
        this.nextTurnMechObjectOrderList = new List<MechObject>();
    }

    /// <summary>
    /// </summary>
    /// <param name="mechActionReport"></param>
    public override void InputMechActionReport(MechActionReport mechActionReport)
    {
        logger.Debug("Attempting to input MechActionReport: ?", mechActionReport);
        MechObject mechObject = mechActionReport.GetMechObject();
        LineRendererUtil.DrawPath(mechActionReport.GetPathObject());
        switch (mechActionReport.GetMechActionType())
        {
            case MechActionTypeEnum.Wait:
                this.InputMechActionReportWait(mechActionReport);
                break;

            case MechActionTypeEnum.Move:
                this.InputMechActionReportMove(mechActionReport);
                break;

            case MechActionTypeEnum.Fire:
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
    }

    /// <summary>
    /// </summary>
    /// <param name="mapControllerObject"></param>
    public override void SetMapControllerObject(MapControllerObject mapControllerObject)
    {
        if (this.mapControllerObject == null)
        {
            logger.Debug("Setting ?", typeof(MapControllerObject).Name);
            this.mapControllerObject = mapControllerObject;
        }
    }

    /// <summary>
    /// </summary>
    /// <param name="mapModelObject"></param>
    public override void SetMapModelObject(MapModelObject mapModelObject)
    {
        if (this.mapModelObject == null)
        {
            logger.Debug("Setting ?", typeof(MapModelObject).Name);
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
            this.currentTurnMechObjectOrderList.Remove(mechObject);
            this.team1MechObjectSet.Remove(mechObject);
            this.team2MechObjectSet.Remove(mechObject);
            GameObject.Destroy(mechGameObject);
            logger.Debug("? has been destroyed!", mechObject);
        }
        //GameObject.Destroy(targetMechObject.GetMechScript().GetGameObject());
        //this.currentTurnMechObjectOrderList.Remove(mechObject);
    }

    /// <summary>
    /// </summary>
    /// <param name="mechActionReport"></param>
    private void InputMechActionReportFire(MechActionReport mechActionReport)
    {
        MechObject mechObject = mechActionReport.GetMechObject();
        CubeCoordinates fireTargetCubeCoordinates = mechActionReport.GetPathObject().GetCubeCoordinatesEnd();
        TileObject fireTileObject = TileObjectFinderUtil.FindTileObjectFrom(fireTargetCubeCoordinates);
        MechObject targetMechObject = fireTileObject.GetTileInfoReport().GetOccupyingMechObject();
        logger.Debug("? is firing at ?", mechObject, targetMechObject);
        HashSet<WeaponCombatReport> weaponCombatReportSet = mechObject.GetMechBehavior().GetWeaponCombatReportSet((PathObjectFire)mechActionReport.GetPathObject());
        bool targetMechIsDestroyed = targetMechObject.GetMechBehavior().InputWeaponCombatReportSet(weaponCombatReportSet);
        if (targetMechIsDestroyed)
        {
            this.DestroyMechObject(targetMechObject);
        }
        // Get Weapon Reports and apply to the target
    }

    /// <summary>
    /// </summary>
    /// <param name="mechActionReport"></param>
    private void InputMechActionReportMove(MechActionReport mechActionReport)
    {
        CubeCoordinates moveTargetCubeCoordinates = mechActionReport.GetPathObject().GetCubeCoordinatesEnd();
        MechObject mechObject = mechActionReport.GetMechObject();
        TileObject moveTileObject = TileObjectFinderUtil.FindTileObjectFrom(moveTargetCubeCoordinates);
        mechObject.SetCubeCoordinates(moveTargetCubeCoordinates);
        moveTileObject.SetOccupyingMechObject(mechObject);
        logger.Debug("? is moving to ?", mechObject, moveTargetCubeCoordinates);
    }

    /// <summary>
    /// </summary>
    /// <param name="mechActionReport"></param>
    private void InputMechActionReportWait(MechActionReport mechActionReport)
    {
        MechObject mechObject = mechActionReport.GetMechObject();
        logger.Debug("? is waiting", mechObject);
    }

    /// <summary>
    /// </summary>
    /// <param name="mechTeam"></param>
    /// <returns></returns>
    private bool ValidMechCount(int mechTeam)
    {
        // Default a case that will fail
        int currentMechForTeam = GameFrameworkObjectConstants.GetMaxMechPerTeam() + 1;
        // Check if the mechReport is for Team 0
        if (mechTeam == 1)
        {
            currentMechForTeam = this.team1MechObjectSet.Count + 1;
        }
        // Check if the mechReport is for Team 1
        else if (mechTeam == 2)
        {
            currentMechForTeam = this.team2MechObjectSet.Count + 1;
        }
        else
        {
            logger.Warn("Invalid MechReport: TeamId is invalid. TeamId=?", mechTeam);
        }
        if (currentMechForTeam > GameFrameworkObjectConstants.GetMaxMechPerTeam())
        {
            logger.Warn("Invalid MechReport: There are already max amount of mechs for Team=?", mechTeam);
        }
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
        private TeamControllerTypeEnum team1Controller;

        // Todo
        private TeamControllerTypeEnum team2Controller;

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public GameFrameworkObjectImpl Build()
        {
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
        public Builder SetTeam1Controller(TeamControllerTypeEnum team1Controller)
        {
            this.team1Controller = team1Controller;
            return this;
        }

        /// <summary>
        /// </summary>
        /// <param name="team2Controller"></param>
        /// <returns></returns>
        public Builder SetTeam2Controller(TeamControllerTypeEnum team2Controller)
        {
            this.team2Controller = team2Controller;
            return this;
        }

        #endregion Public Methods
    }

    /// <summary>
    /// </summary>
    public class MechObjectOrderComparer
        : Comparer<MechObject>
    {
        #region Public Methods

        /// <summary>
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public override int Compare(MechObject x, MechObject y)
        {
            int xOrderPoints = x.GetMechBehavior().GetCurrentOrderPoints();
            int yOrderPoints = y.GetMechBehavior().GetCurrentOrderPoints();

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