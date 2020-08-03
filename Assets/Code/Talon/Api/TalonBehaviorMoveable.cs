using System.Collections.Generic;

/// <summary>
/// Todo
/// </summary>
public abstract class TalonBehaviorMoveable
{
    #region Public Methods

    public abstract void BeginPathFinding();

    public abstract int GetCurrentMovePoints();

    public abstract int GetCurrentOrderPoints();

    public abstract int GetCurrentTurnPoints();

    public abstract int GetMaximumMovePoints();

    public abstract int GetMaximumOrderPoints();

    public abstract int GetMaximumTurnPoints();

    public abstract HashSet<PathObject> GetPathObjectMoveSet();

    public abstract bool InputTalonActionReport(TalonActionReport talonActionReport);

    public abstract void ResetValuesForNewTurn();

    public abstract void SetCubeCoodinates(CubeCoordinates cubeCoordinates);

    #endregion Public Methods
}