using System.Collections.Generic;

/// <summary>
/// Todo
/// </summary>
public class TileInfoReport
{
    #region Private Fields

    private readonly CubeCoordinates cubeCoordinates;
    private readonly HashSet<CubeCoordinates> neighborCubeCoordinates;
    private readonly MechObject occupyingMechObject;
    private readonly TileObjectTypeEnum tileObjectType;

    #endregion Private Fields

    #region Public Constructors

    public TileInfoReport(CubeCoordinates cubeCoordinates, TileObjectTypeEnum tileObjectType, MechObject occupyingMechObject, HashSet<CubeCoordinates> neighborCubeCoordinates)
    {
        this.cubeCoordinates = cubeCoordinates;
        this.neighborCubeCoordinates = new HashSet<CubeCoordinates>(neighborCubeCoordinates);
        this.tileObjectType = tileObjectType;
        this.occupyingMechObject = occupyingMechObject;
    }

    public TileInfoReport(TileInfoReport tileInfoReport)
    {
        this.cubeCoordinates = new CubeCoordinates(tileInfoReport.GetCubeCoordinates());
        this.tileObjectType = tileInfoReport.GetTileObjectType();
        this.occupyingMechObject = tileInfoReport.GetOccupyingMechObject();
        this.neighborCubeCoordinates = new HashSet<CubeCoordinates>(tileInfoReport.GetNeighborCubeCoordinates());
    }

    #endregion Public Constructors

    #region Public Methods

    public CubeCoordinates GetCubeCoordinates()
    {
        return this.cubeCoordinates;
    }

    public HashSet<CubeCoordinates> GetNeighborCubeCoordinates()
    {
        return this.neighborCubeCoordinates;
    }

    public MechObject GetOccupyingMechObject()
    {
        return this.occupyingMechObject;
    }

    public TileObjectTypeEnum GetTileObjectType()
    {
        return this.tileObjectType;
    }

    public override string ToString()
    {
        return "TileInfoReport: CubeCoordinates=" + this.cubeCoordinates.ToString() +
            ", TileObjectType=" + this.tileObjectType +
            ", OccupyingMechScript: " + ((this.occupyingMechObject != null)
            ? this.occupyingMechObject.ToString()
            : "Empty");
    }

    #endregion Public Methods

    #region Public Classes

    public class Builder
    {
        #region Private Fields

        private CubeCoordinates cubeCoordinates;
        private HashSet<CubeCoordinates> neighborCubeCoordinates;
        private MechObject occupyingMechObject;
        private TileObjectTypeEnum tileObjectType;

        #endregion Private Fields

        #region Public Methods

        public TileInfoReport Build()
        {
            return new TileInfoReport(this.cubeCoordinates,
                this.tileObjectType,
                this.occupyingMechObject,
                this.neighborCubeCoordinates);
        }

        public Builder SetCubeCoordinates(CubeCoordinates tileCoordinates)
        {
            this.cubeCoordinates = tileCoordinates;
            return this;
        }

        public Builder SetNeighborTileCoordinates(HashSet<CubeCoordinates> neighborCubeCoordinates)
        {
            this.neighborCubeCoordinates = neighborCubeCoordinates;
            return this;
        }

        public Builder SetOccupyinMechObject(MechObject occupyingMechObject)
        {
            this.occupyingMechObject = occupyingMechObject;
            return this;
        }

        public Builder SetTileObjectType(TileObjectTypeEnum tileObjectType)
        {
            this.tileObjectType = tileObjectType;
            return this;
        }

        #endregion Public Methods
    }

    #endregion Public Classes
}