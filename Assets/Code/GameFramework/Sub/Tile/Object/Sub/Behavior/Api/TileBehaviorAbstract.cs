using System.Collections.Generic;

/// <summary>
/// Abstract Implementation for TileBehavior
/// </summary>
public abstract class TileBehaviorAbstract
    : TileBehavior
{
    #region Protected Fields

    protected MechObject occupyingMechObject;

    #endregion Protected Fields

    ////////////////////
    // Getter Methods
    ////////////////////

    #region Public Methods

    /// <summary>
    /// Getter method, to get the Coordinates of this TileObject
    /// </summary>
    /// <returns>The Coordinates of this TileObject</returns>
    public override CubeCoordinates GetCubeCoordinates()
    {
        return this.tileObject.GetCubeCoordinates();
    }

    public override HashSet<CubeCoordinates> GetNeighborCubeCoordinatesSet()
    {
        return this.tileObject.GetNeighborCubeCoordinates();
    }

    public override MechObject GetOccupyingMechObject()
    {
        return this.occupyingMechObject;
    }

    /// <summary>
    /// Getter method, to get the cost to fire through this TileObject
    /// </summary>
    /// <returns>THe fire cost of this TileObject</returns>
    public override int GetTileFireCost()
    {
        // Collect the Fire cost
        int fireCost = TileBehaviorConstants.GetTileObjectTypeFireCost(this.GetTileObjectType());

        // Check if there is an occupying Object
        if (this.occupyingMechObject != null)
        {
            //fireCost += GameConstants.Tile.OccupyingObjectFireCost;
        }

        return fireCost;
    }

    public override TileInfoReport GetTileInfoReport()
    {
        return this.tileObject.GetTileInfoReport();
    }

    /// <summary>
    /// Getter method, to get the cost to move through this TileObject
    /// </summary>
    /// <returns>The move cost of this TileObject</returns>
    public override int GetTileMoveCost()
    {
        // Collect the Move cost
        int moveCost = TileBehaviorConstants.GetTileObjectTypeMoveCost(this.GetTileObjectType());
        // Check if there is an occupying Object
        if (this.occupyingMechObject != null)
        {
            // Increment by max int to ensure it is not traversable
            moveCost += int.MaxValue;
        }

        return moveCost;
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public override TileObjectTypeEnum GetTileObjectType()
    {
        return this.tileObject.GetTileObjectType();
    }

    public override void SetOccupyingMechObject(MechObject mechObject)
    {
        this.occupyingMechObject = mechObject;
    }

    #endregion Public Methods
}