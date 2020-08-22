using System;
using System.Collections.Generic;

/// <summary>
/// Report to display the construction information for a specific HexTile
/// </summary>
public class HexTileConstructionReport
{
    #region Private Fields

    private readonly CubeCoordinates cubeCoordinates = null;
    private readonly HexTileTypeEnum hexTileType = HexTileTypeEnum.NULL;
    private readonly HashSet<CubeCoordinates> neighborCubeCoordinatesSet = null;

    #endregion Private Fields

    #region Private Constructors

    private HexTileConstructionReport(CubeCoordinates cubeCoordinates, HashSet<CubeCoordinates> neighborCubeCoordinatesSet, HexTileTypeEnum hexTileType)
    {
        this.cubeCoordinates = cubeCoordinates;
        this.neighborCubeCoordinatesSet = new HashSet<CubeCoordinates>(neighborCubeCoordinatesSet);
        this.hexTileType = hexTileType;
    }

    #endregion Private Constructors

    #region Public Methods

    public CubeCoordinates GetCubeCoordinates()
    {
        return this.cubeCoordinates;
    }

    public HexTileTypeEnum GetHexTileType()
    {
        return this.hexTileType;
    }

    public HashSet<CubeCoordinates> GetNeighborCubeCoordinatesSet()
    {
        return new HashSet<CubeCoordinates>(this.neighborCubeCoordinatesSet);
    }

    public override string ToString()
    {
        return this.GetType() + ":" +
            "\n\t>" + typeof(CubeCoordinates) + "=" + this.GetCubeCoordinates() +
            "\n\t>" + typeof(HexTileTypeEnum) + "=" + this.GetHexTileType() +
            "\n\t>neighborCubeCoordinatesSet=[" + string.Join(",", this.GetNeighborCubeCoordinatesSet()) + "]";
    }

    #endregion Public Methods

    #region Public Classes

    public class Builder
    {
        #region Private Fields

        private CubeCoordinates cubeCoordinates = null;
        private HexTileTypeEnum hexTileType = HexTileTypeEnum.NULL;
        private HashSet<CubeCoordinates> neighborCubeCoordinatesSet = null;

        #endregion Private Fields

        #region Public Methods

        public HexTileConstructionReport Build()
        {
            HashSet<string> invalidReasons = this.IsValid();
            // Check that the set parameters are valid
            if (invalidReasons.Count == 0)
            {
                // Instantiate a new Report
                return new HexTileConstructionReport(this.cubeCoordinates, this.neighborCubeCoordinatesSet, this.hexTileType);
            }
            else
            {
                throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                    string.Join("\n\t>", invalidReasons));
            }
        }

        public Builder SetCubeCoordinates(CubeCoordinates cubeCoordinates)
        {
            this.cubeCoordinates = cubeCoordinates;
            return this;
        }

        public Builder SetNeighborCubeCoordinatesSet(HashSet<CubeCoordinates> neighborCubeCoordinatesSet)
        {
            this.neighborCubeCoordinatesSet = neighborCubeCoordinatesSet;
            return this;
        }

        public Builder SetTileType(HexTileTypeEnum hexTileType)
        {
            this.hexTileType = hexTileType;
            return this;
        }

        #endregion Public Methods

        #region Private Methods

        private HashSet<string> IsValid()
        {
            // Default an empty Set: String
            HashSet<string> argumentExceptionSet = new HashSet<string>();
            // Check that cubeCoordinates has been set
            if (this.cubeCoordinates == null)
            {
                argumentExceptionSet.Add(typeof(CubeCoordinates) + " has not been set");
            }
            // Check that hexTileType has been set
            if (this.hexTileType == HexTileTypeEnum.NULL)
            {
                argumentExceptionSet.Add(typeof(HexTileTypeEnum) + " has not been set");
            }
            // Check that neighborCubeCoordinatesSet is has been set
            if (this.neighborCubeCoordinatesSet == null)
            {
                argumentExceptionSet.Add("neighborCubeCoordinatesSet has not been set");
            }
            else
            {
                if (this.neighborCubeCoordinatesSet.Count < 1)
                {
                    argumentExceptionSet.Add("neighborCubeCoordinatesSet contains an invalid amount " + this.neighborCubeCoordinatesSet.Count);
                }
            }
            return argumentExceptionSet;
        }

        #endregion Private Methods
    }

    #endregion Public Classes
}