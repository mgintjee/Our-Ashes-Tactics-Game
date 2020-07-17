using System.Collections.Generic;

/// <summary>
/// API for TileObject
/// </summary>
public abstract class TileObject
{
    #region Public Methods

    public abstract CubeCoordinates GetCubeCoordinates();

    public abstract HashSet<CubeCoordinates> GetNeighborCubeCoordinates();

    public abstract TileBehavior GetTileBehavior();

    public abstract TileInfoReport GetTileInfoReport();

    public abstract int GetTileObjectFireCost();

    public abstract int GetTileObjectMoveCost();

    public abstract TileObjectTypeEnum GetTileObjectType();

    public abstract TileScript GetTileScript();

    public abstract TileVisual GetTileVisual();

    public abstract void SetOccupyingMechObject(MechObject mechObject);

    #endregion Public Methods
}