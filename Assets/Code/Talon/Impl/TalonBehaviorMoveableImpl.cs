using System.Collections.Generic;

/// <summary>
/// Todo
/// </summary>
public class TalonBehaviorMoveableImpl
    : TalonBehaviorMoveable
{
    #region Private Fields

    private readonly TalonAttributes talonAttributes = null;
    private int currentTurnPoints = int.MinValue;
    private int currrentMovePoints = int.MinValue;

    #endregion Private Fields

    #region Public Constructors

    public TalonBehaviorMoveableImpl(TalonAttributes talonAttributes)
    {
        if (talonAttributes != null)
        {
            this.talonAttributes = talonAttributes;
            this.currrentMovePoints = this.talonAttributes.GetMovePoints();
            this.currentTurnPoints = this.talonAttributes.GetTurnPoints();
        }
    }

    #endregion Public Constructors

    #region Public Methods

    public override void BeginPathFinding()
    {
        //throw new System.NotImplementedException();
    }

    public override int GetCurrentMovePoints()
    {
        return this.currrentMovePoints;
    }

    public override int GetCurrentOrderPoints()
    {
        return this.currrentMovePoints;
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
        return int.MinValue;
    }

    public override int GetMaximumTurnPoints()
    {
        return this.talonAttributes.GetTurnPoints();
    }

    public override HashSet<PathObject> GetPathObjectMoveSet()
    {
        //throw new System.NotImplementedException();
        return null;
    }

    public override bool InputTalonActionReport(TalonActionReport talonActionReport)
    {
        //throw new System.NotImplementedException();
        return true;
    }

    public override void ResetValuesForNewTurn()
    {
        throw new System.NotImplementedException();
    }

    public override void SetCubeCoodinates(CubeCoordinates cubeCoordinates)
    {
        // throw new System.NotImplementedException();
    }

    #endregion Public Methods
}