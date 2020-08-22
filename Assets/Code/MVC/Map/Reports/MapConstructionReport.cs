using System;
using System.Collections.Generic;

/// <summary>
/// Report used to generate the Map
/// </summary>
public class MapConstructionReport

{
    #region Private Fields

    private readonly bool mapMirrored = false;
    private readonly int mapRadius = int.MinValue;
    private readonly int mapSeed = int.MinValue;

    #endregion Private Fields

    #region Private Constructors

    private MapConstructionReport(int mapSeed, int mapRadius, bool mapMirrored)
    {
        this.mapSeed = mapSeed;
        this.mapRadius = mapRadius;
        this.mapMirrored = mapMirrored;
    }

    #endregion Private Constructors

    #region Public Methods

    public bool GetMapMirrored()
    {
        return this.mapMirrored;
    }

    public int GetMapRadius()
    {
        return this.mapRadius;
    }

    public int GetMapSeed()
    {
        return this.mapSeed;
    }

    public override string ToString()
    {
        return this.GetType() + ": " +
            "\n\t>mapSeed: " + this.GetMapSeed() +
            ",\n\t>mapRadius: " + this.GetMapRadius() +
            ",\n\t>mapMirrored: " + this.GetMapMirrored();
    }

    #endregion Public Methods

    #region Public Classes

    public class Builder
    {
        #region Private Fields

        private bool mapMirrored;
        private int mapRadius = -1;
        private int mapSeed = -1;
        private bool setMapMirrored = false;

        #endregion Private Fields

        #region Public Methods

        public MapConstructionReport Build()
        {
            HashSet<string> invalidReasons = this.IsValid();
            // Check that the set parameters are valid
            if (invalidReasons.Count == 0)
            {
                // Instantiate a new Report
                return new MapConstructionReport(this.mapSeed, this.mapRadius, this.mapMirrored);
            }
            else
            {
                throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                    string.Join("\n", invalidReasons));
            }
        }

        public Builder SetMapMirrored(bool mapMirrored)
        {
            this.mapMirrored = mapMirrored;
            this.setMapMirrored = true;
            return this;
        }

        public Builder SetMapRadius(int mapRadius)
        {
            this.mapRadius = mapRadius;
            return this;
        }

        public Builder SetMapSeed(int mapSeed)
        {
            this.mapSeed = mapSeed;
            return this;
        }

        #endregion Public Methods

        #region Private Methods

        private HashSet<string> IsValid()
        {
            // Default an empty Set: String
            HashSet<string> argumentExceptionSet = new HashSet<string>();
            // Check that mapMirrored has been set
            if (!this.setMapMirrored)
            {
                argumentExceptionSet.Add("mapMirrored has not been set");
            }
            // Check that mapSeed has been set
            if (this.mapSeed == int.MinValue)
            {
                argumentExceptionSet.Add("mapSeed has not been set");
            }
            // Check that mapSeed is valid
            if (this.mapRadius < 2)
            {
                argumentExceptionSet.Add("mapRadius= " + this.mapRadius + " is invalid");
            }
            return argumentExceptionSet;
        }

        #endregion Private Methods
    }

    #endregion Public Classes
}