using System;
using System.Collections.Generic;
using System.Diagnostics;

/// <summary>
/// Todo
/// </summary>
public class TalonBehaviorMoveableImpl
    : TalonBehaviorMoveable
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    // Todo
    private readonly TalonAttributes talonAttributes = null;

    // Todo
    private Dictionary<CubeCoordinates, PathObject> cubeCoordinatesPathObjectDictionary = new Dictionary<CubeCoordinates, PathObject>();

    // Todo
    private CubeCoordinates currentCubeCoordinates;

    private int currentOrderPoints = 0;

    // Todo
    private int currentTurnPoints = int.MinValue;

    // Todo
    private int currrentMovePoints = int.MinValue;

    #endregion Private Fields

    #region Public Constructors

    public TalonBehaviorMoveableImpl(TalonAttributes talonAttributes)
    {
        if (talonAttributes != null)
        {
            this.talonAttributes = talonAttributes;
            this.ResetTalonAttributeValues();
        }
        else
        {
            throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                "\n\t>" + typeof(TalonAttributes) + " is null");
        }
    }

    #endregion Public Constructors

    #region Public Methods

    public override void BeginPathFinding()
    {
        this.cubeCoordinatesPathObjectDictionary = PathFinderMoveUtil.BeginPathfindingFor(this.currentCubeCoordinates, this.GetMaximumMovePoints());
    }

    public override int GetCurrentMovePoints()
    {
        return this.currrentMovePoints;
    }

    public override int GetCurrentOrderPoints()
    {
        int currentTurnPoints = this.GetCurrentTurnPoints();
        int currentMovePoints = this.GetCurrentMovePoints();
        logger.Info("Turn=?, Move=?, Sum=?, Prod=?, Order=?", currentTurnPoints, currentMovePoints,
            currentTurnPoints + currentMovePoints, currentTurnPoints * currentMovePoints, currentOrderPoints);
        return currentMovePoints + currentTurnPoints;
    }

    public override int GetCurrentTurnPoints()
    {
        return this.currentTurnPoints;
    }

    public override int GetMaximumMovePoints()
    {
        return this.talonAttributes.GetMovePoints();
    }

    public override int GetMaximumOrderPoints()
    {
        return this.GetMaximumMovePoints() * this.GetMaximumTurnPoints();
    }

    public override int GetMaximumTurnPoints()
    {
        return this.talonAttributes.GetTurnPoints();
    }

    public override HashSet<PathObject> GetPathObjectMoveSet()
    {
        return new HashSet<PathObject>(this.cubeCoordinatesPathObjectDictionary.Values);
    }

    public override void InputTalonActionOrder(TalonActionOrderReport talonActionReport)
    {
        TalonActionTypeEnum talonActionType = talonActionReport.GetTalonActionType();
        switch (talonActionType)
        {
            case TalonActionTypeEnum.Wait:
                this.currentOrderPoints += this.GetMaximumMovePoints() * this.currentTurnPoints;
                this.currentTurnPoints -= this.GetMaximumTurnPoints();
                break;

            case TalonActionTypeEnum.Move:
                this.currentOrderPoints += talonActionReport.GetPathObject().GetPathObjectCost();
                this.currrentMovePoints -= talonActionReport.GetPathObject().GetPathObjectCost();
                this.currentTurnPoints -= 1;
                break;

            case TalonActionTypeEnum.Fire:
                this.currentOrderPoints += this.GetMaximumMovePoints();
                this.currentTurnPoints -= 2;
                this.currrentMovePoints -= this.GetMaximumMovePoints();
                break;
        }
    }

    public override void ResetTalonAttributeValues()
    {
        this.currentTurnPoints = this.GetMaximumTurnPoints();
        this.currrentMovePoints = this.GetMaximumMovePoints();
        this.currentOrderPoints = 0;
    }

    public override void SetCubeCoodinates(CubeCoordinates cubeCoordinates)
    {
        if (cubeCoordinates != null)
        {
            this.currentCubeCoordinates = cubeCoordinates;
        }
    }

    #endregion Public Methods
}