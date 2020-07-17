using System.Collections.Generic;

/// <summary>
/// Abstract Implementation for TileObject
/// </summary>
public abstract class TileObjectAbstract
    : TileObject
{
    #region Protected Fields

    protected TileBehavior tileBehavior;

    protected TileInfoReport tileInfoReport;
    protected TileScript tileScript;
    protected TileVisual tileVisual;

    #endregion Protected Fields

    #region Public Methods

    public override CubeCoordinates GetCubeCoordinates()
    {
        return this.GetTileInfoReport().GetCubeCoordinates();
    }

    public override HashSet<CubeCoordinates> GetNeighborCubeCoordinates()
    {
        return this.GetTileInfoReport().GetNeighborCubeCoordinates();
    }

    public override TileBehavior GetTileBehavior()
    {
        return this.tileBehavior;
    }

    public override TileInfoReport GetTileInfoReport()
    {
        if (this.tileBehavior != null)
        {
            if (this.tileInfoReport.GetOccupyingMechObject() != this.tileBehavior.GetOccupyingMechObject())
            {
                this.tileInfoReport = new TileInfoReport.Builder()
                    .SetCubeCoordinates(this.tileInfoReport.GetCubeCoordinates())
                    .SetTileObjectType(this.tileInfoReport.GetTileObjectType())
                    .SetOccupyinMechObject(this.tileBehavior.GetOccupyingMechObject())
                    .SetNeighborTileCoordinates(this.tileInfoReport.GetNeighborCubeCoordinates())
                    .Build();
            }
        }
        return this.tileInfoReport;
    }

    public override int GetTileObjectFireCost()
    {
        return this.GetTileBehavior().GetTileFireCost();
    }

    public override int GetTileObjectMoveCost()
    {
        return this.GetTileBehavior().GetTileMoveCost();
    }

    public override TileObjectTypeEnum GetTileObjectType()
    {
        return this.GetTileInfoReport().GetTileObjectType();
    }

    public override TileScript GetTileScript()
    {
        return this.tileScript;
    }

    public override TileVisual GetTileVisual()
    {
        return this.tileVisual;
    }

    public override void SetOccupyingMechObject(MechObject mechObject)
    {
        this.tileBehavior.SetOccupyingMechObject(mechObject);
    }

    #endregion Public Methods
}