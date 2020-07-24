using System.Collections.Generic;
using System.Diagnostics;

/// <summary>
/// Todo
/// </summary>
public class MechBehaviorMoveable
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    // The int representation for the maximum amount of Move points this Mech has
    private readonly int movePointsMaximum = 0;

    // The int representation for the maximum amount of Turn points this Mech has
    private readonly int turnPointsMaximum = 0;

    private CubeCoordinates currentTileCoordinates;

    // The int representation for the current amount of Move points this Mech has
    private int movePointsCurrent = 0;

    private Dictionary<CubeCoordinates, PathObject> pathObjectDictionary = new Dictionary<CubeCoordinates, PathObject>();

    // The int representation for the current amount of Turn points this Mech has
    private int turnPointsCurrent = 0;

    #endregion Private Fields

    #region Public Constructors

    /// <summary>
    /// Construtor Method, To Construct the MechMoveable with the parameterized values
    /// </summary>
    /// <param name="movePoints">The Integer Move points for this MechMoveable</param>
    /// <param name="turnPoints">The Integer Turn points for this MechMoveable</param>
    public MechBehaviorMoveable(int movePoints, int turnPoints)
    {
        logger.Debug("Constructing Object=?", this.GetType());
        this.movePointsCurrent = movePoints;
        this.movePointsMaximum = movePoints;
        this.turnPointsCurrent = turnPoints;
        this.turnPointsMaximum = turnPoints;
        logger.Debug("Constructed Object=?", this.GetType());
    }

    #endregion Public Constructors

    #region Public Methods

    public void BeginPathFinding()
    {
        this.pathObjectDictionary = PathFinderMoveUtil.BeginPathfindingFor(this.currentTileCoordinates, this.movePointsMaximum);
    }

    /// <summary>
    /// Getter Method, To get the MechMoveable's Current Move Points
    /// </summary>
    /// <returns>The Integer Current Move Points</returns>
    public int GetCurrentMovePoints()
    {
        return this.movePointsCurrent;
    }

    public int GetCurrentOrderPoints()
    {
        int currentTurnPoints = this.GetCurrentTurnPoints();
        if (currentTurnPoints == 0)
        {
            currentTurnPoints++;
        }
        return this.GetCurrentMovePoints() * currentTurnPoints;
    }

    /// <summary>
    /// Getter Method, To get the MechMoveable's Current Turn Points
    /// </summary>
    /// <returns>The Integer Current Turn Points</returns>
    public int GetCurrentTurnPoints()
    {
        return this.turnPointsCurrent;
    }

    /////////////////////////
    // Constructor Methods
    /////////////////////////
    ////////////////////
    // Getter Methods
    ////////////////////
    /// <summary>
    /// Getter Method, To get the MechMoveable's Maximum Move Points
    /// </summary>
    /// <returns>The Integer Maximum Move Points</returns>
    public int GetMaximumMovePoints()
    {
        return this.movePointsMaximum;
    }

    public int GetMaximumTurnPoints()
    {
        return this.turnPointsMaximum;
    }

    public HashSet<PathObject> GetPathObjectMoveSet()
    {
        HashSet<PathObject> pathObjectSet = new HashSet<PathObject>();
        foreach (CubeCoordinates cubeCoordinates in this.pathObjectDictionary.Keys)
        {
            pathObjectSet.Add(this.pathObjectDictionary[cubeCoordinates]);
        }
        return pathObjectSet;
    }

    public bool InputMechActionReport(ActionReport mechActionReport)
    {
        ActionTypeEnum mechActionTypeEnum = mechActionReport.GetMechActionType();
        logger.Debug("MechActionTypeEnum=?", mechActionTypeEnum);
        switch (mechActionTypeEnum)
        {
            case ActionTypeEnum.Wait:
                this.turnPointsCurrent -= this.turnPointsMaximum;
                break;

            case ActionTypeEnum.Move:
                this.movePointsCurrent -= mechActionReport.GetPathObject().GetPathObjectCost();
                this.turnPointsCurrent -= 1;
                break;

            case ActionTypeEnum.Fire:
                this.turnPointsCurrent -= 2;
                this.movePointsCurrent -= this.movePointsMaximum;
                break;
        }
        logger.Debug("TurnPoints=?", this.turnPointsCurrent);
        logger.Debug("OrderPoints=?", this.GetCurrentOrderPoints());
        return this.turnPointsCurrent <= 0;
    }

    public void ResetValuesForNewTurn()
    {
        this.turnPointsCurrent = this.turnPointsMaximum;
        this.movePointsCurrent = this.movePointsMaximum;
    }

    public void SetTileCoodinates(CubeCoordinates tileCoordinates)
    {
        this.currentTileCoordinates = tileCoordinates;
    }

    #endregion Public Methods
}